# PathDrawing 1.0.4 使用說明

適用 .NET 8 Windows Forms；本套件不適用 .NET Framework 4.x。

## 安裝與更新

在 Visual Studio「工具 → NuGet 套件管理員 → 套件管理員設定 → 套件來源」新增本 packages 資料夾，並在目標專案安裝 PathDrawing 1.0.4。建置後重新開啟表單設計工具，在工具箱搜尋 PipeControl（管線）及 ValveControl（閥門），另有 ArmControl（ARM 圓筒），三者皆可拖入表單。

從舊版更新時，在目標專案的 NuGet 套件管理員選擇本機來源，將 PathDrawing 更新至 1.0.4，建置後重新開啟設計工具。若工具箱尚未出現三個元件，重新啟動 Visual Studio 並確認專案實際引用版本為 1.0.4。


### 目前 1111 分支與同版本更新

1111 分支的 AFLA-001.csproj 直接 ProjectReference 到 ../PathDrawing/PathDrawing.csproj。此模式修改 PathDrawing/ArmControl.cs 並重建主程式即可生效，不需要重新安裝 NuGet。關閉再開啟表單設計工具後，選取 ArmControl，應能看到 Shape 與 FlowColor 屬性。

若其他專案使用 NuGet 版，這次仍沿用 1.0.4 版本號；只更換 packages 裡的 nupkg 不保證 NuGet 已安裝的快取會更新。請關閉設計工具，確認實際使用的 PathDrawing 1.0.4 套件位置，清除該版本舊快取後從本機來源重新安裝，再重建專案並重新開啟設計工具。若直接引用 DLL，則將引用指向更新後的 PathDrawing.dll。只有版本號為 1.0.4，不能證明已載入最新內容；ArmControl 是否具有 Shape、FlowColor 才是本次更新的辨識方式。

## 將自己的類別庫輸出為 DLL 與 NuGet 套件

本專案的類別庫為 PathDrawing/PathDrawing.csproj。先安裝支援 .NET 8 的 SDK 與 Windows Forms 開發環境，在 PowerShell 切換到方案根目錄，再執行下列指令。

### 1. 確認類別庫設定

目前 PathDrawing.csproj 使用以下設定；Version 決定套件版本，未另外設定 PackageId 時，套件名稱預設沿用專案名稱 PathDrawing。

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>1.0.4</Version>
    <PackageReadmeFile>README.md</PackageReadmeFile>
    <TargetFramework>net8.0-windows</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>
  <ItemGroup>
    <None Update="README.md" Pack="true" PackagePath="/" />
  </ItemGroup>
