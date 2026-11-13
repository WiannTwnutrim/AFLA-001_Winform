# PathDrawing 1.0.5 使用說明

適用 .NET 8 Windows Forms；本套件不適用 .NET Framework 4.x。

## 安裝與更新

在 Visual Studio「工具 → NuGet 套件管理員 → 套件管理員設定 → 套件來源」新增本 packages 資料夾，並在目標專案安裝 PathDrawing 1.0.5。建置後重新開啟表單設計工具，在工具箱搜尋 PipeControl（管線）及 ValveControl（閥門），手臂只提供 Arm1Control、Arm2Control 兩個工具箱項目。

從舊版更新時，在目標專案的 NuGet 套件管理員選擇本機來源，將 PathDrawing 更新至 1.0.5，建置後重新開啟設計工具。若工具箱尚未出現元件，重新啟動 Visual Studio 並確認專案實際引用版本為 1.0.5。

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

同一份 PathDrawing.dll 包含可拖曳的 PipeControl、ValveControl、Arm1Control、Arm2Control，並保留原本 PathDrawer API（含 DrawArm）。

## Arm1Control / Arm2Control：透明背景手臂

工具箱只顯示 Arm1Control、Arm2Control；ArmControl 保留為相容基底，不列入工具箱。兩個手臂只繪製銀色 ARM，不包含上接管或橫向管線。

手臂在 OnPaint 中繪製，BackColor 預設 Transparent，由 WinForms 繪製父容器的背景（包含父容器 OnPaint 的圖案）。父容器背景可在 OnPaint 繪製；透明區域會顯示該背景。ARM1／ARM2 使用圓筒輪廓 Region，輪廓外可顯示同層管線，兩者維持獨立控制項。手臂請使用 BringToFront() 疊在管線上。

Arm1Control 預設 Angle = 30，Arm2Control 預設 Angle = -30。Angle 可設 -180～180；Size 等比例縮放並置中，Location 決定位置。InletPoint 回傳手臂頂端中心的控制項內座標。雙擊可建立 Click 事件。

FlowColor 僅保留舊程式相容性，已從屬性視窗隱藏，不再影響手臂外觀。


## 液位桶 LevelTankControl（1.0.5）
工具箱元件名稱：LevelTankControl。金屬桶身、液體與 0、25、50、75、100 刻度由控制項繪製。
Level：0～100 的 float 百分比，預設 50，拒絕超出範圍及非有限數值。
LiquidColor：液體顏色，預設 Gold。ForeColor 控制刻度顏色。
LevelChanged：液位變動事件。請在 UI 執行緒更新控制項。

```csharp
var tank = new PathDrawing.LevelTankControl
{
    Location = new Point(20, 20),
    Size = new Size(100, 130),
    Level = 50,
    LiquidColor = Color.Gold
};
Controls.Add(tank);
tank.Level = 75;
tank.LiquidColor = Color.DodgerBlue;
```

建議 Size 使用 100×130 或更大，避免刻度文字因縮小而難以閱讀。


液位桶背景修正：LevelTankControl 現在以桶身、刻度線及文字輪廓設定 Control.Region，外圍空白與刻度間隙不會遮擋同層管線。調整尺寸、DPI 或重建視窗時自動更新輪廓。請使用 BringToFront() 將桶身疊在接管處上方。

## 刻度字型設定（1.0.5 同版本更新）
LevelTankControl 現在支援 Font 屬性，可在 Visual Studio 屬性視窗設定字型、大小與粗體。
例如：levelTankControl1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
ForeColor 控制刻度顏色。Font 沿用標準 WinForms 字型繼承與設計工具序列化行為。
刻度按 Font 實際大小與 DPI 繪製，不再跟著桶身縮放；字型變動時會同步重建透明輪廓，保留外圍與刻度間隙透出管線的效果。
字體加大時請增加控制項寬度及高度，避免文字超出邊界或刻度互相重疊。主程式首頁已設定 Segoe UI 8pt Bold。
本次套件仍為1.0.5，使用NuGet者須依同版本更新步驟重新安裝，僅覆蓋nupkg不會更新既有快取。

## 桶頂外觀更新（1.0.5）
移除 LevelTankControl 頂端突出的小接口，桶頂保留圓弧金屬外形。同步移除接口的視窗 Region，原接口位置不再遮擋管線。液位、顏色、Font 與刻度功能維持原設定。

## Pipe／Valve 外圍透明修正（1.0.5，1112 主程式）
PipeControl 依實際12單位管徑、圓角彎頭與三通路徑設定原生視窗 Region；ValveControl 依三角閥身與中央圓形設定 Region。輪廓外空白不再遮住同層其他圖片或控制項，實體圖形交疊仍由前後順序決定。
改變 Size、DPI、Pipe.Shape／BendX／BendY、Valve.Orientation 時會自動重建輪廓。FlowColor、ForeColor 與既有事件用法維持不變。
主程式更新目標為1112分支，直接引用PathDrawing專案，重新建置即可。其他使用NuGet的專案仍須依上述同版本1.0.5更新步驟重新安裝，覆蓋nupkg不會自動替換已還原的快取。

## 柱狀元件 ColumnControl（1.0.5）
從工具箱拖入 ColumnControl，即可使用屬性調色：
- OuterColor：外框、頂蓋與底座整體顏色，預設 SkyBlue。
- InnerColor：中央八片環形圖案顏色，預設 Firebrick。
- ChamberColor：中央內腔底色，預設 DimGray。
- Size／Location：大小與位置，預設140×180，等比例顯示。
例如 columnControl1.OuterColor = Color.LimeGreen;
columnControl1.InnerColor = Color.Gold;
columnControl1.ChamberColor = Color.DimGray;
使用原生 Region 裁切外框與底座輪廓，外圍空白不遮擋其他圖片或管線；實體部分仍依控制項前後順序顯示。Click 可用於接入 HMI 操作。
主程式1112首頁右側已加入 columnControl1（預設藍色外框、紅色環片），未綁定設備訊號，可直接以屬性連接現有狀態邏輯。
套件維持1.0.5：ProjectReference 專案重建即可；NuGet 使用者需依同版本更新流程重新安裝，避免沿用舊快取。

## PipeWidth 管徑設定（1.0.5／1113）
PipeControl 新增 PipeWidth 屬性，可在 Visual Studio 屬性視窗「管路」類別直接設定，預設12，支援1～512的float數值。
例如：pipeControl1.PipeWidth = 20F;
控制項 Size 決定長度與可用空間，PipeWidth 決定管身粗細；管壁、流體、反光及透明輪廓會同步依比例調整，適用直管、彎管、三通。
數值為96 DPI繪圖單位，隨螢幕DPI調整；控制項尺寸不足時自動縮小，要顯示較粗管身請增大Size。彎點靠邊時管身超出控制項的部分會被裁切。
小於1、大於512、NaN與Infinity會拒絕。既有元件未設定此屬性時維持原12單位外觀。
主程式1113使用ProjectReference，已同步原始碼並重建。NuGet使用者須依同版本更新流程重新安裝1.0.5以替換舊快取。
