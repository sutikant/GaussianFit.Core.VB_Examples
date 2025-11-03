Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports GaussianFit.Core

Public Class Form1
    ' === Fields (State and Cache) ===
    ' Parameters (state)
    Private _borderPercentage As Double = 10.0   ' 0..50 %
    Private _cutoffPercentage As Double = 30.0   ' 1..100 %
    Private _maxIterations As Integer = 60       ' 5..200
    Private _epsStop As Double = 0.000000001          ' 1e-6 / 1e-9 / 1e-12

    ' NEW: Mode and percentile value (for Percentile mode)
    Private _mode As PrepMode = PrepMode.EdgeMean_BorderPct
    Private _percentileP As Double = 10.0        ' 0.1 .. 50.0 %

    Private _currentBitmap As Bitmap             ' The latest loaded image.

    ' Cache (optionally used by your pipeline)
    Private _gray8 As Byte()
    Private _w As Integer, _h As Integer

    ' After BG subtraction + threshold (optional)
    Private _afterThreshF64 As Double()

    ' === Helpers ===
    Private Sub UpdatePreprocessUiEnableState()
        Dim isPercentile As Boolean = (_mode = PrepMode.Percentile_GlobalP)

        ' Enable p% controls only when Percentile mode
        percentileTrackBar.Enabled = isPercentile
        percentileLabel.Enabled = isPercentile

        ' Border% is used only for EdgeMean mode
        borderTrackBar.Enabled = Not isPercentile
        borderLabel.Enabled = Not isPercentile
    End Sub

    ' === Form Initialization and Loading ===
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        ' --- Border % TrackBar (0..50.0) ---
        borderTrackBar.Minimum = 0
        borderTrackBar.Maximum = 500           ' x10
        borderTrackBar.TickFrequency = 50
        borderTrackBar.Value = CInt(_borderPercentage * 10.0)
        borderTrackBar.Width = 240

        borderLabel.AutoSize = True
        borderLabel.Text = _borderPercentage.ToString("F1", CultureInfo.InvariantCulture) & " %"

        ' --- Cutoff % TrackBar (1.0..100.0) ---
        cutoffTrackBar.Minimum = 10            ' 1.0%
        cutoffTrackBar.Maximum = 1000          ' 100.0%
        cutoffTrackBar.TickFrequency = 50
        cutoffTrackBar.Value = CInt(_cutoffPercentage * 10.0)
        cutoffTrackBar.Width = 240

        cutoffLabel.AutoSize = True
        cutoffLabel.Text = _cutoffPercentage.ToString("F1", CultureInfo.InvariantCulture) & " %"

        ' --- Max Iteration Combo (5..200 step 5) ---
        maxIterCombo.DropDownStyle = ComboBoxStyle.DropDownList
        maxIterCombo.Items.Clear()
        For i As Integer = 5 To 200 Step 5
            maxIterCombo.Items.Add(i.ToString())
        Next
        maxIterCombo.SelectedItem = _maxIterations.ToString()

        ' --- Epsilon Combo ---
        epsStopCombo.DropDownStyle = ComboBoxStyle.DropDownList
        epsStopCombo.Items.Clear()
        epsStopCombo.Items.Add("1e-6")
        epsStopCombo.Items.Add("1e-9")
        epsStopCombo.Items.Add("1e-12")
        epsStopCombo.SelectedItem = "1e-9"

        ' === Mode Combo ===
        modeCombo.DropDownStyle = ComboBoxStyle.DropDownList
        modeCombo.Items.Clear()
        modeCombo.Items.Add("Edge Mean (border %)")
        modeCombo.Items.Add("Percentile p% (global)")
        modeCombo.SelectedIndex = 0 ' default = EdgeMean

        ' === Percentile TrackBar (0.1 .. 50.0, step 0.1) ===
        percentileTrackBar.Minimum = 1      ' 0.1%
        percentileTrackBar.Maximum = 500    ' 50.0%
        percentileTrackBar.TickFrequency = 10
        percentileTrackBar.Value = CInt(_percentileP * 10.0)
        percentileLabel.Text = _percentileP.ToString("F1", CultureInfo.InvariantCulture) & " %"

        UpdatePreprocessUiEnableState()

    End Sub

    ' === UI Event Handlers (Input/Configuration) ===
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Using ofd As New OpenFileDialog()
            Dim exeDir As String = AppDomain.CurrentDomain.BaseDirectory
            Dim sampleDir As String = Path.Combine(exeDir, "sample_pic")
            If Not Directory.Exists(sampleDir) Then Directory.CreateDirectory(sampleDir)

            ofd.InitialDirectory = sampleDir
            ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                If _currentBitmap IsNot Nothing Then _currentBitmap.Dispose()
                _currentBitmap = CType(System.Drawing.Image.FromFile(ofd.FileName), Bitmap)

                If picInput.Image IsNot Nothing Then picInput.Image.Dispose()
                picInput.Image = CType(_currentBitmap.Clone(), Bitmap)

                rtbFit.Clear()
            End If
        End Using
    End Sub

    Private Sub borderTrackBar_Scroll(sender As Object, e As EventArgs) Handles borderTrackBar.Scroll
        _borderPercentage = borderTrackBar.Value / 10.0
        borderLabel.Text = _borderPercentage.ToString("F1", CultureInfo.InvariantCulture) & " %"
    End Sub

    Private Sub cutoffTrackBar_Scroll(sender As Object, e As EventArgs) Handles cutoffTrackBar.Scroll
        _cutoffPercentage = cutoffTrackBar.Value / 10.0
        cutoffLabel.Text = _cutoffPercentage.ToString("F1", CultureInfo.InvariantCulture) & " %"
    End Sub

    Private Sub maxIterCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles maxIterCombo.SelectedIndexChanged
        Dim v As Integer
        If Integer.TryParse(Convert.ToString(maxIterCombo.SelectedItem), v) Then
            _maxIterations = v
        End If
    End Sub

    Private Shared Function ParseSci(s As String) As Double
        Dim v As Double
        If Double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, v) Then
            Return v
        End If
        Return 0.000000001
    End Function

    Private Sub epsStopCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles epsStopCombo.SelectedIndexChanged
        _epsStop = ParseSci(Convert.ToString(epsStopCombo.SelectedItem))
    End Sub

    Private Sub modeCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles modeCombo.SelectedIndexChanged
        _mode = If(modeCombo.SelectedIndex = 0, PrepMode.EdgeMean_BorderPct, PrepMode.Percentile_GlobalP)
        UpdatePreprocessUiEnableState()
    End Sub

    Private Sub percentileTrackBar_Scroll(sender As Object, e As EventArgs) Handles percentileTrackBar.Scroll
        _percentileP = percentileTrackBar.Value / 10.0 ' step 0.1
        percentileLabel.Text = _percentileP.ToString("F1", CultureInfo.InvariantCulture) & " %"
    End Sub

    ' === Core Functionality (Gaussian Fit) ===
    Private Sub btnGaussianFit_Click(sender As Object, e As EventArgs) Handles btnGaussianFit.Click
        If _currentBitmap Is Nothing Then
            MessageBox.Show("Please load an image first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Create options to match the UI settings
            Dim opts As New FitOptions()
            opts.Mode = _mode
            opts.BorderPercent = _borderPercentage      ' Used for EdgeMean mode
            opts.PercentileP = _percentileP             ' Used for Percentile mode
            opts.CutoffPercent = _cutoffPercentage
            opts.MaxIterations = _maxIterations
            opts.Epsilon = _epsStop

            ' Call the DLL (new API)
            Dim fit As FitResult = GaussianFitter.Run(_currentBitmap, opts)

            ' Full report
            rtbFit.Text = fit.ReportText

            ' ---- Build nRMSE line for MessageBox (like C#) ----
            Dim nrmsePct As Double = If(Double.IsNaN(fit.NormalizedRmse), Double.NaN, fit.NormalizedRmse * 100.0)
            Dim nrmseLine As String
            If Double.IsNaN(nrmsePct) Then
                nrmseLine = "nRMSE (RMSE/A):     NaN %   [Poor]"
            Else
                Dim pctText As String =
                    If(nrmsePct >= 0.01,
                       nrmsePct.ToString("F2", CultureInfo.InvariantCulture),
                       nrmsePct.ToString("E2", CultureInfo.InvariantCulture))
                Dim grade As String = If(String.IsNullOrEmpty(fit.QualityGrade), "—", fit.QualityGrade)
                nrmseLine = String.Format(CultureInfo.InvariantCulture,
                                          "nRMSE (RMSE/A): {0,10} %   [{1}]", pctText, grade)
            End If

            ' Compact summary
            Dim msg As String = String.Format(CultureInfo.InvariantCulture,
                "Center (x0, y0): {0:F2}, {1:F2}" & Environment.NewLine &
                "σx, σy: {2:F3}, {3:F3}" & Environment.NewLine &
                "FWHM X, Y: {4:F3}, {5:F3}" & Environment.NewLine &
                "{6}",
                fit.X0, fit.Y0, fit.SigmaX, fit.SigmaY, fit.FwhmX, fit.FwhmY, nrmseLine)

            MessageBox.Show(msg, "Fit Results", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' ---- Draw overlay (same as C#) ----
            Using vis As Bitmap = CType(_currentBitmap.Clone(), Bitmap)
                Using g As Graphics = Graphics.FromImage(vis)
                    g.SmoothingMode = SmoothingMode.AntiAlias
                    Dim cx As Single = CSng(fit.X0)
                    Dim cy As Single = CSng(fit.Y0)

                    ' crosshair
                    g.DrawLine(Pens.Red, cx - 8, cy, cx + 8, cy)
                    g.DrawLine(Pens.Red, cx, cy - 8, cx, cy + 8)

                    ' helper to draw ellipse by radii
                    Dim DrawE As Action(Of Pen, Double, Double) =
                        Sub(pen As Pen, rx As Double, ry As Double)
                            Dim rect As New RectangleF(CSng(cx - rx), CSng(cy - ry),
                                                       CSng(2 * rx), CSng(2 * ry))
                            g.DrawEllipse(pen, rect)
                        End Sub

                    Using pen1 As New Pen(Color.Green, 1),
                          pen2 As New Pen(Color.Orange, 1),
                          pen3 As New Pen(Color.Blue, 1)
                        DrawE(pen1, fit.Overlay.OneSigma.Rx, fit.Overlay.OneSigma.Ry)
                        DrawE(pen2, fit.Overlay.FwhmHalf.Rx, fit.Overlay.FwhmHalf.Ry)
                        DrawE(pen3, fit.Overlay.OneOverE2.Rx, fit.Overlay.OneOverE2.Ry)
                    End Using
                End Using

                If picOutput.Image IsNot Nothing Then picOutput.Image.Dispose()
                picOutput.Image = CType(vis.Clone(), Bitmap)
            End Using

        Catch ex As Exception
            MessageBox.Show("Gaussian Fit failed:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class
