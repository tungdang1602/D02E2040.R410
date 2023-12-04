Imports System
Public Class D02F2012
    Dim bHeadClick As Boolean = True
    Dim bUseAna As Boolean
    Dim iLastCol As Integer = -1
    Dim dtGrid As DataTable
    Public dtF2012 As DataTable

#Region "Const of tdbg"
    Private Const COL_TransactionID As Integer = 0    ' TransactionID
    Private Const COL_ModuleID As Integer = 1         ' ModuleID
    Private Const COL_Choose As Integer = 2           ' Chọn
    Private Const COL_VoucherID As Integer = 3        ' Số phiếu
    Private Const COL_VoucherDate As Integer = 4      ' Ngày phiếu
    Private Const COL_RefNo As Integer = 5            ' Số hóa đơn
    Private Const COL_RefDate As Integer = 6          ' Ngày hóa đơn
    Private Const COL_SerialNo As Integer = 7         ' Số Sêri
    Private Const COL_ItemName As Integer = 8         ' Diễn giải
    Private Const COL_CurrencyID As Integer = 9       ' Loại tiền
    Private Const COL_ExchangeRate As Integer = 10    ' Tỷ giá
    Private Const COL_OriginalAmount As Integer = 11  ' Nguyên tệ
    Private Const COL_ConvertedAmount As Integer = 12 ' Quy đổi
    Private Const COL_ObjectTypeID As Integer = 13    ' Loại ĐT
    Private Const COL_ObjectID As Integer = 14        ' Đối tượng
    Private Const COL_Ana01ID As Integer = 15         ' Ana01ID
    Private Const COL_Ana02ID As Integer = 16         ' Ana02ID
    Private Const COL_Ana03ID As Integer = 17         ' Ana03ID
    Private Const COL_Ana04ID As Integer = 18         ' Ana04ID
    Private Const COL_Ana05ID As Integer = 19         ' Ana05ID
    Private Const COL_Ana06ID As Integer = 20         ' Ana06ID
    Private Const COL_Ana07ID As Integer = 21         ' Ana07ID
    Private Const COL_Ana08ID As Integer = 22         ' Ana08ID
    Private Const COL_Ana09ID As Integer = 23         ' Ana09ID
    Private Const COL_Ana10ID As Integer = 24         ' Ana10ID
