<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F2013
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
        Me.components = New System.ComponentModel.Container()
        Dim mnuFindLink As C1.Win.C1Command.C1CommandLink
        Dim mnuListAllLink As C1.Win.C1Command.C1CommandLink
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F2013))
        Me.mnuFind = New C1.Win.C1Command.C1Command()
        Me.mnuListAll = New C1.Win.C1Command.C1Command()
        Me.btnAllToLeft = New System.Windows.Forms.Button()
        Me.btnToLeft = New System.Windows.Forms.Button()
        Me.btnAllToRight = New System.Windows.Forms.Button()
        Me.btnToRight = New System.Windows.Forms.Button()
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu()
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.tdbgRight = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tdbgLeft = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grp1 = New System.Windows.Forms.GroupBox()
        Me.grp3 = New System.Windows.Forms.GroupBox()
        Me.tdbdAssetConditionalID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.btnNextD09F2130 = New System.Windows.Forms.Button()
        Me.chkIsStopDepre = New System.Windows.Forms.CheckBox()
        Me.tdbcEffectReasonID = New C1.Win.C1List.C1Combo()
        Me.lblEffectReasonID = New System.Windows.Forms.Label()
        Me.btnView = New System.Windows.Forms.Button()
        Me.txtManagementObjectName = New System.Windows.Forms.TextBox()
        Me.tdbcManagementObjectTypeID = New C1.Win.C1List.C1Combo()
        Me.lblManagementObjectTypeID = New System.Windows.Forms.Label()
        Me.tdbcManagementObjectID = New C1.Win.C1List.C1Combo()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.tdbcObjectTypeID = New C1.Win.C1List.C1Combo()
        Me.lblObjectTypeID = New System.Windows.Forms.Label()
        Me.txtObjectName = New System.Windows.Forms.TextBox()
        Me.tdbcEmployeeID = New C1.Win.C1List.C1Combo()
        Me.lblEmployeeID = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.tdbcObjectID = New C1.Win.C1List.C1Combo()
        mnuFindLink = New C1.Win.C1Command.C1CommandLink()
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbgRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.tdbgLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp1.SuspendLayout()
        Me.grp3.SuspendLayout()
        CType(Me.tdbdAssetConditionalID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcEffectReasonID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcManagementObjectTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcManagementObjectID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcObjectTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcEmployeeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcObjectID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuFindLink
        '
        mnuFindLink.Command = Me.mnuFind
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.ShortcutText = ""
        Me.mnuFind.Text = "Tìm &kiếm"
        '
        'mnuListAllLink
        '
        mnuListAllLink.Command = Me.mnuListAll
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.ShortcutText = ""
        Me.mnuListAll.Text = "&Liệt kê tất cả"
        '
        'btnAllToLeft
        '
        Me.btnAllToLeft.Location = New System.Drawing.Point(394, 283)
        Me.btnAllToLeft.Name = "btnAllToLeft"
        Me.btnAllToLeft.Size = New System.Drawing.Size(55, 26)
        Me.btnAllToLeft.TabIndex = 20
        Me.btnAllToLeft.Text = "<<"
        Me.btnAllToLeft.UseVisualStyleBackColor = True
        '
        'btnToLeft
        '
        Me.btnToLeft.Location = New System.Drawing.Point(394, 251)
        Me.btnToLeft.Name = "btnToLeft"
        Me.btnToLeft.Size = New System.Drawing.Size(55, 26)
        Me.btnToLeft.TabIndex = 19
        Me.btnToLeft.Text = "<"
        Me.btnToLeft.UseVisualStyleBackColor = True
        '
        'btnAllToRight
        '
        Me.btnAllToRight.Location = New System.Drawing.Point(394, 195)
        Me.btnAllToRight.Name = "btnAllToRight"
        Me.btnAllToRight.Size = New System.Drawing.Size(55, 26)
        Me.btnAllToRight.TabIndex = 18
        Me.btnAllToRight.Text = ">>"
        Me.btnAllToRight.UseVisualStyleBackColor = True
        '
        'btnToRight
        '
        Me.btnToRight.Location = New System.Drawing.Point(394, 163)
        Me.btnToRight.Name = "btnToRight"
        Me.btnToRight.Size = New System.Drawing.Size(55, 26)
        Me.btnToRight.TabIndex = 17
        Me.btnToRight.Text = ">"
        Me.btnToRight.UseVisualStyleBackColor = True
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {mnuFindLink, mnuListAllLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        Me.C1ContextMenu.ShortcutText = ""
        Me.C1ContextMenu.VisualStyleBase = C1.Win.C1Command.VisualStyle.OfficeXP
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Owner = Me
        '
        'tdbgRight
        '
        Me.tdbgRight.AllowColMove = False
        Me.tdbgRight.AllowColSelect = False
        Me.tdbgRight.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgRight.AllowSort = False
        Me.tdbgRight.AlternatingRows = True
        Me.tdbgRight.ColumnFooters = True
        Me.tdbgRight.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbgRight.EmptyRows = True
        Me.tdbgRight.ExtendRightColumn = True
        Me.tdbgRight.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbgRight.Images.Add(CType(resources.GetObject("tdbgRight.Images"), System.Drawing.Image))
        Me.tdbgRight.Location = New System.Drawing.Point(8, 23)
        Me.tdbgRight.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgRight.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgRight.Name = "tdbgRight"
        Me.tdbgRight.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgRight.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgRight.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgRight.PrintInfo.PageSettings = CType(resources.GetObject("tdbgRight.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgRight.PropBag = resources.GetString("tdbgRight.PropBag")
        Me.tdbgRight.Size = New System.Drawing.Size(519, 479)
        Me.tdbgRight.TabAcrossSplits = True
        Me.tdbgRight.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgRight.TabIndex = 0
        Me.tdbgRight.Tag = "COL1"
        Me.tdbgRight.WrapCellPointer = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsFind, Me.mnsListAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(141, 48)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(140, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(140, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'tdbgLeft
        '
        Me.tdbgLeft.AllowColMove = False
        Me.tdbgLeft.AllowColSelect = False
        Me.tdbgLeft.AllowFilter = False
        Me.tdbgLeft.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgLeft.AllowSort = False
        Me.tdbgLeft.AllowUpdate = False
        Me.tdbgLeft.AlternatingRows = True
        Me.tdbgLeft.ColumnFooters = True
        Me.tdbgLeft.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbgLeft.EmptyRows = True
        Me.tdbgLeft.ExtendRightColumn = True
        Me.tdbgLeft.FilterBar = True
        Me.tdbgLeft.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbgLeft.Images.Add(CType(resources.GetObject("tdbgLeft.Images"), System.Drawing.Image))
        Me.tdbgLeft.Location = New System.Drawing.Point(8, 23)
        Me.tdbgLeft.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgLeft.Name = "tdbgLeft"
        Me.tdbgLeft.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgLeft.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgLeft.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgLeft.PrintInfo.PageSettings = CType(resources.GetObject("tdbgLeft.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgLeft.PropBag = resources.GetString("tdbgLeft.PropBag")
        Me.tdbgLeft.Size = New System.Drawing.Size(340, 479)
        Me.tdbgLeft.TabAcrossSplits = True
        Me.tdbgLeft.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgLeft.TabIndex = 0
        Me.tdbgLeft.Tag = "COL"
        Me.tdbgLeft.WrapCellPointer = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(930, 626)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 23
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.tdbgLeft)
        Me.grp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp1.Location = New System.Drawing.Point(9, 110)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(358, 510)
        Me.grp1.TabIndex = 15
        Me.grp1.TabStop = False
        Me.grp1.Text = "Mã tài sản"
        '
        'grp3
        '
        Me.grp3.Controls.Add(Me.tdbdAssetConditionalID)
        Me.grp3.Controls.Add(Me.tdbgRight)
        Me.grp3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp3.Location = New System.Drawing.Point(472, 110)
        Me.grp3.Name = "grp3"
        Me.grp3.Size = New System.Drawing.Size(534, 510)
        Me.grp3.TabIndex = 21
        Me.grp3.TabStop = False
        Me.grp3.Text = "Mã tài sản được chọn"
        '
        'tdbdAssetConditionalID
        '
        Me.tdbdAssetConditionalID.AllowColMove = False
        Me.tdbdAssetConditionalID.AllowColSelect = False
        Me.tdbdAssetConditionalID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdAssetConditionalID.AllowSort = False
        Me.tdbdAssetConditionalID.AlternatingRows = True
        Me.tdbdAssetConditionalID.CaptionStyle = Style1
        Me.tdbdAssetConditionalID.ColumnCaptionHeight = 17
        Me.tdbdAssetConditionalID.ColumnFooterHeight = 17
        Me.tdbdAssetConditionalID.DisplayMember = "AssetConditionName"
        Me.tdbdAssetConditionalID.EmptyRows = True
        Me.tdbdAssetConditionalID.EvenRowStyle = Style2
        Me.tdbdAssetConditionalID.ExtendRightColumn = True
        Me.tdbdAssetConditionalID.FetchRowStyles = False
        Me.tdbdAssetConditionalID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbdAssetConditionalID.FooterStyle = Style3
        Me.tdbdAssetConditionalID.HeadingStyle = Style4
        Me.tdbdAssetConditionalID.HighLightRowStyle = Style5
        Me.tdbdAssetConditionalID.Images.Add(CType(resources.GetObject("tdbdAssetConditionalID.Images"), System.Drawing.Image))
        Me.tdbdAssetConditionalID.Location = New System.Drawing.Point(43, 225)
        Me.tdbdAssetConditionalID.Name = "tdbdAssetConditionalID"
        Me.tdbdAssetConditionalID.OddRowStyle = Style6
        Me.tdbdAssetConditionalID.PropBag = resources.GetString("tdbdAssetConditionalID.PropBag")
        Me.tdbdAssetConditionalID.RecordSelectorStyle = Style7
        Me.tdbdAssetConditionalID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdAssetConditionalID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdAssetConditionalID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdAssetConditionalID.ScrollTips = False
        Me.tdbdAssetConditionalID.Size = New System.Drawing.Size(500, 147)
        Me.tdbdAssetConditionalID.Style = Style8
        Me.tdbdAssetConditionalID.TabIndex = 1
        Me.tdbdAssetConditionalID.TabStop = False
        Me.tdbdAssetConditionalID.ValueMember = "AssetConditionID"
        Me.tdbdAssetConditionalID.ValueTranslate = True
        Me.tdbdAssetConditionalID.Visible = False
        '
        'btnNextD09F2130
        '
        Me.btnNextD09F2130.Location = New System.Drawing.Point(841, 626)
        Me.btnNextD09F2130.Name = "btnNextD09F2130"
        Me.btnNextD09F2130.Size = New System.Drawing.Size(83, 22)
        Me.btnNextD09F2130.TabIndex = 22
        Me.btnNextD09F2130.Text = "Tiếp tục"
        Me.btnNextD09F2130.UseVisualStyleBackColor = True
        '
        'chkIsStopDepre
        '
        Me.chkIsStopDepre.AutoSize = True
        Me.chkIsStopDepre.Location = New System.Drawing.Point(17, 37)
        Me.chkIsStopDepre.Name = "chkIsStopDepre"
        Me.chkIsStopDepre.Size = New System.Drawing.Size(198, 17)
        Me.chkIsStopDepre.TabIndex = 6
        Me.chkIsStopDepre.Text = "Hiển thị các tài sản ngừng khấu hao"
        Me.chkIsStopDepre.UseVisualStyleBackColor = True
        '
        'tdbcEffectReasonID
        '
        Me.tdbcEffectReasonID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcEffectReasonID.AllowColMove = False
        Me.tdbcEffectReasonID.AllowColSelect = True
        Me.tdbcEffectReasonID.AllowSort = False
        Me.tdbcEffectReasonID.AlternatingRows = True
        Me.tdbcEffectReasonID.AutoCompletion = True
        Me.tdbcEffectReasonID.AutoDropDown = True
        Me.tdbcEffectReasonID.Caption = ""
        Me.tdbcEffectReasonID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcEffectReasonID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcEffectReasonID.DisplayMember = "EffectReasonID"
        Me.tdbcEffectReasonID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcEffectReasonID.DropDownWidth = 500
        Me.tdbcEffectReasonID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcEffectReasonID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcEffectReasonID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcEffectReasonID.EmptyRows = True
        Me.tdbcEffectReasonID.ExtendRightColumn = True
        Me.tdbcEffectReasonID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcEffectReasonID.Images.Add(CType(resources.GetObject("tdbcEffectReasonID.Images"), System.Drawing.Image))
        Me.tdbcEffectReasonID.Location = New System.Drawing.Point(144, 4)
        Me.tdbcEffectReasonID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcEffectReasonID.MaxDropDownItems = CType(8, Short)
        Me.tdbcEffectReasonID.MaxLength = 32767
        Me.tdbcEffectReasonID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcEffectReasonID.Name = "tdbcEffectReasonID"
        Me.tdbcEffectReasonID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcEffectReasonID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcEffectReasonID.Size = New System.Drawing.Size(128, 21)
        Me.tdbcEffectReasonID.TabIndex = 1
        Me.tdbcEffectReasonID.ValueMember = "EffectReasonID"
        Me.tdbcEffectReasonID.PropBag = resources.GetString("tdbcEffectReasonID.PropBag")
        '
        'lblEffectReasonID
        '
        Me.lblEffectReasonID.AutoSize = True
        Me.lblEffectReasonID.Location = New System.Drawing.Point(14, 10)
        Me.lblEffectReasonID.Name = "lblEffectReasonID"
        Me.lblEffectReasonID.Size = New System.Drawing.Size(79, 13)
        Me.lblEffectReasonID.TabIndex = 0
        Me.lblEffectReasonID.Text = "Lý do tác động"
        Me.lblEffectReasonID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(382, 131)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(76, 26)
        Me.btnView.TabIndex = 16
        Me.btnView.Text = "Xem"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'txtManagementObjectName
        '
        Me.txtManagementObjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtManagementObjectName.Location = New System.Drawing.Point(833, 4)
        Me.txtManagementObjectName.Name = "txtManagementObjectName"
        Me.txtManagementObjectName.ReadOnly = True
        Me.txtManagementObjectName.Size = New System.Drawing.Size(173, 20)
        Me.txtManagementObjectName.TabIndex = 5
        Me.txtManagementObjectName.TabStop = False
        '
        'tdbcManagementObjectTypeID
        '
        Me.tdbcManagementObjectTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcManagementObjectTypeID.AllowColMove = False
        Me.tdbcManagementObjectTypeID.AllowSort = False
        Me.tdbcManagementObjectTypeID.AlternatingRows = True
        Me.tdbcManagementObjectTypeID.AutoCompletion = True
        Me.tdbcManagementObjectTypeID.AutoDropDown = True
        Me.tdbcManagementObjectTypeID.Caption = ""
        Me.tdbcManagementObjectTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcManagementObjectTypeID.ColumnWidth = 100
        Me.tdbcManagementObjectTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcManagementObjectTypeID.DisplayMember = "ObjectTypeID"
        Me.tdbcManagementObjectTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcManagementObjectTypeID.DropDownWidth = 400
        Me.tdbcManagementObjectTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcManagementObjectTypeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcManagementObjectTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcManagementObjectTypeID.EmptyRows = True
        Me.tdbcManagementObjectTypeID.ExtendRightColumn = True
        Me.tdbcManagementObjectTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcManagementObjectTypeID.Images.Add(CType(resources.GetObject("tdbcManagementObjectTypeID.Images"), System.Drawing.Image))
        Me.tdbcManagementObjectTypeID.Location = New System.Drawing.Point(620, 4)
        Me.tdbcManagementObjectTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcManagementObjectTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcManagementObjectTypeID.MaxLength = 32767
        Me.tdbcManagementObjectTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcManagementObjectTypeID.Name = "tdbcManagementObjectTypeID"
        Me.tdbcManagementObjectTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcManagementObjectTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcManagementObjectTypeID.Size = New System.Drawing.Size(103, 21)
        Me.tdbcManagementObjectTypeID.TabIndex = 3
        Me.tdbcManagementObjectTypeID.ValueMember = "ObjectTypeID"
        Me.tdbcManagementObjectTypeID.PropBag = resources.GetString("tdbcManagementObjectTypeID.PropBag")
        '
        'lblManagementObjectTypeID
        '
        Me.lblManagementObjectTypeID.AutoSize = True
        Me.lblManagementObjectTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManagementObjectTypeID.Location = New System.Drawing.Point(479, 10)
        Me.lblManagementObjectTypeID.Name = "lblManagementObjectTypeID"
        Me.lblManagementObjectTypeID.Size = New System.Drawing.Size(84, 13)
        Me.lblManagementObjectTypeID.TabIndex = 2
        Me.lblManagementObjectTypeID.Text = "Bộ phận quản lý"
        Me.lblManagementObjectTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcManagementObjectID
        '
        Me.tdbcManagementObjectID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcManagementObjectID.AllowColSelect = True
        Me.tdbcManagementObjectID.AllowSort = False
        Me.tdbcManagementObjectID.AlternatingRows = True
        Me.tdbcManagementObjectID.AutoDropDown = True
        Me.tdbcManagementObjectID.Caption = ""
        Me.tdbcManagementObjectID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcManagementObjectID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcManagementObjectID.DisplayMember = "ObjectID"
        Me.tdbcManagementObjectID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.RightDown
        Me.tdbcManagementObjectID.DropDownWidth = 500
        Me.tdbcManagementObjectID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcManagementObjectID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcManagementObjectID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcManagementObjectID.EmptyRows = True
        Me.tdbcManagementObjectID.ExtendRightColumn = True
        Me.tdbcManagementObjectID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcManagementObjectID.Images.Add(CType(resources.GetObject("tdbcManagementObjectID.Images"), System.Drawing.Image))
        Me.tdbcManagementObjectID.Location = New System.Drawing.Point(727, 4)
        Me.tdbcManagementObjectID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcManagementObjectID.MaxDropDownItems = CType(8, Short)
        Me.tdbcManagementObjectID.MaxLength = 32767
        Me.tdbcManagementObjectID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcManagementObjectID.Name = "tdbcManagementObjectID"
        Me.tdbcManagementObjectID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcManagementObjectID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcManagementObjectID.Size = New System.Drawing.Size(103, 21)
        Me.tdbcManagementObjectID.TabIndex = 4
        Me.tdbcManagementObjectID.ValueMember = "ObjectID"
        Me.tdbcManagementObjectID.PropBag = resources.GetString("tdbcManagementObjectID.PropBag")
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(930, 67)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 14
        Me.btnFilter.Text = "&Lọc"
        '
        'tdbcObjectTypeID
        '
        Me.tdbcObjectTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcObjectTypeID.AllowColMove = False
        Me.tdbcObjectTypeID.AllowSort = False
        Me.tdbcObjectTypeID.AlternatingRows = True
        Me.tdbcObjectTypeID.AutoCompletion = True
        Me.tdbcObjectTypeID.AutoDropDown = True
        Me.tdbcObjectTypeID.Caption = ""
        Me.tdbcObjectTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcObjectTypeID.ColumnWidth = 100
        Me.tdbcObjectTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcObjectTypeID.DisplayMember = "ObjectTypeID"
        Me.tdbcObjectTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcObjectTypeID.DropDownWidth = 400
        Me.tdbcObjectTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcObjectTypeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcObjectTypeID.EmptyRows = True
        Me.tdbcObjectTypeID.ExtendRightColumn = True
        Me.tdbcObjectTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectTypeID.Images.Add(CType(resources.GetObject("tdbcObjectTypeID.Images"), System.Drawing.Image))
        Me.tdbcObjectTypeID.Location = New System.Drawing.Point(620, 35)
        Me.tdbcObjectTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcObjectTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcObjectTypeID.MaxLength = 32767
        Me.tdbcObjectTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcObjectTypeID.Name = "tdbcObjectTypeID"
        Me.tdbcObjectTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcObjectTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcObjectTypeID.Size = New System.Drawing.Size(103, 21)
        Me.tdbcObjectTypeID.TabIndex = 8
        Me.tdbcObjectTypeID.ValueMember = "ObjectTypeID"
        Me.tdbcObjectTypeID.PropBag = resources.GetString("tdbcObjectTypeID.PropBag")
        '
        'lblObjectTypeID
        '
        Me.lblObjectTypeID.AutoSize = True
        Me.lblObjectTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObjectTypeID.Location = New System.Drawing.Point(479, 39)
        Me.lblObjectTypeID.Name = "lblObjectTypeID"
        Me.lblObjectTypeID.Size = New System.Drawing.Size(94, 13)
        Me.lblObjectTypeID.TabIndex = 7
        Me.lblObjectTypeID.Text = "Bộ phận tiếp nhận"
        Me.lblObjectTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObjectName
        '
        Me.txtObjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtObjectName.Location = New System.Drawing.Point(833, 35)
        Me.txtObjectName.Name = "txtObjectName"
        Me.txtObjectName.ReadOnly = True
        Me.txtObjectName.Size = New System.Drawing.Size(173, 20)
        Me.txtObjectName.TabIndex = 10
        Me.txtObjectName.TabStop = False
        '
        'tdbcEmployeeID
        '
        Me.tdbcEmployeeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcEmployeeID.AllowColMove = False
        Me.tdbcEmployeeID.AllowColSelect = True
        Me.tdbcEmployeeID.AllowSort = False
        Me.tdbcEmployeeID.AlternatingRows = True
        Me.tdbcEmployeeID.AutoCompletion = True
        Me.tdbcEmployeeID.AutoDropDown = True
        Me.tdbcEmployeeID.Caption = ""
        Me.tdbcEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcEmployeeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcEmployeeID.DisplayMember = "EmployeeID"
        Me.tdbcEmployeeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcEmployeeID.DropDownWidth = 500
        Me.tdbcEmployeeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcEmployeeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcEmployeeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcEmployeeID.EmptyRows = True
        Me.tdbcEmployeeID.ExtendRightColumn = True
        Me.tdbcEmployeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcEmployeeID.Images.Add(CType(resources.GetObject("tdbcEmployeeID.Images"), System.Drawing.Image))
        Me.tdbcEmployeeID.Location = New System.Drawing.Point(620, 67)
        Me.tdbcEmployeeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcEmployeeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcEmployeeID.MaxLength = 32767
        Me.tdbcEmployeeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcEmployeeID.Name = "tdbcEmployeeID"
        Me.tdbcEmployeeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcEmployeeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcEmployeeID.Size = New System.Drawing.Size(103, 21)
        Me.tdbcEmployeeID.TabIndex = 12
        Me.tdbcEmployeeID.ValueMember = "EmployeeID"
        Me.tdbcEmployeeID.PropBag = resources.GetString("tdbcEmployeeID.PropBag")
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeID.Location = New System.Drawing.Point(479, 72)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(82, 13)
        Me.lblEmployeeID.TabIndex = 11
        Me.lblEmployeeID.Text = "Người tiếp nhận"
        Me.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtEmployeeName.Location = New System.Drawing.Point(729, 67)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(195, 20)
        Me.txtEmployeeName.TabIndex = 13
        Me.txtEmployeeName.TabStop = False
        '
        'tdbcObjectID
        '
        Me.tdbcObjectID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcObjectID.AllowColSelect = True
        Me.tdbcObjectID.AllowSort = False
        Me.tdbcObjectID.AlternatingRows = True
        Me.tdbcObjectID.AutoDropDown = True
        Me.tdbcObjectID.Caption = ""
        Me.tdbcObjectID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcObjectID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcObjectID.DisplayMember = "ObjectID"
        Me.tdbcObjectID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.RightDown
        Me.tdbcObjectID.DropDownWidth = 500
        Me.tdbcObjectID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcObjectID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcObjectID.EmptyRows = True
        Me.tdbcObjectID.ExtendRightColumn = True
        Me.tdbcObjectID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectID.Images.Add(CType(resources.GetObject("tdbcObjectID.Images"), System.Drawing.Image))
        Me.tdbcObjectID.Location = New System.Drawing.Point(727, 34)
        Me.tdbcObjectID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcObjectID.MaxDropDownItems = CType(8, Short)
        Me.tdbcObjectID.MaxLength = 32767
        Me.tdbcObjectID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcObjectID.Name = "tdbcObjectID"
        Me.tdbcObjectID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcObjectID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcObjectID.Size = New System.Drawing.Size(103, 21)
        Me.tdbcObjectID.TabIndex = 9
        Me.tdbcObjectID.ValueMember = "ObjectID"
        Me.tdbcObjectID.PropBag = resources.GetString("tdbcObjectID.PropBag")
        '
        'D02F2013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.tdbcObjectID)
        Me.Controls.Add(Me.tdbcEmployeeID)
        Me.Controls.Add(Me.lblEmployeeID)
        Me.Controls.Add(Me.txtEmployeeName)
        Me.Controls.Add(Me.tdbcObjectTypeID)
        Me.Controls.Add(Me.lblObjectTypeID)
        Me.Controls.Add(Me.txtObjectName)
        Me.Controls.Add(Me.tdbcManagementObjectID)
        Me.Controls.Add(Me.txtManagementObjectName)
        Me.Controls.Add(Me.tdbcManagementObjectTypeID)
        Me.Controls.Add(Me.lblManagementObjectTypeID)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.chkIsStopDepre)
        Me.Controls.Add(Me.tdbcEffectReasonID)
        Me.Controls.Add(Me.btnNextD09F2130)
        Me.Controls.Add(Me.grp3)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAllToLeft)
        Me.Controls.Add(Me.btnToLeft)
        Me.Controls.Add(Me.btnAllToRight)
        Me.Controls.Add(Me.btnToRight)
        Me.Controls.Add(Me.lblEffectReasonID)
        Me.Controls.Add(Me.btnFilter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F2013"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lãc tªi s¶n - D02F2013"
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbgRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.tdbgLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp1.ResumeLayout(False)
        Me.grp3.ResumeLayout(False)
        CType(Me.tdbdAssetConditionalID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcEffectReasonID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcManagementObjectTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcManagementObjectID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcObjectTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcEmployeeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcObjectID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnAllToLeft As System.Windows.Forms.Button
    Private WithEvents btnToLeft As System.Windows.Forms.Button
    Private WithEvents btnAllToRight As System.Windows.Forms.Button
    Private WithEvents btnToRight As System.Windows.Forms.Button

    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbgLeft As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grp3 As System.Windows.Forms.GroupBox
    Private WithEvents tdbgRight As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnNextD09F2130 As System.Windows.Forms.Button
    Private WithEvents chkIsStopDepre As System.Windows.Forms.CheckBox
    Private WithEvents tdbcEffectReasonID As C1.Win.C1List.C1Combo
    Private WithEvents lblEffectReasonID As System.Windows.Forms.Label
    Private WithEvents btnView As System.Windows.Forms.Button
    Private WithEvents tdbdAssetConditionalID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents txtManagementObjectName As System.Windows.Forms.TextBox
    Private WithEvents tdbcManagementObjectTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblManagementObjectTypeID As System.Windows.Forms.Label
    Private WithEvents tdbcManagementObjectID As C1.Win.C1List.C1Combo
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents tdbcEmployeeID As C1.Win.C1List.C1Combo
    Private WithEvents lblEmployeeID As System.Windows.Forms.Label
    Private WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Private WithEvents tdbcObjectTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblObjectTypeID As System.Windows.Forms.Label
    Private WithEvents txtObjectName As System.Windows.Forms.TextBox
    Private WithEvents tdbcObjectID As C1.Win.C1List.C1Combo
End Class