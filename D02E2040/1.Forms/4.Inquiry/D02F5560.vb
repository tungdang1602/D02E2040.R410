Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 01/11/2010 9:01:27 AM
'# Created User: Thiên Huỳnh
'# Modify Date: 01/11/2010 9:01:27 AM
'# Modify User: Thiên Huỳnh
'#-------------------------------------------------------------------------------------
Public Class D02F5560

    Private _batchID As String
    Public WriteOnly Property BatchID() As String
        Set(ByVal Value As String)
            _batchID = Value
        End Set
    End Property

    Private _voucherNo As String
    Public WriteOnly Property VoucherNo() As String
        Set(ByVal Value As String)
            _voucherNo = Value
        End Set
    End Property

    Private _voucherDate As String
    Public WriteOnly Property VoucherDate() As String
        Set(ByVal Value As String)
            _voucherDate = Value
        End Set
    End Property

    Private _notes As String
    Public WriteOnly Property Notes() As String
        Set(ByVal Value As String)
            _notes = Value
        End Set
    End Property

    Private Sub D90F5560_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D90F5560_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gbSavedOK = False
        txtVoucherNo.Text = _voucherNo
        InputbyUnicode(Me, gbUnicode)
        txtDescription.Text = _notes
        Loadlanguage()
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Huy_phieu_F") & " - D02F5560" & UnicodeCaption(gbUnicode) 'Hïy phiÕu - D90F5560
        '================================================================ 
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblDescription.Text = rl3("Dien_giai_phieu") 'Diễn giải phiếu
        '================================================================ 
        btnCancel.Text = rl3("_Huy") '&Hủy
        btnClose.Text = rl3("Do_ng") 'Đó&ng
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If D99C0008.MsgAsk(rl3("MSG000030") & vbCrLf & rl3("MSG000020")) = Windows.Forms.DialogResult.Yes Then
            btnCancel.Enabled = False
            btnClose.Enabled = False
            Dim sSQL As String
            Dim dAmount As Double
            sSQL = "Select Sum(ConvertedAmount) From D02T0012 WITH(NOLOCK) Where BatchID = " & SQLString(_batchID) & vbCrLf
            sSQL &= "And VoucherNo = " & SQLString(_voucherNo) & " And ModuleID = '02' And DivisionID = " & SQLString(gsDivisionID)
            dAmount = Number(ReturnScalar(sSQL))
            sSQL = "Update D02T0012 Set Notes = " & SQLString(txtDescription.Text) & COMMA
            sSQL &= " OriginalAmount = 0, ConvertedAmount = 0, Cancel = 1 " & COMMA
            sSQL &= " LastModifyUserID = " & SQLString(gsUserID) & COMMA
            sSQL &= " LastModifyDate = GetDate()" & vbCrLf
            sSQL &= "Where VoucherNo = " & SQLString(_voucherNo) & " And BatchID = " & SQLString(_batchID) & vbCrLf
            sSQL &= "And ModuleID = '02' And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
            If ExecuteSQL(sSQL) Then
                D99C0008.MsgL3(rl3("Huy_phieu_thanh_cong"))
                gbSavedOK = True
                'ExecuteAuditLog("VoucherCancel02", "09", "Soá phieáu: " & _voucherNo, "Ngaøy phieáu: " & _voucherDate, "Dieãn giaûi: " & txtDescription.Text, "Soá tieàn quy ñoåi: " & dAmount.ToString, "")
                Lemon3.D91.RunAuditLog("02", "VoucherCancel02", "02", IIf(gbUnicode = False, "Soá phieáu", "Số phiếu").ToString & ": " & _voucherNo, _
                                                                      IIf(gbUnicode = False, "Ngaøy phieáu", "Ngày phiếu").ToString & ": " & _voucherDate, _
                                                                      IIf(gbUnicode = False, "Dieãn giaûi", "Diễn giải").ToString & ": " & txtDescription.Text, _
                                                                      IIf(gbUnicode = False, "Soá tieàn quy ñoåi", "Số tiền quy đổi").ToString & ": " & dAmount.ToString)
                Me.Close()
            Else
                D99C0008.MsgL3(rl3("Huy_phieu_khong_thanh_cong"))
                gbSavedOK = False
                btnCancel.Enabled = True
                btnClose.Enabled = True
                btnCancel.Focus()
            End If
        End If
    End Sub

End Class