</Project>
```

此設定適用本專案的 Windows Forms 自訂控制項。README.md 必須存在於 PathDrawing 資料夾，封裝時會一併放入套件。

### 2. 建置 DLL

```powershell
Set-Location 'C:\Users\wiann\Desktop\code\AFLA-001_Winform'
dotnet build .\PathDrawing\PathDrawing.csproj -c Release
```

輸出 DLL：`PathDrawing\bin\Release\net8.0-windows\PathDrawing.dll`。

PipeControl、ValveControl、ArmControl 等 public 類別會包含在同一個 PathDrawing.dll 中，不會各自輸出一份 DLL。不要把單一 .cs 原始碼改副檔名當成 DLL，必須經過建置。

### 3. 封裝為 NuGet 套件

```powershell
dotnet pack .\PathDrawing\PathDrawing.csproj -c Release -o .\packages
```

這個指令預設會還原相依套件、建置類別庫，再產生 `packages\PathDrawing.1.0.4.nupkg`。一般更新使用這個指令即可，不需要先手動執行 build。

`.dll` 是可供程式引用的組件；`.nupkg` 是裝有 DLL、版本與相依資訊的 NuGet 套件。封裝不會自動上傳到 nuget.org。可將整個 nupkg 提供給其他專案，並將其所在的 packages 資料夾設為本機 NuGet 來源。

若只是更新說明文件，而且 Release DLL 已是最新版本，可省略重建：

```powershell
dotnet pack .\PathDrawing\PathDrawing.csproj -c Release -o .\packages --no-build --no-restore
```

修改過 .cs 程式碼時請使用前面的正常 pack 指令，避免把舊 DLL 包進新套件。

### 4. 檢查與使用輸出

用壓縮檔工具開啟 nupkg，在 `lib` 下對應目標框架的資料夾確認有 PathDrawing.dll，並確認根目錄包含 README.md。NuGet 的目標框架資料夾名稱可能帶有 Windows 平台版本，與 bin 的資料夾名稱不一定完全相同。

使用 NuGet 時安裝 nupkg；使用手動組件引用時，選取 Release 輸出的 PathDrawing.dll。兩種方式擇一即可。1111 分支目前直接引用 PathDrawing 專案，因此日常修改後重建主程式即可；pack 是提供其他專案安裝或交付時使用。

後續發布新版本可修改 csproj 的 Version（例如 1.0.5），再執行 pack，會產生對應版本的 nupkg。本次依原要求維持 1.0.4，覆蓋同版本套件時仍需留意前述 NuGet 快取。

## 設計畫面操作

拖入 PipeControl，選取後按 F4。在「管路」分類調整 Shape、BendX、BendY、FlowColor；在 Size 調整 Width、Height，Location 決定整個控制項的位置。

| Shape | 接通方向 | 圖形 |
|---|---|---|
| Horizontal | 左右 | ─ |
| Vertical | 上下 | │ |
| LeftUp | 左、上 | ┘ |
| LeftDown | 左、下 | ┐ |
| RightUp | 右、上 | └ |
| RightDown | 右、下 | ┌ |
| TeeRight | 上、下、右 | ├ |

## 調整長度與轉折點

Width、Height 決定整個控制項的大小。直管使用 Width（水平方向）或 Height（垂直方向）調整長度，維持置中，不受 BendX、BendY 影響。

彎管的 BendX 為轉折點距左側的百分比，BendY 為距上側的百分比；範圍 0～100，預設均為 50。數值超出範圍會拋出例外。0 或 100 會使對應的一段縮成零，邊界處管壁可能被裁切，一般請保留適當邊距。

- 左側水平段長度 = Width × BendX / 100。
- 右側水平段長度 = Width × (100 − BendX) / 100。
- 上側垂直段長度 = Height × BendY / 100。
- 下側垂直段長度 = Height × (100 − BendY) / 100。

例如 Size = 200 × 120、Shape = LeftUp、BendX = 75、BendY = 25，水平段約 150 像素、垂直段約 30 像素（依目前控制項客戶區計算，繪圖有整數取整）。改 BendX 只調水平段，改 BendY 只調垂直段；端點會隨轉折點移動，並非固定在邊緣中央。TeeRight 的主管位於 BendX，向右支管高度位於 BendY。

## 調整顏色

FlowColor 設為 Orange、Gold、DeepSkyBlue 等顏色，可改變管內流體顏色；設為 Color.Empty 回到預設金屬色。設計工具可對 FlowColor 按右鍵「重設」。BackColor 為控制項背景，預設 Transparent；不會改變流體顏色。WinForms 透明背景顯示父容器背景，不能任意透出重疊的兄弟控制項。

```csharp
pipeControl1.Shape = PathDrawing.PipeShape.LeftUp;
pipeControl1.Size = new Size(200, 120);
pipeControl1.BendX = 75;
pipeControl1.BendY = 25;
pipeControl1.FlowColor = Color.Orange;

// 閥門切換時同步更新流體顏色，控制項會自動重畫。
pipeControl1.FlowColor = gluepic.ForeColor == Color.LimeGreen
    ? Color.Orange : Color.Empty;
```

拖拉定位是 Visual Studio 設計階段功能，控制項未提供執行階段滑鼠拖曳。

## ValveControl：閥門

沿用原有 DrawValve 圖形，無須自行處理 Paint 或輸入座標。在工具箱拖入 ValveControl，按 F4 設定：

| 屬性 | 用法 |
|---|---|
| Size | 調整閥門寬、高；預設 36 × 48 |
| Location | 移動整個閥門 |
| Orientation | Vertical 上下接管（預設）；Horizontal 左右接管，建議大小 48 × 36 |
| ForeColor | 閥門漸層顏色，預設 Silver；可設 LimeGreen 表示開啟 |
| BackColor | 背景，預設 Transparent |

雙擊閥門可建立 Click 事件。控制項只負責顯示，不會自動切換狀態或控制設備；確認視窗、設備命令與管線變色由使用它的表單處理。例如：

```csharp
private bool valveOpen;

