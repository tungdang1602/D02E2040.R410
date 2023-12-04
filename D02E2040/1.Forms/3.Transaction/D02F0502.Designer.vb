<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F0502
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F0502))
        Me.btnContinue = New System.Windows.Forms.Button
        Me.optTotal = New System.Windows.Forms.RadioButton
        Me.optSingle = New System.Windows.Forms.RadioButton
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(326, 81)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(76, 22)
        Me.btnContinue.TabIndex = 1
        Me.btnContinue.Text = "&Tiếp tục"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'optTotal
        '
        Me.optTotal.AutoSize = True
        Me.optTotal.Location = New System.Drawing.Point(280, 30)
        Me.optTotal.Name = "optTotal"
        Me.optTotal.Size = New System.Drawing.Size(89, 17)
        Me.optTotal.TabIndex = 1
        Me.optTotal.Text = "Số tổng cộng"
        Me.optTotal.UseVisualStyleBackColor = True
        '
        'optSingle
        '
        Me.optSingle.AutoSize = True
        Me.optSingle.Checked = True
        Me.optSingle.Location = New System.Drawing.Point(70, 30)
        Me.optSingle.Name = "optSingle"
        Me.optSingle.Size = New System.Drawing.Size(92, 17)
        Me.optSingle.TabIndex = 0
        Me.optSingle.TabStop = True
        Me.optSingle.Text = "Từng bút toán"
        Me.optSingle.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(408, 81)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optSingle)
        Me.GroupBox1.Controls.Add(Me.optTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'D02F0502
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 110)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F0502"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChuyÓn bòt toÀn khÊu hao - D02F0502"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnContinue As System.Windows.Forms.Button
    Private WithEvents optTotal As System.Windows.Forms.RadioButton
    Private WithEvents optSingle As System.Windows.Forms.RadioButton
    Private WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
