Imports System
Imports System.Text
Public Class D02F0501

    Private Enum ETab
        EInfo = 1
        EAna = 2
    End Enum

    Dim bFlag_Shift As Boolean = False
    Dim bFlag_ChangeRow As Boolean = True
    Dim bFlag_Ctrl As Boolean = False
    Dim iRow, OldRow As Integer
    Dim SelRows As New ArrayList
    Dim dtGrid As DataTable

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable


    Dim iColumns() As Integer = {COL_ConvertedAmount, COL_DepAmount}
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""

#Region "Biến khai báo cho khoản mục"
    Private Const SplitAna As Int16 = 2 ' Ghi nhận Khoản mục chứa ở Split nào
    Dim bUseAna As Boolean 'Kiểm tra có sử dụng Khoản mục không, để set thuộc tính Enabled nút Khoản mục 
    Dim iDisplayAnaCol As Integer = 0 ' Cột Khoản mục đầu tiên được hiển thị, khi nhấn nút Khoản mục thì Focus đến cột đó

#End Region


#Region "Const of tdbg - Total of Columns: 42"
    Private Const COL_OrderNum As Integer = 0          ' STT
    Private Const COL_VoucherNo As Integer = 1         ' Số phiếu
    Private Const COL_VoucherDate As Integer = 2       ' Ngày KH
    Private Const COL_AssetID As Integer = 3           ' Mã tài sản
    Private Const COL_AssetName As Integer = 4         ' Tên tài sản
    Private Const COL_SetupPeriod As Integer = 5       ' Kỳ hình thành
    Private Const COL_ConvertedAmount As Integer = 6   ' Nguyên giá
    Private Const COL_DepAmount As Integer = 7         ' Giá trị khấu hao
    Private Const COL_DebitAccountID As Integer = 8    ' TK Nợ
    Private Const COL_CreditAccountID As Integer = 9   ' TK Có
    Private Const COL_ObjectTypeID As Integer = 10     ' Loại ĐT
    Private Const COL_ObjectID As Integer = 11         ' Đối tượng
    Private Const COL_SourceID As Integer = 12         ' Nguồn hình thành
    Private Const COL_AssignmentID As Integer = 13     ' Tiêu thức phân bổ
    Private Const COL_PeriodID As Integer = 14         ' Tập phí
    Private Const COL_NormID As Integer = 15           ' Bộ định mức
    Private Const COL_Ana01ID As Integer = 16          ' Khoản mục 1
    Private Const COL_Ana02ID As Integer = 17          ' Khoản mục 2
    Private Const COL_Ana03ID As Integer = 18          ' Khoản mục 3
    Private Const COL_Ana04ID As Integer = 19          ' Khoản mục 4
    Private Const COL_Ana05ID As Integer = 20          ' Khoản mục 5
    Private Const COL_Ana06ID As Integer = 21          ' Khoản mục 6
    Private Const COL_Ana07ID As Integer = 22          ' Khoản mục 7
    Private Const COL_Ana08ID As Integer = 23          ' Khoản mục 8
    Private Const COL_Ana09ID As Integer = 24          ' Khoản mục 9
    Private Const COL_Ana10ID As Integer = 25          ' Khoản mục 10
    Private Const COL_Posted As Integer = 26           ' Chuyển bút toán
    Private Const COL_CreateUserID As Integer = 27     ' CreateUserID
    Private Const COL_CreateDate As Integer = 28       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 29 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 30   ' LastModifyDate
    Private Const COL_TransactionID As Integer = 31    ' TransactionID
    Private Const COL_BatchID As Integer = 32          ' BatchID
    Private Const COL_DivisionID As Integer = 33       ' DivisionID
    Private Const COL_TranMonth As Integer = 34        ' TranMonth
    Private Const COL_TranYear As Integer = 35         ' TranYear
    Private Const COL_Locked As Integer = 36           ' Khóa
    Private Const COL_ModuleID As Integer = 37         ' ModuleID
    Private Const COL_ProjectID As Integer = 38        ' Dự án
    Private Const COL_ProjectName As Integer = 39      ' Tên dự án
    Private Const COL_TaskID As Integer = 40           ' Hạng mục
    Private Const COL_TaskName As Integer = 41         ' Tên hạng mục
#End Region


