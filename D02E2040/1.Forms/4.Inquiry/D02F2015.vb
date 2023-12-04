Imports System.Text

Public Class D02F2015


#Region "Const of tdbg"
    Private Const COL_ As Integer = 0                  ' STT
    Private Const COL_BatchID As Integer = 1           ' BatchID
    Private Const COL_CipID As Integer = 2             ' CipID
    Private Const COL_VoucherTypeID As Integer = 3     ' Loại phiếu
    Private Const COL_VoucherNo As Integer = 4         ' Số phiếu
    Private Const COL_VoucherDate As Integer = 5       ' Ngày phiếu
    Private Const COL_Description As Integer = 6       ' Diễn giải
    Private Const COL_CipNo As Integer = 7             ' Mã XDCB
    Private Const COL_CipName As Integer = 8           ' Tên XDCB
    Private Const COL_CreateUserID As Integer = 9      ' Người tạo
    Private Const COL_CreateDate As Integer = 10       ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 11 ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 12   ' Ngày cập nhật cuối cùng
    Private Const COL_TransactionID As Integer = 13    ' TransactionID
    Private Const COL_ModuleID As Integer = 14         ' ModuleID
    Private Const COL_Period As Integer = 15           ' Period
    Private Const COL_Locked As Integer = 16           ' Khóa
