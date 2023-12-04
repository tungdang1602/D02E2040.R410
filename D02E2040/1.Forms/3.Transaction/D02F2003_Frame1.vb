Imports System
Public Class D02F2003_Frame1


#Region "Const of tdbg"
    Private Const COL_SourceID As Integer = 0     ' Mã nguồn
    Private Const COL_SourceName As Integer = 1   ' Tên nguồn
    Private Const COL_SourceAmount As Integer = 2 ' Số tiền
    Private Const COL_SourceRate As Integer = 3   ' Tỷ lệ
#End Region

    Private _assetID As String = ""
    Public Property AssetID() As String 
        Get
            Return _assetID
        End Get
        Set(ByVal Value As String )
            _assetID = Value
        End Set
    End Property

    Private _assetName As String = ""
    Public Property AssetName() As String 
        Get
            Return _assetName
        End Get
        Set(ByVal Value As String )
            _assetName = Value
        End Set
    End Property

    Private Sub D02F2003_Frame1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub D02F2003_Frame1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Loadlanguage()
        ResetColorGrid(tdbg)
        tdbg_NumberFormat()
        '**************************
        InputbyUnicode(Me, gbUnicode)
        lblAssetName.Font = FontUnicode(gbUnicode)
        lblObjectName.Font = FontUnicode(gbUnicode)
        '**************************
        lblAssetID.Text = _assetID
        lblAssetName.Text = _assetName

        Dim dt As DataTable = ReturnDataTable(SQLStoreD02P0520)
        If dt.Rows.Count > 0 Then
            lblConvertedAmount.Text = SQLNumber(dt.Rows(0).Item("ConvertedAmount"), DxxFormat.D90_ConvertedDecimals)
            lblAmountDepreciation.Text = SQLNumber(dt.Rows(0).Item("AmountDepreciation"), DxxFormat.D90_ConvertedDecimals)
            lblRemainAmount.Text = SQLNumber(dt.Rows(0).Item("RemainAmount"), DxxFormat.D90_ConvertedDecimals)

            lblAssetAccountID.Text = dt.Rows(0).Item("AssetAccountID").ToString
            lblDepAccountID.Text = dt.Rows(0).Item("DepAccountID").ToString
            lblObjectName.Text = dt.Rows(0).Item("ObjectName").ToString
            lblManagementObjNameValue.Text = dt.Rows(0).Item("ManagementObjName").ToString
            chkIspledgedD23.Checked = L3Bool(dt.Rows(0).Item("IspledgedD23").ToString)
            LoadDataSource(tdbg, dt, gbUnicode)
        End If
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        lblObjectNameFrame.Text = rL3("Bo_phan_tiep_nhan")
        lblManagementObjName.Text = rL3("Bo_phan_quan_lyU")
        lblDepAccountIDFrame.Text = rl3("TK") 'TK:
        lblAssetAccountIDFrame.Text = rl3("TK") 'TK:
        lblRemainAmountFrame.Text = rl3("Gia_tri_con_lai") 'Giá trị còn lại
        lblAmountDepreciationFrame.Text = rl3("Hao_mon_luy_ke") 'Hao mòn lũy kế
        lblConvertedAmountFrame.Text = rl3("Nguyen_te") 'Nguyên tệ
        lblAssetInfomation.Text = rl3("Thong_tin_ve_tai_san") 'Thông tin về tài sản
        '================================================================ 
        grpCapital.Text = rl3("Nguon_von") 'Nguồn vốn
        '================================================================ 
        tdbg.Columns("SourceID").Caption = rl3("Ma_nguon") 'Mã nguồn
        tdbg.Columns("SourceName").Caption = rl3("Ten_nguon") 'Tên nguồn
        tdbg.Columns("SourceAmount").Caption = rl3("So_tien") 'Số tiền
        tdbg.Columns("SourceRate").Caption = rL3("Ty_le") 'Tỷ lệ
        chkIspledgedD23.Text = rL3("Trang_thai_the_chap")
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_SourceAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_SourceRate).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0520
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 11/03/2011 09:14:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0520() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0520 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_assetID) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub chkIspledgedD23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIspledgedD23.Click
        If Not chkIspledgedD23.Checked Then
            chkIspledgedD23.Checked = True
        Else
            chkIspledgedD23.Checked = False
        End If
    End Sub

  
End Class