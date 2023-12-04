'#-------------------------------------------------------------------------------------
'# Created Date: 10/09/2006 2:14:04 PM
'# Created User: Trần Thị ÁiTrâm
'# Modify Date: 10/09/2006 2:14:04 PM
'# Modify User: Trần Thị ÁiTrâm
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System

Public Class D02F2004

#Region "Const of tdbg - Total of Columns: 38"
    Private Const COL_BatchID As Integer = 0          ' BatchID
    Private Const COL_TransactionID As Integer = 1    ' TransactionID
    Private Const COL_RefDate As Integer = 2          ' Ngày hóa đơn
    Private Const COL_SeriNo As Integer = 3           ' Số Sêri
    Private Const COL_RefNo As Integer = 4            ' Số hóa đơn
    Private Const COL_Description As Integer = 5      ' Diễn giải
    Private Const COL_DebitAccountID As Integer = 6   ' TK nợ
    Private Const COL_CreditAccountID As Integer = 7  ' TK có
    Private Const COL_CurrencyID As Integer = 8       ' Loại tiền
    Private Const COL_ExchangeRate As Integer = 9     ' Tỷ giá
    Private Const COL_OriginalAmount As Integer = 10  ' Nguyên tệ
    Private Const COL_ConvertedAmount As Integer = 11 ' Qui đổi
    Private Const COL_ObjectTypeID As Integer = 12    ' Loại đối tượng
    Private Const COL_ObjectID As Integer = 13        ' Mã đối tượng
    Private Const COL_ObjectName As Integer = 14      ' Tên đối tượng
    Private Const COL_VATNo As Integer = 15           ' Mã số thuế
    Private Const COL_VATTypeID As Integer = 16       ' Loại hóa đơn
    Private Const COL_VATGroupID As Integer = 17      ' Nhóm thuế
    Private Const COL_SourceID As Integer = 18        ' Nguồn vốn
    Private Const COL_Ana01ID As Integer = 19         ' Khoản mục 01
    Private Const COL_Ana02ID As Integer = 20         ' Khoản mục 02
    Private Const COL_Ana03ID As Integer = 21         ' Khoản mục 03
    Private Const COL_Ana04ID As Integer = 22         ' Khoản mục 04
    Private Const COL_Ana05ID As Integer = 23         ' Khoản mục 05
    Private Const COL_Ana06ID As Integer = 24         ' Khoản mục 06
    Private Const COL_Ana07ID As Integer = 25         ' Khoản mục 07
    Private Const COL_Ana08ID As Integer = 26         ' Khoản mục 08
    Private Const COL_Ana09ID As Integer = 27         ' Khoản mục 09
    Private Const COL_Ana10ID As Integer = 28         ' Khoản mục 10
    Private Const COL_ModuleID As Integer = 29        ' ModuleID
    Private Const COL_CipID As Integer = 30           ' CipID
    Private Const COL_CipNo As Integer = 31           ' Mã XDCB
    Private Const COL_DecimalPlaces As Integer = 32   ' DecimalPlaces
    Private Const COL_ProjectID As Integer = 33       ' Dự án
    Private Const COL_ProjectName As Integer = 34     ' Tên dự án
    Private Const COL_TaskID As Integer = 35          ' Hạng mục
    Private Const COL_TaskName As Integer = 36        ' Tên hạng mục
    Private Const COL_PeriodID As Integer = 37        ' Tập phí
#End Region


    Private bInsertRow As Boolean = False
    Private _batchID As String
    Private _voucherTypeID As String
    Private _voucherNo As String
    Dim sTransactionID As String
    Private dtObject As DataTable
    Private dtMain As DataTable
    Private dtExchangeRate As DataTable
    Private iLastCol As Integer
    Dim sOldVoucherNo As String = "" 'Lưu lại số phiếu cũ
    Dim bEditVoucherNo As Boolean = False '= True: có nhấn F2; = False: không 
    Dim bFirstF2 As Boolean = False 'Nhấn F2 lần đầu tiên 

    Dim clsFilterDropdown As Lemon3.Controls.FilterDropdown

    '---Kiểm tra khoản mục theo chuẩn gồm 6 bước
    '--- Chuẩn Khoản mục b1: Khai báo biến
#Region "Biến khai báo cho khoản mục"

    Private Const SplitAna As Int16 = 1 ' Ghi nhận Khoản mục chứa ở Split nào
    Dim bUseAna As Boolean 'Kiểm tra có sử dụng Khoản mục không, để set thuộc tính Enabled nút Khoản mục 
    'Dim iDisplayAnaCol As Integer = 0 ' Cột Khoản mục đầu tiên được hiển thị, khi nhấn nút Khoản mục thì Focus đến cột đó
    'Dim xCheckAna(9) As Boolean 'Khởi động tại Form_load: Ghi lại việc kiểm tra lần đầu Lưu, khi nhấn Lưu lần thứ 2 thì không cần kiểm tra nữa

