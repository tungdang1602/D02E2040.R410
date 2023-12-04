Imports System
Public Class D02F2013
    Dim dtLeft, dtRight As DataTable
    Private dtObjectID, dtObjectTypeID As DataTable
    Dim oFilterCombo As Lemon3.Controls.FilterCombo
    Public dtData As DataTable 'Dung de tra ve du lieu cho Form cha

#Region "Const of tdbgLeft - Total of Columns: 3"
    Private Const COL_AssetID As Integer = 0              ' Mã tài sản
    Private Const COL_AssetName As Integer = 1            ' Tên tài sản
    Private Const COL_D27PropertyProductID As Integer = 2 ' Mã BĐS
#End Region


#Region "Const of tdbgRight - Total of Columns: 6"
    Private Const COL1_AssetID As Integer = 0              ' Mã tài sản
    Private Const COL1_AssetName As Integer = 1            ' Tên tài sản
    Private Const COL1_D27PropertyProductID As Integer = 2 ' Mã BĐS
    Private Const COL1_AssetConditionID As Integer = 3     ' Tình trạng
    Private Const COL1_AssetConditionName As Integer = 4   ' AssetConditionName
    Private Const COL1_Description As Integer = 5          ' Diễn giải
#End Region

    Private Sub D02F2013_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.KeyCode = Keys.F3 Then
            btnView_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub D09F2130_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gbEnabledUseFind = False
        gbSavedOK = False
        Loadlanguage()
        SetShortcutPopupMenuNew(Me, Nothing, ContextMenuStrip1, False)
        ResetColorGrid(tdbgLeft)
        InputbyUnicode(Me, gbUnicode)
        ResetColorGrid(tdbgRight)
        chkIsStopDepre_Click(Nothing, Nothing)

        LoadTDBDropDown()
        tdbgLeft_LockedColumns()
        tdbgRight_LockedColumns()
        CheckbtnView()
        'LoadTDBGridLeft()
        tdbgLeft.Splits(0).DisplayColumns(COL_D27PropertyProductID).Visible = D02Systems.CIPforPropertyProduct
        tdbgRight.Splits(0).DisplayColumns(COL1_D27PropertyProductID).Visible = D02Systems.CIPforPropertyProduct

        oFilterCombo = New Lemon3.Controls.FilterCombo
        LoadCombo()
        oFilterCombo.CheckD91 = False 'Giá trị mặc định True: kiểm tra theo DxxFormat.LoadFormNotINV. Ngược lại luôn luôn Filter dạng mới (dùng cho Novaland)
        oFilterCombo.AddPairObject(tdbcManagementObjectTypeID, tdbcManagementObjectID) 'Tab 1: Bộ phận quản lý
        oFilterCombo.AddPairObject(tdbcObjectTypeID, tdbcObjectID)
        oFilterCombo.UseFilterComboObjectID()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