#End Region

    Private _assetID As String = ""
    Public Property AssetID() As String
        Get
            Return _assetID
        End Get
        Set(ByVal Value As String)
            _assetID = Value
        End Set
    End Property

    Private _assetAccountID As String
    Public WriteOnly Property AssetAccountID() As String
        Set(ByVal Value As String)
            _assetAccountID = Value
        End Set
    End Property

    Private _depAccountID As String
    Public WriteOnly Property DepAccountID() As String
        Set(ByVal Value As String)
            _depAccountID = Value
        End Set
    End Property

    Private Sub D02F2008_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D02F2008_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        '--- Chuẩn Khoản mục b2: Lấy caption cho 10 khoản mục va quy cach
        bUseAna = LoadTDBGridAnalysisCaption(D02, tdbg, COL_Ana01ID, 2, , gbUnicode)
        If bUseAna = False Then
            tdbg.RemoveHorizontalSplit(2)
        Else
            iLastCol = CountCol(tdbg, 2)
        End If
        '***********************************
        CheckIdTextBox(txtVoucherNo)
        CheckIdTextBox(txtAccountID)
        Loadlanguage()
        ResetSplitDividerSize(tdbg)
        InputbyUnicode(Me, gbUnicode)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadTDBCombo()
        LoadDefault()
        '***********************************
        InputbyUnicode(Me, gbUnicode)
        '***********************************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_phieu_ke_thua_-_D02F2012") & UnicodeCaption(gbUnicode) 'Chãn phiÕu kÕ thôa - D02F2012
        '================================================================ 
        lblPeriod.Text = rl3("Ky") 'Kỳ
        lblVoucherNo.Text = rl3("So_phieu_co_chua") 'Số phiếu có chứa
        lblAccountID.Text = rl3("Tai_khoan_co_chua") 'Tài khoản có chứa
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnInherit.Text = rl3("_Ke_thua") '&Kế thừa
        btnFilter.Text = rl3("Loc") 'Lọc
        '================================================================ 
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        '================================================================ 
        tdbg.Columns("Choose").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("VoucherID").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("RefNo").Caption = rl3("So_hoa_don") 'Số hóa đơn
        tdbg.Columns("RefDate").Caption = rl3("Ngay_hoa_don") 'Ngày hóa đơn
        tdbg.Columns("SerialNo").Caption = rl3("So_Seri") 'Số Sêri
        tdbg.Columns("ItemName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("CurrencyID").Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns("ExchangeRate").Caption = rl3("Ty_gia") 'Tỷ giá
        tdbg.Columns("OriginalAmount").Caption = rl3("Nguyen_te") 'Nguyên tệ
        tdbg.Columns("ConvertedAmount").Caption = rl3("Quy_doi") 'Quy đổi
        tdbg.Columns("ObjectTypeID").Caption = rl3("Loai_DT") 'Loại ĐT
        tdbg.Columns("ObjectID").Caption = rl3("Doi_tuong") 'Đối tượng
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_VoucherID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_VoucherDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RefNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RefDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SerialNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ItemName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CurrencyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ExchangeRate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OriginalAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ConvertedAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectTypeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana01ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana02ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana03ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana04ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana05ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana06ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana07ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana08ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana09ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana10ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ExchangeRate).NumberFormat = DxxFormat.ExchangeRateDecimals
        tdbg.Columns(COL_OriginalAmount).NumberFormat = DxxFormat.DecimalPlaces
        tdbg.Columns(COL_ConvertedAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
    End Sub

    Private Sub LoadDefault()
        '******************************
        tdbcPeriodFrom.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcPeriodTo.Text = giTranMonth.ToString("00") & "/" & giTranYear
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D02")
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD02P2011()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcPeriodFrom.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tu_ky"))
            tdbcPeriodFrom.Focus()
            Return False
        End If

        If tdbcPeriodTo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Den_ky"))
            tdbcPeriodTo.Focus()
            Return False
        End If

        If L3Int(tdbcPeriodFrom.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodFrom.Columns("TranMonth").Text) > L3Int(tdbcPeriodTo.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodTo.Columns("TranMonth").Text) Then
            D99C0008.MsgL3(rL3("Ky_tu_khong_duoc_lon_hon_ky_den"))
            tdbcPeriodTo.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If AllowFilter() = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub


#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.LostFocus
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.LostFocus
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

#End Region

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If bUseAna = False Then
                    If tdbg.Col = COL_Choose Then HotKeyEnterGrid(tdbg, COL_Choose, e, 1)
                Else
                    If tdbg.Col = iLastCol Then HotKeyEnterGrid(tdbg, COL_Choose, e, 1)
                End If
                Exit Sub
            End If

            HotKeyDownGrid(e, tdbg, COL_Choose, 0, tdbg.Splits.Count - 1)
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_Choose
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_Choose) = bHeadClick
                Next
                tdbg.UpdateData()
                bHeadClick = Not bHeadClick
            Case Else
                HeadClickTask(e.ColIndex)
        End Select
    End Sub

    Private Sub HeadClickTask(ByVal iCol As Integer)
        If iCol = COL_Choose Then Exit Sub

        tdbg.Col = iCol
        If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
            CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim dr() As DataRow = dtGrid.Select("Choose=1")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = 0
            tdbg.Col = COL_Choose
            tdbg.Bookmark = 0
            Return False
        End If
        Return True
    End Function

    Private Sub btnInherit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInherit.Click
        If AllowSave() = False Then Exit Sub

        dtF2012 = ReturnTableFilter(dtGrid, "Choose=1", True)

        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2011
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 10/03/2011 02:26:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2011() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P2011 "
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'FromTranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'FromTranYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'ToTranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'ToTranYear, int, NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_assetID) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(txtAccountID.Text) & COMMA 'AccountID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth = 13) & COMMA 'FilterAdjPeriod, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_assetAccountID) & COMMA 'AssetAccountID, varchar[50], NOT NULL
        sSQL &= SQLString(_depAccountID) 'DepAccountID, varchar[50], NOT NULL
        Return sSQL
    End Function
End Class

