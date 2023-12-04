<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F2012
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F2012))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnInherit = New System.Windows.Forms.Button
        Me.lblDash = New System.Windows.Forms.Label
        Me.tdbcPeriodTo = New C1.Win.C1List.C1Combo
        Me.tdbcPeriodFrom = New C1.Win.C1List.C1Combo
        Me.lblPeriod = New System.Windows.Forms.Label
        Me.txtVoucherNo = New System.Windows.Forms.TextBox
        Me.lblVoucherNo = New System.Windows.Forms.Label
        Me.txtAccountID = New System.Windows.Forms.TextBox
        Me.lblAccountID = New System.Windows.Forms.Label
        Me.btnFilter = New System.Windows.Forms.Button
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPeriodTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPeriodFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(8, 46)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1000, 575)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 5
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(932, 627)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnInherit
        '
        Me.btnInherit.Location = New System.Drawing.Point(850, 628)
        Me.btnInherit.Name = "btnInherit"
        Me.btnInherit.Size = New System.Drawing.Size(76, 22)
        Me.btnInherit.TabIndex = 6
        Me.btnInherit.Text = "&Kế thừa"
        Me.btnInherit.UseVisualStyleBackColor = True
        '
        'lblDash
        '
        Me.lblDash.AutoSize = True
        Me.lblDash.Location = New System.Drawing.Point(171, 13)
        Me.lblDash.Name = "lblDash"
        Me.lblDash.Size = New System.Drawing.Size(13, 13)
        Me.lblDash.TabIndex = 28
        Me.lblDash.Text = "_"
        Me.lblDash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcPeriodTo
        '
        Me.tdbcPeriodTo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodTo.AllowColMove = False
        Me.tdbcPeriodTo.AllowSort = False
        Me.tdbcPeriodTo.AlternatingRows = True
        Me.tdbcPeriodTo.AutoCompletion = True
        Me.tdbcPeriodTo.AutoDropDown = True
        Me.tdbcPeriodTo.Caption = ""
        Me.tdbcPeriodTo.CaptionHeight = 17
        Me.tdbcPeriodTo.CaptionStyle = Style1
        Me.tdbcPeriodTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodTo.ColumnCaptionHeight = 17
        Me.tdbcPeriodTo.ColumnFooterHeight = 17
        Me.tdbcPeriodTo.ColumnHeaders = False
        Me.tdbcPeriodTo.ContentHeight = 17
        Me.tdbcPeriodTo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodTo.DisplayMember = "Period"
        Me.tdbcPeriodTo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodTo.DropDownWidth = 103
        Me.tdbcPeriodTo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodTo.EditorHeight = 17
        Me.tdbcPeriodTo.EmptyRows = True
        Me.tdbcPeriodTo.EvenRowStyle = Style2
        Me.tdbcPeriodTo.ExtendRightColumn = True
        Me.tdbcPeriodTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.FooterStyle = Style3
        Me.tdbcPeriodTo.HeadingStyle = Style4
        Me.tdbcPeriodTo.HighLightRowStyle = Style5
        Me.tdbcPeriodTo.Images.Add(CType(resources.GetObject("tdbcPeriodTo.Images"), System.Drawing.Image))
        Me.tdbcPeriodTo.ItemHeight = 15
        Me.tdbcPeriodTo.Location = New System.Drawing.Point(189, 13)
        Me.tdbcPeriodTo.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodTo.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodTo.MaxLength = 32767
        Me.tdbcPeriodTo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodTo.Name = "tdbcPeriodTo"
        Me.tdbcPeriodTo.OddRowStyle = Style6
        Me.tdbcPeriodTo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcPeriodTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodTo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodTo.SelectedStyle = Style7
        Me.tdbcPeriodTo.Size = New System.Drawing.Size(103, 23)
        Me.tdbcPeriodTo.Style = Style8
        Me.tdbcPeriodTo.TabIndex = 1
        Me.tdbcPeriodTo.ValueMember = "Period"
        Me.tdbcPeriodTo.PropBag = resources.GetString("tdbcPeriodTo.PropBag")
        '
        'tdbcPeriodFrom
        '
        Me.tdbcPeriodFrom.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodFrom.AllowColMove = False
        Me.tdbcPeriodFrom.AllowSort = False
        Me.tdbcPeriodFrom.AlternatingRows = True
        Me.tdbcPeriodFrom.AutoCompletion = True
        Me.tdbcPeriodFrom.AutoDropDown = True
        Me.tdbcPeriodFrom.Caption = ""
        Me.tdbcPeriodFrom.CaptionHeight = 17
        Me.tdbcPeriodFrom.CaptionStyle = Style9
        Me.tdbcPeriodFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodFrom.ColumnCaptionHeight = 17
        Me.tdbcPeriodFrom.ColumnFooterHeight = 17
        Me.tdbcPeriodFrom.ColumnHeaders = False
        Me.tdbcPeriodFrom.ContentHeight = 17
        Me.tdbcPeriodFrom.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodFrom.DisplayMember = "Period"
        Me.tdbcPeriodFrom.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodFrom.DropDownWidth = 103
        Me.tdbcPeriodFrom.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodFrom.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFrom.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodFrom.EditorHeight = 17
        Me.tdbcPeriodFrom.EmptyRows = True
        Me.tdbcPeriodFrom.EvenRowStyle = Style10
        Me.tdbcPeriodFrom.ExtendRightColumn = True
        Me.tdbcPeriodFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFrom.FooterStyle = Style11
        Me.tdbcPeriodFrom.HeadingStyle = Style12
        Me.tdbcPeriodFrom.HighLightRowStyle = Style13
        Me.tdbcPeriodFrom.Images.Add(CType(resources.GetObject("tdbcPeriodFrom.Images"), System.Drawing.Image))
        Me.tdbcPeriodFrom.ItemHeight = 15
        Me.tdbcPeriodFrom.Location = New System.Drawing.Point(63, 12)
        Me.tdbcPeriodFrom.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodFrom.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodFrom.MaxLength = 32767
        Me.tdbcPeriodFrom.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodFrom.Name = "tdbcPeriodFrom"
        Me.tdbcPeriodFrom.OddRowStyle = Style14
        Me.tdbcPeriodFrom.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcPeriodFrom.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodFrom.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodFrom.SelectedStyle = Style15
        Me.tdbcPeriodFrom.Size = New System.Drawing.Size(103, 23)
        Me.tdbcPeriodFrom.Style = Style16
        Me.tdbcPeriodFrom.TabIndex = 0
        Me.tdbcPeriodFrom.ValueMember = "Period"
        Me.tdbcPeriodFrom.PropBag = resources.GetString("tdbcPeriodFrom.PropBag")
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(12, 17)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(19, 13)
        Me.lblPeriod.TabIndex = 29
        Me.lblPeriod.Text = "Kỳ"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtVoucherNo.Location = New System.Drawing.Point(438, 13)
        Me.txtVoucherNo.MaxLength = 20
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(163, 22)
        Me.txtVoucherNo.TabIndex = 2
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Location = New System.Drawing.Point(319, 18)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(91, 13)
        Me.lblVoucherNo.TabIndex = 31
        Me.lblVoucherNo.Text = "Số phiếu có chứa"
        Me.lblVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAccountID
        '
        Me.txtAccountID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtAccountID.Location = New System.Drawing.Point(754, 14)
        Me.txtAccountID.MaxLength = 20
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(163, 22)
        Me.txtAccountID.TabIndex = 3
        '
        'lblAccountID
        '
        Me.lblAccountID.AutoSize = True
        Me.lblAccountID.Location = New System.Drawing.Point(630, 18)
        Me.lblAccountID.Name = "lblAccountID"
        Me.lblAccountID.Size = New System.Drawing.Size(97, 13)
        Me.lblAccountID.TabIndex = 33
        Me.lblAccountID.Text = "Tài khoản có chứa"
        Me.lblAccountID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFilter
        '
        Me.btnFilter.AutoSize = True
        Me.btnFilter.Location = New System.Drawing.Point(923, 13)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(85, 25)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'D02F2012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.txtAccountID)
        Me.Controls.Add(Me.txtVoucherNo)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblDash)
        Me.Controls.Add(Me.tdbcPeriodTo)
        Me.Controls.Add(Me.tdbcPeriodFrom)
        Me.Controls.Add(Me.btnInherit)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.lblVoucherNo)
        Me.Controls.Add(Me.lblAccountID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F2012"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chãn phiÕu kÕ thôa - D02F2012"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPeriodTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPeriodFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnInherit As System.Windows.Forms.Button
    Private WithEvents lblDash As System.Windows.Forms.Label
    Private WithEvents tdbcPeriodTo As C1.Win.C1List.C1Combo
    Private WithEvents tdbcPeriodFrom As C1.Win.C1List.C1Combo
    Private WithEvents lblPeriod As System.Windows.Forms.Label
    Private WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Private WithEvents lblVoucherNo As System.Windows.Forms.Label
    Private WithEvents txtAccountID As System.Windows.Forms.TextBox
    Private WithEvents lblAccountID As System.Windows.Forms.Label
    Private WithEvents btnFilter As System.Windows.Forms.Button
End Class