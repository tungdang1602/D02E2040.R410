'#-------------------------------------------------------------------------------------
'# Created Date: 10/09/2007 11:21:24 AM
'# Created User: Trần Thị ÁiTrâm
'# Modify Date: 10/09/2007 11:21:24 AM
'# Modify User: Trần Thị ÁiTrâm
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System
Imports System.Drawing
Imports System.Collections

Public Class D02F2005

#Region "Const of tdbg - Total of Columns: 47"
    Private Const COL_Choose As Integer = 0            ' Chọn
    Private Const COL_VoucherTypeID As Integer = 1     ' Loại phiếu
    Private Const COL_VoucherNo As Integer = 2         ' Số phiếu
    Private Const COL_VoucherDate As Integer = 3       ' Ngày phiếu
    Private Const COL_VoucherDesc As Integer = 4       ' Diễn giải
    Private Const COL_SeriNo As Integer = 5            ' Số Sêri
    Private Const COL_VATTypeID As Integer = 6         ' Loại hóa đơn
    Private Const COL_RefNo As Integer = 7             ' Số hóa đơn
    Private Const COL_RefDate As Integer = 8           ' Ngày hóa đơn
    Private Const COL_Description As Integer = 9       ' Diễn giải chi tiết
    Private Const COL_DebitAccountID As Integer = 10   ' TK nợ
    Private Const COL_CreditAccountID As Integer = 11  ' TK có
    Private Const COL_CurrencyID As Integer = 12       ' Loại tiền
    Private Const COL_ExchangeRate As Integer = 13     ' Tỷ giá
    Private Const COL_OriginalAmount As Integer = 14   ' Nguyên tệ
    Private Const COL_ConvertedAmount As Integer = 15  ' Qui đổi
    Private Const COL_ObjectTypeID As Integer = 16     ' Loại đối tượng
    Private Const COL_ObjectID As Integer = 17         ' Mã đối tượng
    Private Const COL_ObjectName As Integer = 18       ' Tên đối tượng
    Private Const COL_VATNo As Integer = 19            ' Mã số thuế
    Private Const COL_SourceID As Integer = 20         ' Nguồn vốn
    Private Const COL_BatchID As Integer = 21          ' BatchID
    Private Const COL_Ana01ID As Integer = 22          ' Khoản mục 01
    Private Const COL_Ana02ID As Integer = 23          ' Khoản mục 02
    Private Const COL_Ana03ID As Integer = 24          ' Khoản mục 03
    Private Const COL_Ana04ID As Integer = 25          ' Khoản mục 04
    Private Const COL_Ana05ID As Integer = 26          ' Khoản mục 05
    Private Const COL_Ana06ID As Integer = 27          ' Khoản mục 06
    Private Const COL_Ana07ID As Integer = 28          ' Khoản mục 07
    Private Const COL_Ana08ID As Integer = 29          ' Khoản mục 08
    Private Const COL_Ana09ID As Integer = 30          ' Khoản mục 09
    Private Const COL_Ana10ID As Integer = 31          ' Khoản mục 10
    Private Const COL_CreateUserID As Integer = 32     ' CreateUserID
    Private Const COL_CreateDate As Integer = 33       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 34 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 35   ' LastModifyDate
    Private Const COL_ModuleID As Integer = 36         ' ModuleID
    Private Const COL_AssetID As Integer = 37          ' Mã tài sản
    Private Const COL_AssetCDVID As Integer = 38       ' Mã tài sản ĐV
    Private Const COL_CipNo As Integer = 39            ' Mã XDCB
    Private Const COL_PeriodID As Integer = 40         ' Tập phí
    Private Const COL_TranMonth As Integer = 41        ' TranMonth
    Private Const COL_TranYear As Integer = 42         ' TranYear
    Private Const COL_Cancel As Integer = 43           ' Hủy
    Private Const COL_Locked As Integer = 44           ' Khóa
    Private Const COL_IsCDV As Integer = 45            ' Chuyển ĐV
    Private Const COL_TransactionID As Integer = 46    ' TransactionID
#End Region


    Dim perD02F5800 As Integer

    Private Enum ETab
        EAna = 1
        EOther = 2
    End Enum


#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
#End Region

    '---Kiểm tra khoản mục theo chuẩn gồm 7 bước
    '--- Chuẩn Khoản mục b1: Khai báo biến
#Region "Biến khai báo cho khoản mục"

    Private Const SplitAna As Int16 = 2 ' Ghi nhận Khoản mục chứa ở Split nào
    Dim bUseAna As Boolean 'Kiểm tra có sử dụng Khoản mục không, để set thuộc tính Enabled nút Khoản mục 
    Dim iDisplayAnaCol As Integer = 0 ' Cột Khoản mục đầu tiên được hiển thị, khi nhấn nút Khoản mục thì Focus đến cột đó
