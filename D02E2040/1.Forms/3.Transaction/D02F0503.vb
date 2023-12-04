Imports System
Imports System.Text
Public Class D02F0503

    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            LoadTDBCombo()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False
                    LoadValueDetail()
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    ReadOnlyControl(tdbcVoucherTypeID)
                    ReadOnlyControl(txtVoucherNo)
                    ReadOnlyControl(c1dateVoucherDate)
                    ReadOnlyControl(txtDescription)
                    ReadOnlyControl(tdbcAssetID)
                    LoadData()
                    btnSave.Focus()
            End Select
        End Set
    End Property

    Private _sVoucherNo As String
    Public Property sVoucherNo() As String
        Get
            Return _sVoucherNo
        End Get
        Set(ByVal Value As String)
            _sVoucherNo = Value
        End Set
    End Property

    Private _assetID As String
    Public Property AssetID() As String
        Get
            Return _assetID
        End Get
        Set(ByVal Value As String)
            _assetID = Value
        End Set
    End Property

    Private _transactionID As String
    Public Property TransactionID() As String
        Get
            Return _transactionID
        End Get
        Set(ByVal Value As String)
            _transactionID = Value
        End Set
    End Property

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D02, , gbUnicode)
        'Load tdbcAssetID
        sSQL = SQLStoreD02P0020()
        LoadDataSource(tdbcAssetID, sSQL, gbUnicode)
    End Sub

    Private Sub D02F0503_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D02F0503_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)
        Loadlanguage()
        SetBackColorObligatory()
        
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub LoadValueDetail()
        c1dateVoucherDate.Value = Now
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("But_toan_khau_hao_-_D02F0503") & UnicodeCaption(gbUnicode) 'Bòt toÀn khÊu hao - D02F0503
        '================================================================ 
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblAssetID.Text = rl3("Ma_tai_san") 'Mã tài sản
        lblBeginConvertedAmount.Text = rl3("Nguyen_gia") 'Nguyên giá
        lblBeginAccuAmount.Text = rl3("Hao_mon_luy_ke") 'Hao mòn lũy kế
        lblRemainAmount.Text = rl3("Gia_tri_con_lai") 'Giá trị còn lại
        lblMethodName.Text = rl3("Phuong_phap_KH") 'Phương pháp KH
        lblDepreciatedAmount.Text = rl3("Muc_khau_hao") 'Mức khấu hao
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        '================================================================ 
        GroupBox1.Text = rl3("Thong_tin_phieu") 'Thông tin phiếu
        GroupBox2.Text = rl3("Thong_tin_tai_san") 'Thông tin tài sản
        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Ten") 'Tên
        tdbcAssetID.Columns("AssetID").Caption = rl3("Ma") 'Mã
        tdbcAssetID.Columns("AssetName").Caption = rl3("Ten") 'Tên
    End Sub

#Region "Events tdbcVoucherTypeID"

    Private Sub tdbcVoucherTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then tdbcVoucherTypeID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAssetID with txtAssetName"

    Private Sub tdbcAssetID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetID.SelectedValueChanged
        If tdbcAssetID.SelectedValue Is Nothing Then
            txtAssetName.Text = ""
            txtBeginConvertedAmount.Text = ""
            txtBeginAccuAmount.Text = ""
            txtRemainAmount.Text = ""
            txtMethodName.Text = ""
        Else
            txtAssetName.Text = tdbcAssetID.Columns(1).Value.ToString
            txtBeginConvertedAmount.Text = Format(Number(tdbcAssetID.Columns("BeginConvertedAmount").Value.ToString), DxxFormat.D90_ConvertedDecimals)
            txtBeginAccuAmount.Text = Format(Number(tdbcAssetID.Columns("BeginAccuAmount").Value.ToString), DxxFormat.D90_ConvertedDecimals)
            txtRemainAmount.Text = Format(Number(tdbcAssetID.Columns("RemainAmount").Value.ToString), DxxFormat.D90_ConvertedDecimals)
            txtMethodName.Text = tdbcAssetID.Columns("MethodName").Value.ToString
        End If
    End Sub

    Private Sub tdbcAssetID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetID.LostFocus
        If tdbcAssetID.FindStringExact(tdbcAssetID.Text) = -1 Then
            tdbcAssetID.Text = ""
        End If
    End Sub