private void valveControl1_Click(object sender, EventArgs e)
{
    // 若需要確認視窗，在切換前加入既有 ShowDialog 判斷。
    valveOpen = !valveOpen;
    valveControl1.ForeColor = valveOpen ? Color.LimeGreen : Color.Silver;
    pipeControl1.FlowColor = valveOpen ? Color.Orange : Color.Empty;
}
```

ForeColor 及 FlowColor 改變時會自動重畫。新閥門使用標準 Click 事件，不必另外綁定 PictureBox 的 PaintValve。既有 HomeForm 的 PictureBox 不會自動轉成 ValveControl；需要在設計工具替換並重新連接原本的操作邏輯。

## 套件內容

同一份 PathDrawing.dll 包含可拖曳的 PipeControl、ValveControl、ArmControl，並保留原本 PathDrawer API（含 DrawArm）。

## ArmControl：ARM1 / ARM2 完整接管組件

在工具箱拖入兩個 ArmControl，按 F4，在「ARM」分類設定 Shape。使用現有 ArmControl 即可，不需要另外尋找 Arm1Control 或 Arm2Control。

| 屬性 | 用法 |
|---|---|
| Shape | Arm1（預設）：右側銀色圓筒，包含上方直管與右側橫管；Arm2：左側細圓筒，包含上方直管與下方接頭 |
| Angle | 未自訂時，Arm1 自動使用 30 度，Arm2 自動使用 -30 度；可自訂 -180～180 度 |
| FlowColor | 接管流體顏色，與外接 PipeControl.FlowColor 設為相同值即可；Empty 使用預設金屬色 |
| Size | 預設 142 × 124；筒身與接管位置依可用範圍等比例縮放，接管粗細維持與一般 PipeControl 相同的 DPI 管徑 |
| Location | 移動整個組件，將上方直管或右側橫管中心對準外部管線 |
| BackColor | 預設 Transparent，顯示父容器背景 |

接管和筒身繪製於同一個控制項，先畫接管、再畫筒身，避免內建接管被 ARM 的透明背景遮住。接管共用 PathDrawer.DrawFlowPipe 的四層金屬配色，標準 DPI 下外徑為 12 像素，與 PipeControl 一致。極小控制項仍可能縮小或不顯示圖形，請保留足夠空間。

Angle 的 0 度表示接口朝下，正角度使下端向左傾斜，負角度使下端向右傾斜。自訂 Angle 後切換 Shape 會保留自訂角度；在屬性視窗對 Angle 按右鍵「重設」，即可恢復該 Shape 的預設角度。舊表單若已儲存 Angle，切換 Shape 後也建議先重設 Angle。

```csharp
arm1Control.Shape = PathDrawing.ArmShape.Arm1; // 右側完整組件
arm1Control.ResetAngle();                    // 使用預設 30 度
arm2Control.Shape = PathDrawing.ArmShape.Arm2; // 左側完整組件
arm2Control.ResetAngle();                    // 使用預設 -30 度

// 外接管與 ARM 內建接管使用相同流體顏色。
pipeControl1.FlowColor = Color.Orange;
arm1Control.FlowColor = pipeControl1.FlowColor;

// 回到預設金屬色。
arm2Control.FlowColor = Color.Empty;
```

InletPoint 為唯讀 PointF，回傳筒身接管接口在控制項內的位置，並非最上方直管的外接端點。位置、角度或大小改變後需重新取得；在同一父容器內可加上 Location 換算座標。

FlowColor 只影響接管，筒身保持銀色；ForeColor 不控制筒身金屬色。Click 為標準事件，控制項未內建設備動作或動畫。外部獨立 PipeControl 與 ArmControl 仍需以端點對接，WinForms 的 Transparent 不會透出重疊的同層控制項。