#Region "Form Load"

    Dim iPer_F5557 As Integer

    Private Sub D02F0501_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim sSQL As String = ("-- Xoa bang tam" & vbCrLf)
        sSQL &= "Delete From D91T9009"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID = 'D02F0501'" & vbCrLf
        ExecuteSQLNoTransaction(sSQL)
    End Sub

    Private Sub D02F0501_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        iPer_F5557 = ReturnPermission("D02F5557")
        '--- Chuẩn Khoản mục b2: Lấy caption cho 10 khoản mục
        bUseAna = LoadTDBGridAnalysisCaption(D02, tdbg, COL_Ana01ID, SplitAna, , gbUnicode)

        CheckIdTextBox(txtAssetID)
        SetShortcutPopupMenu(Me, tbrTableToolStrip, ContextMenuStrip1, True)
        InputbyUnicode(Me, gbUnicode)
        '--- Chuẩn Khoản mục b21: D91 có sử dụng khoản mục
        If bUseAna Then iDisplayAnaCol = 1
        '------------------------------------
        CheckUseAna()
        CheckVisibleAna()
        '------------------------------------
        Loadlanguage()
        ResetColorGrid(tdbg, 0, 3)
        ResetSplitDividerSize(tdbg)
        LoadTDBCombo()
        ' CheckMenu(Me.Name, tbrTableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        tdbg.Columns(COL_VoucherDate).Editor = c1dateFilter
        LoadValueDetail()
        EnabledColInformation(ETab.EInfo)
        SetBackColorObligatory()
        tdbg_NumberFormat()
        CheckMenuOther()
        CallD99U1111()
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ConvertedAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_DepAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
        FooterSum(tdbg, iColumns, COL_OrderNum, True)
    End Sub

    Dim dtCodeID As DataTable
    Private Sub LoadTDBCombo()
        LoadCboPeriodReport(tdbcFromPeriod, tdbcToPeriod, D02)

        ' update 7/8/2013 id 57853
        'Load tdbcTypeCodeID
        Dim sSQL As String = ""
        sSQL = "SELECT 	'%' AS TypeCodeID, " & AllName & " AS Description, 0 AS DisplayOrder UNION ALL " & vbCrLf
        sSQL &= "SELECT 	TypeCodeID, VieTypeCodeName" & UnicodeJoin(gbUnicode) & " AS Description, 1 AS DisplayOrder" & vbCrLf
        sSQL &= "FROM D02T0040 WITH(NOLOCK) WHERE 	Type = 'A' AND Disabled = 0 ORDER BY TypeCodeID "
        LoadDataSource(tdbcTypeCodeID, sSQL, gbUnicode)

        ' update 7/8/2013 id 57853
        'Load tdbcFromCCodeID
        sSQL = "SELECT 	'%' AS AcodeID, " & AllName & " AS Description, '%' AS TypeCodeID, 0 AS DisplayOrder UNION ALL " & vbCrLf
        sSQL &= " SELECT  AcodeID, Description" & UnicodeJoin(gbUnicode) & " As Description, TypeCodeID,  1 AS DisplayOrder           " & vbCrLf
        sSQL &= " FROM   D02T0041 WITH(NOLOCK) WHERE  Type = 'A' ORDER BY DisplayOrder, TypeCodeID, AcodeID"
        dtCodeID = ReturnDataTable(sSQL)
        LoadtdbcFromToCCodeID("-1")

    End Sub

    Private Sub LoadtdbcFromToCCodeID(ByVal sTypeCodeID As String)
        Dim dt As DataTable = ReturnTableFilter(dtCodeID, "TypeCodeID = '%' OR TypeCodeID = " & SQLString(sTypeCodeID), True)
        LoadDataSource(tdbcFromCCodeID, dt, gbUnicode)
        LoadDataSource(tdbcToCCodeID, dt.DefaultView.ToTable, gbUnicode)
        tdbcFromCCodeID.SelectedValue = "%"
        tdbcToCCodeID.SelectedValue = "%"
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_but_toan_phan_bo_khau_hao_-_D02F0501") & UnicodeCaption(gbUnicode) 'Truy vÊn bòt toÀn ph¡n bå khÊu hao - D02F0501
        '================================================================ 
        lblTypeCodeID.Text = rl3("Loai_phan_tich") 'Loại phân tích
        lblFromCCodeID.Text = rl3("Ma_phan_tich") 'Mã phân tích
        lblInfo.Text = rl3("Nhan_Shift__A_de_chon_tat_ca_du_lieu") 'Nhấn Shift + A để chọn tất cả dữ liệu
        lblPeriod.Text = rl3("Ky") 'Kỳ
        lblAssetID.Text = rl3("Ma_tai_san") 'Mã tài sản
        lblAssetName.Text = rl3("Ten_tai_san") 'Tên tài sản
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc (F5)
        btnAna.Text = "2. " & rl3("Khoan_muc") '2. Khoản mục
        btnInfoDepreciation.Text = "1. " & rl3("Thong_tin_khau_hao")
        '================================================================
        tdbcToCCodeID.Columns("AcodeID").Caption = rl3("Ma") 'Mã
        tdbcToCCodeID.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcFromCCodeID.Columns("AcodeID").Caption = rl3("Ma") 'Mã
        tdbcFromCCodeID.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcTypeCodeID.Columns("TypeCodeID").Caption = rl3("Ma") 'Mã
        tdbcTypeCodeID.Columns("Description").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("OrderNum").Caption = rl3("STT") 'STT
        tdbg.Columns("VoucherNo").Caption = rL3("So_phieu_khau_hao") 'rl3("So_phieu") 'Số phiếu
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_khau_hao") 'Ngày khấu hao
        tdbg.Columns("AssetID").Caption = rl3("Ma_tai_san") 'Mã tài sản
        tdbg.Columns("AssetName").Caption = rL3("Ten_tai_san") 'Tên tài sản
        tdbg.Columns("SetupPeriod").Caption = rL3("Ky_hinh_thanh") 'Kỳ hình thành
        tdbg.Columns("ConvertedAmount").Caption = rl3("Nguyen_gia") 'Nguyên giá
        tdbg.Columns("DepAmount").Caption = rl3("Gia_tri_khau_hao") 'Giá trị khấu hao
        tdbg.Columns("DebitAccountID").Caption = rl3("TK_no") 'TK nợ
        tdbg.Columns("CreditAccountID").Caption = rl3("TK_co") 'TK có
        tdbg.Columns("ObjectTypeID").Caption = rl3("Loai_doi_tuong") 'Loại đối tượng
        tdbg.Columns("ObjectID").Caption = rl3("Doi_tuong") 'Đối tượng
        tdbg.Columns("SourceID").Caption = rl3("Nguon_hinh_thanh") 'Nguồn hình thành
        tdbg.Columns("AssignmentID").Caption = rl3("Tieu_thuc_phan_bo") 'Tiêu thức phân bổ
        tdbg.Columns("PeriodID").Caption = rl3("Tap_phi") 'Tập phí
        tdbg.Columns("NormID").Caption = rl3("Bo_dinh_muc") 'Bộ định mức
        tdbg.Columns("Posted").Caption = rl3("Chuyen_but_toan") 'Chuyển bút toán
        'Thêm ngày 25/9/2012 theo incident 47514
        tdbg.Columns("ProjectID").Caption = rL3("Du_an") 'Dự án
        tdbg.Columns("TaskID").Caption = rL3("Hang_muc") 'Hạng mục
        tdbg.Columns("ProjectName").Caption = rL3("Ten_cong_trinh") 'Tên dự án
        tdbg.Columns("TaskName").Caption = rL3("Ten_hang_muc") 'Tên hạng mục

        tdbg.Columns(COL_Locked).Caption = rl3("Khoa") 'Khóa
        tdbg.Splits(0).Caption = rl3("Thong_tin_chinh")
        tdbg.Splits(1).Caption = rl3("Thong_tin_khau_hao")
        tdbg.Splits(2).Caption = rl3("Khoan_muc")
        tdbg.Splits(3).Caption = " "
        mnsSysInfo.Text = rl3("Lic_h_su_tac_dong") 'Lịch sử tác động
        tsmPosted.Text = rl3("Ch_uyen_but_toan_khau_hao") 'Ch&uyển bút toán khấu hao
        mnsPosted.Text = rl3("Ch_uyen_but_toan_khau_hao") 'Ch&uyển bút toán khấu hao
        tsbAdd.Text = rl3("_Them_but_toan_khau_hao") '&Thêm bút toán khấu hao
        tsmAdd.Text = rl3("_Them_but_toan_khau_hao") '&Thêm bút toán khấu hao
        mnsAdd.Text = rl3("_Them_but_toan_khau_hao") '&Thêm bút toán khấu hao
        tsbEdit.Text = rl3("_Sua_but_toan_khau_hao") '&Sửa bút toán khấu hao
        mnsEdit.Text = rl3("_Sua_but_toan_khau_hao") '&Sửa bút toán khấu hao
        tsmEdit.Text = rl3("_Sua_but_toan_khau_hao") '&Sửa bút toán khấu hao
        tsbDelete.Text = rl3("_Xoa_cac_but_toan_KH_da_chuyen") '&Xóa các bút toán KH đã chuyển
        mnsDelete.Text = rl3("_Xoa_cac_but_toan_KH_da_chuyen") '&Xóa các bút toán KH đã chuyển
        tsmDelete.Text = rl3("_Xoa_cac_but_toan_KH_da_chuyen") '&Xóa các bút toán KH đã chuyển
        mnsDeleteDepreciationLevel.Text = rl3("Xoa__muc_khau_hao") 'Xóa &mức khấu hao
        tsmDeleteDepreciationLevel.Text = rl3("Xoa__muc_khau_hao") 'Xóa &mức khấu hao
        tsmEditVoucher.Text = rl3("Sua_so_phieu") 'Sửa số phiếu
        mnsEditVoucher.Text = rl3("Sua_so_phieu") 'Sửa số phiếu

        mnsDeleteAll.Text = rl3("_Tat_ca") '&Tất cả
        mnsDeleteSelected.Text = rl3("_But_toan_duoc_chon") '&Bút toán được chọn
        tsbDeleteAll.Text = mnsDeleteAll.Text
        tsmDeleteAll.Text = mnsDeleteAll.Text
        tsmDeleteSelected.Text = mnsDeleteSelected.Text
        tsbDeleteSelected.Text = mnsDeleteSelected.Text

        tsmPrintVoucher.Text = rL3("_Phieu")
        mnsPrintVoucher.Text = rL3("_Phieu")
        tsmPrintVoucherAccTrans.Text = rL3("Phieu__dinh_khoan")
        mnsPrintVoucherAccTrans.Text = rL3("Phieu__dinh_khoan")
        '================================================================ 
        '================================================================ 
        btnF12.Text = "F12 ( " & rL3("Hien_thi") & " )" 'F12


    End Sub


    Private Sub CheckVisibleAna()
        For i As Integer = 0 To 9
            tdbg.Splits(SplitAna).DisplayColumns.Item(COL_Ana01ID + i).Visible = CBool(tdbg.Columns(COL_Ana01ID + i).Tag)
            If iDisplayAnaCol = 0 And tdbg.Splits(SplitAna).DisplayColumns.Item(COL_Ana01ID + i).Visible Then
                iDisplayAnaCol = COL_Ana01ID + i
            End If
        Next
    End Sub

    Private Sub LoadValueDetail()
        tdbcFromPeriod.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcToPeriod.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcTypeCodeID.SelectedValue = "%"
    End Sub

