Imports System.Text

Public Class D02F2011

#Region "Const of tdbg - Total of Columns: 40"
    Private Const COL_IsNotAllocate As Integer = 0    ' IsNotAllocate
    Private Const COL_DataType As Integer = 1         ' Loại dữ liệu
    Private Const COL_Notes As Integer = 2            ' Diễn giải
    Private Const COL_SeriNo As Integer = 3           ' Số Sêri
    Private Const COL_RefNo As Integer = 4            ' Số hóa đơn
    Private Const COL_RefDate As Integer = 5          ' Ngày hóa đơn
    Private Const COL_DebitAccountID As Integer = 6   ' TK Nợ
    Private Const COL_GroupID As Integer = 7          ' GroupID
    Private Const COL_CreditAccountID As Integer = 8  ' TK Có
    Private Const COL_CurrencyID As Integer = 9       ' Loại tiền
    Private Const COL_ExchangeRate As Integer = 10    ' Tỷ giá
    Private Const COL_OriginalAmount As Integer = 11  ' Nguyên tệ
    Private Const COL_ConvertedAmount As Integer = 12 ' Quy đổi
    Private Const COL_ObjectTypeID As Integer = 13    ' Loại đối tượng
    Private Const COL_ObjectID As Integer = 14        ' Đối tượng
    Private Const COL_ObjectName As Integer = 15      ' Tên đối tượng
    Private Const COL_InventoryID As Integer = 16     ' Mã hàng
    Private Const COL_InventoryName As Integer = 17   ' Tên hàng
    Private Const COL_UnitID As Integer = 18          ' Đơn vị tính
    Private Const COL_Quantity As Integer = 19        ' Số lượng
    Private Const COL_PeriodID As Integer = 20        ' Tập phí
    Private Const COL_WarehouseID As Integer = 21     ' Kho
    Private Const COL_Ana01ID As Integer = 22         ' Khoản mục 01
    Private Const COL_Ana02ID As Integer = 23         ' Khoản mục 02
    Private Const COL_Ana03ID As Integer = 24         ' Khoản mục 03
    Private Const COL_Ana04ID As Integer = 25         ' Khoản mục 04
    Private Const COL_Ana05ID As Integer = 26         ' Khoản mục 05
    Private Const COL_Ana06ID As Integer = 27         ' Khoản mục 06
    Private Const COL_Ana07ID As Integer = 28         ' Khoản mục 07
    Private Const COL_Ana08ID As Integer = 29         ' Khoản mục 08
    Private Const COL_Ana09ID As Integer = 30         ' Khoản mục 09
    Private Const COL_Ana10ID As Integer = 31         ' Khoản mục 10
    Private Const COL_ProjectID As Integer = 32       ' Dự án
    Private Const COL_ProjectName As Integer = 33     ' Tên dự án
    Private Const COL_TaskID As Integer = 34          ' Hạng mục
    Private Const COL_TaskName As Integer = 35        ' Tên hạng mục
    Private Const COL_BatchID As Integer = 36         ' BatchID
    Private Const COL_TransactionID As Integer = 37   ' TransactionID
    Private Const COL_FinalizeCIP As Integer = 38     ' FinalizeCIP
    Private Const COL_Operator As Integer = 39        ' Operator
#End Region


    '#Region "Const of tdbgDetail"
    '    Private Const COLD_VoucherTypeID As Integer = 0    ' Loại phiếu
    '    Private Const COLD_VoucherNo As Integer = 1        ' Số phiếu
    '    Private Const COLD_VoucherDate As Integer = 2      ' Ngày phiếu
    '    Private Const COLD_SeriNo As Integer = 3           ' Số Sêri
    '    Private Const COLD_RefNo As Integer = 4            ' Số hóa đơn
    '    Private Const COLD_RefDate As Integer = 5          ' Ngày hóa đơn
    '    Private Const COLD_Description As Integer = 6      ' Diễn giải
    '    Private Const COLD_DebitAccountID As Integer = 7   ' TK Nợ
    '    Private Const COLD_CreditAccountID As Integer = 8  ' TK Có
    '    Private Const COLD_Currency As Integer = 9         ' Loại tiền
    '    Private Const COLD_ExchangeRate As Integer = 10    ' Tỷ giá
    '    Private Const COLD_OriginalAmount As Integer = 11  ' Nguyên tệ
    '    Private Const COLD_ConvertedAmount As Integer = 12 ' Qui đổi
    '    Private Const COLD_Ana01ID As Integer = 13         ' Khoản mục 01
    '    Private Const COLD_Ana02ID As Integer = 14         ' Khoản mục 02
    '    Private Const COLD_Ana03ID As Integer = 15         ' Khoản mục 03
    '    Private Const COLD_Ana04ID As Integer = 16         ' Khoản mục 04
    '    Private Const COLD_Ana05ID As Integer = 17         ' Khoản mục 05
    '    Private Const COLD_Ana06ID As Integer = 18         ' Khoản mục 06
    '    Private Const COLD_Ana07ID As Integer = 19         ' Khoản mục 07
    '    Private Const COLD_Ana08ID As Integer = 20         ' Khoản mục 08
    '    Private Const COLD_Ana09ID As Integer = 21         ' Khoản mục 09
    '    Private Const COLD_Ana10ID As Integer = 22         ' Khoản mục 10
    '#End Region

#Region "Const of tdbgDetail - Total of Columns: 23"
    Private Const COLD_VoucherTypeID As Integer = 0    ' Loại phiếu
    Private Const COLD_VoucherNo As Integer = 1        ' Số phiếu
    Private Const COLD_VoucherDate As Integer = 2      ' Ngày phiếu
    Private Const COLD_SeriNo As Integer = 3           ' Số Sêri
    Private Const COLD_RefNo As Integer = 4            ' Số hóa đơn
    Private Const COLD_RefDate As Integer = 5          ' Ngày hóa đơn
    Private Const COLD_Description As Integer = 6      ' Diễn giải
    Private Const COLD_DebitAccountID As Integer = 7   ' TK Nợ
    Private Const COLD_CreditAccountID As Integer = 8  ' TK Có
    Private Const COLD_CurrencyID As Integer = 9       ' Loại tiền
    Private Const COLD_ExchangeRate As Integer = 10    ' Tỷ giá
    Private Const COLD_OriginalAmount As Integer = 11  ' Nguyên tệ
    Private Const COLD_ConvertedAmount As Integer = 12 ' Qui đổi
    Private Const COLD_Ana01ID As Integer = 13         ' Khoản mục 01
    Private Const COLD_Ana02ID As Integer = 14         ' Khoản mục 02
    Private Const COLD_Ana03ID As Integer = 15         ' Khoản mục 03
    Private Const COLD_Ana04ID As Integer = 16         ' Khoản mục 04
    Private Const COLD_Ana05ID As Integer = 17         ' Khoản mục 05
    Private Const COLD_Ana06ID As Integer = 18         ' Khoản mục 06
    Private Const COLD_Ana07ID As Integer = 19         ' Khoản mục 07
    Private Const COLD_Ana08ID As Integer = 20         ' Khoản mục 08
    Private Const COLD_Ana09ID As Integer = 21         ' Khoản mục 09
    Private Const COLD_Ana10ID As Integer = 22         ' Khoản mục 10
