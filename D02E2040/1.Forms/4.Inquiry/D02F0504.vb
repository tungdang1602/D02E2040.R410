Public Class D02F0504

    Private _formIDPermission As String = "D02F0504"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

#Region "Const of tdbg - Total of Columns: 5"
    Private Const COL_ChangeNo As Integer = 0    ' Mã nghiệp vụ
    Private Const COL_AssetID As Integer = 1     ' Mã tài sản
    Private Const COL_AssetName As Integer = 2   ' Tên tài sản
    Private Const COL_VoucherNo As Integer = 3   ' Số phiếu
    Private Const COL_VoucherDate As Integer = 4 ' Ngày phiếu
#End Region

    Private dtGrid, dtCaptionCols As DataTable

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Danh_sach_tai_san_khau_hao_da_thanh_ly_trong_ky") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh sªch tªi s¶n kh™u hao ¢º thanh lü trong kî
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnExcel.Text = rl3("Xuat_Excel_") 'Xuất Excel
        '================================================================ 
        tdbg.Columns(COL_ChangeNo).Caption = rl3("Ma_nghiep_vu") 'Mã nghiệp vụ
        tdbg.Columns(COL_AssetID).Caption = rl3("Ma_tai_san") 'Mã tài sản
        tdbg.Columns(COL_AssetName).Caption = rl3("Ten_tai_san") 'Tên tài sản
        tdbg.Columns(COL_VoucherNo).Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns(COL_VoucherDate).Caption = rl3("Ngay_phieu") 'Ngày phiếu
    End Sub



    Private Sub D02F0504_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        gbEnabledUseFind = False
        LoadTDBGrid()
        LoadLanguage()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D02F0504_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt Then
        ElseIf e.Control Then
        Else
            Select Case e.KeyCode
                Case Keys.Enter
                    UseEnterAsTab(Me, True)
                Case Keys.F11
                    HotKeyF11(Me, tdbg)
            End Select
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Dim sFind As String = ""
    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False)
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = SQLStoreD02P0508()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_AssetID)
    End Sub

    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            Dim arrColObligatory() As Integer = {COL_AssetID}
            Dim Arr As New ArrayList
            AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        Dim frm As New D99F2222
        With frm
            .UseUnicode = gbUnicode
            .FormID = Me.Name
            .dtLoadGrid = dtCaptionCols
            .GroupColumns = gsGroupColumns
            .dtExportTable = dtGrid 'Table load dữ liệu cho lưới
            .ShowDialog()
            .Dispose()
        End With
    End Sub


    Dim sFilter As New System.Text.StringBuilder()
    'Dim sFilterServer As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If

    End Sub

    'Lưu ý: gọi hàm ResetFilter(tdbg, sFilter, bRefreshFilter) tại btnFilter_Click và tsbListAll_Click
    'Bổ sung vào đầu sự kiện tdbg_DoubleClick(nếu có) câu lệnh If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0508
    '# Created User: KIM LONG
    '# Created Date: 26/07/2016 05:09:05
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0508() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D02P0508 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gsLanguage) & COMMA 'Language, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'Codetable, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function


End Class