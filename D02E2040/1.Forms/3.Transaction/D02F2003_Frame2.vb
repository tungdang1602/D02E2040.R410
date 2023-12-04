Public Class D02F2003_Frame2


#Region "Const of tdbg - Total of Columns: 7"
    Private Const COL_AssetID As Integer = 0           ' Mã tài sản
    Private Const COL_AssetName As Integer = 1         ' Tên tài sản
    Private Const COL_OldServiceLife As Integer = 2    ' TG sử dụng cũ
    Private Const COL_DepreciatedPeriod As Integer = 3 ' TG đã sử dụng
    Private Const COL_AdjustServiceLife As Integer = 4 ' TG sử dụng mới
    Private Const COL_NewRemainLife As Integer = 5     ' TG còn lại mới
    Private Const COL_NewServiceLife As Integer = 6    ' TG sử dụng cần thay đổi
#End Region

    Public dtData As DataTable

    Private Sub D02F2003_Frame2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        If dtData IsNot Nothing Then
            LoadDataSource(tdbg, dtData, gbUnicode)
        End If
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        lblChangeTime.Text = rl3("Thay_doi_thoi_gian_khau_hao_cho_nhieu_tai_san") 'Thay đổi thời gian khấu hao cho nhiều tài sản
        '================================================================ 
        btnCalculate.Text = rl3("Tin_h") 'Tín&h
        btnContinue.Text = rl3("_Tiep_tuc") '&Tiếp tục
        '================================================================ 
        tdbg.Columns("AssetID").Caption = rl3("Ma_tai_san") 'Mã tài sản
        tdbg.Columns("OldServiceLife").Caption = rl3("TG_su_dung_cu") 'TG sử dụng cũ
        tdbg.Columns("DepreciatedPeriod").Caption = rl3("TG_da_su_dung") 'TG đã sử dụng
        tdbg.Columns("AdjustServiceLife").Caption = rl3("TG_su_dung_moi") 'TG sử dụng mới
        tdbg.Columns("NewRemainLife").Caption = rl3("TG_con_lai_moi") 'TG còn lại mới
        tdbg.Columns("NewServiceLife").Caption = rL3("TG_su_dung_can_thay_doi") 'TG sử dụng cần thay đổi
        '================================================================ 
        tdbg.Columns(COL_AssetName).Caption = rL3("Ten_tai_san") 'Tên tài sản

    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AssetID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OldServiceLife).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepreciatedPeriod).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_NewRemainLife).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_NewServiceLife).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OldServiceLife).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_DepreciatedPeriod).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_AdjustServiceLife).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_NewRemainLife).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_NewServiceLife).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_OldServiceLife
                If Not L3IsNumeric(tdbg.Columns(COL_OldServiceLife).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_DepreciatedPeriod
                If Not L3IsNumeric(tdbg.Columns(COL_DepreciatedPeriod).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_AdjustServiceLife
                If Not L3IsNumeric(tdbg.Columns(COL_AdjustServiceLife).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_NewRemainLife
                If Not L3IsNumeric(tdbg.Columns(COL_NewRemainLife).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_NewServiceLife
                If Not L3IsNumeric(tdbg.Columns(COL_NewServiceLife).Text, EnumDataType.Money) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_OldServiceLife
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_DepreciatedPeriod
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_AdjustServiceLife
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NewRemainLife
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_NewServiceLife
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_AdjustServiceLife).ToString = "" Then
                D99C0008.MsgNotYetEnter("TG sử dụng mới")
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_AdjustServiceLife
                tdbg.Bookmark = i
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        If Not AllowSave() Then Exit Sub
        Calculation()
    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: Calculation
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 11/03/2011 09:50:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Sub Calculation()
        Dim sSQL As String
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL = ""
            sSQL &= "Exec D02P2003 "
            sSQL &= SQLString(tdbg(i, COL_AssetID)) & COMMA 'AssetID, varchar[20], NOT NULL
            sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
            sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
            sSQL &= SQLNumber(tdbg(i, COL_AdjustServiceLife)) & COMMA 'AdjustServiceLife, int, NOT NULL
            sSQL &= SQLString("") 'BatchID, varchar[20], NOT NULL

            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                tdbg(i, COL_OldServiceLife) = dt.Rows(0).Item("OldServiceLife").ToString
                tdbg(i, COL_DepreciatedPeriod) = dt.Rows(0).Item("DepreciatedPeriod").ToString
                tdbg(i, COL_NewRemainLife) = dt.Rows(0).Item("NewRemainLife").ToString
                tdbg(i, COL_NewServiceLife) = dt.Rows(0).Item("NewServiceLife").ToString
            End If
        Next
        tdbg.UpdateData()
    End Sub


End Class