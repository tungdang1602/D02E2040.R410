Imports System.Windows.Forms
Imports System
Imports System.Drawing
Public Class D02F2003

#Region "Const of tdbg1"
    Private Const COL1_HistoryID As Integer = 0      ' HistoryID
    Private Const COL1_AssignmentID As Integer = 1   ' Mã tiêu thức
    Private Const COL1_AssignmentName As Integer = 2 ' Tên tiêu thức
    Private Const COL1_PercentAmount As Integer = 3  ' Tỷ lệ
#End Region


#Region "Const of tdbg2 - Total of Columns: 16"
    Private Const COL2_OrderNo As Integer = 0              ' STT
    Private Const COL2_AssetID As Integer = 1              ' Mã tài sản
    Private Const COL2_AssetName As Integer = 2            ' Tên tài sản
    Private Const COL2_D27PropertyProductID As Integer = 3 ' Mã BĐS
    Private Const COL2_BatchID As Integer = 4              ' BatchID
    Private Const COL2_AssetAccountID As Integer = 5       ' TKTS
    Private Const COL2_DepAccountID As Integer = 6         ' TKKH
    Private Const COL2_ProjectID As Integer = 7            ' Dự án
    Private Const COL2_ProjectName As Integer = 8          ' Tên dự án
    Private Const COL2_NewAAC As Integer = 9               ' TKTS mới
    Private Const COL2_NewDAC As Integer = 10              ' TKKH mới
    Private Const COL2_TranMonth As Integer = 11           ' TranMonth
    Private Const COL2_TranYear As Integer = 12            ' TranYear
    Private Const COL2_Description As Integer = 13         ' Description
    Private Const COL2_AssetConditionID As Integer = 14    ' AssetConditionID
    Private Const COL2_AssetConditionName As Integer = 15  ' AssetConditionName
#End Region


#Region "Const of tdbg3 - Total of Columns: 40"
    Private Const COL3_Choose As Integer = 0            ' Choose
    Private Const COL3_TransactionID As Integer = 1     ' TransactionID
    Private Const COL3_IsLockAccount As Integer = 2     ' IsLockAccount
    Private Const COL3_IsLockAmount As Integer = 3      ' IsLockAmount
    Private Const COL3_TransactionTypeID As Integer = 4 ' TransactionTypeID
    Private Const COL3_ModuleID As Integer = 5          ' ModuleID
    Private Const COL3_IsNotAllocate As Integer = 6     ' Không KH
    Private Const COL3_SeriNo As Integer = 7            ' Số sêri
    Private Const COL3_RefNo As Integer = 8             ' Số hóa đơn
    Private Const COL3_RefDate As Integer = 9           ' Ngày hóa đơn
    Private Const COL3_Description As Integer = 10      ' Diễn giải
    Private Const COL3_ObjectTypeID As Integer = 11     ' Loại ĐT
    Private Const COL3_ObjectID As Integer = 12         ' Đối tượng
    Private Const COL3_ExchangeRate As Integer = 13     ' Tỷ giá
    Private Const COL3_DebitAccountID As Integer = 14   ' TK Nợ
    Private Const COL3_CreditAccountID As Integer = 15  ' TK Có
    Private Const COL3_OriginalAmount As Integer = 16   ' Nguyên tệ
    Private Const COL3_ConvertedAmount As Integer = 17  ' Quy đổi
    Private Const COL3_SourceID As Integer = 18         ' Nguồn vốn
    Private Const COL3_CipNo As Integer = 19            ' Mã XDCB
    Private Const COL3_CipID As Integer = 20            ' CipID
    Private Const COL3_Ana01ID As Integer = 21          ' Ana01ID
    Private Const COL3_Ana02ID As Integer = 22          ' Ana02ID
    Private Const COL3_Ana03ID As Integer = 23          ' Ana03ID
    Private Const COL3_Ana04ID As Integer = 24          ' Ana04ID
    Private Const COL3_Ana05ID As Integer = 25          ' Ana05ID
    Private Const COL3_Ana06ID As Integer = 26          ' Ana06ID
    Private Const COL3_Ana07ID As Integer = 27          ' Ana07ID
    Private Const COL3_Ana08ID As Integer = 28          ' Ana08ID
    Private Const COL3_Ana09ID As Integer = 29          ' Ana09ID
    Private Const COL3_Ana10ID As Integer = 30          ' Ana10ID
    Private Const COL3_InventoryID As Integer = 31      ' Mã hàng
    Private Const COL3_InventoryName As Integer = 32    ' Tên hàng
    Private Const COL3_UnitID As Integer = 33           ' ĐVT
    Private Const COL3_Quantity As Integer = 34         ' Số lượng
    Private Const COL3_ProjectID As Integer = 35        ' Dự án
    Private Const COL3_TaskID As Integer = 36           ' Hạng mục
    Private Const COL3_PeriodID As Integer = 37         ' Tập phí
    Private Const COL3_ProjectName As Integer = 38      ' ProjectName
    Private Const COL3_TaskName As Integer = 39         ' TaskName