End Sub

    Private Sub LoadCombo()
        Dim sSQL As String = "Select '%' as EffectReasonID, " & AllName & " as Description, 0 as DisplayOrder"
        sSQL &= " Union All "
        sSQL &= "Select LookupID as EffectReasonID,Description" & UnicodeJoin(gbUnicode) & " as Description,DisplayOrder from D91T0320 WITH(NOLOCK) "
        sSQL &= " where LookupType = 'D02_EffectReason' and Disabled = 0 "
        sSQL &= " order by DisplayOrder,EffectReasonID"
        LoadDataSource(tdbcEffectReasonID, sSQL, gbUnicode)
        tdbcEffectReasonID.AutoSelect = True
        LoadObjectTypeID(tdbcManagementObjectTypeID, gbUnicode)
        LoadObjectTypeID(tdbcObjectTypeID, gbUnicode)
        'Load tdbcObjectID
        dtObjectID = oFilterCombo.LoadObjectID(Lemon3.Data.eUnionAll.All)
        oFilterCombo.LoadtdbcObjectID(tdbcManagementObjectID, dtObjectID, "")
        LoadDataSource(tdbcObjectID, dtObjectID.Clone, gbUnicode)
        LoadCboCreateBy(tdbcEmployeeID, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdAssetConditionalID
        sSQL = "--Combo tinh trang" & vbCrLf
        
        sSQL &= " SELECT 		LookupID AS AssetConditionID,  Description" & UnicodeJoin(gbUnicode) & " AS AssetConditionName"
        sSQL &= " FROM	 	D91T0320 WITH(NOLOCK)"
        sSQL &= " WHERE		LookupType = 'D02_AssetConditionID'"
        LoadDataSource(tdbdAssetConditionalID, sSQL, gbUnicode)
    End Sub



    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Loc_tai_san_-_D02F2013") & UnicodeCaption(gbUnicode) 'Lãc tªi s¶n - D02F2013
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNextD09F2130.Text = rl3("Tiep_tuc") 'Tiếp tục
        btnView.Text = rL3("Xem") & " (F3)"
        btnFilter.Text = rL3("Loc") & " (F5)" '&Lọc
        '================================================================ 
        grp1.Text = rl3("Ma_tai_san") 'Mã tài sản
        grp3.Text = rl3("Ma_tai_san_duoc_chon") 'Mã tài sản được chọn
        '================================================================ 
        tdbgLeft.Columns("AssetID").Caption = rl3("Ma_tai_san") 'Mã tài sản
        tdbgLeft.Columns("AssetName").Caption = rL3("Ten_tai_san") 'Tên tài sản
        tdbgLeft.Columns("D27PropertyProductID").Caption = rL3("Ma_BDS")

        '================================================================ 
        '================================================================ 
        tdbgRight.Columns(COL1_AssetID).Caption = rL3("Ma_tai_san") 'Mã tài sản
        tdbgRight.Columns(COL1_AssetName).Caption = rL3("Ten_tai_san") 'Tên tài sản
        tdbgRight.Columns(COL1_D27PropertyProductID).Caption = rL3("Ma_BDS") 'Mã BĐS
        tdbgRight.Columns(COL1_AssetConditionID).Caption = rL3("Tinh_trang") 'Tình trạng
        tdbgRight.Columns(COL1_Description).Caption = rL3("Dien_giai") 'Diễn giải

        '================================================================ 
        lblManagementObjectTypeID.Text = rL3("Bo_phan_quan_ly") 'Bộ phận quản lý
        tdbcManagementObjectTypeID.Columns("ObjectTypeID").Caption = rL3("Ma") 'Mã
        tdbcManagementObjectTypeID.Columns("ObjectTypeName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbcManagementObjectID.Columns("ObjectTypeID").Caption = rL3("Loai_DT") 'Loại ĐT
        tdbcManagementObjectID.Columns("ObjectID").Caption = rL3("Ma") 'Mã
        tdbcManagementObjectID.Columns("ObjectName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        lblObjectTypeID.Text = rL3("Bo_phan_tiep_nhan") 'Bộ phận tiếp nhận
        lblEmployeeID.Text = rL3("Nguoi_tiep_nhan") 'Người tiếp nhận
        '================================================================ 
        tdbcObjectTypeID.Columns("ObjectTypeID").Caption = rL3("Ma") 'Mã
        tdbcObjectTypeID.Columns("ObjectTypeName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbcObjectID.Columns("ObjectTypeID").Caption = rL3("Loai_DT") 'Loại ĐT
        tdbcObjectID.Columns("ObjectID").Caption = rL3("Ma") 'Mã
        tdbcObjectID.Columns("ObjectName").Caption = rL3("Ten") 'Tên

        tdbcEmployeeID.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        tdbcEffectReasonID.Columns("EffectReasonID").Caption = rl3("Ma")
        tdbcEffectReasonID.Columns("Description").Caption = rl3("Ten")
        chkIsStopDepre.Text = rl3("Hien_thi_cac_tai_san_ngung_khau_hao")
        lblEffectReasonID.Text = rL3("Ly_do_tac_dong")


    End Sub

    Private Sub FooterText()
        FooterTotalGrid(tdbgLeft, COL_AssetName)
        FooterTotalGrid(tdbgRight, COL_AssetName)
    End Sub

    Private Sub LoadTDBGridLeft()
        Dim sSQL As String = ""

        'sSQL = "SELECT '' As BatchID, '' As OrderNo, N19.AssetID, N19.AssetName" & UnicodeJoin(gbUnicode) & " As AssetName," & vbCrLf
        'sSQL &= "'' As OldServiceLife, '' As DepreciatedPeriod, '' As AdjustServiceLife, '' As NewRemainLife, '' As NewServiceLife" & vbCrLf
        'sSQL &= "FROM " & SQLUDFD02N0019() & " N19" & vbCrLf
        'sSQL &= "WHERE N19.IsCompleted = 1 And N19.Disabled = 0" & vbCrLf
        'sSQL &= "AND N19.DivisionID = " & SQLString(gsDivisionID) & " AND N19.TranMonth + N19.TranYear * 100 <= " & giTranMonth + giTranYear * 100 & " AND N19.IsLiquidated = 0" & vbCrLf
        'sSQL &= "Order by N19.AssetID"
        sSQL = SQLStoreD02P5120()
        dtLeft = ReturnDataTable(sSQL)
        dtRight = dtLeft.Clone
        LoadDataSource(tdbgLeft, dtLeft, gbUnicode)
        ReLoadTDBGridLeft()
        ReLoadTDBGridRight()
        FooterText()
        EnableButton()
    End Sub

    'Hiện tại tính nâng tìm kiếm đang dùng theo kiêu cũ, nhưng có thời gian sử

    Private Sub MoveRow(ByVal tdbg1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dt1 As DataTable, ByVal tdbg2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dt2 As DataTable)
        tdbg1.Bookmark = tdbg1.Row

        Dim dr As DataRow
        For Each dr In dt1.Rows
            If dr("AssetID").ToString = tdbg1(tdbg1.Row, COL_AssetID).ToString AndAlso dr("AssetName").ToString = tdbg1(tdbg1.Row, COL_AssetName).ToString Then
                dt2.ImportRow(dr)
                dt1.Rows.Remove(dr)

                LoadDataSource(tdbg1, dt1, gbUnicode)
                LoadDataSource(tdbg2, dt2, gbUnicode)

                Exit For
            End If
        Next
    End Sub

    Private Sub btnToRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToRight.Click
        Dim iBookmarkLeft As Integer = -1
        If tdbgLeft.Bookmark - 1 > 0 Then iBookmarkLeft = tdbgLeft.Bookmark - 1
        CheckbtnView()
        MoveRow(tdbgLeft, dtLeft, tdbgRight, dtRight)
        EnableButton()
        FooterText()

        If iBookmarkLeft > -1 Then tdbgLeft.Bookmark = iBookmarkLeft
    End Sub

    Private Sub btnToLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToLeft.Click
        Dim iBookmarkRight As Integer = -1
        If tdbgRight.Bookmark - 1 > 0 Then iBookmarkRight = tdbgRight.Bookmark - 1

        MoveRow(tdbgRight, dtRight, tdbgLeft, dtLeft)
        EnableButton()
        FooterText()
        CheckbtnView()
        If iBookmarkRight > -1 Then tdbgRight.Bookmark = iBookmarkRight
    End Sub

    Private Sub btnAllToRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAllToRight.Click
        For i As Integer = 0 To tdbgLeft.RowCount - 1
            MoveRow(tdbgLeft, dtLeft, tdbgRight, dtRight)
        Next i
        EnableButton()
        FooterText()

        tdbgRight.Bookmark = 0
        CheckbtnView()
    End Sub

    Private Sub btnAllToLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAllToLeft.Click
        For i As Integer = 0 To tdbgRight.RowCount - 1
            MoveRow(tdbgRight, dtRight, tdbgLeft, dtLeft)
        Next i
        EnableButton()
        FooterText()

        tdbgLeft.Bookmark = 0
        CheckbtnView()
    End Sub

    Private Sub EnableButton()
        btnToLeft.Enabled = tdbgRight.RowCount > 0
        btnAllToLeft.Enabled = tdbgRight.RowCount > 0
        btnToRight.Enabled = tdbgLeft.RowCount > 0
        btnAllToRight.Enabled = tdbgLeft.RowCount > 0
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub



    Private Function AllowSave() As Boolean
        If tdbgRight.RowCount <= 0 Then
            D99C0008.MsgNotYetChoose(rl3("Tai_san"))
            btnToRight.Focus()
            Return False
        End If

        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUDFD02N0019
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/03/2011 03:58:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUDFD02N0019() As String
        Dim sSQL As String = ""
        sSQL &= "D02N0019("
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    Private Sub btnNextD09F2130_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextD09F2130.Click
        If AllowSave() = False Then Exit Sub
        tdbgRight.UpdateData()
        dtData = CType(tdbgRight.DataSource, DataTable)
        gbSavedOK = True
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5120
    '# Created User: HUỲNH KHANH
    '# Created Date: 26/02/2016 10:43:40
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5120() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi trai" & vbCrlf)
        sSQL &= "Exec D02P5120 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsStopDepre.Checked) & COMMA 'IsStopDepre, tinyint, NOT NULL
        sSQL &= SQLString(tdbcEffectReasonID.Text) & COMMA 'EffectReasonID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcManagementObjectTypeID)) & COMMA 'ManagementObjTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcManagementObjectID)) & COMMA 'ManagementObjID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcObjectTypeID)) & COMMA 'ObjectTypeID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcObjectID)) & COMMA 'ObjectID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcEmployeeID)) 'ReceiverID, varchar[50], NOT NULL
        Return sSQL
    End Function

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Dim f As New D02F2003_Frame1
        With f
            .AssetID = tdbgLeft.Columns(COL_AssetID).Text
            .AssetName = tdbgLeft.Columns(COL_AssetName).Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub chkIsStopDepre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsStopDepre.Click
        If chkIsStopDepre.Checked Then
            tdbcEffectReasonID.Enabled = True
        Else
            tdbcEffectReasonID.Enabled = False
        End If
        'LoadTDBGridLeft()
    End Sub

    Private Sub CheckbtnView()
        btnView.Enabled = tdbgLeft.RowCount > 0
    End Sub

    Private Sub tdbcEffectReasonID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEffectReasonID.SelectedValueChanged
        'LoadTDBGridLeft()
    End Sub

    Private Sub tdbgLeft_LockedColumns()
        tdbgLeft.Splits(SPLIT0).DisplayColumns(COL_AssetID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgLeft.Splits(SPLIT0).DisplayColumns(COL_AssetName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgLeft.Splits(SPLIT0).DisplayColumns(COL_D27PropertyProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbgRight_LockedColumns()
        tdbgRight.Splits(SPLIT0).DisplayColumns(COL1_AssetID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgRight.Splits(SPLIT0).DisplayColumns(COL1_AssetName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgRight.Splits(SPLIT0).DisplayColumns(COL1_D27PropertyProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbgRight_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgRight.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL1_AssetID
            Case COL1_AssetName
            Case COL1_D27PropertyProductID
            Case COL1_AssetConditionID
                If tdbgRight.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgRight.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    tdbgRight.Columns(COL1_AssetConditionName).Text = ""
                    Exit Select
                End If
                tdbgRight.Columns(COL1_AssetConditionName).Text = tdbdAssetConditionalID.Columns("AssetConditionName").Text

        End Select
    End Sub


#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Private sFindLeft As String = ""
    Private sFindRight As String = ""
    Dim dtCaptionCols As DataTable
    'DLL sử dụng Properties
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            If bLeftFocus Then
                sFindLeft = Value
                ReLoadTDBGridLeft() 'Giống sự kiện Finder_FindClick
            Else
                sFindRight = Value
                ReLoadTDBGridRight() 'Giống sự kiện Finder_FindClick
            End If

        End Set
    End Property

    Dim bLeftFocus As Boolean = False
    '*****************************
    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        If tdbgLeft.Focused Then
            tdbgLeft.UpdateData()
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbgLeft.Splits.Count - 1
                AddColVisible(tdbgLeft, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbgLeft, Arr)
            bLeftFocus = True
        Else
            tdbgRight.UpdateData()
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbgRight.Splits.Count - 1
                AddColVisible(tdbgRight, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbgRight, Arr)
            bLeftFocus = False
        End If

        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        If bLeftFocus Then
            sFindLeft = ""
            ResetFilter(tdbgLeft, sFilter, bRefreshFilter)
            ReLoadTDBGridLeft()
        Else
            sFindRight = ""
            ResetFilter(tdbgRight, sFilter, bRefreshFilter)
            ReLoadTDBGridRight()
        End If
    End Sub

    Private Sub ReLoadTDBGridLeft()
        Dim strFind As String = sFindLeft
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtLeft.DefaultView.RowFilter = strFind
        FooterText()
        EnableButton()
        CheckMenu(Me.Name, ContextMenuStrip1, tdbgLeft.RowCount, gbEnabledUseFind)

    End Sub

    Private Sub ReLoadTDBGridRight()
        Dim strFind As String = sFindRight
        dtRight.DefaultView.RowFilter = strFind
        FooterText()
        EnableButton()
        CheckMenu(Me.Name, ContextMenuStrip1, tdbgRight.RowCount, gbEnabledUseFind)
    End Sub


    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbgLeft_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgLeft.FilterChange
        Try
            If (dtLeft Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbgLeft, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGridLeft()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgLeft_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgLeft.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbgLeft, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbgLeft_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgLeft.KeyPress
        If tdbgLeft.Columns(tdbgLeft.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbgLeft.Splits(tdbgLeft.SplitIndex).DisplayColumns(tdbgLeft.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

#End Region

    '#Region "Active Find Client - List All "
    '    Private WithEvents Finder As New D99C1001
    '    Private sFind As String = ""

    '    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
    '        If Not CallMenuFromGrid(tdbgLeft, e) Then Exit Sub
    '        gbEnabledUseFind = True
    '        Dim arr As New ArrayList

    '        If tdbgLeft.Focused Then
    '            AddColVisible(tdbgLeft, SPLIT0, arr, , , , gbUnicode)
    '            Dim dtCaptionCols As DataTable
    '            dtCaptionCols = CreateTableForExcel(tdbgLeft, arr)
    '            ResetTableForExcel(tdbgLeft, dtCaptionCols)
    '            ShowFindDialogClient(Finder, dtCaptionCols, Me.Name, "0", gbUnicode)
    '        Else
    '            AddColVisible(tdbgRight, SPLIT0, arr, , , , gbUnicode)
    '            Dim dtCaptionCols As DataTable
    '            dtCaptionCols = CreateTableForExcel(tdbgRight, arr)
    '            ResetTableForExcel(tdbgRight, dtCaptionCols)
    '            ShowFindDialogClient(Finder, dtCaptionCols, Me.Name, "0", gbUnicode)
    '        End If

    '    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    '    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
    '        If Not CallMenuFromGrid(tdbgLeft, e) Then Exit Sub
    '        sFind = ""
    '        ReLoadTDBGrid()
    '    End Sub

    '    Private Sub ReLoadTDBGrid()
    '        If tdbgLeft.Focused Then
    '            LoadGridFind(tdbgLeft, dtLeft, sFind)
    '            CheckMenu(Me.Text, C1CommandHolder, tdbgLeft.RowCount, gbEnabledUseFind, False)
    '        Else
    '            LoadGridFind(tdbgRight, dtRight, sFind)
    '            CheckMenu(Me.Text, C1CommandHolder, tdbgLeft.RowCount, gbEnabledUseFind, False)
    '        End If

    '    End Sub


    '#End Region

    Private Sub tdbgLeft_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgLeft.MouseDown
        CheckMenu(Me.Name, ContextMenuStrip1, tdbgLeft.RowCount, gbEnabledUseFind)
        bLeftFocus = True
    End Sub

    Private Sub tdbgRight_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgRight.MouseDown
        CheckMenu(Me.Name, ContextMenuStrip1, tdbgRight.RowCount, gbEnabledUseFind)
        bLeftFocus = False
    End Sub

#Region "Events tdbcManagementObjectTypeID load tdbcObjectID2 with tdbcManagementObjectID"

    Private Sub tdbcManagementObjectTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcManagementObjectTypeID.SelectedValueChanged
        'Bổ sung đoạn code sau:
        Dim sObjectID As String = ""
        If bLoadObectID = False Then sObjectID = ReturnValueC1Combo(tdbcManagementObjectID)
        Dim sObjectTypeID As String = ReturnValueC1Combo(tdbcManagementObjectTypeID)
        tdbcManagementObjectID.Splits(0).DisplayColumns("ObjectTypeID").Visible = (sObjectTypeID = "" Or sObjectTypeID = "-1") 'Xử lý cho dạng cũ
        oFilterCombo.LoadtdbcObjectID(tdbcManagementObjectID, dtObjectID, sObjectTypeID)
        If bLoadObectID = False Then tdbcManagementObjectID.SelectedValue = sObjectID : Exit Sub
        tdbcManagementObjectID.Text = ""
        txtManagementObjectName.Text = ""
    End Sub

    Private Sub tdbcManagementObjectTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcManagementObjectTypeID.LostFocus
        If tdbcManagementObjectTypeID.FindStringExact(tdbcManagementObjectTypeID.Text) = -1 OrElse tdbcManagementObjectTypeID.SelectedValue Is Nothing Then
            Dim sObjectTypeID As String = ReturnValueC1Combo(tdbcManagementObjectTypeID)
            oFilterCombo.LoadtdbcObjectID(tdbcManagementObjectID, dtObjectID, sObjectTypeID)
            tdbcManagementObjectID.Text = ""
            txtManagementObjectName.Text = ""
        End If
        'LoadTDBGridLeft()
    End Sub

    Private bLoadObectID As Boolean = True
    Private Sub tdbcManagementObjectID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcManagementObjectID.Validated
        oFilterCombo.FilterCombo(tdbcManagementObjectID, e)
        If tdbcManagementObjectID.FindStringExact(tdbcManagementObjectID.Text) = -1 OrElse tdbcManagementObjectID.SelectedValue Is Nothing Then
            tdbcManagementObjectID.Text = ""
            txtManagementObjectName.Text = ""
        Else
            txtManagementObjectName.Text = tdbcManagementObjectID.Columns(2).Value.ToString
        End If
        If Not oFilterCombo.IsNewFilter AndAlso tdbcManagementObjectID.Splits(0).DisplayColumns("ObjectTypeID").Visible Then
            bLoadObectID = False 'Chặn không cho Load lại Combo Loại ĐT
            tdbcManagementObjectTypeID.SelectedValue = ReturnValueC1Combo(tdbcManagementObjectID, "ObjectTypeID")
        End If

        bLoadObectID = True
        'LoadTDBGridLeft()
    End Sub

    Private Sub tdbcManagementObjectID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcManagementObjectID.SelectedValueChanged
        'If tdbcManagementObjectID.SelectedValue Is Nothing Then
        '    tdbcManagementObjectID.Text = ""
        'Else
        '    txtManagementObjectName.Text = tdbcManagementObjectID.Columns(2).Value.ToString
        'End If
    End Sub

    'Private Sub LoadtdbcObjectID(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal ID As String)
    '    LoadDataSource(tdbc, ReturnTableFilter(dtObjectID, "ObjectTypeID = " & SQLString(ID), True), gbUnicode)
    'End Sub
    'Private Sub tdbcManagementObjectID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcManagementObjectID.KeyDown
    '    If oFilterCombo.IsNewFilter Then
    '        Exit Sub ' TH filter dạng mới thì F2 gọi D99F5555 đã có sẵn
    '    End If
    'End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        'If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        LoadTDBGridLeft()
        Me.Cursor = Cursors.Default
    End Sub


#End Region

#Region "Events tdbcObjectTypeI2 load tdbcObjectID2 with txtObjectName"

    Private Sub tdbcObjectTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.SelectedValueChanged
        'Bổ sung đoạn code sau:
        Dim sObjectID As String = ""
        If bLoadObjectID = False Then sObjectID = ReturnValueC1Combo(tdbcObjectID)
        Dim sObjectTypeID As String = ReturnValueC1Combo(tdbcObjectTypeID)
        tdbcObjectID.Splits(0).DisplayColumns("ObjectTypeID").Visible = (sObjectTypeID = "" Or sObjectTypeID = "-1") 'Xử lý cho dạng cũ
        oFilterCombo.LoadtdbcObjectID(tdbcObjectID, dtObjectID, sObjectTypeID)
        If bLoadObjectID = False Then tdbcObjectID.SelectedValue = sObjectID : Exit Sub
        tdbcObjectID.Text = ""
        txtObjectName.Text = ""
    End Sub

    Private Sub tdbcObjectTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.LostFocus
        If tdbcObjectTypeID.FindStringExact(tdbcObjectTypeID.Text) = -1 OrElse tdbcObjectTypeID.SelectedValue Is Nothing Then
            Dim sObjectTypeID As String = ReturnValueC1Combo(tdbcObjectTypeID)
            oFilterCombo.LoadtdbcObjectID(tdbcObjectID, dtObjectID, sObjectTypeID)
            tdbcObjectID.Text = ""
            txtObjectName.Text = ""
        End If
    End Sub

    Private bLoadObjectID As Boolean = True
    Private Sub tdbcObjectID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.Validated
        oFilterCombo.FilterCombo(tdbcObjectID, e)
        If tdbcObjectID.FindStringExact(tdbcObjectID.Text) = -1 OrElse tdbcObjectID.SelectedValue Is Nothing Then
            tdbcObjectID.Text = ""
            txtObjectName.Text = ""
        Else
            txtObjectName.Text = tdbcObjectID.Columns(2).Value.ToString
        End If
        If Not oFilterCombo.IsNewFilter AndAlso tdbcObjectID.Splits(0).DisplayColumns("ObjectTypeID").Visible Then
            bLoadObjectID = False
            tdbcObjectTypeID.SelectedValue = ReturnValueC1Combo(tdbcObjectID, "ObjectTypeID")
        End If
        bLoadObjectID = True
    End Sub
#End Region

#Region "Events tdbcEmployeeID with txtEmployeeName"

    Private Sub tdbcEmployeeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.Close
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then
            tdbcEmployeeID.Text = ""
            txtEmployeeName.Text = ""
        End If
    End Sub

    Private Sub tdbcEmployeeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.SelectedValueChanged
        txtEmployeeName.Text = tdbcEmployeeID.Columns(1).Value.ToString
    End Sub
#End Region


End Class