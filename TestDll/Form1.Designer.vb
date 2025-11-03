<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.picInput = New System.Windows.Forms.PictureBox()
        Me.picOutput = New System.Windows.Forms.PictureBox()
        Me.rtbFit = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.modeCombo = New System.Windows.Forms.ComboBox()
        Me.percentileLabel = New System.Windows.Forms.Label()
        Me.percentileTrackBar = New System.Windows.Forms.TrackBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.borderLabel = New System.Windows.Forms.Label()
        Me.borderTrackBar = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnGaussianFit = New System.Windows.Forms.Button()
        Me.cutoffLabel = New System.Windows.Forms.Label()
        Me.cutoffTrackBar = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.epsStopCombo = New System.Windows.Forms.ComboBox()
        Me.maxIterCombo = New System.Windows.Forms.ComboBox()
        CType(Me.picInput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.percentileTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.borderTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cutoffTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Image = Global.TestDll.My.Resources.Resources.load_pic
        Me.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoad.Location = New System.Drawing.Point(10, 10)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(135, 51)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "Load Image"
        Me.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'picInput
        '
        Me.picInput.Location = New System.Drawing.Point(149, 218)
        Me.picInput.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picInput.Name = "picInput"
        Me.picInput.Size = New System.Drawing.Size(390, 280)
        Me.picInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picInput.TabIndex = 1
        Me.picInput.TabStop = False
        '
        'picOutput
        '
        Me.picOutput.Location = New System.Drawing.Point(543, 218)
        Me.picOutput.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picOutput.Name = "picOutput"
        Me.picOutput.Size = New System.Drawing.Size(390, 280)
        Me.picOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picOutput.TabIndex = 2
        Me.picOutput.TabStop = False
        '
        'rtbFit
        '
        Me.rtbFit.Location = New System.Drawing.Point(937, 12)
        Me.rtbFit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rtbFit.Name = "rtbFit"
        Me.rtbFit.Size = New System.Drawing.Size(437, 688)
        Me.rtbFit.TabIndex = 3
        Me.rtbFit.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.modeCombo)
        Me.GroupBox1.Controls.Add(Me.percentileLabel)
        Me.GroupBox1.Controls.Add(Me.percentileTrackBar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.borderLabel)
        Me.GroupBox1.Controls.Add(Me.borderTrackBar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(149, 11)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(390, 202)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Background Substraction"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 30)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Mode"
        '
        'modeCombo
        '
        Me.modeCombo.FormattingEnabled = True
        Me.modeCombo.Location = New System.Drawing.Point(136, 28)
        Me.modeCombo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.modeCombo.Name = "modeCombo"
        Me.modeCombo.Size = New System.Drawing.Size(150, 21)
        Me.modeCombo.TabIndex = 6
        '
        'percentileLabel
        '
        Me.percentileLabel.AutoSize = True
        Me.percentileLabel.Location = New System.Drawing.Point(314, 127)
        Me.percentileLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.percentileLabel.Name = "percentileLabel"
        Me.percentileLabel.Size = New System.Drawing.Size(10, 13)
        Me.percentileLabel.TabIndex = 5
        Me.percentileLabel.Text = "-"
        '
        'percentileTrackBar
        '
        Me.percentileTrackBar.Location = New System.Drawing.Point(136, 138)
        Me.percentileTrackBar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.percentileTrackBar.Name = "percentileTrackBar"
        Me.percentileTrackBar.Size = New System.Drawing.Size(211, 45)
        Me.percentileTrackBar.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 138)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Percentile"
        '
        'borderLabel
        '
        Me.borderLabel.AutoSize = True
        Me.borderLabel.Location = New System.Drawing.Point(314, 60)
        Me.borderLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.borderLabel.Name = "borderLabel"
        Me.borderLabel.Size = New System.Drawing.Size(10, 13)
        Me.borderLabel.TabIndex = 2
        Me.borderLabel.Text = "-"
        '
        'borderTrackBar
        '
        Me.borderTrackBar.Location = New System.Drawing.Point(136, 72)
        Me.borderTrackBar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.borderTrackBar.Name = "borderTrackBar"
        Me.borderTrackBar.Size = New System.Drawing.Size(211, 45)
        Me.borderTrackBar.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 72)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Edge Mask Size (%)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGaussianFit)
        Me.GroupBox2.Controls.Add(Me.cutoffLabel)
        Me.GroupBox2.Controls.Add(Me.cutoffTrackBar)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.epsStopCombo)
        Me.GroupBox2.Controls.Add(Me.maxIterCombo)
        Me.GroupBox2.Location = New System.Drawing.Point(543, 12)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(390, 202)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gaussian Model Fitting"
        '
        'btnGaussianFit
        '
        Me.btnGaussianFit.Image = Global.TestDll.My.Resources.Resources.fit_pic
        Me.btnGaussianFit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGaussianFit.Location = New System.Drawing.Point(227, 75)
        Me.btnGaussianFit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnGaussianFit.Name = "btnGaussianFit"
        Me.btnGaussianFit.Size = New System.Drawing.Size(136, 51)
        Me.btnGaussianFit.TabIndex = 6
        Me.btnGaussianFit.Text = "Gaussian Fit"
        Me.btnGaussianFit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGaussianFit.UseVisualStyleBackColor = True
        '
        'cutoffLabel
        '
        Me.cutoffLabel.AutoSize = True
        Me.cutoffLabel.Location = New System.Drawing.Point(276, 18)
        Me.cutoffLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.cutoffLabel.Name = "cutoffLabel"
        Me.cutoffLabel.Size = New System.Drawing.Size(10, 13)
        Me.cutoffLabel.TabIndex = 3
        Me.cutoffLabel.Text = "-"
        '
        'cutoffTrackBar
        '
        Me.cutoffTrackBar.Location = New System.Drawing.Point(94, 29)
        Me.cutoffTrackBar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cutoffTrackBar.Name = "cutoffTrackBar"
        Me.cutoffTrackBar.Size = New System.Drawing.Size(211, 45)
        Me.cutoffTrackBar.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 115)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 39)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Covergence && " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Acceptance " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Criteria (ε)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 78)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Max. Iteration"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 29)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cutoff Percentage"
        '
        'epsStopCombo
        '
        Me.epsStopCombo.FormattingEnabled = True
        Me.epsStopCombo.Location = New System.Drawing.Point(94, 122)
        Me.epsStopCombo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.epsStopCombo.Name = "epsStopCombo"
        Me.epsStopCombo.Size = New System.Drawing.Size(114, 21)
        Me.epsStopCombo.TabIndex = 1
        '
        'maxIterCombo
        '
        Me.maxIterCombo.FormattingEnabled = True
        Me.maxIterCombo.Location = New System.Drawing.Point(94, 75)
        Me.maxIterCombo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.maxIterCombo.Name = "maxIterCombo"
        Me.maxIterCombo.Size = New System.Drawing.Size(114, 21)
        Me.maxIterCombo.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1398, 720)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rtbFit)
        Me.Controls.Add(Me.picOutput)
        Me.Controls.Add(Me.picInput)
        Me.Controls.Add(Me.btnLoad)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "Test Dll: Gaussian Fit Demo (VB)"
        CType(Me.picInput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.percentileTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.borderTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cutoffTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnLoad As Button
    Friend WithEvents picInput As PictureBox
    Friend WithEvents picOutput As PictureBox
    Friend WithEvents rtbFit As RichTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents epsStopCombo As ComboBox
    Friend WithEvents maxIterCombo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents borderLabel As Label
    Friend WithEvents borderTrackBar As TrackBar
    Friend WithEvents btnGaussianFit As Button
    Friend WithEvents cutoffLabel As Label
    Friend WithEvents cutoffTrackBar As TrackBar
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents modeCombo As ComboBox
    Friend WithEvents percentileLabel As Label
    Friend WithEvents percentileTrackBar As TrackBar
    Friend WithEvents Label6 As Label
End Class
