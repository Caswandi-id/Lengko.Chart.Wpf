using System.Windows;
using System.Windows.Media;
using Lengko.Chart.Wpf;

namespace Lengko.Chart.Wpf.Demo.CSharp;

public partial class MainWindow : Window
{
    private bool _isDark = false;
    private readonly Random _rand = new();

    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        PopulateAllCharts();
    }

    private void PopulateAllCharts()
    {
        // ----------------------------------------------------
        // Tab 1: Bars & Columns (6 charts)
        // ----------------------------------------------------
        // 1. Grouped Bar Chart
        BarChart.Categories.Add("Q1");
        BarChart.Categories.Add("Q2");
        BarChart.Categories.Add("Q3");
        BarChart.Categories.Add("Q4");
        BarChart.Series.Add(new LengkoBarSeries("Revenue", new double[] { 120, 150, 180, 220 }, Color.FromRgb(59, 130, 246)));
        BarChart.Series.Add(new LengkoBarSeries("Profit", new double[] { 45, 60, 75, 95 }, Color.FromRgb(16, 185, 129)));

        // 2. Horizontal Bar Chart
        HBarChart.AddItem("TypeScript", 88, Color.FromRgb(59, 130, 246));
        HBarChart.AddItem("C# / .NET", 94, Color.FromRgb(139, 92, 246));
        HBarChart.AddItem("Python", 82, Color.FromRgb(245, 158, 11));
        HBarChart.AddItem("Go", 75, Color.FromRgb(6, 182, 212));
        HBarChart.AddItem("Rust", 70, Color.FromRgb(239, 68, 68));

        // 3. Stacked Bar Chart
        StackedBarChart.Categories.Add("2021");
        StackedBarChart.Categories.Add("2022");
        StackedBarChart.Categories.Add("2023");
        StackedBarChart.Categories.Add("2024");
        StackedBarChart.Series.Add(new LengkoBarSeries("Cloud", new double[] { 40, 55, 75, 110 }, Color.FromRgb(59, 130, 246)));
        StackedBarChart.Series.Add(new LengkoBarSeries("On-Prem", new double[] { 60, 50, 45, 30 }, Color.FromRgb(16, 185, 129)));
        StackedBarChart.Series.Add(new LengkoBarSeries("Support", new double[] { 20, 25, 30, 35 }, Color.FromRgb(245, 158, 11)));

        // 4. Histogram Chart
        HistogramChart.SetData(new double[] { 18, 22, 25, 27, 30, 32, 34, 35, 38, 40, 42, 44, 45, 48, 52, 55, 60, 65, 72 }, 6);

        // 5. Pareto Chart
        ParetoChart.Items.Add(new LengkoParetoItem("Timeout 504", 142));
        ParetoChart.Items.Add(new LengkoParetoItem("Auth 401", 95));
        ParetoChart.Items.Add(new LengkoParetoItem("NullRef", 48));
        ParetoChart.Items.Add(new LengkoParetoItem("DB Lock", 24));
        ParetoChart.Items.Add(new LengkoParetoItem("Bad Format", 12));

        // 6. Waterfall Chart
        WaterfallChart.Items.Add(new LengkoWaterfallItem("Start Cash", 120, isTotal: true));
        WaterfallChart.Items.Add(new LengkoWaterfallItem("Product Sales", 52));
        WaterfallChart.Items.Add(new LengkoWaterfallItem("Subscriptions", 30));
        WaterfallChart.Items.Add(new LengkoWaterfallItem("Salaries", -42));
        WaterfallChart.Items.Add(new LengkoWaterfallItem("Cloud Hosting", -18));
        WaterfallChart.Items.Add(new LengkoWaterfallItem("Marketing", -14));
        WaterfallChart.Items.Add(new LengkoWaterfallItem("Net End Cash", 0, isTotal: true));

        // ----------------------------------------------------
        // Tab 2: Lines & Areas (6 charts)
        // ----------------------------------------------------
        // 7. Line Chart
        LineChart.Series.Add(new LengkoLineSeries("Traffic (k)", new double[] { 22, 34, 45, 40, 58, 65, 80 }, Color.FromRgb(99, 102, 241)));
        LineChart.Series.Add(new LengkoLineSeries("Signups", new double[] { 10, 18, 24, 28, 35, 42, 55 }, Color.FromRgb(236, 72, 153)));

        // 8. Area Chart
        AreaChart.Labels.Add("Jan");
        AreaChart.Labels.Add("Feb");
        AreaChart.Labels.Add("Mar");
        AreaChart.Labels.Add("Apr");
        AreaChart.Labels.Add("May");
        AreaChart.Labels.Add("Jun");
        AreaChart.Series.Add(new LengkoAreaSeries("Inbound", new double[] { 30, 45, 52, 68, 74, 90 }, Color.FromRgb(59, 130, 246)));
        AreaChart.Series.Add(new LengkoAreaSeries("Outbound", new double[] { 18, 25, 32, 40, 48, 62 }, Color.FromRgb(16, 185, 129)));

        // 9. Stacked Area Chart
        StackedAreaChart.Categories.Add("Jan");
        StackedAreaChart.Categories.Add("Feb");
        StackedAreaChart.Categories.Add("Mar");
        StackedAreaChart.Categories.Add("Apr");
        StackedAreaChart.Categories.Add("May");
        StackedAreaChart.Categories.Add("Jun");
        StackedAreaChart.Series.Add(new LengkoAreaSeries("North", new double[] { 25, 30, 38, 45, 52, 60 }, Color.FromRgb(14, 165, 233)));
        StackedAreaChart.Series.Add(new LengkoAreaSeries("South", new double[] { 20, 24, 30, 36, 42, 48 }, Color.FromRgb(168, 85, 247)));
        StackedAreaChart.Series.Add(new LengkoAreaSeries("East", new double[] { 15, 18, 22, 28, 32, 38 }, Color.FromRgb(249, 115, 22)));

        // 10. Step Line Chart
        StepLineChart.Series.Add(new LengkoStepSeries("Inventory", new double[] { 100, 85, 85, 60, 120, 95, 70 }, Color.FromRgb(16, 185, 129)));
        StepLineChart.Series.Add(new LengkoStepSeries("Threshold", new double[] { 50, 50, 50, 50, 50, 50, 50 }, Color.FromRgb(239, 68, 68)));

        // 11. Combo Chart (Bars + Line)
        ComboChart.Categories.Add("Q1");
        ComboChart.Categories.Add("Q2");
        ComboChart.Categories.Add("Q3");
        ComboChart.Categories.Add("Q4");
        ComboChart.BarSeries.Add(new LengkoBarSeries("Units Sold", new double[] { 320, 450, 580, 710 }, Color.FromRgb(59, 130, 246)));
        ComboChart.LineSeries.Add(new LengkoLineSeries("Margin %", new double[] { 22, 28, 26, 31 }, Color.FromRgb(239, 68, 68)));

        // 12. Generic LengkoChart
        GenericChart.AddPoint("CPU", 48);
        GenericChart.AddPoint("RAM", 72);
        GenericChart.AddPoint("Disk", 60);
        GenericChart.AddPoint("Network", 35);
        GenericChart.AddPoint("GPU", 84);

        // ----------------------------------------------------
        // Tab 3: Circular & Polar (5 charts)
        // ----------------------------------------------------
        // 13. Pie Chart
        PieChart.Slices.Add(new LengkoPieSlice("North America", 38, Color.FromRgb(59, 130, 246)));
        PieChart.Slices.Add(new LengkoPieSlice("Europe", 27, Color.FromRgb(16, 185, 129)));
        PieChart.Slices.Add(new LengkoPieSlice("Asia Pacific", 23, Color.FromRgb(245, 158, 11)));
        PieChart.Slices.Add(new LengkoPieSlice("Latin America", 12, Color.FromRgb(239, 68, 68)));

        // 14. Donut Chart
        DonutChart.Slices.Add(new LengkoPieSlice("Enterprise", 45, Color.FromRgb(99, 102, 241)));
        DonutChart.Slices.Add(new LengkoPieSlice("SMB", 30, Color.FromRgb(236, 72, 153)));
        DonutChart.Slices.Add(new LengkoPieSlice("Startup", 15, Color.FromRgb(20, 184, 166)));
        DonutChart.Slices.Add(new LengkoPieSlice("Consumer", 10, Color.FromRgb(245, 158, 11)));

        // 15. Radar Chart
        RadarChart.Axes.Add("Speed");
        RadarChart.Axes.Add("Reliability");
        RadarChart.Axes.Add("Usability");
        RadarChart.Axes.Add("Security");
        RadarChart.Axes.Add("Scalability");
        RadarChart.Series.Add(new LengkoRadarSeries("Lengko UI", new double[] { 92, 95, 88, 90, 94 }, Color.FromRgb(139, 92, 246)));
        RadarChart.Series.Add(new LengkoRadarSeries("Standard", new double[] { 65, 70, 60, 75, 68 }, Color.FromRgb(148, 163, 184)));

        // 16. Polar Area Chart
        PolarChart.Items.Add(new LengkoPolarItem("North", 45, Color.FromRgb(59, 130, 246)));
        PolarChart.Items.Add(new LengkoPolarItem("NE", 60, Color.FromRgb(99, 102, 241)));
        PolarChart.Items.Add(new LengkoPolarItem("East", 80, Color.FromRgb(139, 92, 246)));
        PolarChart.Items.Add(new LengkoPolarItem("SE", 50, Color.FromRgb(236, 72, 153)));
        PolarChart.Items.Add(new LengkoPolarItem("South", 35, Color.FromRgb(244, 63, 94)));
        PolarChart.Items.Add(new LengkoPolarItem("SW", 55, Color.FromRgb(245, 158, 11)));
        PolarChart.Items.Add(new LengkoPolarItem("West", 75, Color.FromRgb(16, 185, 129)));
        PolarChart.Items.Add(new LengkoPolarItem("NW", 40, Color.FromRgb(20, 184, 166)));

        // 17. Sunburst Chart
        SunburstChart.Items.Add(new LengkoSunburstItem("Software", 60, 0, Color.FromRgb(59, 130, 246)));
        SunburstChart.Items.Add(new LengkoSunburstItem("Hardware", 40, 0, Color.FromRgb(16, 185, 129)));
        SunburstChart.Items.Add(new LengkoSunburstItem("Desktop", 35, 1, Color.FromRgb(99, 102, 241)));
        SunburstChart.Items.Add(new LengkoSunburstItem("Mobile", 25, 1, Color.FromRgb(14, 165, 233)));
        SunburstChart.Items.Add(new LengkoSunburstItem("Servers", 25, 1, Color.FromRgb(34, 197, 94)));
        SunburstChart.Items.Add(new LengkoSunburstItem("IoT", 15, 1, Color.FromRgb(245, 158, 11)));

        // ----------------------------------------------------
        // Tab 4: Financial & Timelines (3 charts)
        // ----------------------------------------------------
        // 18. Candlestick Chart
        CandleChart.AddCandle("09:30", open: 150.2, high: 153.5, low: 149.8, close: 152.8, volume: 142000);
        CandleChart.AddCandle("10:00", open: 152.8, high: 154.0, low: 151.2, close: 151.6, volume: 98000);
        CandleChart.AddCandle("10:30", open: 151.6, high: 155.2, low: 151.0, close: 154.5, volume: 175000);
        CandleChart.AddCandle("11:00", open: 154.5, high: 156.0, low: 153.8, close: 155.8, volume: 110000);
        CandleChart.AddCandle("11:30", open: 155.8, high: 156.2, low: 153.0, close: 153.4, volume: 130000);

        // 19. OHLC Bar Chart
        OhlcChart.Bars.Add(new LengkoOhlcBar("Mon", 100, 108, 98, 105));
        OhlcChart.Bars.Add(new LengkoOhlcBar("Tue", 105, 110, 102, 104));
        OhlcChart.Bars.Add(new LengkoOhlcBar("Wed", 104, 114, 103, 112));
        OhlcChart.Bars.Add(new LengkoOhlcBar("Thu", 112, 115, 108, 109));
        OhlcChart.Bars.Add(new LengkoOhlcBar("Fri", 109, 118, 107, 116));

        // 20. Gantt Timeline Chart
        DateTime baseDate = DateTime.Today;
        GanttChart.Tasks.Add(new LengkoGanttItem("Architecture & API", baseDate, baseDate.AddDays(5), progress: 100));
        GanttChart.Tasks.Add(new LengkoGanttItem("Core Chart Engine", baseDate.AddDays(3), baseDate.AddDays(10), progress: 80));
        GanttChart.Tasks.Add(new LengkoGanttItem("32 WPF Controls", baseDate.AddDays(6), baseDate.AddDays(15), progress: 55));
        GanttChart.Tasks.Add(new LengkoGanttItem("Testing & Packaging", baseDate.AddDays(12), baseDate.AddDays(18), progress: 20));

        // ----------------------------------------------------
        // Tab 5: Hierarchy & Flow (5 charts)
        // ----------------------------------------------------
        // 21. Treemap
        TreemapChart.Items.Add(new LengkoTreemapItem("Finance", 420));
        TreemapChart.Items.Add(new LengkoTreemapItem("Engineering", 350));
        TreemapChart.Items.Add(new LengkoTreemapItem("Marketing", 220));
        TreemapChart.Items.Add(new LengkoTreemapItem("Support", 160));
        TreemapChart.Items.Add(new LengkoTreemapItem("Legal & HR", 90));

        // 22. Sankey Chart
        SankeyChart.Links.Add(new LengkoSankeyLink("Organic Search", "Landing Page", 140));
        SankeyChart.Links.Add(new LengkoSankeyLink("Paid Ads", "Landing Page", 90));
        SankeyChart.Links.Add(new LengkoSankeyLink("Referral", "Product Specs", 65));
        SankeyChart.Links.Add(new LengkoSankeyLink("Landing Page", "Pricing", 130));
        SankeyChart.Links.Add(new LengkoSankeyLink("Landing Page", "Checkout", 70));
        SankeyChart.Links.Add(new LengkoSankeyLink("Pricing", "Checkout", 100));
        SankeyChart.Links.Add(new LengkoSankeyLink("Product Specs", "Checkout", 45));

        // 23. Funnel Chart
        FunnelChart.Stages.Add(new LengkoFunnelStage("Website Visits", 12500));
        FunnelChart.Stages.Add(new LengkoFunnelStage("Sign Up", 5200));
        FunnelChart.Stages.Add(new LengkoFunnelStage("Cart Added", 2800));
        FunnelChart.Stages.Add(new LengkoFunnelStage("Checkout Started", 1600));
        FunnelChart.Stages.Add(new LengkoFunnelStage("Purchased", 1100));

        // 24. Pyramid Chart
        PyramidChart.Stages.Add(new LengkoPyramidStage("Executives", 8));
        PyramidChart.Stages.Add(new LengkoPyramidStage("Directors", 24));
        PyramidChart.Stages.Add(new LengkoPyramidStage("Team Leads", 65));
        PyramidChart.Stages.Add(new LengkoPyramidStage("Specialists", 180));
        PyramidChart.Stages.Add(new LengkoPyramidStage("Associates", 340));

        // 25. Heatmap Matrix
        HeatmapChart.RowLabels.Add("Mon");
        HeatmapChart.RowLabels.Add("Tue");
        HeatmapChart.RowLabels.Add("Wed");
        HeatmapChart.RowLabels.Add("Thu");
        HeatmapChart.RowLabels.Add("Fri");
        HeatmapChart.ColumnLabels.Add("09:00");
        HeatmapChart.ColumnLabels.Add("12:00");
        HeatmapChart.ColumnLabels.Add("15:00");
        HeatmapChart.ColumnLabels.Add("18:00");
        HeatmapChart.ColumnLabels.Add("21:00");
        double[,] matrix = {
            { 20, 45, 78, 60, 30 },
            { 35, 60, 92, 85, 40 },
            { 40, 75, 95, 80, 50 },
            { 30, 65, 88, 70, 45 },
            { 25, 50, 70, 90, 65 }
        };
        for (int r = 0; r < 5; r++)
            for (int c = 0; c < 5; c++)
                HeatmapChart.SetCell(r, c, matrix[r, c]);

        // ----------------------------------------------------
        // Tab 6: KPIs & Statistical (7 charts)
        // ----------------------------------------------------
        // 26. Radial Gauge
        GaugeChart.Value = 76.5;
        GaugeChart.Title = "Server Load";
        GaugeChart.Unit = "%";

        // 27. Bullet Graph
        BulletChart.Title = "YTD Sales";
        BulletChart.Subtitle = "$ in Thousands";
        BulletChart.Value = 82;
        BulletChart.Target = 88;
        BulletChart.BadThreshold = 50;
        BulletChart.SatisfactoryThreshold = 75;

        // 28. Sparkline
        SparklineChart.SetData(new double[] { 14, 18, 15, 22, 28, 25, 32, 40, 38, 48, 52 });

        // 29. Scatter Chart (with linear regression)
        var blue = Color.FromRgb(59, 130, 246);
        ScatterChart.Points.Add(new LengkoScatterPoint(10, 25, blue, "A1"));
        ScatterChart.Points.Add(new LengkoScatterPoint(20, 38, blue, "A2"));
        ScatterChart.Points.Add(new LengkoScatterPoint(30, 52, blue, "A3"));
        ScatterChart.Points.Add(new LengkoScatterPoint(40, 66, blue, "A4"));
        ScatterChart.Points.Add(new LengkoScatterPoint(50, 80, blue, "A5"));
        var red = Color.FromRgb(239, 68, 68);
        ScatterChart.Points.Add(new LengkoScatterPoint(12, 18, red, "B1"));
        ScatterChart.Points.Add(new LengkoScatterPoint(22, 30, red, "B2"));
        ScatterChart.Points.Add(new LengkoScatterPoint(32, 40, red, "B3"));
        ScatterChart.Points.Add(new LengkoScatterPoint(42, 58, red, "B4"));
        ScatterChart.Points.Add(new LengkoScatterPoint(52, 70, red, "B5"));

        // 30. Bubble Chart
        BubbleChart.Points.Add(new LengkoBubblePoint(15, 45, 14, "Opportunity A", Color.FromRgb(59, 130, 246)));
        BubbleChart.Points.Add(new LengkoBubblePoint(30, 70, 22, "Opportunity B", Color.FromRgb(16, 185, 129)));
        BubbleChart.Points.Add(new LengkoBubblePoint(55, 35, 18, "Opportunity C", Color.FromRgb(245, 158, 11)));
        BubbleChart.Points.Add(new LengkoBubblePoint(75, 85, 30, "Strategic Bet", Color.FromRgb(139, 92, 246)));
        BubbleChart.Points.Add(new LengkoBubblePoint(85, 50, 16, "Core Business", Color.FromRgb(236, 72, 153)));

        // 31. Box Plot Chart
        BoxPlotChart.Items.Add(new LengkoBoxPlotItem("Group A", 20, 35, 50, 68, 85));
        BoxPlotChart.Items.Add(new LengkoBoxPlotItem("Group B", 30, 45, 62, 78, 92));
        BoxPlotChart.Items.Add(new LengkoBoxPlotItem("Group C", 15, 28, 42, 58, 75));

        // 32. Error Bar Chart
        ErrorBarChart.Points.Add(new LengkoErrorPoint("Sample 1", 45, 5, 6));
        ErrorBarChart.Points.Add(new LengkoErrorPoint("Sample 2", 62, 8, 7));
        ErrorBarChart.Points.Add(new LengkoErrorPoint("Sample 3", 53, 4, 5));
        ErrorBarChart.Points.Add(new LengkoErrorPoint("Sample 4", 78, 9, 8));
    }

    private void BtnTheme_Click(object sender, RoutedEventArgs e)
    {
        _isDark = !_isDark;
        BtnTheme.Content = _isDark ? "Theme: Dark" : "Theme: Light";

        var theme = _isDark ? LengkoChartTheme.Dark : LengkoChartTheme.Light;
        LengkoChartThemeScope.DefaultTheme = theme;
        LengkoChartThemeScope.SetTheme(RootGrid, theme);
        LengkoChartThemeScope.ApplyToTree(RootGrid, theme);

        ApplyDynamicBrushes();
    }

    private void ApplyDynamicBrushes()
    {
        if (_isDark)
        {
            Resources["WindowBackgroundBrush"] = new SolidColorBrush(Color.FromRgb(15, 23, 42));       // #0F172A
            Resources["CardBackgroundBrush"]   = new SolidColorBrush(Color.FromRgb(30, 41, 59));       // #1E293B
            Resources["CardBorderBrush"]       = new SolidColorBrush(Color.FromRgb(51, 65, 85));       // #334155
            Resources["CardTitleBrush"]        = new SolidColorBrush(Color.FromRgb(241, 245, 249));    // #F1F5F9
            Resources["CardSubtitleBrush"]     = new SolidColorBrush(Color.FromRgb(148, 163, 184));    // #94A3B8
            Resources["TextPrimaryBrush"]      = new SolidColorBrush(Color.FromRgb(248, 250, 252));    // #F8FAFC
            Resources["TextSecondaryBrush"]    = new SolidColorBrush(Color.FromRgb(148, 163, 184));    // #94A3B8
            Resources["TabUnselectedBgBrush"]  = new SolidColorBrush(Color.FromRgb(30, 41, 59));       // #1E293B
            Resources["TabUnselectedBorderBrush"] = new SolidColorBrush(Color.FromRgb(51, 65, 85));   // #334155
            Resources["TabForegroundBrush"]    = new SolidColorBrush(Color.FromRgb(148, 163, 184));    // #94A3B8
        }
        else
        {
            Resources["WindowBackgroundBrush"] = new SolidColorBrush(Color.FromRgb(248, 250, 252));   // #F8FAFC
            Resources["CardBackgroundBrush"]   = Brushes.White;
            Resources["CardBorderBrush"]       = new SolidColorBrush(Color.FromRgb(226, 232, 240));    // #E2E8F0
            Resources["CardTitleBrush"]        = new SolidColorBrush(Color.FromRgb(15, 23, 42));       // #0F172A
            Resources["CardSubtitleBrush"]     = new SolidColorBrush(Color.FromRgb(100, 116, 139));    // #64748B
            Resources["TextPrimaryBrush"]      = new SolidColorBrush(Color.FromRgb(15, 23, 42));       // #0F172A
            Resources["TextSecondaryBrush"]    = new SolidColorBrush(Color.FromRgb(100, 116, 139));    // #64748B
            Resources["TabUnselectedBgBrush"]  = new SolidColorBrush(Color.FromRgb(226, 232, 240));    // #E2E8F0
            Resources["TabUnselectedBorderBrush"] = new SolidColorBrush(Color.FromRgb(203, 213, 225)); // #CBD5E1
            Resources["TabForegroundBrush"]    = new SolidColorBrush(Color.FromRgb(71, 85, 105));      // #475569
        }
    }

    private void BtnDonut_Click(object sender, RoutedEventArgs e)
    {
        PieChart.IsDonut = !PieChart.IsDonut;
        BtnDonut.Content = PieChart.IsDonut ? "Pie Mode: Donut" : "Pie Mode: Standard";
    }

    private void BtnSmooth_Click(object sender, RoutedEventArgs e)
    {
        LineChart.SmoothCurves = !LineChart.SmoothCurves;
        AreaChart.SmoothCurves = !AreaChart.SmoothCurves;
        BtnSmooth.Content = LineChart.SmoothCurves ? "Line Curve: Smooth" : "Line Curve: Straight";
    }

    private void BtnRandomize_Click(object sender, RoutedEventArgs e)
    {
        // 1. Randomize Bar
        foreach (var srs in BarChart.Series)
        {
            for (int i = 0; i < srs.Values.Count; i++)
                srs.Values[i] = _rand.Next(30, 260);
        }
        BarChart.InvalidateVisual();

        // 2. Randomize Horizontal Bar
        foreach (var it in HBarChart.Items)
            it.Value = _rand.Next(40, 100);
        HBarChart.InvalidateVisual();

        // 3. Randomize Line
        foreach (var srs in LineChart.Series)
        {
            for (int i = 0; i < srs.Values.Count; i++)
                srs.Values[i] = _rand.Next(15, 110);
        }
        LineChart.InvalidateVisual();

        // 4. Randomize Pie & Donut
        foreach (var slc in PieChart.Slices)
            slc.Value = _rand.Next(10, 60);
        PieChart.InvalidateVisual();

        foreach (var slc in DonutChart.Slices)
            slc.Value = _rand.Next(10, 60);
        DonutChart.InvalidateVisual();

        // 5. Randomize Radar
        foreach (var srs in RadarChart.Series)
        {
            for (int i = 0; i < srs.Values.Count; i++)
                srs.Values[i] = _rand.Next(40, 99);
        }
        RadarChart.InvalidateVisual();

        // 6. Randomize Gauge & Bullet
        GaugeChart.Value = _rand.Next(20, 98);
        BulletChart.Value = _rand.Next(40, 95);

        // 7. Randomize Sparkline
        var sparkData = new double[11];
        for (int i = 0; i < 11; i++) sparkData[i] = _rand.Next(10, 65);
        SparklineChart.SetData(sparkData);
    }
}
