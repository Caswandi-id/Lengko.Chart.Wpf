namespace Lengko.Chart.Wpf.Demo.FSharp

open System
open System.Collections.Generic
open System.Windows
open System.Windows.Controls
open System.Windows.Controls.Primitives
open System.Windows.Media
open Lengko.Chart.Wpf

type CardRef = {
    CardBorder: Border
    TitleBlock: TextBlock
    SubBlock: TextBlock
    ChartCtrl: FrameworkElement
}

module Program =

    type MainWindow() as this =
        inherit Window()

        let mutable isDark = false
        let rand = Random()
        let cardRefs = List<CardRef>()

        let makeCard (title: string) (sub: string) (chart: FrameworkElement) =
            let border = Border(
                Background = Brushes.White,
                BorderBrush = SolidColorBrush(Color.FromRgb(226uy, 232uy, 240uy)),
                BorderThickness = Thickness(1.0),
                CornerRadius = CornerRadius(8.0),
                Padding = Thickness(14.0, 12.0, 14.0, 12.0),
                Margin = Thickness(6.0)
            )
            let grid = Grid()
            grid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))
            grid.RowDefinitions.Add(RowDefinition(Height = GridLength(1.0, GridUnitType.Star)))

            let header = StackPanel(Margin = Thickness(0.0, 0.0, 0.0, 8.0))
            let txtTitle = TextBlock(
                Text = title,
                FontWeight = FontWeights.SemiBold,
                FontSize = 13.5,
                Foreground = SolidColorBrush(Color.FromRgb(15uy, 23uy, 42uy))
            )
            let txtSub = TextBlock(
                Text = sub,
                FontSize = 11.5,
                Foreground = SolidColorBrush(Color.FromRgb(100uy, 116uy, 139uy)),
                Margin = Thickness(0.0, 1.0, 0.0, 0.0)
            )
            header.Children.Add(txtTitle) |> ignore
            header.Children.Add(txtSub) |> ignore
            Grid.SetRow(header, 0)
            grid.Children.Add(header) |> ignore

            chart.Height <- 250.0
            Grid.SetRow(chart, 1)
            grid.Children.Add(chart) |> ignore

            border.Child <- grid
            cardRefs.Add({ CardBorder = border; TitleBlock = txtTitle; SubBlock = txtSub; ChartCtrl = chart })
            border

        let makeUniformGrid (cols: int) (items: Border list) =
            let ug = UniformGrid(Columns = cols, Margin = Thickness(0.0, 8.0, 0.0, 0.0))
            for it in items do
                ug.Children.Add(it) |> ignore
            let scroller = ScrollViewer(VerticalScrollBarVisibility = ScrollBarVisibility.Auto)
            scroller.Content <- ug
            scroller

        let makeTab (header: string) (content: FrameworkElement) =
            let tab = TabItem(
                Header = header,
                FontSize = 13.0,
                FontWeight = FontWeights.SemiBold,
                Padding = Thickness(14.0, 8.0, 14.0, 8.0),
                Margin = Thickness(0.0, 0.0, 4.0, 0.0),
                Cursor = Input.Cursors.Hand,
                Content = content
            )
            tab

        let makeToolbarButton (text: string) (bgHex: string) =
            let color = ColorConverter.ConvertFromString(bgHex) :?> Color
            let btn = Button(
                Content = text,
                Background = SolidColorBrush(color),
                Foreground = Brushes.White,
                FontWeight = FontWeights.SemiBold,
                FontSize = 12.0,
                Padding = Thickness(14.0, 7.0, 14.0, 7.0),
                Margin = Thickness(0.0, 0.0, 8.0, 6.0),
                BorderThickness = Thickness(0.0),
                Cursor = Input.Cursors.Hand
            )
            btn

        do
            this.Title <- "Lengko.Chart.Wpf Showcase (All 32 Charts F# Demo)"
            this.Width <- 1240.0
            this.Height <- 880.0
            this.MinHeight <- 680.0
            this.MinWidth <- 980.0
            this.WindowStartupLocation <- WindowStartupLocation.CenterScreen
            this.Background <- SolidColorBrush(Color.FromRgb(248uy, 250uy, 252uy))
            this.FontFamily <- FontFamily("Segoe UI")
            this.FontSize <- 13.0

            let rootGrid = Grid(Margin = Thickness(16.0))
            rootGrid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))
            rootGrid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))
            rootGrid.RowDefinitions.Add(RowDefinition(Height = GridLength(1.0, GridUnitType.Star)))
            rootGrid.RowDefinitions.Add(RowDefinition(Height = GridLength.Auto))

            // 1. Header
            let headerPanel = StackPanel(Margin = Thickness(0.0, 0.0, 0.0, 12.0))
            let mainTitle = TextBlock(
                Text = "Lengko.Chart.Wpf Showcase (All 32 Charts F# Demo)",
                FontSize = 21.0,
                FontWeight = FontWeights.Bold,
                Foreground = SolidColorBrush(Color.FromRgb(15uy, 23uy, 42uy))
            )
            let mainSub = TextBlock(
                Text = "Complete catalog: 32 chart controls with pure WPF DrawingContext vector rendering, tooltips, zoom/pan, and theme engine.",
                FontSize = 13.0,
                Foreground = SolidColorBrush(Color.FromRgb(100uy, 116uy, 139uy)),
                Margin = Thickness(0.0, 3.0, 0.0, 0.0)
            )
            headerPanel.Children.Add(mainTitle) |> ignore
            headerPanel.Children.Add(mainSub) |> ignore
            Grid.SetRow(headerPanel, 0)
            rootGrid.Children.Add(headerPanel) |> ignore

            // 2. Toolbar
            let toolbar = WrapPanel(Margin = Thickness(0.0, 0.0, 0.0, 10.0))
            let btnTheme = makeToolbarButton "Theme: Light" "#475569"
            let btnDonut = makeToolbarButton "Pie Mode: Standard" "#0284C7"
            let btnSmooth = makeToolbarButton "Line Curve: Smooth" "#059669"
            let btnRandomize = makeToolbarButton "Randomize Data" "#8B5CF6"
            toolbar.Children.Add(btnTheme) |> ignore
            toolbar.Children.Add(btnDonut) |> ignore
            toolbar.Children.Add(btnSmooth) |> ignore
            toolbar.Children.Add(btnRandomize) |> ignore
            Grid.SetRow(toolbar, 1)
            rootGrid.Children.Add(toolbar) |> ignore

            // 3. TabControl
            let tabs = TabControl(Background = Brushes.Transparent, BorderThickness = Thickness(0.0))

            // Controls with external references
            let barChart = LengkoBarChart(ShowGrid = true, ShowValues = true)
            let hBarChart = LengkoHorizontalBarChart(ShowValues = true)
            let stackedBar = LengkoStackedBarChart(ShowGrid = true)
            let hist = LengkoHistogramChart(ShowGrid = true)
            let pareto = LengkoParetoChart()
            let waterfall = LengkoWaterfallChart()

            let lineChart = LengkoLineChart(SmoothCurves = true, ShowPoints = true, FillArea = true, ShowGrid = true)
            let areaChart = LengkoAreaChart(SmoothCurves = true, ShowGrid = true)
            let stackedArea = LengkoStackedAreaChart(ShowGrid = true)
            let stepLine = LengkoStepLineChart(ShowPoints = true, FillArea = true)
            let combo = LengkoComboChart(ShowGrid = true)
            let generic = LengkoChart(Title = "Multi-Point Metric")

            let pieChart = LengkoPieChart(ShowPercentages = true)
            let donutChart = LengkoDonutChart(ShowPercentages = true)
            let radarChart = LengkoRadarChart()
            let polar = LengkoPolarAreaChart()
            let sunburst = LengkoSunburstChart()

            let candle = LengkoCandlestickChart(ShowVolume = true)
            let ohlc = LengkoOhlcChart()
            let gantt = LengkoGanttChart()

            let treemap = LengkoTreemap()
            let sankey = LengkoSankeyChart()
            let funnel = LengkoFunnelChart()
            let pyramid = LengkoPyramidChart()
            let heatmap = LengkoHeatmapChart()

            let gaugeChart = LengkoRadialGauge()
            let bulletChart = LengkoBulletGraph()
            let sparklineChart = LengkoSparkline(Width = 320.0, Height = 100.0, StrokeWidth = 2.5)
            let scatter = LengkoScatterChart(ShowTrendline = true)
            let bubble = LengkoBubbleChart()
            let boxplot = LengkoBoxPlotChart()
            let errorbar = LengkoErrorBarChart()

            // Tab 1: Bars & Columns (6)
            let t1 = makeUniformGrid 2 [
                makeCard "Bar Chart (LengkoBarChart)" "Multi-series grouped column comparison with data values" barChart
                makeCard "Horizontal Bar Chart (LengkoHorizontalBarChart)" "Ranked category comparison with horizontal bars" hBarChart
                makeCard "Stacked Bar Chart (LengkoStackedBarChart)" "Part-to-whole segment distribution across periods" stackedBar
                makeCard "Histogram Chart (LengkoHistogramChart)" "Frequency distribution across numerical range bins" hist
                makeCard "Pareto Chart (LengkoParetoChart)" "80/20 defect / factor analysis with cumulative line" pareto
                makeCard "Waterfall Chart (LengkoWaterfallChart)" "Incremental revenue, expense, and net variance flow" waterfall
            ]
            tabs.Items.Add(makeTab "Bars & Columns (6)" t1) |> ignore

            // Tab 2: Lines & Areas (6)
            let t2 = makeUniformGrid 2 [
                makeCard "Line Chart (LengkoLineChart)" "Multi-series continuous trends with points and fill" lineChart
                makeCard "Area Chart (LengkoAreaChart)" "Cumulative trend volume with smooth area fill" areaChart
                makeCard "Stacked Area Chart (LengkoStackedAreaChart)" "Cumulative regional contribution over continuous time" stackedArea
                makeCard "Step Line Chart (LengkoStepLineChart)" "Discrete step-wise inventory and threshold changes" stepLine
                makeCard "Combo Chart (LengkoComboChart)" "Dual-axis combination of volume bars and profit line" combo
                makeCard "Generic Chart (LengkoChart)" "Lightweight multi-point metric visualization" generic
            ]
            tabs.Items.Add(makeTab "Lines & Areas (6)" t2) |> ignore

            // Tab 3: Circular & Polar (5)
            let t3 = makeUniformGrid 2 [
                makeCard "Pie Chart (LengkoPieChart)" "Proportional slice distribution with percentage badges" pieChart
                makeCard "Donut Chart (LengkoDonutChart)" "Ring distribution with central readout and legend" donutChart
                makeCard "Radar Chart (LengkoRadarChart)" "Multi-variable capability spider comparison" radarChart
                makeCard "Polar Area Chart (LengkoPolarAreaChart)" "Cyclic and directional magnitude comparison" polar
                makeCard "Sunburst Chart (LengkoSunburstChart)" "Multi-level concentric radial hierarchy visualizer" sunburst
            ]
            tabs.Items.Add(makeTab "Circular & Polar (5)" t3) |> ignore

            // Tab 4: Financial & Timelines (3)
            let t4 = makeUniformGrid 1 [
                makeCard "Candlestick Chart (LengkoCandlestickChart)" "Asset price action with OHLC candles and trading volume bars" candle
                makeCard "OHLC Bar Chart (LengkoOhlcChart)" "Open-High-Low-Close financial trading price bars" ohlc
                makeCard "Gantt Chart (LengkoGanttChart)" "Project timeline, milestone scheduling, and task progress tracking" gantt
            ]
            tabs.Items.Add(makeTab "Financial & Timelines (3)" t4) |> ignore

            // Tab 5: Hierarchy & Flow (5)
            let t5 = makeUniformGrid 2 [
                makeCard "Treemap (LengkoTreemap)" "Hierarchical space-filling rectangular proportions" treemap
                makeCard "Sankey Flow Chart (LengkoSankeyChart)" "Directed flow paths, quantities, and node transfers" sankey
                makeCard "Funnel Chart (LengkoFunnelChart)" "Conversion funnel stages and pipeline drop-off" funnel
                makeCard "Pyramid Chart (LengkoPyramidChart)" "Hierarchical tiered organizational structure" pyramid
                makeCard "Heatmap Chart (LengkoHeatmapChart)" "2D intensity matrix grid with color spectrum" heatmap
            ]
            tabs.Items.Add(makeTab "Hierarchy & Flow (5)" t5) |> ignore

            // Tab 6: KPIs & Statistical (7)
            let t6 = makeUniformGrid 2 [
                makeCard "Radial Gauge (LengkoRadialGauge)" "Circular KPI progress arc indicator with centered metrics" gaugeChart
                makeCard "Bullet Graph (LengkoBulletGraph)" "Compact KPI against target and qualitative performance bands" bulletChart
                makeCard "Sparkline (LengkoSparkline)" "Ultra-compact micro trend visualizer for dashboards and tables" sparklineChart
                makeCard "Scatter Chart (LengkoScatterChart)" "Bivariate correlation points with linear regression trendline" scatter
                makeCard "Bubble Chart (LengkoBubbleChart)" "Three-variable correlation mapping X, Y, and bubble magnitude" bubble
                makeCard "Box Plot Chart (LengkoBoxPlotChart)" "Five-number summary showing min, quartiles, median, and max" boxplot
                makeCard "Error Bar Chart (LengkoErrorBarChart)" "Mean values with upper and lower measurement uncertainty" errorbar
            ]
            tabs.Items.Add(makeTab "KPIs & Statistical (7)" t6) |> ignore

            Grid.SetRow(tabs, 2)
            rootGrid.Children.Add(tabs) |> ignore

            // 4. Footer Tip
            let footer = TextBlock(
                Text = "💡 Tips: Hover over chart items for interactive tooltips. Scroll wheel over charts to zoom, drag mouse to pan. Click 'Theme' to toggle dark mode.",
                FontSize = 12.0,
                Foreground = SolidColorBrush(Color.FromRgb(100uy, 116uy, 139uy)),
                Margin = Thickness(4.0, 10.0, 0.0, 0.0)
            )
            Grid.SetRow(footer, 3)
            rootGrid.Children.Add(footer) |> ignore

            this.Content <- rootGrid

            // Event handlers
            btnTheme.Click.Add(fun _ ->
                isDark <- not isDark
                btnTheme.Content <- if isDark then "Theme: Dark" else "Theme: Light"
                let theme = if isDark then LengkoChartTheme.Dark else LengkoChartTheme.Light
                LengkoChartThemeScope.DefaultTheme <- theme
                LengkoChartThemeScope.SetTheme(rootGrid, theme)
                LengkoChartThemeScope.ApplyToTree(rootGrid, theme)

                let bg = if isDark then Color.FromRgb(15uy, 23uy, 42uy) else Color.FromRgb(248uy, 250uy, 252uy)
                let cardBg = if isDark then Color.FromRgb(30uy, 41uy, 59uy) else Colors.White
                let cardBorder = if isDark then Color.FromRgb(51uy, 65uy, 85uy) else Color.FromRgb(226uy, 232uy, 240uy)
                let textPrimary = if isDark then Color.FromRgb(241uy, 245uy, 249uy) else Color.FromRgb(15uy, 23uy, 42uy)
                let textSecondary = if isDark then Color.FromRgb(148uy, 163uy, 184uy) else Color.FromRgb(100uy, 116uy, 139uy)

                this.Background <- SolidColorBrush(bg)
                mainTitle.Foreground <- SolidColorBrush(textPrimary)
                mainSub.Foreground <- SolidColorBrush(textSecondary)
                footer.Foreground <- SolidColorBrush(textSecondary)

                for c in cardRefs do
                    c.CardBorder.Background <- SolidColorBrush(cardBg)
                    c.CardBorder.BorderBrush <- SolidColorBrush(cardBorder)
                    c.TitleBlock.Foreground <- SolidColorBrush(textPrimary)
                    c.SubBlock.Foreground <- SolidColorBrush(textSecondary)
            )

            btnDonut.Click.Add(fun _ ->
                pieChart.IsDonut <- not pieChart.IsDonut
                btnDonut.Content <- if pieChart.IsDonut then "Pie Mode: Donut" else "Pie Mode: Standard"
            )

            btnSmooth.Click.Add(fun _ ->
                lineChart.SmoothCurves <- not lineChart.SmoothCurves
                areaChart.SmoothCurves <- not areaChart.SmoothCurves
                btnSmooth.Content <- if lineChart.SmoothCurves then "Line Curve: Smooth" else "Line Curve: Straight"
            )

            btnRandomize.Click.Add(fun _ ->
                for srs in barChart.Series do
                    for i in 0 .. srs.Values.Count - 1 do
                        srs.Values.[i] <- float (rand.Next(30, 260))
                barChart.InvalidateVisual()

                for it in hBarChart.Items do
                    it.Value <- float (rand.Next(40, 100))
                hBarChart.InvalidateVisual()

                for srs in lineChart.Series do
                    for i in 0 .. srs.Values.Count - 1 do
                        srs.Values.[i] <- float (rand.Next(15, 110))
                lineChart.InvalidateVisual()

                for slc in pieChart.Slices do
                    slc.Value <- float (rand.Next(10, 60))
                pieChart.InvalidateVisual()

                for slc in donutChart.Slices do
                    slc.Value <- float (rand.Next(10, 60))
                donutChart.InvalidateVisual()

                for srs in radarChart.Series do
                    for i in 0 .. srs.Values.Count - 1 do
                        srs.Values.[i] <- float (rand.Next(40, 99))
                radarChart.InvalidateVisual()

                gaugeChart.Value <- float (rand.Next(20, 98))
                bulletChart.Value <- float (rand.Next(40, 95))

                let sparkData = [| for _ in 1 .. 11 -> float (rand.Next(10, 65)) |]
                sparklineChart.SetData(sparkData)
            )

            // Populate sample data
            // Tab 1: Bars & Columns
            barChart.Categories.Add("Q1")
            barChart.Categories.Add("Q2")
            barChart.Categories.Add("Q3")
            barChart.Categories.Add("Q4")
            barChart.Series.Add(LengkoBarSeries("Revenue", [| 120.0; 150.0; 180.0; 220.0 |], Color.FromRgb(59uy, 130uy, 246uy)))
            barChart.Series.Add(LengkoBarSeries("Profit", [| 45.0; 60.0; 75.0; 95.0 |], Color.FromRgb(16uy, 185uy, 129uy)))

            hBarChart.AddItem("TypeScript", 88.0, Color.FromRgb(59uy, 130uy, 246uy))
            hBarChart.AddItem("C# / .NET", 94.0, Color.FromRgb(139uy, 92uy, 246uy))
            hBarChart.AddItem("Python", 82.0, Color.FromRgb(245uy, 158uy, 11uy))
            hBarChart.AddItem("Go", 75.0, Color.FromRgb(6uy, 182uy, 212uy))
            hBarChart.AddItem("Rust", 70.0, Color.FromRgb(239uy, 68uy, 68uy))

            stackedBar.Categories.Add("2021")
            stackedBar.Categories.Add("2022")
            stackedBar.Categories.Add("2023")
            stackedBar.Categories.Add("2024")
            stackedBar.Series.Add(LengkoBarSeries("Cloud", [| 40.0; 55.0; 75.0; 110.0 |], Color.FromRgb(59uy, 130uy, 246uy)))
            stackedBar.Series.Add(LengkoBarSeries("On-Prem", [| 60.0; 50.0; 45.0; 30.0 |], Color.FromRgb(16uy, 185uy, 129uy)))
            stackedBar.Series.Add(LengkoBarSeries("Support", [| 20.0; 25.0; 30.0; 35.0 |], Color.FromRgb(245uy, 158uy, 11uy)))

            hist.SetData([| 18.0; 22.0; 25.0; 27.0; 30.0; 32.0; 34.0; 35.0; 38.0; 40.0; 42.0; 44.0; 45.0; 48.0; 52.0; 55.0; 60.0; 65.0; 72.0 |], 6)

            pareto.Items.Add(LengkoParetoItem("Timeout 504", 142.0))
            pareto.Items.Add(LengkoParetoItem("Auth 401", 95.0))
            pareto.Items.Add(LengkoParetoItem("NullRef", 48.0))
            pareto.Items.Add(LengkoParetoItem("DB Lock", 24.0))
            pareto.Items.Add(LengkoParetoItem("Bad Format", 12.0))

            waterfall.Items.Add(LengkoWaterfallItem("Start Cash", 120.0, isTotal = true))
            waterfall.Items.Add(LengkoWaterfallItem("Product Sales", 52.0))
            waterfall.Items.Add(LengkoWaterfallItem("Subscriptions", 30.0))
            waterfall.Items.Add(LengkoWaterfallItem("Salaries", -42.0))
            waterfall.Items.Add(LengkoWaterfallItem("Cloud Hosting", -18.0))
            waterfall.Items.Add(LengkoWaterfallItem("Marketing", -14.0))
            waterfall.Items.Add(LengkoWaterfallItem("Net End Cash", 0.0, isTotal = true))

            // Tab 2: Lines & Areas
            lineChart.Series.Add(LengkoLineSeries("Traffic (k)", [| 22.0; 34.0; 45.0; 40.0; 58.0; 65.0; 80.0 |], Color.FromRgb(99uy, 102uy, 241uy)))
            lineChart.Series.Add(LengkoLineSeries("Signups", [| 10.0; 18.0; 24.0; 28.0; 35.0; 42.0; 55.0 |], Color.FromRgb(236uy, 72uy, 153uy)))

            areaChart.Labels.Add("Jan")
            areaChart.Labels.Add("Feb")
            areaChart.Labels.Add("Mar")
            areaChart.Labels.Add("Apr")
            areaChart.Labels.Add("May")
            areaChart.Labels.Add("Jun")
            areaChart.Series.Add(LengkoAreaSeries("Inbound", [| 30.0; 45.0; 52.0; 68.0; 74.0; 90.0 |], Color.FromRgb(59uy, 130uy, 246uy)))
            areaChart.Series.Add(LengkoAreaSeries("Outbound", [| 18.0; 25.0; 32.0; 40.0; 48.0; 62.0 |], Color.FromRgb(16uy, 185uy, 129uy)))

            stackedArea.Categories.Add("Jan")
            stackedArea.Categories.Add("Feb")
            stackedArea.Categories.Add("Mar")
            stackedArea.Categories.Add("Apr")
            stackedArea.Categories.Add("May")
            stackedArea.Categories.Add("Jun")
            stackedArea.Series.Add(LengkoAreaSeries("North", [| 25.0; 30.0; 38.0; 45.0; 52.0; 60.0 |], Color.FromRgb(14uy, 165uy, 233uy)))
            stackedArea.Series.Add(LengkoAreaSeries("South", [| 20.0; 24.0; 30.0; 36.0; 42.0; 48.0 |], Color.FromRgb(168uy, 85uy, 247uy)))
            stackedArea.Series.Add(LengkoAreaSeries("East", [| 15.0; 18.0; 22.0; 28.0; 32.0; 38.0 |], Color.FromRgb(249uy, 115uy, 22uy)))

            stepLine.Series.Add(LengkoStepSeries("Inventory", [| 100.0; 85.0; 85.0; 60.0; 120.0; 95.0; 70.0 |], Color.FromRgb(16uy, 185uy, 129uy)))
            stepLine.Series.Add(LengkoStepSeries("Threshold", [| 50.0; 50.0; 50.0; 50.0; 50.0; 50.0; 50.0 |], Color.FromRgb(239uy, 68uy, 68uy)))

            combo.Categories.Add("Q1")
            combo.Categories.Add("Q2")
            combo.Categories.Add("Q3")
            combo.Categories.Add("Q4")
            combo.BarSeries.Add(LengkoBarSeries("Units Sold", [| 320.0; 450.0; 580.0; 710.0 |], Color.FromRgb(59uy, 130uy, 246uy)))
            combo.LineSeries.Add(LengkoLineSeries("Margin %", [| 22.0; 28.0; 26.0; 31.0 |], Color.FromRgb(239uy, 68uy, 68uy)))

            generic.AddPoint("CPU", 48.0)
            generic.AddPoint("RAM", 72.0)
            generic.AddPoint("Disk", 60.0)
            generic.AddPoint("Network", 35.0)
            generic.AddPoint("GPU", 84.0)

            // Tab 3: Circular & Polar
            pieChart.Slices.Add(LengkoPieSlice("North America", 38.0, Color.FromRgb(59uy, 130uy, 246uy)))
            pieChart.Slices.Add(LengkoPieSlice("Europe", 27.0, Color.FromRgb(16uy, 185uy, 129uy)))
            pieChart.Slices.Add(LengkoPieSlice("Asia Pacific", 23.0, Color.FromRgb(245uy, 158uy, 11uy)))
            pieChart.Slices.Add(LengkoPieSlice("Latin America", 12.0, Color.FromRgb(239uy, 68uy, 68uy)))

            donutChart.Slices.Add(LengkoPieSlice("Enterprise", 45.0, Color.FromRgb(99uy, 102uy, 241uy)))
            donutChart.Slices.Add(LengkoPieSlice("SMB", 30.0, Color.FromRgb(236uy, 72uy, 153uy)))
            donutChart.Slices.Add(LengkoPieSlice("Startup", 15.0, Color.FromRgb(20uy, 184uy, 166uy)))
            donutChart.Slices.Add(LengkoPieSlice("Consumer", 10.0, Color.FromRgb(245uy, 158uy, 11uy)))

            radarChart.Axes.Add("Speed")
            radarChart.Axes.Add("Reliability")
            radarChart.Axes.Add("Usability")
            radarChart.Axes.Add("Security")
            radarChart.Axes.Add("Scalability")
            radarChart.Series.Add(LengkoRadarSeries("Lengko UI", [| 92.0; 95.0; 88.0; 90.0; 94.0 |], Color.FromRgb(139uy, 92uy, 246uy)))
            radarChart.Series.Add(LengkoRadarSeries("Standard", [| 65.0; 70.0; 60.0; 75.0; 68.0 |], Color.FromRgb(148uy, 163uy, 184uy)))

            polar.Items.Add(LengkoPolarItem("North", 45.0, Color.FromRgb(59uy, 130uy, 246uy)))
            polar.Items.Add(LengkoPolarItem("NE", 60.0, Color.FromRgb(99uy, 102uy, 241uy)))
            polar.Items.Add(LengkoPolarItem("East", 80.0, Color.FromRgb(139uy, 92uy, 246uy)))
            polar.Items.Add(LengkoPolarItem("SE", 50.0, Color.FromRgb(236uy, 72uy, 153uy)))
            polar.Items.Add(LengkoPolarItem("South", 35.0, Color.FromRgb(244uy, 63uy, 94uy)))
            polar.Items.Add(LengkoPolarItem("SW", 55.0, Color.FromRgb(245uy, 158uy, 11uy)))
            polar.Items.Add(LengkoPolarItem("West", 75.0, Color.FromRgb(16uy, 185uy, 129uy)))
            polar.Items.Add(LengkoPolarItem("NW", 40.0, Color.FromRgb(20uy, 184uy, 166uy)))

            sunburst.Items.Add(LengkoSunburstItem("Software", 60.0, 0, Color.FromRgb(59uy, 130uy, 246uy)))
            sunburst.Items.Add(LengkoSunburstItem("Hardware", 40.0, 0, Color.FromRgb(16uy, 185uy, 129uy)))
            sunburst.Items.Add(LengkoSunburstItem("Desktop", 35.0, 1, Color.FromRgb(99uy, 102uy, 241uy)))
            sunburst.Items.Add(LengkoSunburstItem("Mobile", 25.0, 1, Color.FromRgb(14uy, 165uy, 233uy)))
            sunburst.Items.Add(LengkoSunburstItem("Servers", 25.0, 1, Color.FromRgb(34uy, 197uy, 94uy)))
            sunburst.Items.Add(LengkoSunburstItem("IoT", 15.0, 1, Color.FromRgb(245uy, 158uy, 11uy)))

            // Tab 4: Financial & Timelines
            candle.AddCandle("09:30", 150.2, 153.5, 149.8, 152.8, 142000.0)
            candle.AddCandle("10:00", 152.8, 154.0, 151.2, 151.6, 98000.0)
            candle.AddCandle("10:30", 151.6, 155.2, 151.0, 154.5, 175000.0)
            candle.AddCandle("11:00", 154.5, 156.0, 153.8, 155.8, 110000.0)
            candle.AddCandle("11:30", 155.8, 156.2, 153.0, 153.4, 130000.0)

            ohlc.Bars.Add(LengkoOhlcBar("Mon", 100.0, 108.0, 98.0, 105.0))
            ohlc.Bars.Add(LengkoOhlcBar("Tue", 105.0, 110.0, 102.0, 104.0))
            ohlc.Bars.Add(LengkoOhlcBar("Wed", 104.0, 114.0, 103.0, 112.0))
            ohlc.Bars.Add(LengkoOhlcBar("Thu", 112.0, 115.0, 108.0, 109.0))
            ohlc.Bars.Add(LengkoOhlcBar("Fri", 109.0, 118.0, 107.0, 116.0))

            let baseDate = DateTime.Today
            gantt.Tasks.Add(LengkoGanttItem("Architecture & API", baseDate, baseDate.AddDays(5.0), 100))
            gantt.Tasks.Add(LengkoGanttItem("Core Chart Engine", baseDate.AddDays(3.0), baseDate.AddDays(10.0), 80))
            gantt.Tasks.Add(LengkoGanttItem("32 WPF Controls", baseDate.AddDays(6.0), baseDate.AddDays(15.0), 55))
            gantt.Tasks.Add(LengkoGanttItem("Testing & Packaging", baseDate.AddDays(12.0), baseDate.AddDays(18.0), 20))

            // Tab 5: Hierarchy & Flow
            treemap.Items.Add(LengkoTreemapItem("Finance", 420.0))
            treemap.Items.Add(LengkoTreemapItem("Engineering", 350.0))
            treemap.Items.Add(LengkoTreemapItem("Marketing", 220.0))
            treemap.Items.Add(LengkoTreemapItem("Support", 160.0))
            treemap.Items.Add(LengkoTreemapItem("Legal & HR", 90.0))

            sankey.Links.Add(LengkoSankeyLink("Organic Search", "Landing Page", 140.0))
            sankey.Links.Add(LengkoSankeyLink("Paid Ads", "Landing Page", 90.0))
            sankey.Links.Add(LengkoSankeyLink("Referral", "Product Specs", 65.0))
            sankey.Links.Add(LengkoSankeyLink("Landing Page", "Pricing", 130.0))
            sankey.Links.Add(LengkoSankeyLink("Landing Page", "Checkout", 70.0))
            sankey.Links.Add(LengkoSankeyLink("Pricing", "Checkout", 100.0))
            sankey.Links.Add(LengkoSankeyLink("Product Specs", "Checkout", 45.0))

            funnel.Stages.Add(LengkoFunnelStage("Website Visits", 12500.0))
            funnel.Stages.Add(LengkoFunnelStage("Sign Up", 5200.0))
            funnel.Stages.Add(LengkoFunnelStage("Cart Added", 2800.0))
            funnel.Stages.Add(LengkoFunnelStage("Checkout Started", 1600.0))
            funnel.Stages.Add(LengkoFunnelStage("Purchased", 1100.0))

            pyramid.Stages.Add(LengkoPyramidStage("Executives", 8.0))
            pyramid.Stages.Add(LengkoPyramidStage("Directors", 24.0))
            pyramid.Stages.Add(LengkoPyramidStage("Team Leads", 65.0))
            pyramid.Stages.Add(LengkoPyramidStage("Specialists", 180.0))
            pyramid.Stages.Add(LengkoPyramidStage("Associates", 340.0))

            heatmap.RowLabels.Add("Mon")
            heatmap.RowLabels.Add("Tue")
            heatmap.RowLabels.Add("Wed")
            heatmap.RowLabels.Add("Thu")
            heatmap.RowLabels.Add("Fri")
            heatmap.ColumnLabels.Add("09:00")
            heatmap.ColumnLabels.Add("12:00")
            heatmap.ColumnLabels.Add("15:00")
            heatmap.ColumnLabels.Add("18:00")
            heatmap.ColumnLabels.Add("21:00")
            let matrix: float[,] = array2D [
                [ 20.0; 45.0; 78.0; 60.0; 30.0 ]
                [ 35.0; 60.0; 92.0; 85.0; 40.0 ]
                [ 40.0; 75.0; 95.0; 80.0; 50.0 ]
                [ 30.0; 65.0; 88.0; 70.0; 45.0 ]
                [ 25.0; 50.0; 70.0; 90.0; 65.0 ]
            ]
            for r in 0 .. 4 do
                for c in 0 .. 4 do
                    heatmap.SetCell(r, c, matrix.[r, c])

            // Tab 6: KPIs & Statistical
            gaugeChart.Value <- 76.5
            gaugeChart.Title <- "Server Load"
            gaugeChart.Unit <- "%"

            bulletChart.Title <- "YTD Sales"
            bulletChart.Subtitle <- "$ in Thousands"
            bulletChart.Value <- 82.0
            bulletChart.Target <- 88.0
            bulletChart.BadThreshold <- 50.0
            bulletChart.SatisfactoryThreshold <- 75.0

            sparklineChart.SetData([| 14.0; 18.0; 15.0; 22.0; 28.0; 25.0; 32.0; 40.0; 38.0; 48.0; 52.0 |])

            let blue = Color.FromRgb(59uy, 130uy, 246uy)
            scatter.Points.Add(LengkoScatterPoint(10.0, 25.0, blue, "A1"))
            scatter.Points.Add(LengkoScatterPoint(20.0, 38.0, blue, "A2"))
            scatter.Points.Add(LengkoScatterPoint(30.0, 52.0, blue, "A3"))
            scatter.Points.Add(LengkoScatterPoint(40.0, 66.0, blue, "A4"))
            scatter.Points.Add(LengkoScatterPoint(50.0, 80.0, blue, "A5"))
            let red = Color.FromRgb(239uy, 68uy, 68uy)
            scatter.Points.Add(LengkoScatterPoint(12.0, 18.0, red, "B1"))
            scatter.Points.Add(LengkoScatterPoint(22.0, 30.0, red, "B2"))
            scatter.Points.Add(LengkoScatterPoint(32.0, 40.0, red, "B3"))
            scatter.Points.Add(LengkoScatterPoint(42.0, 58.0, red, "B4"))
            scatter.Points.Add(LengkoScatterPoint(52.0, 70.0, red, "B5"))

            bubble.Points.Add(LengkoBubblePoint(15.0, 45.0, 14.0, "Opportunity A", Color.FromRgb(59uy, 130uy, 246uy)))
            bubble.Points.Add(LengkoBubblePoint(30.0, 70.0, 22.0, "Opportunity B", Color.FromRgb(16uy, 185uy, 129uy)))
            bubble.Points.Add(LengkoBubblePoint(55.0, 35.0, 18.0, "Opportunity C", Color.FromRgb(245uy, 158uy, 11uy)))
            bubble.Points.Add(LengkoBubblePoint(75.0, 85.0, 30.0, "Strategic Bet", Color.FromRgb(139uy, 92uy, 246uy)))
            bubble.Points.Add(LengkoBubblePoint(85.0, 50.0, 16.0, "Core Business", Color.FromRgb(236uy, 72uy, 153uy)))

            boxplot.Items.Add(LengkoBoxPlotItem("Group A", 20.0, 35.0, 50.0, 68.0, 85.0))
            boxplot.Items.Add(LengkoBoxPlotItem("Group B", 30.0, 45.0, 62.0, 78.0, 92.0))
            boxplot.Items.Add(LengkoBoxPlotItem("Group C", 15.0, 28.0, 42.0, 58.0, 75.0))

            errorbar.Points.Add(LengkoErrorPoint("Sample 1", 45.0, 5.0, 6.0))
            errorbar.Points.Add(LengkoErrorPoint("Sample 2", 62.0, 8.0, 7.0))
            errorbar.Points.Add(LengkoErrorPoint("Sample 3", 53.0, 4.0, 5.0))
            errorbar.Points.Add(LengkoErrorPoint("Sample 4", 78.0, 9.0, 8.0))

    [<STAThread>]
    [<EntryPoint>]
    let main _ =
        let app = Application()
        let win = MainWindow()
        app.Run(win)