#End Region

    Public Property BatchID() As String
        Get
            Return _batchID
        End Get
        Set(ByVal value As String)
            If BatchID = value Then
                _batchID = ""
                Return
            End If
            _batchID = value
        End Set
    End Property

    Public Property VoucherTypeID() As String
        Get
            Return _voucherTypeID
        End Get
        Set(ByVal value As String)
            If VoucherTypeID = value Then
                _voucherTypeID = ""
                Return
            End If
            _voucherTypeID = value
        End Set
    End Property

    Public Property VoucherNo() As String
        Get
            Return _voucherNo
        End Get
        Set(ByVal value As String)
            If VoucherNo = value Then
                _voucherNo = ""
                Return
            End If
            _voucherNo = value
        End Set
    End Property

    Private _createUserID As String
    Public Property CreateUserID() As String
        Get
            Return _createUserID
        End Get
        Set(ByVal Value As String)
            _createUserID = value
        End Set
    End Property

    Private _createUserDate As String
    Public Property CreateUserDate() As String
        Get
            Return _createUserDate
        End Get
        Set(ByVal Value As String)
            _createUserDate = value
        End Set
    End Property

    Dim sCreateUserID As String
    Dim sCreateUserDate As String
    Dim sLastModifyDate As String
    'Trần Thị Ái Trâm - 10/12/2009 - Chuẩn load combo khi Sửa b1:
    Dim sEditVoucherTypeID As String = ""
    Dim dtSource, dtAnaCaption As DataTable
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            tdbg_NumberFormat()
            '--- Chuẩn Khoản mục b2: Lấy caption cho 10 khoản mục
            bUseAna = LoadTDBGridAnalysisCaption(D02, tdbg, COL_Ana01ID, SplitAna, True, gbUnicode, dtAnaCaption)

            '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
            clsFilterDropdown = New Lemon3.Controls.FilterDropdown()
            clsFilterDropdown.CheckD91 = True 'Giá trị mặc định False
            clsFilterDropdown.UseFilterDropdown(tdbg, COL_Ana01ID, COL_Ana02ID, COL_Ana03ID, COL_Ana04ID, COL_Ana05ID, COL_Ana06ID, COL_Ana07ID, COL_Ana08ID, COL_Ana09ID, COL_Ana10ID, COL_CipNo, COL_ProjectID, COL_TaskID, COL_PeriodID)

            '------------------------------------
            'Trần Thị Ái Trâm - 10/12/2009 - Chuẩn load combo khi Sửa b2:
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = True
                    btnNext.Enabled = False
                    LoadTDBCombo()
                    LoadTDBDropDown()
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                    LoadTDBDropDown()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                    LoadTDBDropDown()
            End Select
        End Set
    End Property

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Trần Thị Ái Trâm - 10/12/2009 - Chuẩn load combo khi Sửa b5:
        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D02, sEditVoucherTypeID, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdAccountID
        sSQL = "Select AccountID," & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName" & UnicodeJoin(gbUnicode), "AccountName01" & UnicodeJoin(gbUnicode)).ToString & " as AccountName, GroupID" & vbCrLf
        sSQL &= " From D90T0001 WITH(NOLOCK) Where Disabled=0 And AccountStatus=0 And OffAccount=0 Order by AccountID"
        LoadDataSource(tdbdAccountID, sSQL, gbUnicode)

        'Load tdbdCurrencyID
        sSQL = "Select D91T0010.CurrencyID, D91T0010.CurrencyName" & UnicodeJoin(gbUnicode) & " as CurrencyName, D91T0010.ExchangeRate, D91T0010.Operator," & vbCrLf
        sSQL &= "(Case When D91T0010.CurrencyID=A.BaseCurrencyID Then D90_ConvertedDecimals Else D91T0010.DecimalPlaces End) As DecimalPlaces" & vbCrLf
        sSQL &= " From D91T0010 WITH(NOLOCK), (Select Top 1 BaseCurrencyID, D90_ConvertedDecimals From D91T0025 WITH(NOLOCK)) As A " & vbCrLf
        sSQL &= "Order By CurrencyID"
        LoadDataSource(tdbdCurrencyID, sSQL, gbUnicode)

        'Load tdbdObjectTypeID
        sSQL = "Select ObjectTypeID," & IIf(geLanguage = EnumLanguage.Vietnamese, "ObjectTypeName" & UnicodeJoin(gbUnicode), "ObjectTypeName01" & UnicodeJoin(gbUnicode)).ToString & " As ObjectTypeName From D91T0005 WITH(NOLOCK) Order By ObjectTypeID "
        LoadDataSource(tdbdObjectTypeID, sSQL, gbUnicode)

        'Load tdbdObjectID
        sSQL = "Select ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName, ObjectTypeID, VATNo From Object WITH(NOLOCK) Where Disabled=0 Order By ObjectID "
        dtObject = ReturnDataTable(sSQL)

        'Load tdbdVATTypeID
        sSQL = "Select VATTypeID, Description" & UnicodeJoin(gbUnicode) & "  as Description From D91T9001 WITH(NOLOCK) " & vbCrLf
        If geLanguage = EnumLanguage.Vietnamese Then
            sSQL &= "Where Language='84'" & vbCrLf
        ElseIf geLanguage = EnumLanguage.English Then
            sSQL &= "Where Language='01'" & vbCrLf
        End If
        sSQL &= " Order By VATTypeID "
        LoadDataSource(tdbdVATTypeID, sSQL, gbUnicode)

        'Load tdbdVATGroupID
        sSQL = "Select VATGroupID, VATGroupName" & UnicodeJoin(gbUnicode) & " as VATGroupName, RateTax From D91T0040 WITH(NOLOCK) Where Disabled=0 Order By VATGroupID "
        LoadDataSource(tdbdVATGroupID, sSQL, gbUnicode)
        'Load tdbdSourceID
        sSQL = "Select SourceID, SourceName" & UnicodeJoin(gbUnicode) & " as SourceName From D02T0013 WITH(NOLOCK) Where Disabled=0 "
        LoadDataSource(tdbdSourceID, sSQL, gbUnicode)

        'Load tdbdCipID
        sSQL = " Select CipID, CipNo,CipName" & UnicodeJoin(gbUnicode) & "  as CipName "
        sSQL &= " From D02T0100 T10 WITH(NOLOCK) INNER JOIN Account AC ON AC.AccountID=T10.AccountID "
        sSQL &= " WHERE T10.Status <> 2 And T10.Disabled = 0 And T10.DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " ORDER BY CipID "
        LoadDataSource(tdbdCipID, sSQL, gbUnicode)

        '--- Chuẩn Khoản mục b3: Load 10 khoản mục
        LoadTDBDropDownAna(tdbdAna01ID, tdbdAna02ID, tdbdAna03ID, tdbdAna04ID, tdbdAna05ID, tdbdAna06ID, tdbdAna07ID, tdbdAna08ID, tdbdAna09ID, tdbdAna10ID, tdbg, COL_Ana01ID, gbUnicode)
        '------------------------------------------
        'Them ngay 23/11/2012 theo incident 52571 của Thị Hiệp bởi Văn Vinh
        LoadProject(tdbdProjectID, dtSource)

        '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
        'Load tdbdPeriodID
        sSQL = "Select PeriodID, WorkOrderNo, NoteU As Note " & vbCrLf
        sSQL &= "From 	D08N0100 (" & SQLString(gsDivisionID) & ", " & SQLNumber(giTranMonth) & ", " & SQLNumber(giTranYear) & ",'2') " & vbCrLf
        sSQL &= "Order by 	PeriodID"
        LoadDataSource(tdbdPeriodID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBDropdownObjectID(ByVal sObjectTypeID As String)
        LoadDataSource(tdbdObjectID, ReturnTableFilter(dtObject, "ObjectTypeID=" & SQLString(sObjectTypeID)), gbUnicode)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D02F2004_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If gbSavedOK = True Then
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Output01", gbSavedOK.ToString) 'PARA_FormState
        End If
    End Sub

    Private Sub D02F2004_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.Control Then
            If e.KeyCode = Keys.F1 Then
                btnHotKey_Click(Nothing, Nothing)
                Exit Sub
            End If

            If e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
                'btnAna.Focus()
                If btnAna.Enabled Then btnAna_Click(Nothing, Nothing)
                tdbg.Col = COL_Ana01ID
                tdbg.Row = 0
                'tdbg.Focus()
                Exit Sub
            End If

            If e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
                'btnOther.Focus()
                If btnOther.Enabled Then btnOther_Click(Nothing, Nothing)
                tdbg.Col = COL_CipNo
                tdbg.Row = 0
                'tdbg.Focus()
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
    End Sub

    Private Sub D02F2004_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gbSavedOK = False
        Loadlanguage()
        ResetSplitDividerSize(tdbg)
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        SetBackColorObligatory()
        CheckIdTextBox(txtVoucherNo, txtVoucherNo.MaxLength)
        InputbyUnicode(Me, gbUnicode)
        'LoadTDBGridAnalysisCaption(D02, tdbg, COL_Ana01ID, SPLIT1,True)
        tdbg_LockedColumns()
        If PARA_ModuleID = "54" Then
            tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectID).Locked = True
            tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskID).Locked = True
            tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If
        ClickButton(Button.Ana)
        iLastCol = CountCol(tdbg, tdbg.Splits.Count - 1)
        SetResolutionForm(Me)
    End Sub

    Private Sub LoadAddNew()
        c1dateVoucherDate.Value = Date.Today
        'btnSetNewKey.Enabled = False
        _batchID = ""
        LoadForm()
    End Sub

    'Private Sub tdbg_NumberFormat()
    '    tdbg.Columns(COL_ExchangeRate).NumberFormat = DxxFormat.ExchangeRateDecimals

    '    tdbg.Columns(COL_OriginalAmount).NumberFormat = DxxFormat.DecimalPlaces
    '    tdbg.Columns(COL_ConvertedAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
    'End Sub

    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_ExchangeRate).DataField, DxxFormat.ExchangeRateDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_OriginalAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_ConvertedAmount).DataField, DxxFormat.D90_ConvertedDecimals, 28, 8)
        InputNumber(tdbg, arr)
    End Sub

    Private Sub tdbg_ButtonClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ButtonClick
        If clsFilterDropdown.IsNewFilter = False Then Exit Sub
        Select Case tdbg.Col
            Case COL_Ana01ID To COL_Ana10ID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg.Columns(tdbg.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbg.Col, dr)
            Case COL_CipNo 
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbdCipID)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbg.Col, dr)
            Case COL_ProjectID, COL_TaskID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, tdbg.Columns(tdbg.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbg.Col, dr)
            Case COL_PeriodID
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbdPeriodID)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbg.Col, dr)
        End Select
    End Sub



    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case tdbg.Col
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                    If tdbg.Col = COL_OriginalAmount Or tdbg.Col = COL_ConvertedAmount Then Exit Sub
                    If tdbg.Col = COL_ProjectID Or tdbg.Col = COL_TaskID Then
                        Dim iCols() As Integer = {COL_ProjectID, COL_ProjectName, COL_TaskID, COL_TaskName}
                        CopyColumnArr(tdbg, tdbg.Col, iCols)
                    Else
                        CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
                    End If
                Else
                    D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                    Return
                End If
        End Select
    End Sub

    Public Sub CopyColumn(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String)
        Dim sValue1 As String = ""
        Dim sValue2 As String = ""
        Dim sValue3 As String = ""
        Dim sValue4 As String = ""
        Dim Flag As DialogResult
        Flag = D99C0008.MsgCopyColumn()
        If ColCopy = COL_CurrencyID Then
            sValue1 = c1Grid.Columns(COL_CurrencyID).Text
            sValue2 = c1Grid.Columns(COL_ExchangeRate).Text
            sValue3 = c1Grid.Columns(COL_OriginalAmount).Text
            sValue4 = c1Grid.Columns(COL_ConvertedAmount).Text
        ElseIf ColCopy = COL_ObjectID Then
            sValue1 = c1Grid.Columns(COL_ObjectID).Text
            sValue2 = c1Grid.Columns(COL_ObjectName).Text
            sValue3 = c1Grid.Columns(COL_VATNo).Text
        ElseIf ColCopy = COL_ProjectID Then
            sValue1 = c1Grid.Columns(COL_ProjectName).Text
            sValue2 = c1Grid.Columns(COL_TaskID).Text
            sValue3 = c1Grid.Columns(COL_TaskName).Text
        ElseIf ColCopy = COL_TaskID Then
            sValue1 = c1Grid.Columns(COL_ProjectID).Text
            sValue2 = c1Grid.Columns(COL_ProjectName).Text
            sValue3 = c1Grid.Columns(COL_TaskName).Text
        End If
        If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
            For i As Integer = 0 To c1Grid.RowCount - 1
                If c1Grid(i, ColCopy).ToString = "" Then
                    c1Grid(i, ColCopy) = sValue
                    If ColCopy = COL_CurrencyID Then
                        c1Grid(i, COL_CurrencyID) = sValue1
                        c1Grid(i, COL_ExchangeRate) = sValue2
                        c1Grid(i, COL_OriginalAmount) = sValue3
                        c1Grid(i, COL_ConvertedAmount) = sValue4
                    ElseIf ColCopy = COL_ObjectID Then
                        c1Grid(i, COL_ObjectID) = sValue1
                        c1Grid(i, COL_ObjectName) = sValue2
                        c1Grid(i, COL_VATNo) = sValue3

                    ElseIf ColCopy = COL_ProjectID Then
                        c1Grid(i, COL_ProjectName) = sValue1
                        c1Grid(i, COL_TaskID) = sValue2
                        c1Grid(i, COL_TaskName) = sValue3
                    ElseIf ColCopy = COL_TaskID Then
                        c1Grid(i, COL_ProjectID) = sValue1
                        c1Grid(i, COL_ProjectName) = sValue2
                        c1Grid(i, COL_TaskName) = sValue3
                    End If
                End If
            Next
        ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy nhung dong con trong ' Copy het

            For i As Integer = 0 To c1Grid.RowCount - 1
                c1Grid(i, ColCopy) = sValue
                If ColCopy = COL_CurrencyID Then
                    c1Grid(i, COL_CurrencyID) = sValue1
                    c1Grid(i, COL_ExchangeRate) = sValue2
                    c1Grid(i, COL_OriginalAmount) = sValue3
                    c1Grid(i, COL_ConvertedAmount) = sValue4
                ElseIf ColCopy = COL_ObjectID Then
                    c1Grid(i, COL_ObjectID) = sValue1
                    c1Grid(i, COL_ObjectName) = sValue2
                    c1Grid(i, COL_VATNo) = sValue3
                ElseIf ColCopy = COL_ProjectID Then
                    c1Grid(i, COL_ProjectName) = sValue1
                    c1Grid(i, COL_TaskID) = sValue2
                    c1Grid(i, COL_TaskName) = sValue3
                ElseIf ColCopy = COL_TaskID Then
                    c1Grid(i, COL_ProjectID) = sValue1
                    c1Grid(i, COL_ProjectName) = sValue2
                    c1Grid(i, COL_TaskName) = sValue3
                End If
            Next
            c1Grid(0, ColCopy) = sValue
            If ColCopy = COL_CurrencyID Then
                c1Grid(0, COL_CurrencyID) = sValue1
                c1Grid(0, COL_ExchangeRate) = sValue2
                c1Grid(0, COL_OriginalAmount) = sValue3
                c1Grid(0, COL_ConvertedAmount) = sValue4
            ElseIf ColCopy = COL_ObjectID Then
                c1Grid(0, COL_ObjectID) = sValue1
                c1Grid(0, COL_ObjectName) = sValue2
                c1Grid(0, COL_VATNo) = sValue3
            ElseIf ColCopy = COL_ProjectID Then
                c1Grid(0, COL_ProjectName) = sValue1
                c1Grid(0, COL_TaskID) = sValue2
                c1Grid(0, COL_TaskName) = sValue3
            ElseIf ColCopy = COL_TaskID Then
                c1Grid(0, COL_ProjectID) = sValue1
                c1Grid(0, COL_ProjectName) = sValue2
                c1Grid(0, COL_TaskName) = sValue3
            End If
        Else
            Exit Sub
        End If
    End Sub
 
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If clsFilterDropdown.CheckKeydownFilterDropdown(tdbg, e) Then
            Select Case tdbg.Col
                Case COL_Ana01ID To COL_Ana10ID
                    Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg.Columns(tdbg.Col).DataField)
                    If tdbd Is Nothing Then Exit Select

                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate(tdbg.Col, dr)
                    Exit Sub
                Case COL_CipNo
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbdCipID)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate(tdbg.Col, dr)
                    Exit Sub
                Case COL_ProjectID, COL_TaskID
                    Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, tdbg.Columns(tdbg.Col).DataField)
                    If tdbd Is Nothing Then Exit Select
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate(tdbg.Col, dr)
                    Exit Sub
                Case COL_PeriodID
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbdPeriodID)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate(tdbg.Col, dr)
                    Exit Sub
            End Select
        End If

        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = iLastCol Then
                HotKeyEnterGrid(tdbg, COL_RefDate, e)
            End If
        End If
        If e.Shift And e.KeyCode = Keys.Insert Then
            bInsertRow = True
            HotKeyShiftInsert(tdbg, 0, COL_RefDate, tdbg.Columns.Count)
        End If
        If e.KeyCode = Keys.F7 Then
            
            If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                Select Case tdbg.Col
                    Case COL_ProjectID
                        HotKeyF7(tdbg, COL_ProjectID, COL_ProjectName)
                    Case COL_TaskID
                        HotKeyF7(tdbg, COL_TaskID, COL_TaskName, COL_ProjectID, COL_ProjectName)
                    Case Else
                        HotKeyF7(tdbg)
                End Select

            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If
        End If
        If e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
        End If
        If e.Alt And e.Control And e.KeyCode = Keys.C Then
            If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If

        End If
        HotKeyDownGrid(e, tdbg, COL_RefDate, 0, 1, True, True, True, COL_Description, txtNotes.Text)

    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_SeriNo
                e.KeyChar = UCase(e.KeyChar)
                'Case COL_ExchangeRate
                '    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                'Case COL_OriginalAmount
                '    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
                'Case COL_ConvertedAmount
                '    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "Events tdbcVoucherTypeID with txtVoucherNo"