#End Region
#Region "Form Event"

    Private Sub D02F0501_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.Alt And tdbg.RowCount > 0 Then
            If e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
                btnInfoDepreciation_Click(sender, Nothing)
            ElseIf e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
                btnAna_Click(sender, Nothing)
            End If
        End If
        If e.KeyCode = Keys.F5 Then
            btnFilter_Click(sender, Nothing)
            tdbg.Focus()
            Exit Sub
        End If
        If e.KeyCode = Keys.F12 Then
            btnF12_Click(sender, Nothing)
            tdbg.Focus()
            Exit Sub
        End If
        'If e.Control Then
        '    Select Case e.KeyCode
        '        Case Keys.F
        '            If mnuFind.Enabled Then
        '                mnuFind_Click(sender, Nothing)
        '            End If
        '        Case Keys.A
        '            If mnuListAll.Enabled Then
        '                mnuListAll_Click(sender, Nothing)
        '            End If
        '    End Select
        '    bFlag_Ctrl = True
        '    Exit Sub
        'End If
        If e.KeyCode = Keys.Shift Or e.KeyCode = Keys.ShiftKey Then
            bFlag_Shift = True
            Exit Sub
        End If
        'If e.Shift And e.KeyCode = Keys.A Then
        '    If tdbg.RowCount > 0 Then
        '        For i As Integer = 0 To tdbg.RowCount - 1
        '            tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        '            tdbg.SelectedRows.Add(i)
        '        Next
        '    End If
        '    SelRows.Clear()
        'End If
    End Sub

    Private Sub D02F0501_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Shift Or e.KeyCode = Keys.ShiftKey Then
            bFlag_Shift = False
            Exit Sub
        End If
        If e.KeyCode = Keys.Control Or e.KeyCode = Keys.ControlKey Then
            bFlag_Ctrl = False
            Exit Sub
        End If
    End Sub

#End Region

#Region "TDBG  Event"

    Dim sFilter As New System.Text.StringBuilder()
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
            Case COL_OrderNum
                e.Handled = CheckKeyPress(e.KeyChar, True)
            Case COL_Locked
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_VoucherDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_ConvertedAmount, COL_DepAmount
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select


    End Sub


    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = SQLStoreD02P0510()
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
            Dim dr() As DataRow = dt1.Select(tdbg.Columns(COL_VoucherNo).DataField & "=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Sub ResetGrid()
        ' Bỏ vì gọi sai khi thuc hiện khóa sổ,  Và thực thi trong hàm CheckMenuOther()
        'CheckMenu(Me.Name, tbrTableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, True)
        CheckMenuOther()
        FooterTotalGrid(tdbg, COL_VoucherNo)
        FooterSum(tdbg, iColumns, COL_OrderNum, True)
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        UpdateTDBGOrderNum(tdbg, COL_OrderNum, , True)
        ResetGrid()
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tdbg.RowCount = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsmEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        End If
        bFlag_Shift = False
        bFlag_ChangeRow = True
        bFlag_Ctrl = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e, COL_OrderNum) 'Đã bổ sung D99X0000

        If e.Shift And e.KeyCode = Keys.A Then
            If tdbg.RowCount > 0 Then
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
                    tdbg.SelectedRows.Add(i)
                Next
            End If
            SelRows.Clear()
        End If
    End Sub

    Private Sub tdbg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
        Dim iCurrentRow As Integer = tdbg.Row
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If bFlag_Shift Then
                If OldRow > iRow Then
                    For i As Integer = iRow To OldRow
                        tdbg.SelectedRows.Add(i)
                    Next
                Else
                    For i As Integer = OldRow To iRow
                        tdbg.SelectedRows.Add(i)
                    Next
                End If

                SelRows.Clear()
                For i As Integer = 0 To tdbg.SelectedRows.Count - 1
                    SelRows.Add(tdbg.SelectedRows.Item(i))
                Next
                bFlag_ChangeRow = False
                CheckMenuOther()
                Exit Sub
            Else
                'bFlag_ChangeRow = True
            End If
            If bFlag_Ctrl Then
                Dim bNotRemove As Boolean = True
                For i As Integer = 0 To SelRows.Count - 1
                    If CInt(SelRows(i)) = iRow Then
                        SelRows.RemoveAt(i)
                        bNotRemove = False
                        tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
                        Exit For
                    End If
                Next
                If bNotRemove Then
                    If SelRows.Count = 0 Then
                        SelRows.Add(OldRow)
                    End If
                    SelRows.Add(iRow)
                End If
                tdbg.SelectedRows.Clear()
                For i As Integer = 0 To SelRows.Count - 1
                    tdbg.SelectedRows.Add(CInt(SelRows(i)))
                Next
                bFlag_ChangeRow = False
                CheckMenuOther()
                Exit Sub
            End If
            tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
            bFlag_ChangeRow = True
            SelRows.Clear()
            tdbg.SelectedRows.Clear()
        End If
    End Sub

    Dim sMasterValue As String = ""
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        If tdbg.RowCount = 0 Then Exit Sub
        If iRow <> tdbg.Row Then
            If bFlag_ChangeRow Then
                OldRow = iRow
            End If
            iRow = tdbg.Row
        End If

        If e.LastRow = tdbg.Row Then Exit Sub
        If sMasterValue = tdbg.Columns(COL_TransactionID).Text Then Exit Sub
        sMasterValue = tdbg.Columns(COL_TransactionID).Text
        CheckMenuOther()
    End Sub
