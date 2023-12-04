Imports System
Public Class D02F2008
    Dim bHeadClick As Boolean = True
    Dim bUseAna As Boolean
    Dim iLastCol As Integer = -1
    Dim dtGrid As DataTable
    Public dtF2008 As DataTable

#Region "Const of tdbg - Total of Columns: 28"
    Private Const COL_TransactionID As Integer = 0    ' TransactionID
    Private Const COL_ModuleID As Integer = 1         ' ModuleID
    Private Const COL_Choose As Integer = 2           ' Chọn
    Private Const COL_VoucherNo As Integer = 3        ' Số phiếu
    Private Const COL_SeriNo As Integer = 4           ' Số Sêri
    Private Const COL_VoucherDate As Integer = 5      ' Ngày phiếu
    Private Const COL_RefNo As Integer = 6            ' Số hóa đơn
    Private Const COL_RefDate As Integer = 7          ' Ngày hóa đơn
    Private Const COL_Description As Integer = 8      ' Diễn giải
    Private Const COL_ObjectTypeID As Integer = 9     ' Loại ĐT
    Private Const COL_ObjectID As Integer = 10        ' Đối tượng
    Private Const COL_ExchangeRate As Integer = 11    ' Tỷ giá
    Private Const COL_DebitAccountID As Integer = 12  ' TK Nợ
    Private Const COL_CreditAccountID As Integer = 13 ' TK Có
    Private Const COL_OriginalAmount As Integer = 14  ' Nguyên tệ
    Private Const COL_ConvertedAmount As Integer = 15 ' Quy đổi
    Private Const COL_SourceID As Integer = 16        ' Nguồn vốn
    Private Const COL_PeriodID As Integer = 17        ' Tập phí
    Private Const COL_Ana01ID As Integer = 18         ' Ana01ID
    Private Const COL_Ana02ID As Integer = 19         ' Ana02ID
    Private Const COL_Ana03ID As Integer = 20         ' Ana03ID
    Private Const COL_Ana04ID As Integer = 21         ' Ana04ID
    Private Const COL_Ana05ID As Integer = 22         ' Ana05ID
    Private Const COL_Ana06ID As Integer = 23         ' Ana06ID
    Private Const COL_Ana07ID As Integer = 24         ' Ana07ID
    Private Const COL_Ana08ID As Integer = 25         ' Ana08ID
    Private Const COL_Ana09ID As Integer = 26         ' Ana09ID
    Private Const COL_Ana10ID As Integer = 27         ' Ana10ID