#End Region

    Private bFirstCheck As Boolean = False
    Private _FormState As EnumFormState
    Dim clsFilterCombo As Lemon3.Controls.FilterCombo
    Dim clsFilterDropdown As Lemon3.Controls.FilterDropdown

    Dim dtGrid2, dtAnaCaption As DataTable

    Public Property FormState() As EnumFormState
        
        Get
            Return _FormState
        End Get
        Set(ByVal value As EnumFormState)
            _FormState = value
           
            CreateData()
            CreateData_M()
            'Chuẩn load Combo khi Sửa b2: Chuyển vị trí load Combo hay Dropdown xuống từng _FormState

            '--- Chuẩn Khoản mục b2: Lấy caption cho 10 khoản mục va quy cach
            bUseAna = LoadTDBGridAnalysisCaption(D02, tdbg3, COL3_Ana01ID, 1, True, gbUnicode, dtAnaCaption)
            'Neu k su dung KM thi Remove Split cuoi  cung di 
            If bUseAna = False Then tdbg3.RemoveHorizontalSplit(1)
            clsFilterCombo = New Lemon3.Controls.FilterCombo
            clsFilterCombo.CheckD91 = True 'Giá trị mặc định True: kiểm tra theo DxxFormat.LoadFormNotINV. Ngược lại luôn luôn Filter dạng mới (dùng cho Novaland)
            clsFilterCombo.AddPairObject(tdbcObjectTypeID, tdbcObjectID)
            clsFilterCombo.AddPairObject(tdbcManagementObjID, tdbcManagementObjTypeID)
            clsFilterCombo.UseFilterComboObjectID()
            clsFilterCombo.UseFilterCombo(tdbcAssetID, tdbcChangeNo, tdbcSuggestorID, tdbcEffectReasonID, tdbcEmployeeID, tdbcLocationID)

            ' Dim dic As New Dictionary(Of String, String)
            ' dic.Add(tdbdBudgetID.Name, "Note")'Ví dụ Cần lấy cột Note trong tdbdBudgetID. Nếu lấy Name, hoặc Description hoặc cột 1 thì không cần truyền
            clsFilterDropdown = New Lemon3.Controls.FilterDropdown()
            'clsFilterDropdown.SingleLine = True'Mặc đinh False. Chọn nhiều dòng gắn lại dữ liệu cho 1 dòng và cách nhau bằng ; (sử dụng Tài khoản D90F1110)
            clsFilterDropdown.CheckD91 = True 'Giá trị mặc định True: kiểm tra theo DxxFormat.LoadFormNotINV. Ngược lại luôn luôn Filter dạng mới (dùng cho Novaland)
            ' clsFilterDropdown.DicDDName = dic
            clsFilterDropdown.UseFilterDropdown(tdbg1, COL1_AssignmentID)
            clsFilterDropdown.UseFilterDropdown(tdbg3, COL3_ObjectID, COL3_CipNo, COL3_Ana01ID, COL3_Ana02ID, COL3_Ana03ID, COL3_Ana04ID, COL3_Ana05ID, COL3_Ana06ID, COL3_Ana07ID, COL3_Ana08ID, COL3_Ana09ID, COL3_Ana10ID, COL3_DebitAccountID, COL3_CreditAccountID, COL3_InventoryID) 'Nếu dùng nhiều lưới
            'ID-143165 filterbar choCOL3_DebitAccountID, COL3_CreditAccountID

            LoadTDBDropDown()
            Loadlanguage()
            tdbcAssetAccountID.Tag = ""
            tdbcDepAccountID.Tag = ""
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBCombo()
                    LoadAddNew()
                    btnAttachment.Enabled = False
                    btnSave.Enabled = True
                    btnNext.Enabled = False
                    btnPrint.Enabled = False
                Case EnumFormState.FormEdit
                    LoadEdit()
                    btnSave.Enabled = True
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    chkCollect.Enabled = False
                Case EnumFormState.FormView
                    LoadEdit()
                    btnSave.Enabled = False
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    chkCollect.Enabled = False
                Case EnumFormState.FormEditOther
                    LoadEdit()
                    LockControlEditOther()
                    btnAttachment.Enabled = False
                    btnSave.Enabled = True
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    chkCollect.Enabled = False
            End Select
        End Set
    End Property


    Private _batchID As String = ""
    Public Property BatchID() As String 
        Get
            Return _batchID
        End Get
        Set(ByVal Value As String )
            _batchID = Value
        End Set
    End Property

    Private _groupID As String = ""
    Public Property GroupID() As String
        Get
            Return _groupID
        End Get
        Set(ByVal Value As String)
            _groupID = Value
        End Set
    End Property

    Private _assetID As String = ""
    Public Property AssetID() As String 
        Get
            Return _assetID
        End Get
        Set(ByVal Value As String )
            _assetID = Value
        End Set
    End Property

    Private _changeNo As String
    Public WriteOnly Property  ChangeNo() As String
        Set(ByVal Value As String)
            _changeNo = Value
        End Set
    End Property

    Dim sOldVoucherNo As String = "" 'Lưu lại số phiếu cũ
    Dim bEditVoucherNo As Boolean = False '= True: có nhấn F2; = False: không 
    Dim bFirstF2 As Boolean = False 'Nhấn F2 lần đầu tiên 
    Dim iPer_F5558 As Integer = ReturnPermission("D02F5558") 'Phân quyền cho Sửa số phiếu
    Dim bUseAna As Boolean
    Dim iLastCol As Integer

    Dim sEditAssetID As String = ""
    Dim sEditChangeNo As String = ""

    Private dtObjectID, dtAssetID, dtRecordSet_Asset, dtExchangeRate, dtManagementObjID As DataTable
    Private dtGrid3 As DataTable

    Private Sub D02F2003_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '12/10/2020, id 144622-Tài sản cố định_Lỗi chưa cảnh báo khi lưu
        If _FormState = EnumFormState.FormEdit Then
            If Not gbSavedOK Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If (tdbcAssetID.Text <> "" Or tdbcChangeNo.Text <> "" Or txtNotes1.Text <> "" Or txtNotes2.Text <> "" Or txtNotes.Text <> "" Or c1dateChangeDate.Text <> "" Or txtDecisionNo.Text <> "") Then
                If Not gbSavedOK Then
                    If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub D02F2003_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If

        If e.Control And e.KeyCode = Keys.F1 Then
            btnHotKeys_Click(Nothing, Nothing)
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 Then
            If btnView.Enabled Then btnView_Click(Nothing, Nothing)
            Exit Sub
        End If
    End Sub

    Private Sub D02F2003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '21/7/2018, 	Lê Thị Thu Thảo: id 109329-Lỗi "thay đổi tài sản khấu hao không sáng để check" khi thực hiện nghiệp vụ tác động TSCĐ (ẩn 2 checkbox: Thay đổi tài khoản tài sản, Thay đổi tài khoản khấu hao)

        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
        InputDateInTrueDBGrid(tdbg3, COL3_RefDate)
        ResetFooterGrid(tdbg1)
        LoadDefault()

        ResetColorGrid(tdbg2)
        ResetSplitDividerSize(tdbg3)
        tdbg_NumberFormat()
        tdbg_LockedColumns()
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        'tdbg2.Splits(0).DisplayColumns(COL2_NewAAC).Visible = chkIsChangeAssetAccount.Checked
        'tdbg2.Splits(0).DisplayColumns(COL2_NewDAC).Visible = chkIsChangeDepAccount.Checked

        'ID 86630 25.05.2016
        tdbg3.Splits(0).DisplayColumns(COL3_IsNotAllocate).Visible = CheckUseProperty()

        '***********************
        iLastCol = CountCol(tdbg3, tdbg3.Splits.Count - 1)
        '***********************
        tdbg2.Splits(0).DisplayColumns(COL2_D27PropertyProductID).Visible = D02Systems.CIPforPropertyProduct
        SetResolutionForm(Me)


    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_AssignmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadDynamicCaption()
        Dim sSQL As String = SQLStoreD02P2008()
        Dim dtCaption As DataTable = ReturnDataTable(sSQL)
        Dim i, j As Integer
        If dtCaption.Rows.Count > 0 Then
            For i = 0 To dtCaption.Rows.Count - 1
                For j = 1 To 5
                    Dim lblStr As System.Windows.Forms.Label = CType(Tab3.Controls("lblStr" & j.ToString("00")), System.Windows.Forms.Label)
                    Dim lblDate As System.Windows.Forms.Label = CType(Tab3.Controls("lblDate" & j.ToString("00")), System.Windows.Forms.Label)
                    Dim txtStr As System.Windows.Forms.TextBox = CType(Tab3.Controls("txtStr" & j.ToString("00")), System.Windows.Forms.TextBox)
                    Dim c1date As C1.Win.C1Input.C1DateEdit = CType(Tab3.Controls("c1dateDate" & j.ToString("00")), C1.Win.C1Input.C1DateEdit)
                    If lblStr.Name.Contains(dtCaption.Rows(i).Item("RefID").ToString) Then
                        lblStr.Text = dtCaption.Rows(i).Item("Caption").ToString
                        txtStr.Enabled = L3Bool(dtCaption.Rows(i).Item("IsUse").ToString)
                    End If
                    If lblDate.Name.Contains(dtCaption.Rows(i).Item("RefID").ToString) Then
                        lblDate.Text = dtCaption.Rows(i).Item("Caption").ToString
                        c1date.Enabled = L3Bool(dtCaption.Rows(i).Item("IsUse").ToString)
                    End If
                Next
                
            Next
        Else
            For j = 1 To 5 
                Dim txtStr As System.Windows.Forms.TextBox = CType(Tab3.Controls("txtStr" & j.ToString("00")), System.Windows.Forms.TextBox)
                Dim c1date As C1.Win.C1Input.C1DateEdit = CType(Tab3.Controls("c1dateDate" & j.ToString("00")), C1.Win.C1Input.C1DateEdit)
                lblStr01.Text = rL3("Chuoi_thu") & " 1" 'Chuỗi thứ 1
                lblStr02.Text = rL3("Chuoi_thu") & " 2" 'Chuỗi thứ 2
                lblStr03.Text = rL3("Chuoi_thu") & " 3" 'Chuỗi thứ 3
                lblStr04.Text = rL3("Chuoi_thu") & " 4" 'Chuỗi thứ 4
                lblStr05.Text = rL3("Chuoi_thu") & " 5" 'Chuỗi thứ 5
                lblDate05.Text = rL3("Ngay_thuU") & " 5" 'Ngày thứ 5
                lblDate04.Text = rL3("Ngay_thuU") & " 4" 'Ngày thứ 4
                lblDate03.Text = rL3("Ngay_thuU") & " 3" 'Ngày thứ 3
                lblDate01.Text = rL3("Ngay_thuU") & " 1" 'Ngày thứ 1
                lblDate02.Text = rL3("Ngay_thuU") & " 2" 'Ngày thứ 2
                txtStr.Enabled = False
                c1date.Enabled = False
            Next
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2008
    '# Created User: HUỲNH KHANH
    '# Created Date: 18/10/2014 02:55:03
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2008() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Đổ nguồn caption động" & vbCrlf)
        sSQL &= "Exec D02P2008 "
        sSQL &= SQLString(tdbcChangeNo.Columns("ChangeNo").Value.ToString) & COMMA 'ChangeNo, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function



    Private Sub LockControlEditOther()
        ' Master
        tdbcAssetID.Enabled = False
        tdbcChangeNo.Enabled = False
        btnView.Enabled = False
        chkUseAccount.Enabled = False
        'Tab Phi tài chính
        For Each ctrl As Control In Tab1.Controls
            ctrl.Enabled = False
        Next
        'Tab Tài chình
        tdbcVoucherTypeID.Enabled = False
        txtVoucherNo.Enabled = False
        tdbcCurrencyID.Enabled = False
        chkCollect.Enabled = False
        btnCollect.Enabled = False
        btnInherit.Enabled = False
        tdbg2.AllowUpdate = False
        tdbg3.AllowUpdate = False
        tdbg2.AllowDelete = False
        tdbg3.AllowDelete = False

    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_nghiep_vu_tac_dong_tai_san_-_D02F2003") & UnicodeCaption(gbUnicode) 'CËp nhËt nghiÖp vó tÀc ¢èng tªi s¶n - D02F2003
        '================================================================ 
        lblteChangeDate.Text = rl3("Ngay_tac_dong") 'Ngày tác động
        lblDecisionNo.Text = rl3("So_hieu") 'Số hiệu
        lblNotes1.Text = rl3("Ghi_chu") & " 1" 'Ghi chú
        lblNotes2.Text = rl3("Ghi_chu") & " 2" 'Ghi chú
        lblNotes3.Text = rl3("Ghi_chu") & " 3" 'Ghi chú
        lblEmployeeID.Text = rl3("Nguoi_tiep_nhan") 'Người tiếp nhận
        lblSuggestorID.Text = rL3("Nguoi_yeu_cau") 'Người yêu cầu
        'lblObjectTypeID.Text = rL3("Bo_phan_quan_ly") 'Bộ phận quản lý
        lblObjectTypeID.Text = rL3("Bo_phan_tiep_nhan") 'Bộ phận tiếp nhận
        lblServiceLife.Text = rl3("So_ky_khau_hao") 'Số kỳ khấu hao
        lblAssetWHID.Text = rl3("Kho") 'Kho
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblCurrencyID.Text = rl3("Loai_tien") 'Loại tiền
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblteVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblAssetID.Text = rl3("Ma_tai_san") 'Mã tài sản
        lblChangeNo.Text = rL3("Nghiep_vu") 'Nghiệp vụ
        lblLocationID.Text = rL3("Vi_tri") 'Vị trí
        lblStr01.Text = rL3("Chuoi_thu") & " 1" 'Chuỗi thứ 1
        lblStr02.Text = rL3("Chuoi_thu") & " 2" 'Chuỗi thứ 2
        lblStr03.Text = rL3("Chuoi_thu") & " 3" 'Chuỗi thứ 3
        lblStr04.Text = rL3("Chuoi_thu") & " 4" 'Chuỗi thứ 4
        lblStr05.Text = rL3("Chuoi_thu") & " 5" 'Chuỗi thứ 5
        lblDate05.Text = rL3("Ngay_thuU") & " 5" 'Ngày thứ 5
        lblDate04.Text = rL3("Ngay_thuU") & " 4" 'Ngày thứ 4
        lblDate03.Text = rL3("Ngay_thuU") & " 3" 'Ngày thứ 3
        lblDate01.Text = rL3("Ngay_thuU") & " 1" 'Ngày thứ 1
        lblDate02.Text = rL3("Ngay_thuU") & " 2" 'Ngày thứ 2
        'lblManagementObjTypeID.Text = rL3("Don_vi_quan_ly") 'Đơn vị quản lý
        '================================================================ 
        btnView.Text = rl3("Xem") & " (F3)" 'Xem
        btnDepreciation.Text = rl3("_Giam_thoi_gian_khau_hao") '&Giảm thời gian khấu hao
        btnInherit.Text = rl3("_Ke_thua") '&Kế thừa
        btnCollect.Text = rl3("_Tap_hop") '&Tập hợp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        btnHotKeys.Text = rl3("Phim_nong") 'Phím nóng
        btnPrint.Text = rL3("_In") '&In

        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormView Or _FormState = EnumFormState.FormEditOther Then
            btnAttachment.Text = rL3("Dinh_ke_m") & Space(1) & " (" & ReturnAttachmentNumber("D02T0202", _groupID) & ")"  'Đính kèm
        Else
            btnAttachment.Text = rL3("Dinh_ke_m")
        End If
        '================================================================ 
        chkUseAccount.Text = rl3("Kem_theo_tac_dong_tai_chinh") 'Kèm theo tác động tài chính
        chkReceiveManage.Text = rL3("Thay_doi_bo_phan_tiep_nhan") 'Thay đổi bộ phận tiếp nhận
        chkChangeDistribute.Text = rl3("Thay_doi_tieu_thuc_phan_bo") 'Thay đổi tiêu thức phân bổ
        chkChangeDepreciation.Text = rl3("Thay_doi_tinh_trang_khau_hao") 'Thay đổi tình trạng khấu hao
        chkIsEliminated.Text = rl3("Giam_tai_san") 'Giảm tài sản
        chkChangeDepreciationTime.Text = rl3("Thay_doi_thoi_gian_khau_hao") 'Thay đổi thời gian khấu hao
        chkChangeUsing.Text = rL3("Thay_doi_tinh_trang_su_dung") 'Thay đổi tình trạng sử dụng
        chkIsChangeAssetAccount.Text = rL3("Thay_doi_tai_khoan_tai_san") 'Thay đổi tài khoản tài sản
        chkIsChangeDepAccount.Text = rL3("Thay_doi_tai_khoan_khau_hao") 'Thay đổi tài khoản khấu hao
        chkIsNotCalDep.Text = rL3("Khong_tinh_khau_hao_theo_bo_dinh_muc") 'Không tính khấu hao theo bộ định mức
        '================================================================ 
        optReDepreciation.Text = rl3("Tai_khau_hao") 'Tái khấu hao
        optStopDepreciation.Text = rl3("Ngung_khau_hao") 'Ngưng khấu hao
        optReUse.Text = rl3("Tai_su_dung") 'Tái sử dụng
        optStopUse.Text = rl3("Ngung_su_dung") 'Ngưng sử dụng
        '================================================================ 
        Tab1.Text = "1. " & rl3("Phi_tai_chinh") 'Phi tài chính
        Tab2.Text = "2. " & rL3("Tai_chinh") 'Tài chính
        Tab3.Text = "3. " & rL3("Thong_tin_bo_sung")
        '================================================================ 
        tdbcLocationID.Columns("LocationID").Caption = rL3("Ma") 'Mã
        tdbcLocationID.Columns("LocationName").Caption = rL3("Ten") 'Tên
        tdbcObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbcObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên
        tdbcSuggestorID.Columns("SuggestorID").Caption = rL3("Ma") 'Mã
        tdbcSuggestorID.Columns("SuggestorName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbcObjectID.Columns("ObjectTypeID").Caption = rL3("Loai_DT") 'Loại ĐT
        tdbcObjectID.Columns("ObjectID").Caption = rL3("Ma") 'Mã
        tdbcObjectID.Columns("ObjectName").Caption = rL3("Ten") 'Tên

        tdbcWareHouseID.Columns("WareHouseID").Caption = rl3("Ma") 'Mã
        tdbcWareHouseID.Columns("WareHouseName").Caption = rl3("Ten") 'Tên
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Ten") 'Tên
        tdbcCurrencyID.Columns("CurrencyID").Caption = rl3("Ma") 'Mã
        tdbcCurrencyID.Columns("CurrencyName").Caption = rl3("Ten") 'Tên
        tdbcAssetID.Columns("AssetID").Caption = rl3("Ma") 'Mã
        tdbcAssetID.Columns("AssetName").Caption = rl3("Ten") 'Tên
        tdbcChangeNo.Columns("ChangeNo").Caption = rl3("Ma") 'Mã
        tdbcChangeNo.Columns("ChangeName").Caption = rL3("Ten") 'Tên
        tdbcManagementObjID.Columns("ObjectID").Caption = rL3("Ma") 'Mã
        tdbcManagementObjID.Columns("ObjectName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbcEffectReasonID.Columns(0).Caption = rl3("Ma") 'Mã 
        tdbcEffectReasonID.Columns(1).Caption = rl3("Ten") 'Tên
        lblEffectReasonID.Text = rl3("Ly_do_tac_dong")
        tdbdAssignmentID.Columns("AssignmentID").Caption = rl3("Ma") 'Mã 
        tdbdAssignmentID.Columns("AssignmentName").Caption = rl3("Ten") 'Tên
        tdbdAssignmentID.Columns("DebitAccountID").Caption = rl3("Tai_khoan_no") 'Tài khoản nợ
        tdbdCipID.Columns("CipNo").Caption = rl3("Ma") 'Mã
        tdbdCipID.Columns("CipName").Caption = rl3("Ten") 'Tên
        tdbdSourceID.Columns("SourceID").Caption = rl3("Ma") 'Mã
        tdbdSourceID.Columns("SourceName").Caption = rl3("Ten") 'Tên 
        tdbdCreditAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbdCreditAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbdDebitAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbdDebitAccountID.Columns("AccountName").Caption = rL3("Ten") 'Tên
        tdbdObjectID.Columns("ObjectTypeID").Caption = rL3("Loai_DT") 'Mã
        tdbdObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbdObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbdObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbdObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Ten") 'Tên
        tdbdAna05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna04ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna04ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna03ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna03ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna02ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna02ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna09ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna09ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna06ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna06ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna10ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna10ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna08ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna08ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna07ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna07ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna01ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna01ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdPeriodID.Columns("PeriodID").Caption = rL3("Ma") 'Mã
        tdbdPeriodID.Columns("Note").Caption = rL3("Dien_giai") 'Diễn giải
        tdbdTaskID.Columns("TaskID").Caption = rL3("Ma") 'Mã
        tdbdTaskID.Columns("TaskName").Caption = rL3("Ten") 'Tên
        tdbdProjectID.Columns("ProjectID").Caption = rL3("Ma") 'Mã
        tdbdProjectID.Columns("ProjectName").Caption = rL3("Ten")
        '================================================================ 
        tdbg1.Columns("AssignmentID").Caption = rl3("Ma_tieu_thuc") 'Mã tiêu thức
        tdbg1.Columns("AssignmentName").Caption = rl3("Ten_tieu_thuc") 'Tên tiêu thức
        tdbg1.Columns("PercentAmount").Caption = rl3("Ty_le") 'Tỷ lệ
        '================================================================ 
        tdbg2.Columns(COL2_OrderNo).Caption = rL3("STT") 'STT
        tdbg2.Columns(COL2_AssetID).Caption = rL3("Ma_tai_san") 'Mã tài sản
        tdbg2.Columns(COL2_AssetName).Caption = rL3("Ten_tai_san") 'Tên tài sản
        tdbg2.Columns(COL2_D27PropertyProductID).Caption = rL3("Ma_BDS") 'Mã BĐS
        tdbg2.Columns(COL2_AssetAccountID).Caption = rL3("TKTS") 'TKTS
        tdbg2.Columns(COL2_DepAccountID).Caption = rL3("TKKH") 'TKKH
        tdbg2.Columns(COL2_ProjectID).Caption = rL3("Cong_trinh") 'Dự án
        tdbg2.Columns(COL2_ProjectName).Caption = rL3("Ten_cong_trinh") 'Tên dự án
        tdbg2.Columns(COL2_NewAAC).Caption = rL3("TKTS_moi") 'TKTS mới
        tdbg2.Columns(COL2_NewDAC).Caption = rL3("TKKH_moi") 'TKKH mới

        tdbg3.Columns("SeriNo").Caption = rl3("So_Seri") 'Số sêri
        tdbg3.Columns("RefNo").Caption = rl3("So_hoa_don") 'Số hóa đơn
        tdbg3.Columns("RefDate").Caption = rl3("Ngay_hoa_don") 'Ngày hóa đơn
        tdbg3.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg3.Columns("ObjectTypeID").Caption = rl3("Loai_DT") 'Loại ĐT
        tdbg3.Columns("ObjectID").Caption = rl3("Doi_tuong") 'Đối tượng
        tdbg3.Columns("ExchangeRate").Caption = rl3("Ty_gia") 'Tỷ giá
        tdbg3.Columns("DebitAccountID").Caption = rl3("TK_no") 'TK Nợ
        tdbg3.Columns("CreditAccountID").Caption = rl3("TK_co") 'TK Có
        tdbg3.Columns("OriginalAmount").Caption = rl3("Nguyen_te") 'Nguyên tệ
        tdbg3.Columns("ConvertedAmount").Caption = rl3("Quy_doi") 'Quy đổi
        tdbg3.Columns("SourceID").Caption = rl3("Nguon_von") 'Nguồn vốn
        tdbg3.Columns("CipNo").Caption = rl3("Ma_XDCB") 'Mã XDCB
        'Them ngay 3/12/2012 theo incident 52673 cua Bảo Trân bởi Văn Vinh
        tdbg3.Columns("InventoryID").Caption = rl3("Ma_hang") 'Mã hàng
        tdbg3.Columns("InventoryName").Caption = rl3("Ten_hang_") 'Tên hàng
        tdbg3.Columns("UnitID").Caption = rl3("DVT") 'ĐVT
        tdbg3.Columns("Quantity").Caption = rL3("So_luong") 'Số lượng

        tdbg3.Columns("IsNotAllocate").Caption = rL3("Khong_KH") 'Không KH
        tdbg3.Columns("PeriodID").Caption = rL3("Tap_phi") 'Tập phí
        '================================================================ 
        lblAssetAccountID.Text = rL3("TK_tai_san") 'TK tài sản
        lblDepAccountID.Text = rL3("TK_khau_hao") 'TK khấu hao
        '================================================================ 
        tdbcAssetAccountID.Columns("AccountID").Caption = rL3("Ma") 'Mã
        tdbcAssetAccountID.Columns("AccountName").Caption = rL3("Ten") 'Tên
        tdbcDepAccountID.Columns("AccountID").Caption = rL3("Ma") 'Mã
        tdbcDepAccountID.Columns("AccountName").Caption = rL3("Ten") 'Tên
        'ID : 214915 - Đổi caption Đơn vị quản lý => Bộ phận quản lý
        '================================================================ 
        lblManagementObjTypeID.Text = rL3("Bo_phan_quan_ly") 'Bộ phận quản lý


    End Sub

    Private Sub tdbg_NumberFormat()
        'tdbg1.Columns(COL1_PercentAmount).NumberFormat = DxxFormat.DefaultNumber2
        'tdbg3.Columns(COL3_ExchangeRate).NumberFormat = DxxFormat.ExchangeRateDecimals
        'tdbg3.Columns(COL3_OriginalAmount).NumberFormat = DxxFormat.DecimalPlaces
        'tdbg3.Columns(COL3_ConvertedAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
        'tdbg3.Columns(COL3_Quantity).NumberFormat = DxxFormat.D08_QuantityDecimals
        tdbg1_NumberFormat()
        tdbg3_NumberFormat()
    End Sub

    Private Sub tdbg1_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg1.Columns(COL1_PercentAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg1, arr)
    End Sub


    Private Sub tdbg3_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg3.Columns(COL3_ExchangeRate).DataField, DxxFormat.ExchangeRateDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg3.Columns(COL3_OriginalAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg3.Columns(COL3_ConvertedAmount).DataField, DxxFormat.D90_ConvertedDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg3.Columns(COL3_Quantity).DataField, DxxFormat.D08_QuantityDecimals, 28, 8)
        InputNumber(tdbg3, arr)
    End Sub



    Private Sub LoadDefault()
        tdbg3.Columns(COL3_RefDate).Editor = c1dateDate
        '*************************
        tdbg3.Columns(COL3_Ana01ID).DropDown = tdbdAna01ID
        tdbg3.Columns(COL3_Ana02ID).DropDown = tdbdAna02ID
        tdbg3.Columns(COL3_Ana03ID).DropDown = tdbdAna03ID
        tdbg3.Columns(COL3_Ana04ID).DropDown = tdbdAna04ID
        tdbg3.Columns(COL3_Ana05ID).DropDown = tdbdAna05ID
        tdbg3.Columns(COL3_Ana06ID).DropDown = tdbdAna06ID
        tdbg3.Columns(COL3_Ana07ID).DropDown = tdbdAna07ID
        tdbg3.Columns(COL3_Ana08ID).DropDown = tdbdAna08ID
        tdbg3.Columns(COL3_Ana09ID).DropDown = tdbdAna09ID
        tdbg3.Columns(COL3_Ana10ID).DropDown = tdbdAna10ID
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcAssetID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcChangeNo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub CreateData()
        Dim sSQL As String = ""
        sSQL = "Select     ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " As ObjectName, ObjectTypeID " & vbCrLf
        sSQL &= "From       Object WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where      Disabled = 0 " & vbCrLf
        sSQL &= "Order By   ObjectID " & vbCrLf
        dtObjectID = ReturnDataTable(sSQL.ToString)
    End Sub

    Private Sub CreateData_M()
        Dim sSQL As String = ""
        sSQL = "Select     ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " As ObjectName, ObjectTypeID " & vbCrLf
        sSQL &= "From       Object WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where      Disabled = 0 " & vbCrLf
        sSQL &= "Order By   ObjectID " & vbCrLf
        dtManagementObjID = ReturnDataTable(sSQL.ToString)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcAssetID
        'If gbUnicode Then
        '    sSQL = "SELECT     '...' as AssetID, N" & SQLString(rL3("Chon_nhieu_tai_san")) & " as AssetName,'%' As AssetAccountID, '%' As DepAccountID, '' As NewAAC, '' As NewDAC, 0 as TranMonth, 0 As TranYear, '0' as AssignmentTypeID, 0 As DisplayOrder, '' as D27PropertyProductID,'' As ProjectID,'' As ProjectName " & vbCrLf
        'Else
        '    sSQL = "SELECT     '...' as AssetID, " & SQLString(ConvertUnicodeToVni(rL3("Chon_nhieu_tai_san"))) & " as AssetName,'%' As AssetAccountID, '%' As DepAccountID, '' As NewAAC, '' As NewDAC, 0 as TranMonth, 0 As TranYear, '0' as AssignmentTypeID, 0 As DisplayOrder, '' as D27PropertyProductID,'' As ProjectID,'' As ProjectName " & vbCrLf
        'End If
        'sSQL &= "UNION ALL " & vbCrLf
        'sSQL &= "SELECT 	Distinct N19.AssetID,  N19.AssetName" & UnicodeJoin(gbUnicode) & " As AssetName,N19.AssetAccountID, N19.DepAccountID,'' As NewAAC, '' As NewDAC,N19.TranMonth, N19.TranYear, T01.AssignmentTypeID, 1 As DisplayOrder, T01.D27PropertyProductID, T01.D54ProjectID As ProjectID, T02.Description As ProjectName" & vbCrLf
        'sSQL &= "FROM       D02N0019(" & giTranMonth & ", " & giTranYear & ") as N19 Left join D02T0001  as T01 WITH(NOLOCK) on T01.AssetID = N19.AssetID  left join D54T2010 as t02  with(nolock) on T02.ProjectID = T01.D54ProjectID" & vbCrLf
        'sSQL &= "WHERE 		N19.IsCompleted = 1 AND N19.Disabled = 0 " & vbCrLf
        'sSQL &= "           AND N19.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        'sSQL &= "           AND N19.TranMonth + N19.TranYear * 100 <= " & giTranMonth & " + " & giTranYear & " *100" & vbCrLf
        'sSQL &= "           AND (N19.IsLiquidated = 0 )" & vbCrLf
        'If sEditAssetID <> "" Then
        '    sSQL &= " Or N19.AssetID =  " & SQLString(sEditAssetID) & vbCrLf
        'End If
        'sSQL &= "ORDER BY   DisplayOrder, AssetID" & vbCrLf

        sSQL = SQLStoreD02P5002("", 1)
        dtAssetID = ReturnDataTable(sSQL)
        LoadDataSource(tdbcAssetID, dtAssetID, gbUnicode)

        'Load tdbcChangeNo
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        ''sSQL = "SELECT     DISTINCT A.ChangeNo, A.ChangeName" & UnicodeJoin(gbUnicode) & " As ChangeName, " & vbCrLf
        ''sSQL &= "           A.Notes1" & UnicodeJoin(gbUnicode) & " As Notes1, A.Notes2" & UnicodeJoin(gbUnicode) & " As Notes2, A.Notes3" & UnicodeJoin(gbUnicode) & " As Notes3, A.IsEliminated," & vbCrLf
        ''sSQL &= "           A.UseAccount, b.VoucherTypeID , b.VoucherDesc, b.CurrencyID, A.IsEliminated  " & vbCrLf
        ''sSQL &= "FROM       D02T0201 A WITH(NOLOCK) " & vbCrLf
        ''sSQL &= "LEFT JOIN  ( SELECT DISTINCT ChangeNo, VoucherTypeID, VoucherDesc" & UnicodeJoin(gbUnicode) & " as VoucherDesc, CurrencyID FROM D02T0204 WITH(NOLOCK)) B " & vbCrLf
        ''sSQL &= "ON         A.ChangeNo = B.ChangeNo " & vbCrLf
        ''sSQL &= "WHERE 		A.Disabled = 0" & vbCrLf
        ''If sEditChangeNo <> "" Then
        ''    sSQL &= " Or A.ChangeNo =  " & SQLString(sEditChangeNo)
        ''End If
        ''LoadDataSource(tdbcChangeNo, sSQL, gbUnicode)
        LoadTDBCChangeNo()

        'Load tdbcWareHouseID
        sSQL = "SELECT     WareHouseID, RTrim(LTrim(WareHouseName" & UnicodeJoin(gbUnicode) & ")) As WareHouseName " & vbCrLf
        sSQL &= "FROM       D07T0007 WITH(NOLOCK)" & vbCrLf
        sSQL &= "WHERE      DivisionID = " & SQLString(gsDivisionID) & " And Disabled = 0" & vbCrLf
        sSQL &= "           And ( DAGroupID = '' Or " & vbCrLf
        sSQL &= "           DAGroupID In (Select DAGroupID From LemonSys.Dbo.D00V0080" & vbCrLf
        sSQL &= "                           Where UserID = 'LEMONADMIN' " & vbCrLf
        sSQL &= "           Or " & SQLString(gsUserID) & " = 'LEMONADMIN'))" & vbCrLf
        sSQL &= "ORDER BY   WareHouseID" & vbCrLf
        LoadDataSource(tdbcWareHouseID, sSQL, gbUnicode)

        'Load tdbcObjectTypeID
        LoadObjectTypeID(tdbcObjectTypeID, gbUnicode)

        'Load tdbcObjectID    
        LoadtdbcObjectID("-1")

        'Load tdbcManagementObjTypeID
        LoadObjectTypeID(tdbcManagementObjTypeID, gbUnicode) ' ID : 214915
        LoadtdbcManagementObjID("-1")

        'Load tdbcEmployeeID
        sSQL.Remove(0, sSQL.Length)
        sSQL = "Select     ObjectID As EmployeeID, ObjectName" & UnicodeJoin(gbUnicode) & " As EmployeeName" & vbCrLf
        sSQL &= "From       Object WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where      ObjectTypeID = 'NV' " & vbCrLf
        sSQL &= "Order By   ObjectID " & vbCrLf
        LoadDataSource(tdbcEmployeeID, sSQL, gbUnicode)

        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D02, , gbUnicode)

        'Load tdbcCurrencyID
        LoadCurrencyID(tdbcCurrencyID, gbUnicode) ''


        sSQL = "SELECT		LookupID as EffectReasonID, Description" & UnicodeJoin(gbUnicode) & " as Description, DisplayOrder " & vbCrLf
        sSQL &= "FROM		D91T0320 WITH(NOLOCK)" & vbCrLf
        sSQL &= "WHERE		LookupType= 'D02_EffectReason' and Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY 	DisplayOrder,LookupID"
        LoadDataSource(tdbcEffectReasonID, sSQL, gbUnicode) ''

        'Load Location
        sSQL = "-- Combo Vi tri " & vbCrLf
        sSQL &= " SELECT		 LookupID As LocationID, Description" & UnicodeJoin(gbUnicode) & " As LocationName"
        sSQL &= " FROM 		D91T0320 WITH(NOLOCK) "
        sSQL &= " WHERE 		LookupType = 'D02_Position' "
        sSQL &= " And (DAGroupID =  ''  Or DAGroupID "
        sSQL &= " IN (Select DAGroupID From lemonsys.dbo.D00V0080 Where UserID= " & SQLString(gsUserID) & " ) Or 'LEMONADMIN' = 'LEMONADMIN')"
        sSQL &= " Order By		 LookupID"
        LoadDataSource(tdbcLocationID, sSQL, gbUnicode)

        sSQL = "-- Combo doi tuong nguoi yeu cau" & vbCrLf
        sSQL &= " SELECT 		ObjectID AS SuggestorID, ObjectName" & UnicodeJoin(gbUnicode) & " AS SuggestorName"
        sSQL &= " FROM		Object WITH(NOLOCK)"
        sSQL &= " WHERE		ObjectTypeID = 	'NV' AND Disabled = 0"
        sSQL &= " ORDER BY	ObjectID"
        LoadDataSource(tdbcSuggestorID, sSQL, gbUnicode)

        '30/10/2019, Lê Thị Phú Hà:id 123376-Bổ sung thay đổi bộ phận quản lý (NV tác động D02)
        'Load tdbcManagementObjID
        'LoadDataSource(tdbcManagementObjID, ReturnTableFilter(dtObjectID, "ObjectTypeID = 'DV'", True), gbUnicode)

        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        LoadDataSource(tdbcAssetAccountID, dtAssetAccount, gbUnicode)
        LoadDataSource(tdbcDepAccountID, dtDepAccount, gbUnicode)
    End Sub

    Private Sub LoadTDBCChangeNo()
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        'Load tdbcChangeNo
        LoadDataSource(tdbcChangeNo, SQLStoreD02P5002(), gbUnicode)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5002
    '# Created User: 
    '# Created Date: 10/11/2021 05:04:56
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5002() As String
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        Dim sSQL As String = ""
        sSQL &= ("-- DO nguon combo Nghiep vu " & vbCrLf)
        sSQL &= "Exec D02P5002 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString("") & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'strFind, varchar[500], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(3) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(sEditChangeNo) 'ChangeNo, varchar[50], NOT NULL
        Return sSQL
    End Function


    Private Sub LoadtdbcObjectID(ByVal ID As String)
        LoadDataSource(tdbcObjectID, ReturnTableFilter(dtObjectID, " ObjectTypeID = " & SQLString(tdbcObjectTypeID.Text), True), gbUnicode)
    End Sub

    Private Sub LoadtdbdObjectID(ByVal ID As String)
        If ID = "" Then
            LoadDataSource(tdbdObjectID, dtObjectID, gbUnicode)
            tdbdObjectID.DisplayColumns("ObjectTypeID").Visible = True
        Else
            tdbdObjectID.DisplayColumns("ObjectTypeID").Visible = False
            LoadDataSource(tdbdObjectID, ReturnTableFilter(dtObjectID, " ObjectTypeID = " & SQLString(ID), True), gbUnicode)
        End If

    End Sub

    Private Sub LoadtdbcManagementObjID(ByVal ID As String)
        LoadDataSource(tdbcManagementObjID, ReturnTableFilter(dtManagementObjID, " ObjectTypeID = " & SQLString(tdbcManagementObjTypeID.Text), True), gbUnicode)
    End Sub



    Dim dtAssetAccount, dtDepAccount As DataTable
    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdAssignmentID
        sSQL = "SELECT     AssignmentID, AssignmentName" & UnicodeJoin(gbUnicode) & " As AssignmentName, DebitAccountID " & vbCrLf
        sSQL &= "FROM       D02T0002 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE      Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY   AssignmentID, AssignmentName" & vbCrLf
        LoadDataSource(tdbdAssignmentID, sSQL, gbUnicode)

        'Load tdbdObjectTypeID
        LoadObjectTypeID(tdbdObjectTypeID, gbUnicode)

        'Load tdbdObjectID
        LoadtdbdObjectID("-1")

        'Load tdbdDebitAccountID, tdbdCreditAccountID
        sSQL = "SELECT     AccountID,  AccountName" & UnicodeJoin(gbUnicode) & " As AccountName ,GroupID" & vbCrLf
        sSQL &= "FROM       D90T0001 WITH(NOLOCK)" & vbCrLf
        sSQL &= "WHERE      Disabled = 0 And AccountStatus = 0 AND OffAccount = 0" & vbCrLf
        sSQL &= "ORDER BY   AccountID" & vbCrLf
        Dim dtAccountID As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbdDebitAccountID, dtAccountID.Copy, gbUnicode)
        LoadDataSource(tdbdCreditAccountID, dtAccountID.Copy, gbUnicode)

        'Load tdbdSourceID
        sSQL = "SELECT     SourceID, SourceName" & UnicodeJoin(gbUnicode) & " As SourceName " & vbCrLf
        sSQL &= "FROM       D02T0013 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE      Disabled = 0" & vbCrLf
        LoadDataSource(tdbdSourceID, sSQL, gbUnicode)

        'Load tdbdCipID
        'sSQL = "SELECT     CipNo, CipName, CipID " & vbCrLf
        'sSQL &= "FROM       D02T0100 " & vbCrLf
        'sSQL &= "WHERE      Disabled = 0" & vbCrLf

        LoadTDBDCipNo()

        '--- Chuẩn Khoản mục b3: Load 10 khoản mục
        LoadTDBDropDownAna(tdbdAna01ID, tdbdAna02ID, tdbdAna03ID, tdbdAna04ID, tdbdAna05ID, tdbdAna06ID, tdbdAna07ID, tdbdAna08ID, tdbdAna09ID, tdbdAna10ID, tdbg3, COL3_Ana01ID, gbUnicode)
        '---Them ngay 03/12/2012 theo incident 52673 của Bảo Trân bởi Văn Vinh
        'sSQL = "SELECT 	InventoryID, InventoryName" & UnicodeJoin(gbUnicode) & " As InventoryName, UnitID FROM 	D07T0002 WITH(NOLOCK) "
        'sSQL &= " WHERE IsService = 0 AND Disabled = 0 AND InventoryTypeID  =  'CC' ORDER BY InventoryID  "
        'LoadDataSource(tdbdInventoryID, sSQL, gbUnicode)
        'ID 251211 : Cải tiến tốc độ load mã hàng
        If Not DxxFormat.IsUseCacheOfList Then
            sSQL = SQLSelectInv("")
            LoadDataSource(tdbdInventoryID, sSQL, gbUnicode)
        End If
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        'Load tdbdNewAAC
        sSQL = "Select AccountID,  " & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName", "AccountName01").ToString & UnicodeJoin(gbUnicode) & " As AccountName  From D90T0001 WITH(NOLOCK) Where GroupID='7' and OffAccount=0 and AccountStatus=0 Order by AccountID"
        dtAssetAccount = ReturnDataTable(sSQL)
        'LoadDataSource(tdbdNewAAC, dtAssetAccount, gbUnicode)
        'Load tdbdNewDAC
        sSQL = "Select AccountID,  " & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName", "AccountName01").ToString & UnicodeJoin(gbUnicode) & " As AccountName From D90T0001 WITH(NOLOCK) Where GroupID='19' and OffAccount=0 and AccountStatus=0 Order by AccountID"
        dtDepAccount = ReturnDataTable(sSQL)
        'LoadDataSource(tdbdNewDAC, dtDepAccount, gbUnicode)

        LoadProject(tdbdProjectID)
        LoadTask(tdbdTaskID)

        '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
        'Load tdbdPeriodID
        sSQL = "Select PeriodID, WorkOrderNo, NoteU As Note " & vbCrLf
        sSQL &= "From 	D08N0100 (" & SQLString(gsDivisionID) & ", " & SQLNumber(giTranMonth) & ", " & SQLNumber(giTranYear) & ",'2') " & vbCrLf
        sSQL &= "Order by 	PeriodID"
        LoadDataSource(tdbdPeriodID, sSQL, gbUnicode)
    End Sub
    Private Function SQLSelectInv(sFilterInv As String) As String
        Dim sSQL As String = ""
        Dim sSelectTop As String = " TOP 1000 "
        If sFilterInv = "" Then sSelectTop = ""
        sSQL = "Select " & sSelectTop & " InventoryID as InventoryID, InventoryName" & UnicodeJoin(gbUnicode) & " as InventoryName,  UnitID" & vbCrLf
        sSQL &= "From D07T0002 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And IsService = 0 AND InventoryTypeID  =  'CC'" & vbCrLf
        If sFilterInv <> "" Then sSQL &= " And  (InventoryID like N'%" & sFilterInv & "%'  Or InventoryNameU like N'%" & sFilterInv & "%') "
        'sSQL &= " And ( DAGroupID= " & SQLString("") & vbCrLf
        'sSQL &= " or DAGroupID in ( Select DAGroupID From LemonSys.Dbo.D00V0080 Where UserID = " & SQLString(gsUserID) & vbCrLf
        'sSQL &= ") Or " & SQLString(gsUserID) & "= 'LEMONADMIN') " & vbCrLf
        sSQL &= " Order By InventoryID"
        Return sSQL
    End Function
    Private Sub LoadTDBDCipNo()
        Dim sSQL As String = ""
        sSQL = "SELECT A.CipID, B.CipNo, B.AccountID, B.CipName" & UnicodeJoin(gbUnicode) & " As CipName, " & vbCrLf '4/6/2019, Lê Thị Phú Hà:id 120324-Lỗi font chữ màn hình nghiệp vụ tác động tài chính khi chọn mã XDCB
        sSQL &= "	SUM(CASE WHEN A.DebitAccountID = B.AccountID THEN ConvertedAmount " & vbCrLf
        sSQL &= "		WHEN A.CreditAccountID = B.AccountID THEN - ConvertedAmount " & vbCrLf
        sSQL &= "ELSE 0 END) AS SumConvertedAmo, " & vbCrLf
        sSQL &= "	SUM(CASE WHEN A.DebitAccountID = B.AccountID THEN OriginalAmount " & vbCrLf
        sSQL &= "		WHEN A.CreditAccountID = B.AccountID THEN - OriginalAmount " & vbCrLf
        sSQL &= "ELSE 0 END) AS SumOriginalAmo  " & vbCrLf
        sSQL &= "	FROM D02T0012 A WITH(NOLOCK) " & vbCrLf
        sSQL &= "	INNER JOIN D02T0100 B WITH(NOLOCK) " & vbCrLf
        sSQL &= "ON A.CipID = B.CipID " & vbCrLf
        sSQL &= "AND B.[Status] <> 2   " & vbCrLf
        sSQL &= "	WHERE B.DivisionID = " & SQLString(gsDivisionID) & vbCrLf

        ''ID 93607 05.12.2016
        ''sSQL &= "		AND ISNULL(A.SplitbatchID,'') = ''" & vbCrLf
        '20/5/2019, Trần Minh Tài:id 119819-Nghiệp vụ điều chỉnh tăng TSCĐ từ XDCB cột nguyên tệ và quy đổi đang lấy sai dữ liệu
        'sSQL &= "		AND A.Status = 0 " & vbCrLf
        sSQL &= " AND A.Status IN ( 0,1)  " & vbCrLf

        sSQL &= "		AND	A.TranMonth + A.TranYear * 100 <= " & giTranMonth + giTranYear * 100 & vbCrLf
        sSQL &= "	GROUP BY A.CipID, B.CipNo, B.AccountID, B.CipName" & UnicodeJoin(gbUnicode) & vbCrLf
        LoadDataSource(tdbdCipID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBGrid2(ByVal dt As DataTable)
        ExecuteSQL(SQLDeleteD02T0011(""))
        If dtGrid3 IsNot Nothing Then dtGrid3.Clear()

        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormEditOther Or _FormState = EnumFormState.FormView Then
            Dim dc As New DataColumn
            dc.DataType = System.Type.GetType("System.String")
            dc.Caption = "BatchID"
            dc.ColumnName = "BatchID"
            dt.Columns.Add(dc)

            Dim dc2 As New DataColumn
            dc2.DataType = System.Type.GetType("System.String")
            dc2.Caption = "OrderNo"
            dc2.ColumnName = "OrderNo"
            dt.Columns.Add(dc2)
        End If

        LoadDataSource(tdbg2, dt, gbUnicode)
        UpdateTDBGOrderNum(tdbg2, COL2_OrderNo)
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = ""
        Dim dt As DataTable
        'LoadDynamicCaption()
        'Load thong tin Master

        'Load Location
        sSQL = " -- Do nguon Location" & vbCrLf
        sSQL &= " Select LocationID"
        sSQL &= " FROM D02T0201 WITH(NOLOCK)  "
        sSQL &= " WHERE ChangeType ='OB' AND ChangeNo = " & SQLString(ReturnValueC1Combo(tdbcChangeNo))
        Dim sLocation As String = ReturnScalar(sSQL)
        tdbcLocationID.SelectedValue = sLocation

        sSQL = SQLStoreD02P5002("")
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            '***********************
            sEditAssetID = _assetID
            sEditChangeNo = dt.Rows(0).Item("ChangeNo").ToString
            LoadTDBCombo()
            '***********************

            tdbcAssetID.Text = _assetID
            tdbcAssetID.Tag = tdbcAssetID.Text
            tdbcChangeNo.SelectedValue = dt.Rows(0).Item("ChangeNo").ToString
            c1dateChangeDate.Value = SQLDateShow(dt.Rows(0).Item("ChangeDate"))
            txtNotes1.Text = dt.Rows(0).Item("Notes1").ToString
            txtNotes2.Text = dt.Rows(0).Item("Notes2").ToString
            txtNotes3.Text = dt.Rows(0).Item("Notes3").ToString
            txtDecisionNo.Text = dt.Rows(0).Item("DecisionNo").ToString
            chkUseAccount.Checked = L3Bool(dt.Rows(0).Item("UseAccount"))
            tdbcEffectReasonID.Text = dt.Rows(0).Item("EffectReasonID").ToString

            chkIsNotCalDep.Checked = L3Bool(dt.Rows(0).Item("IsNotCalDep")) '24/3/2022, Đinh Văn Khanh:id 217076-SVI_ Cập nhật PP khấu hao TSCD cho tất cả các TS có nghiệp vụ tác động

            'LoadDynamicCaption()
            txtStr01.Text = dt.Rows(0).Item("Str01").ToString
            txtStr02.Text = dt.Rows(0).Item("Str02").ToString
            txtStr03.Text = dt.Rows(0).Item("Str03").ToString
            txtStr04.Text = dt.Rows(0).Item("Str04").ToString
            txtStr05.Text = dt.Rows(0).Item("Str05").ToString

            c1dateDate01.Value = dt.Rows(0).Item("Date01").ToString
            c1dateDate02.Value = dt.Rows(0).Item("Date02").ToString
            c1dateDate03.Value = dt.Rows(0).Item("Date03").ToString
            c1dateDate04.Value = dt.Rows(0).Item("Date04").ToString
            c1dateDate05.Value = dt.Rows(0).Item("Date05").ToString
            tdbcSuggestorID.SelectedValue = dt.Rows(0).Item("SuggestorID").ToString
            If tdbcLocationID.Text = "" Then
                tdbcLocationID.SelectedValue = dt.Rows(0).Item("LocationID").ToString
            End If
        End If


        'Load tieu thuc phan bo
        sSQL = SQLStoreD02P5003("'HistoryTypeID =''AS'''")
        dt = ReturnDataTable(sSQL)
        LoadChangeDistribute(dt)

        'Load Group Thay doi bo phan quan ly
        sSQL = SQLStoreD02P5003("'HistoryTypeID =''OB'''")
        dt = ReturnDataTable(sSQL)
        LoadChangeManage(dt)
        'Load Group Thay doi bo phan tiep nhan
        'sSQL = SQLStoreD02P5003("'HistoryTypeID =''OB'''")
        'dt = ReturnDataTable(sSQL)
        'LoadChangeManagement(dt)

        'sSQL = SQLStoreD02P5003("'HistoryTypeID =''OB'''")
        'dt = ReturnDataTable(sSQL)
        'LoadChangeManagement(dt)

        'Load Group Thay đổi tình trạng khấu hao
        sSQL = SQLStoreD02P5003("'HistoryTypeID =''SD'''")
        dt = ReturnDataTable(sSQL)
        LoadChangeDepreciation(dt)

        'Load Group Thay đổi tình trạng sử dụng
        sSQL = SQLStoreD02P5003("'HistoryTypeID =''SU'''")
        dt = ReturnDataTable(sSQL)
        LoadChangeUsing(dt)

        'Load Group Thay đổi thời gian khấu hao
        sSQL = SQLStoreD02P5003("'HistoryTypeID =''SL'''")
        dt = ReturnDataTable(sSQL)
        LoadChangeDepreciationTime(dt)

        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        'Load Thay đổi tài khoản tài sản
        sSQL = SQLStoreD02P5003("'HistoryTypeID =''AAC'''")
        dt = ReturnDataTable(sSQL)
        LoadChangeAssetAccount(dt)
        'Load Thay đổi tài khoản khấu hao
        sSQL = SQLStoreD02P5003("'HistoryTypeID =''DAC'''")
        dt = ReturnDataTable(sSQL)
        LoadChangeDepAccount(dt)
        SetEnableAsset_DepAccount()

        'Load Tab2
        dt = ReturnTableFilter(dtAssetID, "AssetID = " & SQLString(_assetID), True)

        dtGrid2 = dt.Copy
        LoadTDBGrid2(dtGrid2) 'dt.Copy

        sSQL = SQLStoreD02P5004("")
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            tdbcVoucherTypeID.Text = dt.Rows(0).Item("VoucherTypeID").ToString
            txtVoucherNo.Text = dt.Rows(0).Item("VoucherNo").ToString
            c1dateVoucherDate.Value = SQLDateShow(dt.Rows(0).Item("VoucherDate"))
            tdbcCurrencyID.Text = dt.Rows(0).Item("CurrencyID").ToString
            txtNotes.Text = dt.Rows(0).Item("Notes").ToString
            chkCollect.Checked = L3Bool(dt.Rows(0).Item("Checked"))
        End If

        'Load Grid 3
        dtGrid3 = dt.Copy
        LoadDataSource(tdbg3, dtGrid3, gbUnicode)

        ReadOnlyControl(tdbcAssetID)
        ReadOnlyControl(tdbcChangeNo)
        ReadOnlyControl(tdbcVoucherTypeID)
        ReadOnlyControl(txtVoucherNo)
        chkCollect_Click(Nothing, Nothing)

        VisiblechkIsNotCalDep() '24/3/2022, Đinh Văn Khanh:id 217076-SVI_ Cập nhật PP khấu hao TSCD cho tất cả các TS có nghiệp vụ tác động

    End Sub

    Private Sub LoadAddNew()
        tdbcAssetID.Text = ""
        tdbcAssetID.Tag = tdbcAssetID.Text
        c1dateChangeDate.Value = Date.Now
        tdbcChangeNo.Text = ""
        txtDecisionNo.Text = ""
        txtNotes1.Text = ""
        txtNotes2.Text = ""
        txtNotes3.Text = ""

        chkIsNotCalDep.Checked = True '24/3/2022, Đinh Văn Khanh:id 217076-SVI_ Cập nhật PP khấu hao TSCD cho tất cả các TS có nghiệp vụ tác động

        chkUseAccount.Checked = False
        chkIsEliminated.Checked = False

        chkChangeDepreciation.Checked = False
        grpChangeDepreciation.Enabled = False
        optStopDepreciation.Checked = True
        LoadDataSource(tdbg1, SQLStoreD02P5003("'HistoryTypeID =''AS'''"), gbUnicode)

        chkChangeUsing.Checked = False
        grpChangeUsing.Enabled = False
        optStopUse.Checked = True
        tdbcWareHouseID.Text = ""

        chkChangeDepreciationTime.Checked = False
        grpChangeDepreciationTime.Enabled = False
        txtServiceLife.Text = ""
        chkDepreciationTime.Checked = False
        btnDepreciation.Enabled = False

        chkChangeDistribute.Checked = False
        grpChangeDistribute.Enabled = False

        chkReceiveManage.Checked = False
        chkChangeManagement.Checked = False
        grpChangeManage.Enabled = False

        tdbcObjectTypeID.Text = ""
        tdbcObjectID.Text = ""
        tdbcEmployeeID.Text = ""
        tdbcLocationID.Text = ""
        txtLocationName.Text = ""
        tdbcManagementObjID.Text = ""

        'Load Tab2
        EnabledTabPage(New TabPage() {Tab2}, False)
        tabMain.SelectedTab = Tab1
        chkCollect.Checked = False
        btnCollect.Enabled = False

        dtGrid2 = ReturnTableFilter(dtAssetID, "AssetID = " & SQLString(""), True)
        LoadTDBGrid2(dtGrid2) 'ReturnTableFilter(dtAssetID, "AssetID = " & SQLString(""), True)

        dtGrid3 = ReturnDataTable(SQLStoreD02P5004(""))
        LoadDataSource(tdbg3, dtGrid3, gbUnicode)
        chkIsChangeAssetAccount.Checked = False
        chkIsChangeDepAccount.Checked = False
        SetEnableAsset_DepAccount() '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
    End Sub

    Private Sub LoadDefaultGrid3()
        Dim sSQL As String
        'Load mac dinh cho luoi dinh khoan tdbg3
        sSQL = SQLDeleteD02T0011("") & vbCrLf
        sSQL &= SQLStoreD02P2000s()
        ExecuteSQL(sSQL)

        'Load lai tdbg3 cho AssetID
        'Dim sSQL As String = ""
        sSQL = " SELECT "
        sSQL &= " 	A.UserID,	A.DivisionID, A.AssetID,A.TransactionID,A.VoucherTypeID,A.VoucherNo,A.VoucherDate,A.Notes,A.TransactionTypeID,"
        sSQL &= " 	A.RefNo,A.RefDate,A.SeriNo,A.Description,A.ObjectTypeID,A.ObjectID,A.CurrencyID,A.ExchangeRate,A.DebitAccountID,A.CreditAccountID,"
        sSQL &= " 	A.OriginalAmount, A.ConvertedAmount,A.SourceID,A.CipID,'' as ProjectID,'' as ProjectName,'' as TaskID,'' as TaskName,"
        sSQL &= " 	A.[Ana01ID],A.[Ana02ID], A.[Ana03ID],A.[Ana04ID],A.[Ana05ID],A.[Ana06ID],A.[Ana07ID],A.[Ana08ID],A.[Ana09ID],A.[Ana10ID],"
        sSQL &= "   A.TranMonth,A.TranYear,A.ModuleID,A.CreateUserID,A.CreateDate,A.LastModifyUserID,A.LastModifyDate,A.InventoryID,A.Quantity,"
        sSQL &= "   A.UnitID,A.[D54ProjectID],A.[D27PropertyProductID],CONVERT(BIT,A.IsNotAllocate) AS IsNotAllocate, B.CipNo, C.InventoryNameU AS InventoryName, A.PeriodID, A.TransactionTypeID, " & vbCrLf

        sSQL &= "CASE WHEN A.TransactionTypeID IN ('AAC','DAC') THEN 1 ELSE 0 END IsLockAccount, " & vbCrLf
        sSQL &= "CASE WHEN A.TransactionTypeID IN ('AAC','DAC') THEN 1 ELSE 0 END IsLockAmount " & vbCrLf

        sSQL &= "   FROM D02T0011 A WITH(NOLOCK) "
        sSQL &= "   LEFT JOIN D02T0100 B WITH(NOLOCK) "
        sSQL &= "	On A.CipID = B.CipID "
        sSQL &= "   LEFT JOIN D07T0002 C WITH(NOLOCK) "
        sSQL &= "   ON A.InventoryID = C.InventoryID  "
        sSQL &= "   WHERE      UserID = " & SQLString(gsUserID) & " AND A.AssetID = " & SQLString(tdbg2(tdbg2.Row, COL2_AssetID).ToString) & vbCrLf
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID  = 'D02F2003' "

        dtGrid3 = ReturnDataTable(sSQL)
        LoadDataSource(tdbg3, dtGrid3, gbUnicode)
    End Sub

#Region "Events tdbCombo"

#Region "Events tdbcEffectReasonID with txtEffectReasonName"

    Private Sub tdbcEffectReasonID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEffectReasonID.SelectedValueChanged
        If tdbcEffectReasonID.SelectedValue Is Nothing Then
            txtEffectReasonName.Text = ""
        Else
            txtEffectReasonName.Text = tdbcEffectReasonID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcEffectReasonID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEffectReasonID.LostFocus
        'If tdbcEffectReasonID.FindStringExact(tdbcEffectReasonID.Text) = -1 Then
        '    tdbcEffectReasonID.Text = ""
        'End If
    End Sub

    Private Sub tdbcEffectReasonID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEffectReasonID.Validated
        clsFilterCombo.FilterCombo(tdbcEffectReasonID, e)
        If tdbcEffectReasonID.FindStringExact(tdbcEffectReasonID.Text) = -1 Then
            tdbcEffectReasonID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcAssetID with txtAssetName"

    Private Sub tdbcAssetID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetID.SelectedValueChanged
        If tdbcAssetID.SelectedValue Is Nothing Then
            txtAssetName.Text = ""
        Else
            txtAssetName.Text = tdbcAssetID.Columns(1).Value.ToString
        End If
        btnView.Enabled = ComboValue(tdbcAssetID) <> "" And ComboValue(tdbcAssetID) <> "..." And _FormState <> EnumFormState.FormEditOther
    End Sub

    Private Sub tdbcAssetID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetID.Validated
        clsFilterCombo.FilterCombo(tdbcAssetID, e)
        If tdbcAssetID.Tag Is Nothing Then Exit Sub
        If tdbcAssetID.Tag.ToString = tdbcAssetID.Text Then Exit Sub

        If tdbcAssetID.FindStringExact(tdbcAssetID.Text) = -1 Then
            tdbcAssetID.Text = ""
        End If
        tdbcAssetID.Tag = tdbcAssetID.Text

        If tdbcAssetID.SelectedValue IsNot Nothing Then
            GetAssetID(ReturnValueC1Combo(tdbcAssetID), ReturnValueC1Combo(tdbcAssetID, "AssetName"), ReturnValueC1Combo(tdbcAssetID, "AssetAccountID"), ReturnValueC1Combo(tdbcAssetID, "DepAccountID"), ReturnValueC1Combo(tdbcAssetID, "D27PropertyProductID"), ReturnValueC1Combo(tdbcAssetID, "ProjectID"), ReturnValueC1Combo(tdbcAssetID, "ProjectName"))
            If tdbcChangeNo.Text <> "" Then
                'Load mac dinh cho luoi dinh khoan tdbg3
                LoadDefaultGrid3()
            End If
        End If
    End Sub

    Private Sub GetAssetID(ByVal sAssetID As String, ByVal sAssetName As String, ByVal sAssetAccountID As String, ByVal sDepAccountID As String, ByVal sPropertyProductID As String, ByVal sProjectID As String, ByVal sProjectName As String)
        Dim sSQL As String = ""
        'Dim dt As DataTable
        If sAssetID <> "..." Then
            sSQL &= "SELECT DISTINCT '' As OrderNo, AssetID, HistoryTypeID, EndMonth, EndYear, InstanceID " & vbCrLf
            sSQL &= "FROM   D02T5000 WITH (NOLOCK) " & vbCrLf
            sSQL &= "WHERE  EndMonth = 12 AND EndYear = 9999 " & vbCrLf
            sSQL &= "       AND AssetID = " & SQLString(sAssetID) & vbCrLf
            sSQL &= SQLDeleteD02T0011("") & vbCrLf
            ExecuteSQL(sSQL)

            sSQL = "SELECT	'' As OrderNo, '' As BatchID, "
            sSQL &= SQLString(sAssetID) & " AS AssetID, "
            sSQL &= "N" & SQLString(sAssetName) & " AS AssetName,"
            sSQL &= SQLString(sAssetAccountID) & " AS AssetAccountID, "
            sSQL &= SQLString(sDepAccountID) & " AS DepAccountID ,"
            sSQL &= SQLString(sPropertyProductID) & " AS D27PropertyProductID, "
            sSQL &= SQLString(sProjectID) & " AS ProjectID, "
            sSQL &= "N" & SQLString(sProjectName) & " AS ProjectName "

            dtGrid2 = ReturnDataTable(sSQL)
            LoadTDBGrid2(dtGrid2)

            chkCollect.Enabled = True
            chkCollect.Checked = False
            btnCollect.Enabled = False
            btnInherit.Enabled = True
        Else
            Dim frm As New D02F2013
            Try
                frm.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.StackTrace)
            End Try

            If gbSavedOK Then
                dtGrid2 = frm.dtData ' dt = frm.dtData
                dtRecordSet_Asset = frm.dtData
                LoadTDBGrid2(dtGrid2)
            End If
            frm.Dispose()

            chkCollect.Enabled = False
            btnCollect.Enabled = False
            btnInherit.Enabled = False
        End If
    End Sub
