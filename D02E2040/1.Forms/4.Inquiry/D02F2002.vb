'#-------------------------------------------------------------------------------------
'# Created Date: 12/05/2010 08:06:51 AM
'# Created User: Đặng Vũ Minh Quang
'# Modify Date: 12/05/2010 08:06:51 AM
'# Modify User: Đặng Vũ Minh Quang
'#-------------------------------------------------------------------------------------
Public Class D02F2002
    Dim dtGrid As DataTable
    Dim sFilter As New System.Text.StringBuilder()

#Region "Const of tdbg - Total of Columns: 21"
    Private Const COL_GroupID As Integer = 0            ' GroupID
    Private Const COL_BatchID As Integer = 1            ' BatchID
    Private Const COL_SplitBatchID As Integer = 2       ' SplitBatchID
    Private Const COL_ChangeDate As Integer = 3         ' Ngày tác động
    Private Const COL_ChangeNo As Integer = 4           ' Mã nghiệp vụ
    Private Const COL_VoucherNo As Integer = 5          ' Số phiếu
    Private Const COL_Notes As Integer = 6              ' Diễn giải
    Private Const COL_AssetID As Integer = 7            ' Mã tài sản
    Private Const COL_AssetName As Integer = 8          ' Tên tài sản
    Private Const COL_StrChangeVoucherNo As Integer = 9 ' Chứng từ tác động
    Private Const COL_Notes1 As Integer = 10            ' Ghi chú 1
    Private Const COL_Notes2 As Integer = 11            ' Ghi chú 2
    Private Const COL_Notes3 As Integer = 12            ' Ghi chú 3
    Private Const COL_CreateUserID As Integer = 13      ' CreateUserID
    Private Const COL_CreateDate As Integer = 14        ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 15  ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 16    ' LastModifyDate
    Private Const COL_UseAccount As Integer = 17        ' Tác động tài chính
    Private Const COL_Locked As Integer = 18            ' Khóa
    Private Const COL_ModuleID As Integer = 19          ' ModuleID
    Private Const COL_Period As Integer = 20            ' Period
#End Region