#End Region




    'Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKeyID As String = "")
    '    Dim sSQL As String = ""
    '    sSQL = SQLStoreD02P0510()
    '    dt = ReturnDataTable(sSQL)
    '    LoadDataSource(tdbg, dt)
    '    If bFlagAdd Then
    '        dt.DefaultView.Sort = "VoucherNo"
    '        tdbg.Bookmark = dt.DefaultView.Find(sKeyID)
    '    End If
    '    FooterTotalGrid(tdbg, COL_VoucherNo)
    '    FooterSum(tdbg, iColumns, COL_OrderNum)
    '    CheckMenuOther()
    'End Sub

    ' Nếu có 1 dòng Posted = True thì   Return False
    Private Function GetDeleteDepreciationLevelMenu() As Boolean
        Dim rowCollections As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        For i As Integer = 0 To rowCollections.Count - 1
            If L3Bool(tdbg(rowCollections(i), COL_Posted)) = True Then
                Return False
            End If
        Next
        Return True
    End Function

    ' Nếu có 1 dòng Posted = false thì   Return False
    Private Function GetDeleteMenu() As Boolean
        Dim rowCollections As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        For i As Integer = 0 To rowCollections.Count - 1
            If L3Bool(tdbg(rowCollections(i), COL_Posted)) = False Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub CheckMenuOther()
        ''Update 10/01/2011: Kiểm tra kỳ 13
        Dim bPeriod13 As Boolean = (giTranMonth <> 13)
        CheckMenu(Me.Name, tbrTableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1, True)
        'CheckMenu(PARA_FormIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)

        Dim per As Integer = ReturnPermission(PARA_FormIDPermission)
        'mnuAddDepreciation.Enabled = (per - 2 >= 0) And Not gbClosed And bPeriod13

        'mnuEditDepreciation.Enabled = (per - 3 >= 0) And (tdbg.RowCount > 0) And Not gbClosed And bPeriod13
        Dim bDeleteDepreciationLevel As Boolean
        If tdbg.SelectedRows.Count > 1 Then
            bDeleteDepreciationLevel = GetDeleteDepreciationLevelMenu()
        Else
            bDeleteDepreciationLevel = Not L3Bool(tdbg.Columns(COL_Posted).Text)
        End If
        mnsDeleteDepreciationLevel.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And bDeleteDepreciationLevel And Not gbClosed And bPeriod13
        tsmDeleteDepreciationLevel.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And bDeleteDepreciationLevel And Not gbClosed And bPeriod13
        '        mnsDeleteDepreciationLevel.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And Not L3Bool(tdbg.Columns(COL_Posted).Text) And Not gbClosed And bPeriod13
        '        tsmDeleteDepreciationLevel.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And Not L3Bool(tdbg.Columns(COL_Posted).Text) And Not gbClosed And bPeriod13

        mnsPosted.Enabled = (per - 2 >= 0) And (tdbg.RowCount > 0) And Not L3Bool(tdbg.Columns(COL_Posted).Text) And Not gbClosed And bPeriod13
        tsmPosted.Enabled = (per - 2 >= 0) And (tdbg.RowCount > 0) And Not L3Bool(tdbg.Columns(COL_Posted).Text) And Not gbClosed And bPeriod13

        ' update 12/8/2013 id 57853 - Menu Xóa các bút toán khấu hao đã chuyển hiện đang xử lý sáng/mờ chỉ dựa trên dòng đầu tiên củaa lưới --> sửa lại sẽ dựa theo từng dòng đang đứng
        Dim bPosted As Boolean
        If tdbg.SelectedRows.Count > 1 Then
            bPosted = GetDeleteMenu()
        Else
            bPosted = L3Bool(tdbg.Columns(COL_Posted).Text)
        End If
        mnsDelete.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And bPosted And Not gbClosed And bPeriod13
        tsmDelete.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And bPosted And Not gbClosed And bPeriod13
        tsbDelete.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And bPosted And Not gbClosed And bPeriod13
        '        mnsDelete.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And L3Bool(tdbg.Columns(COL_Posted).Text) And Not gbClosed And bPeriod13
        '        tsmDelete.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And L3Bool(tdbg.Columns(COL_Posted).Text) And Not gbClosed And bPeriod13
        '        tsbDelete.Enabled = (per - 4 >= 0) And (tdbg.RowCount > 0) And L3Bool(tdbg.Columns(COL_Posted).Text) And Not gbClosed And bPeriod13
        'mnuSys.Enabled = tdbg.RowCount > 0

        mnsEditVoucher.Enabled = tdbg.RowCount > 0 And giPerF5558 > 2 And Not gbClosed And bPeriod13
        tsmEditVoucher.Enabled = tdbg.RowCount > 0 And giPerF5558 > 2 And Not gbClosed And bPeriod13
        tsmLockVoucher.Enabled = (tdbg.RowCount > 0) And tdbg.Columns(COL_Locked).Text = "0" And (iPer_F5557 >= EnumPermission.Add) And (Not gbClosed)
        mnsLockVoucher.Enabled = tsmLockVoucher.Enabled

        tsmPrintVoucher.Enabled = tsmPrint.Enabled
        mnsPrintVoucher.Enabled = tsmPrint.Enabled
        tsmPrintVoucherAccTrans.Enabled = tsmPrint.Enabled
        mnsPrintVoucherAccTrans.Enabled = tsmPrint.Enabled
    End Sub

    Private Function SQLStoreD02P0510() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0510 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcFromPeriod.Columns("TranMonth").Text) & COMMA 'MonthFrom, int, NOT NULL
        sSQL &= SQLNumber(tdbcFromPeriod.Columns("TranYear").Text) & COMMA 'YearFrom, int, NOT NULL
        sSQL &= SQLNumber(tdbcToPeriod.Columns("TranMonth").Text) & COMMA 'MonthTo, int, NOT NULL
        sSQL &= SQLNumber(tdbcToPeriod.Columns("TranYear").Text) & COMMA 'YearTo, int, NOT NULL
        sSQL &= SQLString(txtAssetID.Text) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtAssetName.Text) & COMMA 'AssetName, varchar[250], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(giTranMonth = 13, 1, 0)) & COMMA
        sSQL &= SQLNumber(gbUnicode) & COMMA
        ' update 7/8/2013 id 57853
        sSQL &= SQLString(tdbcTypeCodeID.Text) & COMMA 'TypeCodeID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbcFromCCodeID.Text) & COMMA 'ACodeIDFrom, varchar[50], NOT NULL
        sSQL &= SQLString(tdbcToCCodeID.Text) 'ACodeIDTo, varchar[50], NOT NULL
        Return sSQL
    End Function

#Region "Events tdbcFromPeriod"

    Private Sub tdbcFromPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromPeriod.LostFocus
        If tdbcFromPeriod.FindStringExact(tdbcFromPeriod.Text) = -1 Then tdbcFromPeriod.Text = ""
    End Sub

#End Region

#Region "Events tdbcToPeriod"

    Private Sub tdbcToPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToPeriod.LostFocus
        If tdbcToPeriod.FindStringExact(tdbcToPeriod.Text) = -1 Then tdbcToPeriod.Text = ""
    End Sub

#End Region

#Region "Events tdbcTypeCodeID load tdbcFromCCodeID"

    ' update 7/8/2013 id 57853
    Private Sub tdbcTypeCodeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeCodeID.SelectedValueChanged
        If tdbcTypeCodeID.SelectedValue Is Nothing OrElse tdbcTypeCodeID.Text = "" Then
            LoadtdbcFromToCCodeID("%")
            tdbcFromCCodeID.SelectedValue = "%"
            tdbcToCCodeID.SelectedValue = "%"
            ReadOnlyControl(tdbcFromCCodeID, tdbcToCCodeID)
            Exit Sub
        End If
        LoadtdbcFromToCCodeID(tdbcTypeCodeID.SelectedValue.ToString())
        If tdbcTypeCodeID.Text = "%" Then
            ReadOnlyControl(tdbcFromCCodeID, tdbcToCCodeID)
        Else
            UnReadOnlyControl(False, tdbcFromCCodeID, tdbcToCCodeID)
        End If
    End Sub

    Private Sub tdbcTypeCodeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeCodeID.LostFocus
        If tdbcTypeCodeID.FindStringExact(tdbcTypeCodeID.Text) = -1 Then
            tdbcTypeCodeID.Text = ""
            tdbcFromCCodeID.SelectedValue = "%"
            tdbcToCCodeID.SelectedValue = "%"
        End If
       
    End Sub

    Private Sub tdbcFromCCodeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcFromCCodeID.LostFocus
        If tdbcFromCCodeID.FindStringExact(tdbcFromCCodeID.Text) = -1 Then tdbcFromCCodeID.Text = ""
    End Sub

    Private Sub tdbcToCCodeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToCCodeID.LostFocus
        If tdbcToCCodeID.FindStringExact(tdbcToCCodeID.Text) = -1 Then tdbcToCCodeID.Text = ""
    End Sub

