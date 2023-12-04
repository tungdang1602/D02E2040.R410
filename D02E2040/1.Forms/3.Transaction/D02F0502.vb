Imports System
Public Class D02F0502

    Private _continueOK As Boolean = False
    Public ReadOnly Property  ContinueOK() As Boolean 
        Get
            Return _continueOK
        End Get
    End Property
    Private Sub D02F0502_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chuyen_but_toan_khau_hao_-_D02F0502") & UnicodeCaption(gbUnicode) 'ChuyÓn bòt toÀn khÊu hao - D02F0502
        '================================================================ 
        btnContinue.Text = rl3("_Tiep_tuc") '&Tiếp tục
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        optTotal.Text = rl3("So_tong_cong") 'Số tổng cộng
        optSingle.Text = rl3("Tung_but_toan") 'Từng bút toán
        '================================================================ 
    End Sub

    Private Sub D02F0502_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        'ID 87756 07.06.2016
        If Not CheckStore(SQLStoreD02P0507) Then Exit Sub
        Dim bRun As Boolean = ExecuteSQL(SQLStoreD02P0502)
        'Dim Desc1 As String = rl3("Chuyen_but_toan_khau_hao") & Space(1) & giTranMonth.ToString("00") & "/" & giTranMonth
        If bRun Then
            'ExecuteAuditLog("DepAllo", "01", Desc1)
            Lemon3.D91.RunAuditLog("02", "DepAllo", "01", IIf(gbUnicode = False, ConvertUnicodeToVni(rL3("Chuyen_but_toan_khau_hao")), rL3("Chuyen_but_toan_khau_hao")).ToString & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear)
            D99C0008.MsgL3(rL3("Chuyen_but_toan_khau_hao_thanh_cong"))
            _continueOK = True
            btnClose_Click(Nothing, Nothing)
        Else
            D99C0008.MsgL3(rL3("Khong_thanh_cong"))
        End If
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0502
    '# Created User: Lê Sơn Long
    '# Created Date: 29/10/2010 10:51:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0502() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0502 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        If optSingle.Checked Then
            sSQL &= SQLString("1") & COMMA 'General, varchar[20], NOT NULL
        Else
            sSQL &= SQLString("2") & COMMA 'General, varchar[20], NOT NULL
        End If
        sSQL &= SQLNumber(gbUnicode)  'TranYear, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0507
    '# Created User: KIM LONG
    '# Created Date: 07/06/2016 03:03:21
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0507() As String
        Dim sSQL As String = ""
        sSQL &= ("-- --Kiem tra phuong phap da dung khi chuyen but toan" & vbCrLf)
        sSQL &= "Exec D02P0507 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostName, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Laguage, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(IIf(optSingle.Checked, "1", "2")) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function



    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class