#End Region

#Region "Events tdbcChangeNo with txtChangeNoName"

    Private Sub tdbcChangeNo_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcChangeNo.Close
        'ChangeNoItemChange(tdbcChangeNo.Columns("ChangeNo").Value.ToString)
    End Sub

    Private Sub tdbcChangeNo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcChangeNo.SelectedValueChanged

        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        chkIsChangeAssetAccount.Checked = L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeAssetAccount"))
        chkIsChangeDepAccount.Checked = L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeDepAccount"))
        tdbcAssetAccountID.SelectedValue = ReturnValueC1Combo(tdbcChangeNo, "AssetAccountID")
        tdbcDepAccountID.SelectedValue = ReturnValueC1Combo(tdbcChangeNo, "DepAccountID")
        tdbcAssetAccountID.Tag = tdbcAssetAccountID.Text
        tdbcDepAccountID.Tag = tdbcDepAccountID.Text

        If tdbcChangeNo.SelectedValue Is Nothing Then
            txtChangeNoName.Text = ""
        Else
            txtChangeNoName.Text = tdbcChangeNo.Columns(1).Value.ToString
            bFirstCheck = False
            chkCollect.Checked = False

            'If tdbcChangeNo.DroppedDown = False Then
            '    ChangeNoItemChange(tdbcChangeNo.Columns("ChangeNo").Value.ToString)
            'End If
            If _FormState = EnumFormState.FormAdd Then
                chkCollect_Click(Nothing, Nothing)
            End If
            LoadDynamicCaption()
        End If

        VisiblechkIsNotCalDep() '24/3/2022, Đinh Văn Khanh:id 217076-SVI_ Cập nhật PP khấu hao TSCD cho tất cả các TS có nghiệp vụ tác động
    End Sub

    Private Sub tdbcChangeNo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcChangeNo.LostFocus
        'If tdbcChangeNo.FindStringExact(tdbcChangeNo.Text) = -1 Then
        '    tdbcChangeNo.Text = ""
        'End If
    End Sub

    Private Sub tdbcChangeNo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcChangeNo.Validated
        clsFilterCombo.FilterCombo(tdbcChangeNo, e)
        If tdbcChangeNo.FindStringExact(tdbcChangeNo.Text) = -1 Then
            tdbcChangeNo.Text = ""
        End If
        ChangeNoItemChange(tdbcChangeNo.Columns("ChangeNo").Value.ToString)
    End Sub

    Private Sub ChangeNoItemChange(ByVal sChangeNo As String)
        Dim sSQL As String = ""
        Dim dt As DataTable
        chkUseAccount.Checked = L3Bool(tdbcChangeNo.Columns("UseAccount").Value)

        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        If L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeAssetAccount")) Or L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeDepAccount")) Then
            tabMain.SelectedTab = Tab1
            If L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeAssetAccount")) And L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeDepAccount")) Then
                tdbcAssetAccountID.Focus()
            ElseIf L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeAssetAccount")) And L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeDepAccount")) = False Then
                tdbcAssetAccountID.Focus()
            ElseIf L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeAssetAccount")) = False And L3Bool(ReturnValueC1Combo(tdbcChangeNo, "IsChangeDepAccount")) Then
                tdbcDepAccountID.Focus()
            End If
        Else
            If chkUseAccount.Checked Then
                'EnabledTabPage(New TabPage() {Tab2}, True)
                tabMain.SelectedTab = Tab2
            Else
                'EnabledTabPage(New TabPage() {Tab2}, False)
                tabMain.SelectedTab = Tab1
            End If
        End If
        If chkUseAccount.Checked Then
            EnabledTabPage(New TabPage() {Tab2}, True)
            'tabMain.SelectedTab = Tab2
        Else
            EnabledTabPage(New TabPage() {Tab2}, False)
            'tabMain.SelectedTab = Tab1
        End If

        'Load thong tin mac dinh
        txtNotes1.Text = tdbcChangeNo.Columns("Notes1").Text
        txtNotes2.Text = tdbcChangeNo.Columns("Notes2").Text
        txtNotes3.Text = tdbcChangeNo.Columns("Notes3").Text
        tdbcVoucherTypeID.Text = tdbcChangeNo.Columns("VoucherTypeID").Text
        txtNotes.Text = tdbcChangeNo.Columns("VoucherDesc").Text
        tdbcCurrencyID.Text = tdbcChangeNo.Columns("CurrencyID").Text
        c1dateVoucherDate.Value = Date.Now()

        chkIsEliminated.Checked = L3Bool(tdbcChangeNo.Columns("IsEliminated").Value)

        'Load Group Thay doi tieu thuc phan bo
        sSQL = "SELECT     '' AS HistoryID, A.AssignmentID, B.AssignmentName" & UnicodeJoin(gbUnicode) & " as AssignmentName, A.PercentAmount " & vbCrLf
        sSQL &= "FROM       D02T0201 A WITH(NOLOCK) " & vbCrLf
        sSQL &= "LEFT JOIN 	D02T0002 B WITH(NOLOCK) " & vbCrLf
        sSQL &= "ON A.AssignmentID = B.AssignmentID " & vbCrLf
        sSQL &= "WHERE      ChangeType = 'AS' AND ChangeNo = " & SQLString(sChangeNo) & vbCrLf
        sSQL &= "ORDER BY   B.AssignmentID, B.AssignmentName" & vbCrLf
        dt = ReturnDataTable(sSQL)
        LoadChangeDistribute(dt)

        'Load Group Thay doi bo phan quan ly và Load Group Thay doi bo phan tiếp nhận
        sSQL = "SELECT 	ObjectTypeID, ObjectID, EmployeeID, FullName" & UnicodeJoin(gbUnicode) & " as FullName , ManagementObjTypeID, ManagementObjID, IsManagement, isReceive " & vbCrLf
        sSQL &= "FROM 		D02T0201 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE 		ChangeType = 'OB' AND IsManagement = 0 AND ChangeNo = " & SQLString(sChangeNo) & vbCrLf
        'sSQL &= "ORDER BY 	ObjectTypeID, ObjectID, EmployeeID, FullName" & vbCrLf
        dt = ReturnDataTable(sSQL)
        LoadChangeManage(dt)
        'LoadChangeManagement(dt)
        sSQL = "SELECT 	ObjectTypeID, ObjectID, EmployeeID, FullName" & UnicodeJoin(gbUnicode) & " as FullName , ManagementObjTypeID, ManagementObjID, IsManagement, isReceive " & vbCrLf
        sSQL &= "FROM 		D02T0201 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE 		ChangeType = 'OB' AND IsManagement = 1 AND ChangeNo = " & SQLString(sChangeNo) & vbCrLf
        'sSQL &= "ORDER BY 	ObjectTypeID, ObjectID, EmployeeID, FullName" & vbCrLf
        dt = ReturnDataTable(sSQL)
        LoadChangeManage(dt)
        'sSQL = "SELECT 	 EmployeeID, FullName" & UnicodeJoin(gbUnicode) & " as FullName, ManagementObjTypeID, ManagementObjID  " & vbCrLf
        'sSQL &= "FROM 		D02T0201 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "WHERE 		ChangeType = 'OB' AND ChangeNo = " & SQLString(sChangeNo) & vbCrLf
        'sSQL &= "ORDER BY 	ManagementObjTypeID, ManagementObjID, EmployeeID, FullName" & vbCrLf
        'dt = ReturnDataTable(sSQL)
        'LoadChangeManagement(dt)

        'Load Group Thay đổi tình trạng khấu hao
        sSQL = "SELECT  StopDepreciation" & vbCrLf
        sSQL &= "FROM   D02T0201 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE  ChangeType = 'SD' AND ChangeNo = " & SQLString(sChangeNo) & vbCrLf
        dt = ReturnDataTable(sSQL)
        LoadChangeDepreciation(dt)

        'Load Group Thay đổi tình trạng sử dụng
        sSQL = "SELECT 	StopUse, AssetWHID " & vbCrLf
        sSQL &= "FROM 	D02T0201 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE ChangeType = 'SU' AND ChangeNo = " & SQLString(sChangeNo) & vbCrLf
        dt = ReturnDataTable(sSQL)
        LoadChangeUsing(dt)

        'Load Group Thay đổi thời gian khấu hao
        sSQL = "SELECT 		ChangeNo, ServiceLife " & vbCrLf
        sSQL &= "FROM 	D02T0201 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE 	ChangeType = 'SL' AND ChangeNo = " & SQLString(sChangeNo) & vbCrLf
        dt = ReturnDataTable(sSQL)
        LoadChangeDepreciationTime(dt)
        'Load mac dinh cho luoi dinh khoan tdbg3
        LoadDefaultGrid3()

        'Load Location
        sSQL = " -- Do nguon Location" & vbCrLf
        sSQL &= " Select LocationID"
        sSQL &= " FROM 		D02T0201 WITH(NOLOCK)  "
        sSQL &= " WHERE 		ChangeType ='OB' AND ChangeNo = " & SQLString(ReturnValueC1Combo(tdbcChangeNo))
        Dim sLocation As String = ReturnScalar(sSQL)
        tdbcLocationID.SelectedValue = sLocation

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2000s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 12/05/2011 09:39:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2000s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbg2.RowCount - 1
            sSQL = ""
            sSQL &= "Exec D02P2000 "
            sSQL &= SQLString(tdbcChangeNo.Text) & COMMA 'ChangeNo, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg2(i, COL2_AssetID)) & COMMA 'AssetID, varchar[20], NOT NULL
            sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
            sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
            sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
            sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
            sSQL &= SQLNumber(1) & COMMA 'IsBegin, int, NOT NULL
            sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, int, NOT NULL
            sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID,  varchar[20], NOT NULL
            sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
            '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
            sSQL &= SQLString(tdbcAssetAccountID.Text) & COMMA 'ChangeAssetAccountID, varchar[50], NOT NULL
            sSQL &= SQLString(tdbcDepAccountID.Text) & COMMA 'ChangeDepAccountID, varchar[50], NOT NULL
            sSQL &= SQLString(_batchID) 'BatchID, varchar[50], NOT NULL

            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

#End Region

#Region "Events tdbcWareHouseID"

    Private Sub tdbcWareHouseID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWareHouseID.LostFocus
        If tdbcWareHouseID.FindStringExact(tdbcWareHouseID.Text) = -1 Then tdbcWareHouseID.Text = ""
    End Sub

#End Region

#Region "Events tdbcObjectTypeID load tdbcObjectID with txtObjectName"

    Private Sub tdbcObjectTypeID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.GotFocus
        'Dùng phím Enter
        tdbcObjectTypeID.Tag = tdbcObjectTypeID.Text
    End Sub

    Private Sub tdbcObjectTypeID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcObjectTypeID.MouseDown
        'Di chuyển chuột
        tdbcObjectTypeID.Tag = tdbcObjectTypeID.Text
    End Sub

    Private Sub tdbcObjectTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.SelectedValueChanged
        Try
            clsFilterCombo.LoadtdbcObjectID(tdbcObjectID, dtObjectID, ReturnValueC1Combo(tdbcObjectTypeID))
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace.ToString)
        End Try

        tdbcObjectID.Text = ""
    End Sub

    Private Sub tdbcObjectTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.LostFocus
        'If tdbcObjectTypeID.Tag.ToString = "" And tdbcObjectTypeID.Text = "" Then Exit Sub
        'If tdbcObjectTypeID.Tag.ToString = tdbcObjectTypeID.Text And tdbcObjectTypeID.SelectedValue IsNot Nothing Then Exit Sub
        'If tdbcObjectTypeID.FindStringExact(tdbcObjectTypeID.Text) = -1 OrElse tdbcObjectTypeID.SelectedValue Is Nothing Then
        '    tdbcObjectTypeID.Text = ""
        '    LoadtdbcObjectID("-1")
        '    tdbcObjectID.Text = ""
        '    Exit Sub
        'End If
        'LoadtdbcObjectID(ComboValue(tdbcObjectTypeID))
        'tdbcObjectID.Text = ""
    End Sub

    Private Sub tdbcObjectTypeID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.Validated
        clsFilterCombo.FilterCombo(tdbcObjectTypeID, e)
        If tdbcObjectTypeID.Tag.ToString = "" And tdbcObjectTypeID.Text = "" Then Exit Sub
        If tdbcObjectTypeID.Tag.ToString = tdbcObjectTypeID.Text And tdbcObjectTypeID.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcObjectTypeID.FindStringExact(tdbcObjectTypeID.Text) = -1 OrElse tdbcObjectTypeID.SelectedValue Is Nothing Then
            tdbcObjectID.Text = ""
            Exit Sub
        End If
    End Sub


    Private Sub tdbcObjectID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.SelectedValueChanged
        If tdbcObjectID.SelectedValue Is Nothing Then
            txtObjectName.Text = ""
        Else
            txtObjectName.Text = tdbcObjectID.Columns("ObjectName").Value.ToString
        End If
    End Sub

    Private Sub tdbcObjectID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.LostFocus
        'If tdbcObjectID.FindStringExact(tdbcObjectID.Text) = -1 Then tdbcObjectID.Text = ""
    End Sub

    Private Sub tdbcObjectID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcObjectID.Validated
        clsFilterCombo.FilterCombo(tdbcObjectID, e)
        If tdbcObjectID.FindStringExact(tdbcObjectID.Text) = -1 Then tdbcObjectID.Text = ""
    End Sub

#End Region


#Region "Events tdbcEmployeeID with txtEmployeeName"

    Private Sub tdbcEmployeeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.SelectedValueChanged
        If tdbcEmployeeID.SelectedValue Is Nothing Then
            txtEmployeeName.Text = ""
        Else
            txtEmployeeName.Text = tdbcEmployeeID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        'If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then
        '    tdbcEmployeeID.Text = ""
        'End If
    End Sub

    Private Sub tdbcEmployeeID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.Validated
        clsFilterCombo.FilterCombo(tdbcEmployeeID, e)
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then
            tdbcEmployeeID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcVoucherTypeID"

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        bEditVoucherNo = False
        bFirstF2 = False
        If tdbcVoucherTypeID.SelectedValue Is Nothing OrElse tdbcVoucherTypeID.Text = "" Then
            txtVoucherNo.Text = ""
            ReadOnlyControl(txtVoucherNo)
            Exit Sub
        End If
        If _FormState = EnumFormState.FormAdd Then
            If tdbcVoucherTypeID.Columns("Auto").Text = "1" Then 'Sinh tự động
                txtVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
                ReadOnlyControl(txtVoucherNo)
            Else 'Không sinh tự động
                txtVoucherNo.Text = ""
                UnReadOnlyControl(txtVoucherNo, True)
            End If
        End If
    End Sub

    Private Sub txtVoucherNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVoucherNo.KeyDown
        If e.KeyCode = Keys.F2 Then
            'Loại phiếu hay Số phiếu = "" thì thoát
            If tdbcVoucherTypeID.Text = "" Or txtVoucherNo.Text = "" Then Exit Sub

            'Update 21/09/2010: Trường hợp Thêm mới phiếu và đã lưu Thành công thì không cho sửa Số phiếu
            If _FormState = EnumFormState.FormAdd And btnSave.Enabled = False Then Exit Sub
            'Kiểm tra quyền cho trường hợp Sửa
            If _FormState = EnumFormState.FormEdit And iPer_F5558 <= 2 Then Exit Sub

            'Cho sửa Số phiếu ở trạng thái Thêm mới hay Sửa
            If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormEdit Then
                'Trước khi gọi exe con thì nhớ lại Số phiếu cũ
                If bFirstF2 = False Then
                    sOldVoucherNo = txtVoucherNo.Text
                    bFirstF2 = True
                End If
                'Gọi exe con D91E0640
                'Dim frm As New D91F5558
                'With frm
                '    .FormName = "D91F5558"
                '    .FormPermission = "D02F5558" 'Màn hình phân quyền
                '    .ModuleID = D02 'Mã module hiện tại, VD: D22
                '    .TableName = "D02T0012" 'Tên bảng chứa số phiếu
                '    'Update 21/09/2010
                '    If _FormState = EnumFormState.FormAdd Then
                '        .VoucherID = "" 'Khóa sinh IGE là rỗng
                '    ElseIf _FormState = EnumFormState.FormEdit Then
                '        .VoucherID = _groupID 'Khóa sinh IGE
                '    End If
                '    .VoucherNo = txtVoucherNo.Text 'Số phiếu cần sửa
                '    .Mode = "0" ' Tùy theo Module, mặc định là 0
                '    .KeyID01 = ""
                '    .KeyID02 = ""
                '    .KeyID03 = ""
                '    .KeyID04 = ""
                '    .KeyID05 = ""
                '    .ShowDialog()
                '    Dim sVoucherNo As String
                '    sVoucherNo = .Output02
                '    .Dispose()
                '    If sVoucherNo <> "" Then
                '        txtVoucherNo.Text = sVoucherNo 'Giá trị trả về Số phiếu mới
                '        ReadOnlyControl(txtVoucherNo) 'Lock text Số phiếu
                '        bEditVoucherNo = True 'Đã nhấn F2
                '        gbSavedOK = True
                '    End If
                'End With

                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D02F5558")
                SetProperties(arrPro, "VoucherTypeID", ReturnValueC1Combo(tdbcVoucherTypeID))
                If _FormState = EnumFormState.FormAdd Then
                    SetProperties(arrPro, "VoucherID", "")
                ElseIf _FormState = EnumFormState.FormEdit Then
                    SetProperties(arrPro, "VoucherID", _groupID)
                End If
                SetProperties(arrPro, "Mode", 0)
                SetProperties(arrPro, "KeyID01", "")
                SetProperties(arrPro, "TableName", "D02T0012")
                SetProperties(arrPro, "ModuleID", D02)
                SetProperties(arrPro, "OldVoucherNo", txtVoucherNo.Text)
                SetProperties(arrPro, "KeyID02", "")
                SetProperties(arrPro, "KeyID03", "")
                SetProperties(arrPro, "KeyID04", "")
                SetProperties(arrPro, "KeyID05", "")
                Dim frm As Form = CallFormShowDialog("D91D0640", "D91F5558", arrPro)
                Dim sNew As String = GetProperties(frm, "NewVoucherNo").ToString
                If sNew <> "" Then
                    txtVoucherNo.Text = sNew 'Giá trị trả về Số phiếu mới
                    ReadOnlyControl(txtVoucherNo) 'Lock text Số phiếu
                    bEditVoucherNo = True 'Đã nhấn F2
                    gbSavedOK = True
                End If
            End If
        End If
    End Sub

#End Region

#Region "Events tdbcCurrencyID"

    Private Sub tdbcCurrencyID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.LostFocus
        If tdbcCurrencyID.FindStringExact(tdbcCurrencyID.Text) = -1 Then tdbcCurrencyID.Text = ""
    End Sub

    Private Sub tdbcCurrencyID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.SelectedValueChanged
        'Sửa ngày 18/7/2012 theo anh Tuan boi VANVINH
        If chkCollect.Checked = False Then
            GetExchangeRate()
            If tdbg3.RowCount > 0 Then
                tdbg3(tdbg3.Row, COL3_ExchangeRate) = tdbcCurrencyID.Columns("ExchangeRate").Text
                CalcuteConvertedAmount()
            End If
        End If
    End Sub

    Private Sub GetExchangeRate()
        Dim sSQL As String = ""
        sSQL = SQLStoreD91P0010()
        dtExchangeRate = ReturnDataTable(sSQL)
    End Sub

    Private Sub CalcuteConvertedAmount()
        Dim dExchangeRate As Double = 0
        Dim dOriginalAmount As Double = 0
        Dim dConvertedAmount As Double
        If tdbg3.Columns(COL3_ExchangeRate).Text <> "" And tdbg3.Columns(COL3_OriginalAmount).Text <> "" Then
            dExchangeRate = CDbl(tdbg3.Columns(COL3_ExchangeRate).Text)
            dOriginalAmount = CDbl(tdbg3.Columns(COL3_OriginalAmount).Text)
            If tdbcCurrencyID.Columns("Operator").Text <> "" Then
                If CInt(tdbcCurrencyID.Columns("Operator").Text) = 0 Then
                    dConvertedAmount = dExchangeRate * dOriginalAmount
                    tdbg3.Columns(COL3_ConvertedAmount).Text = dConvertedAmount.ToString
                Else
                    If dExchangeRate <> 0 Then
                        dConvertedAmount = dOriginalAmount / dExchangeRate
                        tdbg3.Columns(COL3_ConvertedAmount).Text = SQLNumber(dConvertedAmount.ToString, DxxFormat.D90_ConvertedDecimals)

                    Else
                        D99C0008.MsgL3(rL3("Nguyen_te_khong_hop_le"))
                        Exit Sub
                    End If
                End If

            End If
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P0010
    '# Created User: Trần Thị ÁiTrâm
    '# Created Date: 11/09/2007 10:36:53
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lấy tỷ giá qui đổi
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD91P0010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P0010 "
        sSQL &= SQLString(tdbcCurrencyID.Columns("CurrencyID").Text) & COMMA 'CurrencyID, varchar[20], NOT NULL
        If tdbg3.Columns(COL3_RefDate).Text = "  /  /" Then
            sSQL &= SQLDateSave("") 'ExDate, datetime, NOT NULL
        Else
            sSQL &= SQLDateSave(tdbg3.Columns(COL3_RefDate).Text) 'ExDate, datetime, NOT NULL
        End If
        Return sSQL
    End Function

#End Region

#End Region