#End Region


    Private _assetID As String
    Public WriteOnly Property AssetID() As String
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

    Private _ChangeNo As String
    Public WriteOnly Property ChangeNo() As String
        Set(ByVal Value As String)
            _ChangeNo = Value
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
        InputbyUnicode(Me, gbUnicode)
        '***********************************
        Loadlanguage()
        ResetSplitDividerSize(tdbg)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadTDBDropDown()
        LoadTDBGrid()

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_phieu_-_D02F2008") & UnicodeCaption(gbUnicode) 'Danh sÀch phiÕu - D02F2008
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSet.Text = rl3("_Tap_hop") '&Tập hợp
        '================================================================ 
        tdbdAna01ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna01ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna02ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna02ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna03ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna03ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna04ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna04ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna06ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna06ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna07ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna07ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna08ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna08ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna09ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna09ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna10ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna10ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("Choose").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("SeriNo").Caption = rl3("So_Seri") 'Số Sêri
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("RefNo").Caption = rl3("So_hoa_don") 'Số hóa đơn
        tdbg.Columns("RefDate").Caption = rl3("Ngay_hoa_don") 'Ngày hóa đơn
        tdbg.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns("ObjectTypeID").Caption = rl3("Loai_DT") 'Loại ĐT
        tdbg.Columns("ObjectID").Caption = rl3("Doi_tuong") 'Đối tượng
        tdbg.Columns("ExchangeRate").Caption = rl3("Ty_gia") 'Tỷ giá
        tdbg.Columns("DebitAccountID").Caption = rl3("TK_no") 'TK Nợ
        tdbg.Columns("CreditAccountID").Caption = rl3("TK_co") 'TK Có
        tdbg.Columns("OriginalAmount").Caption = rl3("Nguyen_te") 'Nguyên tệ
        tdbg.Columns("ConvertedAmount").Caption = rl3("Quy_doi") 'Quy đổi
        tdbg.Columns("SourceID").Caption = rL3("Nguon_von") 'Nguồn vốn
        '27/4/2020, Phạm Thị Mỹ Tiên:id 120653-Bổ sung tập phí cho nghiệp vụ nhập chứng từ và tác động tài sản
        tdbg.Columns("PeriodID").Caption = rL3("Tap_phi") 'Tập phí
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_VoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SeriNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_VoucherDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RefNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RefDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectTypeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ExchangeRate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DebitAccountID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CreditAccountID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OriginalAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ConvertedAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SourceID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PeriodID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ExchangeRate).NumberFormat = DxxFormat.ExchangeRateDecimals
        tdbg.Columns(COL_OriginalAmount).NumberFormat = DxxFormat.DecimalPlaces
        tdbg.Columns(COL_ConvertedAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
    End Sub

    Private Sub LoadTDBDropDown()
        '--- Chuẩn Khoản mục b3: Load 10 khoản mục
        LoadTDBDropDownAna(tdbdAna01ID, tdbdAna02ID, tdbdAna03ID, tdbdAna04ID, tdbdAna05ID, tdbdAna06ID, tdbdAna07ID, tdbdAna08ID, tdbdAna09ID, tdbdAna10ID, tdbg, COL_Ana01ID, gbUnicode)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD02P5007()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P5007
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 10/03/2011 01:15:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P5007() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P5007 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString("") & COMMA 'strFind, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Check Tap Hop, tinyint, NOT NULL
        sSQL &= SQLString(_assetID) & COMMA 'AssetID, varchar[50], NOT NULL
        sSQL &= SQLString(_assetAccountID) & COMMA 'AssetAccountID, varchar[50], NOT NULL
        sSQL &= SQLString(_depAccountID) & COMMA 'DepAccountID, varchar[20], NOT NULL
        sSQL &= SQLString(_ChangeNo) 'ChangeNo, varchar[50], NOT NULL
        Return sSQL
    End Function

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_Ana01ID
                If tdbg.Columns(COL_Ana01ID).Text <> tdbdAna01ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(0) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana01ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana01ID).Text.Length > giArrAnaLength(0) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana01ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana02ID
                If tdbg.Columns(COL_Ana02ID).Text <> tdbdAna02ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(1) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana02ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana02ID).Text.Length > giArrAnaLength(1) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana02ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana03ID
                If tdbg.Columns(COL_Ana03ID).Text <> tdbdAna03ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(2) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana03ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana03ID).Text.Length > giArrAnaLength(2) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana03ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana04ID
                If tdbg.Columns(COL_Ana04ID).Text <> tdbdAna04ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(3) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana04ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana04ID).Text.Length > giArrAnaLength(3) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana04ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana05ID
                If tdbg.Columns(COL_Ana05ID).Text <> tdbdAna05ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(4) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana05ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana05ID).Text.Length > giArrAnaLength(4) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana05ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana06ID
                If tdbg.Columns(COL_Ana06ID).Text <> tdbdAna06ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(5) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana06ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana06ID).Text.Length > giArrAnaLength(5) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana06ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana07ID
                If tdbg.Columns(COL_Ana07ID).Text <> tdbdAna07ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(6) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana07ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana07ID).Text.Length > giArrAnaLength(6) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana07ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana08ID
                If tdbg.Columns(COL_Ana08ID).Text <> tdbdAna08ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(7) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana08ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana08ID).Text.Length > giArrAnaLength(7) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana08ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana09ID
                If tdbg.Columns(COL_Ana09ID).Text <> tdbdAna09ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(8) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana09ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana09ID).Text.Length > giArrAnaLength(8) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana09ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana10ID
                If tdbg.Columns(COL_Ana10ID).Text <> tdbdAna10ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(9) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana10ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana10ID).Text.Length > giArrAnaLength(9) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana10ID).Text = ""
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If bUseAna = False Then
                    If tdbg.Col = COL_Choose Then HotKeyEnterGrid(tdbg, COL_Choose, e, 1)
                Else
                    If tdbg.Col = iLastCol Then HotKeyEnterGrid(tdbg, COL_Choose, e, 1)
                End If
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 Then
                HotKeyF8(tdbg)
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 Then
                HotKeyF7(tdbg)
                Exit Sub
            ElseIf e.KeyCode = Keys.S And e.Control Then
                HeadClickTask(tdbg.Col)
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
            tdbg.UpdateData()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        If AllowSave() = False Then Exit Sub

        dtF2008 = ReturnTableFilter(dtGrid, "Choose=1", True)
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
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = 0
            tdbg.Col = COL_Choose
            tdbg.Bookmark = 0
            Return False
        End If
        Return True
    End Function


End Class