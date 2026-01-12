# GaussianFit.Core VB Examples (v1.1.0)

Example WinForms project demonstrating how to use the **GaussianFit.Core** library **v1.1.0**  
for performing **2D Gaussian fitting** on bitmap/image data in Visual Basic .NET.

---

## 🧠 Overview

This project provides a **Visual Basic .NET WinForms** demo that uses the  
[`GaussianFit.Core`](https://www.nuget.org/packages/GaussianFit.Core) library (v1.1.0+) to perform  
2D Gaussian fitting on grayscale or intensity images.

**What’s new in v1.1.0**
- ✅ **ROI support** (crop internally, results reported in original image coordinates)
- ✅ Clean separation of *crop/local* vs *original* coordinates
- ✅ Report text includes ROI metadata when used
- ✅ Backward compatible: works exactly the same when ROI is not provided

It demonstrates:
- Background subtraction using **EdgeMean** or **Percentile** methods.  
- Parameter configuration through interactive UI (TrackBars, ComboBoxes).  
- Optional **fixed ROI** for production use (noise suppression near edges).  
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
| **Background Subtraction** | Mode, Edge Mask Size (%), Percentile (%)             | Select preprocessing mode and parameters. |
| **Gaussian Model Fitting** | Cutoff (%), Max Iterations, ε (epsilon)              | Configure fitting parameters.             |
| **ROI (optional)**         | Fixed rectangle (x, y, w, h)                          | Limit fitting area without changing output coordinates. |
| **Visualization**          | PictureBox for input/output                          | Shows original and fitted overlay images. |
| **Buttons**                | “Load Image” and “Gaussian Fit”                      | Load image and execute fitting.           |

---

## 💡 Example Code (No ROI – default behavior)

```vbnet
Dim opts As New FitOptions() With {
    .Mode = PrepMode.EdgeMean_BorderPct,
    .BorderPercent = 10.0,
    .CutoffPercent = 30.0,
    .MaxIterations = 200,
    .Epsilon = 1.0E-9
}

Dim fit As FitResult = GaussianFitter.Run(_currentBitmap, opts)

Console.WriteLine($"Center (orig): x={fit.X0:F2}, y={fit.Y0:F2}")
```

---

## 💡 Example Code (With ROI – **recommended for production**)

```vbnet
' Fixed parameters (lock for production)
Dim roi As New RoiRect(202, 163, 750, 750)

Dim opts As New FitOptions() With {
    .Mode = PrepMode.EdgeMean_BorderPct,
    .BorderPercent = 10.0,
    .CutoffPercent = 30.0,
    .MaxIterations = 500,
    .Epsilon = 1.0E-9
}

Dim fit As FitResult = GaussianFitter.Run(_currentBitmap, roi, opts)

' IMPORTANT:
' fit.X0, fit.Y0 are ALWAYS in ORIGINAL image coordinates
Console.WriteLine($"Center (orig): x={fit.X0:F2}, y={fit.Y0:F2}")
```

✔ Internally, the image is cropped to ROI for computation  
✔ Results are **automatically compensated back** to original coordinates  
✔ No coordinate drift in downstream systems

---

## 📄 Fit Report (v1.1.0)

When ROI is used, the report includes:
```
ROI (original)  = x=202, y=163, w=750, h=750
x0, y0 (orig)   = 524.31, 487.92
```

This makes debugging and production validation much easier.

---

## 🖼️ Sample images

This repo includes a `sample_pic/` folder with test images.  
All images are marked as **Content** and **Copy to Output Directory = Copy if newer**,  
so after you build, they will appear under:
```
bin\<Configuration>\sample_pic
```

---

## 📊 Output Example

```
Center (x0, y0): 524.31, 487.92
σx, σy: 5.214, 5.097
FWHM X, Y: 12.280, 12.010
nRMSE (RMSE/A):  0.0312 %   [Excellent]
```

---

## ⚠ Troubleshooting: "Mark of the Web" Error in Visual Studio

If you download this project as a ZIP file and open it directly in Visual Studio, you might see:
```
Couldn't process file Form1.resx due to its being in the Internet or Restricted zone
```

### ✅ Solution (Recommended)
1. Right-click the downloaded `.zip`
2. Select **Properties**
3. Check **Unblock**
4. Click **Apply → OK**
5. Extract and reopen the solution

Or clone directly:
```bash
git clone https://github.com/sutikant/GaussianFit.Core.VB_Examples.git
```

---

## 📄 License
MIT License © 2025 Napat Sutikant