#Region "Events tdbg"

    Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        Select Case e.ColIndex
            Case COL1_PercentAmount
                FooterSumNew(tdbg1, COL1_PercentAmount)
            Case COL1_AssignmentID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg1, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg1, e, tdbd)
                    AfterColUpdate(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim row As DataRow = ReturnDataRow(tdbd, tdbd.DisplayMember & "=" & SQLString(tdbg1.Columns(e.ColIndex).Text))
                    AfterColUpdate(e.ColIndex, row)
                End If
        End Select
    End Sub

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr() As DataRow)
        Dim iRow As Integer = tdbg1.Row
        If dr Is Nothing OrElse dr.Length = 0 Then
            Dim row As DataRow = Nothing
            AfterColUpdate(iCol, row)
        ElseIf dr.Length = 1 Then
            If tdbg1.Bookmark <> tdbg1.Row AndAlso tdbg1.RowCount = tdbg1.Row Then 'Đang đứng dòng mới
                Dim dtGrid1 As DataTable = CType(tdbg1.DataSource, DataTable)
                Dim dr1 As DataRow = dtGrid1.NewRow
                dtGrid1.Rows.InsertAt(dr1, tdbg1.Row)
                SetDefaultValues(tdbg1, dr1) 'Bổ sung set giá trị mặc định 19/08/2015
                tdbg1.Bookmark = tdbg1.Row
            End If
            AfterColUpdate(iCol, dr(0))
        Else
            For Each row As DataRow In dr
                tdbg1.Bookmark = iRow
                tdbg1.Row = iRow
                AfterColUpdate(iCol, row)
                tdbg1.UpdateData()
                iRow += 1
            Next
            tdbg1.Focus()
        End If
    End Sub

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr As DataRow)
        'Gán lại các giá trị phụ thuộc vào Dropdown
        Select Case iCol
            Case COL1_AssignmentID
                If dr Is Nothing OrElse dr.Item("AssignmentID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg1.Columns(COL1_AssignmentID).Text = ""
                    tdbg1.Columns(COL1_AssignmentName).Text = ""
                    Exit Sub
                End If
                tdbg1.Columns(COL1_AssignmentID).Text = dr.Item("AssignmentID").ToString
                tdbg1.Columns(COL1_AssignmentName).Text = dr.Item("AssignmentName").ToString
        End Select
    End Sub

    Private Sub tdbg1_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.ButtonClick
        If clsFilterDropdown.IsNewFilter = False Then Exit Sub
        If tdbg1.AllowUpdate = False Then Exit Sub
        If tdbg1.Splits(tdbg1.SplitIndex).DisplayColumns(tdbg1.Col).Locked Then Exit Sub
        Select Case tdbg1.Col
            Case COL1_AssignmentID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg1, tdbg1.Columns(tdbg1.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg1, e, tdbd)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbg1.Col, dr)
        End Select
    End Sub

    Private Sub tdbg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        If clsFilterDropdown.CheckKeydownFilterDropdown(tdbg1, e) Then
            Select Case tdbg1.Col
                Case COL1_AssignmentID
                    Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg1, tdbg1.Columns(tdbg1.Col).DataField)
                    If tdbd Is Nothing Then Exit Select
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg1, e, tdbd)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate(tdbg1.Col, dr)
                    Exit Sub
            End Select
        End If
    End Sub


    Private Sub tdbg1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg1.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg1.Col
            'Case COL1_PercentAmount
            '    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg1_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg1.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL1_AssignmentID
                If clsFilterDropdown.IsNewFilter Then Exit Sub
                If tdbg1.Columns(COL1_AssignmentID).Text <> tdbdAssignmentID.Columns("AssignmentID").Text Then
                    tdbg1.Columns(COL1_AssignmentID).Text = ""
                    tdbg1.Columns(COL1_AssignmentName).Text = ""
                End If
                'Case COL1_AssignmentID
                '    If tdbg1.Columns(COL1_AssignmentID).Text <> tdbdAssignmentID.Columns("AssignmentID").Text Then
                '        tdbg1.Columns(COL1_AssignmentID).Text = ""
                '        tdbg1.Columns(COL1_AssignmentName).Text = ""
                '    End If
                'Case COL1_PercentAmount
                '    If Not L3IsNumeric(tdbg1.Columns(COL1_PercentAmount).Text, EnumDataType.Money) Then e.Cancel = True
        End Select

    End Sub

    Private Sub tdbg1_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.ComboSelect
        '--- Gán giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL1_AssignmentID
                tdbg1.Columns(COL1_AssignmentName).Text = tdbdAssignmentID.Columns("AssignmentName").Text
        End Select
    End Sub

    Private Sub tdbg2_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg2.RowColChange
        If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        'If tdbg2.Row = e.LastRow Then Exit Sub
        Dim sSQL As String = ""
        Dim sAssetID As String = tdbg2(e.LastRow, COL2_AssetID).ToString

        'Luu du lieu AssetID cu
        If tdbg3.RowCount > 0 Then
            sSQL &= SQLDeleteD02T0011(sAssetID)
            sSQL &= SQLInsertD02T0011s(sAssetID).ToString()
            ExecuteSQL(sSQL)
        End If

        'Load lai tdbg3 cho AssetID moi
        sSQL = " SELECT "
        sSQL &= " 	A.UserID,	A.DivisionID, A.AssetID,A.TransactionID,A.VoucherTypeID,A.VoucherNo,A.VoucherDate,A.Notes,A.TransactionTypeID,"
        sSQL &= " 	A.RefNo,A.RefDate,A.SeriNo,A.Description,A.ObjectTypeID,A.ObjectID,A.CurrencyID,A.ExchangeRate,A.DebitAccountID,A.CreditAccountID,"
        sSQL &= " 	A.OriginalAmount, A.ConvertedAmount,A.SourceID,A.CipID,A.ProjectID, A.ProjectName,A.TaskID,A.TaskName,"
        sSQL &= " 	A.[Ana01ID],A.[Ana02ID], A.[Ana03ID],A.[Ana04ID],A.[Ana05ID],A.[Ana06ID],A.[Ana07ID],A.[Ana08ID],A.[Ana09ID],A.[Ana10ID],"
        sSQL &= "   A.TranMonth,A.TranYear,A.ModuleID,A.CreateUserID,A.CreateDate,A.LastModifyUserID,A.LastModifyDate,A.InventoryID,A.Quantity,"
        sSQL &= "   A.UnitID,A.[D54ProjectID],A.[D27PropertyProductID],CONVERT(BIT,A.IsNotAllocate) AS IsNotAllocate, B.CipNo, C.InventoryNameU AS InventoryName, A.PeriodID, A.TransactionTypeID, " & vbCrLf
        sSQL &= "CASE WHEN A.TransactionTypeID IN ('AAC','DAC') THEN 1 ELSE 0 END IsLockAccount, " & vbCrLf
        sSQL &= "CASE WHEN A.TransactionTypeID IN ('AAC','DAC') THEN 1 ELSE 0 END IsLockAmount " & vbCrLf

        sSQL &= "   FROM D02T0011 A WITH(NOLOCK) "
        sSQL &= "   LEFT JOIN D02T0100 B WITH(NOLOCK) "
        sSQL &= "	On A.CipID = B.CipID "
        sSQL &= "   LEFT JOIN D07T0002 C WITH(NOLOCK) "
        sSQL &= "   ON A.InventoryID = C.InventoryID  "
        sSQL &= "   WHERE UserID = " & SQLString(gsUserID) & " AND A.AssetID = " & SQLString(tdbg2(tdbg2.Row, COL2_AssetID).ToString) & vbCrLf
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID  = 'D02F2003' "

        dtGrid3 = ReturnDataTable(sSQL)
        LoadDataSource(tdbg3, dtGrid3, gbUnicode)

    End Sub

    Private Sub tdbg3_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg3.BeforeColEdit
        Select Case tdbg3.Col
            Case COL3_DebitAccountID, COL3_CreditAccountID
                '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
                e.Cancel = L3Bool(tdbg3.Columns(COL3_IsLockAccount).Text)
            Case COL3_OriginalAmount, COL3_ConvertedAmount
                '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
                e.Cancel = L3Bool(tdbg3.Columns(COL3_IsLockAmount).Text)
        End Select
    End Sub


    Private Sub tdbg3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg3.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg3.Col
            Case COL3_ExchangeRate, COL3_OriginalAmount, COL3_ConvertedAmount, COL3_Quantity
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg3_LockTDBGrid(ByVal bIsLock As Boolean)
        tdbg3.AllowAddNew = Not bIsLock
        'tdbg3.AllowUpdate = Not bIsLock
        For i As Integer = 4 To tdbg3.Columns.Count - 1
            tdbg3.Splits(SPLIT0).DisplayColumns(i).Locked = bIsLock
            If tdbg3.Splits.Count > 1 Then tdbg3.Splits(SPLIT1).DisplayColumns(i).Locked = bIsLock
        Next
        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Button = False
        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Locked = True
        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Quantity).Locked = True
        If L3Bool(bIsLock) Then
            tdbg3.Columns(COL3_ObjectID).DropDown = Nothing
            tdbg3.Columns(COL3_ObjectTypeID).DropDown = Nothing
            tdbg3.Columns(COL3_DebitAccountID).DropDown = Nothing
            tdbg3.Columns(COL3_CreditAccountID).DropDown = Nothing
            tdbg3.Columns(COL3_SourceID).DropDown = Nothing
            tdbg3.Columns(COL3_CipNo).DropDown = Nothing
            tdbg3.Columns(COL3_Ana01ID).DropDown = Nothing
            tdbg3.Columns(COL3_Ana02ID).DropDown = Nothing
            tdbg3.Columns(COL3_Ana03ID).DropDown = Nothing
            tdbg3.Columns(COL3_Ana04ID).DropDown = Nothing
            tdbg3.Columns(COL3_Ana05ID).DropDown = Nothing
            tdbg3.Columns(COL3_Ana06ID).DropDown = Nothing
            tdbg3.Columns(COL3_Ana07ID).DropDown = Nothing
            tdbg3.Columns(COL3_Ana08ID).DropDown = Nothing
            tdbg3.Columns(COL3_Ana09ID).DropDown = Nothing
            tdbg3.Columns(COL3_Ana10ID).DropDown = Nothing
        Else

            tdbg3.Columns(COL3_ObjectTypeID).DropDown = tdbdObjectTypeID
            tdbg3.Columns(COL3_DebitAccountID).DropDown = tdbdDebitAccountID
            tdbg3.Columns(COL3_CreditAccountID).DropDown = tdbdCreditAccountID
            tdbg3.Columns(COL3_SourceID).DropDown = tdbdSourceID
            tdbg3.Columns(COL3_CipNo).DropDown = tdbdCipID
            If Not clsFilterDropdown.IsNewFilter Then
                tdbg3.Columns(COL3_ObjectID).DropDown = tdbdObjectID
                tdbg3.Columns(COL3_Ana01ID).DropDown = tdbdAna01ID
                tdbg3.Columns(COL3_Ana02ID).DropDown = tdbdAna02ID
                tdbg3.Columns(COL3_Ana03ID).DropDown = tdbdAna03ID
                tdbg3.Columns(COL3_Ana04ID).DropDown = tdbdAna04ID
                tdbg3.Columns(COL3_Ana05ID).DropDown = tdbdAna05ID
                tdbg3.Columns(COL3_Ana06ID).DropDown = tdbdAna06ID
                tdbg3.Columns(COL3_Ana07ID).DropDown = tdbdAna07ID
                tdbg3.Columns(COL3_Ana08ID).DropDown = tdbdAna08ID
                tdbg3.Columns(COL3_Ana09ID).DropDown = tdbdAna09ID
                tdbg3.Columns(COL3_Ana10ID).DropDown = tdbdAna10ID
            End If


        End If
    End Sub

    Private Sub tdbg3_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg3.AfterDelete
        If tdbg3.RowCount <= 0 Then
            tdbg3_LockTDBGrid(False)
        End If
    End Sub
    Private dtInv As DataTable = Nothing

    Private Sub tdbg3_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL3_InventoryID
                'ID 251211 : Cải tiến tốc độ load mã hàng
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    If DxxFormat.IsUseCacheOfList Then
                        If dtInv IsNot Nothing Then dtInv.Dispose()
                        dtInv = Nothing
                        System.GC.Collect()
                        dtInv = ReturnDataTable(SQLSelectInv(tdbg3.Columns(COL3_InventoryID).Text))
                        LoadDataSource(tdbd, dtInv, gbUnicode)
                    End If

                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg3, e, tdbd)
                    AfterColUpdate_tdbg3(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim row As DataRow = ReturnDataRow(tdbd, tdbd.DisplayMember & "=" & SQLString(tdbg3.Columns(e.ColIndex).Text))
                    AfterColUpdate_tdbg3(e.ColIndex, row)
                End If
            Case COL3_ObjectTypeID
                tdbg3.Columns(COL3_ObjectID).Value = ""
            Case COL3_CreditAccountID  'ID-143165 
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdownMulti(tdbg3, e, tdbd)
                    AfterColUpdate_tdbg3(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                End If

            Case COL3_DebitAccountID   'ID-143165 
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdownMulti(tdbg3, e, tdbd)
                    AfterColUpdate_tdbg3(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim sSQL As String = "SELECT TOP 1 1 FROM D90T0001 WITH(NOLOCK) WHERE AccountID = " & SQLString(tdbg3.Columns(COL3_DebitAccountID).Text) & " AND GroupID = 21"
                    If ExistRecord(sSQL) Then
                        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Button = True
                        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Locked = False
                        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Quantity).Locked = False
                    Else
                        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Button = False
                        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Locked = True
                        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Quantity).Locked = True
                    End If
                End If
            Case COL3_ExchangeRate
                CalcuteConvertedAmount()
            Case COL3_OriginalAmount
                CalcuteConvertedAmount()
            Case COL3_ObjectID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg3, e, tdbd)
                    AfterColUpdate_tdbg3(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim row As DataRow = ReturnDataRow(tdbd, tdbd.DisplayMember & "=" & SQLString(tdbg3.Columns(e.ColIndex).Text))
                    AfterColUpdate_tdbg3(e.ColIndex, row)
                End If

            Case COL3_Ana01ID To COL3_Ana10ID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg3, e, tdbd)
                    AfterColUpdate_tdbg3(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim row As DataRow = ReturnDataRow(tdbd, tdbd.DisplayMember & "=" & SQLString(tdbg3.Columns(e.ColIndex).Text))
                    AfterColUpdate_tdbg3(e.ColIndex, row)
                End If
        End Select
    End Sub

    Private Sub AfterColUpdate_tdbg3(ByVal iCol As Integer, ByVal dr() As DataRow)
        Dim iRow As Integer = tdbg3.Row
        If dr Is Nothing OrElse dr.Length = 0 Then
            Dim row As DataRow = Nothing
            AfterColUpdate_tdbg3(iCol, row)
        ElseIf dr.Length = 1 Then
            If tdbg3.Bookmark <> tdbg3.Row AndAlso tdbg3.RowCount = tdbg3.Row Then 'Đang đứng dòng mới
                Dim dtGrid3 As DataTable = CType(tdbg3.DataSource, DataTable)
                Dim dr1 As DataRow = dtGrid3.NewRow
                dtGrid3.Rows.InsertAt(dr1, tdbg3.Row)
                SetDefaultValues(tdbg3, dr1) 'Bổ sung set giá trị mặc định 19/08/2015
                tdbg3.Bookmark = tdbg3.Row
            End If
            AfterColUpdate_tdbg3(iCol, dr(0))
        Else
            For Each row As DataRow In dr
                tdbg3.Bookmark = iRow
                tdbg3.Row = iRow
                AfterColUpdate_tdbg3(iCol, row)
                tdbg3.UpdateData()
                iRow += 1
            Next
            tdbg3.Focus()
        End If
    End Sub

    Private Sub AfterColUpdate_tdbg3(ByVal iCol As Integer, ByVal dr As DataRow)
        'Gán lại các giá trị phụ thuộc vào Dropdown
        Select Case iCol
            Case COL3_Ana01ID To COL3_Ana10ID
                If dr Is Nothing OrElse dr.Item("AnaID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    CheckAfterColUpdateAna(tdbg3, COL3_Ana01ID, iCol, dtAnaCaption) 'tham khảo hàm viết phía dưới
                    Exit Sub
                End If
                tdbg3.Columns(iCol).Text = dr.Item("AnaID").ToString
            Case COL3_ObjectID
                If dr Is Nothing OrElse dr.Item("ObjectID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg3.Columns(COL3_ObjectID).Text = ""
                    Exit Sub
                End If
                'Chỉ dùng cho cột là Đối tượng
                If tdbg3.Columns(COL3_ObjectTypeID).Text = "" Then
                    tdbg3(tdbg3.Row, COL3_ObjectTypeID) = dr.Item("ObjectTypeID").ToString
                    LoadtdbdObjectID(tdbg3.Columns(COL3_ObjectTypeID).Text)
                End If
                tdbg3.Columns(COL3_ObjectID).Text = dr.Item("ObjectID").ToString
            Case COL3_CreditAccountID   'ID-143165 
                If dr Is Nothing OrElse dr.Item("AccountID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg3.Columns(COL3_CreditAccountID).Text = ""
                    Exit Sub
                End If
                tdbg3.Columns(iCol).Text = dr.Item("AccountID").ToString
                If clsFilterDropdown.IsNewFilter Then
                    tdbg3.Columns(COL3_CreditAccountID).DropDown = Nothing
                    tdbg3.Splits(tdbg3.SplitIndex).DisplayColumns(tdbg3.Col).Button = True
                End If
            Case COL3_DebitAccountID    'ID-143165 
                If dr Is Nothing OrElse dr.Item("AccountID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg3.Columns(COL3_DebitAccountID).Text = ""
                Else
                    tdbg3.Columns(COL3_DebitAccountID).Text = dr.Item("AccountID").ToString
                End If
                Dim sSQL As String = "SELECT TOP 1 1 FROM D90T0001 WITH(NOLOCK) WHERE AccountID = " & SQLString(tdbg3.Columns(COL3_DebitAccountID).Text) & " AND GroupID = 21"
                If ExistRecord(sSQL) Then
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Button = True
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Locked = False
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Quantity).Locked = False
                Else
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Button = False
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Locked = True
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Quantity).Locked = True
                End If
                If clsFilterDropdown.IsNewFilter Then
                    tdbg3.Columns(COL3_DebitAccountID).DropDown = Nothing
                    tdbg3.Splits(tdbg3.SplitIndex).DisplayColumns(tdbg3.Col).Button = True
                End If
            Case COL3_InventoryID
                'ID 251211 : Cải tiến tốc độ load mã hàng
                If dr Is Nothing OrElse dr.Item("InventoryID").ToString <> "" Then
                    tdbg3.Columns(COL3_InventoryID).Value = dr.Item("InventoryID")
                    tdbg3.Columns(COL3_InventoryName).Value = dr.Item("InventoryName")
                    tdbg3.Columns(COL3_UnitID).Value = dr.Item("UnitID")
                Else
                    tdbg3.Columns(COL3_InventoryID).Value = ""
                    tdbg3.Columns(COL3_InventoryName).Value = ""
                    tdbg3.Columns(COL3_UnitID).Value = ""
                End If
        End Select
    End Sub

    Private Sub tdbg3_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.ButtonClick
        If clsFilterDropdown.IsNewFilter = False Then Exit Sub
        If tdbg3.AllowUpdate = False Then Exit Sub
        If tdbg3.Splits(tdbg3.SplitIndex).DisplayColumns(tdbg3.Col).Locked Then Exit Sub
        Select Case tdbg3.Col
            Case COL3_ObjectID, COL3_Ana01ID To COL3_Ana10ID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, tdbg3.Columns(tdbg3.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg3, e, tdbd)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate_tdbg3(tdbg3.Col, dr)
            Case COL3_CreditAccountID, COL3_DebitAccountID
                'ID-143165  bo sung COL3_CreditAccountID, COL3_DebitAccountID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, tdbg3.Columns(tdbg3.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg3, e, tdbd)
                If clsFilterDropdown.IsNewFilter Then
                    tdbg3.Columns(tdbg3.Col).DropDown = Nothing
                    tdbg3.Splits(tdbg3.SplitIndex).DisplayColumns(tdbg3.Col).Button = True
                End If
                If dr Is Nothing Then Exit Sub
                AfterColUpdate_tdbg3(tdbg3.Col, dr)
            Case COL3_InventoryID
                If DxxFormat.IsUseCacheOfList Then Exit Sub
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, tdbg3.Columns(tdbg3.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg3, e, tdbd)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate_tdbg3(tdbg3.Col, dr)
        End Select
    End Sub

    Private Sub tdbg3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg3.Col = iLastCol Then
                HotKeyEnterGrid(tdbg3, COL3_SeriNo, e)
            End If
        End If
        If clsFilterDropdown.CheckKeydownFilterDropdown(tdbg3, e) Then
            Select Case tdbg3.Col
                Case COL3_ObjectID, COL3_Ana01ID To COL3_Ana10ID, COL3_CreditAccountID, COL3_DebitAccountID
                    'ID-143165  bo sung COL3_CreditAccountID, COL3_DebitAccountID
                    Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, tdbg3.Columns(tdbg3.Col).DataField)
                    If tdbd Is Nothing Then Exit Select
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg3, e, tdbd)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate_tdbg3(tdbg3.Col, dr)
                    Exit Sub
                Case COL3_InventoryID
                    If DxxFormat.IsUseCacheOfList Then Exit Sub
                    Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg3, tdbg3.Columns(tdbg3.Col).DataField)
                    If tdbd Is Nothing Then Exit Select
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdownMulti(tdbg3, e, tdbd)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate_tdbg3(tdbg3.Col, dr)
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub tdbg3_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg3.BeforeColUpdate
        Select Case e.ColIndex
            Case COL3_SeriNo, COL3_RefNo, COL3_RefDate, COL3_Description
                '31/7/2012 VANVINH Tu dong cap nhat ty gia tren combo xuong luoi khi them moi dong
                GetExchangeRate()
                If tdbg3.RowCount > 0 Then
                    tdbg3.Columns(COL3_ExchangeRate).Text = tdbcCurrencyID.Columns("ExchangeRate").Text
                    CalcuteConvertedAmount()
                End If
            Case COL3_ObjectTypeID
                If tdbg3.Columns(COL3_ObjectTypeID).Text <> tdbdObjectTypeID.Columns(tdbdObjectTypeID.DisplayMember).Text Then
                    tdbg3.Columns(COL3_ObjectTypeID).Text = ""
                    tdbg3.Columns(COL3_ObjectID).Text = ""
                End If
                '31/7/2012 VANVINH Tu dong cap nhat ty gia tren combo xuong luoi khi them moi dong
                GetExchangeRate()
                If tdbg3.RowCount > 0 Then
                    tdbg3.Columns(COL3_ExchangeRate).Text = tdbcCurrencyID.Columns("ExchangeRate").Text
                    CalcuteConvertedAmount()
                End If
                'Case COL3_ObjectID
                '    If tdbg3.Columns(COL3_ObjectID).Text <> tdbdObjectID.Columns(tdbdObjectID.DisplayMember).Text Then
                '        tdbg3.Columns(COL3_ObjectID).Text = ""
                '    End If

            Case COL3_ObjectID
                If clsFilterDropdown.IsNewFilter Then Exit Sub
                If tdbg3.Columns(COL3_ObjectID).Text <> tdbdObjectID.Columns("ObjectID").Text Then
                    tdbg3.Columns(COL3_ObjectID).Text = ""
                End If
            Case COL3_Ana01ID To COL3_Ana10ID 'Có nhập ngoài danh sách không bỏ
                If clsFilterDropdown.IsNewFilter Then Exit Sub
                If tdbg3.Columns(e.ColIndex).Text <> tdbg3.Columns(e.ColIndex).DropDown.Columns("AnaID").Text Then
                    CheckAfterColUpdateAna(tdbg3, COL3_Ana01ID, e.ColIndex, dtAnaCaption) 'tham khảo hàm viết phía dưới
                End If

            Case COL3_DebitAccountID
                If clsFilterDropdown.IsNewFilter Then Exit Sub
                If tdbg3.Columns(COL3_DebitAccountID).Text <> tdbdDebitAccountID.Columns(tdbdDebitAccountID.DisplayMember).Text Then
                    tdbg3.Columns(COL3_DebitAccountID).Text = ""
                End If
            Case COL3_CreditAccountID
                If clsFilterDropdown.IsNewFilter Then Exit Sub
                If tdbg3.Columns(COL3_CreditAccountID).Text <> tdbdCreditAccountID.Columns(tdbdCreditAccountID.DisplayMember).Text Then
                    tdbg3.Columns(COL3_CreditAccountID).Text = ""
                End If
            Case COL3_SourceID
                If tdbg3.Columns(COL3_SourceID).Text <> tdbdSourceID.Columns(tdbdSourceID.DisplayMember).Text Then
                    tdbg3.Columns(COL3_SourceID).Text = ""
                End If
            Case COL3_CipNo
                If tdbg3.Columns(COL3_CipNo).Text <> tdbdCipID.Columns(tdbdCipID.DisplayMember).Text Then
                    tdbg3.Columns(COL3_CipNo).Text = ""
                End If
            Case COL3_ProjectID
                If tdbg3.Columns(COL3_ProjectID).Text <> tdbdProjectID.Columns(tdbdProjectID.DisplayMember).Text Then
                    tdbg3.Columns(COL3_ProjectID).Text = ""
                    tdbg3.Columns(COL3_ProjectName).Text = ""
                End If
            Case COL3_TaskID
                If tdbg3.Columns(COL3_TaskID).Text <> tdbdTaskID.Columns(tdbdTaskID.DisplayMember).Text Then
                    tdbg3.Columns(COL3_TaskID).Text = ""
                    tdbg3.Columns(COL3_TaskName).Text = ""
                End If

            Case COL3_PeriodID
                If tdbg3.Columns(e.ColIndex).Text <> tdbg3.Columns(e.ColIndex).DropDown.Columns(tdbg3.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg3.Columns(e.ColIndex).Text = ""
                End If

        End Select
    End Sub

    Private Sub tdbg3_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.ComboSelect
        '--- Gán giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL3_InventoryID
              
                If tdbdInventoryID.Columns(0).Text <> "" Then
                    tdbg3.Columns(COL3_InventoryID).Value = tdbdInventoryID.Columns("InventoryID").Text
                    tdbg3.Columns(COL3_InventoryName).Value = tdbdInventoryID.Columns("InventoryName").Text
                    tdbg3.Columns(COL3_UnitID).Value = tdbdInventoryID.Columns("UnitID").Text
                Else
                    tdbg3.Columns(COL3_InventoryID).Value = ""
                    tdbg3.Columns(COL3_InventoryName).Value = ""
                    tdbg3.Columns(COL3_UnitID).Value = ""
                End If
            Case COL3_CipNo
                tdbg3.Columns(COL3_CipID).Text = tdbdCipID.Columns("CipID").Text
                tdbg3.Columns(COL3_CreditAccountID).Text = tdbdCipID.Columns("AccountID").Text
                tdbg3.Columns(COL3_ConvertedAmount).Text = tdbdCipID.Columns("SumConvertedAmo").Text
                tdbg3.Columns(COL3_OriginalAmount).Text = tdbdCipID.Columns("SumOriginalAmo").Text
            Case COL3_ProjectID
                If tdbg3.Columns(COL3_ProjectID).Text <> tdbdProjectID.Columns(0).Text Then
                    tdbg3.Columns(COL3_ProjectID).Value = ""
                    tdbg3.Columns(COL3_ProjectName).Value = ""
                Else
                    tdbg3.Columns(COL3_ProjectID).Text = tdbdProjectID.Columns("ProjectID").Text
                    tdbg3.Columns(COL3_ProjectName).Text = tdbdProjectID.Columns("ProjectName").Text
                End If
            Case COL3_TaskID
                If tdbg3.Columns(COL3_TaskID).Text <> tdbdTaskID.Columns(0).Text Then
                    tdbg3.Columns(COL3_TaskID).Value = ""
                    tdbg3.Columns(COL3_TaskName).Value = ""
                Else
                    tdbg3.Columns(COL3_TaskID).Text = tdbdTaskID.Columns("TaskID").Text
                    tdbg3.Columns(COL3_TaskName).Text = tdbdTaskID.Columns("TaskName").Text
                End If
            Case Else
                tdbg3.UpdateData()
        End Select
    End Sub

    Private Sub tdbg3_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg3.RowColChange
        If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg3.Col
            Case COL3_ObjectID
                LoadtdbdObjectID(tdbg3(tdbg3.Row, COL3_ObjectTypeID).ToString)
                'Them ngay 3/12/2012 theo incident 52673 cua bảo Trân bởi Văn Vinh
            Case COL3_InventoryID
                Dim sSQL As String = "SELECT top 1 1 from d90t0001 with(nolock) where accountid = " & SQLString(tdbg3.Columns(COL3_DebitAccountID).Text) & " and groupid = 21"
                If ExistRecord(sSQL) Then
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Button = True
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Locked = False
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Quantity).Locked = False
                Else
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Button = False
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Locked = True
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Quantity).Locked = True
                End If
            Case COL3_Quantity
                Dim sSQL As String = "SELECT TOP 1 1 FROM D90T0001 WITH(NOLOCK) WHERE AccountID = " & SQLString(tdbg3.Columns(COL3_DebitAccountID).Text) & " AND GroupID = 21"
                If ExistRecord(sSQL) Then
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Button = True
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Locked = False
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Quantity).Locked = False
                Else
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Button = False
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_InventoryID).Locked = True
                    tdbg3.Splits(SPLIT0).DisplayColumns(COL3_Quantity).Locked = True
                End If
            Case COL3_DebitAccountID, COL3_CreditAccountID
                '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
                If L3Bool(tdbg3(tdbg3.Row, COL3_IsLockAccount)) = True Then
                    tdbg3.Splits(SPLIT0).DisplayColumns(tdbg3.Col).Button = False
                    tdbg3.Splits(SPLIT0).DisplayColumns(tdbg3.Col).Locked = True
                    tdbg3.UpdateData()
                Else
                    tdbg3.Splits(SPLIT0).DisplayColumns(tdbg3.Col).Button = True
                    tdbg3.Splits(SPLIT0).DisplayColumns(tdbg3.Col).Locked = False
                End If

        End Select
    End Sub

#End Region

#Region "Load cac Group"

    ''' <summary>
    ''' Thay đổi tiêu thức phân bổ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadChangeDistribute(ByVal dt As DataTable)
        chkChangeDistribute.Checked = dt.Rows.Count > 0
        grpChangeDistribute.Enabled = dt.Rows.Count > 0
        LoadDataSource(tdbg1, dt.Copy, gbUnicode)
        FooterSumNew(tdbg1, COL1_PercentAmount)
    End Sub
    ''' <summary>
    ''' Thay đổi tình trạng khấu hao
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadChangeDepreciation(ByVal dt As DataTable)
        chkChangeDepreciation.Checked = dt.Rows.Count > 0
        grpChangeDepreciation.Enabled = dt.Rows.Count > 0
        If dt.Rows.Count > 0 Then
            If L3Bool(dt.Rows(0).Item("StopDepreciation")) Then
                optStopDepreciation.Checked = True
            Else
                optReDepreciation.Checked = True
            End If

        End If
    End Sub
    ''' <summary>
    ''' Thay đổi tình trạng sử dụng
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadChangeUsing(ByVal dt As DataTable)
        chkChangeUsing.Checked = dt.Rows.Count > 0
        grpChangeUsing.Enabled = dt.Rows.Count > 0
        If dt.Rows.Count > 0 Then
            If L3Bool(dt.Rows(0).Item("StopUse")) Then
                optStopUse.Checked = True
            Else
                optReUse.Checked = True
            End If
            tdbcWareHouseID.Text = dt.Rows(0).Item("AssetWHID").ToString
        Else
            tdbcWareHouseID.Text = ""
        End If
    End Sub
    ''' <summary>
    ''' Thay đổi thời gian khấu hao
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadChangeDepreciationTime(ByVal dt As DataTable)
        chkChangeDepreciationTime.Checked = dt.Rows.Count > 0
        grpChangeDepreciationTime.Enabled = dt.Rows.Count > 0
        chkDepreciationTime.Enabled = dt.Rows.Count > 0
        btnDepreciation.Enabled = chkDepreciationTime.Checked
        If dt.Rows.Count > 0 Then
            txtServiceLife.Text = dt.Rows(0).Item("ServiceLife").ToString
        End If
    End Sub
    ''' <summary>
    ''' Thay đổi bộ phận quản lý
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadChangeManage(ByVal dt As DataTable)
        'chkChangeManage.Checked = dt.Rows.Count > 0
        'grpChangeManage.Enabled = dt.Rows.Count > 0
        If dt.Rows.Count > 0 Then
            grpChangeManage.Enabled = dt.Rows.Count > 0
            chkChangeManagement.Checked = L3Bool(dt.Rows(0).Item("IsManagement").ToString)
            If chkChangeManagement.Checked = True Then
                chkReceiveManage.Checked = L3Bool(dt.Rows(0).Item("IsReceive").ToString)
            Else
                chkReceiveManage.Checked = True

            End If

            tdbcObjectTypeID.SelectedValue = dt.Rows(0).Item("ObjectTypeID").ToString
            'LoadtdbcObjectID(ComboValue(tdbcObjectTypeID))
            tdbcObjectID.SelectedValue = dt.Rows(0).Item("ObjectID").ToString
            tdbcEmployeeID.SelectedValue = dt.Rows(0).Item("EmployeeID").ToString
            '30/10/2019, Lê Thị Phú Hà:id 123376-Bổ sung thay đổi bộ phận quản lý (NV tác động D02)
            tdbcManagementObjTypeID.SelectedValue = dt.Rows(0).Item("ManagementObjTypeID").ToString
            tdbcManagementObjID.SelectedValue = dt.Rows(0).Item("ManagementObjID").ToString
        End If
    End Sub

    Private Sub LoadChangeAssetAccount(ByVal dt As DataTable)
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        If dt.Rows.Count > 0 Then
            chkIsChangeAssetAccount.Checked = L3Bool(dt.Rows(0).Item("IsChangeAssetAccount"))
            tdbcAssetAccountID.SelectedValue = dt.Rows(0).Item("AssetAccountID").ToString
            tdbcAssetAccountID.Tag = tdbcAssetAccountID.Text
        End If
    End Sub

    Private Sub LoadChangeDepAccount(ByVal dt As DataTable)
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        If dt.Rows.Count > 0 Then
            chkIsChangeDepAccount.Checked = L3Bool(dt.Rows(0).Item("IsChangeDepAccount"))
            tdbcDepAccountID.SelectedValue = dt.Rows(0).Item("DepAccountID").ToString
            tdbcDepAccountID.Tag = tdbcDepAccountID.Text
        End If
    End Sub