#End Region


#Region "Menu"

    Private Function AllowEdit() As Boolean
        If L3Int(tdbg(tdbg.Row, COL_TranMonth).ToString) + L3Int(tdbg(tdbg.Row, COL_TranYear).ToString) * 100 <> giTranMonth + giTranYear * 100 Then
            D99C0008.MsgL3(rl3("MSG000001"))
            Return False
        End If
        Return True
    End Function

    Private Sub tsmEditVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEditVoucher.Click, mnsEditVoucher.Click
        If AllowEdit() = False Then Exit Sub
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        gbSavedOK = False
        Dim sVoucherNo As String
        'Dim frm As New D91F5558
        'With frm
        '    .FormName = "D91F5558"
        '    .FormPermission = "D02F5558" 'Màn hình phân quyền
        '    .ModuleID = D02 'Mã module hiện tại, VD: D22
        '    .TableName = "D02T0012" 'Tên bảng chứa số phiếu
        '    .VoucherID = tdbg.Columns(COL_BatchID).Value.ToString 'Khóa sinh IGE
        '    .VoucherNo = tdbg.Columns(COL_VoucherNo).Value.ToString 'Số phiếu cần sửa
        '    .Mode = "0" ' Tùy theo Module, mặc định là 0
        '    .KeyID01 = "AL"
        '    .KeyID02 = ""
        '    .KeyID03 = ""
        '    .KeyID04 = ""
        '    .KeyID05 = ""
        '    .ShowDialog()
        '    If .Output01 <> "" Then gbSavedOK = CBool(.Output01) 'Giá trị trả về
        '    sVoucherNo = .Output02
        '    .Dispose()
        'End With
        'If gbSavedOK Then
        '    'Dim sVoucherIDOld As String = tdbg.Columns(COL_VoucherNo).Value.ToString
        '    'Load lại dữ liệu cho lưới
        '    LoadTDBGrid()
        '    If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        'End If

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F5558")
        ' SetProperties(arrPro, "VoucherTypeID", ReturnValueC1Combo(tdbcVoucherTypeID))
        SetProperties(arrPro, "VoucherID", tdbg.Columns(COL_BatchID).Value.ToString)
        SetProperties(arrPro, "Mode", 0)
        SetProperties(arrPro, "KeyID01", "AL")
        SetProperties(arrPro, "TableName", "D02T0012")
        SetProperties(arrPro, "ModuleID", D02)
        SetProperties(arrPro, "OldVoucherNo", tdbg.Columns(COL_VoucherNo).Value.ToString)
        SetProperties(arrPro, "KeyID02", "")
        SetProperties(arrPro, "KeyID03", "")
        SetProperties(arrPro, "KeyID04", "")
        SetProperties(arrPro, "KeyID05", "")
        Dim frm As Form = CallFormShowDialog("D91D0640", "D91F5558", arrPro)
        gbSavedOK = CType(GetProperties(frm, "bSaved"), Boolean)
        sVoucherNo = GetProperties(frm, "NewVoucherNo").ToString
        If gbSavedOK Then
            'Load lại dữ liệu cho lưới
            LoadTDBGrid()
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        End If

    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        'If sFilter.ToString <> "" Then ResetFilter()
        LoadTDBGrid(True)
        bFlag_Shift = False
        bFlag_ChangeRow = True
        bFlag_Ctrl = False
        SelRows.Clear()
        EnabledColInformation(ETab.EInfo)
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcFromPeriod.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky"))
            tdbcFromPeriod.Focus()
            Return False
        End If
        If tdbcToPeriod.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky"))
            tdbcToPeriod.Focus()
            Return False
        End If

        If CInt(tdbcFromPeriod.Columns("TranYear").Text) > CInt(tdbcToPeriod.Columns("TranYear").Text) Then
            D99C0008.MsgL3(rl3("MSG000014"))
            tdbcFromPeriod.Focus()
            Return False
        ElseIf CInt(tdbcFromPeriod.Columns("TranYear").Text) = CInt(tdbcToPeriod.Columns("TranYear").Text) Then
            If CInt(tdbcFromPeriod.Columns("TranMonth").Text) > CInt(tdbcToPeriod.Columns("TranMonth").Text) Then
                D99C0008.MsgL3(rl3("MSG000014"))
                tdbcFromPeriod.Focus()
                Return False
            End If
        End If
        Return True
    End Function


    Private Sub SetBackColorObligatory()
        tdbcFromPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcToPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub


    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim sSQL As String = ""
        Me.Cursor = Cursors.WaitCursor
        sSQL = "Select Top 1 1" & vbCrLf
        sSQL &= "From D02T0012 WITH(NOLOCK)" & vbCrLf
        sSQL &= "Where TransactionTypeID='KH'" & vbCrLf
        sSQL &= "And Posted=1 And DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "And TranMonth=" & SQLNumber(giTranMonth) & " And TranYear=" & SQLNumber(giTranYear)
        If ExistRecord(sSQL) Then
            D99C0008.MsgL3(rl3("Da_co_chuyen_but_toan_nen_khong_the_them_but_toan_khau_hao"))
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            Me.Cursor = Cursors.Default
            Dim frm As New D02F0503
            With frm
                .sVoucherNo = ""
                .FormState = EnumFormState.FormAdd
                .ShowDialog()
                If gbSavedOK Then
                    Dim sVoucherNo As String = frm.sVoucherNo
                    LoadTDBGrid(True, sVoucherNo)
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If Not (CInt(tdbg.Columns(COL_TranMonth).Text) = giTranMonth And CInt(tdbg.Columns(COL_TranYear).Text) = giTranYear) Then
            D99C0008.MsgL3(rl3("MSG000001"))
            Exit Sub
        End If
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If
        Dim sSQL As String = ""
        Me.Cursor = Cursors.WaitCursor

        sSQL = "Select Top 1 1" & vbCrLf
        sSQL &= "From D02T0012 WITH(NOLOCK)" & vbCrLf
        sSQL &= "Where TransactionTypeID='KH'" & vbCrLf
        sSQL &= "And Posted=1 And DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "And TranMonth=" & SQLNumber(giTranMonth) & " And TranYear=" & SQLNumber(giTranYear)
        If ExistRecord(sSQL) Then
            D99C0008.MsgL3(rl3("Da_co_chuyen_but_toan_nen_khong_duoc_sua_but_toan_khau_hao"))
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            Me.Cursor = Cursors.Default

            Dim frm As New D02F0503
            With frm
                .AssetID = tdbg.Columns(COL_AssetID).Text
                .TransactionID = tdbg.Columns(COL_TransactionID).Text
                .FormState = EnumFormState.FormEdit
                .ShowDialog()
                .Dispose()
                If gbSavedOK Then
                    'Dim Bookmark As Integer
                    'If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                    LoadTDBGrid(False, tdbg.Columns(COL_VoucherNo).Text)
                    ' If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
                End If
            End With
        End If
    End Sub

    '  ' update 7/8/2013 id 57853 - Chuyển xuống tsmDeleteAll_Click
    '    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
    '        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
    '        If Not AllowXXX() Then Exit Sub
    '
    '        If Not AllowDelete() Then Exit Sub
    '        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
    '            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
    '            Exit Sub
    '        End If
    '        Dim sSQL As String = ""
    '        Dim bRun As Boolean
    '        Dim iBookmark As Integer
    '        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
    '
    '        sSQL = SQLStoreD02P0504()
    '        bRun = ExecuteSQL(sSQL)
    '        If bRun = True Then
    '            LoadTDBGrid()
    '            ResetGrid()
    '            UpdateTDBGOrderNum(tdbg, 0, , True)
    '            Dim sDesc1 As String = rl3("Xoa_muc_khau_hao_ky") & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear
    '            ExecuteAuditLog("DepAllo", "03", sDesc1)
    '            DeleteOK()
    '            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
    '        Else
    '            DeleteNotOK()
    '        End If
    '    End Sub

    ' update 7/8/2013 id 57853
    Private Sub tsmDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleteAll.Click, tsmDeleteAll.Click, mnsDeleteAll.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowXXX() Then Exit Sub
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If

        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrLf)
        sSQL &= "Delete From D91T9009"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID = 'D02F0501'" & vbCrLf

        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL &= SQLInsertD91T9009s(tdbg(i, COL_TransactionID).ToString, tdbg(i, COL_AssetID).ToString, L3Int(tdbg(i, COL_Posted)), "D02F0501").ToString & vbCrLf
        Next
        ExecuteSQLNoTransaction(sSQL)
        If Not AllowDelete(0) Then Exit Sub

        Dim bRun As Boolean
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        sSQL = SQLStoreD02P0504(0)
        bRun = ExecuteSQL(sSQL)
        If bRun = True Then
            DeleteOK()
            DeleteVoucherNoD91T9111(tdbg.Columns(COL_VoucherNo).Text, "D02T0012", "VoucherNo")
            LoadTDBGrid()
            ResetGrid()
            UpdateTDBGOrderNum(tdbg, 0, , True)
            'Dim sDesc1 As String = rL3("Xoa_muc_khau_hao_ky") & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear
            'ExecuteAuditLog("DepAllo", "03", sDesc1)
            Lemon3.D91.RunAuditLog("02", "DepAllo", "03", IIf(gbUnicode = False, ConvertUnicodeToVni(rL3("Xoa_muc_khau_hao_ky")), rL3("Xoa_muc_khau_hao_ky")).ToString & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear)
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        Else
            DeleteNotOK()
        End If
    End Sub

    ' update 7/8/2013 id 57853
    Private Sub tsmDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleteSelected.Click, tsmDeleteSelected.Click, mnsDeleteSelected.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowXXX() Then Exit Sub

        Dim SelectedRows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows

        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrLf)
        sSQL &= "Delete From D91T9009"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID = 'D02F0501'" & vbCrLf

        ' chỉ insert các dòng được chọn
        If SelectedRows.Count > 1 Then 'Xóa nhiều dòng một lúc
            For i As Integer = 0 To SelectedRows.Count - 1
                sSQL &= SQLInsertD91T9009s(tdbg(SelectedRows.Item(i), COL_TransactionID).ToString, tdbg(SelectedRows.Item(i), COL_AssetID).ToString, L3Int(tdbg(SelectedRows.Item(i), COL_Posted)), "D02F0501").ToString & vbCrLf
            Next
        Else 'Xóa 1 dòng
            sSQL &= SQLInsertD91T9009s(tdbg.Columns(COL_TransactionID).Text, tdbg.Columns(COL_AssetID).Text, L3Int(tdbg.Columns(COL_Posted).Text), "D02F0501").ToString & vbCrLf
        End If
        ExecuteSQLNoTransaction(sSQL)

        If Not AllowDelete(1) Then Exit Sub
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If
        Dim bRun As Boolean
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        sSQL = SQLStoreD02P0504(1)
        bRun = ExecuteSQL(sSQL)
        If bRun = True Then
            DeleteOK()
            DeleteVoucherNoD91T9111(tdbg.Columns(COL_VoucherNo).Text, "D02T0012", "VoucherNo")
            LoadTDBGrid()
            UpdateTDBGOrderNum(tdbg, 0, , True)
            'Dim sDesc1 As String = rL3("Xoa_muc_khau_hao_ky") & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear
            'ExecuteAuditLog("DepAllo", "03", sDesc1)
            Lemon3.D91.RunAuditLog("02", "DepAllo", "03", IIf(gbUnicode = False, ConvertUnicodeToVni(rL3("Xoa_muc_khau_hao_ky")), rL3("Xoa_muc_khau_hao_ky")).ToString & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear)
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            ResetGrid()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsmPosted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsPosted.Click, tsmPosted.Click
        'Goi form D02F0502
        If Not AllowXXX() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim f As New D02F0502
        With f
            .ShowDialog()
            If .ContinueOK Then
                'Dim Bookmark As Integer
                'If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid(False, tdbg.Columns(COL_VoucherNo).Text)
                ' If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End If
            .Dispose()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowXXX() As Boolean
        If Not (tdbcFromPeriod.Columns("TranMonth").Text.Trim = giTranMonth.ToString.Trim _
       And tdbcFromPeriod.Columns("TranYear").Text.Trim = giTranYear.ToString.Trim _
       And tdbcToPeriod.Columns("TranMonth").Text.Trim = giTranMonth.ToString.Trim _
       And tdbcToPeriod.Columns("TranYear").Text.Trim = giTranYear.ToString.Trim) Then
            D99C0008.MsgL3(rl3("MSG000001"))
            Return False
        End If
        Return True
    End Function

    Private Sub tsmDeleteDepreciationLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDeleteDepreciationLevel.Click, mnsDeleteDepreciationLevel.Click

        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowXXX() Then Exit Sub

        Dim iBookmark As Integer
        Dim SelectedRows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        Dim sListAssetID As String = ""

        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        Dim sSQL As String = ""
        Dim bRun As Boolean
        sSQL = SQLDeleteD91T9009() & vbCrLf
        If SelectedRows.Count > 1 Then 'Xóa nhiều dòng một lúc
            For i As Integer = 0 To SelectedRows.Count - 1
                ' update 7/8/2013 id 57853
                'sSQL &= SQLInsertD91T9009s(tdbg(SelectedRows.Item(i), COL_AssetID).ToString).ToString & vbCrLf
                sSQL &= SQLInsertD91T9009s(tdbg(SelectedRows.Item(i), COL_TransactionID).ToString, tdbg(SelectedRows.Item(i), COL_AssetID).ToString).ToString & vbCrLf
            Next
        Else 'Xóa 1 dòng
            ' update 7/8/2013 id 57853
            sSQL &= SQLInsertD91T9009s(tdbg.Columns(COL_TransactionID).Text, tdbg.Columns(COL_AssetID).Text).ToString & vbCrLf
            'sSQL &= SQLInsertD91T9009s(tdbg.Columns(COL_AssetID).Text).ToString & vbCrLf
        End If

        sSQL &= SQLStoreD02P0506()
        bRun = ExecuteSQL(sSQL)
        If bRun Then
            DeleteOK()
            LoadTDBGrid()
            ResetGrid()
            UpdateTDBGOrderNum(tdbg, 0, , True)
            'Dim sDesc1 As String = rl3("Xoa_muc_khau_hao_ky") & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear
            'ExecuteAuditLog("DepAllo", "03", sDesc1)
            Lemon3.D91.RunAuditLog("02", "DepAllo", "03", IIf(gbUnicode = False, ConvertUnicodeToVni(rL3("Xoa_muc_khau_hao_ky")), rL3("Xoa_muc_khau_hao_ky")).ToString & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear)
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        Else
            DeleteNotOK()
        End If
    End Sub


    Private Sub tsbSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        'Dim frm As New D91F5558
        'With frm
        '    .FormName = "D91F1655"
        '    .FormPermission = "D02F0501" 'Màn hình phân quyền
        '    .ID01 = "DepAllo" 'AuditCode
        '    .ID02 = tdbg.Columns(COL_TransactionID).Text 'AuditItemID
        '    .ID03 = "1" 'Mode
        '    .ID04 = tdbg.Columns(COL_CreateUserID).Text 'CreateUserID
        '    .ID05 = tdbg.Columns(COL_CreateDate).Text 'CreateDate
        '    .ShowDialog()
        '    .Dispose()
        'End With

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F0501")
        SetProperties(arrPro, "AuditCode", "DepAllo")
        SetProperties(arrPro, "AuditItemID", tdbg.Columns(COL_TransactionID).Text)
        SetProperties(arrPro, "mode", "1")
        SetProperties(arrPro, "CreateUserID", tdbg.Columns(COL_CreateUserID).Text)
        SetProperties(arrPro, "CreateDate", tdbg.Columns(COL_CreateDate).Text)
        CallFormShow(Me, "D91D0640", "D91F1655", arrPro)
       
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""
    Private dtCaptionCols As DataTable
    Dim arrMaster As New ArrayList ' Máº£ng Master
    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then 'Incident 72333
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, , , , gbUnicode)
        AddColVisible(tdbg, SPLIT2, Arr, , , , gbUnicode)
        AddColVisible(tdbg, SPLIT3, Arr, , , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ShowFindDialogClient(Finder, dtCaptionCols, Me.Name, "0", gbUnicode)
        '*****************************************
    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, mnsPrint.Click, tsmPrint.Click
        
    End Sub
#End Region


    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= "Delete D91T9009"
        sSQL &= " Where UserID=" & SQLString(gsUserID)
        Return sSQL
    End Function

    Private Function SQLInsertD91T9009s(ByVal sKey01ID As String, ByVal sKey02ID As String, Optional ByVal Num01 As Integer = 0, Optional ByVal FormID As String = "") As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        ' Bổ sung thêm 3 trường HostID, Num01, FormID cho tính năng tsmDeleteSelected - Đã tham khảo PSD (ko ảnh hư tới tinh năng tsmDeleteDepreciationLevel khi insert)
        sSQL.Append("Insert Into D91T9009(")
        sSQL.Append("UserID,Key01ID, Key02ID, HostID, Num01, FormID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
        sSQL.Append(SQLString(sKey01ID) & COMMA) 'Key01ID, varchar[250], NULL
        sSQL.Append(SQLString(sKey02ID) & COMMA) 'Key01ID, varchar[250], NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
        sSQL.Append(SQLNumber(Num01) & COMMA) 'Num01, decimal, NOT NULL
        sSQL.Append(SQLString(FormID)) 'FormID, varchar[50], NOT NULL
        sSQL.Append(")")
        sRet.Append(sSQL.ToString & vbCrLf)
        Return sRet
    End Function

    Private Function SQLStoreD02P0506() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0506 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID01, varchar[8000], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID02, varchar[8000], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID03, varchar[8000], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID04, varchar[8000], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID05, varchar[8000], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID06, varchar[8000], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID07, varchar[8000], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID08, varchar[8000], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID09, varchar[8000], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID10, varchar[8000], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

    'Private Function AllowDelete(ByVal iMode As Integer) As Boolean
    '    Return CheckStore(SQLStoreD02P0505(iMode))
    'End Function

    Private Function AllowDelete(ByVal iMode As Integer) As Boolean
        Dim dt As New DataTable
        Dim bResult As Boolean = CheckStore(SQLStoreD02P0505(iMode), "", dt)
        If dt.Rows.Count > 0 Then
            If L3Int(dt.Rows(0)("Status")) = 4 Then
                If bResult Then
                    Dim frm As New D02F0504
                    frm.ShowDialog()
                    frm.Dispose()
                End If
                Return False
            End If
        End If
        Return bResult
    End Function

    Private Function SQLStoreD02P0505(ByVal iMode As Integer) As String
        'Với @Mode = 0 (chọn mode Tất cả)
        '@Mode = 1 (Chọn mode Từng bút toán)
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0505 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        If geLanguage = EnumLanguage.Vietnamese Then
            sSQL &= SQLNumber(0) & COMMA  'Language, tinyint, NOT NULL
        Else
            sSQL &= SQLNumber(1) & COMMA 'Language, tinyint, NOT NULL
        End If
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, int, NOT NULL
        Return sSQL
    End Function

    Private Function SQLStoreD02P0504(ByVal iMode As Integer) As String
        'Với @Mode = 0 (chọn mode Tất cả)
        '@Mode = 1 (Chọn mode Từng bút toán)
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0504 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, int, NOT NULL
        Return sSQL
    End Function



    Private Function SQLStoreD02P3021(ByVal sReportID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P3021 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcFromPeriod.Columns("TranMonth").Text) & COMMA 'FromTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcFromPeriod.Columns("TranYear").Text) & COMMA 'FromTranYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcToPeriod.Columns("TranMonth").Text) & COMMA 'ToTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcToPeriod.Columns("TranYear").Text) & COMMA 'ToTranYear, int, NOT NULL
        sSQL &= SQLString("%") & COMMA 'FromAssetID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'ToAssetID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'ObjectTypeID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'FromObjectID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'ToObjectID, varchar[20], NOT NULL
        sSQL &= SQLNumber("0") & COMMA 'ShowStopDeprication, tinyint, NOT NULL
        sSQL &= SQLNumber("0") & COMMA 'DecreaseAsset, tinyint, NOT NULL
        sSQL &= SQLString(sFind) & COMMA 'StrFilter, varchar[2000], NOT NULL
        sSQL &= SQLString("D02F3021") & COMMA 'ReportTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(sReportID) & COMMA 'ReportID, varchar[20], NOT NULL
        sSQL &= SQLNumber("0") & COMMA 'PrintOffsetPeriod, tinyint, NOT NULL
        sSQL &= SQLNumber("0") & COMMA 'IsAllAsset, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    Private Sub EnabledColInformation(ByVal ID As ETab)
        Try
            Select Case ID
                Case ETab.EInfo 'Thông tin khấu hao
                    tdbg.Splits(1).SplitSize = 407
                    tdbg.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                    tdbg.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                    tdbg.Splits(2).SplitSize = 0
                    tdbg.Splits(2).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
                    tdbg.Splits(2).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.None
                    btnInfoDepreciation.Enabled = False
                    btnAna.Enabled = (iDisplayAnaCol <> 0)
                Case ETab.EAna 'Khoan muc
                    tdbg.Splits(1).SplitSize = 0
                    tdbg.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
                    tdbg.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.None
                    tdbg.Splits(2).SplitSize = 407
                    tdbg.Splits(2).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                    tdbg.Splits(2).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                    btnInfoDepreciation.Enabled = True
                    btnAna.Enabled = False
            End Select
        Catch
        End Try
    End Sub

    Private Sub btnInfoDepreciation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoDepreciation.Click
        tdbg.Focus()
        tdbg.SplitIndex = 1
        tdbg.Col = COL_ConvertedAmount
        EnabledColInformation(ETab.EInfo)
    End Sub

    Private Sub btnAna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAna.Click
        tdbg.Focus()
        tdbg.SplitIndex = 2
        tdbg.Col = COL_Ana01ID
        EnabledColInformation(ETab.EAna)

    End Sub

    Private Sub CheckUseAna()
        'D91 có sử dụng Khoản mục thì tiếp tục kiểm tra D90 có sử dụng không
        If bUseAna Then
            tdbg.Columns(COL_Ana01ID).Tag = gbArrAnaVisiable(0)
            tdbg.Columns(COL_Ana02ID).Tag = gbArrAnaVisiable(1)
            tdbg.Columns(COL_Ana03ID).Tag = gbArrAnaVisiable(2)
            tdbg.Columns(COL_Ana04ID).Tag = gbArrAnaVisiable(3)
            tdbg.Columns(COL_Ana05ID).Tag = gbArrAnaVisiable(4)
            tdbg.Columns(COL_Ana06ID).Tag = gbArrAnaVisiable(5)
            tdbg.Columns(COL_Ana07ID).Tag = gbArrAnaVisiable(6)
            tdbg.Columns(COL_Ana08ID).Tag = gbArrAnaVisiable(7)
            tdbg.Columns(COL_Ana09ID).Tag = gbArrAnaVisiable(8)
            tdbg.Columns(COL_Ana10ID).Tag = gbArrAnaVisiable(9)

            iDisplayAnaCol = Convert.ToInt16(tdbg.Columns(COL_Ana01ID).Tag.ToString = "True" _
                    OrElse tdbg.Columns(COL_Ana02ID).Tag.ToString = "True" _
                    OrElse tdbg.Columns(COL_Ana03ID).Tag.ToString = "True" _
                    OrElse tdbg.Columns(COL_Ana04ID).Tag.ToString = "True" _
                    OrElse tdbg.Columns(COL_Ana05ID).Tag.ToString = "True" _
                    OrElse tdbg.Columns(COL_Ana06ID).Tag.ToString = "True" _
                    OrElse tdbg.Columns(COL_Ana07ID).Tag.ToString = "True" _
                    OrElse tdbg.Columns(COL_Ana08ID).Tag.ToString = "True" _
                    OrElse tdbg.Columns(COL_Ana09ID).Tag.ToString = "True" _
                    OrElse tdbg.Columns(COL_Ana10ID).Tag.ToString = "True")
        End If
    End Sub



    Private Sub c1dateDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub mnsLockVoucher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsLockVoucher.Click, tsmLockVoucher.Click
        Dim sSQL As String = ""
        If D99C0008.Msg(rl3("MSG000002"), rl3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then '"Bạn có muốn khóa phiếu này không?"
            If tdbg.Columns(COL_ModuleID).Text <> "02" Then
                D99C0008.MsgL3(rl3("Du_lieu_tu_module_khac_chuyen_qua") & Space(1) & rl3("Ban_khong_the_thay_doi_duoc")) 'Dữ liệu từ module khác chuyển qua. Bạn không thể thay đổi được.
                Exit Sub
            End If
            If tdbg.Columns(COL_TranMonth).Text = giTranMonth.ToString And tdbg.Columns(COL_TranYear).Text = giTranYear.ToString Then
            Else
                D99C0008.MsgL3(rl3("Du_lieu_khong_thuoc_ky_nay") & Space(1) & rl3("Ban_khong_the_thay_doi_duoc")) 'Dữ liệu không thuộc kỳ này. Bạn không thể thay đổi được.
                Exit Sub
            End If
            sSQL = "Update D02T0012 Set "
            sSQL = sSQL & " Locked = 1,"
            sSQL = sSQL & " LockedUserID = '" & gsUserID & "',"
            sSQL = sSQL & " LockedDate = " & SQLDateSave(Now)
            sSQL = sSQL & " Where DivisionID = " & SQLString(gsDivisionID) & " And TransactionID = '" & tdbg.Columns(COL_TransactionID).Text & "'"
            ExecuteSQLNoTransaction(sSQL)
            LoadTDBGrid(, tdbg.Columns(COL_VoucherNo).Text)
        End If
    End Sub

    Private Sub tdbg_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If tdbg.RowCount = 0 Then
                tsmLockVoucher.Enabled = False
                mnsLockVoucher.Enabled = False
                Exit Sub
            End If
            tsmLockVoucher.Enabled = (tdbg.RowCount > 0) And tdbg.Columns(COL_Locked).Text = "0" And (iPer_F5557 > EnumPermission.Add) And (Not gbClosed)
            mnsLockVoucher.Enabled = tsmLockVoucher.Enabled
        End If
    End Sub

    'Thêm ngày 27/9/2012 theo incident 51575 (Xuất excel màn hình phân bổ khấu hao) bởi VANVINH
    Private Sub tsbExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then 'Incident 72333
        Dim iSUMCol() As Integer = {COL_VoucherNo, COL_AssetID}

        AddColVisible(tdbg, SPLIT0, arrMaster, iSUMCol, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, arrMaster, iSUMCol, , , gbUnicode)
        AddColVisible(tdbg, SPLIT2, arrMaster, iSUMCol, , , gbUnicode)
        AddColVisible(tdbg, SPLIT3, arrMaster, iSUMCol, , , gbUnicode)

        dtCaptionCols = CreateTableForExcelOnly(tdbg, arrMaster)
        'End If

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        'End If
        Dim frm As New D99F2222
        With frm
            .FormID = Me.Name
            .UseUnicode = gbUnicode
            .dtLoadGrid = dtCaptionCols
            .GroupColumns = gsGroupColumns
            .dtExportTable = dtGrid
            .ShowDialog()
            .Dispose()
        End With
    End Sub


    Private Sub mnsPrintVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsPrintVoucher.Click
        Me.Cursor = Cursors.WaitCursor
        Dim report As New D99C1003
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D02R3021"
        Dim sSubReportName As String = "D02R0000"
        Dim sReportCaption As String = ""
        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""
        Dim sModuleID As String = "02"
        Dim sCustomReport As String = ""

        sReportName = GetReportPath("D02F3021", sReportName, sCustomReport, sReportPath, sReportTitle, sModuleID)
        Me.Cursor = Cursors.Default
        If sReportName = "" Then Exit Sub

        sReportCaption = rL3("Bao_cao_but_toan_phan_bo_khau_hao") & " - " & sReportName

        sSQL = SQLStoreD02P3021(sReportName)
        sSQLSub = "Select Top 1 * From D91T0025 WITH(NOLOCK)"
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnsPrintVoucherAccTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsPrintVoucherAccTrans.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            PrintVoucherAccTrans(D02, tdbg.Columns(COL_VoucherNo).Text, , ReportModeType.lmPreview)
        Catch ex As Exception
            WriteLogFile("In phiếu định khoản bị lổi " & vbCrLf & ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = tdbg.Location 'New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.Height = tdbg.Height
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_VoucherNo, COL_Posted, COL_Locked, COL_ProjectID}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
        usrOption.Anchor = CType(EnumAnchorStyles.TopLeftBottom, System.Windows.Forms.AnchorStyles)
    End Sub

End Class