#End Region

    Private Sub SetBackColorObligatory()
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcAssetID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtDepreciatedAmount.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Dim TableName As String = "D02T0012"
        Select Case _FormState
            Case EnumFormState.FormAdd
                _transactionID = CreateIGE("D02T0012", "TransactionID", "02", "KH", gsStringKey)
                If tdbcVoucherTypeID.Columns("Auto").Text = "1" And bEditVoucherNo = False Then 'Sinh tự động
                    txtVoucherNo.Text = CreateIGEVoucherNoNew(tdbcVoucherTypeID, "D02T0012", _transactionID)
                Else 'Không sinh tự động hay có nhấn F2
                    If bEditVoucherNo = False Then
                        'Kiểm tra trùng Số phiếu
                        If CheckDuplicateVoucherNoNew("D02", "D02T0012", _transactionID, txtVoucherNo.Text) = True Then btnSave.Enabled = True : btnClose.Enabled = True : Me.Cursor = Cursors.Default : Exit Sub
                    Else 'Có nhấn F2 để sửa số phiếu
                        'Insert Số phiếu vào bảng D02T5558
                        InsertD02T5558(_transactionID, sOldVoucherNo, txtVoucherNo.Text)
                    End If
                    'Insert VoucherNo vào bảng D91T9111
                    InsertVoucherNoD91T9111(txtVoucherNo.Text, "D02T0012", _transactionID)
                End If
                bEditVoucherNo = False
                sOldVoucherNo = ""
                bFirstF2 = False

                _sVoucherNo = txtVoucherNo.Text
                sSQL.Append(SQLStoreD02P0005)

            Case EnumFormState.FormEdit
                ExecuteSQLNoTransaction(SQLGeneral.SQLStoreD91P9200(TableName, 0, "TransactionID", _transactionID))

                'sSQL.Append(SQLStoreD91P9200(0) & vbCrLf)
                sSQL.Append(SQLUpdateD02T0012().ToString)
                'sSQL.Append(SQLStoreD91P9200(1) & vbCrLf)
                'sSQL.Append(SQLStoreD91P9106())

        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            gbSavedOK = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    Lemon3.D91.RunAuditLogDetail("02", "DepAllo", "02", _transactionID, TableName, "TransactionID", _transactionID, _assetID, txtAssetName.Text, txtVoucherNo.Text, L3String(c1dateVoucherDate.Value), giTranMonth.ToString("00") & "/" & giTranYear)
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
        If tdbcAssetID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ma_tai_san"))
            tdbcAssetID.Focus()
            Return False
        End If
        If txtDepreciatedAmount.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Muc_khau_hao"))
            txtDepreciatedAmount.Focus()
            Return False
        End If
        If txtRemainAmount.Text <> "" Then
            If CDec(txtRemainAmount.Text) < CDec(txtDepreciatedAmount.Text) Then
                D99C0008.MsgL3(rL3("Gia_tri_khau_hao_khong_duoc_lon_hon_gia_tri_con_lai"))
                Return False
            End If
        Else
            If 0 < CDec(txtDepreciatedAmount.Text) Then
                D99C0008.MsgL3(rL3("Gia_tri_khau_hao_khong_duoc_lon_hon_gia_tri_con_lai"))
                Return False
            End If
        End If
        If _FormState = EnumFormState.FormAdd Then
            If CheckDuplicateVoucherNo("D02", "D02T0012", "", txtVoucherNo.Text) Then
                Return False
            End If
        End If
        If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Value.ToString) Then
            c1dateVoucherDate.Focus()
            Return False
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD02T0012
    '# Created User: Lê Sơn Long
    '# Created Date: 03/11/2010 04:05:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD02T0012() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D02T0012 Set ")
        sSQL.Append("OriginalAmount = " & SQLMoney(txtDepreciatedAmount.Text, DxxFormat.D90_ConvertedDecimals) & COMMA) 'money, NULL
        sSQL.Append("ConvertedAmount = " & SQLMoney(txtDepreciatedAmount.Text, DxxFormat.D90_ConvertedDecimals) & COMMA) 'money, NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("TransactionID = " & SQLString(_transactionID) & " And ")
        sSQL.Append("AssetID = " & SQLString(_assetID))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9106
    '# Created User: Lê Sơn Long
    '# Created Date: 03/11/2010 04:14:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD91P9106() As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D91P9106 "
    '    sSQL &= SQLDateSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
    '    sSQL &= SQLString("DepAllo") & COMMA 'AuditCode, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString("02") & COMMA 'ModuleID, varchar[2], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString("02") & COMMA 'EventID, varchar[20], NOT NULL
    '    sSQL &= SQLString(_assetID) & COMMA 'Desc1, varchar[250], NOT NULL
    '    sSQL &= SQLString(txtAssetName.Text) & COMMA 'Desc2, varchar[250], NOT NULL
    '    sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'Desc3, varchar[250], NOT NULL
    '    sSQL &= SQLDateSave(c1dateVoucherDate.Value) & COMMA 'Desc4, varchar[250], NOT NULL
    '    sSQL &= SQLString(giTranMonth.ToString("00") & "/" & giTranYear) & COMMA 'Desc5, varchar[250], NOT NULL
    '    sSQL &= SQLNumber(1) & COMMA 'IsAuditDetail, tinyint, NOT NULL
    '    sSQL &= SQLString(_transactionID) 'AuditItemID, varchar[50], NOT NULL
    '    Return sSQL
    'End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9200
    '# Created User: Lê Sơn Long
    '# Created Date: 03/11/2010 04:03:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD91P9200(ByVal mode As Integer) As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D91P9200 "
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString("D02T0012") & COMMA 'TableName, varchar[20], NOT NULL
    '    sSQL &= SQLString("TransactionID") & COMMA 'ColVoucherID, varchar[50], NOT NULL
    '    sSQL &= SQLString(_transactionID) & COMMA 'VoucherID, varchar[50], NOT NULL
    '    sSQL &= SQLNumber(mode) & COMMA 'Mode, tinyint, NOT NULL
    '    sSQL &= SQLString("") & COMMA 'ColTransID, varchar[50], NOT NULL
    '    sSQL &= SQLNumber(0) & COMMA 'LineType, int, NOT NULL
    '    sSQL &= SQLString("") 'sLineFilter, varchar[8000], NOT NULL
    '    Return sSQL
    'End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0005
    '# Created User: Lê Sơn Long
    '# Created Date: 03/11/2010 03:51:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0005() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0005 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbcAssetID.Text) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'NormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLMoney(txtDepreciatedAmount.Text, DxxFormat.D90_ConvertedDecimals) & COMMA 'DepreciatedAmount, money, NOT NULL
        sSQL &= SQLString(tdbcVoucherTypeID.Text) & COMMA 'VoucherTypeID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDate.Value) & COMMA 'VoucherDate, datetime, NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA  'Description, varchar[250], NOT NULL
        ' update 25/10/2013 id 60917 - Kiểm tra lai thấy con nhiều tham số chưa truyền thì truyền mac84 định
        ' Theo Bảo Trân - truyền Notes là txtDescription
        sSQL &= SQLString("") & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Notes, varchar[250], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'CheckAssetID, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'CheckAssetName, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLStringUnicode(txtDescription, True) & COMMA 'DescriptionU, nvarchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtDescription, True) 'NotesU, nvarchar[250], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0020
    '# Created User: Lê Sơn Long
    '# Created Date: 03/11/2010 08:42:22
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0020 "
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)  'TranYear, int, NOT NULL
        Return sSQL
    End Function