#End Region

#Region "btnSave Events"

    Private Function AllowSave() As Boolean
        Dim sSQL As String = ""

        If chkUseAccount.Checked Then
            If tdbg3.RowCount > 0 Then
                sSQL = SQLDeleteD02T0011(tdbg2.Columns(COL2_AssetID).Text).ToString() & vbCrLf
                sSQL &= SQLInsertD02T0011s(tdbg2.Columns(COL2_AssetID).Text).ToString() & vbCrLf
                ExecuteSQL(sSQL)
            End If
        End If

        sSQL = "SELECT Top 1 1" & vbCrLf
        sSQL &= "FROM   D02T0012 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE  TranMonth = " & giTranMonth & " And TranYear = " & giTranYear & vbCrLf
        sSQL &= "       And TransactionTypeID = 'KH' And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        If ExistRecord(sSQL) Then
            If D99C0008.MsgAsk(rL3("Ky_nay_da_duoc_phan_bo") & " " & rL3("_Ban_co_muon_luu_khong") & "?") = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If

        If tdbcAssetID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ma_tai_san"))
            tdbcAssetID.Focus()
            Return False
        End If
        If tdbcChangeNo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nghiep_vu"))
            tdbcChangeNo.Focus()
            Return False
        End If

        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COL1_PercentAmount).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ty_le"))
                tabMain.SelectedTab = Tab1
                tdbg1.Focus()
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Col = COL1_PercentAmount
                tdbg1.Bookmark = i
                Return False
            End If
        Next
        If chkReceiveManage.Checked Then
            If tdbcObjectTypeID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblObjectTypeID.Text)
                tabMain.SelectedTab = Tab1
                tdbcObjectTypeID.Focus()
                Return False
            End If
            If tdbcObjectID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblObjectTypeID.Text)
                tabMain.SelectedTab = Tab1
                tdbcObjectID.Focus()
                Return False
            End If
            If tdbcEmployeeID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblEmployeeID.Text)
                tabMain.SelectedTab = Tab1
                tdbcEmployeeID.Focus()
                Return False
            End If
            If tdbcLocationID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblLocationID.Text)
                tabMain.SelectedTab = Tab1
                tdbcLocationID.Focus()
                Return False
            End If
        End If
        If chkChangeManagement.Checked Then
            If tdbcManagementObjTypeID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblManagementObjTypeID.Text)
                tabMain.SelectedTab = Tab1
                tdbcObjectTypeID.Focus()
                Return False
            End If
            If tdbcManagementObjID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblManagementObjTypeID.Text)
                tabMain.SelectedTab = Tab1
                tdbcObjectID.Focus()
                Return False
            End If
        End If
        If (chkChangeDistribute.Checked And tdbcAssetID.Columns("AssignmentTypeID").Text = "0") Then
            If (tdbcAssetID.Columns(0).Text <> "...") Then
                For i As Integer = 0 To tdbg1.RowCount - 1
                    If tdbg1(i, COL1_PercentAmount).ToString = "0" Then
                        D99C0008.MsgL3(rL3("Ty_le_phai_lon_hon_0"))
                        tabMain.SelectedTab = Tab1
                        tdbg1.Focus()
                        tdbg1.Col = COL1_PercentAmount
                        tdbg1.Bookmark = i
                        Return False
                    End If
                Next
                If (L3Int(tdbg1.Columns(COL1_PercentAmount).FooterText.ToString()) <> 100) Then
                    D99C0008.MsgL3(rL3("Tong_ty_le_phai_bang_100U"))
                    tabMain.SelectedTab = Tab1
                    tdbg1.Focus()
                    tdbg1.Col = COL1_PercentAmount
                    tdbg1.Bookmark = 0
                    Return False
                End If
            End If
        End If

        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        If chkIsChangeAssetAccount.Checked = True Then
            If tdbcAssetAccountID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblAssetAccountID.Text)
                tabMain.SelectedTab = Tab1
                tdbcAssetAccountID.Focus()
                Return False
            End If
        End If
        If chkIsChangeDepAccount.Checked = True Then
            If tdbcDepAccountID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblDepAccountID.Text)
                tabMain.SelectedTab = Tab1
                tdbcDepAccountID.Focus()
                Return False
            End If
        End If

        If chkUseAccount.Checked Then
            If Not chkCollect.Checked Then
                If tdbcVoucherTypeID.Text.Trim = "" Then
                    D99C0008.MsgNotYetChoose(rL3("Loai_phieu"))
                    tabMain.SelectedTab = Tab2
                    tdbcVoucherTypeID.Focus()
                    Return False
                End If
                If txtVoucherNo.Text.Trim = "" Then
                    D99C0008.MsgNotYetEnter(rL3("So_phieu"))
                    tabMain.SelectedTab = Tab2
                    txtVoucherNo.Focus()
                    Return False
                End If
            End If
            If tdbg3.RowCount <= 0 Then
                D99C0008.MsgNoDataInGrid()
                tabMain.SelectedTab = Tab2
                tdbg3.Focus()
                Return False
            End If

            For i As Integer = 0 To tdbg3.RowCount - 1
                If Not L3Bool(tdbg3(i, COL3_Choose)) Then
                    If tdbg3(i, COL3_DebitAccountID).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rL3("TK_no"))
                        tabMain.SelectedTab = Tab2
                        tdbg3.Focus()
                        tdbg3.SplitIndex = SPLIT0
                        tdbg3.Col = COL3_DebitAccountID
                        tdbg3.Bookmark = i
                        Return False
                    End If
                    If tdbg3(i, COL3_CreditAccountID).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rL3("TK_co"))
                        tabMain.SelectedTab = Tab2
                        tdbg3.Focus()
                        tdbg3.SplitIndex = SPLIT0
                        tdbg3.Col = COL3_CreditAccountID
                        tdbg3.Bookmark = i
                        Return False
                    End If
                    If tdbg3(i, COL3_OriginalAmount).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rL3("Nguyen_te"))
                        tabMain.SelectedTab = Tab2
                        tdbg3.Focus()
                        tdbg3.SplitIndex = SPLIT0
                        tdbg3.Col = COL3_OriginalAmount
                        tdbg3.Bookmark = i
                        Return False
                    End If
                    If tdbg3(i, COL3_ConvertedAmount).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rL3("Quy_doi"))
                        tabMain.SelectedTab = Tab2
                        tdbg3.Focus()
                        tdbg3.SplitIndex = SPLIT0
                        tdbg3.Col = COL3_ConvertedAmount
                        tdbg3.Bookmark = i
                        Return False
                    End If
                    sSQL = "SELECT TOP 1 1 FROM D90T0001 WITH(NOLOCK) WHERE AccountID = " & SQLString(tdbg3(i, COL3_DebitAccountID).ToString) & " AND GroupID = 21"
                    If ExistRecord(sSQL) Then
                        If tdbg3(i, COL3_InventoryID).ToString = "" Then
                            D99C0008.MsgNotYetEnter(rL3("Ma_hang"))
                            tabMain.SelectedTab = Tab2
                            tdbg3.Focus()
                            tdbg3.SplitIndex = SPLIT0
                            tdbg3.Col = COL3_InventoryID
                            tdbg3.Bookmark = i
                            Return False
                        End If
                        If tdbg3(i, COL3_Quantity).ToString = "" Then
                            D99C0008.MsgNotYetEnter(rL3("So_luong"))
                            tabMain.SelectedTab = Tab2
                            tdbg3.Focus()
                            tdbg3.SplitIndex = SPLIT0
                            tdbg3.Col = COL3_Quantity
                            tdbg3.Bookmark = i
                            Return False
                        End If
                    End If
                End If
            Next
            For i As Integer = 0 To tdbg2.RowCount - 1
                Dim sAssetID As String = tdbg2(i, COL2_AssetID).ToString
                Dim sAssetAccountID As String = tdbg2(i, COL2_AssetAccountID).ToString
                Dim sDepAccountID As String = tdbg2(i, COL2_DepAccountID).ToString
                'Dim sAssetAccountIDNew As String = tdbg2(i, COL2_NewAAC).ToString 
                'Dim sDepAccountIDNew As String = tdbg2(i, COL2_NewDAC).ToString
                Dim sD27PropertyProductID As String = tdbg2(i, COL2_D27PropertyProductID).ToString
                '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
                'sSQL = SQLStoreD02P2001(sAssetID, sAssetAccountID, sDepAccountID, sAssetAccountIDNew, sDepAccountIDNew, sD27PropertyProductID)
                sSQL = SQLStoreD02P2001(sAssetID, sAssetAccountID, sDepAccountID, tdbcAssetAccountID.Text, tdbcDepAccountID.Text, sD27PropertyProductID)

                Dim dtTable As DataTable = ReturnDataTable(sSQL)
                If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                    Dim sMessage As String = ConvertVietwareFToUnicode(dtTable.Rows(0).Item("Message").ToString)
                    If L3Int(dtTable.Rows(0).Item("Status")) = 1 Then
                        If D99C0008.MsgAsk(sMessage, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            Return False
                        End If
                    ElseIf L3Int(dtTable.Rows(0).Item("Status")) = 2 Then
                        D99C0008.Msg(sMessage)
                        Return False
                    End If
                End If

                'If Not CheckStore(sSQL, True) Then
                '    Return False
                'End If
            Next
        End If

        'Kiem tra TK nợ , TK có phải thuộc TSKH
        'For i As Integer = 0 To tdbg3.RowCount - 1
        '    If tdbg3(i, COL3_DebitAccountID).ToString = tdbg2.Columns(COL2_AssetAccountID).Text Or tdbg3(i, COL3_DebitAccountID).ToString = tdbg2.Columns(COL2_DepAccountID).Text Or tdbg3(i, COL3_CreditAccountID).ToString = tdbg2.Columns(COL2_AssetAccountID).Text Or tdbg3(i, COL3_CreditAccountID).ToString = tdbg2.Columns(COL2_DepAccountID).Text Then
        '        Return True
        '    Else
        '        D99C0008.MsgNotYetEnter(rL3("TK_no") & "/" & rL3("TK_co") & rL3("khong_hop_le"))
        '        tdbg3.Focus()
        '        tabMain.SelectedTab = Tab2
        '        tdbg3.SplitIndex = SPLIT0
        '        tdbg3.Col = COL3_DebitAccountID
        '        tdbg3.Bookmark = i
        '        Return False
        '    End If
        'Next
        Return True
    End Function

    Private Function AllowSaveVirtualEntry() As Boolean
        Dim dt As DataTable
        Dim sDebitAccount As String = ""
        Dim lstDebitAccount As New ArrayList
        If chkIsEliminated.Checked Then
            For iRow As Integer = 0 To tdbg2.RowCount - 1
                If _FormState = EnumFormState.FormAdd Then
                    dt = ReturnDataTable("SELECT * FROM D02T0011 WITH(NOLOCK) WHERE UserID = " & SQLString(gsUserID) & " And AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID).ToString))
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If ExistRecord("SELECT TOP 1 1 FROM D90T0001 WITH(NOLOCK) WHERE GroupID = '7' AND AccountID = " & SQLString(dt.Rows(i).Item("DebitAccountID"))) Then
                            If Not ExistRecord("SELECT TOP 1 1 FROM D02T0001 WITH(NOLOCK) WHERE AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID)) & " AND AssetAccountID = " & SQLString(dt.Rows(i).Item("DebitAccountID"))) Then
                                'If D99C0008.Msg(rl3("Nghiep_vu_nay_se_phat_sinh_but_toan_co_the_duoc_dung_de_hinh_thanh_tai_san_moi") & ". " & rl3("MSG000021"), rl3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                '    Return False
                                'Else
                                '    Return True
                                'End If
                                If lstDebitAccount.IndexOf(dt.Rows(i).Item("DebitAccountID").ToString) < 0 Then
                                    lstDebitAccount.Add(dt.Rows(i).Item("DebitAccountID").ToString)
                                End If
                            End If
                        End If
                    Next
                ElseIf _FormState = EnumFormState.FormEdit Then
                    For i As Integer = 0 To tdbg3.RowCount - 1
                        If ExistRecord("SELECT TOP 1 1 FROM D90T0001 WITH(NOLOCK) WHERE GroupID = '7' AND AccountID = " & SQLString(tdbg3(i, COL3_DebitAccountID))) Then
                            If Not ExistRecord("SELECT TOP 1 1 FROM D02T0001 WITH(NOLOCK) WHERE AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID)) & " AND AssetAccountID = " & SQLString(tdbg3(i, COL3_DebitAccountID))) Then
                                'If D99C0008.Msg(rl3("Nghiep_vu_nay_se_phat_sinh_but_toan_co_the_duoc_dung_de_hinh_thanh_tai_san_moi") & ". " & rl3("MSG000021"), rl3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                '    Return False
                                'Else
                                '    Return True
                                'End If
                                If lstDebitAccount.IndexOf(tdbg3(i, COL3_DebitAccountID).ToString) < 0 Then
                                    lstDebitAccount.Add(tdbg3(i, COL3_DebitAccountID).ToString)
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        End If

        For i As Integer = 0 To lstDebitAccount.Count - 1
            sDebitAccount &= lstDebitAccount(i).ToString & ", "
        Next

        If sDebitAccount <> "" Then
            If D99C0008.Msg(rL3("Nghiep_vu_nay_se_phat_sinh_but_toan_No") & " " & sDebitAccount.Trim.Remove(sDebitAccount.Trim.Length - 1, 1) & ". " & rL3("But_toan_nay_co_the_duoc_dung_de_hinh_thanh_tai_san_moi") & ". " & rL3("MSG000021"), rL3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If _FormState <> EnumFormState.FormEditOther Then  ' 29/11/2013 id 61503 - Không ktra khi sửa khác 
            If Not AllowSave() Then Exit Sub
        End If

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        If chkUseAccount.Checked And c1dateVoucherDate.Enabled Then
            If CheckVoucherDateInPeriod(c1dateVoucherDate.Text) = False Then
                c1dateVoucherDate.Focus()
                Exit Sub
            End If
        End If

        If _FormState <> EnumFormState.FormEditOther Then  ' 29/11/2013 id 61503 - Không ktra khi sửa khác 
            If Not AllowSaveVirtualEntry() Then Exit Sub
        End If

        btnSave.Enabled = False
        btnClose.Enabled = False
        gbSavedOK = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                '****************************************
                'Kiểm tra phiếu theo kiểu mới
                'Sinh IGE cho khóa của Phiếu trước
                _groupID = CreateIGE("D02T0012", "GroupID", "02", "GP", gsStringKey)
                'Kiểm tra phiếu

                If chkUseAccount.Checked Then
                    If tdbcVoucherTypeID.Columns("Auto").Text = "1" And bEditVoucherNo = False Then 'Sinh tự động và không nhấn F2
                        txtVoucherNo.Text = CreateIGEVoucherNoNew(tdbcVoucherTypeID, "D02T0012", _groupID)
                    Else 'Không sinh tự động hay có nhấn F2
                        If bEditVoucherNo = False Then
                            'Kiểm tra trùng Số phiếu
                            If Not chkCollect.Checked Then
                                If CheckDuplicateVoucherNoNew("D02", "D02T0012", _groupID, txtVoucherNo.Text) = True Then btnSave.Enabled = True : btnClose.Enabled = True : Me.Cursor = Cursors.Default : Exit Sub
                            End If

                        Else 'Có nhấn F2 để sửa số phiếu
                            'Insert Số phiếu vào bảng D02T5558
                            InsertD02T5558(_groupID, sOldVoucherNo, txtVoucherNo.Text)
                        End If
                        'Insert VoucherNo vào bảng D91T9111
                        InsertVoucherNoD91T9111(txtVoucherNo.Text, "D02T0012", _groupID)
                    End If

                    bEditVoucherNo = False
                    sOldVoucherNo = ""
                    bFirstF2 = False
                End If

                '****************************************

                'Cap nhat tinh trang
                sSQL.Append(SaveAddNew() & vbCrLf)
                For i As Integer = 0 To tdbg2.RowCount - 1
                    sSQL.Append(" Update D02T0001")
                    sSQL.Append(" Set AssetConditionID = " & SQLString(tdbg2(i, COL2_AssetConditionID)))
                    sSQL.Append(" WHERE AssetID = " & SQLString(tdbg2(i, COL2_AssetID)) & vbCrLf)
                Next
            Case EnumFormState.FormEdit
                sSQL.Append(SaveEdit() & vbCrLf)
                sSQL.Append(SaveAddNew)
            Case EnumFormState.FormEditOther ' 29/11/2013 id 61503
                sSQL.Append(SQLStoreD02P2006)

        End Select
        'ID 93793 12.12.2016
        If Not CheckStore(SQLStoreD02P5009) Then
            btnSave.Enabled = True
            btnClose.Enabled = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If _FormState <> EnumFormState.FormEditOther Then ' 29/11/2013 id 61503 - Không ktra khi sưa khác
            For i As Integer = 0 To tdbg2.RowCount - 1
                Dim sAssetID As String = tdbg2(i, COL2_AssetID).ToString
                Dim sBatchID As String = tdbg2(i, COL2_BatchID).ToString
                If Not CheckStore(SQLStoreD02P5010(sAssetID, sBatchID)) Then
                    btnClose.Enabled = True
                    btnSave.Enabled = True
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Next
        End If

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            If ComboValue(tdbcAssetID) = "..." Then
                AssetID = dtRecordSet_Asset.Rows(0).Item("AssetID").ToString
            Else
                AssetID = tdbcAssetID.Text
            End If

            If L3Int(ReturnValueC1Combo(tdbcChangeNo, "IsEliminated")) = 1 Then
                For i As Integer = 0 To tdbg2.RowCount - 1
                    ExecuteSQL(SQLStoreD02P2070(tdbg2(i, COL2_BatchID).ToString))
                Next
            End If

            ExecuteSQLNoTransaction(SQLStoreD02P7777("D02F2003", "D02T0011")) '4/7/2017, Phạm Thị Thu: id 98475-Bổ sung cơ chế thực hiện store xóa dữ liệu bảng tạm Form D02F2003

            '24/3/2022, Đinh Văn Khanh:id 217076-SVI_ Cập nhật PP khấu hao TSCD cho tất cả các TS có nghiệp vụ tác động
            If (_FormState = EnumFormState.FormAdd And chkIsNotCalDep.Checked = True) Or _FormState = EnumFormState.FormEdit Then ExecuteSQLNoTransaction(SQLUpdateD02T0055.ToString)

            gbSavedOK = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnAttachment.Enabled = True
                    btnNext.Enabled = True
                    btnPrint.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = False
                    btnClose.Focus()
                Case EnumFormState.FormEditOther
                    btnSave.Enabled = False
                    btnClose.Focus()
            End Select
        Else
            If _FormState = EnumFormState.FormAdd Then
                DeleteVoucherNoD91T9111_Transaction(txtVoucherNo.Text, "D02T0012", "VoucherNo", tdbcVoucherTypeID, bEditVoucherNo)
            End If
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2070
    '# Created User: HUỲNH KHANH
    '# Created Date: 04/03/2015 05:07:58
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2070(ByVal sBatchID As String) As String
        Dim sSQL As String = ""

        sSQL &= ("-- Update du lieu trang thai san pham BDS va ton kho BDS " & vbCrLf)
        sSQL &= "Exec D02P2070 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcAssetID)) & COMMA 'AssetID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcAssetID, "D27PropertyProductID")) & COMMA 'PropertyProductID, varchar[50], NOT NULL
        sSQL &= SQLString(sBatchID) 'BatchID, varchar[50], NOT NULL
        Return sSQL
    End Function

    Private Function SaveAddNew() As String
        Dim sSQL As New StringBuilder

        'Luu Tab1
        Dim nRowCountBatchID As Long
        Dim iFirstIGEBatchID As Long
        Dim sBatchID As String = ""

        For i As Integer = 0 To tdbg2.RowCount - 1
            If tdbg2(i, COL2_BatchID).ToString = "" Then
                nRowCountBatchID += 1
            End If
        Next

        'Dem so lan sinh khoa cho HistoryID
        Dim nRowCountHistoryID As Long
        Dim iFirstIGEHistoryID As Long
        Dim sHistoryID As String = ""

        'Luu thay doi tieu thuc phan bo
        If chkChangeDistribute.Checked Then
            If _FormState = EnumFormState.FormAdd Then
                For j As Integer = 0 To tdbg1.RowCount - 1
                    tdbg1(j, COL1_HistoryID) = ""
                Next
            End If

            For i As Integer = 0 To tdbg1.RowCount - 1
                If tdbg1(i, COL1_HistoryID).ToString = "" Then
                    nRowCountHistoryID += 1
                End If
            Next
        End If

        'Thay doi bo phan quan ly
        If chkReceiveManage.Checked Then nRowCountHistoryID += 1
        'Thay doi bo phan tiep nhan ''ID : 214915
        If chkChangeManagement.Checked Then nRowCountHistoryID += 1
        'Thay doi tinh trang khau hao
        If chkChangeDepreciation.Checked Then nRowCountHistoryID += 1
        'Thay doi tinh trang su dung
        If chkChangeUsing.Checked Then nRowCountHistoryID += 1
        'Thay doi thoi gian khau hao
        If chkChangeDepreciationTime.Checked Then nRowCountHistoryID += 1
        'Giam tai san
        If chkIsEliminated.Checked Then nRowCountHistoryID += 1

        'Thay đổi tài khoản tài sản
        If chkIsChangeAssetAccount.Checked Then
            Dim sSQLSub As String = ""

            For i As Integer = 0 To tdbg2.RowCount - 1
                sSQLSub = "Select 1 from D02T5010 with(NOLOCK)" & vbCrLf 'NOLOCK
                sSQLSub &= " Where " & vbCrLf
                sSQLSub &= " HistoryTypeID = " & SQLString("AAC") & vbCrLf
                sSQLSub &= " AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
                sSQLSub &= " AND EndMonth = 12 AND EndYear = 9999" & vbCrLf
                sSQLSub &= " AND AssetID = " & SQLString(tdbg2(i, COL2_AssetID)) 'varchar[20], NOT NULL
                If Not ExistRecord(sSQLSub) Then
                    nRowCountHistoryID += 1
                End If
            Next

            nRowCountHistoryID = nRowCountHistoryID + 2
        End If

        'Thay đổi tài khoản khấu hao
        If chkIsChangeDepAccount.Checked Then
            Dim sSQLSub As String = ""

            For i As Integer = 0 To tdbg2.RowCount - 1
                sSQLSub = "Select 1 from D02T5010 with(NOLOCK)" & vbCrLf
                sSQLSub &= " Where " & vbCrLf
                sSQLSub &= " HistoryTypeID = " & SQLString("DAC") & vbCrLf
                sSQLSub &= " AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
                sSQLSub &= " AND EndMonth = 12 AND EndYear = 9999" & vbCrLf
                sSQLSub &= " AND AssetID = " & SQLString(tdbg2(i, COL2_AssetID)) 'varchar[20], NOT NULL
                If Not ExistRecord(sSQLSub) Then
                    nRowCountHistoryID += 1
                End If
            Next

            nRowCountHistoryID = nRowCountHistoryID + 2
        End If

        nRowCountHistoryID = tdbg2.RowCount * nRowCountHistoryID

        'Thuc hien luu
        For i As Integer = 0 To tdbg2.RowCount - 1

            If _FormState = EnumFormState.FormAdd Then
                If tdbg2(i, COL2_BatchID).ToString = "" Then
                    sBatchID = CreateIGENewS("D02T0202", "BatchID", "02", "BF", gsStringKey, sBatchID, nRowCountBatchID, iFirstIGEBatchID)
                    tdbg2(i, COL2_BatchID) = sBatchID
                End If
            Else
                If tdbg2(i, COL2_BatchID).ToString = "" Then
                    tdbg2(i, COL2_BatchID) = _batchID
                End If
            End If

            'Luu phieu nghiep vu tac dong
            sSQL.Append(SQLInsertD02T0202(i).ToString() & vbCrLf)

            'Luu thay doi tieu thuc phan bo
            If chkChangeDistribute.Checked Then
                'Sinh IGE cho HistoryID

                If _FormState = EnumFormState.FormAdd Then
                    For j As Integer = 0 To tdbg1.RowCount - 1
                        tdbg1(j, COL1_HistoryID) = ""
                    Next
                End If

                For j As Integer = 0 To tdbg1.RowCount - 1
                    If tdbg1(j, COL1_HistoryID).ToString = "" Then
                        sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                        tdbg1(j, COL1_HistoryID) = sHistoryID
                    End If
                Next

                sSQL.Append(SQLUpdateD02T5000(tdbg2(i, COL2_AssetID).ToString, "AS").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5000s(i).ToString() & vbCrLf)
            End If

            'Luu Thay doi bo phan quan ly
            If chkReceiveManage.Checked Or chkChangeManagement.Checked Then
                sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                sSQL.Append(SQLUpdateD02T5000(tdbg2(i, COL2_AssetID).ToString, "OB").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5000(i, "OB", sHistoryID).ToString() & vbCrLf)
            End If

            'Thay doi tinh trang khau hao
            If chkChangeDepreciation.Checked Then
                sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                sSQL.Append(SQLUpdateD02T5000(tdbg2(i, COL2_AssetID).ToString, "SD").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5000(i, "SD", sHistoryID).ToString() & vbCrLf)
            End If

            'Thay doi tinh trang su dung
            If chkChangeUsing.Checked Then
                sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                sSQL.Append(SQLUpdateD02T5000(tdbg2(i, COL2_AssetID).ToString, "SU").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5000(i, "SU", sHistoryID).ToString() & vbCrLf)
            End If

            'Thay doi thoi gian khau hao
            If chkChangeDepreciationTime.Checked Then
                sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                sSQL.Append(SQLUpdateD02T5000(tdbg2(i, COL2_AssetID).ToString, "SL").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5000(i, "SL", sHistoryID).ToString() & vbCrLf)
                sSQL.Append(SQLUpdateD02T0001(i).ToString() & vbCrLf)
            End If

            'Thay đổi tài khoản tài sản
            If chkIsChangeAssetAccount.Checked Then
                Dim sSQLSub As String = "Select 1 from D02T5010 with(NOLOCK)" & vbCrLf 'NOLOCK
                sSQLSub &= " Where " & vbCrLf
                sSQLSub &= " HistoryTypeID = " & SQLString("AAC") & vbCrLf
                sSQLSub &= " AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
                sSQLSub &= " AND EndMonth = 12 AND EndYear = 9999" & vbCrLf
                sSQLSub &= " AND AssetID = " & SQLString(tdbg2(i, COL2_AssetID)) 'varchar[20], NOT NULL

                If Not ExistRecord(sSQLSub) Then 'Nếu tài sản chưa có dòng dữ liệu thì insert 
                    'Dim sHistoryIDSub As String = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                    sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                    sSQL.Append(SQLInsertD02T5010(i, "AAC", sHistoryID, tdbg2(i, COL2_TranMonth).ToString, tdbg2(i, COL2_TranYear).ToString, tdbg2(i, COL2_AssetID).ToString, "", tdbcAssetAccountID.Text).ToString() & vbCrLf)
                End If

                sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                sSQL.Append(SQLUpdateD02T5010(i, "AAC").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5010(i, "AAC", sHistoryID, giTranMonth.ToString, giTranYear.ToString, tdbg2(i, COL2_BatchID).ToString, _groupID, tdbcAssetAccountID.Text).ToString() & vbCrLf)

                '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
                'Thay đổi tài khoản tài sản
                sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                sSQL.Append(SQLUpdateD02T5000(tdbg2(i, COL2_AssetID).ToString, "AAC").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5000_ChangeAssetAccount(sHistoryID, tdbg2(i, COL2_AssetID).ToString, tdbg2(i, COL2_BatchID).ToString).ToString() & vbCrLf)
                sSQL.Append("UPDATE D02T0001 SET AssetAccountID = " & SQLString(tdbcAssetAccountID.Text) & " WHERE AssetID = " & SQLString(tdbg2(i, COL2_AssetID).ToString) & vbCrLf)
            End If

            'Thay đổi tài khoản khấu hao 
            If chkIsChangeDepAccount.Checked Then 'Nếu tài sản chưa có dòng dữ liệu thì insert 
                Dim sSQLSub As String = "Select 1 from D02T5010 with(NOLOCK)" & vbCrLf
                sSQLSub &= " Where " & vbCrLf
                sSQLSub &= " HistoryTypeID = " & SQLString("DAC") & vbCrLf
                sSQLSub &= " AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
                sSQLSub &= " AND EndMonth = 12 AND EndYear = 9999" & vbCrLf
                sSQLSub &= " AND AssetID = " & SQLString(tdbg2(i, COL2_AssetID)) 'varchar[20], NOT NULL

                If Not ExistRecord(sSQLSub) Then 'Nếu tài sản chưa có dòng dữ liệu thì insert 
                    'Dim sHistoryIDSub As String = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                    sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                    sSQL.Append(SQLInsertD02T5010(i, "DAC", sHistoryID, tdbg2(i, COL2_TranMonth).ToString, tdbg2(i, COL2_TranYear).ToString, tdbg2(i, COL2_AssetID).ToString, "", tdbcDepAccountID.Text).ToString() & vbCrLf)
                End If
                sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                sSQL.Append(SQLUpdateD02T5010(i, "DAC").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5010(i, "DAC", sHistoryID, giTranMonth.ToString, giTranYear.ToString, tdbg2(i, COL2_BatchID).ToString, _groupID, tdbcDepAccountID.Text).ToString() & vbCrLf)

                '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
                'Thay đổi tài khoản khấu hao
                sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                sSQL.Append(SQLUpdateD02T5000(tdbg2(i, COL2_AssetID).ToString, "DAC").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5000_ChangeDepAccount(sHistoryID, tdbg2(i, COL2_AssetID).ToString, tdbg2(i, COL2_BatchID).ToString).ToString() & vbCrLf)
                sSQL.Append("UPDATE D02T0001 SET DepAccountID = " & SQLString(tdbcDepAccountID.Text) & " WHERE AssetID = " & SQLString(tdbg2(i, COL2_AssetID).ToString) & vbCrLf)
            End If

            'Giam tai san
            If chkIsEliminated.Checked Then
                sHistoryID = CreateIGENewS("D02T5000", "HistoryID", "02", "HA", gsStringKey, sHistoryID, nRowCountHistoryID, iFirstIGEHistoryID)
                sSQL.Append("UPDATE D02T0001 SET IsDisposed = 1 WHERE AssetID = " & SQLString(tdbg2(i, COL2_AssetID).ToString) & vbCrLf)
                sSQL.Append(SQLUpdateD02T5000(tdbg2(i, COL2_AssetID).ToString, "IL").ToString() & vbCrLf)
                sSQL.Append(SQLInsertD02T5000(i, "IL", sHistoryID).ToString() & vbCrLf)
            End If

            'Giam thoi gian khau hao
            If chkDepreciationTime.Checked And dtRecordSet_Asset IsNot Nothing Then
                sSQL.Append(SQLInsertD02T0203s(tdbg2(i, COL2_AssetID).ToString).ToString() & vbCrLf)
            End If

            '************************************************************************
            'Luu phieu tai chinh (Tab2)
            If chkUseAccount.Checked Then
                '  If L3Bool(tdbg3(0, COL3_Choose)) Then 
                If chkCollect.Checked Then ' Sữa giống VB6 3/2/2012
                    sSQL.Append(SQLUpdateD02T0012s(i).ToString() & vbCrLf)
                Else
                    sSQL.Append(SQLInsertD02T0012s(i).ToString() & vbCrLf)
                End If
            End If

        Next

        Return sSQL.ToString
    End Function

    Private Function SaveEdit() As String
        Dim sSQL As New StringBuilder
        'Update lai trang thai cua Mº XDCB CipID tai D02T0100 truoc khi luu Edit
        sSQL.Append("Update D02T0100 Set Status = 0 " & vbCrLf)
        sSQL.Append("Where CipID In (   Select CipID")
        sSQL.Append("                   From D02T0012 WITH(NOLOCK) " & vbCrLf)
        sSQL.Append("                   Where   AssetID = " & SQLString(tdbcAssetID.Text) & vbCrLf)
        sSQL.Append("                           AND BatchID = " & SQLString(_batchID) & vbCrLf)
        sSQL.Append("                           AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append("               )" & vbCrLf)

        'Thøc hiÖn Edit = Delete + Insert
        sSQL.Append("DELETE D02T0202 " & vbCrLf)
        sSQL.Append("WHERE AssetID = " & SQLString(tdbcAssetID.Text) & vbCrLf)
        sSQL.Append("AND BatchID = " & SQLString(_batchID) & vbCrLf)
        sSQL.Append("AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf)

        sSQL.Append("DELETE D02T5000 " & vbCrLf)
        sSQL.Append("WHERE AssetID = " & SQLString(tdbcAssetID.Text) & vbCrLf)
        sSQL.Append("AND BatchID = " & SQLString(_batchID) & vbCrLf)
        sSQL.Append("AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf)

        sSQL.Append(SQLDeleteD02T5010() & vbCrLf) '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ

        sSQL.Append("DELETE D02T0012 " & vbCrLf)
        sSQL.Append("WHERE AssetID = " & SQLString(tdbcAssetID.Text) & vbCrLf)
        sSQL.Append("AND BatchID = " & SQLString(_batchID) & vbCrLf)
        sSQL.Append("AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf)

        'Cho phÇn ¢Ünh kho¶n
        sSQL.Append("DELETE D02T0012 " & vbCrLf)
        sSQL.Append("WHERE AssetID = " & SQLString(tdbcAssetID.Text) & vbCrLf)
        sSQL.Append("AND BatchID = " & SQLString(_batchID) & vbCrLf)
        sSQL.Append("AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append("AND SplitBatchID = " & SQLString(_batchID) & vbCrLf)

        sSQL.Append("DELETE D02T0012 " & vbCrLf)
        sSQL.Append("WHERE Isnull(AssetID,'') = '' " & vbCrLf)
        sSQL.Append("AND Status = 0" & vbCrLf)
        sSQL.Append("AND Posted = 0" & vbCrLf)
        sSQL.Append("AND BatchID = " & SQLString(_batchID) & vbCrLf)
        sSQL.Append("AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append("AND SplitBatchID = " & SQLString(_batchID) & vbCrLf)

        sSQL.Append("UPDATE D02T0012 " & vbCrLf)
        sSQL.Append("SET AssetID = null, Status = 0, SplitBatchID = null " & vbCrLf)
        sSQL.Append("WHERE AssetID = " & SQLString(tdbcAssetID.Text) & vbCrLf)
        sSQL.Append("AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append("AND TranMonth = " & SQLString(giTranMonth) & vbCrLf)
        sSQL.Append("AND TranYear = " & SQLString(giTranYear) & vbCrLf)
        sSQL.Append("AND SplitBatchID = " & SQLString(_batchID) & vbCrLf)

        'Cho thoi gian khau hao
        sSQL.Append("DELETE D02T0203 " & vbCrLf)
        sSQL.Append("WHERE AssetID = " & SQLString(tdbcAssetID.Text) & vbCrLf)
        sSQL.Append("AND BatchID = " & SQLString(_batchID) & vbCrLf)

        'Cap nhat tinh trang
        sSQL.Append("DELETE D02T0203 " & vbCrLf)
        sSQL.Append("WHERE AssetID = " & SQLString(tdbcAssetID.Text) & vbCrLf)
        sSQL.Append("AND BatchID = " & SQLString(_batchID) & vbCrLf)

        sSQL.Append("--Cap nhat tinh trang" & vbCrLf)
        For i As Integer = 0 To tdbg2.RowCount - 1
            sSQL.Append(" Update D02T0001")
            sSQL.Append(" Set AssetConditionID = " & SQLString(tdbg2(i, COL2_AssetConditionID)))
            sSQL.Append(" WHERE AssetID = " & SQLString(tdbg2(i, COL2_AssetID)) & vbCrLf)
        Next

        Return sSQL.ToString
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD02T5010
    '# Created User: 
    '# Created Date: 18/11/2021 04:51:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD02T5010() As String
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu " & vbCrLf)
        sSQL &= "Delete From D02T5010 Where AssetID = " & SQLString(tdbcAssetID.Text) & " AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= " AND BatchID = " & SQLString(_batchID)
        Return sSQL
    End Function

#End Region

#Region "Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2001
    '# Created User: HUỲNH KHANH
    '# Created Date: 11/03/2011 11:00:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2001(ByVal sAssetID As String, ByVal sAssetAccountID As String, ByVal sDepAccountID As String, ByVal sAssetAccountIDNew As String, ByVal sDepAccountIDNew As String, ByVal sD27PropertyProductID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P2001 "
        sSQL &= SQLString(sAssetID) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkCollect.Checked) & COMMA 'Collect, bit, NOT NULL
        sSQL &= SQLString(sAssetAccountID) & COMMA 'AssetAccountID, varchar[20], NOT NULL
        sSQL &= SQLString(sDepAccountID) & COMMA 'DepAccountID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsChangeAssetAccount.Checked) & COMMA 'IsChangeAssetAccount, int, NOT NULL
        sSQL &= SQLNumber(chkIsChangeDepAccount.Checked) & COMMA 'IsChangeDepAccount, int, NOT NULL
        sSQL &= SQLString(sAssetAccountIDNew) & COMMA 'AssetAccountIDNew, varchar[20], NOT NULL
        sSQL &= SQLString(sDepAccountIDNew) & COMMA 'DepAccountIDNew, varchar[20], NOT NULL
        sSQL &= SQLString(sD27PropertyProductID) & COMMA 'D27PropertyProductID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString("D02F2003") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5002
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 07/03/2011 01:18:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5002(ByVal strFind As String, Optional ByVal iMode As Integer = 0) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P5002 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_batchID) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString(_assetID) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString(strFind) & COMMA 'strFind, varchar[500], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5003
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 07/03/2011 01:08:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5003(ByVal strFind As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P5003 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_batchID) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString(_assetID) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= strFind & COMMA 'strFind, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5004
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 10/03/2011 08:32:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5004(ByVal strFind As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P5004 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_batchID) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString(_assetID) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString(strFind) & COMMA 'strFind, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5010
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 11/03/2011 11:06:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5010(ByVal sAssetID As String, ByVal sBatchID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P5010 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sAssetID) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbcChangeNo.Text) & COMMA 'ChangeNo, varchar[20], NOT NULL
        sSQL &= SQLString(IIf(gsLanguage = "84", "0", "1").ToString) & COMMA 'Language, tinyint, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWareHouseID)) & COMMA 'AssetWHID, varchar[20], NOT NULL
        sSQL &= SQLString(sBatchID) 'BatchID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD02T0011
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 10/03/2011 09:19:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD02T0011(ByVal sAssetID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D02T0011"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & vbCrLf
        sSQL &= " AND HostID  = " & SQLString(My.Computer.Name) & " AND FormID  = " & SQLString(Me.Name) & vbCrLf
        If sAssetID <> "" Then
            sSQL &= " AND AssetID = " & SQLString(sAssetID)
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T0011s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 10/03/2011 09:28:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T0011s(ByVal sAssetID As String) As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To tdbg3.RowCount - 1
            sSQL.Append("Insert Into D02T0011(")
            sSQL.Append("UserID, DivisionID, AssetID, TransactionID, ")
            sSQL.Append("TransactionTypeID, RefNo, ")
            sSQL.Append("RefDate, SeriNo, Description, ObjectTypeID, ObjectID, ")
            sSQL.Append("ExchangeRate, DebitAccountID, CreditAccountID, OriginalAmount, ")
            sSQL.Append("ConvertedAmount, SourceID, CipID, Ana01ID, Ana02ID, ")
            sSQL.Append("Ana03ID, Ana04ID, Ana05ID, Ana06ID, Ana07ID, ")
            sSQL.Append("Ana08ID, Ana09ID, Ana10ID, TranMonth, TranYear, ")
            sSQL.Append("ModuleID, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, Quantity, InventoryID, UnitID,IsNotAllocate,")
            sSQL.Append("ProjectID, ProjectName, TaskID, TaskName,FormID, HostID, PeriodID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(sAssetID) & COMMA) 'AssetID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_TransactionID)) & COMMA) 'TransactionID, varchar[20], NULL
            '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
            sSQL.Append(SQLString(tdbg3(i, COL3_TransactionTypeID)) & COMMA) 'TransactionTypeID, varchar[20], NOT NULL

            sSQL.Append(SQLString(tdbg3(i, COL3_RefNo)) & COMMA) 'RefNo, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(tdbg3(i, COL3_RefDate)) & COMMA) 'RefDate, datetime, NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_SeriNo)) & COMMA) 'SeriNo, varchar[20], NOT NULL
            sSQL.Append("N" & SQLString(tdbg3(i, COL3_Description)) & COMMA) 'Description, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_ObjectTypeID)) & COMMA) 'ObjectTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_ObjectID)) & COMMA) 'ObjectID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg3(i, COL3_ExchangeRate), DxxFormat.ExchangeRateDecimals) & COMMA) 'ExchangeRate, money, NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_DebitAccountID)) & COMMA) 'DebitAccountID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_CreditAccountID)) & COMMA) 'CreditAccountID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg3(i, COL3_OriginalAmount), DxxFormat.DecimalPlaces) & COMMA) 'OriginalAmount, money, NOT NULL
            sSQL.Append(SQLMoney(tdbg3(i, COL3_ConvertedAmount), DxxFormat.D90_ConvertedDecimals) & COMMA) 'ConvertedAmount, money, NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_SourceID)) & COMMA) 'SourceID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_CipID)) & COMMA) 'CipID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana01ID)) & COMMA) 'Ana01ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana02ID)) & COMMA) 'Ana02ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana03ID)) & COMMA) 'Ana03ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana04ID)) & COMMA) 'Ana04ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana05ID)) & COMMA) 'Ana05ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana06ID)) & COMMA) 'Ana06ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana07ID)) & COMMA) 'Ana07ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana08ID)) & COMMA) 'Ana08ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana09ID)) & COMMA) 'Ana09ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_Ana10ID)) & COMMA) 'Ana10ID, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
            sSQL.Append(SQLString(IIf(tdbg3(i, COL3_ModuleID).ToString = "", "02", tdbg3(i, COL3_ModuleID).ToString)) & COMMA) 'ModuleID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20],  NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            'Them ngay 3/12/2012 theo incident 52673 cua Bảo Trân bởi Văn Vinh
            sSQL.Append(SQLMoney(tdbg3(i, COL3_Quantity), DxxFormat.D08_QuantityDecimals) & COMMA) 'Quantity, decimal(28, 8), NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_InventoryID)) & COMMA) 'InventoryID, nvarchar(20), NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_UnitID)) & COMMA) 'UnitID, nvarchar(20), NOT NULL
            'ID 86630 25.05.2016
            sSQL.Append(SQLNumber(tdbg3(i, COL3_IsNotAllocate)) & COMMA) 'IsNotAllocate, nvarchar(20), NOT NULL

            sSQL.Append(SQLString(tdbg3(i, COL3_ProjectID)) & COMMA) 'ProjectID, nvarchar(20), NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg3(i, COL3_ProjectName), gbUnicode, True) & COMMA) 'ProjectName, nvarchar(20), NOT NULL
            sSQL.Append(SQLString(tdbg3(i, COL3_TaskID)) & COMMA) 'TaskID, nvarchar(20), NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg3(i, COL3_TaskName), gbUnicode, True) & COMMA) 'TaskName, nvarchar(20), NOT NULL
            sSQL.Append(SQLString(Me.Name) & COMMA) 'FormID, nvarchar(20), NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, nvarchar(20), NOT NULL
            '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
            sSQL.Append(SQLString(tdbg3(i, COL3_PeriodID))) 'PeriodID, varchar[20], NOT NULL

            sSQL.Append(") ")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T0202
    '# Created User: HUỲNH KHANH
    '# Created Date: 17/10/2014 03:42:51
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T0202(ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        sSQL.Append("Insert Into D02T0202(" & vbCrLf)
        sSQL.Append("BatchID, AssetID, ChangeNo, TranMonth, TranYear, " & vbCrLf)
        sSQL.Append("DivisionID, ChangeDate, DecisionNo, " & vbCrLf)
        sSQL.Append("CreateDate, CreateUserID, LastModifyDate, LastModifyUserID, " & vbCrLf)
        sSQL.Append("Extend, GroupID, Notes1U, Notes2U, Notes3U,EffectReasonID," & vbCrLf)
        sSQL.Append("Date01, Date02, Date03, Date04, Date05, " & vbCrLf)
        sSQL.Append("Str01U, Str02U, Str03U, Str04U, Str05U, DescriptionU, " & vbCrLf)
        sSQL.Append("AssetConditionID, AssetConditionNameU,SuggestorID, SuggestorNameU, ")
        '24/3/2022, Đinh Văn Khanh:id 217076-SVI_ Cập nhật PP khấu hao TSCD cho tất cả các TS có nghiệp vụ tác động
        sSQL.Append("IsNotCalDep")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'BatchID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbg2(iRow, COL2_AssetID)) & COMMA) 'AssetID, varchar[20], NULL
        sSQL.Append(SQLString(tdbcChangeNo.Text) & COMMA) 'ChangeNo, varchar[20], NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA & vbCrLf) 'TranYear, smallint, NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateChangeDate.Text) & COMMA) 'ChangeDate, datetime, NULL
        sSQL.Append(SQLString(txtDecisionNo.Text) & COMMA & vbCrLf) 'DecisionNo, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA & vbCrLf) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append(SQLNumber(chkDepreciationTime.Checked) & COMMA) 'Extend, tinyint, NOT NULL
        sSQL.Append(SQLString(_groupID) & COMMA) 'GroupID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotes1.Text, gbUnicode, True) & COMMA) 'Notes1U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotes2.Text, gbUnicode, True) & COMMA) 'Notes2U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotes3.Text, gbUnicode, True) & COMMA) 'Notes3U, nvarchar, NOT NULL
        sSQL.Append(SQLString(tdbcEffectReasonID.Text) & COMMA & vbCrLf) 'EffectReasonID
        sSQL.Append(SQLDateSave(c1dateDate01.Value) & COMMA) 'Date01, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateDate02.Value) & COMMA) 'Date02, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateDate03.Value) & COMMA) 'Date03, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateDate04.Value) & COMMA) 'Date04, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateDate05.Value) & COMMA & vbCrLf) 'Date05, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtStr01, True) & COMMA) 'Str01U, nvarchar[1000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtStr02, True) & COMMA) 'Str02U, nvarchar[1000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtStr03, True) & COMMA) 'Str03U, nvarchar[1000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtStr04, True) & COMMA) 'Str04U, nvarchar[1000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtStr05, True) & COMMA) 'Str05U, nvarchar[1000], NOT NULL

        sSQL.Append(SQLStringUnicode(tdbg2(iRow, COL2_Description), gbUnicode, True) & COMMA & vbCrLf) 'DescriptionU, nvarchar[1000], NOT NULL
        sSQL.Append(SQLString(tdbg2(iRow, COL2_AssetConditionID)) & COMMA) 'AssetConditionID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(tdbg2(iRow, COL2_AssetConditionName), gbUnicode, True) & COMMA) 'AssetConditionNameU, nvarchar[500], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcSuggestorID)) & COMMA) 'SuggestorID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(ReturnValueC1Combo(tdbcSuggestorID, "SuggestorName"), gbUnicode, True) & COMMA) 'SuggestorNameU, nvarchar[500], NOT NULL

        '24/3/2022, Đinh Văn Khanh:id 217076-SVI_ Cập nhật PP khấu hao TSCD cho tất cả các TS có nghiệp vụ tác động
        If L3Byte(ReturnValueC1Combo(tdbcChangeNo, "UseAccount")) = 1 Then
            sSQL.Append(SQLNumber(chkIsNotCalDep.Checked)) 'IsNotCalDep, tinyint, NOT NULL
        Else
            sSQL.Append(SQLNumber(0)) 'IsNotCalDep, tinyint, NOT NULL
        End If

        sSQL.Append(")")
        sRet.Append(sSQL.ToString & vbCrLf)
        sSQL.Remove(0, sSQL.Length)

        Return sRet
    End Function

    Private Function SQLUpdateD02T0055() As StringBuilder
        '24/3/2022, Đinh Văn Khanh:id 217076-SVI_ Cập nhật PP khấu hao TSCD cho tất cả các TS có nghiệp vụ tác động
        Dim sSQL As New StringBuilder
        sSQL.Append("IF EXISTS (SELECT TOP 1 1 FROM D02T0202 T1 " & vbCrLf)
        sSQL.Append("LEFT JOIN D02T0201 T2 ON T1.ChangeNo = T2.ChangeNo " & vbCrLf) 'tinyint, NOT NULL
        sSQL.Append("WHERE T2.UseAccount = 1 AND T1.ChangeNo = " & SQLString(tdbcChangeNo.Text) & ") " & vbCrLf) 'smallint, NOT NULL
        sSQL.Append("BEGIN " & vbCrLf)
        sSQL.Append("UPDATE T1 SET T1.IsNotCalDep = T2.IsNotCalDep " & vbCrLf)
        sSQL.Append("FROM D02T0055 T1 WITH(NOLOCK) " & vbCrLf)
        sSQL.Append("INNER JOIN	D02T0202 T2 WITH(NOLOCK) " & vbCrLf)
        sSQL.Append("ON T1.AssetID = T2.AssetID " & vbCrLf)
        sSQL.Append("WHERE T2.GroupID = " & SQLString(_groupID))
        sSQL.Append("END " & vbCrLf)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T5000
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 11/03/2011 01:39:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T5000(sAssetID As String, ByVal sHistoryTypeID As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D02T5000 Set ")
        sSQL.Append("EndMonth = " & SQLNumber(giTranMonth) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("EndYear = " & SQLNumber(giTranYear)) 'smallint, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("HistoryTypeID = " & SQLString(sHistoryTypeID))
        sSQL.Append(" AND DivisionID = " & SQLString(gsDivisionID))
        sSQL.Append(" AND EndMonth = 12 AND EndYear = 9999")
        sSQL.Append(" AND AssetID = " & SQLString(sAssetID)) 'varchar[20], NOT NULL
        If sHistoryTypeID = "OB" Then
            If chkReceiveManage.Checked = True OrElse (chkReceiveManage.Checked = False AndAlso chkChangeManagement.Checked = False) Then
                sSQL.Append(" AND (IsReceive = 1 OR (IsManagement = 0 AND IsReceive = 0))")
            ElseIf chkChangeManagement.Checked = True Then
                sSQL.Append(" AND IsManagement = 1")
            End If
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T5010
    '# Created User: HUỲNH KHANH
    '# Created Date: 18/12/2014 02:27:57
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T5010(ByVal iRow As Integer, ByVal sHistoryTypeID As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Cap nhat TKTS - TKKH" & vbCrLf)
        sSQL.Append("Update D02T5010 Set ")
        sSQL.Append("EndMonth = " & SQLNumber(giTranMonth) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("EndYear = " & SQLNumber(giTranYear)) 'int, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append(" HistoryTypeID = " & SQLString(sHistoryTypeID))
        sSQL.Append(" AND DivisionID = " & SQLString(gsDivisionID))
        sSQL.Append(" AND EndMonth = 12 AND EndYear = 9999")
        sSQL.Append(" AND AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID))) 'varchar[20], NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T5000s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 11/03/2011 02:03:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T5000s(ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To tdbg1.RowCount - 1
            sSQL.Append("Insert Into D02T5000(")
            sSQL.Append("HistoryID, DivisionID, AssetID, BatchID, ")
            sSQL.Append("BeginMonth, BeginYear, EndMonth, EndYear, HistoryTypeID, ")
            sSQL.Append("Status, InstanceID, ")
            sSQL.Append("PercentAmount, AssignmentID, ")
            sSQL.Append("CreateDate, CreateUserID, LastModifyUserID, ")
            sSQL.Append("LastModifyDate, GroupID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg1(i, COL1_HistoryID)) & COMMA) 'HistoryID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(iRow, COL2_AssetID)) & COMMA) 'AssetID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'BatchID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'BeginMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'BeginYear, smallint, NOT NULL
            sSQL.Append(SQLNumber(12) & COMMA) 'EndMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(9999) & COMMA) 'EndYear, smallint, NOT NULL
            sSQL.Append(SQLString("AS") & COMMA) 'HistoryTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'Status, tinyint, NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'InstanceID, tinyint, NOT NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL1_PercentAmount), DxxFormat.DefaultNumber2) & COMMA) 'PercentAmount, money, NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_AssignmentID)) & COMMA) 'AssignmentID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
            sSQL.Append(SQLString(_groupID)) 'GroupID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T5000
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 11/03/2011 02:37:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T5000(ByVal iRow As Integer, ByVal sHistoryTypeID As String, ByVal sHistoryID As String) As StringBuilder
        Dim sSQL As New StringBuilder

        sSQL.Append("Insert Into D02T5000(")
        sSQL.Append("HistoryID, DivisionID, AssetID, BatchID, ")
        sSQL.Append("BeginMonth, BeginYear, EndMonth, EndYear, HistoryTypeID, ")
        sSQL.Append("Status, InstanceID, ")

        Select Case sHistoryTypeID
            Case "OB" 'Thay doi bo phan quan ly
                sSQL.Append("ObjectTypeID, ObjectID, EmployeeID, FullNameU, LocationID, ManagementObjTypeID, ManagementObjID, IsReceive, IsManagement, ")
            Case "SD" 'Thay doi tinh trang khau hao
                sSQL.Append("IsStopDepreciation, ")
            Case "SU" 'Thay doi tinh trang su dung
                sSQL.Append("IsStopUse, AssetWHID, ")
            Case "SL" 'Thay doi thoi gian khau hao
                sSQL.Append("ServiceLife, ")
            Case "IL" 'Giam tai san
                sSQL.Append("IsLiquidated, ")
        End Select

        sSQL.Append("CreateDate, CreateUserID, LastModifyUserID, ")
        sSQL.Append("LastModifyDate, GroupID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(sHistoryID) & COMMA) 'HistoryID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbg2(iRow, COL2_AssetID)) & COMMA) 'AssetID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'BatchID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'BeginMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'BeginYear, smallint, NOT NULL
        sSQL.Append(SQLNumber(12) & COMMA) 'EndMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(9999) & COMMA) 'EndYear, smallint, NOT NULL
        sSQL.Append(SQLString(sHistoryTypeID) & COMMA) 'HistoryTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'Status, tinyint, NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'InstanceID, tinyint, NOT NULL

        Select Case sHistoryTypeID
            Case "OB" 'Thay doi bo phan quan ly
                sSQL.Append(SQLString(tdbcObjectTypeID.Text) & COMMA) 'ObjectTypeID, varchar[20], NULL
                sSQL.Append(SQLString(tdbcObjectID.Text) & COMMA) 'ObjectID, varchar[20], NULL
                sSQL.Append(SQLString(tdbcEmployeeID.Text) & COMMA) 'EmployeeID, varchar[20], NULL
                sSQL.Append(SQLStringUnicode(txtEmployeeName.Text, gbUnicode, True) & COMMA) 'FullNameU, nvarchar, NOT NULL
                sSQL.Append(SQLString(ReturnValueC1Combo(tdbcLocationID)) & COMMA) 'LocationID, varchar[50], NOT NULL
                '30/10/2019, Lê Thị Phú Hà:id 123376-Bổ sung thay đổi bộ phận quản lý (NV tác động D02)
                sSQL.Append(SQLString(tdbcManagementObjTypeID.Text) & COMMA) 'ManagementObjTypeID, varchar[50], NULL
                sSQL.Append(SQLString(tdbcManagementObjID.Text) & COMMA) 'ManagementObjID, varchar[50], NULL
                sSQL.Append(SQLNumber(chkReceiveManage.Checked) & COMMA)
                sSQL.Append(SQLNumber(chkChangeManagement.Checked) & COMMA)

            Case "SD" 'Thay doi tinh trang khau hao
                sSQL.Append(SQLNumber(optStopDepreciation.Checked) & COMMA) 'IsStopDepreciation, tinyint, NULL
            Case "SU" 'Thay doi tinh trang su dung
                sSQL.Append(SQLNumber(optStopUse.Checked) & COMMA) 'IsStopUse, tinyint, NULL
                sSQL.Append(SQLString(tdbcWareHouseID.Text) & COMMA) 'AssetWHID, varchar[50], NOT NULL
            Case "SL" 'Thay doi thoi gian khau hao
                If tdbcAssetID.Text <> "..." Then
                    sSQL.Append(SQLNumber(txtServiceLife.Text) & COMMA) 'ServiceLife, int, NULL
                Else
                    Dim sServiceLife As String = ""
                    Dim dt As DataTable = ReturnTableFilter(dtRecordSet_Asset, "AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID).ToString), True)
                    If dt.Rows.Count > 0 Then
                        sServiceLife = dt.Rows(0).Item("NewServiceLife").ToString
                    End If
                    sSQL.Append(SQLNumber(sServiceLife) & COMMA) 'ServiceLife, int, NULL
                End If
            Case "IL" 'Giam tai san
                sSQL.Append(SQLNumber(chkIsEliminated.Checked) & COMMA) 'IsLiquidated, tinyint, NOT NULL
        End Select

        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(_groupID)) 'GroupID, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T5000_ChangeAssetAccount
    '# Created User: 
    '# Created Date: 11/11/2021 11:26:47
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T5000_ChangeAssetAccount(ByVal sHistoryID As String, sAssetID As String, sBatchID As String) As StringBuilder
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Thay doi Tai khoan tai san " & vbCrLf)
        sSQL.Append("Insert Into D02T5000(")
        sSQL.Append("HistoryID, DivisionID, AssetID, BatchID, BeginMonth, " & vbCrLf)
        sSQL.Append("BeginYear, EndMonth, EndYear, HistoryTypeID, Status, " & vbCrLf)
        sSQL.Append("InstanceID, CreateDate, CreateUserID, LastModifyUserID, LastModifyDate, " & vbCrLf)
        sSQL.Append("GroupID, AssetAccountID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(sHistoryID) & COMMA) 'HistoryID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLString(sAssetID) & COMMA) 'AssetID, varchar[20], NOT NULL
        sSQL.Append(SQLString(sBatchID) & COMMA) 'BatchID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA & vbCrLf) 'BeginMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'BeginYear, smallint, NOT NULL
        sSQL.Append(SQLNumber(12) & COMMA) 'EndMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(9999) & COMMA) 'EndYear, smallint, NOT NULL
        sSQL.Append(SQLString("AAC") & COMMA) 'HistoryTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(0) & COMMA & vbCrLf) 'Status, tinyint, NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'InstanceID, tinyint, NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA & vbCrLf) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA & vbCrLf) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(_groupID) & COMMA) 'GroupID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcAssetAccountID.Text)) 'AssetAccountID, varchar[50], NOT NULL
        sSQL.Append(") " & vbCrLf)

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T5000_ChangeDepAccount
    '# Created User: 
    '# Created Date: 11/11/2021 11:26:47
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T5000_ChangeDepAccount(ByVal sHistoryID As String, sAssetID As String, sBatchID As String) As StringBuilder
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        Dim sSQL As New StringBuilder

        sSQL.Append("-- Thay doi Tai khoan tai san " & vbCrLf)
        sSQL.Append("Insert Into D02T5000(")
        sSQL.Append("HistoryID, DivisionID, AssetID, BatchID, BeginMonth, " & vbCrLf)
        sSQL.Append("BeginYear, EndMonth, EndYear, HistoryTypeID, Status, " & vbCrLf)
        sSQL.Append("InstanceID, CreateDate, CreateUserID, LastModifyUserID, LastModifyDate, " & vbCrLf)
        sSQL.Append("GroupID, DepAccountID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(sHistoryID) & COMMA) 'HistoryID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLString(sAssetID) & COMMA) 'AssetID, varchar[20], NOT NULL
        sSQL.Append(SQLString(sBatchID) & COMMA) 'BatchID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA & vbCrLf) 'BeginMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'BeginYear, smallint, NOT NULL
        sSQL.Append(SQLNumber(12) & COMMA) 'EndMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(9999) & COMMA) 'EndYear, smallint, NOT NULL
        sSQL.Append(SQLString("DAC") & COMMA) 'HistoryTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(0) & COMMA & vbCrLf) 'Status, tinyint, NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'InstanceID, tinyint, NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA & vbCrLf) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(_groupID) & COMMA) 'GroupID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcDepAccountID.Text) & vbCrLf) 'AssetAccountID, varchar[50], NOT NULL
        sSQL.Append(") " & vbCrLf)

        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T5010
    '# Created User: HUỲNH KHANH
    '# Created Date: 18/12/2014 06:26:20
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T5010(ByVal iRow As Integer, ByVal sHistoryTypeID As String, ByVal sHistoryID As String, ByVal sBeginMonth As String, ByVal sBeginYear As String, ByVal sBatchID As String, ByVal sGroupID As String, sAccountID As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Them TKTS - TKKH" & vbCrLf)
        sSQL.Append("Insert Into D02T5010(")
        sSQL.Append("HistoryID, DivisionID, BatchID, HistoryTypeID, AssetID, " & vbCrLf)
        sSQL.Append("BeginMonth, BeginYear, EndMonth, EndYear, GroupID, " & vbCrLf)
        sSQL.Append("AccountID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(sHistoryID) & COMMA) 'HistoryID, varchar[50], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[50], NOT NULL
        sSQL.Append(SQLString(sBatchID) & COMMA) 'BatchID, varchar[50], NOT NULL
        sSQL.Append(SQLString(sHistoryTypeID) & COMMA) 'HistoryTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbg2(iRow, COL2_AssetID)) & COMMA & vbCrLf) 'AssetID, varchar[50], NOT NULL
        sSQL.Append(SQLNumber(sBeginMonth) & COMMA) 'BeginMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(sBeginYear) & COMMA) 'BeginYear, smallint, NOT NULL
        sSQL.Append(SQLNumber(12) & COMMA) 'EndMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(9999) & COMMA) 'EndYear, smallint, NOT NULL
        sSQL.Append(SQLString(sGroupID) & COMMA) 'GroupID, varchar[50], NOT NULL
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        'sSQL.Append(SQLString(tdbg2(iRow, COL2_NewAAC))) 'AccountID, varchar[50], NOT NULL
        sSQL.Append(SQLString(sAccountID)) 'AccountID, varchar[50], NOT NULL

        sSQL.Append(")")

        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T0001
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 14/03/2011 08:08:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLUpdateD02T0001(ByVal iRow As Integer) As StringBuilder
    '    Dim sSQL As New StringBuilder
    '    sSQL.Append("Update D02T0001 Set ")
    '    If tdbcAssetID.Text <> "..." Then
    '        sSQL.Append("ServiceLife = " & SQLNumber(txtServiceLife.Text)) 'int, NULL
    '    Else
    '        Dim sServiceLife As String = ""
    '        Dim dt As DataTable = ReturnTableFilter(dtRecordSet_Asset, "AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID).ToString), True)
    '        If dt.Rows.Count > 0 Then
    '            sServiceLife = dt.Rows(0).Item("NewServiceLife").ToString
    '        End If
    '        sSQL.Append("ServiceLife = " & SQLNumber(sServiceLife)) 'int, NULL
    '    End If
    '    sSQL.Append(" Where ")
    '    sSQL.Append("AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID).ToString))

    '    Return sSQL
    'End Function

    Private Function SQLUpdateD02T0001(ByVal iRow As Integer) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D02T0001 Set ")
        If tdbcAssetID.Text <> "..." Then
            sSQL.Append("ServiceLife = " & SQLNumber(txtServiceLife.Text)) 'int, NULL
        Else
            Dim sServiceLife As String = ""
            Dim dt As DataTable = ReturnTableFilter(dtRecordSet_Asset, "AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID).ToString), True)
            If dt.Rows.Count > 0 Then
                sServiceLife = dt.Rows(0).Item("NewServiceLife").ToString
            End If
            sSQL.Append("ServiceLife = " & SQLNumber(sServiceLife)) 'int, NULL
            'sSQL.Append("AssetConditionID = " & SQLString(tdbg2(iRow, COL2_AssetConditionID).ToString))
        End If

        sSQL.Append(" Where ")
        sSQL.Append("AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID).ToString))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T0203s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 14/03/2011 08:28:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T0203s(ByVal sAssetID As String) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dtRecordSet_Asset.Rows.Count - 1
            If dtRecordSet_Asset.Rows(i).Item("AssetID").ToString = sAssetID Then
                Dim dr() As DataRow
                dr = CType(tdbg2.DataSource, DataTable).Select("AssetID = " & SQLString(dtRecordSet_Asset.Rows(i).Item("AssetID")))
                sSQL.Append("Insert Into D02T0203(")
                sSQL.Append("BatchID, AssetID, AdjustServiceLife, DepreciatedPeriod, OldServiceLife, ")
                sSQL.Append("NewServiceLife, NewRemainLife")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(dr(0).Item("BatchID").ToString) & COMMA) 'BatchID, varchar[20], NULL
                sSQL.Append(SQLString(dtRecordSet_Asset.Rows(i).Item("AssetID")) & COMMA) 'AssetID, varchar[20], NULL
                sSQL.Append(SQLNumber(dtRecordSet_Asset.Rows(i).Item("AdjustServiceLife")) & COMMA) 'AdjustServiceLife, int, NULL
                sSQL.Append(SQLNumber(dtRecordSet_Asset.Rows(i).Item("DepreciatedPeriod")) & COMMA) 'DepreciatedPeriod, int, NULL
                sSQL.Append(SQLNumber(dtRecordSet_Asset.Rows(i).Item("OldServiceLife")) & COMMA) 'OldServiceLife, int, NULL
                sSQL.Append(SQLNumber(dtRecordSet_Asset.Rows(i).Item("NewServiceLife")) & COMMA) 'NewServiceLife, int, NULL
                sSQL.Append(SQLNumber(dtRecordSet_Asset.Rows(i).Item("NewRemainLife"))) 'NewRemainLife, int, NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T0012
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 26/07/2011 10:38:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: iMode = 1 : Luu them 1 dong but toan
    '# Description: iMode = 2 : Luu them 1 dong but toan
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T0012(ByVal iRow As Integer, ByVal dt As DataTable, _
                                        ByVal i As Integer, _
                                        ByVal iMode As Int16) As StringBuilder
        Dim sSQL As New StringBuilder

        Dim sAssetID As String = ""
        Dim iStatus As Int16 = 0
        Dim iPosted As Int16 = 0
        Dim sDebitAccountID As String = ""
        Dim sCreditAccountID As String = ""

        If iMode = 1 Then
            sDebitAccountID = dt.Rows(i).Item("DebitAccountID").ToString
            sCreditAccountID = dt.Rows(i).Item("CreditAccountID").ToString
        Else
            sDebitAccountID = dt.Rows(i).Item("CreditAccountID").ToString
            sCreditAccountID = dt.Rows(i).Item("DebitAccountID").ToString
        End If

        Dim nRowCountTransactionID As Long = 1
        Dim iFirstIGETransactionID As Long
        Dim sTransactionID As String = ""
        sTransactionID = CreateIGENewS("D02T0012", "TransactionID", "02", "TF", gsStringKey, sTransactionID, nRowCountTransactionID, iFirstIGETransactionID)

        sSQL.Append("Insert Into D02T0012(")
        sSQL.Append("TransactionID, DivisionID, ModuleID, AssetID, ")
        sSQL.Append("VoucherTypeID, VoucherNo, VoucherDate, TranMonth, TranYear, ")
        sSQL.Append("CurrencyID, ExchangeRate, DebitAccountID, ")
        sSQL.Append("CreditAccountID, OriginalAmount, ConvertedAmount, TransactionTypeID, ")
        sSQL.Append("RefNo, RefDate, CreateUserID, CreateDate, ")
        sSQL.Append("LastModifyUserID, LastModifyDate, SeriNo, ObjectTypeID, ObjectID, ")
        sSQL.Append("BatchID, Ana01ID, Ana02ID, Ana03ID, ")
        sSQL.Append("Ana04ID, Ana05ID, Ana06ID, Ana07ID, Ana08ID, ")
        sSQL.Append("Ana09ID, Ana10ID, CipID, ")
        sSQL.Append("SourceID, SplitBatchID, GroupID, ")
        sSQL.Append("DescriptionU, NotesU, Status, Posted, Quantity, InventoryID, UnitID, IsNotAllocate, ProjectID, ProjectNameU, TaskID, TaskNameU, PropertyProductID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(sTransactionID) & COMMA) 'TransactionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("ModuleID")) & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(sAssetID) & COMMA) 'AssetID, varchar[20], NULL
        sSQL.Append(SQLString(ComboValue(tdbcVoucherTypeID)) & COMMA) 'VoucherTypeID, varchar[20], NULL
        sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[50], NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NULL

        sSQL.Append(SQLString(ComboValue(tdbcCurrencyID)) & COMMA) 'CurrencyID, varchar[20], NOT NULL
        sSQL.Append(SQLMoney(dt.Rows(i).Item("ExchangeRate"), DxxFormat.DefaultNumber2) & COMMA) 'ExchangeRate, money, NOT NULL
        sSQL.Append(SQLString(sDebitAccountID) & COMMA) 'DebitAccountID, varchar[20], NULL
        sSQL.Append(SQLString(sCreditAccountID) & COMMA) 'CreditAccountID, varchar[20], NULL
        sSQL.Append(SQLMoney(dt.Rows(i).Item("OriginalAmount"), DxxFormat.DecimalPlaces) & COMMA) 'OriginalAmount, money, NULL
        sSQL.Append(SQLMoney(dt.Rows(i).Item("ConvertedAmount"), DxxFormat.D90_ConvertedDecimals) & COMMA) 'ConvertedAmount, money, NULL
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        sSQL.Append(SQLString(IIf(chkIsEliminated.Checked, "GTS", dt.Rows(i).Item("TransactionTypeID").ToString)) & COMMA) 'TransactionTypeID, varchar[20], NULL

        sSQL.Append(SQLString(dt.Rows(i).Item("RefNo")) & COMMA) 'RefNo, varchar[20], NULL
        sSQL.Append(SQLDateSave(dt.Rows(i).Item("RefDate")) & COMMA) 'RefDate, datetime, NULL

        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("SeriNo")) & COMMA) 'SeriNo, varchar[20], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("ObjectTypeID")) & COMMA) 'ObjectTypeID, varchar[20], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("ObjectID")) & COMMA) 'ObjectID, varchar[20], NULL
        sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'BatchID, varchar[20], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana01ID")) & COMMA) 'Ana01ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana02ID")) & COMMA) 'Ana02ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana03ID")) & COMMA) 'Ana03ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana04ID")) & COMMA) 'Ana04ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana05ID")) & COMMA) 'Ana05ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana06ID")) & COMMA) 'Ana06ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana07ID")) & COMMA) 'Ana07ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana08ID")) & COMMA) 'Ana08ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana09ID")) & COMMA) 'Ana09ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("Ana10ID")) & COMMA) 'Ana10ID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("CipID")) & COMMA) 'CipID, varchar[20], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("SourceID")) & COMMA) 'SourceID, varchar[20], NULL
        sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'SplitBatchID, varchar[20], NULL
        sSQL.Append(SQLString(_groupID) & COMMA) 'GroupID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(dt.Rows(i).Item("Description"), gbUnicode, True) & COMMA) 'DescriptionU, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotes.Text, gbUnicode, True) & COMMA) 'NotesU, nvarchar, NOT NULL
        sSQL.Append(SQLNumber(iStatus) & COMMA) 'Status, tinyint, NOT NULL
        sSQL.Append(SQLNumber(iPosted) & COMMA) 'Posted, tinyint, NOT NULL
        ' update 11/6/2013 id 57078 - Khi thực hiện lưu dữ liệu (AddNew) vào bảng D02T0012 thì trường Quantity = 1
        If _FormState = EnumFormState.FormAdd Then
            sSQL.Append(SQLMoney(1) & COMMA) 'Quantity, decimal(28, 8), NULL
        Else
            sSQL.Append(SQLMoney(dt.Rows(i).Item("Quantity"), DxxFormat.D08_QuantityDecimals) & COMMA) 'Quantity, decimal(28, 8), NULL
        End If
        sSQL.Append(SQLString(dt.Rows(i).Item("InventoryID")) & COMMA) 'InventoryID, varchar[50], NULL
        sSQL.Append(SQLString(dt.Rows(i).Item("UnitID")) & COMMA) 'UnitID, varchar[20], NULL
        'ID 87531 25.05.2016
        sSQL.Append(SQLNumber(dt.Rows(i).Item("IsNotAllocate"))) 'IsNotAllocate, varchar[20], NULL
        'ID 87726 7.06.2016
        'sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "ProjectID"))) 'IsNotAllocate, tinyint, NOT NULL
        'sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "TaskID"))) 'IsNotAllocate, tinyint, NOT NULL

        'ID 91410 28.09.2016
        sSQL.Append(COMMA & SQLString(dt.Rows(i).Item("ProjectID"))) 'ProjectID
        sSQL.Append(COMMA & SQLStringUnicode(dt.Rows(i).Item("ProjectName"), gbUnicode, True)) 'ProjectNameU
        sSQL.Append(COMMA & SQLString(dt.Rows(i).Item("TaskID"))) 'TaskID
        sSQL.Append(COMMA & SQLStringUnicode(dt.Rows(i).Item("TaskName"), gbUnicode, True)) 'TaskNameU

        sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "D27PropertyProductID"))) 'PropertyProductID

        sSQL.Append(") ")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T0012
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 26/07/2011 10:38:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: iMode = 1 : Luu them 1 dong but toan
    '# Description: iMode = 2 : Luu them 1 dong but toan
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T0012(ByVal iRow As Integer, _
                                        ByVal i As Integer, _
                                        ByVal iMode As Int16) As StringBuilder
        Dim sSQL As New StringBuilder

        Dim sAssetID As String = ""
        Dim iStatus As Int16 = 0
        Dim iPosted As Int16 = 0
        Dim sDebitAccountID As String = ""
        Dim sCreditAccountID As String = ""

        If iMode = 1 Then
            sDebitAccountID = tdbg3(i, COL3_DebitAccountID).ToString
            sCreditAccountID = tdbg3(i, COL3_CreditAccountID).ToString
        Else
            sDebitAccountID = tdbg3(i, COL3_CreditAccountID).ToString
            sCreditAccountID = tdbg3(i, COL3_DebitAccountID).ToString
        End If

        Dim nRowCountTransactionID As Long = 1
        Dim iFirstIGETransactionID As Long
        Dim sTransactionID As String = ""
        sTransactionID = CreateIGENewS("D02T0012", "TransactionID", "02", "TF", gsStringKey, sTransactionID, nRowCountTransactionID, iFirstIGETransactionID)

        sSQL.Append("Insert Into D02T0012(")
        sSQL.Append("TransactionID, DivisionID, ModuleID, AssetID, ")
        sSQL.Append("VoucherTypeID, VoucherNo, VoucherDate, TranMonth, TranYear, ")
        sSQL.Append("CurrencyID, ExchangeRate, DebitAccountID, ")
        sSQL.Append("CreditAccountID, OriginalAmount, ConvertedAmount, TransactionTypeID, ")
        sSQL.Append("RefNo, RefDate, CreateUserID, CreateDate, ")
        sSQL.Append("LastModifyUserID, LastModifyDate, SeriNo, ObjectTypeID, ObjectID, ")
        sSQL.Append("BatchID, Ana01ID, Ana02ID, Ana03ID, ")
        sSQL.Append("Ana04ID, Ana05ID, Ana06ID, Ana07ID, Ana08ID, ")
        sSQL.Append("Ana09ID, Ana10ID, CipID, ")
        sSQL.Append("SourceID, SplitBatchID, GroupID, ")
        sSQL.Append("DescriptionU, NotesU, Status, Posted, InventoryID, Quantity, UnitID")
        'ID 86630 25.05.2016
        sSQL.Append(",IsNotAllocate")
        'ID 87726 7.06.2016

        'ID 91410 28.09.2016
        sSQL.Append(", ProjectID, ProjectNameU, TaskID, TaskNameU, PropertyProductID")
        '****************************************
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(sTransactionID) & COMMA) 'TransactionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_ModuleID)) & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(sAssetID) & COMMA) 'AssetID, varchar[20], NULL
        sSQL.Append(SQLString(ComboValue(tdbcVoucherTypeID)) & COMMA) 'VoucherTypeID, varchar[20], NULL
        sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[50], NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NULL

        sSQL.Append(SQLString(ComboValue(tdbcCurrencyID)) & COMMA) 'CurrencyID, varchar[20], NOT NULL
        sSQL.Append(SQLMoney(tdbg3(i, COL3_ExchangeRate), DxxFormat.DefaultNumber2) & COMMA) 'ExchangeRate, money, NOT NULL
        sSQL.Append(SQLString(sDebitAccountID) & COMMA) 'DebitAccountID, varchar[20], NULL
        sSQL.Append(SQLString(sCreditAccountID) & COMMA) 'CreditAccountID, varchar[20], NULL
        sSQL.Append(SQLMoney(tdbg3(i, COL3_OriginalAmount), DxxFormat.DecimalPlaces) & COMMA) 'OriginalAmount, money, NULL
        sSQL.Append(SQLMoney(tdbg3(i, COL3_ConvertedAmount), DxxFormat.D90_ConvertedDecimals) & COMMA) 'ConvertedAmount, money, NULL
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        sSQL.Append(SQLString(IIf(chkIsEliminated.Checked, "GTS", tdbg3(i, COL3_TransactionTypeID).ToString)) & COMMA) 'TransactionTypeID, varchar[20], NULL

        sSQL.Append(SQLString(tdbg3(i, COL3_RefNo)) & COMMA) 'RefNo, varchar[20], NULL
        sSQL.Append(SQLDateSave(tdbg3(i, COL3_RefDate)) & COMMA) 'RefDate, datetime, NULL

        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_SeriNo)) & COMMA) 'SeriNo, varchar[20], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_ObjectTypeID)) & COMMA) 'ObjectTypeID, varchar[20], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_ObjectID)) & COMMA) 'ObjectID, varchar[20], NULL
        sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'BatchID, varchar[20], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana01ID)) & COMMA) 'Ana01ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana02ID)) & COMMA) 'Ana02ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana03ID)) & COMMA) 'Ana03ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana04ID)) & COMMA) 'Ana04ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana05ID)) & COMMA) 'Ana05ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana06ID)) & COMMA) 'Ana06ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana07ID)) & COMMA) 'Ana07ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana08ID)) & COMMA) 'Ana08ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana09ID)) & COMMA) 'Ana09ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_Ana10ID)) & COMMA) 'Ana10ID, varchar[50], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_CipID)) & COMMA) 'CipID, varchar[20], NULL
        sSQL.Append(SQLString(tdbg3(i, COL3_SourceID)) & COMMA) 'SourceID, varchar[20], NULL
        sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'SplitBatchID, varchar[20], NULL
        sSQL.Append(SQLString(_groupID) & COMMA) 'GroupID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(tdbg3(i, COL3_Description), gbUnicode, True) & COMMA) 'DescriptionU, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotes.Text, gbUnicode, True) & COMMA) 'NotesU, nvarchar, NOT NULL
        sSQL.Append(SQLNumber(iStatus) & COMMA) 'Status, tinyint, NOT NULL
        sSQL.Append(SQLNumber(iPosted) & COMMA) 'Posted, tinyint, NOT NULL
        'Them ngay 3/12/2012 theo incident 52673 cua Bảo Trân bởi Văn Vinh
        sSQL.Append(SQLString(tdbg3(i, COL3_InventoryID)) & COMMA) 'InventoryID, nvarchar(20), NOT NULL
        ' update 11/6/2013 id 57078 - Khi thực hiện lưu dữ liệu (AddNew) vào bảng D02T0012 thì trường Quantity = 1
        If _FormState = EnumFormState.FormAdd Then
            sSQL.Append(SQLMoney(1) & COMMA) 'Quantity, decimal(28, 8), NULL
        Else
            sSQL.Append(SQLMoney(tdbg3(i, COL3_Quantity), DxxFormat.D08_QuantityDecimals) & COMMA) 'Quantity, decimal(28, 8), NOT NULL
        End If
        sSQL.Append(SQLString(tdbg3(i, COL3_UnitID))) 'UnitID, nvarchar(20), NOT NULL
        'ID 86630 25.05.2016
        sSQL.Append(COMMA & SQLNumber(tdbg3(i, COL3_IsNotAllocate))) 'IsNotAllocate, tinyint, NOT NULL
        'ID 87726 7.06.2016


        'ID 91410 28.09.2016
        sSQL.Append(COMMA & SQLString(tdbg3(i, COL3_ProjectID))) 'ProjectID
        sSQL.Append(COMMA & SQLStringUnicode(tdbg3(i, COL3_ProjectName), gbUnicode, True)) 'ProjectNameU
        sSQL.Append(COMMA & SQLString(tdbg3(i, COL3_TaskID))) 'TaskID
        sSQL.Append(COMMA & SQLStringUnicode(tdbg3(i, COL3_TaskName), gbUnicode, True)) 'TaskNameU

        sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "D27PropertyProductID"))) 'PropertyProductID

        '************************************
        sSQL.Append(") ")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T0012s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 14/03/2011 09:33:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T0012s(ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        Dim nRowCountTransactionID As Long
        Dim iFirstIGETransactionID As Long
        Dim sTransactionID As String = ""

        If _FormState = EnumFormState.FormAdd Then
            Dim dt As DataTable
            '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
            dt = ReturnDataTable("SELECT * FROM D02T0011 WITH(NOLOCK) WHERE UserID = " & SQLString(gsUserID) & " And AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID).ToString) & " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID  = 'D02F2003' ")

            nRowCountTransactionID = dt.Rows.Count

            For i As Integer = 0 To dt.Rows.Count - 1

                sTransactionID = CreateIGENewS("D02T0012", "TransactionID", "02", "TF", gsStringKey, sTransactionID, nRowCountTransactionID, iFirstIGETransactionID)

                sSQL.Append("Insert Into D02T0012(")
                sSQL.Append("TransactionID, DivisionID, ModuleID, AssetID, ")
                sSQL.Append("VoucherTypeID, VoucherNo, VoucherDate, TranMonth, TranYear, ")
                sSQL.Append("CurrencyID, ExchangeRate, DebitAccountID, ")
                sSQL.Append("CreditAccountID, OriginalAmount, ConvertedAmount, TransactionTypeID, ")
                sSQL.Append("RefNo, RefDate, CreateUserID, CreateDate, ")
                sSQL.Append("LastModifyUserID, LastModifyDate, SeriNo, ObjectTypeID, ObjectID, ")
                sSQL.Append("BatchID, Ana01ID, Ana02ID, Ana03ID, ")
                sSQL.Append("Ana04ID, Ana05ID, Ana06ID, Ana07ID, Ana08ID, ")
                sSQL.Append("Ana09ID, Ana10ID, CipID, ")
                sSQL.Append("SourceID, SplitBatchID, GroupID, ")
                sSQL.Append("DescriptionU, NotesU, Quantity, InventoryID, UnitID,IsNotAllocate, ProjectID, ProjectNameU, TaskID, TaskNameU, PropertyProductID, PeriodID") ',Quantity, InventoryID, UnitID
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(sTransactionID) & COMMA) 'TransactionID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(IIf(dt.Rows(i).Item("ModuleID").ToString = "", "02", dt.Rows(i).Item("ModuleID"))) & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg2(iRow, COL2_AssetID)) & COMMA) 'AssetID, varchar[20], NULL
                sSQL.Append(SQLString(ComboValue(tdbcVoucherTypeID)) & COMMA) 'VoucherTypeID, varchar[20], NULL
                sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[50], NULL
                sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
                sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
                sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NULL

                sSQL.Append(SQLString(ComboValue(tdbcCurrencyID)) & COMMA) 'CurrencyID, varchar[20], NOT NULL
                sSQL.Append(SQLMoney(dt.Rows(i).Item("ExchangeRate"), DxxFormat.DefaultNumber2) & COMMA) 'ExchangeRate, money, NOT NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("DebitAccountID")) & COMMA) 'DebitAccountID, varchar[20], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("CreditAccountID")) & COMMA) 'CreditAccountID, varchar[20], NULL
                sSQL.Append(SQLMoney(dt.Rows(i).Item("OriginalAmount"), DxxFormat.DecimalPlaces) & COMMA) 'OriginalAmount, money, NULL
                sSQL.Append(SQLMoney(dt.Rows(i).Item("ConvertedAmount"), DxxFormat.D90_ConvertedDecimals) & COMMA) 'ConvertedAmount, money, NULL

                '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
                sSQL.Append(SQLString(IIf(chkIsEliminated.Checked, "GTS", dt.Rows(i).Item("TransactionTypeID").ToString)) & COMMA) 'TransactionTypeID, varchar[20], NULL

                sSQL.Append(SQLString(dt.Rows(i).Item("RefNo")) & COMMA) 'RefNo, varchar[20], NULL
                sSQL.Append(SQLDateSave(dt.Rows(i).Item("RefDate")) & COMMA) 'RefDate, datetime, NULL

                sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
                sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("SeriNo")) & COMMA) 'SeriNo, varchar[20], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("ObjectTypeID")) & COMMA) 'ObjectTypeID, varchar[20], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("ObjectID")) & COMMA) 'ObjectID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'BatchID, varchar[20], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana01ID")) & COMMA) 'Ana01ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana02ID")) & COMMA) 'Ana02ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana03ID")) & COMMA) 'Ana03ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana04ID")) & COMMA) 'Ana04ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana05ID")) & COMMA) 'Ana05ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana06ID")) & COMMA) 'Ana06ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana07ID")) & COMMA) 'Ana07ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana08ID")) & COMMA) 'Ana08ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana09ID")) & COMMA) 'Ana09ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("Ana10ID")) & COMMA) 'Ana10ID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("CipID")) & COMMA) 'CipID, varchar[20], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("SourceID")) & COMMA) 'SourceID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'SplitBatchID, varchar[20], NULL
                sSQL.Append(SQLString(_groupID) & COMMA) 'GroupID, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(dt.Rows(i).Item("Description"), gbUnicode, True) & COMMA) 'DescriptionU, nvarchar, NOT NULL
                sSQL.Append(SQLStringUnicode(txtNotes.Text, gbUnicode, True) & COMMA) 'NotesU, nvarchar, NOT NULL

                ' update 11/6/2013 id 57078 - Khi thực hiện lưu dữ liệu (AddNew) vào bảng D02T0012 thì trường Quantity = 1
                If _FormState = EnumFormState.FormAdd Then
                    sSQL.Append(SQLMoney(1) & COMMA) 'Quantity, decimal(28, 8), NULL
                Else
                    sSQL.Append(SQLMoney(dt.Rows(i).Item("Quantity"), DxxFormat.D08_QuantityDecimals) & COMMA) 'Quantity, decimal(28, 8), NULL
                End If
                sSQL.Append(SQLString(dt.Rows(i).Item("InventoryID")) & COMMA) 'InventoryID, varchar[50], NULL
                sSQL.Append(SQLString(dt.Rows(i).Item("UnitID")) & COMMA) 'UnitID, varchar[20], NULL
                'ID 86630 25.05.2016
                sSQL.Append(SQLNumber(dt.Rows(i).Item("IsNotAllocate"))) 'IsNotAllocate, varchar[20], NULL
                'ID 87726 7.06.2016
                'sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "ProjectID"))) 'IsNotAllocate, tinyint, NOT NULL
                'sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "TaskID"))) 'IsNotAllocate, tinyint, NOT NULL

                'ID 91410 28.09.2016
                sSQL.Append(COMMA & SQLString(dt.Rows(i).Item("ProjectID"))) 'ProjectID, tinyint, NOT NULL
                sSQL.Append(COMMA & SQLStringUnicode(dt.Rows(i).Item("ProjectName"), gbUnicode, True)) 'ProjectNameU, tinyint, NOT NULL
                sSQL.Append(COMMA & SQLString(dt.Rows(i).Item("TaskID"))) 'TaskID, tinyint, NOT NULL
                sSQL.Append(COMMA & SQLStringUnicode(dt.Rows(i).Item("TaskName"), gbUnicode, True)) 'TaskNameU, tinyint, NOT NULL

                sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "D27PropertyProductID")) & COMMA) 'IsNotAllocate, tinyint, NOT NULL
                '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
                sSQL.Append(SQLString(dt.Rows(i).Item("PeriodID"))) 'PeriodID, varchar[20], NOT NULL

                sSQL.Append(") ")

                sRet.Append(sSQL.ToString & vbCrLf)

                'ID 93607 05.12.2016
                'sRet.Append(SQLUpdateD02T0100(dt.Rows(i).Item("CipID").ToString).ToString & vbCrLf)
                sRet.Append(SQLStoreD02P0101(ReturnValueC1Combo(tdbcAssetID), txtVoucherNo.Text, dt.Rows(i).Item("CipID").ToString) & vbCrLf)

                If chkIsEliminated.Checked Then
                    If ExistRecord("SELECT TOP 1 1 FROM D90T0001 WITH(NOLOCK) WHERE GroupID = '7' AND AccountID = " & SQLString(dt.Rows(i).Item("DebitAccountID"))) Then
                        If Not ExistRecord("SELECT TOP 1 1 FROM D02T0001 WITH(NOLOCK) WHERE AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID)) & " AND AssetAccountID = " & SQLString(dt.Rows(i).Item("DebitAccountID"))) Then
                            'Luu them 2 dong but toan
                            sRet.Append(SQLInsertD02T0012(iRow, dt, i, 1).ToString & vbCrLf)
                            sRet.Append(SQLInsertD02T0012(iRow, dt, i, 2).ToString & vbCrLf)
                        End If
                    End If
                End If

                sSQL.Remove(0, sSQL.Length)
            Next
        Else
            For i As Integer = 0 To tdbg3.RowCount - 1
                If tdbg3(i, COL3_TransactionID).ToString = "" Then
                    nRowCountTransactionID += 1
                End If
            Next

            For i As Integer = 0 To tdbg3.RowCount - 1
                If tdbg3(i, COL3_TransactionID).ToString = "" Then
                    sTransactionID = CreateIGENewS("D02T0012", "TransactionID", "02", "TF", gsStringKey, sTransactionID, nRowCountTransactionID, iFirstIGETransactionID)
                    tdbg3(i, COL3_TransactionID) = sTransactionID
                End If

                sSQL.Append("Insert Into D02T0012(")
                sSQL.Append("TransactionID, DivisionID, ModuleID, AssetID, ")
                sSQL.Append("VoucherTypeID, VoucherNo, VoucherDate, TranMonth, TranYear, ")
                sSQL.Append("CurrencyID, ExchangeRate, DebitAccountID, ")
                sSQL.Append("CreditAccountID, OriginalAmount, ConvertedAmount, TransactionTypeID, ")
                sSQL.Append("RefNo, RefDate, CreateUserID, CreateDate, ")
                sSQL.Append("LastModifyUserID, LastModifyDate, SeriNo, ObjectTypeID, ObjectID, ")
                sSQL.Append("BatchID, Ana01ID, Ana02ID, Ana03ID, ")
                sSQL.Append("Ana04ID, Ana05ID, Ana06ID, Ana07ID, Ana08ID, ")
                sSQL.Append("Ana09ID, Ana10ID, CipID, ")
                sSQL.Append("SourceID, SplitBatchID, GroupID, ")
                sSQL.Append("DescriptionU, NotesU, InventoryID, Quantity, UnitID, IsNotAllocate, ProjectID, ProjectNameU, TaskID, TaskNameU, PropertyProductID, PeriodID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(tdbg3(i, COL3_TransactionID)) & COMMA) 'TransactionID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(IIf(tdbg3(i, COL3_ModuleID).ToString = "", "02", tdbg3(i, COL3_ModuleID))) & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg2(iRow, COL2_AssetID)) & COMMA) 'AssetID, varchar[20], NULL
                sSQL.Append(SQLString(ComboValue(tdbcVoucherTypeID)) & COMMA) 'VoucherTypeID, varchar[20], NULL
                sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[50], NULL
                sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
                sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
                sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NULL

                sSQL.Append(SQLString(ComboValue(tdbcCurrencyID)) & COMMA) 'CurrencyID, varchar[20], NOT NULL
                sSQL.Append(SQLMoney(tdbg3(i, COL3_ExchangeRate), DxxFormat.DefaultNumber2) & COMMA) 'ExchangeRate, money, NOT NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_DebitAccountID)) & COMMA) 'DebitAccountID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_CreditAccountID)) & COMMA) 'CreditAccountID, varchar[20], NULL
                sSQL.Append(SQLMoney(tdbg3(i, COL3_OriginalAmount), DxxFormat.DecimalPlaces) & COMMA) 'OriginalAmount, money, NULL
                sSQL.Append(SQLMoney(tdbg3(i, COL3_ConvertedAmount), DxxFormat.D90_ConvertedDecimals) & COMMA) 'ConvertedAmount, money, NULL

                '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
                sSQL.Append(SQLString(IIf(chkIsEliminated.Checked, "GTS", tdbg3(i, COL3_TransactionTypeID).ToString)) & COMMA) 'TransactionTypeID, varchar[20], NULL

                sSQL.Append(SQLString(tdbg3(i, COL3_RefNo)) & COMMA) 'RefNo, varchar[20], NULL
                sSQL.Append(SQLDateSave(tdbg3(i, COL3_RefDate)) & COMMA) 'RefDate, datetime, NULL

                sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
                sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_SeriNo)) & COMMA) 'SeriNo, varchar[20], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_ObjectTypeID)) & COMMA) 'ObjectTypeID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_ObjectID)) & COMMA) 'ObjectID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'BatchID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana01ID)) & COMMA) 'Ana01ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana02ID)) & COMMA) 'Ana02ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana03ID)) & COMMA) 'Ana03ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana04ID)) & COMMA) 'Ana04ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana05ID)) & COMMA) 'Ana05ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana06ID)) & COMMA) 'Ana06ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana07ID)) & COMMA) 'Ana07ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana08ID)) & COMMA) 'Ana08ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana09ID)) & COMMA) 'Ana09ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_Ana10ID)) & COMMA) 'Ana10ID, varchar[50], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_CipID)) & COMMA) 'CipID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_SourceID)) & COMMA) 'SourceID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg2(iRow, COL2_BatchID)) & COMMA) 'SplitBatchID, varchar[20], NULL
                sSQL.Append(SQLString(_groupID) & COMMA) 'GroupID, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg3(i, COL3_Description), gbUnicode, True) & COMMA) 'DescriptionU, nvarchar, NOT NULL
                sSQL.Append(SQLStringUnicode(txtNotes.Text, gbUnicode, True) & COMMA) 'NotesU, nvarchar, NOT NULL
                'Them ngay 3/12/2012 theo incident 52673 cua Bảo Trân bởi Văn Vinh
                sSQL.Append(SQLString(tdbg3(i, COL3_InventoryID)) & COMMA) 'InventoryID, nvarchar(20), NOT NULL
                sSQL.Append(SQLMoney(tdbg3(i, COL3_Quantity), DxxFormat.D08_QuantityDecimals) & COMMA) 'Quantity, decimal(28, 8), NOT NULL
                sSQL.Append(SQLString(tdbg3(i, COL3_UnitID)) & COMMA) 'UnitID, nvarchar(20), NOT NULL
                'ID 86630 25.05.2016
                sSQL.Append(SQLNumber(tdbg3(i, COL3_IsNotAllocate))) 'IsNotAllocate, varchar[20], NULL
                'ID 87726 7.06.2016
                'sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "ProjectID"))) 'IsNotAllocate, tinyint, NOT NULL
                'sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "TaskID"))) 'IsNotAllocate, tinyint, NOT NULL

                'ID 91410 28.09.2016
                sSQL.Append(COMMA & SQLString(tdbg3(i, COL3_ProjectID))) 'ProjectID, tinyint, NOT NULL
                sSQL.Append(COMMA & SQLStringUnicode(tdbg3(i, COL3_ProjectName), gbUnicode, True)) 'ProjectNameU, tinyint, NOT NULL
                sSQL.Append(COMMA & SQLString(tdbg3(i, COL3_TaskID))) 'TaskID, tinyint, NOT NULL
                sSQL.Append(COMMA & SQLStringUnicode(tdbg3(i, COL3_TaskName), gbUnicode, True)) 'TaskNameU, tinyint, NOT NULL

                sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcAssetID, "D27PropertyProductID")) & COMMA) 'IsNotAllocate, tinyint, NOT NULL
                '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
                sSQL.Append(SQLString(tdbg3(i, COL3_PeriodID))) 'PeriodID, varchar[20], NOT NULL

                sSQL.Append(") ")

                sRet.Append(sSQL.ToString & vbCrLf)

                'ID 93607 05.12.2016
                'sRet.Append(SQLUpdateD02T0100(tdbg3(i, COL3_CipID).ToString).ToString & vbCrLf)
                sRet.Append(SQLStoreD02P0101(ReturnValueC1Combo(tdbcAssetID), txtVoucherNo.Text, tdbg3(i, COL3_CipID).ToString) & vbCrLf)

                If chkIsEliminated.Checked Then
                    If ExistRecord("SELECT TOP 1 1 FROM D90T0001 WITH(NOLOCK) WHERE GroupID = '7' AND AccountID = " & SQLString(tdbg3(i, COL3_DebitAccountID))) Then
                        If Not ExistRecord("SELECT TOP 1 1 FROM D02T0001 WITH(NOLOCK) WHERE AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID)) & " AND AssetAccountID = " & SQLString(tdbg3(i, COL3_DebitAccountID))) Then
                            'Luu them 2 dong but toan
                            sRet.Append(SQLInsertD02T0012(iRow, i, 1).ToString & vbCrLf)
                            sRet.Append(SQLInsertD02T0012(iRow, i, 2).ToString & vbCrLf)
                        End If
                    End If
                End If

                sSQL.Remove(0, sSQL.Length)
            Next
        End If

        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T0012s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 15/03/2011 01:54:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T0012s(ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg3.RowCount - 1
            sSQL.Append("Update D02T0012 Set ")
            sSQL.Append("AssetID = " & SQLString(tdbg2(iRow, COL2_AssetID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("Status = " & SQLNumber(1) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("SourceID = " & SQLString(tdbg3(i, COL3_SourceID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("SplitBatchID = " & SQLString(tdbg2(iRow, COL2_BatchID))) 'varchar[20], NULL
            'ID 86630 25.05.2016
            sSQL.Append(COMMA & "IsNotAllocate = " & SQLNumber(tdbg3(i, COL3_IsNotAllocate)))
            'ID 87726 07.06.2016
            'sSQL.Append(COMMA & "ProjectID = " & SQLString(ReturnValueC1Combo(tdbcAssetID, "ProjectID")))
            'sSQL.Append(COMMA & "TaskID = " & SQLString(ReturnValueC1Combo(tdbcAssetID, "TaskID")))

            'ID 91410 28.09.2016
            sSQL.Append(COMMA & "ProjectID = " & SQLString(tdbg3(i, COL3_ProjectID)))
            sSQL.Append(COMMA & "TaskID = " & SQLString(tdbg3(i, COL3_TaskID)))
            sSQL.Append(COMMA & "ProjectNameU = " & SQLStringUnicode(tdbg3(i, COL3_ProjectName), gbUnicode, True))
            sSQL.Append(COMMA & "TaskNameU = " & SQLStringUnicode(tdbg3(i, COL3_TaskName), gbUnicode, True))

            sSQL.Append(COMMA & "PropertyProductID = " & SQLString(ReturnValueC1Combo(tdbcAssetID, "D27PropertyProductID")) & COMMA)
            '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
            sSQL.Append("PeriodID = " & SQLString(tdbg3(i, COL3_PeriodID)) & vbCrLf) 'PeriodID, varchar[20], NOT NULL

            '**********************************
            sSQL.Append(" Where ")
            sSQL.Append("TransactionID = " & SQLString(tdbg3(i, COL3_TransactionID)) & " And ")
            sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
            sSQL.Append("TranMonth = " & SQLNumber(giTranMonth) & " And ") 'tinyint, NULL
            sSQL.Append("TranYear = " & SQLNumber(giTranYear) & " And ") 'smallint, NULL
            sSQL.Append("isnull(SplitBatchID,'')=''")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T0100
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 14/03/2011 10:21:02
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T0100(ByVal sCipID As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D02T0100 Set ")
        sSQL.Append("Status = " & SQLNumber(2)) 'tinyint, NULL
        sSQL.Append(" Where ")
        sSQL.Append("CipID = " & SQLString(sCipID))

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
        If _FormState = EnumFormState.FormAdd Then
            sSQL &= SQLString(tdbg2.Columns(COL2_BatchID).Text) & COMMA 'BatchID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(_batchID) & COMMA 'BatchID, varchar[20], NOT NULL
        End If
        sSQL &= SQLString(_groupID) & COMMA 'GroupID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0101
    '# Created User: KIM LONG
    '# Created Date: 05/12/2016 09:45:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0101(ByVal sAssetID As String, ByVal sVoucherNo As String, ByVal sCipID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- --kiem tra va cap nhat trang thai XDCB" & vbCrLf)
        sSQL &= "Exec D02P0101 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(sAssetID) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString(sVoucherNo) & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= "''" & SQLString(sCipID) & "''" 'CipID, varchar[8000], NOT NULL
        Return sSQL
    End Function



#End Region

    Private Sub chkDepreciationTime_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDepreciationTime.Click
        btnDepreciation.Enabled = chkDepreciationTime.Checked
    End Sub

    Private Sub chkCollect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCollect.Click
        btnCollect.Enabled = chkCollect.Checked
        If btnCollect.Enabled = False Then
            If (_FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormEditOther Or _FormState = EnumFormState.FormView) And dtGrid3.Rows.Count > 0 Then
                Exit Sub
            End If
            If dtGrid3 IsNot Nothing Then
                dtGrid3.Clear()
            End If
            tdbcVoucherTypeID.Enabled = True
            txtVoucherNo.Enabled = True
            tdbcCurrencyID.Enabled = True
            txtNotes.Enabled = True
            c1dateVoucherDate.Enabled = True
            tdbg3_LockTDBGrid(False)
            tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        Else
            If _FormState = EnumFormState.FormAdd Then
                If bFirstCheck = False Then
                    If dtGrid3 IsNot Nothing Then
                        dtGrid3.Clear()
                    End If
                End If
                bFirstCheck = True
            End If
            tdbcVoucherTypeID.Enabled = False
            txtVoucherNo.Enabled = False
            tdbcCurrencyID.Enabled = False
            txtNotes.Enabled = False
            c1dateVoucherDate.Enabled = False
            tdbg3_LockTDBGrid(True)
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
            txtNotes.Text = ""
            c1dateVoucherDate.Value = Date.Now
            tdbcCurrencyID.Text = ""
            tdbcVoucherTypeID.EditorBackColor = Color.LightGray
            txtVoucherNo.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub btnCollect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollect.Click
        Dim f As New D02F2008

        With f
            .AssetID = tdbg2.Columns(COL2_AssetID).Text
            .AssetAccountID = tdbg2.Columns(COL2_AssetAccountID).Text
            .DepAccountID = tdbg2.Columns(COL2_DepAccountID).Text
            .ChangeNo = tdbcChangeNo.Text
            .ShowDialog()
            If .dtF2008 IsNot Nothing Then
                dtGrid3 = .dtF2008
                LoadDataSource(tdbg3, dtGrid3, gbUnicode)
                tdbg3_LockTDBGrid(True)
            End If
            .Dispose()
        End With

    End Sub

    Private Sub btnInherit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInherit.Click
        Dim f As New D02F2012

        With f
            .AssetID = tdbg2.Columns(COL2_AssetID).Text
            .AssetAccountID = tdbg2.Columns(COL2_AssetAccountID).Text
            .DepAccountID = tdbg2.Columns(COL2_DepAccountID).Text
            .ShowDialog()
            If .dtF2012 IsNot Nothing Then
                Dim dt As DataTable = .dtF2012
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i).Item("Choose") = False
                Next

                dtGrid3 = dt
                LoadDataSource(tdbg3, dtGrid3, gbUnicode)
                tdbg3_LockTDBGrid(False)
            End If
            .Dispose()
        End With

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Dim f As New D02F2003_Frame1
        With f
            .AssetID = tdbcAssetID.Text
            .AssetName = txtAssetName.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub btnDepreciation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepreciation.Click
        '  If tdbcAssetID.Text <> "..." Then
        'UPDATE 2/7/2013 ID  57692
        If tdbcAssetID.Text = "..." Then
            Dim f As New D02F2003_Frame2
            With f
                .dtData = dtRecordSet_Asset
                .ShowDialog()
                dtRecordSet_Asset = .dtData
                .Dispose()
            End With
        End If
    End Sub

    Private Sub btnHotKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHotKeys.Click

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAddNew()
        sEditChangeNo = ""
        btnAttachment.Enabled = False
        btnPrint.Enabled = False
        btnNext.Enabled = False
        btnSave.Enabled = True
        tdbcAssetID.Focus()
        LoadTDBCombo()
        tdbcEffectReasonID.Text = ""
        'ID 92038 05.12.2016
        LoadTDBDCipNo()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
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

        '-------------------------------

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

    Private Sub txtServiceLife_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServiceLife.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtServiceLife_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServiceLife.LostFocus
        If IsNumeric(txtServiceLife.Text) Then
            If Number(txtServiceLife.Text) > MaxInt Then
                txtServiceLife.Text = ""
            End If
        Else
            txtServiceLife.Text = ""
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2006
    '# Created User: Hoàng Nhân
    '# Created Date: 29/11/2013 01:18:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2006() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luu mode Sua khac" & vbCrLf)
        sSQL &= "Exec D02P2006 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_batchID) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateChangeDate.Value) & COMMA 'ChangeDate, datetime, NOT NULL
        sSQL &= SQLString(txtDecisionNo.Text) & COMMA 'DecisionNo, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Notes1, varchar[250], NOT NULL
        sSQL &= SQLString("") & COMMA 'Notes2, varchar[250], NOT NULL
        sSQL &= SQLString("") & COMMA 'Notes3, varchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtNotes1, True) & COMMA 'Notes1U, nvarchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtNotes1, True) & COMMA 'Notes2U, nvarchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtNotes1, True) & COMMA 'Notes3U, nvarchar[250], NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDate.Value) & COMMA 'VoucherDate, datetime, NOT NULL
        sSQL &= SQLString("") & COMMA 'Notes, varchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtNotes, True) & COMMA 'NotesU, nvarchar[250], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcEffectReasonID)) 'EffectReasonID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5009
    '# Created User: KIM LONG
    '# Created Date: 12/12/2016 04:49:14
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5009() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Thuc thi store kiem tra so tien xay dung co ban truoc khi luu" & vbCrlf)
        sSQL &= "Exec D02P5009 "
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function


#Region "Events tdbcLocationID with txtLocationName"
    '20/11/2018, id 115884-Lỗi hiển thị dữ liệu D02
    Private Sub tdbcLocationID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcLocationID.SelectedValueChanged
        If tdbcLocationID.SelectedValue Is Nothing Then
            txtLocationName.Text = ""
        Else
            txtLocationName.Text = tdbcLocationID.Columns("LocationName").Value.ToString
        End If
    End Sub

    Private Sub tdbcLocationID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcLocationID.Validated
        clsFilterCombo.FilterCombo(tdbcLocationID, e)
        If tdbcLocationID.FindStringExact(tdbcLocationID.Text) = -1 Then
            tdbcLocationID.Text = ""
        End If
    End Sub
#End Region

    Private Sub chkIsChangeAssetAccount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsChangeAssetAccount.CheckedChanged
        'tdbg2.Splits(0).DisplayColumns(COL2_NewAAC).Visible = chkIsChangeAssetAccount.Checked'10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        SetEnableAsset_DepAccount()
    End Sub

    Private Sub chkIsChangeDepAccount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsChangeDepAccount.CheckedChanged
        'tdbg2.Splits(0).DisplayColumns(COL2_NewDAC).Visible = chkIsChangeDepAccount.Checked'10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        SetEnableAsset_DepAccount()
    End Sub

#Region "Events tdbcSuggestorID with txtSuggestorName"

    Private Sub tdbcSuggestorID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSuggestorID.SelectedValueChanged
        If tdbcSuggestorID.SelectedValue Is Nothing Then
            txtSuggestorName.Text = ""
        Else
            txtSuggestorName.Text = tdbcSuggestorID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcSuggestorID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSuggestorID.LostFocus
        'If tdbcSuggestorID.FindStringExact(tdbcSuggestorID.Text) = -1 Then
        '    tdbcSuggestorID.Text = ""
        'End If
    End Sub

    Private Sub tdbcSuggestorID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSuggestorID.Validated
        clsFilterCombo.FilterCombo(tdbcSuggestorID, e)
        If tdbcSuggestorID.FindStringExact(tdbcSuggestorID.Text) = -1 Then
            tdbcSuggestorID.Text = ""
        End If
    End Sub

#End Region


    Private Sub chkReceiveManage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReceiveManage.CheckedChanged
        tdbcObjectTypeID.Enabled = chkReceiveManage.Checked
        tdbcObjectID.Enabled = chkReceiveManage.Checked
        tdbcEmployeeID.Enabled = chkReceiveManage.Checked
        tdbcLocationID.Enabled = chkReceiveManage.Checked
        tdbcManagementObjTypeID.Enabled = chkChangeManagement.Checked
        tdbcManagementObjID.Enabled = chkChangeManagement.Checked
        If chkReceiveManage.Checked Then

            tdbcObjectTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            tdbcObjectID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            tdbcLocationID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        Else
            ' ''tdbcEmployeeID.Enabled = False
            ' ''tdbcLocationID.Enabled = False
            tdbcObjectTypeID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
            tdbcObjectID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
            tdbcEmployeeID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
            tdbcLocationID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
        End If
        If chkReceiveManage.Checked And chkChangeManagement.Checked Then
            tdbcManagementObjTypeID.Enabled = chkChangeManagement.Checked
            tdbcManagementObjID.Enabled = chkChangeManagement.Checked
            tdbcObjectTypeID.Enabled = chkReceiveManage.Checked
            tdbcObjectID.Enabled = chkReceiveManage.Checked
            tdbcEmployeeID.Enabled = chkReceiveManage.Checked
            tdbcLocationID.Enabled = chkReceiveManage.Checked
            tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            tdbcLocationID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        End If
        'If chkReceiveManage.Checked Then
        '    tdbcObjectTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        '    tdbcObjectID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        '    tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        '    tdbcLocationID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'Else
        '    tdbcObjectTypeID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
        '    tdbcObjectID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
        '    tdbcEmployeeID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
        '    tdbcLocationID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
        'End If
        'If chkReceiveManage.Checked And chkChangeManagement.Checked Then
        '    tdbcManagementObjTypeID.Enabled = chkChangeManagement.Checked
        '    tdbcManagementObjID.Enabled = chkChangeManagement.Checked
        '    tdbcObjectTypeID.Enabled = chkReceiveManage.Checked
        '    tdbcObjectID.Enabled = chkReceiveManage.Checked
        '    tdbcEmployeeID.Enabled = chkReceiveManage.Checked
        '    tdbcLocationID.Enabled = chkReceiveManage.Checked
        '    tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        '    tdbcLocationID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'End If
    End Sub

    Private Sub chkChangeManagement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChangeManagement.CheckedChanged
        tdbcObjectTypeID.Enabled = chkReceiveManage.Checked
        tdbcObjectID.Enabled = chkReceiveManage.Checked
        tdbcManagementObjTypeID.Enabled = chkChangeManagement.Checked
        tdbcManagementObjID.Enabled = chkChangeManagement.Checked
        tdbcEmployeeID.Enabled = chkReceiveManage.Checked
        tdbcLocationID.Enabled = chkReceiveManage.Checked
        If chkChangeManagement.Checked Then

            tdbcManagementObjTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            tdbcManagementObjID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            tdbcEmployeeID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
            tdbcLocationID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
        Else
            'tdbcEmployeeID.Enabled = True
            'tdbcLocationID.Enabled = True
            tdbcManagementObjTypeID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
            tdbcManagementObjID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
            'tdbcEmployeeID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
            'tdbcLocationID.EditorBackColor = New C1.Win.C1List.C1Combo().EditorBackColor
        End If

        If chkReceiveManage.Checked And chkChangeManagement.Checked Then
            tdbcManagementObjTypeID.Enabled = chkChangeManagement.Checked
            tdbcManagementObjID.Enabled = chkChangeManagement.Checked
            tdbcObjectTypeID.Enabled = chkReceiveManage.Checked
            tdbcObjectID.Enabled = chkReceiveManage.Checked
            tdbcEmployeeID.Enabled = chkReceiveManage.Checked
            tdbcLocationID.Enabled = chkReceiveManage.Checked
            tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            tdbcLocationID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        End If
    End Sub

    Private Function CheckUseProperty() As Boolean
        Dim bCheck As Boolean = False
        Dim sSQL As String = "SELECT UseProperty FROM D02T0000 WITH(NOLOCK)"
        Dim _dt As DataTable = ReturnDataTable(sSQL)
        If _dt.Rows.Count > 0 Then bCheck = L3Bool(_dt.Rows(0)("UseProperty"))

        Return bCheck
    End Function


#Region "Events tdbcManagementObjTypeID load tdbcObjectID with tdbcManagementObjID"

    Private Sub tdbcManagementObjTypeID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcManagementObjTypeID.GotFocus
        'Dùng phím Enter
        tdbcManagementObjTypeID.Tag = tdbcManagementObjTypeID.Text
    End Sub

    Private Sub tdbcManagementObjTypeID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcManagementObjTypeID.MouseDown
        'Di chuyển chuột
        tdbcManagementObjTypeID.Tag = tdbcManagementObjTypeID.Text
    End Sub

    Private Sub tdbcManagementObjTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcManagementObjTypeID.SelectedValueChanged
        Try
            clsFilterCombo.LoadtdbcObjectID(tdbcManagementObjID, dtManagementObjID, ReturnValueC1Combo(tdbcManagementObjTypeID))
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace.ToString)
        End Try

        tdbcManagementObjID.Text = ""
    End Sub

    'Private Sub tdbcManagementObjTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcManagementObjTypeID.LostFocus

    'End Sub

    Private Sub tdbcManagementObjTypeID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcManagementObjTypeID.Validated
        clsFilterCombo.FilterCombo(tdbcManagementObjTypeID, e)
        If tdbcManagementObjTypeID.Tag.ToString = "" And tdbcManagementObjTypeID.Text = "" Then Exit Sub
        If tdbcManagementObjTypeID.Tag.ToString = tdbcManagementObjTypeID.Text And tdbcManagementObjTypeID.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcManagementObjTypeID.FindStringExact(tdbcManagementObjTypeID.Text) = -1 OrElse tdbcManagementObjTypeID.SelectedValue Is Nothing Then
            tdbcManagementObjID.Text = ""
            Exit Sub
        End If
    End Sub
    Private Sub tdbcManagementObjID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcManagementObjID.SelectedValueChanged
        If tdbcManagementObjID.SelectedValue Is Nothing Then
            txtManagementObjName.Text = ""
        Else
            txtManagementObjName.Text = tdbcManagementObjID.Columns("ObjectName").Value.ToString
        End If
    End Sub

    Private Sub tdbcManagementObjID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcManagementObjID.LostFocus
        If tdbcManagementObjID.FindStringExact(tdbcManagementObjID.Text) = -1 Then
            tdbcManagementObjID.Text = ""
        End If
    End Sub

#End Region

    'Đính kèm
    Private Sub btnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachment.Click
        '19/12/2019, Nguyễn Thị Hân:id 126523-Bổ sung tính năng đính kèm file - nghiệp vụ tác động TSCĐ
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "TableName", "D02T0202")
        SetProperties(arrPro, "Key1ID", _groupID)
        SetProperties(arrPro, "Status", L3Byte(IIf(_FormState = EnumFormState.FormView, 0, 1)))
        CallFormShowDialog("D91D0340", "D91F4010", arrPro)

        btnAttachment.Text = rL3("Dinh_ke_m") & Space(1) & " (" & ReturnAttachmentNumber("D02T0202", _groupID) & ")"  'Đính kèm
    End Sub

#Region "Events tdbcAssetAccountID"
    'Private Sub tdbcAssetAccountID_Validated(sender As Object, e As EventArgs) Handles tdbcAssetAccountID.Validated

    'End Sub

    Private Sub tdbcAssetAccountID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tdbcAssetAccountID.Validating
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        If tdbcAssetAccountID.Tag Is Nothing Then Exit Sub
        If tdbcAssetAccountID.Tag.ToString = tdbcAssetAccountID.Text Then Exit Sub
        If tdbcAssetAccountID.FindStringExact(tdbcAssetAccountID.Text) = -1 Then tdbcAssetAccountID.Text = ""
        If Loadtdbg3ByAssetAccount() = False Then e.Cancel = True
        tdbcAssetAccountID.Tag = tdbcAssetAccountID.Text
    End Sub

    Private Function Loadtdbg3ByAssetAccount() As Boolean
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        If tdbg3.RowCount > 0 Then
            Dim dr() As DataRow = dtGrid3.Select("TransactionTypeID = 'AAC'")
            If dr.Length > 0 Then
                If D99C0008.MsgAsk(rL3("Du_lieu_but_toan_se_thay_doi_Ban_co_muon_tiep_tuc"), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    tdbcAssetAccountID.Text = tdbcAssetAccountID.Tag.ToString
                    Return False
                End If

                dtGrid3.Rows.Clear()
                LoadDefaultGrid3()
            Else
                If dtGrid3.Rows.Count > 0 Then dtGrid3.Rows.Clear()
                LoadDefaultGrid3()
            End If
        Else
            LoadDefaultGrid3()
        End If
        Return True
    End Function
#End Region

#Region "Events tdbcDepAccountID"
    'Private Sub tdbcDepAccountID_Validated(sender As Object, e As EventArgs) Handles tdbcDepAccountID.Validated


    'End Sub

    Private Sub tdbcDepAccountID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tdbcDepAccountID.Validating
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        If tdbcDepAccountID.Tag Is Nothing Then Exit Sub
        If tdbcDepAccountID.Tag.ToString = tdbcDepAccountID.Text Then Exit Sub
        If tdbcDepAccountID.FindStringExact(tdbcDepAccountID.Text) = -1 Then tdbcDepAccountID.Text = ""
        If Loadtdbg3ByDepAccount() = False Then e.Cancel = True
        tdbcDepAccountID.Tag = tdbcDepAccountID.Text
    End Sub

    Private Function Loadtdbg3ByDepAccount() As Boolean
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        If tdbg3.RowCount > 0 Then
            Dim dr() As DataRow = dtGrid3.Select("TransactionTypeID = 'DAC'")
            If dr.Length > 0 Then
                If D99C0008.MsgAsk(rL3("Du_lieu_but_toan_se_thay_doi_Ban_co_muon_tiep_tuc"), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    tdbcDepAccountID.Text = tdbcDepAccountID.Tag.ToString
                    Return False
                End If

                dtGrid3.Rows.Clear()
                LoadDefaultGrid3()
            Else
                If dtGrid3.Rows.Count > 0 Then dtGrid3.Rows.Clear()
                LoadDefaultGrid3()
            End If
        Else
            LoadDefaultGrid3()
        End If
        Return True
    End Function
#End Region

    Private Sub SetEnableAsset_DepAccount()
        '10/11/2021, Phạm Thị Mỹ Tiên:id 191804-[LAF] D02 - Phát triển nghiệp vụ tác động Thay đổi TK Tài sản, TK khấu hao của Mã TSCĐ
        If chkIsChangeAssetAccount.Checked = True Then
            UnReadOnlyControl(tdbcAssetAccountID)
        Else
            ReadOnlyControl(tdbcAssetAccountID)
            tdbcAssetAccountID.Text = ""
        End If

        If chkIsChangeDepAccount.Checked = True Then
            UnReadOnlyControl(tdbcDepAccountID)
        Else
            ReadOnlyControl(tdbcDepAccountID)
            tdbcDepAccountID.Text = ""
        End If
    End Sub

    Private Sub VisiblechkIsNotCalDep()
        '24/3/2022, Đinh Văn Khanh:id 217076-SVI_ Cập nhật PP khấu hao TSCD cho tất cả các TS có nghiệp vụ tác động
        chkIsNotCalDep.Visible = L3Bool(ReturnValueC1Combo(tdbcChangeNo, "UseAccount"))
    End Sub


End Class