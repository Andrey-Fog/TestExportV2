<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.lblRecordsInFile = New System.Windows.Forms.Label()
        Me.lblTestType = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.ChckLstBoxEnableResults = New System.Windows.Forms.CheckedListBox()
        Me.lblEnabledData = New System.Windows.Forms.Label()
        Me.lblTestAbout = New System.Windows.Forms.Label()
        Me.lbltest = New System.Windows.Forms.Label()
        Me.Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ComboBoxXAxis = New System.Windows.Forms.ComboBox()
        Me.ComboBoxYAxis = New System.Windows.Forms.ComboBox()
        Me.cmdRedraw = New System.Windows.Forms.Button()
        Me.txtFirstPoint = New System.Windows.Forms.TextBox()
        Me.txtLastPoint = New System.Windows.Forms.TextBox()
        Me.lblFirstPoint = New System.Windows.Forms.Label()
        Me.lblLastPoint = New System.Windows.Forms.Label()
        Me.HScrollBarFirstPoint = New System.Windows.Forms.HScrollBar()
        Me.MenuStrip.SuspendLayout()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.DataToolStripMenuItem, Me.ExportToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(671, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.DataToolStripMenuItem.Text = "Data"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelToolStripMenuItem, Me.TextFileToolStripMenuItem})
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'TextFileToolStripMenuItem
        '
        Me.TextFileToolStripMenuItem.Name = "TextFileToolStripMenuItem"
        Me.TextFileToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.TextFileToolStripMenuItem.Text = "Text file"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(12, 34)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(51, 13)
        Me.lblFileName.TabIndex = 1
        Me.lblFileName.Text = "FileName"
        '
        'lblRecordsInFile
        '
        Me.lblRecordsInFile.AutoSize = True
        Me.lblRecordsInFile.Location = New System.Drawing.Point(170, 95)
        Me.lblRecordsInFile.Name = "lblRecordsInFile"
        Me.lblRecordsInFile.Size = New System.Drawing.Size(82, 13)
        Me.lblRecordsInFile.TabIndex = 2
        Me.lblRecordsInFile.Text = "lblRecordsInFile"
        '
        'lblTestType
        '
        Me.lblTestType.AutoSize = True
        Me.lblTestType.Location = New System.Drawing.Point(12, 56)
        Me.lblTestType.Name = "lblTestType"
        Me.lblTestType.Size = New System.Drawing.Size(51, 13)
        Me.lblTestType.TabIndex = 3
        Me.lblTestType.Text = "Test type"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(534, 552)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(125, 27)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'ChckLstBoxEnableResults
        '
        Me.ChckLstBoxEnableResults.Enabled = False
        Me.ChckLstBoxEnableResults.FormattingEnabled = True
        Me.ChckLstBoxEnableResults.Location = New System.Drawing.Point(487, 72)
        Me.ChckLstBoxEnableResults.Name = "ChckLstBoxEnableResults"
        Me.ChckLstBoxEnableResults.Size = New System.Drawing.Size(113, 109)
        Me.ChckLstBoxEnableResults.TabIndex = 6
        '
        'lblEnabledData
        '
        Me.lblEnabledData.AutoSize = True
        Me.lblEnabledData.Enabled = False
        Me.lblEnabledData.Location = New System.Drawing.Point(484, 56)
        Me.lblEnabledData.Name = "lblEnabledData"
        Me.lblEnabledData.Size = New System.Drawing.Size(74, 13)
        Me.lblEnabledData.TabIndex = 7
        Me.lblEnabledData.Text = "Data structure"
        '
        'lblTestAbout
        '
        Me.lblTestAbout.AutoSize = True
        Me.lblTestAbout.Location = New System.Drawing.Point(12, 95)
        Me.lblTestAbout.Name = "lblTestAbout"
        Me.lblTestAbout.Size = New System.Drawing.Size(66, 39)
        Me.lblTestAbout.TabIndex = 8
        Me.lblTestAbout.Text = "lblTestAbout" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0"
        '
        'lbltest
        '
        Me.lbltest.AutoSize = True
        Me.lbltest.Location = New System.Drawing.Point(83, 179)
        Me.lbltest.Name = "lbltest"
        Me.lbltest.Size = New System.Drawing.Size(34, 13)
        Me.lbltest.TabIndex = 9
        Me.lbltest.Text = "lbltest"
        '
        'Chart
        '
        Me.Chart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Sunken
        ChartArea1.Name = "ChartArea1"
        Me.Chart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart.Legends.Add(Legend1)
        Me.Chart.Location = New System.Drawing.Point(69, 220)
        Me.Chart.Name = "Chart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart.Series.Add(Series1)
        Me.Chart.Size = New System.Drawing.Size(590, 285)
        Me.Chart.TabIndex = 10
        Me.Chart.Text = "Chart1"
        '
        'ComboBoxXAxis
        '
        Me.ComboBoxXAxis.FormattingEnabled = True
        Me.ComboBoxXAxis.Location = New System.Drawing.Point(545, 511)
        Me.ComboBoxXAxis.Name = "ComboBoxXAxis"
        Me.ComboBoxXAxis.Size = New System.Drawing.Size(114, 21)
        Me.ComboBoxXAxis.TabIndex = 11
        Me.ComboBoxXAxis.Text = "X axis"
        '
        'ComboBoxYAxis
        '
        Me.ComboBoxYAxis.FormattingEnabled = True
        Me.ComboBoxYAxis.Location = New System.Drawing.Point(0, 220)
        Me.ComboBoxYAxis.Name = "ComboBoxYAxis"
        Me.ComboBoxYAxis.Size = New System.Drawing.Size(63, 21)
        Me.ComboBoxYAxis.TabIndex = 12
        Me.ComboBoxYAxis.Text = "Y axis"
        '
        'cmdRedraw
        '
        Me.cmdRedraw.Location = New System.Drawing.Point(86, 552)
        Me.cmdRedraw.Name = "cmdRedraw"
        Me.cmdRedraw.Size = New System.Drawing.Size(125, 27)
        Me.cmdRedraw.TabIndex = 5
        Me.cmdRedraw.Text = "Redraw"
        Me.cmdRedraw.UseVisualStyleBackColor = True
        '
        'txtFirstPoint
        '
        Me.txtFirstPoint.Location = New System.Drawing.Point(98, 610)
        Me.txtFirstPoint.Name = "txtFirstPoint"
        Me.txtFirstPoint.Size = New System.Drawing.Size(86, 20)
        Me.txtFirstPoint.TabIndex = 13
        Me.txtFirstPoint.Text = "1"
        '
        'txtLastPoint
        '
        Me.txtLastPoint.Location = New System.Drawing.Point(98, 636)
        Me.txtLastPoint.Name = "txtLastPoint"
        Me.txtLastPoint.Size = New System.Drawing.Size(86, 20)
        Me.txtLastPoint.TabIndex = 14
        Me.txtLastPoint.Text = "1000"
        '
        'lblFirstPoint
        '
        Me.lblFirstPoint.AutoSize = True
        Me.lblFirstPoint.Location = New System.Drawing.Point(23, 614)
        Me.lblFirstPoint.Name = "lblFirstPoint"
        Me.lblFirstPoint.Size = New System.Drawing.Size(52, 13)
        Me.lblFirstPoint.TabIndex = 15
        Me.lblFirstPoint.Text = "First point"
        '
        'lblLastPoint
        '
        Me.lblLastPoint.AutoSize = True
        Me.lblLastPoint.Location = New System.Drawing.Point(26, 639)
        Me.lblLastPoint.Name = "lblLastPoint"
        Me.lblLastPoint.Size = New System.Drawing.Size(53, 13)
        Me.lblLastPoint.TabIndex = 16
        Me.lblLastPoint.Text = "Last point"
        '
        'HScrollBarFirstPoint
        '
        Me.HScrollBarFirstPoint.Location = New System.Drawing.Point(187, 610)
        Me.HScrollBarFirstPoint.Name = "HScrollBarFirstPoint"
        Me.HScrollBarFirstPoint.Size = New System.Drawing.Size(472, 20)
        Me.HScrollBarFirstPoint.TabIndex = 19
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 696)
        Me.Controls.Add(Me.HScrollBarFirstPoint)
        Me.Controls.Add(Me.lblLastPoint)
        Me.Controls.Add(Me.lblFirstPoint)
        Me.Controls.Add(Me.txtLastPoint)
        Me.Controls.Add(Me.txtFirstPoint)
        Me.Controls.Add(Me.ComboBoxYAxis)
        Me.Controls.Add(Me.ComboBoxXAxis)
        Me.Controls.Add(Me.Chart)
        Me.Controls.Add(Me.lbltest)
        Me.Controls.Add(Me.lblTestAbout)
        Me.Controls.Add(Me.lblEnabledData)
        Me.Controls.Add(Me.ChckLstBoxEnableResults)
        Me.Controls.Add(Me.cmdRedraw)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblTestType)
        Me.Controls.Add(Me.lblRecordsInFile)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.MenuStrip)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMain"
        Me.Text = "TestExport  v 2.0"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents lblRecordsInFile As System.Windows.Forms.Label
    Friend WithEvents lblTestType As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents ChckLstBoxEnableResults As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblEnabledData As System.Windows.Forms.Label
    Friend WithEvents lblTestAbout As System.Windows.Forms.Label
    Friend WithEvents lbltest As System.Windows.Forms.Label
    Friend WithEvents Chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ComboBoxXAxis As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxYAxis As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRedraw As System.Windows.Forms.Button
    Friend WithEvents txtFirstPoint As System.Windows.Forms.TextBox
    Friend WithEvents txtLastPoint As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstPoint As System.Windows.Forms.Label
    Friend WithEvents lblLastPoint As System.Windows.Forms.Label
    Friend WithEvents DataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HScrollBarFirstPoint As System.Windows.Forms.HScrollBar

End Class