#End Region

    Private dtGrid As DataTable
    Private sBatchID As String
    Private sVoucherNoNew As String = ""
    Private sVoucherTypeID As String
    Private sVoucherNo As String
    Dim sFilter As New StringBuilder()

    Dim iColumns() As Integer = {COL_ConvertedAmount}

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub D02F2005_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
        If e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If
        If e.Control Then
            Select Case e.KeyCode
                ' Case Keys.A
                '   tsbListAll_Click(sender, Nothing)
                ' Case Keys.F
                '   tsbFind_Click(sender, Nothing)
                Case Keys.D1, Keys.NumPad1
                    btnAna_Click(Nothing, Nothing)
                Case Keys.D2, Keys.NumPad2
                    btnOther_Click(Nothing, Nothing)
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

    Private Sub D02F2005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        perD02F5800 = ReturnPermission("D02F5800")
        iPer_F5557 = ReturnPermission("D02F5557")
        For i As Integer = 0 To tdbg.Splits.Count - 1
            For j As Integer = 0 To tdbg.Columns.Count - 1
                tdbg.Splits(i).DisplayColumns(j).Locked = True
            Next
        Next
        'tdbg.Splits(0).DisplayColumns(COL_Choose).Locked = False
        'tdbg.Splits(0).DisplayColumns(COL_Choose).Visible = False
        SetShortcutPopupMenu(Me, tbrTableToolStrip, ContextMenuStrip1)
        SetBackColorObligatory()
        '--- Chuẩn Khoản mục b2: Lấy caption cho 10 khoản mục
        bUseAna = LoadTDBGridAnalysisCaption(D02, tdbg, COL_Ana01ID, SplitAna, , gbUnicode)
        '--- Chuẩn Khoản mục b21: D91 có sử dụng Khoản mục
        If bUseAna Then
            iDisplayAnaCol = 1
        End If
        sFind = ""
        '------------------------------------

        Loadlanguage()
        gbEnabledUseFind = False
        LoadTDBCombo()
        LoadDefault()
        chkPeriod_Click(Nothing, Nothing)
        chkDate_Click(Nothing, Nothing)
        InputbyUnicode(Me, gbUnicode)
        '  tdbg.Columns(COL_RefDate).Editor = c1dateDate
        ' tdbg.Columns(COL_VoucherDate).Editor = c1dateDate
        InputDateInTrueDBGrid(tdbg, COL_RefDate, COL_VoucherDate)
        CheckMenu(Me.Name, tbrTableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        CheckMenuOther()
        ResetColorGrid(tdbg, SPLIT0, SPLIT3)
        ResetSplitDividerSize(tdbg)
        tdbg_NumberFormat()

        LoadTDBGridAnalysisCaption(D02, tdbg, COL_Ana01ID, 2, True, gbUnicode)
        btnAna.Enabled = (iDisplayAnaCol <> 0)
        VisibleBySystem() '28/3/2017, Trần Hoàng Anh: id 75367-Bổ sung tính năng điều chuyển đơn vị TSCĐ

        '*****************************************
        'Chuẩn hóa D09U1111 B2_0: đẩy vào Arr các cột có Visible = True (khi nhấn các nút trên lưới)
        'CHÚ Ý: Luôn luôn để đúng thứ tự nút Nhấn trên lưới
        'Đặt các dòng code sau vào cuối FormLoad
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, , , , gbUnicode)
        '-----------------------------------
        EnabledColInformation(ETab.EAna, True)
        AddColVisible(tdbg, SPLIT2, Arr, , , , gbUnicode)
        EnabledColInformation(ETab.EOther, True)
        AddColVisible(tdbg, SPLIT2, Arr, , , , gbUnicode)
        AddColVisible(tdbg, SPLIT3, Arr, , , , gbUnicode)
        If bUseAna Then
            EnabledColInformation(ETab.EAna, True)
        Else
            EnabledColInformation(ETab.EOther, True)
        End If
        '*****************************************
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl        

        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
        tdbg_LockedColumns()
        '*****************************************
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Choose).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_PeriodID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR) '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
    End Sub

    '28/3/2017, Trần Hoàng Anh: id 75367-Bổ sung tính năng điều chuyển đơn vị TSCĐ
    Private Sub VisibleBySystem()
        chkShowCDV.Visible = D02Systems.AllowChangeDivision
       
        tdbg.Splits(SPLIT3).DisplayColumns(COL_IsCDV).Visible = D02Systems.AllowChangeDivision
        tdbg.Splits(SPLIT3).DisplayColumns(COL_IsCDV).AllowSizing = D02Systems.AllowChangeDivision
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD02P1500("")
        dtGrid = ReturnDataTable(sSQL)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If bFlagAdd Then
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        'tdbg.SetDataBinding(dt, "", True)
        'If Not bFlagEdit Or Not gbEnabledUseFind Then
        '    LoadDataSource(tdbg, dt, gbUnicode)
        '    CheckMenu(PARA_FormIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        '    CheckMenuOther()
        'Else
        '    ReLoadTDBGrid()
        'End If
        If sKey <> "" Then 'Khi Thêm mới hoặc Sửa đều thực thi
            Dim dr() As DataRow
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            dr = dt1.Select(tdbg.Columns(COL_BatchID).DataField & " = " & SQLString(sKey))
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0))
            If Not tdbg.Focused Then tdbg.Focus()
        End If
        'FooterTotalGrid(tdbg, COL_VoucherNo)
        'FooterSum(tdbg, iColumns)
    End Sub

    Private Sub CheckMenuOther()
        '*Thay doi ngay 25/3/2013 theo ID 55186
        CheckMenu(Me.Name, tbrTableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1, , "D02F5800")
        'mnsImportData.Enabled = perD02F5800 > 1 And gbClosed = False
        'tsmImportData.Enabled = mnsImportData.Enabled
        'tsbImportData.Enabled = mnsImportData.Enabled
        '****************************
        tsmLockVoucher.Enabled = (tdbg.RowCount > 0) And tdbg.Columns(COL_Locked).Text = "0" And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False And (iPer_F5557 >= EnumPermission.Add) And (Not gbClosed)
        mnsLockVoucher.Enabled = tsmLockVoucher.Enabled
        If tdbg.RowCount <= 0 Then
            mnsEditVoucher.Enabled = False
            mnsExportToExcel.Enabled = False
            mnsCancelVoucher.Enabled = False
            tsmEditVoucher.Enabled = False
            tsmExportToExcel.Enabled = False
            tsmCancelVoucher.Enabled = False
            tsbExportToExcel.Enabled = False
        Else
            '28/3/2017, Trần Hoàng Anh: id 75367-Bổ sung tính năng điều chuyển đơn vị TSCĐ
            tsbEdit.Enabled = tsbEdit.Enabled And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False
            tsmEdit.Enabled = tsmEdit.Enabled And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False
            mnsEdit.Enabled = mnsEdit.Enabled And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False
            tsbDelete.Enabled = tsbDelete.Enabled And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False
            tsmDelete.Enabled = tsmDelete.Enabled And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False
            mnsDelete.Enabled = mnsDelete.Enabled And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False


            'Update 10/01/2011: Kiểm tra kỳ 13
            Dim bPeriod13 As Boolean = (giTranMonth <> 13)
            mnsEditVoucher.Enabled = giPerF5558 > 2 And tdbg.Columns(COL_ModuleID).Text = "02" And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False And Not gbClosed And bPeriod13
            mnsExportToExcel.Enabled = True
            mnsCancelVoucher.Enabled = ReturnPermission("D02F5560") > 0 And Not CBool(tdbg.Columns(COL_Cancel).Text) And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False And Not gbClosed And bPeriod13

            tsmEditVoucher.Enabled = giPerF5558 > 2 And tdbg.Columns(COL_ModuleID).Text = "02" And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False And Not gbClosed And bPeriod13
            tsmExportToExcel.Enabled = True
            tsmCancelVoucher.Enabled = ReturnPermission("D02F5560") > 0 And Not CBool(tdbg.Columns(COL_Cancel).Text) And L3Bool(tdbg.Columns(COL_IsCDV).Text) = False And Not gbClosed And bPeriod13
            tsbExportToExcel.Enabled = True
        End If
        If dtGrid IsNot Nothing Then
            ' tdbg.UpdateData()
            Dim dr() As DataRow = dtGrid.DefaultView.ToTable.Select("Choose = 'True'")
            If dr.Length > 0 Then
                mnsAssetID.Enabled = True
                tsmAssetID.Enabled = True
            Else
                mnsAssetID.Enabled = False
                tsmAssetID.Enabled = False
            End If
            If tdbg.Splits(0).DisplayColumns(COL_Choose).Locked = False Then
                mnsAdd.Enabled = False
                tsbAdd.Enabled = False
                tsmAdd.Enabled = False

                tsbEdit.Enabled = False
                tsmEdit.Enabled = False
                mnsEdit.Enabled = False

                tsmView.Enabled = False
                tsbView.Enabled = False
                mnsView.Enabled = False

                tsmDelete.Enabled = False
                tsbDelete.Enabled = False
                mnsDelete.Enabled = False

                mnsFind.Enabled = False
                tsbFind.Enabled = False
                tsmFind.Enabled = False

                tsmListAll.Enabled = False
                tsbListAll.Enabled = False
                mnsListAll.Enabled = False

                tsbExportToExcel.Enabled = False
                tsmExportToExcel.Enabled = False
                mnsExportToExcel.Enabled = False

                tsbImportData.Enabled = False
                mnsImportData.Enabled = False
                tsmImportData.Enabled = False

                tsmEditVoucher.Enabled = False
                mnsEditVoucher.Enabled = False

                tsmCancelVoucher.Enabled = False
                mnsCancelVoucher.Enabled = False

                tsmPrint.Enabled = False
                tsbPrint.Enabled = False
                mnsPrint.Enabled = False

                tsmSysInfo.Enabled = False
                mnsSysInfo.Enabled = False
                tsbSysInfo.Enabled = False
            End If
        Else
            mnsAssetID.Enabled = False
            tsmAssetID.Enabled = False
        End If



    End Sub

    Private Function SQLStoreD02P1500(ByVal strBatchID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P1500 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL

        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL

        sSQL &= SQLString("") & COMMA 'strFind, varchar[8000], NOT NULL
        If chkDate.Checked And chkPeriod.Checked = False Then
            sSQL &= SQLNumber(1) & COMMA 'IsTime, tinyint, NOT NULL
        ElseIf chkPeriod.Checked And chkDate.Checked = False Then
            sSQL &= SQLNumber(2) & COMMA 'IsTime, tinyint, NOT NULL
        ElseIf chkPeriod.Checked And chkDate.Checked Then
            sSQL &= SQLNumber(3) & COMMA 'IsTime, tinyint, NOT NULL
        ElseIf chkPeriod.Checked = False And chkDate.Checked = False Then
            sSQL &= SQLNumber(4) & COMMA 'IsTime, tinyint, NOT NULL
        End If
        If chkPeriod.Checked Then
            sSQL &= SQLNumber(tdbcFromPeriod.Columns("TranMonth").Text) & COMMA 'FromMonth, tinyint, NOT NULL
            sSQL &= SQLNumber(tdbcFromPeriod.Columns("TranYear").Text) & COMMA 'FromYear, int, NOT NULL
            sSQL &= SQLNumber(tdbcToPeriod.Columns("TranMonth").Text) & COMMA 'ToMonth, tinyint, NOT NULL
            sSQL &= SQLNumber(tdbcToPeriod.Columns("TranYear").Text) & COMMA 'ToYear, int, NOT NULL
        Else
            sSQL &= SQLNumber(0) & COMMA 'FromMonth, tinyint, NOT NULL
            sSQL &= SQLNumber(0) & COMMA 'FromYear, int, NOT NULL
            sSQL &= SQLNumber(0) & COMMA 'ToMonth, tinyint, NOT NULL
            sSQL &= SQLNumber(0) & COMMA 'ToYear, int, NOT NULL
        End If
        If chkDate.Checked Then
            sSQL &= SQLDateSave(c1dateFromDate.Value) & COMMA 'FromDate, datetime, NOT NULL
            sSQL &= SQLDateSave(c1dateToDate.Value) & COMMA 'ToDate, datetime, NOT NULL
        Else
            sSQL &= "NULL" & COMMA 'FromDate, datetime, NOT NULL
            sSQL &= "NULL" & COMMA 'ToDate, datetime, NOT NULL
        End If
        sSQL &= SQLString(strBatchID) & COMMA 'BatchID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbcVoucherTypeID.Text) & COMMA 'VoucherTypeID, varchar[50], NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherNo, varchar[50], NOT NULL
        sSQL &= SQLNumber(IIf(giTranMonth = 13, 1, 0)) & COMMA
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLNumber(chkShow.Checked) & COMMA 'IsCompleted, tinyint, NOT NULL
        '28/3/2017, Trần Hoàng Anh: id 75367-Bổ sung tính năng điều chuyển đơn vị TSCĐ
        sSQL &= SQLNumber(chkShowCDV.Checked) 'IsCDB, tinyint, NOT NULL
        Return sSQL
    End Function


    Private WithEvents Finder As New D99C1001
    Private dtCaptionCols As DataTable
    Private sFind As String = ""
    Dim bRefreshFilter As Boolean = False
    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, mnsListAll.Click, tsmListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#Region "Active Find - List All (Client)"
    '   Dim dtCaptionCols As DataTable

    '   Private WithEvents Finder As New D99C1001
    '   Private sFind As String = ""


    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, mnsFind.Click, tsmFind.Click
        'Dim sSQL As String = ""
        'gbEnabledUseFind = True
        'sSQL = "Select * From D02V1234 "
        'sSQL &= "Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
        'ShowFindDialogClient(Finder, sSQL, gbUnicode)
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        Dim dtCaptionCols1 As DataTable
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT1, Arr, , False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT2, Arr, , False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT3, Arr, , False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols1 = CreateTableForExcelOnly(tdbg, Arr)
        ShowFindDialogClient(Finder, dtCaptionCols1, Me.Name, "0", gbUnicode)
    End Sub
    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Then Exit Sub
        sFind = ResultWhereClause.ToString
        ReLoadTDBGrid()
    End Sub

#End Region
#Region "Active Find Client - List All "
    'Private WithEvents Finder As New D99C1001
    '   Private sFind As String = ""

    'Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
    '    If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '    Dim sSQL As String = ""
    '    gbEnabledUseFind = True
    '    sSQL = "Select * From D02V1234 "
    '    sSQL &= "Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
    '    ShowFindDialogClient(Finder, sSQL)
    'End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    'Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
    '    If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    '    sFind = ""
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGird()

    End Sub

    Private Sub ResetGird()

        CheckMenuOther()
        FooterTotalGrid(tdbg, COL_VoucherNo)
        FooterSum(tdbg, iColumns, , True)
    End Sub
#End Region

    'Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
    'If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
    'ShowSysInfoDialog(tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    'End Sub
    Private Sub tsbSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, mnsSysInfo.Click, tsmSysInfo.Click
        ShowSysInfoDialog(tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D02F2004
        With f
            .BatchID = ""
            .VoucherTypeID = ""
            .VoucherNo = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            .Dispose()
            sBatchID = .BatchID
            sVoucherTypeID = .VoucherTypeID
            sVoucherNo = .VoucherNo
        End With
        If gbSavedOK Then
            LoadTDBGrid(True, sBatchID)
        End If
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D02F2004
        'Kiểm tra điều kiện Sửa
        If AllowEdit() = False Then Exit Sub
        If Not AllowEditDelete(0) Then Exit Sub
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If
        With f
            .BatchID = tdbg.Columns(COL_BatchID).Text
            .VoucherTypeID = tdbg.Columns(COL_VoucherTypeID).Text
            .VoucherNo = tdbg.Columns(COL_VoucherNo).Text
            .CreateUserID = tdbg.Columns(COL_CreateUserID).Text
            .CreateUserDate = tdbg.Columns(COL_CreateDate).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
        End With
        If gbSavedOK Then
            LoadTDBGrid(True, tdbg.Columns(COL_BatchID).Text)
        End If
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click

        Dim sSQL As String = ""

        Dim bResult As Boolean

        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            'Kiểm tra điều kiện xóa
            If AllowDelete() = False Then Exit Sub
            If Not AllowEditDelete(1) Then Exit Sub
            If L3Bool(tdbg.Columns(COL_Locked).Text) Then
                D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
                Exit Sub
            End If
            sSQL = "Delete From D02T0018" & vbCrLf
            sSQL &= "Where BatchID=" & SQLString(tdbg.Columns(COL_BatchID).Text) & vbCrLf
            sSQL &= "Delete From D02T0012" & vbCrLf
            sSQL &= "Where BatchID=" & SQLString(tdbg.Columns(COL_BatchID).Text) & vbCrLf
            sSQL &= "Delete From D02T5558" & vbCrLf
            sSQL &= "Where BatchID=" & SQLString(tdbg.Columns(COL_BatchID).Text) & vbCrLf
            bResult = ExecuteSQL(sSQL)
            If bResult = True Then
                DeleteOK()
                DeleteVoucherNoD91T9111(tdbg.Columns(COL_VoucherNo).Value.ToString, "D02T0012", "VoucherNo")
                DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            Else
                DeleteNotOK()
            End If
        End If
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D02F2004
        With f
            .BatchID = tdbg.Columns(COL_BatchID).Text
            .VoucherTypeID = tdbg.Columns(COL_VoucherTypeID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Function AllowEditDelete(ByVal iMode As Integer) As Boolean
        Return CheckStore(SQLStoreD02P1402(iMode))
    End Function

    Private Function SQLStoreD02P1402(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P1402 "
        sSQL &= SQLString(tdbg.Columns(COL_BatchID).Text) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLNumber(geLanguage) & COMMA 'Language, tinyint, NOT NULL
        sSQL &= SQLNumber(iMode) 'Delete, tinyint, NOT NULL
        Return sSQL
    End Function


    Dim iHeight As Integer = 0
    Dim bHeadCleck As Boolean = False

    Private Sub tdbg_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColEdit
        If tdbg.Col = COL_Choose Then
            CheckMenuOther()
        End If
    End Sub

    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle

        If tdbg.Splits(0).DisplayColumns(COL_Choose).Locked = False Then
            If e.Row Mod 2 = 0 Then
                e.CellStyle.BackColor = Color.White
            Else
                e.CellStyle.BackColor = Color.Beige
            End If
        End If
    End Sub
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub ' Lấy tọa độ Y của chuột click tới


    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_Choose
                If tdbg.Splits(0).DisplayColumns(COL_Choose).Locked = False Then
                    L3HeadClick(tdbg, iCol, bHeadCleck) 'Có trong D99X0000
                End If
            Case Else
                tdbg.AllowSort = True 'Nếu mặc định AllowSort = True
        End Select
    End Sub


    Private Sub tdbg_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
        iHeight = e.Location.Y
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If iHeight <= tdbg.Splits(0).ColumnCaptionHeight Then Exit Sub
        If tdbg.FilterActive Then Exit Sub

        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub

    'Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
    '    Try
    '        If (dt Is Nothing) Then Exit Sub
    '        sFilter = New StringBuilder("")
    '        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
    '        For Each dc In Me.tdbg.Columns
    '            Select Case dc.DataType.Name
    '                Case "DateTime"
    '                    If dc.FilterText.Length = 10 Then
    '                        If sFilter.Length > 0 Then sFilter.Append(" AND ")
    '                        Dim sClause As String = ""
    '                        sClause = "(" & dc.DataField & " >= #" & DateSave(CDate(dc.FilterText)) & "#"
    '                        sClause &= " And " & dc.DataField & " < #" & DateSave(CDate(dc.FilterText).AddDays(1)) & "# )"
    '                        sFilter.Append(sClause)
    '                    End If

    '                Case "Boolean"
    '                    If dc.FilterText.Length > 0 Then
    '                        If sFilter.Length > 0 Then sFilter.Append(" AND ")
    '                        sFilter.Append((dc.DataField + " = " + "'" + dc.FilterText + "'"))
    '                    End If

    '                Case "String"
    '                    If dc.FilterText.Length > 0 Then
    '                        If sFilter.Length > 0 Then sFilter.Append(" AND ")
    '                        sFilter.Append((dc.DataField + " like " + "'%" + dc.FilterText.Replace("'", "''") + "%'"))
    '                    End If

    '                Case "Decimal", "Byte", "Integer"
    '                    If dc.FilterText.Length > 0 Then
    '                        If sFilter.Length > 0 Then sFilter.Append(" AND ")
    '                        sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
    '                    End If
    '            End Select
    '        Next

    '        'Filter the data 
    '        If sFilter.ToString() <> "" And sFind <> "" Then
    '            dt.DefaultView.RowFilter = sFilter.ToString() & " AND " & sFind
    '        ElseIf sFind <> "" Then
    '            dt.DefaultView.RowFilter = sFind
    '        ElseIf sFind = "" Then
    '            dt.DefaultView.RowFilter = sFilter.ToString()
    '        End If

    '        CheckMenu(PARA_FormIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False)
    '        CheckMenuOther()
    '        FooterTotalGrid(tdbg, COL_VoucherNo)
    '        FooterSum(tdbg, iColumns)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message & " - " & ex.Source)
    '    End Try

    'End Sub
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

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        '   If e.Control Then
        'CheckMenu(PARA_FormIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        ' End If
        If tdbg.Columns.Count <= 0 Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            If tdbg.FilterActive Then Exit Sub
            If tsbEdit.Enabled Then
                tsbEdit_Click(sender, Nothing)
            ElseIf tsbView.Enabled Then
                tsbView_Click(sender, Nothing)
            End If
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tsmEditVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEditVoucher.Click, mnsEditVoucher.Click

        If AllowEdit() = False Then Exit Sub
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rl3("MSG000003") & Space(1) & rl3("MSG000023")) 'Phieu_nay_da_duoc_khoa_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        gbSavedOK = False
        'Dim frm As New D91F5558
        'With frm
        '    .FormName = "D91F5558"
        '    .FormPermission = "D02F5558" 'Màn hình phân quyền
        '    .ModuleID = D02 'Mã module hiện tại, VD: D22
        '    .TableName = "D02T0012" 'Tên bảng chứa số phiếu
        '    .VoucherID = tdbg.Columns(COL_BatchID).Value.ToString 'Khóa sinh IGE
        '    .VoucherNo = tdbg.Columns(COL_VoucherNo).Value.ToString 'Số phiếu cần sửa
        '    .Mode = "0" ' Tùy theo Module, mặc định là 0
        '    .KeyID01 = ""
        '    .KeyID02 = ""
        '    .KeyID03 = ""
        '    .KeyID04 = ""
        '    .KeyID05 = ""
        '    .ShowDialog()
        '    If .Output01 <> "" Then gbSavedOK = CBool(.Output01) 'Giá trị trả về
        '    .Dispose()
        'End With

        'If gbSavedOK Then
        '    Dim sVoucherIDOld As String = tdbg.Columns(COL_VoucherNo).Value.ToString
        '    'Load lại dữ liệu cho lưới
        '    LoadTDBGrid()
        '    If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        'End If

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D02F5558")
        SetProperties(arrPro, "VoucherTypeID", ReturnValueC1Combo(tdbcVoucherTypeID))
        SetProperties(arrPro, "VoucherID", tdbg.Columns(COL_BatchID).Value.ToString)
        SetProperties(arrPro, "Mode", 0)
        SetProperties(arrPro, "KeyID01", "")
        SetProperties(arrPro, "TableName", "D02T0012")
        SetProperties(arrPro, "ModuleID", D02)
        SetProperties(arrPro, "OldVoucherNo", tdbg.Columns(COL_VoucherNo).Value.ToString)
        SetProperties(arrPro, "KeyID02", "")
        SetProperties(arrPro, "KeyID03", "")
        SetProperties(arrPro, "KeyID04", "")
        SetProperties(arrPro, "KeyID05", "")
        Dim frm As Form = CallFormShowDialog("D91D0640", "D91F5558", arrPro)
        'Dim sNew As String = GetProperties(frm, "NewVoucherNo").ToString
        gbSavedOK = CType(GetProperties(frm, "bSaved"), Boolean)
        If gbSavedOK Then
            Dim sVoucherIDOld As String = tdbg.Columns(COL_VoucherNo).Value.ToString
            'Load lại dữ liệu cho lưới
            LoadTDBGrid()
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        End If
    End Sub



    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_chung_tu_-_D02F2005") & UnicodeCaption(gbUnicode) 'Danh sÀch ch÷ng tô - D02F2005
        '================================================================ 
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblVoucherNo.Text = rl3("So_phieu_co_chua") 'Số phiếu có chứa
        '================================================================ 
        chkShow.Text = rl3("Chi_hien_thi_cac_chung_tu_chua_hinh_thanh_tai_san_(tu_XDCB)")
        ' btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnAna.Text = "1. " & rL3("Khoan_muc")
        btnOther.Text = "2. " & rl3("Khac")
        'Chuẩn hóa D09U1111 B6: Gắn F12
        btnF12.Text = "F12 (" & rL3("Hien_thi") & ")"
        btnFilter.Text = rl3("Loc") & " (F5)" '&Lọc
        '================================================================ 
        chkDate.Text = rl3("Ngay") 'Ngày
        chkPeriod.Text = rL3("Ky") 'Kỳ
        chkShowCDV.Text = rL3("Hien_thi_cac_chung_tu_dieu_chuyen_don_vi") 'Hiển thị các chứng từ điều chuyển đơn vị
        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("VoucherTypeID").Caption = rl3("Loai_phieu") 'Loại phiếu
        tdbg.Columns("Choose").Caption = rl3("Chon") 'Loại phiếu
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("SeriNo").Caption = rl3("So_Seri") 'Số Sêri
        tdbg.Columns("VATTypeID").Caption = rl3("Loai_hoa_don") 'Loại hóa đơn
        tdbg.Columns("RefNo").Caption = rl3("So_hoa_don") 'Số hóa đơn
        tdbg.Columns("RefDate").Caption = rl3("Ngay_hoa_don") 'Ngày hóa đơn

        'Them Space(1) sau caption de fix loi sai Caption trung DataField
        tdbg.Columns("VoucherDesc").Caption = rl3("Dien_giai") & Space(1) 'Diễn giải
        tdbg.Columns("Description").Caption = rl3("Dien_giai_chi_tiet")

        tdbg.Columns("DebitAccountID").Caption = rl3("TK_no") 'TK nợ
        tdbg.Columns("CreditAccountID").Caption = rl3("TK_co") 'TK có
        tdbg.Columns("CurrencyID").Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns("ExchangeRate").Caption = rl3("Ty_gia") 'Tỷ giá
        tdbg.Columns("OriginalAmount").Caption = rl3("Nguyen_te") 'Nguyên tệ
        tdbg.Columns("ConvertedAmount").Caption = rl3("Quy_doi") 'Quy đổi
        tdbg.Columns("ObjectTypeID").Caption = rl3("Loai_doi_tuong") 'Loại đối tượng
        tdbg.Columns("ObjectID").Caption = rl3("Ma_doi_tuong") 'Mã đối tượng
        tdbg.Columns("ObjectName").Caption = rl3("Ten_doi_tuong") 'Tên đối tượng
        tdbg.Columns("VATNo").Caption = rl3("Ma_so_thue") 'Mã số thuế
        tdbg.Columns("SourceID").Caption = rl3("Nguon_von") 'Nguồn vốn
        tdbg.Columns("AssetID").Caption = rL3("Ma_tai_san") 'Mã tài sản
        tdbg.Columns("AssetCDVID").Caption = rL3("Ma_tai_san_DV")          ' Mã tài sản ĐV
        tdbg.Columns("CipNo").Caption = rl3("Ma_XDCB") 'Mã XDCB
        tdbg.Columns("Cancel").Caption = rl3("Huy") 'Hủy
        tdbg.Columns(COL_Locked).Caption = rL3("Khoa") 'Khóa
        tdbg.Columns("IsCDV").Caption = rL3("Chuyen_DV")   ' Chuyển ĐV
        '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
        tdbg.Columns("PeriodID").Caption = rL3("Tap_phi") 'Tập phí
        '================================================================ 

        tsmAssetID.Text = rl3("Hi_nh_thanh_tai_san_tu_XDCB")


        mnsAssetID.Text = rl3("Hi_nh_thanh_tai_san_tu_XDCB")
        'mnuAdd.Text = rl3("_Them") '&Thêm
        'mnuView.Text = rl3("Xe_m") 'Xe&m
        'mnuEdit.Text = rl3("_Sua") '&Sửa
        'mnuDelete.Text = rl3("_Xoa") '&Xóa
        'mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        'mnuPrint.Text = rl3("_In")
        'mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        'mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        'mnuEditVoucher.Text = rl3("Sua_so_phieu") 'Sửa số phiếu
        'mnuExportToExcel.Text = rl3("Xuat__Excel")
        mnsVoucherNo.Text = rl3("_Chung_tu") '&Chứng từ
        mnsListVoucherNo.Text = rl3("_Danh_sach_chung_tu") '&Danh sách chứng từ
        tsmVoucherNo.Text = rl3("_Chung_tu") '&Chứng từ
        tsmListVoucherNo.Text = rl3("_Danh_sach_chung_tu") '&Danh sách chứng từ
        tsbVoucherNo.Text = rl3("_Chung_tu") '&Chứng từ
        tsbListVoucherNo.Text = rl3("_Danh_sach_chung_tu") '&Danh sách chứng từ
        'mnuCancelVoucher.Text = rl3("Huy_phieu")
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ExchangeRate).NumberFormat = DxxFormat.ExchangeRateDecimals
        tdbg.Columns(COL_OriginalAmount).NumberFormat = DxxFormat.DecimalPlaces
        tdbg.Columns(COL_ConvertedAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
    End Sub

    Private Sub btnAna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAna.Click
        EnabledColInformation(ETab.EAna)
    End Sub

    Private Sub EnabledColInformation(ByVal ID As ETab, Optional ByVal bFlagLoad As Boolean = False)
        Try
            Dim i As Integer
            With tdbg.Splits(2)
                Select Case ID
                    Case ETab.EAna 'Khoan muc
                        For i = COL_Ana01ID To COL_Ana10ID
                            tdbg.Splits(SPLIT2).DisplayColumns(i).Visible = Convert.ToBoolean(tdbg.Columns(i).Tag)
                        Next
                        tdbg.Splits(SPLIT2).DisplayColumns(COL_AssetID).Visible = False
                        tdbg.Splits(SPLIT2).DisplayColumns(COL_CipNo).Visible = False

                        tdbg.Splits(SPLIT2).DisplayColumns(COL_AssetCDVID).Visible = False
                        tdbg.Splits(SPLIT2).DisplayColumns(COL_AssetCDVID).AllowSizing = False
                        tdbg.Splits(SPLIT2).DisplayColumns(COL_PeriodID).Visible = True
                        btnAna.Enabled = False
                        btnOther.Enabled = True
                        tdbg.SplitIndex = 2

                        tdbg.Focus()
                        '------------------------------------------
                    Case ETab.EOther 'Khác
                        For i = COL_Ana01ID To COL_Ana10ID
                            tdbg.Splits(SPLIT2).DisplayColumns(i).Visible = False
                        Next

                        tdbg.Splits(SPLIT2).DisplayColumns(COL_AssetCDVID).Visible = D02Systems.AllowChangeDivision
                        tdbg.Splits(SPLIT2).DisplayColumns(COL_AssetCDVID).AllowSizing = D02Systems.AllowChangeDivision

                        tdbg.Splits(SPLIT2).DisplayColumns(COL_AssetID).Visible = True
                        tdbg.Splits(SPLIT2).DisplayColumns(COL_CipNo).Visible = True
                        tdbg.Splits(SPLIT2).DisplayColumns(COL_PeriodID).Visible = True
                        btnAna.Enabled = (iDisplayAnaCol <> 0)
                        btnOther.Enabled = False
                        tdbg.SplitIndex = 2
                        tdbg.Col = COL_AssetID
                        tdbg.Focus()
                End Select
            End With
            'Chuẩn hóa D09U1111 B5: Refresh lại lưới
            If Not bFlagLoad Then Call_D09U1111Refresh()
            tdbg.Refresh()
        Catch
        End Try
    End Sub


    Private Sub EnabledColInformation1(ByVal ID As ETab, Optional ByVal bFlagLoad As Boolean = False)
        Try
            Dim i As Integer
            With tdbg.Splits(1)
                Select Case ID
                    Case ETab.EAna 'Khoan muc
                        For i = COL_Ana01ID To COL_Ana10ID
                            tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = Convert.ToBoolean(tdbg.Columns(i).Tag)
                        Next
                        tdbg.Splits(SPLIT1).DisplayColumns(COL_AssetID).Visible = False
                        tdbg.Splits(SPLIT1).DisplayColumns(COL_CipNo).Visible = False
                        '   btnAna.Enabled = False
                        'btnOther.Enabled = True
                        ' tdbg.SplitIndex = 1

                        ' tdbg.Focus()
                        '------------------------------------------
                    Case ETab.EOther 'Khác
                        For i = COL_Ana01ID To COL_Ana10ID
                            tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = False
                        Next
                        tdbg.Splits(SPLIT1).DisplayColumns(COL_AssetID).Visible = True
                        tdbg.Splits(SPLIT1).DisplayColumns(COL_CipNo).Visible = True
                        ' btnAna.Enabled = (iDisplayAnaCol <> 0)
                        ' btnOther.Enabled = False
                        ' tdbg.SplitIndex = 1
                        ' tdbg.Col = COL_AssetID
                        ' tdbg.Focus()
                End Select
            End With
            'Chuẩn hóa D09U1111 B5: Refresh lại lưới
            If Not bFlagLoad Then Call_D09U1111Refresh()
            tdbg.Refresh()
        Catch
        End Try
    End Sub

    Private Sub Call_D09U1111Refresh()
        'Chuẩn hóa D09U1111 B5: đánh dấu sự ẩn hiện từng cột trên lưới mỗi khi có sự thay đổi, sau đó Refresh lại lưới
        'Gọi hàm Call_D09U1111Refresh tại sự kiện ClickButton
        'MarkInvisibleColumn(SPLIT1)
        If usrOption IsNot Nothing Then
            usrOption.MarkInvisibleColumn(SPLIT2)
            usrOption.D09U1111Refresh()
        End If
    End Sub

    Private Sub btnOther_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOther.Click
        EnabledColInformation(ETab.EOther)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcToPeriod
        LoadCboPeriodReport(tdbcFromPeriod, tdbcToPeriod, D02)

        'Load tdbcVoucherTypeID
        sSQL = "Select 0 as DisplayOrder,'%' As VoucherTypeID, " & AllName & " As VoucherTypeName " & vbCrLf
        sSQL &= "Union All" & vbCrLf
        sSQL &= "Select 1 as DisplayOrder,VoucherTypeID,VoucherTypeName" & UnicodeJoin(gbUnicode) & " as VoucherTypeName" & vbCrLf
        sSQL &= "From D91T0001 WITH(NOLOCK)" & vbCrLf
        sSQL &= "Where UseD02=1 And Disabled=0 And (VoucherDivisionID='' Or VoucherDivisionID=" & SQLString(gsDivisionID) & ")" & vbCrLf
        sSQL &= "Order By DisplayOrder,VoucherTypeID"
        LoadDataSource(tdbcVoucherTypeID, sSQL, gbUnicode)

    End Sub

    Private Sub tsbVoucherNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbVoucherNo.Click, tsmVoucherNo.Click, mnsVoucherNo.Click
        Me.Cursor = Cursors.WaitCursor
        Dim report As New D99C1003
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D02R2005"
        Dim sSubReportName As String = "D91R0000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportCaption = rl3("Bao_cao_Chung_tu") & " - " & sReportName '& UnicodeCaption(gbUnicode)
        sPathReport = UnicodeGetReportPath(gbUnicode, D02Options.ReportLanguage, "") & sReportName & ".rpt"
        ' sPathReport = Application.StartupPath & "\XReports\" & sReportName & ".rpt"
        sSQLSub = SQLSubReport(gsDivisionID)
        sSQL = SQLStoreD02P1500(tdbg.Columns(COL_BatchID).Text)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub tsbListVoucherNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListVoucherNo.Click, mnsListVoucherNo.Click, tsmListVoucherNo.Click
        Me.Cursor = Cursors.WaitCursor

        Dim report As New D99C1003
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D02R2005"
        Dim sSubReportName As String = "D91R0000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportCaption = rl3("Bao_cao_danh_sach_chung_tu") & " - " & sReportName ' & UnicodeCaption(gbUnicode)
        sPathReport = UnicodeGetReportPath(gbUnicode, D02Options.ReportLanguage, "") & sReportName & ".rpt"
        sSQLSub = SQLSubReport(gsDivisionID)


        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(dtGrid.DefaultView.ToTable) ' Sua ngay 7/9/2012 boi VANVINH
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub chkPeriod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPeriod.Click
        If chkPeriod.Checked Then
            UnReadOnlyControl(tdbcFromPeriod)
            UnReadOnlyControl(tdbcToPeriod)
            tdbcFromPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            tdbcToPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        Else
            ReadOnlyControl(tdbcFromPeriod)
            ReadOnlyControl(tdbcToPeriod)
        End If
    End Sub

    Private Sub chkDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDate.Click
        If chkDate.Checked Then
            UnReadOnlyControl(c1dateFromDate)
            UnReadOnlyControl(c1dateToDate)
        Else
            ReadOnlyControl(c1dateFromDate)
            ReadOnlyControl(c1dateToDate)
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click

        'Set lại các giá trị FilterText
        sFind = "" ' Them ngay 7/9/2012 boi VANVINH
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        For Each dc In Me.tdbg.Columns
            dc.FilterText = ""
        Next dc

        'sFind = ""
        If chkShow.Checked = True Then
            tdbg.Splits(0).DisplayColumns(COL_Choose).Locked = False
            tdbg.Splits(SPLIT0).DisplayColumns(COL_Choose).Style.BackColor = Color.FromArgb(255, 255, 255, 255)
        Else
            tdbg.Splits(0).DisplayColumns(COL_Choose).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_Choose).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If
        If AllowFilter() = False Then Exit Sub
        LoadTDBGrid()

        'Dim Arr As New ArrayList
        'AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        '-----------------------------------
        'EnabledColInformation1(ETab.EAna, True)
        'AddColVisible(tdbg, SPLIT1, Arr, , , , gbUnicode)
        'EnabledColInformation1(ETab.EOther, True)
        'AddColVisible(tdbg, SPLIT1, Arr, , , , gbUnicode)
        'AddColVisible(tdbg, SPLIT2, Arr, , , , gbUnicode)
        'If bUseAna Then
        '    EnabledColInformation(ETab.EAna, True)
        'Else
        '    EnabledColInformation(ETab.EOther, True)
        'End If
        '*****************************************
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl        

        'dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        'usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
    End Sub

    Private Function AllowFilter() As Boolean
        If chkPeriod.Checked Then
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
            If Not CheckValidPeriodFromTo(tdbcFromPeriod, tdbcToPeriod) Then Return False
        End If
        If chkDate.Checked Then
            If c1dateFromDate.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay"))
                c1dateFromDate.Focus()
                Return False
            End If
            If c1dateToDate.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay"))
                c1dateToDate.Focus()
                Return False
            End If
            If Not CheckValidDateFromTo(c1dateFromDate, c1dateToDate) Then Return False

            'If CDate(c1dateFromDate.Text) < CDate(c1dateFromDate.Calendar.MinDate) Or CDate(c1dateFromDate.Text) > CDate(c1dateFromDate.Calendar.MaxDate) Then
            '    D99C0008.MsgL3(rl3("Ngay_khong_hop_le"))
            '    c1dateFromDate.Focus()
            '    Return False
            'End If
            'If CDate(c1dateToDate.Text) < CDate(c1dateToDate.Calendar.MinDate) Or CDate(c1dateToDate.Text) > CDate(c1dateToDate.Calendar.MaxDate) Then
            '    D99C0008.MsgL3(rl3("Ngay_khong_hop_le"))
            '    c1dateToDate.Focus()
            '    Return False
            'End If
        End If
        Return True
    End Function

    Private Function AllowEdit() As Boolean
        If CInt(tdbg(tdbg.Row, COL_TranMonth).ToString) + CInt(tdbg(tdbg.Row, COL_TranYear).ToString) * 100 <> giTranMonth + giTranYear * 100 Then
            'D99C0008.MsgL3(rl3("Chung_tu_khong_thuoc_ky_ke_toan_nay") & Space(1) & rl3("Ban_khong_duoc_phep_sua"))
            D99C0008.MsgL3(rl3("MSG000001"))
            Return False
        End If
        If CBool(tdbg.Columns(COL_Cancel).Text) Then
            D99C0008.MsgL3(rl3("MSG000031"))
            Return False
        End If
        Return True
    End Function

    Private Function AllowDelete() As Boolean
        If CInt(tdbg(tdbg.Row, COL_TranMonth).ToString) + CInt(tdbg(tdbg.Row, COL_TranYear).ToString) * 100 <> giTranMonth + giTranYear * 100 Then
            'D99C0008.MsgL3(rl3("Chung_tu_khong_thuoc_ky_ke_toan_nay") & Space(1) & rl3("Ban_khong_duoc_phep_xoa"))
            D99C0008.MsgL3(rl3("MSG000001"))
            Return False
        End If
        Return True
    End Function

    Private Sub btnF12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        '*****************************************
        'Chuẩn hóa D09U1111 B7: Xuất Excel (Nếu lưới có nút Hiển thị)
        Dim frm As New D99F2222
        ResetTableForExcel(tdbg, gdtCaptionExcel, iColumns)
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

    Private Sub LoadDefault()
        tdbcFromPeriod.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcToPeriod.Text = giTranMonth.ToString("00") & "/" & giTranYear
        c1dateFromDate.Value = Date.Today
        c1dateToDate.Value = Date.Today
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcFromPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcToPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateFromDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateToDate.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "Events tdbcVoucherTypeID"

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
        End If

    End Sub

#End Region

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

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Cancel, COL_Choose, COL_Locked
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_ConvertedAmount, COL_OriginalAmount, COL_ExchangeRate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
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

    Private Sub tsmCancelVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCancelVoucher.Click, mnsCancelVoucher.Click

        If tdbg.RowCount <= 0 Then Exit Sub
        If tdbg.Columns(COL_ModuleID).Text <> "02" Then
            D99C0008.MsgL3(rL3("MSG000032"))
            Exit Sub
        End If
        If CInt(tdbg(tdbg.Row, COL_TranMonth).ToString) + CInt(tdbg(tdbg.Row, COL_TranYear).ToString) * 100 <> giTranMonth + giTranYear * 100 Then
            D99C0008.MsgL3(rL3("MSG000001"))
            Exit Sub
        End If
        If Not CheckStore(SQLStoreD02P1402(2).ToString) Then Exit Sub
        'If D99C0008.MsgAsk(rl3("MSG000004"), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then Exit Sub
        '   Dim bookmark As Int32 = 0
        ' If Not IsDBNull(tdbg.Bookmark) Then bookmark = tdbg.Bookmark

        Dim frm As New D02F5560
        With frm
            .BatchID = tdbg.Columns(COL_BatchID).Text
            .VoucherNo = tdbg.Columns(COL_VoucherNo).Text
            .VoucherDate = tdbg.Columns(COL_VoucherDate).Text
            .Notes = tdbg.Columns(COL_VoucherDesc).Text
            .ShowDialog()
            .Dispose()
        End With

        If gbSavedOK Then
            LoadTDBGrid(True, tdbg.Columns(COL_BatchID).Text.ToString)
        End If
        ' If Not IsDBNull(bookmark) Then tdbg.Bookmark = bookmark
    End Sub

    Private Sub tsbImportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportData.Click, mnsImportData.Click, tsmImportData.Click
        'Me.Cursor = Cursors.WaitCursor
        'gbSavedOK = False
        'Dim frm As New D80F2090
        'With frm
        '    .FormActive = "D80F2090"
        '    .FormPermission = "D02F2005"
        '    .ModuleID = "D02"
        '    .TransTypeID = "D02F2005" 'Theo TL phân tích
        '    .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '    .ShowDialog()
        '    If .OutPut01 Then gbSavedOK = .OutPut01
        '    .Dispose()
        'End With
        'If gbSavedOK Then
        '    'Load lại dữ liệu
        '    LoadTDBGrid(True)
        'End If

        If CallShowDialogD80F2090(D02, "D02F2005", "D02F2005") Then
            LoadTDBGrid(True)
        End If
        Me.Cursor = Cursors.Default
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        ' CheckMenu(Me.Name, tbrTableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        CheckMenuOther()
    End Sub


    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub chkShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShow.Click
        'Sua ngay 18/7/2012
        If chkShow.Checked = True Then
            tdbg.Splits(0).DisplayColumns(COL_Choose).AllowFocus = True
        Else
            tdbg.Splits(0).DisplayColumns(COL_Choose).AllowFocus = False
        End If
        '  LoadTDBGrid(, tdbg.Columns(COL_BatchID).Text)
    End Sub

    Private Sub tsmAssetID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAssetID.Click, mnsAssetID.Click
        Dim sSQl As String = "Delete D91T9009 where UserID = " & SQLString(gsUserID) & " and HostID = " & SQLString(My.Computer.Name)
        sSQl &= vbCrLf & SQLInsertD91T9009s.ToString
        ExecuteSQLNoTransaction(sSQl)

        ''Dim frm As New D02F1010
        ''frm.ShowDialog()

        ' ''Dim exe As New D02E0030(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        ' ''exe.FormActive = D02E0030Form.D02F1010
        ' ''exe.FormState = EnumFormState.FormEdit 'FormAdd Truyền FormEdit vì VB 6.0 FormAdd = 1
        ' ''exe.Flag = True
        ' ''exe.RunExeWait()

        'Dim frm As New D02M2240
        'frm.FormActive = "D02F1010"
        'frm.FormStatus = EnumFormState.FormCopy
        ''Thêm ngày 20/7/2012 theo incident 49472
        'frm.FromCall = "D02F2005"
        'frm.ShowDialog()
        'frm.Dispose()

        '======================
        '18/4/2017, id 96337-Đóng gói V4.1
        Dim dicParaIn As New Dictionary(Of String, Object) 'DS tham số đầu vào
        dicParaIn.Add("Ctrl02", "8")
        dicParaIn.Add("FromCall", "D02F2005")
        Lemon3.CallDxxMxx40("D02E2240", "D02F1010", dicParaIn)

        ExecuteSQLNoTransaction("Delete D91T9009 where UserID = " & SQLString(gsUserID) & " and HostID = " & SQLString(My.Computer.Name))
        btnFilter_Click(Nothing, Nothing)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009s
    '# Created User: Lê Đình Thái
    '# Created Date: 13/02/2012 09:15:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_Choose)) = True Then
                sSQL.Append("Insert Into D91T9009(")
                sSQL.Append("UserID, HostID, Key01ID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
                sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_CipNo))) 'Key01ID, nvarchar, NULL
                sSQL.Append(")")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    Private Sub tsdActive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdActive.Click
        CheckMenuOther()
    End Sub

    Private Sub mnsLockVoucher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsLockVoucher.Click, tsmLockVoucher.Click
        Dim sSQL As String = ""
        If D99C0008.Msg(rL3("MSG000002"), rL3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then '"Bạn có muốn khóa phiếu này không?"
            If tdbg.Columns(COL_ModuleID).Text <> "02" Then
                D99C0008.MsgL3(rL3("Du_lieu_tu_module_khac_chuyen_qua") & Space(1) & rL3("Ban_khong_the_thay_doi_duoc")) 'Dữ liệu từ module khác chuyển qua. Bạn không thể thay đổi được.
                Exit Sub
            End If
            If tdbg.Columns(COL_TranMonth).Text = giTranMonth.ToString And tdbg.Columns(COL_TranYear).Text = giTranYear.ToString Then
            Else
                D99C0008.MsgL3(rL3("Du_lieu_khong_thuoc_ky_nay") & Space(1) & rL3("Ban_khong_the_thay_doi_duoc")) 'Dữ liệu không thuộc kỳ này. Bạn không thể thay đổi được.
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

   
End Class