#Region "Events tdbcVoucherTypeID with txtVoucherNo"

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        bEditVoucherNo = False
        bFirstF2 = False
        If tdbcVoucherTypeID.SelectedValue Is Nothing OrElse tdbcVoucherTypeID.Text = "" Then
            txtVoucherNo.Text = ""
            ReadOnlyControl(txtVoucherNo)
            Exit Sub
        End If
        If _FormState = EnumFormState.FormAdd Then
            If tdbcVoucherTypeID.Columns("Auto").Text = "1" Then 'Sinh tu dong
                txtVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
                ReadOnlyControl(txtVoucherNo)
            Else
                txtVoucherNo.Text = ""
                UnReadOnlyControl(txtVoucherNo, True)
            End If
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcVoucherTypeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
        End If
    End Sub
#End Region

#End Region

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_DebitAccountID
            Case COL_CreditAccountID
            Case COL_CurrencyID
                GetExchangeRate()
                tdbg.Columns(COL_ExchangeRate).Text = dtExchangeRate.Rows(0).Item("ExchangeRate").ToString
                CalcuteConvertedAmount()
                If tdbg.Columns(COL_OriginalAmount).Text <> "" Then
                    tdbg.Columns(COL_OriginalAmount).Text = SQLNumber(tdbg.Columns(COL_OriginalAmount).Text, InsertFormat(ReturnValueC1DropDown(tdbdCurrencyID, "DecimalPlaces", "CurrencyID = " & SQLString(tdbg.Columns(COL_CurrencyID).Text))))
                End If
            Case COL_ObjectTypeID
                tdbg.Columns(COL_ObjectTypeID).Text = tdbdObjectTypeID.Columns("ObjectTypeID").Text
                tdbg.Columns(COL_ObjectID).Text = ""
                tdbg.Columns(COL_ObjectName).Text = ""
                tdbg.Columns(COL_VATNo).Text = ""
            Case COL_ObjectID
                tdbg.Columns(COL_ObjectName).Text = tdbdObjectID.Columns("ObjectName").Text()
                tdbg.Columns(COL_VATNo).Text = tdbdObjectID.Columns("VATNo").Text()
            Case COL_CipNo
                tdbg.Columns(COL_CipID).Text = tdbdCipID.Columns("CipID").Text()
            Case COL_ProjectID
                tdbg.Columns(COL_ProjectName).Text = tdbdProjectID.Columns("ProjectName").Text
                tdbg.Columns(COL_TaskID).Text = ""
                tdbg.Columns(COL_TaskName).Text = ""
            Case COL_TaskID
                tdbg.Columns(COL_TaskName).Text = tdbdTaskID.Columns("TaskName").Text
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_RefDate
                tdbg.Columns(e.ColIndex).Text = L3DateValue(tdbg.Columns(e.ColIndex).Text)
            
            Case COL_DebitAccountID
                If tdbg.Columns(COL_DebitAccountID).Text <> tdbdAccountID.Columns("AccountID").Text Then
                    tdbg.Columns(COL_DebitAccountID).Text = ""
                End If
            Case COL_CreditAccountID
                If tdbg.Columns(COL_CreditAccountID).Text <> tdbdAccountID.Columns("AccountID").Text Then
                    tdbg.Columns(COL_CreditAccountID).Text = ""
                End If
            Case COL_CurrencyID
                If tdbg.Columns(COL_CurrencyID).Text <> tdbdCurrencyID.Columns("CurrencyID").Text Then
                    tdbg.Columns(COL_CurrencyID).Text = ""
                    tdbg.Columns(COL_ExchangeRate).Text = ""
                End If
                'Case COL_ExchangeRate
                '    If Not IsNumeric(tdbg.Columns(COL_ExchangeRate).Text) Then e.Cancel = True
                'Case COL_OriginalAmount
                '    If Not IsNumeric(tdbg.Columns(COL_OriginalAmount).Text) Then e.Cancel = True
                'Case COL_ConvertedAmount
                '    If Not IsNumeric(tdbg.Columns(COL_ConvertedAmount).Text) Then e.Cancel = True
            Case COL_ObjectTypeID
                If tdbg.Columns(COL_ObjectTypeID).Text <> tdbdObjectTypeID.Columns("ObjectTypeID").Text Then
                    tdbg.Columns(COL_ObjectTypeID).Text = ""
                    tdbg.Columns(COL_ObjectID).Text = ""
                    tdbg.Columns(COL_ObjectName).Text = ""
                    tdbg.Columns(COL_VATNo).Text = ""
                End If
            Case COL_ObjectID
                If tdbg.Columns(COL_ObjectID).Text <> tdbdObjectID.Columns("ObjectID").Text Then
                    tdbg.Columns(COL_ObjectID).Text = ""
                    tdbg.Columns(COL_ObjectName).Text = ""
                    tdbg.Columns(COL_VATNo).Text = ""
                End If
            Case COL_VATTypeID
                If tdbg.Columns(COL_VATTypeID).Text <> tdbdVATTypeID.Columns("VATTypeID").Text Then
                    tdbg.Columns(COL_VATTypeID).Text = ""
                End If
            Case COL_VATGroupID
                If tdbg.Columns(COL_VATGroupID).Text <> tdbdVATGroupID.Columns("VATGroupID").Text Then
                    tdbg.Columns(COL_VATGroupID).Text = ""
                End If
            Case COL_SourceID
                If tdbg.Columns(COL_SourceID).Text <> tdbdSourceID.Columns("SourceID").Text Then
                    tdbg.Columns(COL_SourceID).Text = ""
                End If
                '--- Chuẩn Khoản mục b5: Kiểm tra Khoản mục lúc nhập liệu
                '---------------------------------------------
            Case COL_Ana01ID To COL_Ana10ID
                '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                If clsFilterDropdown.IsNewFilter Then Exit Sub
                '--- Chuẩn Khoản mục b5: Kiểm tra Khoản mục lúc nhập liệu
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If tdbg.Columns(e.ColIndex).Text <> tdbd.Columns("AnaID").Text Then
                    CheckAfterColUpdateAna(tdbg, COL_Ana01ID, e.ColIndex, dtAnaCaption)
                End If

                'Case COL_Ana01ID
                '    If tdbg.Columns(COL_Ana01ID).Text <> tdbdAna01ID.Columns("AnaID").Text Then
                '        If gbArrAnaValidate(0) Then 'Kiểm tra nhập trong danh sách
                '            tdbg.Columns(COL_Ana01ID).Text = ""
                '        Else
                '            If tdbg.Columns(COL_Ana01ID).Text.Length > giArrAnaLength(0) Then ' Kiểm tra chiều dài nhập vào
                '                tdbg.Columns(COL_Ana01ID).Text = ""
                '            End If
                '        End If
                '    End If

            Case COL_CipNo
                If clsFilterDropdown.IsNewFilter Then Exit Sub '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                If tdbg.Columns(COL_CipNo).Text <> tdbdCipID.Columns("CipNo").Text Then
                    tdbg.Columns(COL_CipNo).Text = ""
                    tdbg.Columns(COL_CipID).Text = ""
                End If

            Case COL_ProjectID
                If clsFilterDropdown.IsNewFilter Then Exit Sub '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                If tdbg.Columns(COL_ProjectID).Text <> tdbdProjectID.Columns("ProjectID").Text Then
                    tdbg.Columns(COL_ProjectID).Text = ""
                    tdbg.Columns(COL_ProjectName).Text = ""
                    tdbg.Columns(COL_TaskID).Text = ""
                    tdbg.Columns(COL_TaskName).Text = ""
                End If
            Case COL_TaskID
                If clsFilterDropdown.IsNewFilter Then Exit Sub '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                If tdbg.Columns(COL_TaskID).Text <> tdbdTaskID.Columns("TaskID").Text Then
                    tdbg.Columns(COL_TaskID).Text = ""
                    tdbg.Columns(COL_TaskName).Text = ""
                End If
            Case COL_PeriodID
                If clsFilterDropdown.IsNewFilter Then Exit Sub '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
        End Select
    End Sub

    Private Sub btnSetNewKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetNewVoucherNo(tdbcVoucherTypeID, txtVoucherNo)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2004
    '# Created User: VANVINH
    '# Created Date: 23/11/2012 02:40:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2004() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho man hinh Nhap chung tu (D02F2004)" & vbCrLf)
        sSQL &= "Exec D02P2004 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(_batchID) & COMMA 'BatchID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(PARA_ModuleID) & COMMA  'CallModule, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub LoadForm()

        'Thay doi ngay 23/11/2012 theo incident 52571 của Thị Hiệp bởi Văn Vinh
        Dim sSQL As String = SQLStoreD02P2004()
        'sSQL = "Select '' as DecimalPlace,A.TransactionID, A.ModuleID, A.VoucherTypeID, A.VoucherNo, A.VoucherDate, A.Notes" & UnicodeJoin(gbUnicode) & " as Notes, " & vbCrLf
        'sSQL &= "(CASE WHEN A.ModuleID='02' OR (ISNULL(A.ItemName,'')='' And A.ModuleID<>'02') THEN A.Description" & UnicodeJoin(gbUnicode) & " ELSE A.ItemName" & UnicodeJoin(gbUnicode) & " END) As Description, " & vbCrLf
        'sSQL &= " A.CurrencyID, A.RefNo, Convert(varchar(20), A.RefDate, 103) as RefDate, A.SeriNo,  " & vbCrLf
        'sSQL &= "A.DebitAccountID, A.CreditAccountID, A.ExchangeRate, A.OriginalAmount, A.ConvertedAmount," & vbCrLf
        'sSQL &= " A.ObjectTypeID, A.ObjectID, CASE WHEN Isnull(A.ObjectName,'')  = '' THEN Isnull(Ob.ObjectName,'') ELSE A.ObjectName" & UnicodeJoin(gbUnicode) & " END As ObjectName  , " & vbCrLf
        'sSQL &= " A.VATNo, A.VATTypeID, A.VATGroupID, A.SourceID, A.Ana01ID, A.Ana02ID, " & vbCrLf
        'sSQL &= " A.Ana03ID, A.Ana04ID, A.Ana05ID, A.Ana06ID, A.Ana07ID, A.Ana08ID, A.Ana09ID, A.Ana10ID ,A.CipID, B.CipNo AS CipNo,A.Posted " & vbCrLf
        'sSQL &= " From D02T0012 A WITH (NOLOCK) Left Join D02T0100 B On A.CIpID = B.CipID " & vbCrLf
        'sSQL &= "LEFT JOIN Object Ob ON  Ob.ObjectTypeID = A.ObjectTypeID AND Ob.ObjectID  =A.ObjectID" & vbCrLf
        'sSQL &= "Where BatchID = " & SQLString(_batchID)
        dtMain = ReturnDataTable(sSQL)

        If dtMain.Rows.Count > 0 Then
            sEditVoucherTypeID = dtMain.Rows(0).Item("VoucherTypeID").ToString
            'Trần Thị Ái Trâm - 10/12/2009 - Chuẩn load combo khi Sửa b3:
            LoadTDBCombo()
            tdbcVoucherTypeID.Text = dtMain.Rows(0).Item("VoucherTypeID").ToString
            txtVoucherNo.Text = dtMain.Rows(0).Item("VoucherNo").ToString
            c1dateVoucherDate.Value = CDate(dtMain.Rows(0).Item("VoucherDate"))
            txtNotes.Text = dtMain.Rows(0).Item("Notes").ToString
            chkPosted.Checked = Not L3Bool(dtMain.Rows(0).Item("Posted"))
        End If
        LoadDataSource(tdbg, dtMain, gbUnicode)
        FooterSum()
        FooterTotalGrid(tdbg, COL_SeriNo)
    End Sub

    Private Sub FooterSum()
        FooterSumNew(tdbg, COL_ConvertedAmount)
    End Sub

    Private Sub LoadEdit()
        tdbcVoucherTypeID.Enabled = False
        txtVoucherNo.ReadOnly = True
        'c1dateVoucherDate.Enabled = False
        LoadForm()
    End Sub

    Private Sub CalcuteConvertedAmount()
        Dim dExchangeRate As Double = 0
        Dim dOriginalAmount As Double = 0
        Dim dConvertedAmount As Double
        If tdbg.Columns(COL_ExchangeRate).Text <> "" And tdbg.Columns(COL_OriginalAmount).Text <> "" Then
            dExchangeRate = CDbl(tdbg.Columns(COL_ExchangeRate).Text)
            dOriginalAmount = CDbl(tdbg.Columns(COL_OriginalAmount).Text)
            If tdbdCurrencyID.Columns("Operator").Text <> "" Then
                If CInt(tdbdCurrencyID.Columns("Operator").Text) = 0 Then
                    dConvertedAmount = dExchangeRate * dOriginalAmount
                    tdbg.Columns(COL_ConvertedAmount).Text = SQLNumber(dConvertedAmount.ToString, DxxFormat.D90_ConvertedDecimals)
                Else
                    If dExchangeRate <> 0 Then
                        dConvertedAmount = dOriginalAmount / dExchangeRate
                        tdbg.Columns(COL_ConvertedAmount).Text = SQLNumber(dConvertedAmount.ToString, DxxFormat.D90_ConvertedDecimals)
                    Else
                        D99C0008.MsgL3(rl3("Nguyen_te_khong_hop_le"))
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_RefDate
                tdbg.Columns(e.ColIndex).Value = tdbg.Columns(e.ColIndex).Text
            Case COL_ExchangeRate
                tdbg.Columns(COL_ExchangeRate).Text = SQLNumber(tdbg.Columns(COL_ExchangeRate).Text, DxxFormat.ExchangeRateDecimals)
                CalcuteConvertedAmount()
                FooterSum()
                'tdbg.Columns(COL_ConvertedAmount).Text = SQLNumber(tdbg.Columns(COL_ConvertedAmount).Text, D02Format.ConvertedAmount)
            Case COL_OriginalAmount
                CalcuteConvertedAmount()
                ' update 30/7/2013 id 58521
                Dim sDecimalPlaces As String = DxxFormat.DecimalPlaces
                If tdbg.Columns(COL_CurrencyID).Text <> "" Then
                    sDecimalPlaces = InsertFormat(ReturnValueC1DropDown(tdbdCurrencyID, "DecimalPlaces", "CurrencyID = " & SQLString(tdbg.Columns(COL_CurrencyID).Text)))
                End If
                tdbg.Columns(COL_OriginalAmount).Text = SQLNumber(tdbg.Columns(COL_OriginalAmount).Text, sDecimalPlaces)
                '   tdbg.Columns(COL_OriginalAmount).Text = SQLNumber(tdbg.Columns(COL_OriginalAmount).Text, InsertFormat(ReturnValueC1DropDown(tdbdCurrencyID, "DecimalPlaces", "CurrencyID = " & SQLString(tdbg.Columns(COL_CurrencyID).Text))))
                'tdbg.Columns(COL_ConvertedAmount).Text = SQLNumber(tdbg.Columns(COL_ConvertedAmount).Text, D02Format.ConvertedAmount)
                FooterSum()
            Case COL_ConvertedAmount
                tdbg.Columns(COL_ConvertedAmount).Text = SQLNumber(tdbg.Columns(COL_ConvertedAmount).Text, DxxFormat.D90_ConvertedDecimals)
                FooterSum()

            Case COL_Ana01ID To COL_Ana10ID
                '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select

                If DxxFormat.LoadFormNotINV = 1 Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    AfterColUpdate(e.ColIndex, dr)
                    Exit Sub
                Else
                    Dim row As DataRow = ReturnDataRow(tdbd, "AnaID = " & SQLString(tdbg.Columns(e.ColIndex).Text))
                    AfterColUpdate(e.ColIndex, row)
                End If
            Case COL_CipNo
                'If tdbg.Columns(COL_CipNo).Text <> tdbdCipID.Columns("CipNo").Text Then
                '    tdbg.Columns(COL_CipNo).Text = ""
                '    tdbg.Columns(COL_CipID).Text = ""
                'Else
                '    tdbg.Columns(COL_CipID).Text = tdbdCipID.Columns("CipID").Text
                'End If
                '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    AfterColUpdate(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim row As DataRow = Nothing
                    If tdbg.Columns(e.ColIndex).Text <> "" Then row = CType(tdbd.DataSource, DataTable).Rows(tdbd.Row) 'Sửa lỗi bị khi chọn Mã trùng 
                    AfterColUpdate(e.ColIndex, row)
                End If
            Case COL_ProjectID
                'If bNotInList Then
                '    tdbg.Columns(COL_TaskID).Text = ""
                '    tdbg.Columns(COL_TaskName).Text = ""

                '    bNotInList = False
                'End If
                '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    AfterColUpdate(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    If tdbg.Columns(e.ColIndex).Text = "" Then Exit Select
                    'Gắn dữ liệu cho cột Tên dự án 
                    tdbg.Columns(COL_ProjectName).Text = tdbg.Columns(e.ColIndex).DropDown.Columns(1).Text
                    tdbg.Columns(COL_TaskID).Text = ""
                    tdbg.Columns(COL_TaskName).Text = ""
                End If
            Case COL_TaskID
                'If tdbg.Columns(COL_TaskID).Text <> tdbdTaskID.Columns("TaskID").Text Then
                '    tdbg.Columns(COL_TaskID).Text = ""
                '    tdbg.Columns(COL_TaskName).Text = ""
                'Else
                '    tdbg.Columns(COL_TaskID).Text = tdbdTaskID.Columns("TaskID").Text
                '    tdbg.Columns(COL_TaskName).Text = tdbdTaskID.Columns("TaskName").Text
                'End If
                '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    AfterColUpdate(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    If tdbg.Columns(e.ColIndex).Text = "" Then Exit Select
                    'Gắn dữ liệu cho cột Tên hạng mục
                    tdbg.Columns(COL_TaskName).Text = tdbg.Columns(e.ColIndex).DropDown.Columns(1).Text
                End If

            Case COL_PeriodID
                '30/3/2021, Nguyễn Thị Mỹ Lài:id 155517-Bổ sung filter bar tại tab khoản mục và tab khác
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    AfterColUpdate(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim row As DataRow = Nothing
                    If tdbg.Columns(e.ColIndex).Text <> "" Then row = CType(tdbd.DataSource, DataTable).Rows(tdbd.Row) 'Sửa lỗi bị khi chọn Mã trùng 
                    AfterColUpdate(e.ColIndex, row)
                End If
        End Select
        FooterTotalGrid(tdbg, COL_SeriNo)
    End Sub

    Private Sub tdbg_LockedColumns()
        'tdbg.Splits(SPLIT0).DisplayColumns(COL_ConvertedAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        If PARA_ModuleID = "54" Then
            tdbg.Splits(SPLIT0).DisplayColumns(COL_CurrencyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns(COL_CurrencyID).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_CurrencyID).AllowFocus = False
            tdbg.Splits(SPLIT0).DisplayColumns(COL_ExchangeRate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns(COL_ExchangeRate).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_ExchangeRate).AllowFocus = False
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("So_phieu"))
            txtVoucherNo.Focus()
            Return False
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DebitAccountID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Tai_khoan_no"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DebitAccountID
                tdbg.Bookmark = i
                'tdbg.UpdateData()
                'tdbg.Focus()

                Return False
            End If
            If tdbg(i, COL_CreditAccountID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Tai_khoan_co"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_CreditAccountID
                tdbg.Bookmark = i
                'tdbg.UpdateData()
                'tdbg.Focus()
                Return False
            End If
            If PARA_ModuleID <> "54" And tdbg(i, COL_CurrencyID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Loai_tien"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_CurrencyID
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_ExchangeRate).ToString <> "" Then
                If CDbl(tdbg(i, COL_ExchangeRate).ToString) > MaxMoney Then
                    D99C0008.MsgL3(rl3("Ty_gia_khong_hop_le"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_ExchangeRate
                    tdbg.Bookmark = i
                    'tdbg.Focus()
                    Return False
                End If

            End If
            If tdbg(i, COL_OriginalAmount).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Nguyen_te"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_OriginalAmount
                tdbg.Bookmark = i
                'tdbg.UpdateData()
                'tdbg.Focus()
                Return False
            End If

            If tdbg(i, COL_OriginalAmount).ToString <> "" Then
                If CDbl(tdbg(i, COL_OriginalAmount).ToString) > MaxMoney Then
                    D99C0008.MsgL3(rl3("Nguyen_te_khong_hop_le"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_OriginalAmount
                    tdbg.Bookmark = i
                    'tdbg.Focus()
                    Return False
                End If
            End If

            If tdbg(i, COL_ObjectTypeID).ToString <> "" Then
                If tdbg(i, COL_ObjectID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ma_doi_tuong"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_ObjectID
                    tdbg.Bookmark = i
                    'tdbg.Focus()
                    Return False
                End If

            End If

            ' 20/3/2014 id 60323 - Thao Bao Trân
            '            If PARA_ModuleID = "54" Then
            '                If tdbg(i, COL_CipNo).ToString = "" Then
            '                    D99C0008.MsgNotYetEnter(rl3("Ma_XDCB"))
            '                    tdbg.Focus()
            '                    tdbg.SplitIndex = SPLIT1
            '                    tdbg.Col = COL_CipNo
            '                    tdbg.Bookmark = i
            '                    Return False
            '                End If
            '            End If
        Next
        Return True

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Value.ToString) Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False
        gbSavedOK = False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        If _FormState = EnumFormState.FormEdit Then
            sCreateUserID = _createUserID
            sCreateUserDate = _createUserDate
        Else
            sCreateUserID = gsUserID
            sCreateUserDate = Now.ToString
        End If
        sLastModifyDate = Now.ToString

        Select Case _FormState
            Case EnumFormState.FormAdd
                _batchID = CreateIGE("D02T0012", "BatchID", "02", "BG", gsStringKey)
                'Kiểm tra phiếu
                If tdbcVoucherTypeID.Columns("Auto").Value.ToString = "1" And bEditVoucherNo = False Then
                    'Sinh tự động và không nhấn F2
                    txtVoucherNo.Text = CreateIGEVoucherNoNew(tdbcVoucherTypeID, "D02T0012", _batchID)
                Else 'Không sinh tự động hay có nhấn F2
                    If bEditVoucherNo = False Then
                        'Kiểm tra trùng số phiếu
                        If CheckDuplicateVoucherNoNew(D02, "D02T0012", _batchID, txtVoucherNo.Text) Then
                            btnSave.Enabled = True
                            btnClose.Enabled = True
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Else 'Có nhấn F2 để sửa số phiếu
                        'Insert Số phiếu vào bảng D40T5558
                        InsertD02T5558(_batchID, sOldVoucherNo, txtVoucherNo.Text)
                    End If
                    'Insert VoucherNo vào bảng D91T9111
                    InsertVoucherNoD91T9111(txtVoucherNo.Text, "D02T0012", _batchID)
                End If
                bEditVoucherNo = False
                sOldVoucherNo = ""
                bFirstF2 = False

                sSQL.Append(SQLInsertD02T0018().ToString & vbCrLf)
                sSQL.Append(SQLInsertD02T0012s)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLDeleteD02T0018.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD02T0012.ToString & vbCrLf)
                sSQL.Append(SQLInsertD02T0018.ToString & vbCrLf)
                sSQL.Append(SQLInsertD02T0012s)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            gbSavedOK = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    _voucherTypeID = tdbcVoucherTypeID.Text
                    _voucherNo = txtVoucherNo.Text
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
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

    Private Function SQLStoreD91P0010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P0010 "
        sSQL &= SQLString(tdbg.Columns(COL_CurrencyID).Text) & COMMA 'CurrencyID, varchar[20], NOT NULL
        If tdbg.Columns(COL_RefDate).Text = "  /  /" Or tdbg.Columns(COL_RefDate).Text = "  /  /    " Then
            sSQL &= SQLDateSave("") 'ExDate, datetime, NOT NULL
        Else
            sSQL &= SQLDateSave(tdbg.Columns(COL_RefDate).Text) 'ExDate, datetime, NOT NULL
        End If

        Return sSQL
    End Function

    Private Sub GetExchangeRate()
        Dim sSQL As String = ""
        sSQL = SQLStoreD91P0010()
        dtExchangeRate = ReturnDataTable(sSQL)
    End Sub

    Private Function SQLInsertD02T0018() As StringBuilder

        Dim sSQL As New StringBuilder

        '_batchID = CreateIGE("D02T0012", "BatchID", "02", "BI", gsStringKey)

        sSQL.Append("Insert Into D02T0018(")
        sSQL.Append("BatchID, VoucherNo, VoucherTypeID, VoucherDate, ")
        sSQL.Append("DivisionID, TranMonth, TranYear, CreateDate, CreateUserID, ")
        sSQL.Append("LastmodifyDate, LastmodifyUserID,NotesU")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(_batchID) & COMMA) 'BatchID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcVoucherTypeID.Text) & COMMA) 'VoucherTypeID, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Value) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NULL
        sSQL.Append(SQLDateTimeSave(sCreateUserDate) & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(sCreateUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLDateTimeSave(sLastModifyDate) & COMMA) 'LastmodifyDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastmodifyUserID, varchar[20], NULL
        sSQL.Append(SQLStringUnicode(txtNotes.Text, gbUnicode, True)) 'NotesU, nvarchar[250], NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    Private Function SQLInsertD02T0012s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        sTransactionID = ""
        Dim iCountIGE As Int32 = 0
        Dim iFirstIGETransID As Long

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransactionID).ToString = "" Then
                iCountIGE += 1
            End If
        Next
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransactionID).ToString = "" Then
                sTransactionID = CreateIGENewS("D02T0012", "TransactionID", "02", "TG", gsStringKey, sTransactionID, iCountIGE, iFirstIGETransID)
                tdbg(i, COL_TransactionID) = sTransactionID
            End If

            sSQL.Append("Insert Into D02T0012(")
            sSQL.Append("TransactionID, DivisionID, ModuleID,")
            sSQL.Append("VoucherTypeID, VoucherNo, VoucherDate, TranMonth, TranYear, ")
            sSQL.Append("CurrencyID, ExchangeRate, DebitAccountID, ")
            sSQL.Append("CreditAccountID, OriginalAmount,  ConvertedAmount, Status,")
            sSQL.Append("RefNo, RefDate, Disabled, CreateUserID, CreateDate, ")
            sSQL.Append("LastModifyUserID, LastModifyDate, SeriNo, ObjectTypeID, ObjectID, ")
            sSQL.Append("BatchID, VATNo, VATGroupID, VATTypeID,Ana01ID, Ana02ID, ")
            sSQL.Append("Ana03ID,Ana04ID, Ana05ID, Ana06ID, Ana07ID, Ana08ID, Ana09ID, Ana10ID, ")
            sSQL.Append("Posted, SourceID, Internal,CipID,DescriptionU,ObjectNameU,NotesU, ProjectID, ProjectNameU, TaskID, TaskNameU, PeriodID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_TransactionID)) & COMMA) 'TransactionID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
            If PARA_ModuleID = "54" Then
                sSQL.Append(SQLString("54") & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
            Else ' Có thể co module khác (cũ)
                sSQL.Append(SQLString("02") & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
            End If
            sSQL.Append(SQLString(tdbcVoucherTypeID.Text) & COMMA) 'VoucherTypeID, varchar[20], NULL
            sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[20], NULL
            sSQL.Append(SQLDateSave(c1dateVoucherDate.Value) & COMMA) 'VoucherDate, datetime, NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NULL
            sSQL.Append(SQLString(tdbg(i, COL_CurrencyID)) & COMMA) 'CurrencyID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_ExchangeRate), DxxFormat.ExchangeRateDecimals) & COMMA) 'ExchangeRate, money, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DebitAccountID)) & COMMA) 'DebitAccountID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_CreditAccountID)) & COMMA) 'CreditAccountID, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_OriginalAmount), InsertFormat(ReturnValueC1DropDown(tdbdCurrencyID, "DecimalPlaces", "CurrencyID = " & SQLString(tdbg(i, COL_CurrencyID))))) & COMMA) 'OriginalAmount, money, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_ConvertedAmount), DxxFormat.D90_ConvertedDecimals) & COMMA) 'ConvertedAmount, money, NULL
            sSQL.Append("0" & COMMA) 'Status, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RefNo)) & COMMA) 'RefNo, varchar[20], NULL
            If tdbg(i, COL_RefDate).ToString = " /  /" Or tdbg.Columns(COL_RefDate).Text = "  /  /    " Then
                sSQL.Append(SQLDateSave(Date.Today) & COMMA) 'RefDate, datetime, NULL
            Else
                sSQL.Append(SQLDateSave(tdbg(i, COL_RefDate)) & COMMA) 'RefDate, datetime, NULL
            End If

            sSQL.Append("0" & COMMA) 'Disabled, bit, NOT NULL
            sSQL.Append(SQLString(sCreateUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append(SQLDateTimeSave(sCreateUserDate) & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append(SQLDateTimeSave(sLastModifyDate) & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_SeriNo)) & COMMA) 'SeriNo, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_ObjectTypeID)) & COMMA) 'ObjectTypeID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_ObjectID)) & COMMA) 'ObjectID, varchar[20], NULL
            sSQL.Append(SQLString(_batchID) & COMMA) 'BatchID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_VATNo)) & COMMA) 'VATNo, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_VATGroupID)) & COMMA) 'VATGroupID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_VATTypeID)) & COMMA) 'VATTypeID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana01ID)) & COMMA) 'Ana01ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana02ID)) & COMMA) 'Ana02ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana03ID)) & COMMA) 'Ana03ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana04ID)) & COMMA) 'Ana04ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana05ID)) & COMMA) 'Ana05ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana06ID)) & COMMA) 'Ana06ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana07ID)) & COMMA) 'Ana07ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana08ID)) & COMMA) 'Ana08ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana09ID)) & COMMA) 'Ana09ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana10ID)) & COMMA) 'Ana10ID, varchar[20], NULL
            sSQL.Append(SQLNumber(Not chkPosted.Checked) & COMMA) 'Posted, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_SourceID)) & COMMA) 'SourceID, varchar[20], NULL
            sSQL.Append("0" & COMMA) 'Internal, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CipID)) & COMMA) 'CipID, varchar[20], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True) & COMMA) 'DescriptionU, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ObjectName), gbUnicode, True) & COMMA) 'ObjectNameU, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(txtNotes.Text, gbUnicode, True) & COMMA) 'NotesU, varchar[250], NULL
            'Them ngay 23/11/2012 theo incidetn 52571 của Thị Hiệp bởi Văn Vinh
            sSQL.Append(SQLString(tdbg(i, COL_ProjectID)) & COMMA) 'ProjectID, varchar[20], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ProjectName), gbUnicode, True) & COMMA) 'ProjectNameU, varchar[250], NULL
            sSQL.Append(SQLString(tdbg(i, COL_TaskID)) & COMMA) 'TaskID, varchar[20], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_TaskName), gbUnicode, True) & COMMA) 'TaskNameU, varchar[250], NULL
            '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
            sSQL.Append(SQLString(tdbg(i, COL_PeriodID))) 'PeriodID, varchar[20], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLDeleteD02T0018() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D02T0018"
        sSQL &= " Where "
        sSQL &= "BatchID = " & SQLString(_batchID)
        Return sSQL
    End Function

    Private Function SQLDeleteD02T0012() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D02T0012"
        sSQL &= " Where "
        sSQL &= "BatchID = " & SQLString(_batchID)
        Return sSQL
    End Function

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        btnSave.Enabled = True
        btnNext.Enabled = False
        LoadAddNew()
        tdbcVoucherTypeID.Text = ""
        txtVoucherNo.Text = ""
        txtNotes.Text = ""
        ClickButton(Button.Ana)
        tdbcVoucherTypeID.Focus()
    End Sub

    Private Sub btnHotKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D02F7777
        With f
            .CallShowForm(Me.Name)
            .ShowDialog()
        End With
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        Select Case tdbg.Col
            Case COL_ObjectID
                LoadTDBDropdownObjectID(tdbg.Columns(COL_ObjectTypeID).Text)
            Case COL_TaskID
                LoadTask(tdbdTaskID, dtSource, tdbg(tdbg.Row, COL_ProjectID).ToString)
        End Select

        If bInsertRow = True And tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
            tdbg.Columns(COL_RefNo).Text = "" ' Gán 1 cột bất kỳ ="" cho lưới
            bInsertRow = False
        End If
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_chung_tu_-_D02F2004") & UnicodeCaption(gbUnicode) 'CËp nhËt ch÷ng tô - D02F2004
        '================================================================ 
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblteVoucherDate.Text = rl3("Ngay_hach_toan") 'Ngày hạch toán
        lblNotes.Text = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnHotKey.Text = rl3("_Phim_nong") '&Phím nóng
        btnAna.Text = "1. " & rl3("Khoan_muc")
        btnOther.Text = "2. " & rl3("Khac")
        '================================================================ 
        GroupBox1.Text = rl3("Chung_tu_hach_toan") 'Chứng từ hạch toán
        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbdObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbdObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Ten") 'Tên
        tdbdObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbdObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbdVATTypeID.Columns("VATTypeID").Caption = rl3("Ma") 'Mã
        tdbdVATTypeID.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbdVATGroupID.Columns("VATGroupID").Caption = rl3("Ma") 'Mã
        tdbdVATGroupID.Columns("VATGroupName").Caption = rl3("Ten") 'Tên
        tdbdSourceID.Columns("SourceID").Caption = rl3("Ma") 'Mã
        tdbdSourceID.Columns("SourceName").Caption = rl3("Ten") 'Tên
        tdbdAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbdAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbdCurrencyID.Columns("CurrencyID").Caption = rl3("Ma") 'Mã
        tdbdCurrencyID.Columns("CurrencyName").Caption = rl3("Ten") 'Tên

        tdbdAna01ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna01ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục
        tdbdAna02ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna02ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục
        tdbdAna03ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna03ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục
        tdbdAna04ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna04ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục
        tdbdAna05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục
        tdbdAna06ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna06ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục
        tdbdAna07ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna07ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục
        tdbdAna08ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna08ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục
        tdbdAna09ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna09ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục
        tdbdAna10ID.Columns("AnaID").Caption = rl3("Ma") 'Mã khoản mục
        tdbdAna10ID.Columns("AnaName").Caption = rl3("Ten") 'Tên khoản mục

        tdbdProjectID.Columns("ProjectID").Caption = rl3("Ma") 'Dự án
        tdbdProjectID.Columns("ProjectName").Caption = rl3("Ten") 'Tên dự án

        tdbdTaskID.Columns("TaskID").Caption = rl3("Ma") 'Hạng mục
        tdbdTaskID.Columns("TaskName").Caption = rL3("Ten") 'Tên hạng mục
        tdbdPeriodID.Columns("PeriodID").Caption = rL3("Ma") 'Mã
        tdbdPeriodID.Columns("Note").Caption = rL3("Dien_giai") 'Diễn giải
        '================================================================ 

        tdbg.Columns("RefDate").Caption = rl3("Ngay_hoa_don") 'Ngày hóa đơn
        tdbg.Columns("SeriNo").Caption = rl3("So_Seri") 'Số Sêri
        tdbg.Columns("RefNo").Caption = rl3("So_hoa_don") 'Số hóa đơn
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("DebitAccountID").Caption = rl3("TK_no") 'rl3("Tai_khoan_no") 'Tài khoản nợ
        tdbg.Columns("CreditAccountID").Caption = rl3("TK_co") 'rl3("Tai_khoan_co") 'Tài khoản có
        tdbg.Columns("CurrencyID").Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns("ExchangeRate").Caption = rl3("Ty_gia") 'Tỷ giá
        tdbg.Columns("OriginalAmount").Caption = rl3("Nguyen_te") 'Nguyên tệ
        tdbg.Columns("ConvertedAmount").Caption = rl3("Quy_doi") 'Quy đổi
        tdbg.Columns("ObjectTypeID").Caption = rl3("Loai_doi_tuong") 'rl3("Ma_loai_doi_tuong") 'Mã loại đối tượng
        tdbg.Columns("ObjectID").Caption = rl3("Ma_doi_tuong") 'Mã đối tượng
        tdbg.Columns("ObjectName").Caption = rl3("Ten_doi_tuong") 'Tên đối tượng
        tdbg.Columns("VATNo").Caption = rl3("Ma_so_thue") 'Mã số thuế
        tdbg.Columns("VATTypeID").Caption = rl3("Loai_hoa_don") 'Loại hóa đơn
        tdbg.Columns("VATGroupID").Caption = rl3("Nhom_thue") 'Nhóm thuế
        tdbg.Columns("SourceID").Caption = rl3("Nguon_von") 'Nguồn vốn
        tdbg.Columns("CipNo").Caption = rl3("Ma_XDCB") 'Mã XDCB
        tdbg.Columns(COL_ProjectID).Caption = rl3("Du_an") 'Dự án
        tdbg.Columns(COL_ProjectName).Caption = rL3("Ten_du_an1") 'Tên dự án
        tdbg.Columns(COL_TaskID).Caption = rL3("Hang_muc")
        tdbg.Columns(COL_TaskName).Caption = rL3("Ten_hang_muc1")
        tdbg.Columns("PeriodID").Caption = rL3("Tap_phi") 'Tập phí
        chkPosted.Text = rL3("Khong_chuyen_sang_module_tong_hop") ' Không chuyển sang module tổng hợp
    End Sub

    Private Sub ClickButton(ByVal but As Button)
        Dim ShowAllAna As Boolean = Convert.ToBoolean(tdbg.Columns(COL_Ana01ID).Tag) OrElse Convert.ToBoolean(tdbg.Columns(COL_Ana02ID).Tag) OrElse Convert.ToBoolean(tdbg.Columns(COL_Ana03ID).Tag) OrElse Convert.ToBoolean(tdbg.Columns(COL_Ana04ID).Tag) OrElse Convert.ToBoolean(tdbg.Columns(COL_Ana05ID).Tag) OrElse Convert.ToBoolean(tdbg.Columns(COL_Ana06ID).Tag) OrElse Convert.ToBoolean(tdbg.Columns(COL_Ana07ID).Tag) OrElse Convert.ToBoolean(tdbg.Columns(COL_Ana08ID).Tag) OrElse Convert.ToBoolean(tdbg.Columns(COL_Ana09ID).Tag) OrElse Convert.ToBoolean(tdbg.Columns(COL_Ana10ID).Tag)
        btnAna.Enabled = Math.Abs(but - Button.Ana) > 0 And ShowAllAna
        btnOther.Enabled = Math.Abs(but - Button.Other) > 0
        '--- Chuẩn Khoản mục b4: nhấn nút Khoản mục
        '2. Khoản mục
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana01ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana01ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana02ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana02ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana03ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana03ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana04ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana04ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana05ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana05ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana06ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana06ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana07ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana07ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana08ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana08ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana09ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana09ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana10ID).Visible = Math.Abs(but - Button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana10ID).Tag)
        '3. Khác        
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CipNo).Visible = (Math.Abs(but - Button.Other) = 0)

        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectID).Visible = (Math.Abs(but - Button.Other) = 0)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectName).Visible = (Math.Abs(but - Button.Other) = 0)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskID).Visible = (Math.Abs(but - Button.Other) = 0)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskName).Visible = (Math.Abs(but - Button.Other) = 0)

        tdbg.Splits(SPLIT1).DisplayColumns(COL_PeriodID).Visible = (Math.Abs(but - Button.Other) = 0)
        'tdbg.Splits(SPLIT1).SplitSize = 200
        'If but = Button.Other Then
        '    tdbg.Splits(SPLIT1).SplitSize = 200
        'Else
        '    tdbg.Splits(SPLIT1).SplitSize = 200
        'End If

    End Sub

    Private Sub btnAna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAna.Click
        ClickButton(Button.Ana)
        iLastCol = CountCol(tdbg, tdbg.Splits.Count - 1)

        tdbg.Col = COL_Ana01ID
        tdbg.SplitIndex = SPLIT1
        tdbg.Focus()
    End Sub

    Private Sub btnOther_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOther.Click
        ClickButton(Button.Other)
        iLastCol = CountCol(tdbg, tdbg.Splits.ColCount - 1)
        tdbg.Col = COL_CipNo
        tdbg.SplitIndex = SPLIT1
        tdbg.Focus()
    End Sub

    Private Sub txtVoucherNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVoucherNo.KeyDown
        If e.KeyCode = Keys.F2 Then
            'Loại phiếu hay Số phiếu = "" thì thoát
            If tdbcVoucherTypeID.Text = "" Or txtVoucherNo.Text = "" Then Exit Sub
            'Trường hợp Thêm mới mà IGE đã được sinh thì gán lại = "" 
            'If _FormState = EnumFormState.FormAdd And _batchID <> "" Then _batchID = ""

            'ID 86735 16.05.2016
            If _FormState = EnumFormState.FormAdd And btnSave.Enabled = False Then Exit Sub
            'Kiểm tra quyền cho trường hợp Sửa
            'If (_FormState = EnumFormState.FormEdit Or _batchID <> "") And giPerF5558 <= 2 Then Exit Sub
            If _FormState = EnumFormState.FormEdit And giPerF5558 <= 2 Then Exit Sub

            If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormEditVoucher Then
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
                '    .VoucherID = _batchID 'Khóa sinh IGE
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
                SetProperties(arrPro, "VoucherID", _batchID)
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

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr() As DataRow)
        Dim iRow As Integer = tdbg.Row
        If dr Is Nothing OrElse dr.Length = 0 Then
            Dim row As DataRow = Nothing
            AfterColUpdate(iCol, row)
        ElseIf dr.Length = 1 Then
            AfterColUpdate(iCol, dr(0))
            tdbg.UpdateData()
        Else
            For Each row As DataRow In dr
                tdbg.Row = iRow
                tdbg.Bookmark = iRow
                AfterColUpdate(iCol, row, True)
                tdbg.UpdateData()
                iRow += 1
            Next
            tdbg.Focus()
        End If
    End Sub

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr As DataRow, Optional ByVal bMultiRow As Boolean = False)
        'Gán lại các giá trị phụ thuộc vào Dropdown
        Select Case iCol
            Case COL_Ana01ID To COL_Ana10ID
                If dr Is Nothing OrElse dr.Item("AnaID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    CheckAfterColUpdateAna(tdbg, COL_Ana01ID, iCol, dtAnaCaption)
                    Exit Sub
                End If

                tdbg.Columns(iCol).Text = dr.Item("AnaID").ToString

            Case COL_CipNo
                If dr Is Nothing OrElse dr.Item("CipNo").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_CipNo).Text = ""
                    tdbg.Columns(COL_CipID).Text = ""
                    Exit Sub
                End If
                tdbg.Columns(COL_CipNo).Text = dr.Item("CipNo").ToString
                tdbg.Columns(COL_CipID).Text = dr.Item("CipID").ToString
            Case COL_ProjectID
                If dr Is Nothing OrElse dr.Item("ProjectID").ToString = "" Then
                    tdbg.Columns(COL_ProjectID).Text = ""
                    tdbg.Columns(COL_ProjectName).Text = ""
                    tdbg.Columns(COL_TaskID).Text = ""
                    tdbg.Columns(COL_TaskName).Text = ""
                Else
                    tdbg.Columns(COL_ProjectID).Text = dr.Item("ProjectID").ToString
                    tdbg.Columns(COL_ProjectName).Text = dr.Item("ProjectName").ToString
                    tdbg.Columns(COL_TaskID).Text = ""
                    tdbg.Columns(COL_TaskName).Text = ""
                End If
            Case COL_TaskID
                If dr Is Nothing OrElse dr.Item("TaskID").ToString = "" Then
                    tdbg.Columns(COL_TaskID).Text = ""
                    tdbg.Columns(COL_TaskName).Text = ""
                Else
                    tdbg.Columns(COL_TaskID).Text = dr.Item("TaskID").ToString
                    tdbg.Columns(COL_TaskName).Text = dr.Item("TaskName").ToString
                End If
            Case COL_PeriodID
                If dr Is Nothing OrElse dr.Item("PeriodID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_PeriodID).Text = ""
                    Exit Sub
                End If
                tdbg.Columns(COL_PeriodID).Text = dr.Item("PeriodID").ToString
        End Select


    End Sub

End Class