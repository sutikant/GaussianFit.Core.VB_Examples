# GaussianFit.Core VB Examples

Example WinForms project demonstrating how to use the **GaussianFit.Core** library  
for performing **2D Gaussian fitting** on bitmap/image data in Visual Basic .NET.

---

## 🧠 Overview

This project provides a **Visual Basic .NET WinForms** demo that uses the  
[`GaussianFit.Core`](https://www.nuget.org/packages/GaussianFit.Core) library to perform  
2D Gaussian fitting on grayscale or intensity images.

It demonstrates:
- Background subtraction using **EdgeMean** or **Percentile** methods.  
- Parameter configuration through interactive UI (TrackBars, ComboBoxes).  
- 2D Gaussian model fitting with Levenberg–Marquardt optimization.  
- Visualization of fitted ellipses for:
  - Green = 1σ boundary (~68% energy)
  - Orange = FWHM/2 (~1.177σ)
  - Blue = 1/e² (radius = 2σ)
- Display of fit statistics such as SSE, RMSE, normalized RMSE, and quality grade.

---

## 🧩 Installation

Install the core library via NuGet:
   ```bash
   dotnet add package GaussianFit.Core
```
---

## 🧰 UI Components
| Section                    | Controls                                            | Description                               |
| -------------------------- | --------------------------------------------------- | ----------------------------------------- |
| **Background Subtraction** | Mode (ComboBox), Edge Mask Size (%), Percentile (%) | Select preprocessing mode and parameters. |
| **Gaussian Model Fitting** | Cutoff (%), Max Iterations, ε (epsilon)             | Configure fitting parameters.             |
| **Visualization**          | PictureBox for input/output                         | Shows original and fitted overlay images. |
| **Buttons**                | “Load Image” and “Gaussian Fit”                     | Load image and execute fitting.           |

---

## 💡 Example Code

Below is the main section that performs the fitting and visualization:

```vbnet
Private Sub btnGaussianFit_Click(sender As Object, e As EventArgs) Handles btnGaussianFit.Click
    If _currentBitmap Is Nothing Then
        MessageBox.Show("Please load an image first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return
    End If

    Try
        Dim opts As New FitOptions()
        opts.Mode = _mode
        opts.BorderPercent = _borderPercentage
        opts.PercentileP = _percentileP
        opts.CutoffPercent = _cutoffPercentage
        opts.MaxIterations = _maxIterations
        opts.Epsilon = _epsStop

        Dim fit As FitResult = GaussianFitter.Run(_currentBitmap, opts)
        rtbFit.Text = fit.ReportText

        Dim msg As String = String.Format(
            "Center (x0, y0): {0:F2}, {1:F2}" & vbCrLf &
            "σx, σy: {2:F3}, {3:F3}" & vbCrLf &
            "FWHM X, Y: {4:F3}, {5:F3}" & vbCrLf &
            "nRMSE: {6:P2} [{7}]",
            fit.X0, fit.Y0, fit.SigmaX, fit.SigmaY,
            fit.FwhmX, fit.FwhmY, fit.NormalizedRmse, fit.QualityGrade
        )

        MessageBox.Show(msg, "Fit Results", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Draw overlay ellipses (1σ, FWHM/2, 1/e²)
        Using vis As Bitmap = CType(_currentBitmap.Clone(), Bitmap)
            Using g As Graphics = Graphics.FromImage(vis)
                g.SmoothingMode = SmoothingMode.AntiAlias
                Dim cx As Single = CSng(fit.X0)
                Dim cy As Single = CSng(fit.Y0)
                g.DrawLine(Pens.Red, cx - 8, cy, cx + 8, cy)
                g.DrawLine(Pens.Red, cx, cy - 8, cx, cy + 8)

                Dim DrawE As Action(Of Pen, Double, Double) =
                    Sub(pen As Pen, rx As Double, ry As Double)
                        g.DrawEllipse(pen, CSng(cx - rx), CSng(cy - ry), CSng(2 * rx), CSng(2 * ry))
                    End Sub

                Using pen1 As New Pen(Color.Green, 1),
                      pen2 As New Pen(Color.Orange, 1),
                      pen3 As New Pen(Color.Blue, 1)
                    DrawE(pen1, fit.Overlay.OneSigma.Rx, fit.Overlay.OneSigma.Ry)
                    DrawE(pen2, fit.Overlay.FwhmHalf.Rx, fit.Overlay.FwhmHalf.Ry)
                    DrawE(pen3, fit.Overlay.OneOverE2.Rx, fit.Overlay.OneOverE2.Ry)
                End Using
            End Using
            picOutput.Image = CType(vis.Clone(), Bitmap)
        End Using

    Catch ex As Exception
        MessageBox.Show("Gaussian Fit failed:" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```
---

## 📊 Output Example

When fitting completes successfully, you’ll see a dialog like:
```
Center (x0, y0): 124.52, 132.33
σx, σy: 5.214, 5.097
FWHM X, Y: 12.280, 12.010
nRMSE (RMSE/A):  0.0312 %   [Excellent]
```

And the output image will display 3 overlaid ellipses:  

🟢 Green = 1σ  
🟠 Orange = FWHM/2  
🔵 Blue = 1/e² boundary  

---
## How to Run
1. Clone this repository  
2. Open `TestDll.sln` in Visual Studio  
3. Build and Run (F5)
4. Load an image and press "Gaussian Fit"

---

## ⚠ Troubleshooting: "Mark of the Web" Error in Visual Studio
If you download this project as a ZIP file and open it directly in Visual Studio, you might see an error like this:
```vbnet
Couldn't process file Form1.resx due to its being in the Internet or Restricted zone
or having the mark of the web on the file.
```
### 💡 Cause

Windows automatically marks downloaded files from the internet with a security flag (“Mark of the Web”).
Visual Studio blocks those files for safety reasons.

### ✅ Solution

Option 1 – Recommended (Before extracting ZIP):
1. Right-click the downloaded .zip file.
2. Select Properties.
3. Check the box Unblock at the bottom of the window.
4. Click Apply → OK.
5. Then extract (unzip) and open the project in Visual Studio again.

Option 2 – Clone directly:
If you use Git, you can clone the repository directly (this avoids the problem entirely):

```bash
git clone https://github.com/sutikant/GaussianFit.Core.VB_Examples.git
```
---

## 📄 License
MIT License © 2025 Napat Sutikant