#Region "Events tdbcVoucherTypeID with txtVoucherNo"
    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        bFirstF2 = False
        bEditVoucherNo = False

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

#End Region
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        tdbcVoucherTypeID_SelectedValueChanged(Nothing, Nothing)
        tdbcAssetID.Text = ""
        txtBeginAccuAmount.Text = ""
        txtBeginConvertedAmount.Text = ""
        txtDepreciatedAmount.Text = ""
        txtMethodName.Text = ""
        txtRemainAmount.Text = ""
        btnSave.Enabled = True
        btnNext.Enabled = False
    End Sub

    Private Sub txtXXX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBeginConvertedAmount.KeyPress, txtBeginAccuAmount.KeyPress, txtRemainAmount.KeyPress, txtDepreciatedAmount.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub LoadData()
        Dim dt As DataTable
        dt = ReturnDataTable(SQLStoreD02P0503)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tdbcVoucherTypeID.Text = .Item("VoucherTypeID").ToString
                txtVoucherNo.Text = .Item("VoucherNo").ToString
                c1dateVoucherDate.Value = .Item("VoucherDate").ToString
                txtDescription.Text = .Item("Description").ToString
                tdbcAssetID.Text = .Item("AssetID").ToString
                txtBeginConvertedAmount.Text = Format(Number(.Item("BeginConvertedAmount").ToString), DxxFormat.D90_ConvertedDecimals)
                txtBeginAccuAmount.Text = Format(Number(.Item("BeginAccuAmount").ToString), DxxFormat.D90_ConvertedDecimals)
                txtRemainAmount.Text = Format(Number(.Item("RemainAmount").ToString), DxxFormat.D90_ConvertedDecimals)
                txtMethodName.Text = .Item("MethodName").ToString
                txtDepreciatedAmount.Text = Format(Number(.Item("DepreciatedAmount").ToString), DxxFormat.D90_ConvertedDecimals)
                c1dateVoucherDate.Value = SQLDateShow(.Item("VoucherDate").ToString)
            End With
        End If
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0503
    '# Created User: Lê Sơn Long
    '# Created Date: 04/11/2010 10:36:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0503() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0503 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_assetID) & COMMA 'AssetID, varchar[50], NOT NULL
        sSQL &= SQLString(_transactionID) & COMMA 'TransactionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'TransactionID, varchar[50], NOT NULL
        Return sSQL
    End Function

    Private Sub txtDepreciatedAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDepreciatedAmount.LostFocus
        If Not IsNumeric(txtDepreciatedAmount.Text) Then txtDepreciatedAmount.Text = ""
        txtDepreciatedAmount.Text = SQLNumber(txtDepreciatedAmount.Text, DxxFormat.D90_ConvertedDecimals)
    End Sub

    Private Sub txtDepreciatedAmount_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDepreciatedAmount.MouseDown
        'Không cho paste ký tự đặc biệt bằng chuột
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Clipboard.GetText.Trim <> "" Then Clipboard.SetText(Clipboard.GetText.Trim)
            Dim txt As TextBox = CType(sender, TextBox)
            If CheckCharactor(Clipboard.GetText, txt.MaxLength) Then Clipboard.Clear()
        End If
    End Sub

    Private Function CheckCharactor(ByVal str As String, Optional ByVal iLength As Integer = 20) As Boolean
        If str.Length > iLength Then
            Return True
        End If
        For Each c As Char In str
            If c <> CChar("0") And c <> CChar("1") And c <> CChar("2") And c <> CChar("3") And c <> CChar("4") And c <> CChar("5") And c <> CChar("6") And c <> CChar("7") _
            And c <> CChar("8") And c <> CChar("9") And c <> CChar("(") And c <> CChar(")") And c <> CChar(",") And c <> CChar(";") And c <> CChar("-") Then Return True
        Next
        Return False
    End Function

    Dim bFirstF2 As Boolean = False 'Nhấn F2 lần đầu tiên 
    Dim sOldVoucherNo As String = "" 'Lưu lại số phiếu cũ
    Dim bEditVoucherNo As Boolean = False '= True: có nhấn F2; = False: không 

    Private Sub txtVoucherNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVoucherNo.KeyDown
        'If e.KeyCode = Keys.F2 Then
        '    'Loại phiếu hay Số phiếu = "" thì thoát
        '    If tdbcVoucherTypeID.Text = "" Or txtVoucherNo.Text = "" Then Exit Sub

        '    'Kiểm tra quyền cho trường hợp Sửa
        '    If ReturnPermission("D02P5558") <= 2 Then Exit Sub

        '    'Cho sửa Số phiếu ở trạng thái Thêm mới hay Sửa

        '    'Trước khi gọi exe con thì nhớ lại Số phiếu cũ
        '    If bFirstF2 = False Then
        '        sOldVoucherNo = txtVoucherNo.Text
        '        bFirstF2 = True
        '    End If

        '    'Gọi exe con D91E0640
        '    Dim frm As New D91F5558
        '    With frm
        '        .FormName = "D91F5558"
        '        .FormPermission = "D02F5558" 'Màn hình phân quyền
        '        .ModuleID = D02 'Mã module hiện tại, VD: D22
        '        .TableName = "D02T0012" 'Tên bảng chứa số phiếu
        '        .VoucherNo = txtVoucherNo.Text 'Số phiếu cần sửa
        '        .VoucherID = ""
        '        .Mode = "0" ' Tùy theo Module, mặc định là 0
        '        .KeyID01 = "AL"
        '        .KeyID02 = ""
        '        .KeyID03 = ""
        '        .KeyID04 = ""
        '        .KeyID05 = ""
        '        .ShowDialog()
        '        Dim sVoucherNo As String
        '        sVoucherNo = .Output02
        '        .Dispose()
        '        If sVoucherNo <> "" Then
        '            txtVoucherNo.Text = sVoucherNo 'Giá trị trả về Số phiếu mới
        '            ReadOnlyControl(txtVoucherNo) 'Lock text Số phiếu
        '            bEditVoucherNo = True 'Đã nhấn F2
        '            gbSavedOK = True
        '        End If
        '    End With
        'End If
    End Sub

End Class