#End Region


    Private dtGrid As DataTable

    Private Sub D02F2010_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Dim iPer_F5557, iPer_F2015 As Integer

    Private Sub D02F2010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        iPer_F5557 = ReturnPermission("D02F5557")
        iPer_F2015 = ReturnPermission("D02F2015")
        Loadlanguage()
        ResetColorGrid(tdbg)
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)
        LoadTDBGrid()
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False)
    '    Dim sSQL As New StringBuilder("")
    '    sSQL.Append(" Select DISTINCT '' as Orders, A.BatchID, A.CipID, A.VoucherTypeID, A.VoucherNo, A.VoucherDate, " & vbCrLf)
    '    sSQL.Append(" A.Description, A.CreateUserID, A.CreateDate, A.LastModifyUserID, A.LastModifyDate, B.CipNo, B.CipName " & vbCrLf)
    '    sSQL.Append(" From D02T0012 A  WITH (NOLOCK)" & vbCrLf)
    '    sSQL.Append(" Left Join D02T0100 B On A.CipID=B.CipID " & vbCrLf)
    '    sSQL.Append(" Where A.TranMonth = " & giTranMonth & " And TranYear = " & giTranYear & vbCrLf)
    '    sSQL.Append(" And A.DivisionID= " & SQLString(gsDivisionID) & " And A.BatchID In ( Select Distinct BatchID from D02T2050 )")

    '    If sFind <> "" Then sSQL.Append(" And " & sFind & vbCrLf)

    '    dtGrid = ReturnDataTable(sSQL.ToString)
    '    LoadDataSource(tdbg, dtGrid)
    '    If bFlagAdd = True Then
    '        dtGrid.DefaultView.Sort = "BatchID"
    '        tdbg.Bookmark = dtGrid.DefaultView.Find(sBatchID)
    '    End If
    '    UpdateTDBGOrderNum(tdbg, COL_Orders)
    '    CheckMenu(PARA_FormIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)

    'End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2015
    '# Created User: Phạm Văn Vinh
    '# Created Date: 22/10/2012 09:45:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2015() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do du lieu cho man hinh truy van quyet toan XDCB" & vbCrlf)
        sSQL &= "Exec D02P2015 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =’’
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        'Thay đổi câu đổ nguồn theo incident 51452 của Thị Hiệp bởi Văn Vinh
        'Dim sSQL As New StringBuilder("")
        'sSQL.Append(" Select DISTINCT '' as Orders, A.BatchID, A.TransactionID, A.CipID, A.VoucherTypeID, A.VoucherNo, A.VoucherDate, " & vbCrLf)
        'sSQL.Append(" A.Description" & UnicodeJoin(gbUnicode) & " as Description, A.CreateUserID, A.CreateDate, A.LastModifyUserID, A.LastModifyDate, B.CipNo, B.CipName" & UnicodeJoin(gbUnicode) & " as CipName " & vbCrLf)
        'sSQL.Append(", A.Locked, A.ModuleID, REPLACE(STR(A.TranMonth, 2), ' ', '0') + '/' + STR(A.TranYear, 4) AS Period" & vbCrLf)
        'sSQL.Append(" From D02T0012 A  WITH (NOLOCK)" & vbCrLf)
        'sSQL.Append(" Left Join D02T0100 B On A.CipID=B.CipID " & vbCrLf)
        'sSQL.Append(" Where A.TranMonth = " & giTranMonth & " And TranYear = " & giTranYear & vbCrLf)
        'sSQL.Append(" And A.DivisionID= " & SQLString(gsDivisionID) & " And A.BatchID In ( Select Distinct BatchID from D02T2050 )")
        dtGrid = ReturnDataTable(SQLStoreD02P2015)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng  
        'Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select(tdbg.Columns(COL_BatchID).DataField & "=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        'If Not chkShowDisabled.Checked Then
        '    If strFind <> "" Then strFind &= " And "
        '    strFind &= "Disabled =0"
        'End If
        dtGrid.DefaultView.RowFilter = strFind
        '  LoadGridFind(tdbg, dtGrid, strFind)'gây lỗi không nhập được ký tự thứ 2 trên filter
        ' Nếu lưới có Group thì bổ sung thêm 2 đoạn lệnh sau:
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1, False)
        tsmLockVoucher.Enabled = (tdbg.RowCount > 0) And tdbg.Columns(COL_Locked).Text = "0" And (iPer_F5557 >= EnumPermission.Add) And (Not gbClosed)
        mnsLockVoucher.Enabled = tsmLockVoucher.Enabled
        mnsImportData.Enabled = iPer_F2015 >= 2
        tsbImportData.Enabled = mnsImportData.Enabled
        FooterTotalGrid(tdbg, COL_VoucherNo)
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D02F2011
        With f
            .BatchID = ""
            .CipID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            'sBatchID = .BatchID
            'sCipID = .CipID
            If gbSavedOK = True Then LoadTDBGrid(True, .BatchID)
            .Dispose()
        End With

    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If

        If CheckBeforeEditDelete() = False Then Exit Sub

        Dim f As New D02F2011
        With f
            .BatchID = tdbg.Columns(COL_BatchID).Text
            .CipID = tdbg.Columns(COL_CipID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            If gbSavedOK Then LoadTDBGrid(False, .BatchID)
            .Dispose()
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If CheckBeforeEditDelete() = False Then Exit Sub

        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If
        Dim sSQL As New StringBuilder("")
        sSQL.Append(SQLStoreD02P2012())
        Dim bResult As Boolean = ExecuteSQL(sSQL.ToString)
        If bResult = True Then
            DeleteOK()
            DeleteVoucherNoD91T9111(tdbg.Columns(COL_VoucherNo).Text, "D02T0012", "VoucherNo")
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()

        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D02F2011
        With f
            .BatchID = tdbg.Columns(COL_BatchID).Text
            .CipID = tdbg.Columns(COL_CipID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

#Region "Events of Grid"

    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Dim sFilter As New System.Text.StringBuilder()

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub


    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_  'Chặn nhập liệu trên cột STT tăng tự 						động trong code
                e.Handled = CheckKeyPress(e.KeyChar, True)
            Case COL_Locked
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_VoucherDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub
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
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(sender, e) : Exit Sub
        HotKeyCtrlVOnGrid(tdbg, e, COL_) 'Nhấn Ctrl + V trên lưới 'có trong D99X0000
    End Sub
#End Region

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""

    Dim dtCaptionCols As DataTable
    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then 'Incident 72333
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me.Name, "0", gbUnicode)

        'If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        'Dim sSQL As String = ""
        'gbEnabledUseFind = True
        'sSQL = "Select * From D02V1234 "
        'sSQL &= "Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
        'ShowFindDialogClient(Finder, sSQL)
    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmListAll.Click, mnsListAll.Click
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    'Private Sub ReLoadTDBGrid()
    '    LoadGridFind(tdbg, dtGrid, sFind)
    '    CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    'End Sub
#End Region

    Private Function CheckBeforeEditDelete() As Boolean
        Dim sSQL As String = ""
        sSQL = SQLStoreD02P2013()
        Return CheckStore(sSQL)
        '        Dim dt As DataTable = ReturnDataTable(sSQL)
        '        If dt.Rows.Count > 0 Then
        '            For i As Integer = 0 To dt.Rows.Count - 1
        '                If dt.Rows(i).Item("Status").ToString = "1" Then
        '                    Return False
        '                Else
        '                    Return True
        '                End If
        '            Next
        '        End If
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2012
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 27/04/2007 04:26:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2012() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P2012 "
        sSQL &= SQLString(tdbg.Columns(COL_CipID).Text) & COMMA 'CipID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_batchID).Text) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2013
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 27/04/2007 04:26:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2013() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P2013 "
        sSQL &= SQLString(tdbg.Columns(COL_BatchID).Text) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_CipID).Text) & COMMA 'CipID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Quyet_toan_XDCB_-_D02F2015") & UnicodeCaption(gbUnicode) 'QuyÕt toÀn XDCB - D02F2015
        '================================================================ 
        'btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        'btnClose.Text = rl3("Do_ng") 'Đó&ng
        'btnHelp.Text = rl3("Tro__giup") 'Trợ &giúp
        '================================================================ 
        tdbg.Columns("").Caption = rl3("STT") 'STT
        tdbg.Columns("VoucherTypeID").Caption = rl3("Loai_phieu") 'Loại phiếu
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("CipNo").Caption = rl3("Ma_XDCB") 'Mã XDCB
        tdbg.Columns("CipName").Caption = rl3("Ten_XDCB") 'Tên XDCB
        tdbg.Columns(COL_Locked).Caption = rl3("Khoa") 'Khóa
        '================================================================ 
        'mnuAdd.Text = rl3("_Them") '&Thêm
        'mnuView.Text = rl3("Xe_m") 'Xe&m
        'mnuEdit.Text = rl3("_Sua") '&Sửa
        'mnuDelete.Text = rl3("_Xoa") '&Xóa
        'mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        'mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        'mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
    End Sub


    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg.UnboundColumnFetch
        e.Value = (e.Row + 1).ToString
    End Sub


    Private Sub mnsLockVoucher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsLockVoucher.Click, tsmLockVoucher.Click
        Dim sSQL As String = ""
        If D99C0008.Msg(rl3("MSG000002"), rl3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then '"Bạn có muốn khóa phiếu này không?"
            If tdbg.Columns(COL_ModuleID).Text <> "02" Then
                D99C0008.MsgL3(rl3("Du_lieu_tu_module_khac_chuyen_qua") & Space(1) & rl3("Ban_khong_the_thay_doi_duoc")) 'Dữ liệu từ module khác chuyển qua. Bạn không thể thay đổi được.
                Exit Sub
            End If
            If tdbg.Columns(COL_Period).Text <> giTranMonth.ToString("00") & "/" & giTranYear.ToString Then
                D99C0008.MsgL3(rl3("Du_lieu_khong_thuoc_ky_nay") & Space(1) & rl3("Ban_khong_the_thay_doi_duoc")) 'Dữ liệu không thuộc kỳ này. Bạn không thể thay đổi được.
                Exit Sub
            End If
            sSQL = "Update D02T0012 Set "
            sSQL = sSQL & " Locked = 1,"
            sSQL = sSQL & " LockedUserID = '" & gsUserID & "',"
            sSQL = sSQL & " LockedDate = " & SQLDateSave(Now)
            sSQL = sSQL & " Where DivisionID = " & SQLString(gsDivisionID) & " And TransactionID = '" & tdbg.Columns(COL_TransactionID).Text & "'"
            ExecuteSQLNoTransaction(sSQL)
            LoadTDBGrid(, tdbg.Columns(COL_BatchID).Text)
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

    Private Sub mnsImportToData_Click(sender As Object, e As EventArgs) Handles mnsImportData.Click, tsbImportData.Click
        Me.Cursor = Cursors.WaitCursor
        If CallShowDialogD80F2090(D02, "D02F2015", "CIPFinalizationVouchers") Then
            LoadTDBGrid()
        End If
        Me.Cursor = Cursors.Default

    End Sub
End Class