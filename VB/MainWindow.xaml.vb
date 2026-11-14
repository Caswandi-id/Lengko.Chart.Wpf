Imports System
Imports System.Windows
Imports System.Windows.Media
Imports Lengko.Chart.Wpf

Class MainWindow

    Private _isDark As Boolean = False
    Private ReadOnly _rand As New Random()

    Public Sub New()
        InitializeComponent()
        AddHandler Loaded, AddressOf MainWindow_Loaded
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs)
        PopulateAllCharts()
    End Sub

    Private Sub PopulateAllCharts()
        ' Tab 1: Bars & Columns (6 charts)
        BarChart.Categories.Add("Q1")
        BarChart.Categories.Add("Q2")
        BarChart.Categories.Add("Q3")
        BarChart.Categories.Add("Q4")
        BarChart.Series.Add(New LengkoBarSeries("Revenue", New Double() {120, 150, 180, 220}, Color.FromRgb(59, 130, 246)))
        BarChart.Series.Add(New LengkoBarSeries("Profit", New Double() {45, 60, 75, 95}, Color.FromRgb(16, 185, 129)))

        HBarChart.AddItem("TypeScript", 88, Color.FromRgb(59, 130, 246))
        HBarChart.AddItem("C# / .NET", 94, Color.FromRgb(139, 92, 246))
        HBarChart.AddItem("Python", 82, Color.FromRgb(245, 158, 11))
        HBarChart.AddItem("Go", 75, Color.FromRgb(6, 182, 212))
        HBarChart.AddItem("Rust", 70, Color.FromRgb(239, 68, 68))

        StackedBarChart.Categories.Add("2021")
        StackedBarChart.Categories.Add("2022")
        StackedBarChart.Categories.Add("2023")
        StackedBarChart.Categories.Add("2024")
        StackedBarChart.Series.Add(New LengkoBarSeries("Cloud", New Double() {40, 55, 75, 110}, Color.FromRgb(59, 130, 246)))
        StackedBarChart.Series.Add(New LengkoBarSeries("On-Prem", New Double() {60, 50, 45, 30}, Color.FromRgb(16, 185, 129)))
        StackedBarChart.Series.Add(New LengkoBarSeries("Support", New Double() {20, 25, 30, 35}, Color.FromRgb(245, 158, 11)))

        HistogramChart.SetData(New Double() {18, 22, 25, 27, 30, 32, 34, 35, 38, 40, 42, 44, 45, 48, 52, 55, 60, 65, 72}, 6)

        ParetoChart.Items.Add(New LengkoParetoItem("Timeout 504", 142))
        ParetoChart.Items.Add(New LengkoParetoItem("Auth 401", 95))
        ParetoChart.Items.Add(New LengkoParetoItem("NullRef", 48))
        ParetoChart.Items.Add(New LengkoParetoItem("DB Lock", 24))
        ParetoChart.Items.Add(New LengkoParetoItem("Bad Format", 12))

        WaterfallChart.Items.Add(New LengkoWaterfallItem("Start Cash", 120, isTotal:=True))
        WaterfallChart.Items.Add(New LengkoWaterfallItem("Product Sales", 52))
        WaterfallChart.Items.Add(New LengkoWaterfallItem("Subscriptions", 30))
        WaterfallChart.Items.Add(New LengkoWaterfallItem("Salaries", -42))
        WaterfallChart.Items.Add(New LengkoWaterfallItem("Cloud Hosting", -18))
        WaterfallChart.Items.Add(New LengkoWaterfallItem("Marketing", -14))
        WaterfallChart.Items.Add(New LengkoWaterfallItem("Net End Cash", 0, isTotal:=True))

        ' Tab 2: Lines & Areas (6 charts)
        LineChart.Series.Add(New LengkoLineSeries("Traffic (k)", New Double() {22, 34, 45, 40, 58, 65, 80}, Color.FromRgb(99, 102, 241)))
        LineChart.Series.Add(New LengkoLineSeries("Signups", New Double() {10, 18, 24, 28, 35, 42, 55}, Color.FromRgb(236, 72, 153)))

        AreaChart.Labels.Add("Jan")
        AreaChart.Labels.Add("Feb")
        AreaChart.Labels.Add("Mar")
        AreaChart.Labels.Add("Apr")
        AreaChart.Labels.Add("May")
        AreaChart.Labels.Add("Jun")
        AreaChart.Series.Add(New LengkoAreaSeries("Inbound", New Double() {30, 45, 52, 68, 74, 90}, Color.FromRgb(59, 130, 246)))
        AreaChart.Series.Add(New LengkoAreaSeries("Outbound", New Double() {18, 25, 32, 40, 48, 62}, Color.FromRgb(16, 185, 129)))

        StackedAreaChart.Categories.Add("Jan")
        StackedAreaChart.Categories.Add("Feb")
        StackedAreaChart.Categories.Add("Mar")
        StackedAreaChart.Categories.Add("Apr")
        StackedAreaChart.Categories.Add("May")
        StackedAreaChart.Categories.Add("Jun")
        StackedAreaChart.Series.Add(New LengkoAreaSeries("North", New Double() {25, 30, 38, 45, 52, 60}, Color.FromRgb(14, 165, 233)))
        StackedAreaChart.Series.Add(New LengkoAreaSeries("South", New Double() {20, 24, 30, 36, 42, 48}, Color.FromRgb(168, 85, 247)))
        StackedAreaChart.Series.Add(New LengkoAreaSeries("East", New Double() {15, 18, 22, 28, 32, 38}, Color.FromRgb(249, 115, 22)))

        StepLineChart.Series.Add(New LengkoStepSeries("Inventory", New Double() {100, 85, 85, 60, 120, 95, 70}, Color.FromRgb(16, 185, 129)))
        StepLineChart.Series.Add(New LengkoStepSeries("Threshold", New Double() {50, 50, 50, 50, 50, 50, 50}, Color.FromRgb(239, 68, 68)))

        ComboChart.Categories.Add("Q1")
        ComboChart.Categories.Add("Q2")
        ComboChart.Categories.Add("Q3")
        ComboChart.Categories.Add("Q4")
        ComboChart.BarSeries.Add(New LengkoBarSeries("Units Sold", New Double() {320, 450, 580, 710}, Color.FromRgb(59, 130, 246)))
        ComboChart.LineSeries.Add(New LengkoLineSeries("Margin %", New Double() {22, 28, 26, 31}, Color.FromRgb(239, 68, 68)))

        GenericChart.AddPoint("CPU", 48)
        GenericChart.AddPoint("RAM", 72)
        GenericChart.AddPoint("Disk", 60)
        GenericChart.AddPoint("Network", 35)
        GenericChart.AddPoint("GPU", 84)

        ' Tab 3: Circular & Polar (5 charts)
        PieChart.Slices.Add(New LengkoPieSlice("North America", 38, Color.FromRgb(59, 130, 246)))
        PieChart.Slices.Add(New LengkoPieSlice("Europe", 27, Color.FromRgb(16, 185, 129)))
        PieChart.Slices.Add(New LengkoPieSlice("Asia Pacific", 23, Color.FromRgb(245, 158, 11)))
        PieChart.Slices.Add(New LengkoPieSlice("Latin America", 12, Color.FromRgb(239, 68, 68)))

        DonutChart.Slices.Add(New LengkoPieSlice("Enterprise", 45, Color.FromRgb(99, 102, 241)))
        DonutChart.Slices.Add(New LengkoPieSlice("SMB", 30, Color.FromRgb(236, 72, 153)))
        DonutChart.Slices.Add(New LengkoPieSlice("Startup", 15, Color.FromRgb(20, 184, 166)))
        DonutChart.Slices.Add(New LengkoPieSlice("Consumer", 10, Color.FromRgb(245, 158, 11)))

        RadarChart.Axes.Add("Speed")
        RadarChart.Axes.Add("Reliability")
        RadarChart.Axes.Add("Usability")
        RadarChart.Axes.Add("Security")
        RadarChart.Axes.Add("Scalability")
        RadarChart.Series.Add(New LengkoRadarSeries("Lengko UI", New Double() {92, 95, 88, 90, 94}, Color.FromRgb(139, 92, 246)))
        RadarChart.Series.Add(New LengkoRadarSeries("Standard", New Double() {65, 70, 60, 75, 68}, Color.FromRgb(148, 163, 184)))

        PolarChart.Items.Add(New LengkoPolarItem("North", 45, Color.FromRgb(59, 130, 246)))
        PolarChart.Items.Add(New LengkoPolarItem("NE", 60, Color.FromRgb(99, 102, 241)))
        PolarChart.Items.Add(New LengkoPolarItem("East", 80, Color.FromRgb(139, 92, 246)))
        PolarChart.Items.Add(New LengkoPolarItem("SE", 50, Color.FromRgb(236, 72, 153)))
        PolarChart.Items.Add(New LengkoPolarItem("South", 35, Color.FromRgb(244, 63, 94)))
        PolarChart.Items.Add(New LengkoPolarItem("SW", 55, Color.FromRgb(245, 158, 11)))
        PolarChart.Items.Add(New LengkoPolarItem("West", 75, Color.FromRgb(16, 185, 129)))
        PolarChart.Items.Add(New LengkoPolarItem("NW", 40, Color.FromRgb(20, 184, 166)))

        SunburstChart.Items.Add(New LengkoSunburstItem("Software", 60, 0, Color.FromRgb(59, 130, 246)))
        SunburstChart.Items.Add(New LengkoSunburstItem("Hardware", 40, 0, Color.FromRgb(16, 185, 129)))
        SunburstChart.Items.Add(New LengkoSunburstItem("Desktop", 35, 1, Color.FromRgb(99, 102, 241)))
        SunburstChart.Items.Add(New LengkoSunburstItem("Mobile", 25, 1, Color.FromRgb(14, 165, 233)))
        SunburstChart.Items.Add(New LengkoSunburstItem("Servers", 25, 1, Color.FromRgb(34, 197, 94)))
        SunburstChart.Items.Add(New LengkoSunburstItem("IoT", 15, 1, Color.FromRgb(245, 158, 11)))

        ' Tab 4: Financial & Timelines (3 charts)
        CandleChart.AddCandle("09:30", open:=150.2, high:=153.5, low:=149.8, close:=152.8, volume:=142000)
        CandleChart.AddCandle("10:00", open:=152.8, high:=154.0, low:=151.2, close:=151.6, volume:=98000)
        CandleChart.AddCandle("10:30", open:=151.6, high:=155.2, low:=151.0, close:=154.5, volume:=175000)
        CandleChart.AddCandle("11:00", open:=154.5, high:=156.0, low:=153.8, close:=155.8, volume:=110000)
        CandleChart.AddCandle("11:30", open:=155.8, high:=156.2, low:=153.0, close:=153.4, volume:=130000)

        OhlcChart.Bars.Add(New LengkoOhlcBar("Mon", 100, 108, 98, 105))
        OhlcChart.Bars.Add(New LengkoOhlcBar("Tue", 105, 110, 102, 104))
        OhlcChart.Bars.Add(New LengkoOhlcBar("Wed", 104, 114, 103, 112))
        OhlcChart.Bars.Add(New LengkoOhlcBar("Thu", 112, 115, 108, 109))
        OhlcChart.Bars.Add(New LengkoOhlcBar("Fri", 109, 118, 107, 116))

        Dim baseDate As DateTime = DateTime.Today
        GanttChart.Tasks.Add(New LengkoGanttItem("Architecture & API", baseDate, baseDate.AddDays(5), progress:=100))
        GanttChart.Tasks.Add(New LengkoGanttItem("Core Chart Engine", baseDate.AddDays(3), baseDate.AddDays(10), progress:=80))
        GanttChart.Tasks.Add(New LengkoGanttItem("32 WPF Controls", baseDate.AddDays(6), baseDate.AddDays(15), progress:=55))
        GanttChart.Tasks.Add(New LengkoGanttItem("Testing & Packaging", baseDate.AddDays(12), baseDate.AddDays(18), progress:=20))

        ' Tab 5: Hierarchy & Flow (5 charts)
        TreemapChart.Items.Add(New LengkoTreemapItem("Finance", 420))
        TreemapChart.Items.Add(New LengkoTreemapItem("Engineering", 350))
        TreemapChart.Items.Add(New LengkoTreemapItem("Marketing", 220))
        TreemapChart.Items.Add(New LengkoTreemapItem("Support", 160))
        TreemapChart.Items.Add(New LengkoTreemapItem("Legal & HR", 90))

        SankeyChart.Links.Add(New LengkoSankeyLink("Organic Search", "Landing Page", 140))
        SankeyChart.Links.Add(New LengkoSankeyLink("Paid Ads", "Landing Page", 90))
        SankeyChart.Links.Add(New LengkoSankeyLink("Referral", "Product Specs", 65))
        SankeyChart.Links.Add(New LengkoSankeyLink("Landing Page", "Pricing", 130))
        SankeyChart.Links.Add(New LengkoSankeyLink("Landing Page", "Checkout", 70))
        SankeyChart.Links.Add(New LengkoSankeyLink("Pricing", "Checkout", 100))
        SankeyChart.Links.Add(New LengkoSankeyLink("Product Specs", "Checkout", 45))

        FunnelChart.Stages.Add(New LengkoFunnelStage("Website Visits", 12500))
        FunnelChart.Stages.Add(New LengkoFunnelStage("Sign Up", 5200))
        FunnelChart.Stages.Add(New LengkoFunnelStage("Cart Added", 2800))
        FunnelChart.Stages.Add(New LengkoFunnelStage("Checkout Started", 1600))
        FunnelChart.Stages.Add(New LengkoFunnelStage("Purchased", 1100))

        PyramidChart.Stages.Add(New LengkoPyramidStage("Executives", 8))
        PyramidChart.Stages.Add(New LengkoPyramidStage("Directors", 24))
        PyramidChart.Stages.Add(New LengkoPyramidStage("Team Leads", 65))
        PyramidChart.Stages.Add(New LengkoPyramidStage("Specialists", 180))
        PyramidChart.Stages.Add(New LengkoPyramidStage("Associates", 340))

        HeatmapChart.RowLabels.Add("Mon")
        HeatmapChart.RowLabels.Add("Tue")
        HeatmapChart.RowLabels.Add("Wed")
        HeatmapChart.RowLabels.Add("Thu")
        HeatmapChart.RowLabels.Add("Fri")
        HeatmapChart.ColumnLabels.Add("09:00")
        HeatmapChart.ColumnLabels.Add("12:00")
        HeatmapChart.ColumnLabels.Add("15:00")
        HeatmapChart.ColumnLabels.Add("18:00")
        HeatmapChart.ColumnLabels.Add("21:00")
        Dim matrix(,) As Double = {
            {20, 45, 78, 60, 30},
            {35, 60, 92, 85, 40},
            {40, 75, 95, 80, 50},
            {30, 65, 88, 70, 45},
            {25, 50, 70, 90, 65}
        }
        For r As Integer = 0 To 4
            For c As Integer = 0 To 4
                HeatmapChart.SetCell(r, c, matrix(r, c))
            Next
        Next

        ' Tab 6: KPIs & Statistical (7 charts)
        GaugeChart.Value = 76.5
        GaugeChart.Title = "Server Load"
        GaugeChart.Unit = "%"

        BulletChart.Title = "YTD Sales"
        BulletChart.Subtitle = "$ in Thousands"
        BulletChart.Value = 82
        BulletChart.Target = 88
        BulletChart.BadThreshold = 50
        BulletChart.SatisfactoryThreshold = 75

        SparklineChart.SetData(New Double() {14, 18, 15, 22, 28, 25, 32, 40, 38, 48, 52})

        Dim blue = Color.FromRgb(59, 130, 246)
        ScatterChart.Points.Add(New LengkoScatterPoint(10, 25, blue, "A1"))
        ScatterChart.Points.Add(New LengkoScatterPoint(20, 38, blue, "A2"))
        ScatterChart.Points.Add(New LengkoScatterPoint(30, 52, blue, "A3"))
        ScatterChart.Points.Add(New LengkoScatterPoint(40, 66, blue, "A4"))
        ScatterChart.Points.Add(New LengkoScatterPoint(50, 80, blue, "A5"))
        Dim red = Color.FromRgb(239, 68, 68)
        ScatterChart.Points.Add(New LengkoScatterPoint(12, 18, red, "B1"))
        ScatterChart.Points.Add(New LengkoScatterPoint(22, 30, red, "B2"))
        ScatterChart.Points.Add(New LengkoScatterPoint(32, 40, red, "B3"))
        ScatterChart.Points.Add(New LengkoScatterPoint(42, 58, red, "B4"))
        ScatterChart.Points.Add(New LengkoScatterPoint(52, 70, red, "B5"))

        BubbleChart.Points.Add(New LengkoBubblePoint(15, 45, 14, "Opportunity A", Color.FromRgb(59, 130, 246)))
        BubbleChart.Points.Add(New LengkoBubblePoint(30, 70, 22, "Opportunity B", Color.FromRgb(16, 185, 129)))
        BubbleChart.Points.Add(New LengkoBubblePoint(55, 35, 18, "Opportunity C", Color.FromRgb(245, 158, 11)))
        BubbleChart.Points.Add(New LengkoBubblePoint(75, 85, 30, "Strategic Bet", Color.FromRgb(139, 92, 246)))
        BubbleChart.Points.Add(New LengkoBubblePoint(85, 50, 16, "Core Business", Color.FromRgb(236, 72, 153)))

        BoxPlotChart.Items.Add(New LengkoBoxPlotItem("Group A", 20, 35, 50, 68, 85))
        BoxPlotChart.Items.Add(New LengkoBoxPlotItem("Group B", 30, 45, 62, 78, 92))
        BoxPlotChart.Items.Add(New LengkoBoxPlotItem("Group C", 15, 28, 42, 58, 75))

        ErrorBarChart.Points.Add(New LengkoErrorPoint("Sample 1", 45, 5, 6))
        ErrorBarChart.Points.Add(New LengkoErrorPoint("Sample 2", 62, 8, 7))
        ErrorBarChart.Points.Add(New LengkoErrorPoint("Sample 3", 53, 4, 5))
        ErrorBarChart.Points.Add(New LengkoErrorPoint("Sample 4", 78, 9, 8))
    End Sub

    Private Sub BtnTheme_Click(sender As Object, e As RoutedEventArgs)
        _isDark = Not _isDark
        BtnTheme.Content = If(_isDark, "Theme: Dark", "Theme: Light")

        Dim theme = If(_isDark, LengkoChartTheme.Dark, LengkoChartTheme.Light)
        LengkoChartThemeScope.DefaultTheme = theme
        LengkoChartThemeScope.SetTheme(RootGrid, theme)
        LengkoChartThemeScope.ApplyToTree(RootGrid, theme)

        ApplyDynamicBrushes()
    End Sub

    Private Sub ApplyDynamicBrushes()
        If _isDark Then
            Resources("WindowBackgroundBrush") = New SolidColorBrush(Color.FromRgb(15, 23, 42))
            Resources("CardBackgroundBrush") = New SolidColorBrush(Color.FromRgb(30, 41, 59))
            Resources("CardBorderBrush") = New SolidColorBrush(Color.FromRgb(51, 65, 85))
            Resources("CardTitleBrush") = New SolidColorBrush(Color.FromRgb(241, 245, 249))
            Resources("CardSubtitleBrush") = New SolidColorBrush(Color.FromRgb(148, 163, 184))
            Resources("TextPrimaryBrush") = New SolidColorBrush(Color.FromRgb(248, 250, 252))
            Resources("TextSecondaryBrush") = New SolidColorBrush(Color.FromRgb(148, 163, 184))
            Resources("TabUnselectedBgBrush") = New SolidColorBrush(Color.FromRgb(30, 41, 59))
            Resources("TabUnselectedBorderBrush") = New SolidColorBrush(Color.FromRgb(51, 65, 85))
            Resources("TabForegroundBrush") = New SolidColorBrush(Color.FromRgb(148, 163, 184))
        Else
            Resources("WindowBackgroundBrush") = New SolidColorBrush(Color.FromRgb(248, 250, 252))
            Resources("CardBackgroundBrush") = Brushes.White
            Resources("CardBorderBrush") = New SolidColorBrush(Color.FromRgb(226, 232, 240))
            Resources("CardTitleBrush") = New SolidColorBrush(Color.FromRgb(15, 23, 42))
            Resources("CardSubtitleBrush") = New SolidColorBrush(Color.FromRgb(100, 116, 139))
            Resources("TextPrimaryBrush") = New SolidColorBrush(Color.FromRgb(15, 23, 42))
            Resources("TextSecondaryBrush") = New SolidColorBrush(Color.FromRgb(100, 116, 139))
            Resources("TabUnselectedBgBrush") = New SolidColorBrush(Color.FromRgb(226, 232, 240))
            Resources("TabUnselectedBorderBrush") = New SolidColorBrush(Color.FromRgb(203, 213, 225))
            Resources("TabForegroundBrush") = New SolidColorBrush(Color.FromRgb(71, 85, 105))
        End If
    End Sub

    Private Sub BtnDonut_Click(sender As Object, e As RoutedEventArgs)
        PieChart.IsDonut = Not PieChart.IsDonut
        BtnDonut.Content = If(PieChart.IsDonut, "Pie Mode: Donut", "Pie Mode: Standard")
    End Sub

    Private Sub BtnSmooth_Click(sender As Object, e As RoutedEventArgs)
        LineChart.SmoothCurves = Not LineChart.SmoothCurves
        AreaChart.SmoothCurves = Not AreaChart.SmoothCurves
        BtnSmooth.Content = If(LineChart.SmoothCurves, "Line Curve: Smooth", "Line Curve: Straight")
    End Sub

    Private Sub BtnRandomize_Click(sender As Object, e As RoutedEventArgs)
        For Each srs In BarChart.Series
            For i As Integer = 0 To srs.Values.Count - 1
                srs.Values(i) = _rand.Next(30, 260)
            Next
        Next
        BarChart.InvalidateVisual()

        For Each it In HBarChart.Items
            it.Value = _rand.Next(40, 100)
        Next
        HBarChart.InvalidateVisual()

        For Each srs In LineChart.Series
            For i As Integer = 0 To srs.Values.Count - 1
                srs.Values(i) = _rand.Next(15, 110)
            Next
        Next
        LineChart.InvalidateVisual()

        For Each slc In PieChart.Slices
            slc.Value = _rand.Next(10, 60)
        Next
        PieChart.InvalidateVisual()

        For Each slc In DonutChart.Slices
            slc.Value = _rand.Next(10, 60)
        Next
        DonutChart.InvalidateVisual()

        For Each srs In RadarChart.Series
            For i As Integer = 0 To srs.Values.Count - 1
                srs.Values(i) = _rand.Next(40, 99)
            Next
        Next
        RadarChart.InvalidateVisual()

        GaugeChart.Value = _rand.Next(20, 98)
        BulletChart.Value = _rand.Next(40, 95)

        Dim sparkData(10) As Double
        For i As Integer = 0 To 10
            sparkData(i) = _rand.Next(10, 65)
        Next
        SparklineChart.SetData(sparkData)
    End Sub

End Class
