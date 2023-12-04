<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F2003_Frame1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F2003_Frame1))
        Me.pnlAssetInfomation = New System.Windows.Forms.Panel
        Me.chkIspledgedD23 = New System.Windows.Forms.CheckBox
        Me.lblManagementObjNameValue = New System.Windows.Forms.Label
        Me.lblManagementObjName = New System.Windows.Forms.Label
        Me.grpCapital = New System.Windows.Forms.GroupBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.lblObjectName = New System.Windows.Forms.Label
        Me.lblObjectNameFrame = New System.Windows.Forms.Label
        Me.grpLine2 = New System.Windows.Forms.GroupBox
        Me.lblDepAccountID = New System.Windows.Forms.Label
        Me.lblAssetAccountID = New System.Windows.Forms.Label
        Me.lblDepAccountIDFrame = New System.Windows.Forms.Label
        Me.lblAssetAccountIDFrame = New System.Windows.Forms.Label
        Me.lblRemainAmount = New System.Windows.Forms.Label
        Me.lblRemainAmountFrame = New System.Windows.Forms.Label
        Me.lblAmountDepreciation = New System.Windows.Forms.Label
        Me.lblAmountDepreciationFrame = New System.Windows.Forms.Label
        Me.lblConvertedAmount = New System.Windows.Forms.Label
        Me.lblConvertedAmountFrame = New System.Windows.Forms.Label
        Me.grpLine1 = New System.Windows.Forms.GroupBox
        Me.lblAssetName = New System.Windows.Forms.Label
        Me.lblAssetID = New System.Windows.Forms.Label
        Me.lblAssetInfomation = New System.Windows.Forms.Label
        Me.pnlAssetInfomation.SuspendLayout()
        Me.grpCapital.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlAssetInfomation
        '
        Me.pnlAssetInfomation.BackColor = System.Drawing.SystemColors.Control
        Me.pnlAssetInfomation.Controls.Add(Me.chkIspledgedD23)
        Me.pnlAssetInfomation.Controls.Add(Me.lblManagementObjNameValue)
        Me.pnlAssetInfomation.Controls.Add(Me.lblManagementObjName)
        Me.pnlAssetInfomation.Controls.Add(Me.grpCapital)
        Me.pnlAssetInfomation.Controls.Add(Me.lblObjectName)
        Me.pnlAssetInfomation.Controls.Add(Me.lblObjectNameFrame)
        Me.pnlAssetInfomation.Controls.Add(Me.grpLine2)
        Me.pnlAssetInfomation.Controls.Add(Me.lblDepAccountID)
        Me.pnlAssetInfomation.Controls.Add(Me.lblAssetAccountID)
        Me.pnlAssetInfomation.Controls.Add(Me.lblDepAccountIDFrame)
        Me.pnlAssetInfomation.Controls.Add(Me.lblAssetAccountIDFrame)
        Me.pnlAssetInfomation.Controls.Add(Me.lblRemainAmount)
        Me.pnlAssetInfomation.Controls.Add(Me.lblRemainAmountFrame)
        Me.pnlAssetInfomation.Controls.Add(Me.lblAmountDepreciation)
        Me.pnlAssetInfomation.Controls.Add(Me.lblAmountDepreciationFrame)
        Me.pnlAssetInfomation.Controls.Add(Me.lblConvertedAmount)
        Me.pnlAssetInfomation.Controls.Add(Me.lblConvertedAmountFrame)
        Me.pnlAssetInfomation.Controls.Add(Me.grpLine1)
        Me.pnlAssetInfomation.Controls.Add(Me.lblAssetName)
        Me.pnlAssetInfomation.Controls.Add(Me.lblAssetID)
        Me.pnlAssetInfomation.Controls.Add(Me.lblAssetInfomation)
        Me.pnlAssetInfomation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAssetInfomation.Location = New System.Drawing.Point(0, 0)
        Me.pnlAssetInfomation.Name = "pnlAssetInfomation"
        Me.pnlAssetInfomation.Size = New System.Drawing.Size(525, 373)
        Me.pnlAssetInfomation.TabIndex = 31
        '
        'chkIspledgedD23
        '
        Me.chkIspledgedD23.AutoSize = True
        Me.chkIspledgedD23.Location = New System.Drawing.Point(351, 42)
        Me.chkIspledgedD23.Name = "chkIspledgedD23"
        Me.chkIspledgedD23.Size = New System.Drawing.Size(119, 17)
        Me.chkIspledgedD23.TabIndex = 23
        Me.chkIspledgedD23.Text = "Trạng thái thế chấp"
        Me.chkIspledgedD23.UseVisualStyleBackColor = True
        '
        'lblManagementObjNameValue
        '
        Me.lblManagementObjNameValue.AutoSize = True
        Me.lblManagementObjNameValue.Location = New System.Drawing.Point(188, 190)
        Me.lblManagementObjNameValue.Name = "lblManagementObjNameValue"
        Me.lblManagementObjNameValue.Size = New System.Drawing.Size(116, 13)
        Me.lblManagementObjNameValue.TabIndex = 22
        Me.lblManagementObjNameValue.Text = "Management ObjName"
        Me.lblManagementObjNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblManagementObjName
        '
        Me.lblManagementObjName.AutoSize = True
        Me.lblManagementObjName.Location = New System.Drawing.Point(20, 190)
        Me.lblManagementObjName.Name = "lblManagementObjName"
        Me.lblManagementObjName.Size = New System.Drawing.Size(84, 13)
        Me.lblManagementObjName.TabIndex = 21
        Me.lblManagementObjName.Text = "Bộ phận quản lý"
        Me.lblManagementObjName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpCapital
        '
        Me.grpCapital.Controls.Add(Me.tdbg)
        Me.grpCapital.Location = New System.Drawing.Point(6, 212)
        Me.grpCapital.Name = "grpCapital"
        Me.grpCapital.Size = New System.Drawing.Size(510, 156)
        Me.grpCapital.TabIndex = 20
        Me.grpCapital.TabStop = False
        Me.grpCapital.Text = "Nguồn vốn"
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 19)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(497, 131)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 19
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'lblObjectName
        '
        Me.lblObjectName.AutoSize = True
        Me.lblObjectName.Location = New System.Drawing.Point(188, 163)
        Me.lblObjectName.Name = "lblObjectName"
        Me.lblObjectName.Size = New System.Drawing.Size(69, 13)
        Me.lblObjectName.TabIndex = 17
        Me.lblObjectName.Text = "Object Name"
        Me.lblObjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObjectNameFrame
        '
        Me.lblObjectNameFrame.AutoSize = True
        Me.lblObjectNameFrame.Location = New System.Drawing.Point(20, 163)
        Me.lblObjectNameFrame.Name = "lblObjectNameFrame"
        Me.lblObjectNameFrame.Size = New System.Drawing.Size(94, 13)
        Me.lblObjectNameFrame.TabIndex = 16
        Me.lblObjectNameFrame.Text = "Bộ phận tiếp nhận"
        Me.lblObjectNameFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpLine2
        '
        Me.grpLine2.Location = New System.Drawing.Point(3, 148)
        Me.grpLine2.Name = "grpLine2"
        Me.grpLine2.Size = New System.Drawing.Size(519, 5)
        Me.grpLine2.TabIndex = 14
        Me.grpLine2.TabStop = False
        '
        'lblDepAccountID
        '
        Me.lblDepAccountID.AutoSize = True
        Me.lblDepAccountID.Location = New System.Drawing.Point(390, 101)
        Me.lblDepAccountID.Name = "lblDepAccountID"
        Me.lblDepAccountID.Size = New System.Drawing.Size(25, 13)
        Me.lblDepAccountID.TabIndex = 13
        Me.lblDepAccountID.Text = "112"
        Me.lblDepAccountID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAssetAccountID
        '
        Me.lblAssetAccountID.AutoSize = True
        Me.lblAssetAccountID.Location = New System.Drawing.Point(390, 77)
        Me.lblAssetAccountID.Name = "lblAssetAccountID"
        Me.lblAssetAccountID.Size = New System.Drawing.Size(25, 13)
        Me.lblAssetAccountID.TabIndex = 12
        Me.lblAssetAccountID.Text = "111"
        Me.lblAssetAccountID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepAccountIDFrame
        '
        Me.lblDepAccountIDFrame.AutoSize = True
        Me.lblDepAccountIDFrame.Location = New System.Drawing.Point(348, 101)
        Me.lblDepAccountIDFrame.Name = "lblDepAccountIDFrame"
        Me.lblDepAccountIDFrame.Size = New System.Drawing.Size(24, 13)
        Me.lblDepAccountIDFrame.TabIndex = 11
        Me.lblDepAccountIDFrame.Text = "TK:"
        Me.lblDepAccountIDFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAssetAccountIDFrame
        '
        Me.lblAssetAccountIDFrame.AutoSize = True
        Me.lblAssetAccountIDFrame.Location = New System.Drawing.Point(348, 77)
        Me.lblAssetAccountIDFrame.Name = "lblAssetAccountIDFrame"
        Me.lblAssetAccountIDFrame.Size = New System.Drawing.Size(24, 13)
        Me.lblAssetAccountIDFrame.TabIndex = 10
        Me.lblAssetAccountIDFrame.Text = "TK:"
        Me.lblAssetAccountIDFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemainAmount
        '
        Me.lblRemainAmount.AutoSize = True
        Me.lblRemainAmount.Location = New System.Drawing.Point(188, 125)
        Me.lblRemainAmount.Name = "lblRemainAmount"
        Me.lblRemainAmount.Size = New System.Drawing.Size(13, 13)
        Me.lblRemainAmount.TabIndex = 9
        Me.lblRemainAmount.Text = "0"
        Me.lblRemainAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRemainAmountFrame
        '
        Me.lblRemainAmountFrame.AutoSize = True
        Me.lblRemainAmountFrame.Location = New System.Drawing.Point(20, 125)
        Me.lblRemainAmountFrame.Name = "lblRemainAmountFrame"
        Me.lblRemainAmountFrame.Size = New System.Drawing.Size(68, 13)
        Me.lblRemainAmountFrame.TabIndex = 8
        Me.lblRemainAmountFrame.Text = "Giá trị còn lại"
        Me.lblRemainAmountFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAmountDepreciation
        '
        Me.lblAmountDepreciation.AutoSize = True
        Me.lblAmountDepreciation.Location = New System.Drawing.Point(188, 101)
        Me.lblAmountDepreciation.Name = "lblAmountDepreciation"
        Me.lblAmountDepreciation.Size = New System.Drawing.Size(13, 13)
        Me.lblAmountDepreciation.TabIndex = 7
        Me.lblAmountDepreciation.Text = "0"
        Me.lblAmountDepreciation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAmountDepreciationFrame
        '
        Me.lblAmountDepreciationFrame.AutoSize = True
        Me.lblAmountDepreciationFrame.Location = New System.Drawing.Point(20, 101)
        Me.lblAmountDepreciationFrame.Name = "lblAmountDepreciationFrame"
        Me.lblAmountDepreciationFrame.Size = New System.Drawing.Size(81, 13)
        Me.lblAmountDepreciationFrame.TabIndex = 6
        Me.lblAmountDepreciationFrame.Text = "Hao mòn lũy kế"
        Me.lblAmountDepreciationFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConvertedAmount
        '
        Me.lblConvertedAmount.AutoSize = True
        Me.lblConvertedAmount.Location = New System.Drawing.Point(188, 77)
        Me.lblConvertedAmount.Name = "lblConvertedAmount"
        Me.lblConvertedAmount.Size = New System.Drawing.Size(13, 13)
        Me.lblConvertedAmount.TabIndex = 5
        Me.lblConvertedAmount.Text = "0"
        Me.lblConvertedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblConvertedAmountFrame
        '
        Me.lblConvertedAmountFrame.AutoSize = True
        Me.lblConvertedAmountFrame.Location = New System.Drawing.Point(20, 77)
        Me.lblConvertedAmountFrame.Name = "lblConvertedAmountFrame"
        Me.lblConvertedAmountFrame.Size = New System.Drawing.Size(56, 13)
        Me.lblConvertedAmountFrame.TabIndex = 4
        Me.lblConvertedAmountFrame.Text = "Nguyên tệ"
        Me.lblConvertedAmountFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpLine1
        '
        Me.grpLine1.Location = New System.Drawing.Point(3, 62)
        Me.grpLine1.Name = "grpLine1"
        Me.grpLine1.Size = New System.Drawing.Size(519, 5)
        Me.grpLine1.TabIndex = 3
        Me.grpLine1.TabStop = False
        '
        'lblAssetName
        '
        Me.lblAssetName.AutoSize = True
        Me.lblAssetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssetName.Location = New System.Drawing.Point(202, 41)
        Me.lblAssetName.Name = "lblAssetName"
        Me.lblAssetName.Size = New System.Drawing.Size(94, 17)
        Me.lblAssetName.TabIndex = 2
        Me.lblAssetName.Text = "Asset Name"
        Me.lblAssetName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAssetID
        '
        Me.lblAssetID.AutoSize = True
        Me.lblAssetID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssetID.Location = New System.Drawing.Point(20, 41)
        Me.lblAssetID.Name = "lblAssetID"
        Me.lblAssetID.Size = New System.Drawing.Size(63, 17)
        Me.lblAssetID.TabIndex = 1
        Me.lblAssetID.Text = "AssetID"
        Me.lblAssetID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAssetInfomation
        '
        Me.lblAssetInfomation.AutoSize = True
        Me.lblAssetInfomation.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssetInfomation.ForeColor = System.Drawing.Color.Red
        Me.lblAssetInfomation.Location = New System.Drawing.Point(158, 5)
        Me.lblAssetInfomation.Name = "lblAssetInfomation"
        Me.lblAssetInfomation.Size = New System.Drawing.Size(188, 22)
        Me.lblAssetInfomation.TabIndex = 0
        Me.lblAssetInfomation.Text = "Thông tin về tài sản"
        Me.lblAssetInfomation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'D02F2003_Frame1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 373)
        Me.Controls.Add(Me.pnlAssetInfomation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F2003_Frame1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlAssetInfomation.ResumeLayout(False)
        Me.pnlAssetInfomation.PerformLayout()
        Me.grpCapital.ResumeLayout(False)
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pnlAssetInfomation As System.Windows.Forms.Panel
    Private WithEvents lblObjectName As System.Windows.Forms.Label
    Private WithEvents lblObjectNameFrame As System.Windows.Forms.Label
    Private WithEvents grpLine2 As System.Windows.Forms.GroupBox
    Private WithEvents lblDepAccountID As System.Windows.Forms.Label
    Private WithEvents lblAssetAccountID As System.Windows.Forms.Label
    Private WithEvents lblDepAccountIDFrame As System.Windows.Forms.Label
    Private WithEvents lblAssetAccountIDFrame As System.Windows.Forms.Label
    Private WithEvents lblRemainAmount As System.Windows.Forms.Label
    Private WithEvents lblRemainAmountFrame As System.Windows.Forms.Label
    Private WithEvents lblAmountDepreciation As System.Windows.Forms.Label
    Private WithEvents lblAmountDepreciationFrame As System.Windows.Forms.Label
    Private WithEvents lblConvertedAmount As System.Windows.Forms.Label
    Private WithEvents lblConvertedAmountFrame As System.Windows.Forms.Label
    Private WithEvents grpLine1 As System.Windows.Forms.GroupBox
    Private WithEvents lblAssetName As System.Windows.Forms.Label
    Private WithEvents lblAssetID As System.Windows.Forms.Label
    Private WithEvents lblAssetInfomation As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents grpCapital As System.Windows.Forms.GroupBox
    Private WithEvents lblManagementObjName As System.Windows.Forms.Label
    Private WithEvents lblManagementObjNameValue As System.Windows.Forms.Label
    Private WithEvents chkIspledgedD23 As System.Windows.Forms.CheckBox
End Class