#Region "UserControl"
    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region

    Private Sub D09F2170_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
                Exit Sub
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
        End Select

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.N 'them moi
                    If Not tsbAdd.Enabled Then Exit Sub
                    tsbAdd_Click(Nothing, Nothing)
                    Exit Sub
                Case Keys.E 'sua
                    If Not tsbEdit.Enabled Then Exit Sub
                    tsbEdit_Click(Nothing, Nothing)
                    Exit Sub
                Case Keys.F 'Tim kiem
                    If Not tsbFind.Enabled Then Exit Sub
                    tsbFind_Click(Nothing, Nothing)
                    Exit Sub
                Case Keys.A 'Liet ke tat ca
                    If Not tsbListAll.Enabled Then Exit Sub
                    tsbListAll_Click(Nothing, Nothing)
                    Exit Sub
                Case Keys.P 'In
                    If Not tsbPrint.Enabled Then Exit Sub
                    tsbPrint_Click(Nothing, Nothing)
                    Exit Sub
            End Select
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnF12_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk(rl3("Thong_tin_tren_luoi_da_thay_doi_ban_co_muon_Refresh_lai_khong")) = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
        '***************************************
    End Sub


    Dim iPer_F5557 As Integer

    Private Sub D09F2170_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        Loadlanguage()
        CheckIdTextBox(txtVoucherNo)
        ResetColorGrid(tdbg, SPLIT0, 1)
        iPer_F5557 = ReturnPermission("D02F5557")
        InputDateInTrueDBGrid(tdbg, COL_ChangeDate)
        LoadTDBCombo()
        LoadDefault()
        ResetGrid()
        c1dateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        '******************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        CallD09U1111_Button(True)
        '******************************
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadDefault()
        '******************************
        tdbcPeriodFrom.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcPeriodTo.Text = giTranMonth.ToString("00") & "/" & giTranYear
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcPeriodTo
        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D02")
        'Load tdbcFromAssetID
        sSQL = "--Do nguon combo Ma tai san" & vbCrLf
        sSQL &= " SELECT  '%' AS AssetID, " & AllName & " AS AssetName, 0 AS DisplayOrder UNION ALL"
        sSQL &= " SELECT DISTINCT N19.AssetID, N19.AssetName" & UnicodeJoin(gbUnicode) & " As AssetName, 1 AS DisplayOrder"
        sSQL &= " FROM	D02N0019 (" & giTranMonth & ", " & giTranYear & ") AS N19 "
        sSQL &= " LEFT JOIN	D02T0001 AS T01 ON T01.AssetID = N19.AssetID "
        sSQL &= " WHERE N19.IsCompleted = 1 AND N19.Disabled = 0 AND N19.DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " AND N19.TranMonth + N19.TranYear * 100 <= " & giTranMonth & "+" & giTranYear & "*100"
        sSQL &= " ORDER BY	DisplayOrder, AssetID"
        Dim dtAssetID As DataTable = ReturnDataTable(sSQL)

        LoadDataSource(tdbcFromAssetID, dtAssetID, gbUnicode)
        LoadDataSource(tdbcToAssetID, dtAssetID.Copy, gbUnicode)
        'Load tdbcChangeNo
        sSQL = "--Do nguon combo Nghiep vu " & vbCrLf
        sSQL &= " SELECT '%' AS ChangeNo, " & AllName & " AS ChangeName, 0 AS DisplayOrder UNION ALL "
        sSQL &= " SELECT DISTINCT T1.ChangeNo, T1.ChangeName" & UnicodeJoin(gbUnicode) & " As ChangeName, 1 AS DisplayOrder "
        sSQL &= " FROM D02T0201 T1 WITH(NOLOCK) LEFT JOIN (SELECT DISTINCT ChangeNo FROM D02T0204 WITH(NOLOCK)) T2 ON T1.ChangeNo = T2.ChangeNo "
        sSQL &= " WHERE T1.Disabled = 0 ORDER BY DisplayOrder, ChangeNo "

        LoadDataSource(tdbcChangeNo, sSQL, gbUnicode)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("_Truy_van_nghiep_vu_tac_dong_tai_san_-_D02F2002") & UnicodeCaption(gbUnicode) ' Truy vÊn nghiÖp vó tÀc ¢èng tªi s¶n - D02F2002
        '================================================================ 
        btnF12.Text = "F12 (" & rL3("Hien_thi") & ")"
        '================================================================ 
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("Notes").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("AssetID").Caption = rl3("Ma_tai_san") 'Mã tài sản
        tdbg.Columns("AssetName").Caption = rl3("Ten_tai_san") 'Tên tài sản
        tdbg.Columns("ChangeNo").Caption = rl3("Ma_nghiep_vu") 'Mã nghiệp vụ
        tdbg.Columns("ChangeDate").Caption = rl3("Ngay_tac_dong") 'Ngày tác động
        tdbg.Columns("Notes1").Caption = rl3("Ghi_chu") & " 1" 'Ghi chú 1
        tdbg.Columns("Notes2").Caption = rl3("Ghi_chu") & " 2" 'Ghi chú 2
        tdbg.Columns("Notes3").Caption = rL3("Ghi_chu") & " 3" 'Ghi chú 3
        '20/9/2019, Nguyễn Thị Hân:id 122950-hiển thị thông tin tác động tài chính tại màn hình truy vấn tác động
        tdbg.Columns("UseAccount").Caption = rL3("Tac_dong_tai_chinh")      ' Tác động tài chính

        tdbg.Columns(COL_Locked).Caption = rL3("Khoa") 'Khóa

        '================================================================ 
        tdbg.Columns(COL_StrChangeVoucherNo).Caption = rL3("Chung_tu_tac_dong") 'Chứng từ tác động

        'Them ngay 21/12/2012 theo incident 53005
        chkDate.Text = rl3("Ngay") ' Ngày
        chkPeriod.Text = rl3("Ky") 'Kỳ
        lblFromAssetID.Text = rl3("Ma_tai_san")
        lblVoucherNo.Text = rl3("So_phieu")
        lblChangeNo.Text = rl3("Nghiep_vu")
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        tdbcFromAssetID.Columns("AssetID").Caption = rl3("Ma") 'Mã
        tdbcFromAssetID.Columns("AssetName").Caption = rl3("Ten") 'Tên
        tdbcToAssetID.Columns("AssetID").Caption = rl3("Ma") 'Mã
        tdbcToAssetID.Columns("AssetName").Caption = rl3("Ten") 'Tên
        tdbcChangeNo.Columns("ChangeNo").Caption = rl3("Ma") 'Mã
        tdbcChangeNo.Columns("ChangeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tsbAdd.Text = rl3("_Them") '&Thêm
        tsbView.Text = rl3("Xe_m") 'Xe&m
        tsbEdit.Text = rl3("_Sua") '&Sửa
        tsbDelete.Text = rl3("_Xoa") '&Xóa
        tsbFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        tsbListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        tsbSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        tsbPrint.Text = rl3("_In") '&In
        tsbClose.Text = rl3("Do_ng") 'Đó&ng

        tsbAdd.ToolTipText = tsbAdd.Text.Replace("&", "") & " (Ctrl+N)"
        tsbEdit.ToolTipText = tsbEdit.Text.Replace("&", "") & " (Ctrl+E)"
        tsbView.ToolTipText = tsbView.Text.Replace("&", "")
        tsbDelete.ToolTipText = tsbDelete.Text.Replace("&", "")
        tsbFind.ToolTipText = tsbFind.Text.Replace("&", "") & " (Ctrl+F)"
        tsbListAll.ToolTipText = tsbListAll.Text.Replace("&", "") & " (Ctrl+A)"
        tsbSysInfo.ToolTipText = tsbSysInfo.Text.Replace("&", "")
        tsbPrint.ToolTipText = tsbPrint.Text.Replace("&", "") & " (Ctrl+P)"
        tsbClose.ToolTipText = tsbClose.Text.Replace("&", "")

        tsbImportNoAssetTrans.Text = rl3("_Nghiep_vu_tac_dong_phi_tai_chinh") '&Nghiệp vụ tác động phi tài chính
        tsmImportNoAssetTrans.Text = tsbImportNoAssetTrans.Text
        mnsImportNoAssetTrans.Text = tsbImportNoAssetTrans.Text
        tsbImportAssetTrans.Text = rl3("Nghiep_vu_tac_dong__tai_chinh") 'Nghiệp vụ tác động &tài chính
        tsmImportAssetTrans.Text = tsbImportAssetTrans.Text
        mnsImportAssetTrans.Text = tsbImportAssetTrans.Text
    End Sub

#Region "LoadTDBGrid"


    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        If chkPeriod.Checked And Not chkDate.Checked Then
            sSQL = SQLStoreD02P5001(2)
        ElseIf chkDate.Checked And Not chkPeriod.Checked Then
            sSQL = SQLStoreD02P5001(1)
        ElseIf chkPeriod.Checked And chkDate.Checked Then
            sSQL = SQLStoreD02P5001(3)
        Else
            sSQL = SQLStoreD02P5001(4)
        End If
        dtGrid = ReturnDataTable(sSQL)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =’’
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            'Dim dr() As DataRow = dt1.Select(tdbg.Columns(COL_AssetID).DataField & "=" & SQLString(sKey), dt1.DefaultView.Sort)
            Dim dr() As DataRow = dt1.Select(tdbg.Columns(COL_GroupID).DataField & "=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If

    End Sub

    'Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
    '    Dim sSQL As String
    '    sSQL = SQLStoreD02P5001()
    '    dtGrid = ReturnDataTable(sSQL)
    '    If dtGrid.Rows.Count < 1 Then 'Không có dữ liệu
    '        gbEnabledUseFind = False
    '        LoadDataSource(tdbg, dtGrid, gbUnicode)
    '        CheckMenu(PARA_FormIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
    '    Else 'Có dữ liệu
    '        If Not FlagEdit Or Not gbEnabledUseFind Then 'Không phải nhấn Sửa (Xóa) hay Chưa nhấn tìm kiếm
    '            LoadDataSource(tdbg, dtGrid, gbUnicode)
    '            CheckMenu(PARA_FormIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
    '        Else 'Nhấn Sửa (Xóa) hay đã nhấn Tìm kiếm
    '            ReLoadTDBGrid()
    '        End If

    '        If sKeyID <> "" Then
    '            'dtGrid.DefaultView.Sort = "EmployeeID" 'Field của khóa chính
    '            'tdbg.Bookmark = dtGrid.DefaultView.Find(sKeyID)

    '            Dim dt As DataTable = dtGrid.DefaultView.Table
    '            Dim dr() As DataRow = dt.Select("BatchID = " & SQLString(sKeyID))
    '            If dr.Length > 0 Then
    '                tdbg.Bookmark = dt.Rows.IndexOf(dr(0))
    '            End If
    '        End If
    '    End If

    '    '*********************************
    '    FooterTotalGrid(tdbg, COL_ChangeNo)

    'End Sub
#End Region

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""
    Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, mnsFind.Click, tsmFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        ShowFindDialogClient(Finder, gdtCaptionExcel, Me.Name, "0", gbUnicode)
        '*****************************************
    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, mnsListAll.Click, tsmListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Dim iPerD02P8050 As Integer = ReturnPermission("D02P8050") ' Import nghiệp vụ phi tài chính
    Dim iPerD02P8060 As Integer = ReturnPermission("D02P8060") ' Import nghiệp vụ tài chính

    Private Sub ReLoadTDBGrid()
        Dim strFind As String
        strFind = sFind
        If sFilter.ToString() <> "" Then
            If strFind <> "" Then
                strFind &= " And " & sFilter.ToString
            Else
                strFind &= sFilter.ToString
            End If
        End If
        '   LoadGridFind(tdbg, dtGrid, strFind)
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()

    End Sub

    Private Sub ResetGrid()
        CheckMenu(PARA_FormIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1, , "D02F5603")
        tsbEditOther.Enabled = tsbEdit.Enabled
        tsmEditOther.Enabled = tsbEditOther.Enabled
        mnsEditOther.Enabled = tsbEditOther.Enabled
        FooterTotalGrid(tdbg, COL_ChangeNo)
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, tdbg.Top + tdbg.Height - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        'Những cột bắt buộc nhập
        If bLoadFirst = True Then
            Dim arrColObligatory() As Integer = {COL_AssetID, COL_AssetName}
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT2, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        Dim dtCaptionCols As DataTable

        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

#End Region

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, mnsSysInfo.Click, tsmSysInfo.Click
        ShowSysInfoDialog(tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, mnsAdd.Click, tsmAdd.Click
        Dim frm As New D02F2003
        Dim sKey As String = ""
        With frm
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            'sKey = .AssetID
            sKey = .GroupID
            .Dispose()
            If gbSavedOK Then
                LoadTDBGrid(True, sKey)
            End If
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click, tsmEdit.Click
        If CheckDataNotInPeriod(tdbg, COL_Period) Then Exit Sub
        If Not AllowEditDelete() Then Exit Sub
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If
        Dim frm As New D02F2003

        With frm
            .GroupID = tdbg.Columns(COL_GroupID).Text
            .BatchID = tdbg.Columns(COL_BatchID).Text
            .AssetID = tdbg.Columns(COL_AssetID).Text
            .ChangeNo = tdbg.Columns(COL_ChangeNo).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()

            If gbSavedOK Then
                'LoadTDBGrid(False, tdbg.Columns(COL_BatchID).Text)
                LoadTDBGrid(False, tdbg.Columns(COL_GroupID).Text)
            End If
        End With
    End Sub

    '29/11/2013 id 61503
    Private Sub tsbEditOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditOther.Click, tsmEditOther.Click, mnsEditOther.Click
        If CheckDataNotInPeriod(tdbg, COL_Period) Then Exit Sub
        '  If Not AllowEditDelete() Then Exit Sub
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003"))
            Exit Sub
        End If
        Dim frm As New D02F2003

        With frm
            .GroupID = tdbg.Columns(COL_GroupID).Text
            .BatchID = tdbg.Columns(COL_BatchID).Text
            .AssetID = tdbg.Columns(COL_AssetID).Text
            .FormState = EnumFormState.FormEditOther
            .ShowDialog()
            .Dispose()

            If gbSavedOK Then
                'LoadTDBGrid(False, tdbg.Columns(COL_BatchID).Text)
                LoadTDBGrid(False, tdbg.Columns(COL_GroupID).Text)
            End If
        End With
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, mnsView.Click, tsmView.Click
        Dim frm As New D02F2003
        With frm
            .GroupID = tdbg.Columns(COL_GroupID).Text
            .BatchID = tdbg.Columns(COL_BatchID).Text
            .AssetID = tdbg.Columns(COL_AssetID).Text
            .ChangeNo = tdbg.Columns(COL_ChangeNo).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    ''' <summary>
    ''' Kiểm tra dữ liệu không thuộc kỳ hiện tại
    ''' </summary>
    ''' <param name="tdbg">Tên lưới </param>
    ''' <param name="Col_Period">Cột Kỳ có dạng (MM/yyyy) </param>
    ''' <remarks>Trả về True là vi phạm </remarks>
    Public Function CheckDataNotInPeriod(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal Col_Period As Integer) As Boolean
        If tdbg.Columns(Col_Period).Text.Trim <> giTranMonth.ToString("00") & "/" & giTranYear.ToString("0000") Then
            D99C0008.MsgL3(rl3("MSG000001"))
            Return True
        End If
        Return False
    End Function

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click, tsmDelete.Click
        If CheckDataNotInPeriod(tdbg, COL_Period) Then Exit Sub
        Dim sSQL As String
        Dim bResult As Boolean

        If Not AllowEditDelete() Then Exit Sub
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If
        sSQL = SQLStoreD02P5006()

        bResult = ExecuteSQL(sSQL)
        If bResult Then
            DeleteOK()
            'RunAuditLog("OtherTrans", "03", tdbg.Columns(COL_AssetID).Text, tdbg.Columns(COL_ChangeNo).Text, tdbg.Columns(COL_ChangeDate).Text, "", "")
            Lemon3.D91.RunAuditLog("02", "OtherTrans", "03", tdbg.Columns(COL_AssetID).Text, tdbg.Columns(COL_ChangeNo).Text, tdbg.Columns(COL_ChangeDate).Text)
            DeleteVoucherNoD91T9111(tdbg.Columns(COL_VoucherNo).Value.ToString, "D02T0012", "VoucherNo")
            'Cach moi
            tdbg.Delete()
            dtGrid.AcceptChanges()

            ResetGrid()
        Else
            DeleteNotOK()
        End If
    End Sub
    ' update 27/5/2013 id 56766
    Private Sub tsbImportNoAssetTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportNoAssetTrans.Click, tsmImportNoAssetTrans.Click, mnsImportNoAssetTrans.Click
        '    Me.Cursor = Cursors.WaitCursor
        '    gbSavedOK = False
        '    Dim frm As New D80F2090
        '    With frm
        '        .FormPermission = "D02F5603"
        '        .ModuleID = "D02"
        '        .TransTypeID = "D02F2002A" 'Theo TL phân tích
        '        .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '        .ShowDialog()
        '        If .OutPut01 Then gbSavedOK = .OutPut01
        '        .Dispose()
        '    End With
        '    If gbSavedOK Then
        '        'Load lại dữ liệu
        '        LoadTDBGrid(True)
        '    End If

        Me.Cursor = Cursors.WaitCursor
        If CallShowDialogD80F2090(D02, "D02F5603", "D02F2002A") Then
            LoadTDBGrid(True)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    ' update 27/5/2013 id 56766
    Private Sub tsbImportAssetTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportAssetTrans.Click, tsmImportAssetTrans.Click, mnsImportAssetTrans.Click
        Me.Cursor = Cursors.WaitCursor
        gbSavedOK = False
        'Dim frm As New D80F2090
        'With frm
        '    .FormPermission = "D02F5603"
        '    .ModuleID = "D02"
        '    .TransTypeID = "D02F2002B" 'Theo TL phân tích
        '    .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '    .ShowDialog()
        '    If .OutPut01 Then gbSavedOK = .OutPut01
        '    .Dispose()
        'End With
        'If gbSavedOK Then
        '    'Load lại dữ liệu
        '    LoadTDBGrid(True)
        'End If

        Me.Cursor = Cursors.WaitCursor
        If CallShowDialogD80F2090(D02, "D02F5603", "D02F2002B") Then
            'Load lại dữ liệu VD: LoadTDBGrid(True)
            LoadTDBGrid(True)
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub tsbPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, mnsPrint.Click, tsmPrint.Click
        'Me.Cursor = Cursors.WaitCursor

        'Dim report As New D99C1003
        'Dim conn As New SqlConnection(gsConnectionString)
        'Dim sReportName As String = "D02R1010"
        'Dim sSubReportName As String = "D02R0000"
        'Dim sReportCaption As String = ""
        'Dim sSQL As String = ""
        'Dim sSQLSub As String = ""

        'Dim sReportPath As String = ""
        'Dim sReportTitle As String = "" 'Thêm biến
        'Dim sCustomReport As String = ""

        'sReportName = GetReportPath(Me.Name, sReportName, sCustomReport, sReportPath, sReportTitle)
        'If sReportName = "" Then Me.Cursor = Cursors.Default : Exit Sub

        'sReportCaption = "BÀo cÀo nghiÖp vó tÀc ¢èng tªi s¶n" & " - " & sReportName
        'sSQL = SQLStoreD02P4200()

        'sSQLSub = "SELECT CompanyName, CompanyPhone, CompanyFax, AddressLine1, AddressLine2,AddressLine3, AddressLine4, AddressLine5, CompanyAddress" & vbCrLf
        'sSQLSub &= "FROM D91V0016 WHERE DivisionID = " & SQLString(gsDivisionID)

        ''Phải đặt sau Lệnh gán sSQLSub =""
        'UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)

        'With report
        '    .OpenConnection(conn)
        '    .AddSub(sSQLSub, sSubReportName & ".rpt")
        '    .AddMain(sSQL)
        '    .PrintReport(sReportPath, sReportCaption)
        'End With
        'Me.Cursor = Cursors.Default


        Me.Cursor = Cursors.WaitCursor
        Print(Me, Me.Name)
        Me.Cursor = Cursors.Default
    End Sub


    Dim report As D99C2003
    Private Sub printReport(ByVal sReportName As String, ByVal sReportPath As String, ByVal sReportCaption As String, ByVal sSQL As String)
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        Dim conn As New SqlConnection(gsConnectionString)
        With report
            .OpenConnection(conn)
            Dim sSQLSub As String = ""
            sSQLSub = "SELECT CompanyName, CompanyPhone, CompanyFax, AddressLine1, AddressLine2,AddressLine3, AddressLine4, AddressLine5, CompanyAddress" & vbCrLf
            sSQLSub &= "FROM D91V0016 WHERE DivisionID = " & SQLString(gsDivisionID)
            Dim sSubReport As String = "D02R0000"
            UnicodeSubReport(sSubReport, sSQLSub, gsDivisionID, gbUnicode)
            .AddSub(sSQLSub, sSubReport & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption & " - " & sReportName)
        End With
    End Sub

    Private Sub Print(ByVal form As Form, ByVal sReportTypeID As String, Optional ByVal ModuleID As String = "02")
        Dim sReportName As String = "D02R1010"
        Dim sReportPath As String = ""
        Dim sReportTitle As String = "BÀo cÀo nghiÖp vó tÀc ¢èng tªi s¶n"
        Dim sCustomReport As String = ""
        Dim file As String = D99D0541.GetReportPathNew(ModuleID, sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)
        If sReportName = "" Then Exit Sub

        Dim sSQL As String = ""
        sSQL = SQLStoreD02P4200()
        Select Case file.ToLower
            Case "rpt"
                printReport(sReportName, sReportPath, sReportTitle, sSQL)
            Case Else
                D99D0541.PrintOfficeType(sReportTypeID, sReportName, sReportPath, file, sSQL)
        End Select
    End Sub

    Dim bRefreshFilter As Boolean = False

#Region "Events tdbg"
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()

        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_ChangeDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
        'Me.Cursor = Cursors.WaitCursor
        'If e.KeyCode = Keys.Enter Then
        '    If tdbg.FilterActive Then Me.Cursor = Cursors.Default : Exit Sub
        '    If tsbEdit.Enabled Then
        '        tsbEdit_Click(sender, Nothing)
        '    ElseIf tsbView.Enabled Then
        '        tsbView_Click(sender, Nothing)
        '    End If
        'End If
        'Me.Cursor = Cursors.Default
        'HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

#End Region

#Region " FilterBar trên lưới"

    Private Sub c1dateFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1dateFilter.KeyDown
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub ResetFilter()
    '    'Set lại các giá trị FilterText
    '    Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
    '    For Each dc In Me.tdbg.Columns
    '        dc.FilterText = ""
    '    Next dc
    'End Sub

#End Region

    Private Function AllowEditDelete() As Boolean
        Dim sSQL As String = SQLStoreD02P5005()
        Return CheckStore(sSQL)
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5005
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 10/03/2011 08:59:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5005() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P5005 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_ChangeNo).Text) & COMMA 'ChangeNo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_AssetID).Text) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_BatchID).Text) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gsLanguage) 'Language, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5001
    '# Created User: VANVINH
    '# Created Date: 21/12/2012 10:41:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: Theo ID 53005
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5001(ByVal imode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load phieu nghiep vu tac dong" & vbCrLf)
        sSQL &= "Exec D02P5001 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'strFind, varchar[500], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(imode) & COMMA 'IsTime, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Value) & COMMA 'FromMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Value) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Value) & COMMA 'ToMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Value) & COMMA 'ToYear, int, NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Value) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Value) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(tdbcChangeNo.Text) & COMMA 'ChangeNo, varchar[20], NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcFromAssetID.Text) & COMMA 'FromAssetID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcToAssetID.Text) 'ToAssetID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5006
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 10/03/2011 09:04:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5006() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P5006 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_AssetID).Text) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_ChangeNo).Text) & COMMA 'ChangeNo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_BatchID).Text) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P4200
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 10/03/2011 09:22:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P4200() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P4200 "
        sSQL &= SQLString(tdbg.Columns(COL_BatchID).Text) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_GroupID).Text) & COMMA 'GroupID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub mnsLockVoucher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsLockVoucher.Click, tsmLockVoucher.Click
        Dim sSQL As String = ""
        If D99C0008.Msg(rL3("MSG000002"), rL3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then '"Bạn có muốn khóa phiếu này không?"
            If tdbg.Columns(COL_ModuleID).Text <> "02" Then
                D99C0008.MsgL3(rL3("Du_lieu_tu_module_khac_chuyen_qua") & Space(1) & rL3("Ban_khong_the_thay_doi_duoc")) 'Dữ liệu từ module khác chuyển qua. Bạn không thể thay đổi được.
                Exit Sub
            End If
            If tdbg.Columns(COL_Period).Text <> giTranMonth.ToString("00") & "/" & giTranYear.ToString Then
                D99C0008.MsgL3(rL3("Du_lieu_khong_thuoc_ky_nay") & Space(1) & rL3("Ban_khong_the_thay_doi_duoc")) 'Dữ liệu không thuộc kỳ này. Bạn không thể thay đổi được.
                Exit Sub
            End If
            sSQL = "Update D02T0202 Set "
            sSQL = sSQL & " Locked = 1,"
            sSQL = sSQL & " LockedUserID = '" & gsUserID & "',"
            sSQL = sSQL & " LockedDate = " & SQLDateSave(Now)
            sSQL = sSQL & " Where DivisionID = " & SQLString(gsDivisionID) & " And BatchID = '" & tdbg.Columns(COL_BatchID).Text & "'"
            ExecuteSQLNoTransaction(sSQL)
            'LoadTDBGrid(, tdbg.Columns(COL_BatchID).Text)
            LoadTDBGrid(, tdbg.Columns(COL_GroupID).Text)
        End If
    End Sub

    Private Sub tdbg_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If tdbg.RowCount = 0 Then
                tsmLockVoucher.Enabled = False
                mnsLockVoucher.Enabled = False
                Exit Sub
            End If
            tsmLockVoucher.Enabled = (tdbg.RowCount > 0) And tdbg.Columns(COL_Locked).Text = "0" And (iPer_F5557 >= EnumPermission.Add) And (Not gbClosed)
            mnsLockVoucher.Enabled = tsmLockVoucher.Enabled
        End If
    End Sub


#Region "Events tdbcChangeNo"

    Private Sub tdbcChangeNo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcChangeNo.LostFocus
        If tdbcChangeNo.FindStringExact(tdbcChangeNo.Text) = -1 Then tdbcChangeNo.Text = ""
    End Sub

#End Region

#Region "Events tdbcToAssetID"

    Private Sub tdbcToAssetID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToAssetID.LostFocus
        If tdbcToAssetID.FindStringExact(tdbcToAssetID.Text) = -1 Then tdbcToAssetID.Text = ""
    End Sub

#End Region

#Region "Events tdbcFromAssetID"

    Private Sub tdbcFromAssetID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromAssetID.LostFocus
        If tdbcFromAssetID.FindStringExact(tdbcFromAssetID.Text) = -1 Then tdbcFromAssetID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.LostFocus
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.LostFocus
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub

#End Region


    Private Sub chkPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPeriod.Click
        If chkPeriod.Checked Then
            tdbcPeriodFrom.Text = Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000")
            tdbcPeriodTo.Text = Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000")
        Else
            tdbcPeriodFrom.Text = ""
            tdbcPeriodTo.Text = ""
        End If
        ReadOnlyControl(Not (chkPeriod.Checked), tdbcPeriodFrom, tdbcPeriodTo)
        tdbcPeriodFrom.Enabled = chkPeriod.Checked
        tdbcPeriodTo.Enabled = chkPeriod.Checked
    End Sub

    Private Sub chkDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.Click
        If chkDate.Checked Then
            c1dateFrom.Value = Date.Today
            c1dateTo.Value = Date.Today
        Else
            c1dateFrom.Value = ""
            c1dateTo.Value = ""
        End If
        ReadOnlyControl(Not (chkDate.Checked), c1dateFrom, c1dateTo)
        c1dateFrom.Enabled = chkDate.Checked
        c1dateTo.Enabled = chkDate.Checked
    End Sub

    'Them ngay 21/12/2012 theo incident 53005
    Private Function AllowSave() As Boolean
        If chkPeriod.Checked Then
            If tdbcPeriodFrom.Text.Trim = "" Then

                D99C0008.MsgNotYetChoose(rL3("Tu_ky"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
            If tdbcPeriodTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Den_ky"))
                tdbcPeriodTo.Focus()
                Return False
            End If
            If Not CheckValidPeriodFromTo(tdbcPeriodFrom, tdbcPeriodTo) Then
                Return False
            End If
        End If

        If chkDate.Checked Then
            If c1dateFrom.Value.ToString = "" Then

                D99C0008.MsgNotYetEnter(rL3("Tu_ngay"))
                c1dateFrom.Focus()
                Return False
            End If
            If c1dateTo.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Den_ngay"))
                c1dateTo.Focus()
                Return False
            End If
            If Not CheckValidDateFromTo(c1dateFrom, c1dateTo) Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowSave() Then Exit Sub
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
    End Sub

    'Xuất Excel
    Private Sub tsbExportToExcel_Click(sender As Object, e As EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        '5/1/2021, Nguyễn Thị Mỹ Lài:id 151678-HỖ TRỢ XUẤT FILE EXCEL CHUẨN MÀN HÌNH D02F2002
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        Dim frm As New D99F2222
        With frm
            .UseUnicode = gbUnicode
            .FormID = Me.Name 'Me.Name
            .dtLoadGrid = gdtCaptionExcel
            .GroupColumns = gsGroupColumns
            .dtExportTable = dtGrid
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class