#End Region



    Dim dtGrid As DataTable
    Dim dtTemp, dtCipNo, dtProperty As DataTable
    'Dim Sum As Double
    'Dim Total As Double
    Dim bInsertRow As Boolean = False
    Private _FormState As EnumFormState
    Private createUserID As String = ""
    Private createDate As String = ""
    'Trần Thị Ái Trâm - 10/12/2009 - Chuẩn load combo khi Sửa b1:
    Dim sEditVoucherTypeID As String = ""

    Dim clsFilterCombo As Lemon3.Controls.FilterCombo
    Dim clsFilterDropdown As Lemon3.Controls.FilterDropdown
    Dim bUseAna As Boolean

    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            VisibleControls()
            'ID 78488 07/08/2015
            clsFilterCombo = New Lemon3.Controls.FilterCombo()
            clsFilterCombo.CheckD91 = True
            clsFilterCombo.UseFilterCombo(tdbcPropertyProductID)

            '20/5/2021, id 165276-Bổ sung filterbar mã hàng tại màn hình cập nhập quyết toán XDCB
            clsFilterDropdown = New Lemon3.Controls.FilterDropdown()
            clsFilterDropdown.CheckD91 = True 'Giá trị mặc định True: kiểm tra theo DxxFormat.LoadFormNotINV. Ngược lại luôn luôn Filter dạng mới (dùng cho Novaland)
            clsFilterDropdown.UseFilterDropdown(tdbg, COL_InventoryID) 'Nếu dùng nhiều lưới

            'Trần Thị Ái Trâm - 10/12/2009 - Chuẩn load combo khi Sửa b2:
            LoadTDBGridAnalysisCaption(D02, tdbg, COL_Ana01ID, SPLIT1, True, gbUnicode)
            LoadTDBGridAnalysisCaption(D02, tdbgDetail, COLD_Ana01ID, SPLIT0, True, gbUnicode)
            

            LoadTDBDropDown()
            tdbg_NumberFormat()
            tdbgDetail_NumberFormat()
            LoadTDBCombo()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = True
                    btnNext.Enabled = False
                    LoadAdd()
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
            End Select

        End Set
    End Property

    Private _batchID As String
    Private _cipID As String
    Private _description As String
    Private bFlagObject As Boolean = False
    Private bFlagInventory As Boolean = False
    Private bFlagAna As Boolean = False
    Dim sTransactionID As String
    Dim iLastCol As Integer

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
    Public Property CipID() As String
        Get
            Return _cipID
        End Get
        Set(ByVal value As String)
            If CipID = value Then
                _cipID = ""
                Return
            End If
            _cipID = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            If Description = value Then
                _description = ""
                Return
            End If
            _description = value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D02F2011_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        End If
        If e.Control Then
            If e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
                btnObject_Click(Nothing, Nothing)
                tdbg.Col = COL_ObjectID
                tdbg.Row = 0
                'tdbg.Focus()
                Exit Sub
            End If

            If e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
                btnInventory_Click(Nothing, Nothing)
                tdbg.Col = COL_InventoryID
                tdbg.Row = 0
                'tdbg.Focus()
                Exit Sub
            End If
            If e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3 Then
                btnAna_Click(Nothing, Nothing)
                tdbg.Col = COL_Ana01ID
                tdbg.Row = 0
                'tdbg.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Dim sOldPropertyProductID As String
    Dim sOldCipNo As String
    Private Sub D02F2011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
        iPer_F5558 = ReturnPermission("D02F5558")

        tdbg.Columns("RefDate").Editor = c1date1 'Thêm theo incident 50729 ngày 14/8/2012 boi VANVINH
        tdbg_LockedColumns()
        bFlagObject = True
        ClickButton(Button.ObjectButton)
        ResetFooterGrid(tdbg, 0, 1)
        ResetFooterGrid(tdbgDetail)
        ResetColorGrid(tdbgDetail)
        ResetSplitDividerSize(tdbg)
        InputDateInTrueDBGrid(tdbgDetail, COLD_VoucherDate, COLD_RefDate)
        sOldPropertyProductID = ReturnValueC1Combo(tdbcPropertyProductID)
        sOldCipNo = ReturnValueC1Combo(tdbcCipNo)
        tdbdAna01ID_D.Enabled = False
        tdbdAna02ID_D.Enabled = False

        EnableVisibleProjectIDTaskID()
        If bVisible Then 'Có hiển thị combo bất động sản
            tdbg.AllowAddNew = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_CurrencyID).Locked = False
        Else
            tdbg.Splits(SPLIT0).DisplayColumns(COL_CurrencyID).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_CurrencyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR) 'them ngay 15/8/2012 theo incident 50729 cua THIHUAN boi VANVINH
        End If
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    'Dự án hạng mục ẩn hiển theo D54 và D02
    Private Sub EnableVisibleProjectIDTaskID()
        tdbg.Splits(1).DisplayColumns(COL_ProjectID).Visible = bUseD54 AndAlso bVisible
        tdbg.Splits(1).DisplayColumns(COL_ProjectName).Visible = bUseD54 AndAlso bVisible

        tdbg.Splits(1).DisplayColumns(COL_TaskID).Visible = bUseD54 AndAlso bVisible
        tdbg.Splits(1).DisplayColumns(COL_TaskName).Visible = bUseD54 AndAlso bVisible

        '5/6/2017, Phạm Thị Thu: id 97643-Bổ sung cho phép chọn nhóm tài khoản 18 - Giá thành dự án khi Quyết toán
        tdbg.Splits(1).DisplayColumns(COL_ProjectID).Locked = (ReturnValueC1Combo(tdbcPropertyProductID) <> "" And optTransMode1.Checked)
        tdbg.Splits(1).DisplayColumns(COL_ProjectID).Button = Not tdbg.Splits(1).DisplayColumns(COL_ProjectID).Locked
        tdbg.Splits(1).DisplayColumns(COL_TaskID).Locked = (ReturnValueC1Combo(tdbcPropertyProductID) <> "" And optTransMode1.Checked)
        tdbg.Splits(1).DisplayColumns(COL_TaskID).Button = Not tdbg.Splits(1).DisplayColumns(COL_TaskID).Locked

        If ReturnValueC1Combo(tdbcPropertyProductID) <> "" Then
            If optTransMode1.Checked Then
                tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            Else
                tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectID).Style.ResetBackColor()
                tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskID).Style.ResetBackColor()
            End If
        Else
            tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectID).Style.ResetBackColor()
            tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskID).Style.ResetBackColor()
        End If

        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

        Dim bVisible As Boolean = D02Systems.CIPforPropertyProduct
    Private Sub VisibleControls()
        lblPropertyProductID.Visible = bVisible
        tdbcPropertyProductID.Visible = bVisible
        optTransMode0.Visible = bVisible
        optTransMode1.Visible = bVisible
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCipNo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Dim dtVoucherTypeID As DataTable
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcEmployeeID
        LoadCboCreateBy(tdbcEmployeeID, gbUnicode)
        'Load tdbcVoucherTypeID
        'Trần Thị Ái Trâm - 10/12/2009 - Chuẩn load combo khi Sửa b5:
        'LoadVoucherTypeID(tdbcVoucherTypeID, D02, sEditVoucherTypeID, gbUnicode)
        dtVoucherTypeID = ReturnDataTable(ReturnTableVoucherTypeID("D02", gsDivisionID, sEditVoucherTypeID, gbUnicode))
        LoadDataSource(tdbcVoucherTypeID, dtVoucherTypeID, gbUnicode)
        'Load CipNo và BDS
        LoadCipNoAndPropertyProductID()
    End Sub

    Public Function ReturnTableVoucherTypeID(ByVal sModuleID As String, ByVal DivisionID As String, ByVal sEditTransTypeID As String, Optional ByVal bUseUnicode As Boolean = False) As String
        Dim sSQL As String = "--Do nguon cho combo loai phieu" & vbCrLf
        sSQL &= "Select T01.VoucherTypeID, " & IIf(bUseUnicode, "VoucherTypeNameU", "VoucherTypeName").ToString & " as VoucherTypeName, Auto, S1Type, S1, S2Type, S2, " & vbCrLf
        sSQL &= "S3, S3Type, OutputOrder, OutputLength, Separator, T40.FormID " & vbCrLf
        sSQL &= "From D91T0001 T01 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Left Join D02T0080 T40 WITH(NOLOCK) ON T01.VoucherTypeID = T40.VoucherTypeID" & vbCrLf
        sSQL &= "Where Use" & sModuleID & " = 1 And Disabled = 0 " & vbCrLf
        If DivisionID <> "" Then sSQL &= "AND( VoucherDivisionID='' Or VoucherDivisionID = " & SQLString(DivisionID) & ") " & vbCrLf
        'Load cho trường hợp Sửa, Xem
        If sEditTransTypeID <> "" Then
            sSQL &= "Or T01.VoucherTypeID = " & SQLString(sEditTransTypeID) & vbCrLf
        End If
        sSQL &= "Order By VoucherTypeID"
        Return sSQL
    End Function

    Private Sub FiltertdbcCipNo(ByVal sD27PropertyProductID As String)
        If sD27PropertyProductID = "" Then
            LoadDataSource(tdbcCipNo, dtCipNo, gbUnicode)
        Else
            Dim dtTable As DataTable = ReturnTableFilter(dtCipNo, "D27PropertyProductID=" & SQLString(sD27PropertyProductID), True)
            If dtTable.Rows.Count = 0 Then tdbcCipNo.Text = ""
            tdbcCipNo.SelectedValue = dtTable.Rows(0).Item("CipNo").ToString
        End If
    End Sub

    Private Sub LoadCipNoAndPropertyProductID()
        Dim sSQL As String = ""
        'Load tdbcBDS
        sSQL = "Select A.CipID, A.CipNo, A.CipName" & UnicodeJoin(gbUnicode) & " as CipName, A.AccountID,  " & IIf(geLanguage = EnumLanguage.Vietnamese, "B.AccountName", "B.AccountName01").ToString & UnicodeJoin(gbUnicode) & " as AccountName,A.D27PropertyProductID,A.D54ProjectID  From D02T0100 A WITH(NOLOCK) " & vbCrLf
        sSQL &= "Left Join D90T0001 B WITH(NOLOCK) On A.AccountID=B.AccountID Where Status=1 AND A.Disabled = 0 AND A.DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " Order By A.CipNo"

        dtProperty = ReturnDataTable(sSQL)
        LoadDataSource(tdbcPropertyProductID, ReturnTableFilter(dtProperty, "D27PropertyProductID <> '' and D54ProjectID <> ''", True), gbUnicode)

        'Load tdbcCipNo
        dtCipNo = dtProperty.DefaultView.ToTable
        LoadDataSource(tdbcCipNo, dtCipNo, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdDebitAccountID 
        '5/6/2017, Phạm Thị Thu: id 97643-Bổ sung cho phép chọn nhóm tài khoản 18 - Giá thành dự án khi Quyết toán
        ' update 10/10/2013 id 60118
       LoadtdbdDebitAccountID

        'Load tdbdCreditAccountID
        sSQL = "Select AccountID as CreditAccountID,  " & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName", "AccountName01").ToString & UnicodeJoin(gbUnicode) & " as AccountName From  D90T0001 WITH(NOLOCK)  " & vbCrLf
        sSQL &= " Where GroupID = 9 Order By AccountID "
        LoadDataSource(tdbdCreditAccountID, sSQL, gbUnicode)

        'Load tdbdInventoryID
        'sSQL = "Select InventoryID,InventoryName" & UnicodeJoin(gbUnicode) & " as InventoryName, UnitID From D07T0002 WITH(NOLOCK) Where isService = 0 And Disabled=0 Order By InventoryID  "
        'LoadDataSource(tdbdInventoryID, sSQL, gbUnicode)
        'ID 251213 : Cải tiến tốc độ load mã hàng
        If Not DxxFormat.IsUseCacheOfList Then
            sSQL = SQLSelectInv("")
            LoadDataSource(tdbdInventoryID, sSQL, gbUnicode)
        End If
        'Incident 78839
        LoadTDBDropDownAnaForDivision(tdbg, COL_Ana01ID)
        LoadTDBDropDownAnaForDivision(tdbgDetail, COLD_Ana01ID)


        sSQL = "Select ObjectTypeID,ObjectTypeName" & UnicodeJoin(gbUnicode) & " as ObjectTypeName" & vbCrLf
        sSQL &= "From D91T0005 WITH(NOLOCK) Order by ObjectTypeID"
        LoadDataSource(tdbdObjectTypeID, sSQL, gbUnicode)

        LoadProject(tdbdProjectID, , False)
        LoadTask(tdbdTaskID, , tdbg.Columns(COL_ProjectID).Text, False)

        LoadCurrencyID(tdbdCurrencyID, gbUnicode)

        '22/2/2022, Bùi Thị Thanh Tuyền:id 218198-ORGAN - Điều chỉnh màn hình Cập nhật quyết toán XDCB D02F2011
        sSQL = "Select WareHouseID, WareHouseName" & UnicodeJoin(gbUnicode) & " as WareHouseName " & vbCrLf
        sSQL &= "From D07T0007 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= " And (D07T0007.DAGroupID = '' or D07T0007.DAGroupID in (Select DAGroupID From lemonsys.dbo.D00V0080 " & vbCrLf
        sSQL &= "Where UserID = " & SQLString(gsUserID) & " Or 'LEMONADMIN' = " & SQLString(gsUserID) & ")) " & vbCrLf
        sSQL &= "Order by D07T0007.WareHouseID"
        LoadDataSource(tdbdWareHouseID, sSQL, gbUnicode)

        sSQL = "SELECT DISTINCT PeriodID, Note" & UnicodeJoin(gbUnicode) & " as Note " & vbCrLf
        sSQL &= "FROM D08N0100 (" & SQLString(gsDivisionID) & COMMA & SQLNumber(giTranMonth) & COMMA & SQLNumber(giTranYear) & COMMA & " 2)" & vbCrLf
        sSQL &= "Where (DAGroupID='' Or DAGroupID In (Select DAGroupID From LemonSys.dbo.D00V0080 Where UserID= " & SQLString(gsUserID) & ") Or 'LEMONADMIN'=" & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "Order by PeriodID"
        LoadDataSource(tdbdPeriodID, sSQL, gbUnicode)
    End Sub

    Private Function SQLSelectInv(sFilterInv As String) As String
        Dim sSQL As String = ""
        Dim sSelectTop As String = " TOP 1000 "
        If sFilterInv = "" Then sSelectTop = ""
        sSQL = "Select " & sSelectTop & " InventoryID as InventoryID, InventoryName" & UnicodeJoin(gbUnicode) & " as InventoryName, UnitID" & vbCrLf
        sSQL &= "From D07T0002 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And IsService = 0 " & vbCrLf
        If sFilterInv <> "" Then sSQL &= " And  (InventoryID like N'%" & sFilterInv & "%'  Or InventoryNameU like N'%" & sFilterInv & "%') "
        'sSQL &= " And ( DAGroupID= " & SQLString("") & vbCrLf
        'sSQL &= " or DAGroupID in ( Select DAGroupID From LemonSys.Dbo.D00V0080 Where UserID = " & SQLString(gsUserID) & vbCrLf
        'sSQL &= ") Or " & SQLString(gsUserID) & "= 'LEMONADMIN') " & vbCrLf
        sSQL &= " Order By InventoryID"
        Return sSQL
    End Function

    Private Sub LoadtdbdDebitAccountID()
        Dim sSQL As String = ""
        '5/6/2017, Phạm Thị Thu: id 97643-Bổ sung cho phép chọn nhóm tài khoản 18 - Giá thành dự án khi Quyết toán
        sSQL = "Select AccountID as DebitAccountID,  " & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName", "AccountName01").ToString & UnicodeJoin(gbUnicode) & " as AccountName , GroupID From  D90T0001 WITH(NOLOCK)  " & vbCrLf
        '22/2/2022, Bùi Thị Thanh Tuyền:id 218198-ORGAN - Điều chỉnh màn hình Cập nhật quyết toán XDCB D02F2011: bổ sung GroupID = 4
        If D02Systems.CIPforPropertyProduct = False Then
            sSQL &= "Where GroupID In (20, 21, 15, 17, 4, 7) " 'ID : 249327 - 18/10/2022 - Bổ sung GroupID = 7 : tất cả trường hợp
        Else
            If ReturnValueC1Combo(tdbcPropertyProductID) = "" Then
                sSQL &= "Where GroupID In (20, 21, 15, 17, 18, 4, 7) "
            Else
                sSQL &= "Where GroupID In (20, 21, 15, 17, 4, 7"
                If optTransMode1.Checked Then
                    sSQL &= ", 27"
                ElseIf optTransMode0.Checked Then
                    sSQL &= ", 18"
                End If
                sSQL &= ") "
            End If
        End If
        sSQL &= " And Disabled = 0 And OffAccount = 0 And AccountStatus = 0 Order By AccountID "
        LoadDataSource(tdbdDebitAccountID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadDropDownObjectID(ByVal sObjectTypeID As String)
        Dim sSQL As String = ""
        sSQL = "Select ObjectID,ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName From Object WITH(NOLOCK)  " & vbCrLf
        sSQL &= "Where Disabled=0 AND ObjectTypeID = " & SQLString(sObjectTypeID) & " Order by ObjectID"
        LoadDataSource(tdbdObjectID, sSQL, gbUnicode)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2016
    '# Created User: Phạm Văn Vinh
    '# Created Date: 23/10/2012 10:29:53
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2016() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho thong tin phieu cua man hinh Quyet toan XDCB" & vbCrLf)
        sSQL &= "Exec D02P2016 "
        sSQL &= SQLString(_cipID) & COMMA 'CipID, varchar[50], NOT NULL
        sSQL &= SQLString(_batchID) & COMMA 'BatchID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Dim sProjectID As String = ""
    Private Sub LoadMaster()
        Dim sSQL As New StringBuilder("")
        'Thay đổi câu đổ nguồn ngày 23/10/2012 theo incident 51452 của Thị Hiệp bởi Văn Vinh
        sSQL.Append(SQLStoreD02P2016())
        Dim dtMaster As DataTable = ReturnDataTable(sSQL.ToString)
        If dtMaster.Rows.Count = 0 Then Exit Sub
        With dtMaster.Rows(0)
            sEditVoucherTypeID = .Item("VoucherTypeID").ToString
            'Trần Thị Ái Trâm - 10/12/2009 - Chuẩn load combo khi Sửa b3:
            'LoadTDBCombo()
            LoadVoucherTypeID(tdbcVoucherTypeID, D02, sEditVoucherTypeID, gbUnicode)
            tdbcVoucherTypeID.Text = .Item("VoucherTypeID").ToString
            txtVoucherNo.Text = .Item("VoucherNo").ToString
            c1dateVoucherDate.Value = .Item("VoucherDate").ToString
            tdbcEmployeeID.Text = .Item("EmployeeID").ToString
            txtDescription.Text = .Item("Description").ToString
            _cipID = .Item("CipID").ToString
            tdbcCipNo.Text = .Item("CipNo").ToString 'Trường hợp sửa không dùng selectedvalue vì trong combo không có value đó
            tdbcPropertyProductID.Text = .Item("PropertyProductID").ToString
            sProjectID = .Item("ProjectID").ToString
            ' tdbcCipNo.Text = _cipID
            txtCipName.Text = .Item("CipName").ToString
            txtAccountID.Text = .Item("AccountID").ToString
            txtAccountName.Text = .Item("AccountName").ToString
            Dim sTransMode As String = .Item("TransMode").ToString
            If sTransMode = "PropertyProduct" Then
                optTransMode1.Checked = True
            Else
                optTransMode0.Checked = True
            End If
           
            createUserID = .Item("CreateUserID").ToString
            createDate = .Item("CreateDate").ToString

            '22/2/2022, Bùi Thị Thanh Tuyền:id 218198-ORGAN - Điều chỉnh màn hình Cập nhật quyết toán XDCB D02F2011
            chkIsInventoryTranfer.Checked = L3Bool(.Item("IsInventoryTranfer"))
        End With
    End Sub

    Private Sub LoadTDBGrid(ByVal CipID As String, ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iGridID As String, ByVal iMode As String)
        Dim sSQL As New StringBuilder("")
        sSQL.Append(SQLStoreD02P2009(CipID, iGridID, iMode))
        dtGrid = ReturnDataTable(sSQL.ToString)
        
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        Dim iDate As Integer = COLD_RefDate
        If iGridID = "1" Then
            dtTemp = dtGrid.Copy
            iDate = COL_RefDate
        End If
        If _FormState = EnumFormState.FormAdd Then
            tdbg.Columns(iDate).Text = Date.Today.ToShortDateString
        End If
        If tdbg.Name = "tdbg" Then
            tdbg_FooterText()
        Else
            tdbgDetail_FooterText()
        End If

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2009
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 07/05/2007 08:01:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2009(ByVal sCipID As String, ByVal iGridID As String, ByVal iMode As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P2009 "
        sSQL &= SQLString(sCipID) & COMMA 'CipID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iGridID) & COMMA 'GridID, int, NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(_batchID) & COMMA  'BatchID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Sub LoadAdd()
        'tdbcVoucherTypeID.Text = ""

        For i As Integer = 0 To dtVoucherTypeID.Rows.Count - 1
            If dtVoucherTypeID.Rows(i).Item("FormID").ToString = "D02F2011" Then
                Dim sFormID As String = dtVoucherTypeID.Rows(i).Item("VoucherTypeID").ToString
                tdbcVoucherTypeID.Text = sFormID
                Exit Sub
            End If
        Next
        txtVoucherNo.Text = ""
        c1dateVoucherDate.Value = Date.Today
        tdbcEmployeeID.SelectedValue = gsCreateBy
        txtDescription.Text = ""
        tdbcCipNo.SelectedValue = ""
        txtCipName.Text = ""
        txtAccountID.Text = ""
        txtAccountName.Text = ""
        tdbcPropertyProductID.Text = ""
        LoadTDBGrid(_cipID, tdbg, "1", "0")
        LoadTDBGrid(_cipID, tdbgDetail, "2", "0")
        tdbcCipNo.Enabled = True
        tdbcPropertyProductID.Enabled = True

    End Sub

    Private Sub LoadEdit()
        btnNext.Visible = False
        btnSave.Left = btnNext.Left

        tdbcVoucherTypeID.Enabled = False
        txtVoucherNo.ReadOnly = True
        'btnSetNewKey.Enabled = False
        c1dateVoucherDate.Enabled = False
        tdbcCipNo.Enabled = False
        tdbcPropertyProductID.Enabled = False
        LoadMaster()
        LoadTDBGrid(_cipID, tdbg, "1", "1")

        'ID 92835 08.11.2016
        SetRemainQTY()

        LoadTDBGrid(_cipID, tdbgDetail, "2", "1")
     
    End Sub

#Region "Events tdbcVoucherTypeID"

    'Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
    '    If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then tdbcVoucherTypeID.Text = ""
    'End Sub

    'Private Sub tdbcVoucherTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcVoucherTypeID.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcVoucherTypeID.Text = ""
    'End Sub

    'Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged

    '    If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormOther Then
    '        If Not (tdbcVoucherTypeID.Tag Is Nothing OrElse tdbcVoucherTypeID.Tag.ToString = "") Then
    '            tdbcVoucherTypeID.Tag = ""
    '            Exit Sub
    '        End If
    '        GetVoucherNo(tdbcVoucherTypeID, txtVoucherNo, btnSetNewKey)
    '    End If
    'End Sub
#End Region

#Region "Events tdbcEmployeeID"

    Private Sub tdbcEmployeeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.Close
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
    End Sub

    Private Sub tdbcEmployeeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcEmployeeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcEmployeeID.Text = ""
    End Sub
#End Region

    Private Sub btnSetNewKey_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        GetNewVoucherNo(tdbcVoucherTypeID, txtVoucherNo)
    End Sub

    Private Sub ClickButton(ByVal button As Button)
        btnObject.Enabled = Math.Abs(button - button.ObjectButton) > 0
        btnInventory.Enabled = Math.Abs(button - button.Inventory) > 0
        btnAna.Enabled = Math.Abs(button - button.Ana) > 0

        tdbg.Splits(1).DisplayColumns(COL_ObjectTypeID).Visible = Math.Abs(button - button.ObjectButton) = 0 And bFlagObject
        tdbg.Splits(1).DisplayColumns(COL_ObjectID).Visible = Math.Abs(button - button.ObjectButton) = 0 And bFlagObject
        tdbg.Splits(1).DisplayColumns(COL_ObjectName).Visible = Math.Abs(button - button.ObjectButton) = 0 And bFlagObject

        tdbg.Splits(1).DisplayColumns(COL_InventoryID).Visible = Math.Abs(button - button.Inventory) = 0 And bFlagInventory
        tdbg.Splits(1).DisplayColumns(COL_InventoryName).Visible = Math.Abs(button - button.Inventory) = 0 And bFlagInventory
        tdbg.Splits(1).DisplayColumns(COL_UnitID).Visible = Math.Abs(button - button.Inventory) = 0 And bFlagInventory
        tdbg.Splits(1).DisplayColumns(COL_Quantity).Visible = Math.Abs(button - button.Inventory) = 0 And bFlagInventory
        tdbg.Splits(1).DisplayColumns(COL_PeriodID).Visible = Math.Abs(button - button.Inventory) = 0 And bFlagInventory
        tdbg.Splits(1).DisplayColumns(COL_WarehouseID).Visible = Math.Abs(button - button.Inventory) = 0 And bFlagInventory


        tdbg.Splits(1).DisplayColumns(COL_Ana01ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbg.Splits(1).DisplayColumns(COL_Ana02ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbg.Splits(1).DisplayColumns(COL_Ana03ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbg.Splits(1).DisplayColumns(COL_Ana04ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbg.Splits(1).DisplayColumns(COL_Ana05ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbg.Splits(1).DisplayColumns(COL_Ana06ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbg.Splits(1).DisplayColumns(COL_Ana07ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbg.Splits(1).DisplayColumns(COL_Ana08ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbg.Splits(1).DisplayColumns(COL_Ana09ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbg.Splits(1).DisplayColumns(COL_Ana10ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna


        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana01ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana02ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana03ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana04ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana05ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana06ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana07ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana08ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana09ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana10ID).Visible = Math.Abs(button - button.Ana) = 0 And bFlagAna

        iLastCol = CountCol(tdbg, SPLIT1)
    End Sub

    Private Sub btnObject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnObject.Click
        bFlagObject = True
        ClickButton(Button.ObjectButton)
    End Sub

    Private Sub btnInventory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInventory.Click
        bFlagInventory = True
        ClickButton(Button.Inventory)
        If tdbg.Columns(COL_DebitAccountID).Text = "" Then
            tdbg.Columns(COL_InventoryID).Text = ""
            tdbg.Columns(COL_InventoryName).Text = ""
            tdbg.Columns(COL_UnitID).Text = ""
            tdbg.Columns(COL_Quantity).Text = ""
        End If
    End Sub

    Private Sub btnAna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAna.Click
        bFlagAna = True
        ClickButton(Button.Ana)
        LoadTDBGridAnalysisCaption(D02, tdbg, COL_Ana01ID, SPLIT1, True, gbUnicode)
        LoadTDBGridAnalysisCaption(D02, tdbgDetail, COLD_Ana01ID, SPLIT0, True, gbUnicode)
        DisableDropdownAna()
    End Sub
    Private Sub DisableDropdownAna()
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana01ID).Button = False
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana02ID).Button = False
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana03ID).Button = False
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana04ID).Button = False
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana05ID).Button = False
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana06ID).Button = False
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana07ID).Button = False
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana08ID).Button = False
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana09ID).Button = False
        tdbgDetail.Splits(0).DisplayColumns(COLD_Ana10ID).Button = False

    End Sub
    Private dtInv As DataTable
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_Notes
                If tdbg(tdbg.Row, COL_RefDate).ToString = "" Then
                    tdbg.Columns(COL_RefDate).Text = Date.Today.ToShortDateString
                    tdbg.Columns(COL_FinalizeCIP).Value = 0
                End If
            Case COL_RefNo
                If tdbg(tdbg.Row, COL_RefDate).ToString = "" Then
                    tdbg.Columns(COL_RefDate).Text = Date.Today.ToShortDateString
                    tdbg.Columns(COL_FinalizeCIP).Value = 0
                End If

            Case COL_DebitAccountID
                If tdbg.Columns(COL_DebitAccountID).Text = "" Then
                    tdbg.Columns(COL_InventoryID).Text = ""
                    tdbg.Columns(COL_InventoryName).Text = ""
                    tdbg.Columns(COL_UnitID).Text = ""
                    tdbg.Columns(COL_Quantity).Text = ""
                    Exit Select
                End If

                tdbg.Columns(COL_GroupID).Text = tdbdDebitAccountID.Columns("GroupID").Value.ToString

                If tdbg.RowCount >= 1 Then
                    tdbg(tdbg.Row, COL_CreditAccountID) = tdbg(0, COL_CreditAccountID)
                End If
            Case COL_ObjectTypeID
                tdbg.Columns(COL_ObjectID).Text = ""
                tdbg.Columns(COL_ObjectName).Text = ""
            Case COL_ObjectID
                If tdbg.Columns(COL_ObjectID).Text <> "" Then
                    tdbg.Columns(COL_ObjectName).Text = tdbdObjectID.Columns("ObjectName").Text
                End If
            Case COL_InventoryID
               '20/5/2021, id 165276-Bổ sung filterbar mã hàng tại màn hình cập nhập quyết toán XDCB
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then 'ID 251213 : Cải tiến tốc độ load mã hàng
                    If DxxFormat.IsUseCacheOfList Then
                        If dtInv IsNot Nothing Then dtInv.Dispose()
                        dtInv = Nothing
                        System.GC.Collect()
                        dtInv = ReturnDataTable(SQLSelectInv(tdbg.Columns(COL_InventoryID).Text))
                        LoadDataSource(tdbd, dtInv, gbUnicode)
                    End If

                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    AfterColUpdate(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim row As DataRow = ReturnDataRow(tdbd, tdbd.DisplayMember & "=" & SQLString(tdbg.Columns(e.ColIndex).Text))
                    AfterColUpdate(e.ColIndex, row)
                End If
            Case COL_ExchangeRate
                tdbg.Columns(COL_ExchangeRate).Text = SQLNumber(tdbg.Columns(COL_ExchangeRate).Text, DxxFormat.ExchangeRateDecimals)
                'Bổ sung Operator theo ID 71700
                CalcuteConvertedAmount(tdbg.Row)
            Case COL_OriginalAmount
                'Bổ sung Operator theo ID 71700
                CalcuteConvertedAmount(tdbg.Row)
                
            Case COL_ConvertedAmount
                'Bổ sung Operator theo ID 71700
                CalOriginalAmount(tdbg.Row)
            Case COL_ProjectID
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ProjectName).Text = ""
                    tdbg.Columns(COL_TaskID).Text = ""
                    tdbg.Columns(COL_TaskName).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_ProjectName).Text = tdbdProjectID.Columns("ProjectName").Text
                tdbg.Columns(COL_TaskID).Text = ""
                tdbg.Columns(COL_TaskName).Text = ""
            Case COL_TaskID
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_TaskName).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_TaskName).Text = tdbdTaskID.Columns("TaskName").Text
            Case COL_CurrencyID
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ExchangeRate).Text = ""
                    tdbg.Columns(COL_Operator).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_ExchangeRate).Text = tdbdCurrencyID.Columns("ExchangeRate").Text
                tdbg.Columns(COL_Operator).Text = tdbdCurrencyID.Columns("Operator").Text
                CalcuteConvertedAmount(tdbg.Row)
        End Select
        tdbg_FooterText()
    End Sub

    'Nếu lưới có 2 dòng, khi nhập dòng trên thì tự động tính dòng dưới
    Private Sub AutoCalConvertedAmount(ByVal iRow As Integer)
        If _FormState = EnumFormState.FormView Then Exit Sub
        If tdbg.RowCount <> 2 Then Exit Sub
        Dim dToTalConvertedAmount As Double = Number(tdbgDetail.Columns(COLD_ConvertedAmount).FooterText, DxxFormat.D90_ConvertedDecimals)
        If iRow = 0 Then
            tdbg(iRow + 1, COL_ConvertedAmount) = dToTalConvertedAmount - Number(tdbg(iRow, COL_ConvertedAmount), DxxFormat.D90_ConvertedDecimals)
            CalOriginalAmount(iRow + 1)
        Else
            tdbg(iRow - 1, COL_ConvertedAmount) = dToTalConvertedAmount - Number(tdbg(iRow, COL_ConvertedAmount), DxxFormat.D90_ConvertedDecimals)
            CalOriginalAmount(iRow - 1)
        End If
    End Sub

    Private Sub CalcuteConvertedAmount(ByVal iRow As Integer)
        Dim dExchangeRate As Double = 0
        Dim dOriginalAmount As Double = 0
        Dim dConvertedAmount As Double
        If tdbg(iRow, COL_ExchangeRate).ToString <> "" And tdbg(iRow, COL_OriginalAmount).ToString <> "" Then
            dExchangeRate = Number(tdbg(iRow, COL_ExchangeRate))
            dOriginalAmount = Number(tdbg(iRow, COL_OriginalAmount))
            If tdbg(iRow, COL_Operator).ToString <> "" Then
                If L3Int(tdbg(iRow, COL_Operator)) = 0 Then 'Nhan
                    dConvertedAmount = dExchangeRate * dOriginalAmount
                    tdbg(iRow, COL_ConvertedAmount) = SQLNumber(dConvertedAmount.ToString, DxxFormat.D90_ConvertedDecimals)
                Else 'Chia
                    If dExchangeRate <> 0 Then
                        dConvertedAmount = dOriginalAmount / dExchangeRate
                        tdbg(iRow, COL_ConvertedAmount) = SQLNumber(dConvertedAmount.ToString, DxxFormat.D90_ConvertedDecimals)
                    Else
                        D99C0008.MsgL3(rL3("Nguyen_te_khong_hop_le"))
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CalOriginalAmount(ByVal iRow As Integer)
        Dim dExchangeRate As Double = 0
        Dim dOriginalAmount As Double = 0
        Dim dConvertedAmount As Double
        If tdbg(iRow, COL_ExchangeRate).ToString <> "" And tdbg(iRow, COL_ConvertedAmount).ToString <> "" Then
            dExchangeRate = Number(tdbg(iRow, COL_ExchangeRate))
            dConvertedAmount = Number(tdbg(iRow, COL_ConvertedAmount))
            If tdbg(iRow, COL_Operator).ToString <> "" Then
                If L3Int(tdbg(iRow, "Operator")) = 0 Then 'Chia
                    If dExchangeRate <> 0 Then
                        dOriginalAmount = dConvertedAmount / dExchangeRate
                        tdbg(iRow, COL_OriginalAmount) = SQLNumber(dOriginalAmount.ToString, DxxFormat.DecimalPlaces)
                    Else
                        D99C0008.MsgL3(rL3("Nguyen_te_khong_hop_le"))
                        Exit Sub
                    End If
                Else 'Nhan
                    dOriginalAmount = dExchangeRate * dConvertedAmount
                    tdbg(iRow, COL_OriginalAmount) = SQLNumber(dOriginalAmount.ToString, DxxFormat.DecimalPlaces)
                End If
            End If
        End If
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_DebitAccountID
                If tdbg.Columns(COL_DebitAccountID).Text <> tdbdDebitAccountID.Columns("DebitAccountID").Text Then
                    tdbg.Columns(COL_DebitAccountID).Text = ""
                    tdbg.Columns(COL_GroupID).Text = ""
                End If
            Case COL_CreditAccountID
                If tdbg.Columns(COL_CreditAccountID).Text <> tdbdCreditAccountID.Columns("CreditAccountID").Text Then
                    tdbg.Columns(COL_CreditAccountID).Text = ""
                End If
            Case COL_ObjectTypeID
                If tdbg.Columns(COL_ObjectTypeID).Text <> tdbdObjectTypeID.Columns("ObjectTypeID").Text Then
                    tdbg.Columns(COL_ObjectTypeID).Text = ""
                    tdbg.Columns(COL_ObjectID).Text = ""
                    tdbg.Columns(COL_ObjectName).Text = ""
                End If
            Case COL_ObjectID
                If tdbg.Columns(COL_ObjectID).Text <> tdbdObjectID.Columns("ObjectID").Text Then
                    tdbg.Columns(COL_ObjectID).Text = ""
                    tdbg.Columns(COL_ObjectName).Text = ""
                End If
            Case COL_InventoryID
                If clsFilterCombo.IsNewFilter = True Then Exit Sub '20/5/2021, id 165276-Bổ sung filterbar mã hàng tại màn hình cập nhập quyết toán XDCB
                If tdbg.Columns(COL_InventoryID).Text <> tdbdInventoryID.Columns("InventoryID").Text Then
                    tdbg.Columns(COL_InventoryID).Text = ""
                    tdbg.Columns(COL_InventoryName).Text = ""
                    tdbg.Columns(COL_UnitID).Text = ""
                End If
            Case COL_Ana01ID
                If tdbg.Columns(COL_Ana01ID).Text <> tdbdAna01ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana01ID).Text = ""
                End If
            Case COL_Ana02ID
                If tdbg.Columns(COL_Ana02ID).Text <> tdbdAna02ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana02ID).Text = ""
                End If
            Case COL_Ana03ID
                If tdbg.Columns(COL_Ana03ID).Text <> tdbdAna03ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana03ID).Text = ""
                End If
            Case COL_Ana04ID
                If tdbg.Columns(COL_Ana04ID).Text <> tdbdAna04ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana04ID).Text = ""
                End If
            Case COL_Ana05ID
                If tdbg.Columns(COL_Ana05ID).Text <> tdbdAna05ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana05ID).Text = ""
                End If
            Case COL_Ana06ID
                If tdbg.Columns(COL_Ana06ID).Text <> tdbdAna06ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana06ID).Text = ""
                End If
            Case COL_Ana07ID
                If tdbg.Columns(COL_Ana07ID).Text <> tdbdAna07ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana07ID).Text = ""
                End If
            Case COL_Ana08ID
                If tdbg.Columns(COL_Ana08ID).Text <> tdbdAna08ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana08ID).Text = ""
                End If
            Case COL_Ana09ID
                If tdbg.Columns(COL_Ana09ID).Text <> tdbdAna09ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana09ID).Text = ""
                End If
            Case COL_Ana10ID
                If tdbg.Columns(COL_Ana10ID).Text <> tdbdAna10ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana10ID).Text = ""
                End If
            Case COL_ProjectID, COL_TaskID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_WarehouseID '22/2/2022, Bùi Thị Thanh Tuyền:id 218198-ORGAN - Điều chỉnh màn hình Cập nhật quyết toán XDCB D02F2011
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_DebitAccountID, COL_CreditAccountID, COL_InventoryID, COL_ObjectTypeID, COL_ObjectID, COL_ProjectID, COL_TaskID, COL_WarehouseID
                tdbg.UpdateData()
            Case COL_Ana01ID To COL_Ana10ID
                tdbg.UpdateData()
        End Select
    End Sub

    Private Sub tdbg_FetchRowStyle(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If tdbg.RowCount < 1 Then Exit Sub
        If tdbg(e.Row, COL_FinalizeCIP).ToString = "1" Then
            e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR) ' Color.Gainsboro
            e.CellStyle.Locked = True
        Else
            e.CellStyle.ResetBackColor()
            e.CellStyle.Locked = False
        End If
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
                'Case COL_Quantity
                '    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_ButtonClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ButtonClick
        If clsFilterDropdown.IsNewFilter = False Then Exit Sub
        Select Case tdbg.Col '20/5/2021, id 165276-Bổ sung filterbar mã hàng tại màn hình cập nhập quyết toán XDCB
            Case COL_InventoryID
                If DxxFormat.IsUseCacheOfList Then Exit Sub 'ID 251213 : Cải tiến tốc độ load mã hàng
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbdInventoryID)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbg.Col, dr)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If clsFilterDropdown.CheckKeydownFilterDropdown(tdbg, e) Then '20/5/2021, id 165276-Bổ sung filterbar mã hàng tại màn hình cập nhập quyết toán XDCB
            Select Case tdbg.Col
                Case COL_InventoryID
                    If DxxFormat.IsUseCacheOfList Then Exit Sub 'ID 251213 : Cải tiến tốc độ load mã hàng

                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbdInventoryID)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate(tdbg.Col, dr)
                    Exit Sub
            End Select
        End If

        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = iLastCol Then
                HotKeyEnterGrid(tdbg, COL_Notes, e)
            End If
        End If
        If e.Shift And e.KeyCode = Keys.Insert Then
            bInsertRow = True
            HotKeyShiftInsert(tdbg, 0, COL_Notes, tdbg.Columns.Count)
        End If
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
        End If
        If e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg, COL_FinalizeCIP)
            tdbg_FooterText()
        End If
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        Select Case tdbg.Col
            Case COL_ObjectID
                LoadDropDownObjectID(tdbg.Columns(COL_ObjectTypeID).Text)
            Case COL_TaskID
                LoadTask(tdbdTaskID, , tdbg.Columns(COL_ProjectID).Text, False)
        End Select

        If bInsertRow = True And tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
            tdbg.Columns(COL_Notes).Text = "" ' Gán 1 cột bất kỳ ="" cho lưới
            bInsertRow = False
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _cipID = ""
        _batchID = ""
        btnNext.Enabled = False
        btnSave.Enabled = True
        'LoadtdbcCipNo()
        LoadCipNoAndPropertyProductID()
        LoadAdd()
        tdbcVoucherTypeID.Focus()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("So_phieu"))
            txtVoucherNo.Focus()
            Return False
        End If
        If txtDescription.Text <> "" Then
            If Trim(txtDescription.Text).Length > 250 Then
                D99C0008.MsgL3(rL3("Chieu_dai_Dien_giai_khong_duoc_vuot_qua_250_ky_tu"))
                txtDescription.Focus()
                Return False
            End If
        End If
        If tdbcCipNo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ma_XDCB"))
            tdbcCipNo.Focus()
            Return False
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DebitAccountID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("TK_no"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DebitAccountID
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_CreditAccountID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("TK_co"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_CreditAccountID
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_CurrencyID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Loai_tien"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_CurrencyID
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_ExchangeRate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ty_gia"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_ExchangeRate
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_OriginalAmount).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Nguyen_te"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_OriginalAmount
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_ConvertedAmount).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Quy_doi"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_ConvertedAmount
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If

            If tdbg(i, COL_ObjectTypeID).ToString <> "" Then
                If tdbg(i, COL_ObjectID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Doi_tuong"))
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_ObjectID
                    tdbg.Bookmark = i
                    'tdbg.Focus()
                    Return False
                End If
            End If
            If tdbg(i, COL_GroupID).ToString = "21" Or tdbg(i, COL_GroupID).ToString = "4" Then '22/2/2022, Bùi Thị Thanh Tuyền:id 218198-ORGAN - Điều chỉnh màn hình Cập nhật quyết toán XDCB D02F2011
                If tdbg(i, COL_InventoryID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ma_hang"))
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_InventoryID
                    btnInventory.Enabled = True
                    btnInventory_Click(Nothing, Nothing)
                    tdbg.Bookmark = i
                    'tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COL_Quantity).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("So_luong"))
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_Quantity
                    btnInventory.Enabled = True
                    btnInventory_Click(Nothing, Nothing)
                    tdbg.Bookmark = i
                    'tdbg.Focus()
                    Return False
                End If
            End If

            '22/2/2022, Bùi Thị Thanh Tuyền:id 218198-ORGAN - Điều chỉnh màn hình Cập nhật quyết toán XDCB D02F2011
            If chkIsInventoryTranfer.Checked = True AndAlso tdbg(i, COL_WarehouseID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Kho"))
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_WarehouseID
                tdbg.Bookmark = i
                Return False
            End If
        Next

        'ID 92835 08.11.2016
        Dim Sum As Object = tdbgDetail.Columns(COLD_ConvertedAmount).FooterText
        Dim Sum1 As Object = tdbg.Columns(COL_ConvertedAmount).FooterText
        If Number(Sum1, DxxFormat.D90_ConvertedDecimals) > Number(Sum, DxxFormat.D90_ConvertedDecimals) Then
            D99C0008.MsgL3(rL3("So_tien_con_lai_phai_nho_hon_hoac_bang") & " " & bRemainQTY.ToString)
            tdbg.Focus()
            tdbg.Col = COL_ConvertedAmount
            tdbg.Row = 0
            tdbg.SplitIndex = 0
            Return False
        End If

        Return True
    End Function

    'Thêm ngày 19/10/2012 theo incident 51452 của Thị Hiệp bởi Văn Vinh
    Private Function CheckChooseDataGrid() As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            ''Không bắt buộc trên lưới có dữ liệu thi rem lai
            '            D99C0008.MsgL3(rl3("MSG000029"))
            '            Return False
        Else
            Dim dr() As DataRow
            Dim dtTable As DataTable = CType(tdbg.DataSource, DataTable)
            dr = dtTable.Select("FinalizeCIP = 0")
            If dr.Length < 1 Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()
        'Kiểm tra ngày phiếu có phù hợp trog kỳ kế toán hiện tại hay không
        If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Value.ToString) Then Exit Sub
        If tdbcCipNo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ma_XDCB"))
            tdbcCipNo.Focus()
            Exit Sub
        End If
        If Not CheckChooseDataGrid() Then
            Dim sMsg As String = rL3("Ma_XDCB_nay_da_duoc_quyet_toan_het_Ban_co_muon_cap_nhat_trang_thai_khong_")
            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim sSQL1 As String = ""
                sSQL1 = "Update D02T0100 set Status = 2 where CipID = " & SQLString(tdbcCipNo.Columns(0).Value) & vbCrLf
                sSQL1 &= "Update D02T0012 set Status = 1 where CipID = " & SQLString(tdbcCipNo.Columns(0).Value)
                ExecuteSQL(sSQL1)
                Dim bRunSQL1 As Boolean = ExecuteSQL(sSQL1.ToString)
                If bRunSQL1 Then
                    SaveOK()
                    gbSavedOK = True
                    Select Case _FormState
                        Case EnumFormState.FormAdd
                            _cipID = tdbcCipNo.Columns(0).Value.ToString
                            btnNext.Enabled = True
                            btnClose.Enabled = True
                            btnNext.Focus()
                        Case EnumFormState.FormEdit
                            btnSave.Enabled = True
                            btnClose.Enabled = True
                            btnClose.Focus()
                    End Select
                Else
                    SaveNotOK()
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                End If
                btnSave.Enabled = False
            End If
            Exit Sub
        End If
        If Not AllowSave() Then Exit Sub
        Dim sSQL As New StringBuilder("")

        gbSavedOK = False
        btnSave.Enabled = False
        btnClose.Enabled = False
        Select Case _FormState
            Case EnumFormState.FormAdd
                '****************************************
                'Kiểm tra phiếu theo kiểu mới
                'Sinh IGE cho khóa của Phiếu 
                _batchID = CreateIGE("D02T0012", "BatchID", "02", "VC", gsStringKey)
                'Kiểm tra phiếu
                If tdbcVoucherTypeID.Columns("Auto").Text = "1" And bEditVoucherNo = False Then 'Sinh tự động và không nhấn F2
                    txtVoucherNo.Text = CreateIGEVoucherNoNew(tdbcVoucherTypeID, "D02T0012", _batchID)
                Else 'Không sinh tự động hay có nhấn F2
                    If bEditVoucherNo = False Then
                        'Kiểm tra trùng Số phiếu
                        If CheckDuplicateVoucherNoNew(D02, "D02T0012", _batchID, txtVoucherNo.Text) = True Then btnSave.Enabled = True : btnClose.Enabled = True : Me.Cursor = Cursors.Default : Exit Sub
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
                '****************************************

                sSQL.Append(SQLInsertD02T2050s().ToString & vbCrLf)
                sSQL.Append(SQLInsertD02T0012s.ToString & vbCrLf)
                sSQL.Append(SQLStoreD02P2010() & vbCrLf)
                sSQL.Append(SQLUpdateD02T0012.ToString & vbCrLf)

            Case EnumFormState.FormEdit
                'Bước 1
                sSQL.Append(SQLStoreD02P2012() & vbCrLf)
                'Bước 2
                sSQL.Append(SQLInsertD02T2050s.ToString & vbCrLf)
                'Bước 3
                sSQL.Append(SQLInsertD02T0012s.ToString & vbCrLf)
                'Bước 4
                sSQL.Append(SQLStoreD02P2010() & vbCrLf) 'Append 16/12/2011
                'Bước 5
                sSQL.Append(SQLUpdateD02T0012.ToString & vbCrLf)
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            gbSavedOK = True

            Select Case _FormState
                Case EnumFormState.FormAdd
                    _cipID = ReturnValueC1Combo(tdbcCipNo, "CipID")
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
            If tdbcPropertyProductID.Text <> "" Then 'Không được lấy value, vì lúc sửa chỉ load text cho xem, không load value
                ExecuteSQL(SQLStoreD02P2025)
            End If
            tdbcCipNo.Enabled = False
            tdbcPropertyProductID.Enabled = False

        Else
            If _FormState = EnumFormState.FormAdd Then
                DeleteVoucherNoD91T9111_Transaction(txtVoucherNo.Text, "D02T0012", "VoucherNo", tdbcVoucherTypeID, bEditVoucherNo)
            End If
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2025
    '# Created User: HUỲNH KHANH
    '# Created Date: 05/02/2015 03:05:21
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2025() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Store duoc chay khi BDS <> """ & vbCrLf)
        sSQL &= "Exec D02P2025 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbcPropertyProductID.Text) & COMMA 'PropertyProductID, varchar[50], NOT NULL 'Không được lưu value nha. 
        sSQL &= SQLString(_batchID) & COMMA 'BatchID, varchar[50], NOT NULL

        If optTransMode1.Checked Then
            sSQL &= SQLString("PropertyProduct") 'TransMode, varchar[50], NOT NULL
        ElseIf optTransMode0.Checked Then
            sSQL &= SQLString("Project") 'TransMode, varchar[50], NOT NULL
        Else
            sSQL &= SQLString("") 'TransMode, varchar[50], NOT NULL
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T2050s
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 02/05/2007 01:55:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T2050s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        sTransactionID = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransactionID).ToString = "" Then
                iCountIGE += 1
            End If
        Next
        For i As Integer = 0 To tdbg.RowCount - 1
            'Thêm ngày 19/10/2012 theo incident 51452 của Thị Hiệp bởi Văn Vinh
            'Them doan : tdbg(i, COL_FinalizeCIP).ToString = "0"
            If tdbg(i, COL_FinalizeCIP).ToString = "0" Then
                If tdbg(i, COL_TransactionID).ToString = "" And tdbg(i, COL_FinalizeCIP).ToString = "0" Then
                    sTransactionID = CreateIGEs("D02T0012", "TransactionID", "02", "CP", gsStringKey, sTransactionID, iCountIGE)
                    tdbg(i, COL_TransactionID) = sTransactionID
                End If

                sSQL.Append("Insert Into D02T2050(")
                sSQL.Append("BatchID, TransactionID, IsD19, IsD43, IsD07, ")
                sSQL.Append("InventoryID, UnitID, Quantity")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(_batchID) & COMMA) 'BatchID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TransactionID)) & COMMA) 'TransactionID [KEY], varchar[20], NOT NULL
                If tdbdDebitAccountID.Columns(2).Value.ToString = "20" Then
                    sSQL.Append("1" & COMMA) 'IsD19, tinyint, NOT NULL
                Else
                    sSQL.Append("0" & COMMA) 'IsD19, tinyint, NOT NULL
                End If
                If tdbdDebitAccountID.Columns(2).Value.ToString = "21" Then
                    sSQL.Append("1" & COMMA) 'IsD43, tinyint, NOT NULL
                Else
                    sSQL.Append("0" & COMMA) 'IsD43, tinyint, NOT NULL
                End If
                sSQL.Append("0" & COMMA) 'IsD07, tinyint, NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_InventoryID)) & COMMA) 'InventoryID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_UnitID)) & COMMA) 'UnitID, varchar[20], NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_Quantity))) 'Quantity, money, NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T0012s
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 02/05/2007 02:28:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T0012s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("DECLARE @LastModifyDate AS datetime" & vbCrLf)
        sSQL.Append("SET @LastModifyDate = GETDATE()" & vbCrLf)
        For i As Integer = 0 To tdbg.RowCount - 1
            'Thêm ngày 19/10/2012 theo incident 51452 của Thị Hiệp bởi Văn Vinh
            'Them doan : tdbg(i, COL_FinalizeCIP).ToString = "0"
            If tdbg(i, COL_FinalizeCIP).ToString = "0" Then
                sSQL.Append("Insert Into D02T0012(")
                sSQL.Append("TransactionID, DivisionID, ModuleID, AssetID, " & vbCrLf)
                sSQL.Append("VoucherTypeID, VoucherNo, VoucherDate, TranMonth, TranYear, " & vbCrLf)
                sSQL.Append("DescriptionU,  CurrencyID, ExchangeRate, DebitAccountID, " & vbCrLf)
                sSQL.Append("CreditAccountID, OriginalAmount, ConvertedAmount, Status, TransactionTypeID, " & vbCrLf)
                sSQL.Append("RefNo, RefDate, CreateUserID, CreateDate, " & vbCrLf)
                sSQL.Append("LastModifyUserID, LastModifyDate, SeriNo, ObjectTypeID, ObjectID, " & vbCrLf)
                sSQL.Append("BatchID, VATObjectTypeID, VATObjectID, " & vbCrLf)
                sSQL.Append("Ana01ID, Ana02ID, Ana03ID, Ana04ID, Ana05ID, " & vbCrLf)
                sSQL.Append("Ana06ID, Ana07ID, Ana08ID, Ana09ID, Ana10ID, " & vbCrLf)
                sSQL.Append("CipID, NotesU,TransMode, IsNotAllocate, " & vbCrLf)
                sSQL.Append("PropertyProductID,ProjectID, TaskID,ProjectNameU, TaskNameU, " & vbCrLf)
                '22/2/2022, Bùi Thị Thanh Tuyền:id 218198-ORGAN - Điều chỉnh màn hình Cập nhật quyết toán XDCB D02F2011
                sSQL.Append("IsInventoryTranfer, WarehouseID, PeriodID ")

                sSQL.Append(") Values(")
                sSQL.Append(SQLString(tdbg(i, COL_TransactionID)) & COMMA) 'TransactionID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString("02") & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString("") & COMMA & vbCrLf) 'AssetID, varchar[20], NULL
                sSQL.Append(SQLString(tdbcVoucherTypeID.Text) & COMMA) 'VoucherTypeID, varchar[20], NULL
                sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[20], NULL
                sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
                sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
                sSQL.Append(SQLNumber(giTranYear) & COMMA & vbCrLf) 'TranYear, smallint, NULL
                sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'Description, varchar[250], NULL
                sSQL.Append(SQLString(tdbg(i, COL_CurrencyID)) & COMMA) 'CurrencyID, varchar[20], NOT NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_ExchangeRate), DxxFormat.ExchangeRateDecimals) & COMMA) 'ExchangeRate, money, NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_DebitAccountID)) & COMMA & vbCrLf) 'DebitAccountID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_CreditAccountID)) & COMMA) 'CreditAccountID, varchar[20], NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_OriginalAmount), DxxFormat.DecimalPlaces) & COMMA) 'OriginalAmount, money, NULL
                sSQL.Append(SQLMoney(tdbg(i, COL_ConvertedAmount), DxxFormat.D90_ConvertedDecimals) & COMMA) 'ConvertedAmount, money, NULL
                sSQL.Append("1" & COMMA) 'Status, tinyint, NOT NULL
                sSQL.Append(SQLString("") & COMMA & vbCrLf) 'TransactionTypeID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_RefNo)) & COMMA) 'RefNo, varchar[20], NULL
                sSQL.Append(SQLDateSave(tdbg(i, COL_RefDate)) & COMMA) 'RefDate, datetime, NULL
                If _FormState = EnumFormState.FormAdd Then
                    sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                    sSQL.Append("@LastModifyDate" & COMMA & vbCrLf) 'CreateDate, datetime, NULL
                Else
                    sSQL.Append(SQLString(createUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                    sSQL.Append(SQLDateTimeSave(createDate) & COMMA & vbCrLf) 'CreateDate, datetime, NULL
                End If
                sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                sSQL.Append("@LastModifyDate" & COMMA) 'LastModifyDate, datetime, NULL
                sSQL.Append(SQLString(tdbg(i, COL_SeriNo)) & COMMA) 'SeriNo, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_ObjectTypeID)) & COMMA) 'ObjectTypeID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_ObjectID)) & COMMA & vbCrLf) 'ObjectID, varchar[20], NULL
                sSQL.Append(SQLString(_batchID) & COMMA) 'BatchID, varchar[20], NULL
                sSQL.Append(SQLString("NV") & COMMA) 'VATObjectTypeID, varchar[20], NULL
                sSQL.Append(SQLString(tdbcEmployeeID.SelectedValue) & COMMA & vbCrLf) 'VATObjectID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana01ID)) & COMMA) 'Ana01ID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana02ID)) & COMMA) 'Ana02ID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana03ID)) & COMMA) 'Ana03ID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana04ID)) & COMMA) 'Ana04ID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana05ID)) & COMMA & vbCrLf) 'Ana05ID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana06ID)) & COMMA) 'Ana06ID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana07ID)) & COMMA) 'Ana07ID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana08ID)) & COMMA) 'Ana08ID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana09ID)) & COMMA) 'Ana09ID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_Ana10ID)) & COMMA & vbCrLf) 'Ana10ID, varchar[20], NULL
                If _FormState = EnumFormState.FormAdd Then
                    sSQL.Append(SQLString(tdbcCipNo.Columns(0).Value) & COMMA) 'CipID, varchar[20], NULL
                Else
                    sSQL.Append(SQLString(_cipID) & COMMA) 'CipID, varchar[20], NULL
                End If

                sSQL.Append(SQLStringUnicode(tdbg(i, COL_Notes), gbUnicode, True) & COMMA) 'Notes, varchar[250], NULL
                If optTransMode1.Enabled AndAlso optTransMode1.Checked Then
                    sSQL.Append(SQLString("PropertyProduct") & COMMA) 'TransMode, varchar[20], NOT NULL
                ElseIf optTransMode0.Enabled AndAlso optTransMode0.Checked Then
                    sSQL.Append(SQLString("Project") & COMMA) 'TransMode, varchar[20], NOT NULL
                Else
                    sSQL.Append(SQLString("") & COMMA) 'TransMode, varchar[20], NOT NULL
                End If
                sSQL.Append(SQLNumber(tdbg(i, COL_IsNotAllocate)) & COMMA & vbCrLf) 'IsNotAllocate, int, NOT NULL
                'Theo yeu cau anh Long la khong lay ProjectID trong BDS luu nua ma lay tren luoi 71700
                'If _FormState = EnumFormState.FormAdd Then
                '    sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcPropertyProductID)) & COMMA) 'PropertyProductID, varchar[50], NOT NULL
                '    sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPropertyProductID, "D54ProjectID"))) 'PropertyProductID, varchar[50], NOT NULL
                'Else
                '    sSQL.Append(COMMA & SQLString(tdbcPropertyProductID.Text) & COMMA) 'PropertyProductID, varchar[50], NOT NULL
                '    sSQL.Append(SQLString(sProjectID)) 'PropertyProductID, varchar[50], NOT NULL
                'End If
                sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPropertyProductID)) & COMMA) 'PropertyProductID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_ProjectID)) & COMMA) 'ProjectID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TaskID)) & COMMA) 'TaskID, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_ProjectName), gbUnicode, True) & COMMA) 'ProjectNameU, nvarchar[500], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_TaskName), gbUnicode, True) & COMMA & vbCrLf) 'TaskNameU, nvarchar[500], NOT NULL
                '22/2/2022, Bùi Thị Thanh Tuyền:id 218198-ORGAN - Điều chỉnh màn hình Cập nhật quyết toán XDCB D02F2011
                sSQL.Append(SQLNumber(chkIsInventoryTranfer.Checked) & COMMA) 'IsInventoryTranfer, tinyint, NULL
                sSQL.Append(SQLString(tdbg(i, COL_WarehouseID)) & COMMA) 'WarehouseID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_PeriodID))) 'WarehouseID, varchar[50], NOT NULL
                sSQL.Append(") ")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2012
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 02/05/2007 03:19:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2012() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P2012 "
        sSQL &= SQLString(_cipID) & COMMA 'CipID, varchar[20], NOT NULL
        sSQL &= SQLString(_batchID) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2010
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 02/05/2007 03:47:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P2010 "
        If _FormState = EnumFormState.FormAdd Then
            sSQL &= SQLString(tdbcCipNo.Columns("CipID").Value)  'CipID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(_cipID)
        End If
        sSQL &= COMMA & SQLString(_batchID) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_ExchangeRate).DataField, DxxFormat.ExchangeRateDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_OriginalAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_ConvertedAmount).DataField, DxxFormat.D90_ConvertedDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_Quantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        InputNumber(tdbg, arr)
    End Sub

    Private Sub tdbgDetail_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbgDetail.Columns(COLD_ExchangeRate).DataField, DxxFormat.ExchangeRateDecimals, 28, 8)
        AddDecimalColumns(arr, tdbgDetail.Columns(COLD_OriginalAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbgDetail.Columns(COLD_ConvertedAmount).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        InputNumber(tdbgDetail, arr)
    End Sub

    Private Sub tdbg_FooterText()
        FooterTotalGrid(tdbg, COL_Notes)
        FooterSumNew(tdbg, COL_ConvertedAmount)
    End Sub

    Private Sub tdbgDetail_FooterText()
        FooterTotalGrid(tdbgDetail, COLD_VoucherNo)
        FooterSumNew(tdbgDetail, COLD_ConvertedAmount)
    End Sub

    Private Function CheckTotalConvertedAmount() As Boolean
        '  Dim Sum As Double = 0
        'Sum = TotalConvertedAmount()
        dtTemp = dtGrid.Copy
        Dim Sum As Object = dtTemp.Compute("SUM(ConvertedAmount)", "")
        If Number(Sum) = 0 Then Return True
        If Number(tdbg.Columns(COL_ConvertedAmount).FooterText) <> Number(Sum) Then
            D99C0008.MsgL3(rL3("Tong_so_tien_quy_doi_phai_bang") & " " & FormatNumber(Sum, 2).ToString)
            tdbg.Focus()
            tdbg.Col = COL_ConvertedAmount
            tdbg.Row = 0
            tdbg.SplitIndex = 0
            Return False
        End If
        Return True
    End Function

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Cap_nhat_quyet_toan_XDCB_-_D02F2011") & UnicodeCaption(gbUnicode) 'CËp nhËt quyÕt toÀn XDCB - D02F2011
        '================================================================ 
        lblVoucherTypeID.Text = rL3("Loai_phieu") 'Loại phiếu
        lblVoucherNo.Text = rL3("So_phieu") 'Số phiếu
        lblteVoucherDate.Text = rL3("Ngay_phieu") 'Ngày phiếu
        lblEmployeeID.Text = rL3("Nguoi_lap") 'Người lập
        lblDescription.Text = rL3("Dien_giai") 'Diễn giải
        lblAccountID.Text = rL3("Tai_khoan") 'Tài khoản
        lblCipNo.Text = rL3("Ma_XDCB") 'Mã XDCB
        lblXDCB.Text = rL3("Chi_tiet_chung_tu_quyet_toan_XDCB") 'Chi tiết chứng từ quyết toán XDCB
        lblPropertyProductID.Text = rL3("Ma_BDS") 'Mã BĐS
        '================================================================ 
        optTransMode1.Text = rL3("Chuyen_thanh_hang_hoa_BDS") 'Chuyển thành hàng hoá BĐS
        optTransMode0.Text = rL3("Chuyen_vao_du_an") 'Chuyển vào dự án
        '================================================================ 
        tdbcPropertyProductID.Columns("D27PropertyProductID").Caption = rL3("Ma_BDS") 'Mã BĐS
        tdbcPropertyProductID.Columns("D54ProjectID").Caption = rL3("Ma_cong_trinh") 'Mã Dự án
        tdbcPropertyProductID.Columns("CipNo").Caption = rL3("Ma_XDCB") 'Mã XDCB

        btnObject.Text = "1. " & rL3("Doi_tuong")  'Đối tượng
        btnInventory.Text = "2. " & rL3("Mat_hang") 'Mặt hàng
        btnAna.Text = "3. " & rL3("Khoan_muc") 'Khoản mục
        btnSave.Text = rL3("_Luu") '&Lưu
        btnNext.Text = rL3("Nhap__tiep") 'Nhập &tiếp
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        grpDetail.Text = rL3("Thong_tin_tap_hop_chi_phi") & Space(1) 'Thông tin tập hợp chi phí
        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rL3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rL3("Dien_giai") ' Diễn giải
        tdbcEmployeeID.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên
        tdbcCipNo.Columns("CipNo").Caption = rL3("Ma") 'Mã
        tdbcCipNo.Columns("CipName").Caption = rL3("Ten") 'Tên
        tdbcCipNo.Columns("AccountID").Caption = rL3("Ma") 'Mã
        tdbcCipNo.Columns("AccountName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbdDebitAccountID.Columns("DebitAccountID").Caption = rL3("Ma") 'Mã
        tdbdDebitAccountID.Columns("AccountName").Caption = rL3("Ten") 'Tên
        tdbdCreditAccountID.Columns("CreditAccountID").Caption = rL3("Ma") 'Mã
        tdbdCreditAccountID.Columns("AccountName").Caption = rL3("Ten") 'Tên
        tdbdInventoryID.Columns("InventoryID").Caption = rL3("Ma") 'Mã
        tdbdInventoryID.Columns("InventoryName").Caption = rL3("Ten") 'Tên
        tdbdInventoryID.Columns("UnitID").Caption = rL3("Don_vi_tinh") 'Đơn vị tính
        tdbdAna01ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna01ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdAna02ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna02ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdAna03ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna03ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdAna04ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna04ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdAna05ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna05ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdAna06ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna06ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdAna07ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna07ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdAna08ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna08ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdAna09ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna09ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdAna10ID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbdAna10ID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbdObjectTypeID.Columns("ObjectTypeID").Caption = rL3("Ma") 'Mã
        tdbdObjectTypeID.Columns("ObjectTypeName").Caption = rL3("Dien_giai") ' Diễn giải
        tdbdObjectID.Columns("ObjectID").Caption = rL3("Ma") 'Mã
        tdbdObjectID.Columns("ObjectName").Caption = rL3("Ten") 'Tên

        tdbdProjectID.Columns("ProjectID").Caption = rL3("Ma") 'Mã
        tdbdProjectID.Columns("ProjectName").Caption = rL3("Ten") 'Tên
        tdbdTaskID.Columns("TaskID").Caption = rL3("Ma") 'Mã
        tdbdTaskID.Columns("TaskName").Caption = rL3("Ten") 'Tên

        tdbdWareHouseID.Columns("WarehouseID").Caption = rL3("Ma") 'Mã
        tdbdWareHouseID.Columns("WarehouseName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_DataType).Caption = rL3("DataType") 'Loại dữ liệu
        tdbg.Columns(COL_Notes).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_SeriNo).Caption = rL3("So_Seri") 'Số Sêri
        tdbg.Columns(COL_RefNo).Caption = rL3("So_hoa_don") 'Số hóa đơn
        tdbg.Columns(COL_RefDate).Caption = rL3("Ngay_hoa_don") 'Ngày hóa đơn
        tdbg.Columns(COL_DebitAccountID).Caption = rL3("TK_no") 'TK Nợ
        tdbg.Columns(COL_CreditAccountID).Caption = rL3("TK_co") 'TK Có
        tdbg.Columns(COL_CurrencyID).Caption = rL3("Loai_tien") 'Loại tiền
        tdbg.Columns(COL_ExchangeRate).Caption = rL3("Ty_gia") 'Tỷ giá
        tdbg.Columns(COL_OriginalAmount).Caption = rL3("Nguyen_te") 'Nguyên tệ
        tdbg.Columns(COL_ConvertedAmount).Caption = rL3("Quy_doi") 'Quy đổi
        tdbg.Columns(COL_ObjectTypeID).Caption = rL3("Loai_doi_tuong1") 'Loại đối tượng
        tdbg.Columns(COL_ObjectID).Caption = rL3("Doi_tuong") 'Đối tượng
        tdbg.Columns(COL_ObjectName).Caption = rL3("Ten_doi_tuong") 'Tên đối tượng
        tdbg.Columns(COL_InventoryID).Caption = rL3("Ma_hang") 'Mã hàng
        tdbg.Columns(COL_InventoryName).Caption = rL3("Ten_hang_") 'Tên hàng
        tdbg.Columns(COL_UnitID).Caption = rL3("Don_vi_tinh") 'Đơn vị tính
        tdbg.Columns(COL_Quantity).Caption = rL3("So_luong") 'Số lượng
        tdbg.Columns(COL_WarehouseID).Caption = rL3("Kho")    ' Kho
        tdbg.Columns(COL_ProjectID).Caption = rL3("Cong_trinh")
        tdbg.Columns(COL_ProjectName).Caption = rL3("Ten_cong_trinh")
        tdbg.Columns(COL_TaskID).Caption = rL3("Hang_muc")
        tdbg.Columns(COL_TaskName).Caption = rL3("Ten_hang_muc")

        tdbgDetail.Columns("VoucherTypeID").Caption = rL3("Loai_phieu") 'Loại phiếu
        tdbgDetail.Columns("VoucherNo").Caption = rL3("So_phieu") 'Số phiếu
        tdbgDetail.Columns("VoucherDate").Caption = rL3("Ngay_phieu") 'Ngày phiếu
        tdbgDetail.Columns("SeriNo").Caption = rL3("So_Seri") 'Số Sêri
        tdbgDetail.Columns("RefNo").Caption = rL3("So_hoa_don") 'Số hóa đơn
        tdbgDetail.Columns("RefDate").Caption = rL3("Ngay_hoa_don") 'Ngày hóa đơn
        tdbgDetail.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbgDetail.Columns("DebitAccountID").Caption = rL3("TK_no") 'TK Nợ
        tdbgDetail.Columns("CreditAccountID").Caption = rL3("TK_co") 'TK có
        tdbgDetail.Columns("CurrencyID").Caption = rL3("Loai_tien") 'Loại tiền
        tdbgDetail.Columns("ExchangeRate").Caption = rL3("Ty_gia") 'Tỷ giá
        tdbgDetail.Columns("OriginalAmount").Caption = rL3("Nguyen_te") 'Nguyên tệ
        tdbgDetail.Columns("ConvertedAmount").Caption = rL3("Quy_doi") 'Quy đổi

        tdbg.Columns(COL_PeriodID).Caption = rL3("Tap_phi") 'Tập phí
        '================================================================ 
        tdbdPeriodID.Columns("PeriodID").Caption = rL3("Ma") 'Mã
        tdbdPeriodID.Columns("Note").Caption = rL3("Dien_giai") 'Diễn giải

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T0012
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 24/11/2009 02:41:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T0012() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D02T0012 Set ")
        sSQL.Append("Status = 1") 'tinyint, NOT NULL
        sSQL.Append(" Where ")
        If _FormState = EnumFormState.FormAdd Then
            sSQL.Append("CipID = " & SQLString(tdbcCipNo.Columns("CipID").Text) & " And ")
        Else
            sSQL.Append("CipID = " & SQLString(_cipID) & " And ")
        End If

        sSQL.Append("BatchID <> " & SQLString(_batchID))
        Return sSQL
    End Function

#Region "Events tdbcPropertyProductID load tdbcCipNo"

    Private Sub tdbcPropertyProductID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPropertyProductID.SelectedValueChanged
        If tdbcPropertyProductID.SelectedValue Is Nothing OrElse tdbcPropertyProductID.Text = "" Then
            optTransMode0.Enabled = False
            optTransMode1.Enabled = False
            Exit Sub
        End If
        optTransMode0.Enabled = True
        optTransMode1.Enabled = True
        EnableVisibleProjectIDTaskID()
    End Sub

    Private Sub tdbcPropertyProductID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPropertyProductID.Validated
        clsFilterCombo.FilterCombo(tdbcPropertyProductID, e)
        If _FormState <> EnumFormState.FormView AndAlso tdbg.RowCount > 0 AndAlso sOldPropertyProductID <> ReturnValueC1Combo(tdbcPropertyProductID) Then
            If D99C0008.MsgAsk(rL3("Du_lieu_tren_luoi_se_bi_xoa_Ban_co_muon_thuc_hien_ko")) = Windows.Forms.DialogResult.Yes Then
                If dtGrid IsNot Nothing Then dtGrid.Clear()
                LoadDataSource(tdbg, dtGrid, gbUnicode)
                FiltertdbcCipNo(ReturnValueC1Combo(tdbcPropertyProductID))
                LoadtdbdDebitAccountID()
            Else
                tdbcPropertyProductID.SelectedValue = sOldPropertyProductID
            End If
        End If
        sOldPropertyProductID = ReturnValueC1Combo(tdbcPropertyProductID)
        sOldCipNo = ReturnValueC1Combo(tdbcCipNo)
        tdbcCipNo.SelectedValue = ReturnValueC1Combo(tdbcPropertyProductID, "CipNo")

        If tdbcPropertyProductID.FindStringExact(tdbcPropertyProductID.Text) = -1 OrElse tdbcPropertyProductID.SelectedValue Is Nothing OrElse tdbcPropertyProductID.Text = "" Then
            tdbcPropertyProductID.Text = ""
            tdbcCipNo.Text = ""
            If dtGrid IsNot Nothing Then dtGrid.Clear()
            LoadDataSource(tdbg, dtGrid, gbUnicode)
            optTransMode0.Enabled = False
            optTransMode1.Enabled = False
            Exit Sub
        End If

    End Sub

    Private Sub tdbcPropertyProductID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcPropertyProductID.Validating

    End Sub

    '    Private Sub tdbcPropertyProductID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPropertyProductID.KeyDown
    '        If FilterComboCustom(Me, tdbcPropertyProductID, e) = True Then Exit Sub
    '    End Sub

#End Region


#Region "Events tdbcCipNo with txtCipName"

    'Private Sub tdbcCipNo_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCipNo.Close
    '    If tdbcCipNo.FindStringExact(tdbcCipNo.Text) = -1 Then
    '        tdbcCipNo.Text = ""
    '        txtCipName.Text = ""
    '    End If
    'End Sub

    'Private Sub tdbcCipNo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCipNo.SelectedValueChanged
    '    txtCipName.Text = tdbcCipNo.Columns(2).Value.ToString
    '    txtAccountID.Text = tdbcCipNo.Columns(3).Value.ToString
    '    txtAccountName.Text = tdbcCipNo.Columns(4).Value.ToString
    '    LoadTDBGrid(tdbcCipNo.Columns(0).Value.ToString, tdbg, "1", "0")
    '    LoadTDBGrid(tdbcCipNo.Columns(0).Value.ToString, tdbgDetail, "2", "0")
    '    'tdbg_FooterText()
    '    'tdbg_NumberFormat()
    '    'tdbgDetail_NumberFormat()
    'End Sub

    'Private Sub tdbcCipNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcCipNo.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        tdbcCipNo.Text = ""
    '        txtCipName.Text = ""
    '    End If
    'End Sub
#End Region

#Region "Events tdbcCipNo with txtCipName"
    Dim bRemainQTY As Double = 0
    Private Sub tdbcCipNo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCipNo.SelectedValueChanged
        If tdbcCipNo.SelectedValue Is Nothing Or tdbcCipNo.Text = "" Then
            txtCipName.Text = ""
            txtCipName.Text = ""
            txtAccountID.Text = ""
            txtAccountName.Text = ""
        Else
            txtCipName.Text = tdbcCipNo.Columns(2).Value.ToString
            txtAccountID.Text = tdbcCipNo.Columns(3).Value.ToString
            txtAccountName.Text = tdbcCipNo.Columns(4).Value.ToString
            tdbcPropertyProductID.SelectedValue = ReturnValueC1Combo(tdbcCipNo, "D27PropertyProductID")
            LoadTDBGrid(tdbcCipNo.Columns(0).Value.ToString, tdbg, "1", "0")
            If (dtGrid.Rows.Count > 0) Then
                'ID 92835 08.11.2016
                SetRemainQTY()
            End If

            LoadTDBGrid(tdbcCipNo.Columns(0).Value.ToString, tdbgDetail, "2", "0")
        End If
        LoadtdbdDebitAccountID()
    End Sub

    Private Sub SetRemainQTY()
        bRemainQTY = 0
        For i As Integer = 0 To dtGrid.Rows.Count - 1
            If L3String(dtGrid.Rows(i)("FinalizeCIP")) = "0" Then
                bRemainQTY = bRemainQTY + Number(dtGrid.Rows(i).Item("ConvertedAmount"), DxxFormat.D90_ConvertedDecimals)
            End If
        Next
    End Sub

    Private Sub tdbcCipNo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCipNo.LostFocus
        If tdbcCipNo.FindStringExact(tdbcCipNo.Text) = -1 Then
            tdbcCipNo.Text = ""
            txtCipName.Text = ""
            txtCipName.Text = ""
            txtAccountID.Text = ""
            txtAccountName.Text = ""
            tdbcPropertyProductID.Text = ""
            LoadTDBGrid("", tdbg, "1", "0")
            LoadTDBGrid("", tdbgDetail, "2", "0")
            LoadtdbdDebitAccountID()
        End If
    End Sub

#End Region

    Private Sub optTransMode0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTransMode0.CheckedChanged
        LoadtdbdDebitAccountID()
    End Sub

    'Incident 	73638
#Region "Chuẩn hóa sinh số phiếu"
    Dim sOldVoucherNo As String = "" 'Lưu lại số phiếu cũ
    Dim bEditVoucherNo As Boolean = False '= True: có nhấn F2; = False: không
    Dim bFirstF2 As Boolean = False 'Nhấn F2 lần đầu tiên
    Dim iPer_F5558 As Integer = 0 'Phân quyền cho Sửa số phiếu

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

                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D02F5558")
                SetProperties(arrPro, "VoucherTypeID", ReturnValueC1Combo(tdbcVoucherTypeID))
                If _FormState = EnumFormState.FormAdd Then
                    SetProperties(arrPro, "VoucherID", "")
                ElseIf _FormState = EnumFormState.FormEdit Then
                    SetProperties(arrPro, "VoucherID", _batchID)
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

    Private Sub optTransMode1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTransMode1.Click
        EnableVisibleProjectIDTaskID()
    End Sub

    Private Sub optTransMode0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTransMode0.Click
        EnableVisibleProjectIDTaskID()
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
            Case COL_InventoryID '20/5/2021, id 165276-Bổ sung filterbar mã hàng tại màn hình cập nhập quyết toán XDCB
                If dr Is Nothing OrElse dr.Item("InventoryID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_InventoryID).Text = ""
                    tdbg.Columns(COL_InventoryName).Text = ""
                    tdbg.Columns(COL_UnitID).Text = ""
                    Exit Sub
                End If
                tdbg.Columns(COL_InventoryID).Text = dr.Item("InventoryID").ToString
                tdbg.Columns(COL_InventoryName).Text = dr.Item("InventoryName").ToString
                tdbg.Columns(COL_UnitID).Text = dr.Item("UnitID").ToString
        End Select

    End Sub

#Region "Event tdbgDetail"

    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Dim sFilter As New System.Text.StringBuilder()
    Private sFind As String = ""
    Private Sub ReLoadTDBGDetail()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        tdbgDetail_FooterText()
    End Sub
    Private Sub tdbgDetail_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgDetail.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbgDetail, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGDetail()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgDetail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgDetail.KeyPress
        Select Case tdbgDetail.Col
            Case COLD_RefDate, COLD_VoucherDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới

    Private Sub tdbgDetail_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgDetail.MouseClick
        iHeight = e.Location.Y
    End Sub

   
    Private Sub tdbgDetail_RowColChange(sender As Object, e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgDetail.RowColChange
        If tdbgDetail.Columns(tdbgDetail.Col).DropDown IsNot Nothing Then
            'tdbgDetail.Splits(1).DisplayColumns(tdbgDetail.Col).Button = L3Bool(tdbg.Columns(COL_IsUsed).Text)
            tdbgDetail.Splits(0).DisplayColumns(tdbgDetail.Col).AutoDropDown = Not tdbgDetail.FilterActive
            tdbgDetail.Splits(0).DisplayColumns(tdbgDetail.Col).AutoComplete = Not tdbgDetail.FilterActive
        End If
    End Sub
#End Region

  
    
End Class