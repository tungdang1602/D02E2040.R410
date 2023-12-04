<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F0503
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F0503))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtVoucherNo = New System.Windows.Forms.TextBox()
        Me.lblVoucherNo = New System.Windows.Forms.Label()
        Me.c1dateVoucherDate = New C1.Win.C1Input.C1DateEdit()
        Me.tdbcVoucherTypeID = New C1.Win.C1List.C1Combo()
        Me.lblVoucherTypeID = New System.Windows.Forms.Label()
        Me.lblVoucherDate = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDepreciatedAmount = New System.Windows.Forms.TextBox()
        Me.txtMethodName = New System.Windows.Forms.TextBox()
        Me.txtRemainAmount = New System.Windows.Forms.TextBox()
        Me.txtBeginAccuAmount = New System.Windows.Forms.TextBox()
        Me.txtBeginConvertedAmount = New System.Windows.Forms.TextBox()
        Me.tdbcAssetID = New C1.Win.C1List.C1Combo()
        Me.lblAssetID = New System.Windows.Forms.Label()
        Me.txtAssetName = New System.Windows.Forms.TextBox()
        Me.lblBeginConvertedAmount = New System.Windows.Forms.Label()
        Me.lblBeginAccuAmount = New System.Windows.Forms.Label()
        Me.lblRemainAmount = New System.Windows.Forms.Label()
        Me.lblMethodName = New System.Windows.Forms.Label()
        Me.lblDepreciatedAmount = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.c1dateVoucherDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tdbcAssetID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.lblDescription)
        Me.GroupBox1.Controls.Add(Me.txtVoucherNo)
        Me.GroupBox1.Controls.Add(Me.lblVoucherNo)
        Me.GroupBox1.Controls.Add(Me.c1dateVoucherDate)
        Me.GroupBox1.Controls.Add(Me.tdbcVoucherTypeID)
        Me.GroupBox1.Controls.Add(Me.lblVoucherTypeID)
        Me.GroupBox1.Controls.Add(Me.lblVoucherDate)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(566, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin phiếu"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtDescription.Location = New System.Drawing.Point(113, 85)
        Me.txtDescription.MaxLength = 250
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(434, 20)
        Me.txtDescription.TabIndex = 7
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(21, 88)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(48, 13)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "Diễn giải"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtVoucherNo.Location = New System.Drawing.Point(407, 26)
        Me.txtVoucherNo.MaxLength = 20
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(140, 20)
        Me.txtVoucherNo.TabIndex = 3
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucherNo.Location = New System.Drawing.Point(300, 29)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(49, 13)
        Me.lblVoucherNo.TabIndex = 2
        Me.lblVoucherNo.Text = "Số phiếu"
        Me.lblVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c1dateVoucherDate
        '
        Me.c1dateVoucherDate.AutoSize = False
        Me.c1dateVoucherDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateVoucherDate.EmptyAsNull = True
        Me.c1dateVoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.c1dateVoucherDate.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateVoucherDate.Location = New System.Drawing.Point(113, 56)
        Me.c1dateVoucherDate.Name = "c1dateVoucherDate"
        Me.c1dateVoucherDate.Size = New System.Drawing.Size(140, 22)
        Me.c1dateVoucherDate.TabIndex = 5
        Me.c1dateVoucherDate.Tag = Nothing
        Me.c1dateVoucherDate.TrimStart = True
        Me.c1dateVoucherDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'tdbcVoucherTypeID
        '
        Me.tdbcVoucherTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcVoucherTypeID.AllowColMove = False
        Me.tdbcVoucherTypeID.AllowColSelect = True
        Me.tdbcVoucherTypeID.AllowSort = False
        Me.tdbcVoucherTypeID.AlternatingRows = True
        Me.tdbcVoucherTypeID.AutoCompletion = True
        Me.tdbcVoucherTypeID.AutoDropDown = True
        Me.tdbcVoucherTypeID.Caption = ""
        Me.tdbcVoucherTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcVoucherTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcVoucherTypeID.DisplayMember = "VoucherTypeID"
        Me.tdbcVoucherTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcVoucherTypeID.DropDownWidth = 500
        Me.tdbcVoucherTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcVoucherTypeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcVoucherTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcVoucherTypeID.EmptyRows = True
        Me.tdbcVoucherTypeID.ExtendRightColumn = True
        Me.tdbcVoucherTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcVoucherTypeID.Images.Add(CType(resources.GetObject("tdbcVoucherTypeID.Images"), System.Drawing.Image))
        Me.tdbcVoucherTypeID.Location = New System.Drawing.Point(113, 26)
        Me.tdbcVoucherTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcVoucherTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcVoucherTypeID.MaxLength = 32767
        Me.tdbcVoucherTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcVoucherTypeID.Name = "tdbcVoucherTypeID"
        Me.tdbcVoucherTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcVoucherTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcVoucherTypeID.Size = New System.Drawing.Size(140, 21)
        Me.tdbcVoucherTypeID.TabIndex = 1
        Me.tdbcVoucherTypeID.ValueMember = "VoucherTypeID"
        Me.tdbcVoucherTypeID.PropBag = resources.GetString("tdbcVoucherTypeID.PropBag")
        '
        'lblVoucherTypeID
        '
        Me.lblVoucherTypeID.AutoSize = True
        Me.lblVoucherTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucherTypeID.Location = New System.Drawing.Point(21, 29)
        Me.lblVoucherTypeID.Name = "lblVoucherTypeID"
        Me.lblVoucherTypeID.Size = New System.Drawing.Size(56, 13)
        Me.lblVoucherTypeID.TabIndex = 0
        Me.lblVoucherTypeID.Text = "Loại phiếu"
        Me.lblVoucherTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVoucherDate
        '
        Me.lblVoucherDate.AutoSize = True
        Me.lblVoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucherDate.Location = New System.Drawing.Point(21, 59)
        Me.lblVoucherDate.Name = "lblVoucherDate"
        Me.lblVoucherDate.Size = New System.Drawing.Size(61, 13)
        Me.lblVoucherDate.TabIndex = 4
        Me.lblVoucherDate.Text = "Ngày phiếu"
        Me.lblVoucherDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDepreciatedAmount)
        Me.GroupBox2.Controls.Add(Me.txtMethodName)
        Me.GroupBox2.Controls.Add(Me.txtRemainAmount)
        Me.GroupBox2.Controls.Add(Me.txtBeginAccuAmount)
        Me.GroupBox2.Controls.Add(Me.txtBeginConvertedAmount)
        Me.GroupBox2.Controls.Add(Me.tdbcAssetID)
        Me.GroupBox2.Controls.Add(Me.lblAssetID)
        Me.GroupBox2.Controls.Add(Me.txtAssetName)
        Me.GroupBox2.Controls.Add(Me.lblBeginConvertedAmount)
        Me.GroupBox2.Controls.Add(Me.lblBeginAccuAmount)
        Me.GroupBox2.Controls.Add(Me.lblRemainAmount)
        Me.GroupBox2.Controls.Add(Me.lblMethodName)
        Me.GroupBox2.Controls.Add(Me.lblDepreciatedAmount)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(566, 158)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thông tin tài sản"
        '
        'txtDepreciatedAmount
        '
        Me.txtDepreciatedAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtDepreciatedAmount.Location = New System.Drawing.Point(113, 118)
        Me.txtDepreciatedAmount.MaxLength = 250
        Me.txtDepreciatedAmount.Name = "txtDepreciatedAmount"
        Me.txtDepreciatedAmount.Size = New System.Drawing.Size(140, 20)
        Me.txtDepreciatedAmount.TabIndex = 12
        Me.txtDepreciatedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMethodName
        '
        Me.txtMethodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtMethodName.Location = New System.Drawing.Point(407, 88)
        Me.txtMethodName.MaxLength = 250
        Me.txtMethodName.Name = "txtMethodName"
        Me.txtMethodName.ReadOnly = True
        Me.txtMethodName.Size = New System.Drawing.Size(140, 20)
        Me.txtMethodName.TabIndex = 10
        Me.txtMethodName.TabStop = False
        '
        'txtRemainAmount
        '
        Me.txtRemainAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtRemainAmount.Location = New System.Drawing.Point(113, 88)
        Me.txtRemainAmount.MaxLength = 0
        Me.txtRemainAmount.Name = "txtRemainAmount"
        Me.txtRemainAmount.ReadOnly = True
        Me.txtRemainAmount.Size = New System.Drawing.Size(140, 20)
        Me.txtRemainAmount.TabIndex = 8
        Me.txtRemainAmount.TabStop = False
        Me.txtRemainAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBeginAccuAmount
        '
        Me.txtBeginAccuAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtBeginAccuAmount.Location = New System.Drawing.Point(407, 58)
        Me.txtBeginAccuAmount.MaxLength = 0
        Me.txtBeginAccuAmount.Name = "txtBeginAccuAmount"
        Me.txtBeginAccuAmount.ReadOnly = True
        Me.txtBeginAccuAmount.Size = New System.Drawing.Size(140, 20)
        Me.txtBeginAccuAmount.TabIndex = 6
        Me.txtBeginAccuAmount.TabStop = False
        Me.txtBeginAccuAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBeginConvertedAmount
        '
        Me.txtBeginConvertedAmount.BackColor = System.Drawing.SystemColors.Control
        Me.txtBeginConvertedAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtBeginConvertedAmount.Location = New System.Drawing.Point(113, 58)
        Me.txtBeginConvertedAmount.MaxLength = 0
        Me.txtBeginConvertedAmount.Name = "txtBeginConvertedAmount"
        Me.txtBeginConvertedAmount.ReadOnly = True
        Me.txtBeginConvertedAmount.Size = New System.Drawing.Size(140, 20)
        Me.txtBeginConvertedAmount.TabIndex = 4
        Me.txtBeginConvertedAmount.TabStop = False
        Me.txtBeginConvertedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tdbcAssetID
        '
        Me.tdbcAssetID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcAssetID.AllowColMove = False
        Me.tdbcAssetID.AllowColSelect = True
        Me.tdbcAssetID.AllowSort = False
        Me.tdbcAssetID.AlternatingRows = True
        Me.tdbcAssetID.AutoCompletion = True
        Me.tdbcAssetID.AutoDropDown = True
        Me.tdbcAssetID.Caption = ""
        Me.tdbcAssetID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcAssetID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcAssetID.DisplayMember = "AssetID"
        Me.tdbcAssetID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcAssetID.DropDownWidth = 500
        Me.tdbcAssetID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcAssetID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcAssetID.EmptyRows = True
        Me.tdbcAssetID.ExtendRightColumn = True
        Me.tdbcAssetID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetID.Images.Add(CType(resources.GetObject("tdbcAssetID.Images"), System.Drawing.Image))
        Me.tdbcAssetID.Location = New System.Drawing.Point(113, 27)
        Me.tdbcAssetID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcAssetID.MaxDropDownItems = CType(8, Short)
        Me.tdbcAssetID.MaxLength = 32767
        Me.tdbcAssetID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcAssetID.Name = "tdbcAssetID"
        Me.tdbcAssetID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcAssetID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcAssetID.Size = New System.Drawing.Size(140, 21)
        Me.tdbcAssetID.TabIndex = 1
        Me.tdbcAssetID.ValueMember = "AssetID"
        Me.tdbcAssetID.PropBag = resources.GetString("tdbcAssetID.PropBag")
        '
        'lblAssetID
        '
        Me.lblAssetID.AutoSize = True
        Me.lblAssetID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssetID.Location = New System.Drawing.Point(21, 30)
        Me.lblAssetID.Name = "lblAssetID"
        Me.lblAssetID.Size = New System.Drawing.Size(56, 13)
        Me.lblAssetID.TabIndex = 0
        Me.lblAssetID.Text = "Mã tài sản"
        Me.lblAssetID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAssetName
        '
        Me.txtAssetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtAssetName.Location = New System.Drawing.Point(260, 27)
        Me.txtAssetName.Name = "txtAssetName"
        Me.txtAssetName.ReadOnly = True
        Me.txtAssetName.Size = New System.Drawing.Size(287, 20)
        Me.txtAssetName.TabIndex = 2
        Me.txtAssetName.TabStop = False
        '
        'lblBeginConvertedAmount
        '
        Me.lblBeginConvertedAmount.AutoSize = True
        Me.lblBeginConvertedAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBeginConvertedAmount.Location = New System.Drawing.Point(21, 61)
        Me.lblBeginConvertedAmount.Name = "lblBeginConvertedAmount"
        Me.lblBeginConvertedAmount.Size = New System.Drawing.Size(61, 13)
        Me.lblBeginConvertedAmount.TabIndex = 3
        Me.lblBeginConvertedAmount.Text = "Nguyên giá"
        Me.lblBeginConvertedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBeginAccuAmount
        '
        Me.lblBeginAccuAmount.AutoSize = True
        Me.lblBeginAccuAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBeginAccuAmount.Location = New System.Drawing.Point(269, 61)
        Me.lblBeginAccuAmount.Name = "lblBeginAccuAmount"
        Me.lblBeginAccuAmount.Size = New System.Drawing.Size(81, 13)
        Me.lblBeginAccuAmount.TabIndex = 5
        Me.lblBeginAccuAmount.Text = "Hao mòn lũy kế"
        Me.lblBeginAccuAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemainAmount
        '
        Me.lblRemainAmount.AutoSize = True
        Me.lblRemainAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemainAmount.Location = New System.Drawing.Point(21, 91)
        Me.lblRemainAmount.Name = "lblRemainAmount"
        Me.lblRemainAmount.Size = New System.Drawing.Size(68, 13)
        Me.lblRemainAmount.TabIndex = 7
        Me.lblRemainAmount.Text = "Giá trị còn lại"
        Me.lblRemainAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMethodName
        '
        Me.lblMethodName.AutoSize = True
        Me.lblMethodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethodName.Location = New System.Drawing.Point(269, 91)
        Me.lblMethodName.Name = "lblMethodName"
        Me.lblMethodName.Size = New System.Drawing.Size(89, 13)
        Me.lblMethodName.TabIndex = 9
        Me.lblMethodName.Text = "Phương pháp KH"
        Me.lblMethodName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepreciatedAmount
        '
        Me.lblDepreciatedAmount.AutoSize = True
        Me.lblDepreciatedAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepreciatedAmount.Location = New System.Drawing.Point(21, 121)
        Me.lblDepreciatedAmount.Name = "lblDepreciatedAmount"
        Me.lblDepreciatedAmount.Size = New System.Drawing.Size(76, 13)
        Me.lblDepreciatedAmount.TabIndex = 11
        Me.lblDepreciatedAmount.Text = "Mức khấu hao"
        Me.lblDepreciatedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(502, 309)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Đó&ng"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(340, 309)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Lưu"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(421, 309)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "Nhập &tiếp"
        '
        'D02F0503
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 339)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F0503"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bòt toÀn khÊu hao - D02F0503"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.c1dateVoucherDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tdbcAssetID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents c1dateVoucherDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents tdbcVoucherTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblVoucherTypeID As System.Windows.Forms.Label
    Private WithEvents lblVoucherDate As System.Windows.Forms.Label
    Private WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Private WithEvents lblVoucherNo As System.Windows.Forms.Label
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents tdbcAssetID As C1.Win.C1List.C1Combo
    Private WithEvents lblAssetID As System.Windows.Forms.Label
    Private WithEvents txtAssetName As System.Windows.Forms.TextBox
    Private WithEvents txtMethodName As System.Windows.Forms.TextBox
    Private WithEvents txtRemainAmount As System.Windows.Forms.TextBox
    Private WithEvents txtBeginAccuAmount As System.Windows.Forms.TextBox
    Private WithEvents txtBeginConvertedAmount As System.Windows.Forms.TextBox
    Private WithEvents lblBeginConvertedAmount As System.Windows.Forms.Label
    Private WithEvents lblBeginAccuAmount As System.Windows.Forms.Label
    Private WithEvents lblRemainAmount As System.Windows.Forms.Label
    Private WithEvents lblMethodName As System.Windows.Forms.Label
    Private WithEvents txtDepreciatedAmount As System.Windows.Forms.TextBox
    Private WithEvents lblDepreciatedAmount As System.Windows.Forms.Label
End Class