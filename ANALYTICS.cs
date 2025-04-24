using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using static Cozify.dbHelper;
using System.Globalization;
using System.Text;

namespace Cozify
{
    public partial class ANALYTICS : BaseForm
    {
        private Chart mainChart;
        private Panel currentView;
        public ANALYTICS()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void InitializeChart()
        {
            pnlChartContainer.Controls.Clear();

            // Create main chart control (hidden by default)
            mainChart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Visible = false
            };
            pnlChartContainer.Controls.Add(mainChart);

            // Create container for non-chart views
            currentView = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Visible = false
            };
            pnlChartContainer.Controls.Add(currentView);

            // Ensure the chart is on top in the Z-order
            mainChart.BringToFront();
        }

        private void btnPomoUsage_Click(object sender, EventArgs e)
        {
            LoadPomoUsage();
            mainChart.Visible = true;
            currentView.Visible = false;
        }
        private void LoadPomoUsage()
        {
            var dailyData = db.GetDailyPomodoroData(GlobalUser.LoggedInUsername);

            if (dailyData == null || dailyData.Count == 0)
            {
                MessageBox.Show("No Pomodoro data available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            mainChart.Titles.Clear();
            mainChart.Legends.Clear();
            mainChart.BackColor = Color.FromArgb(34, 40, 49); // Cozy dark background
            mainChart.BorderlineColor = Color.Transparent;

            Font pixelFontSmall = new Font("Pixeltype", 18, FontStyle.Regular);
            Font pixelFontLabel = new Font("Pixeltype", 18, FontStyle.Regular);
            Font pixelFontTitle = new Font("Pixeltype", 20, FontStyle.Regular);

            var area = new ChartArea("MainArea")
            {
                BackColor = Color.FromArgb(34, 40, 49),
                BorderColor = Color.Transparent,
                AxisX =
        {
            Title = "Date",
            TitleFont = pixelFontLabel,
            TitleForeColor = Color.WhiteSmoke,
            LineColor = Color.LightGray,
            LabelStyle = { ForeColor = Color.WhiteSmoke, Font = pixelFontSmall, Format = "MMM dd" },
            MajorGrid = { LineColor = Color.FromArgb(64, 64, 64) }
        },
                AxisY =
        {
            Title = "Minutes",
            TitleFont = pixelFontLabel,
            TitleForeColor = Color.WhiteSmoke,
            LineColor = Color.LightGray,
            LabelStyle = { ForeColor = Color.WhiteSmoke, Font = pixelFontSmall },
            MajorGrid = { LineColor = Color.FromArgb(64, 64, 64) },
            Minimum = 0
        },
                AxisY2 =
        {
            Title = "Sessions",
            TitleFont = pixelFontLabel,
            TitleForeColor = Color.WhiteSmoke,
            LineColor = Color.LightGray,
            LabelStyle = { ForeColor = Color.WhiteSmoke, Font = pixelFontSmall },
            MajorGrid = { LineColor = Color.FromArgb(64, 64, 64) },
            Minimum = 0,
            Enabled = AxisEnabled.True
        }
            };
            mainChart.ChartAreas.Add(area);

            var workSeries = new Series("Work Time")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(129, 199, 132),
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Int32
            };

            var breakSeries = new Series("Break Time")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(239, 154, 154),
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Int32
            };

            var sessionSeries = new Series("Sessions Completed")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.FromArgb(144, 202, 249),
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Int32,
                YAxisType = AxisType.Secondary
            };

            foreach (var day in dailyData)
            {
                workSeries.Points.AddXY(day.Date, day.WorkMinutes);
                breakSeries.Points.AddXY(day.Date, day.BreakMinutes);
                sessionSeries.Points.AddXY(day.Date, day.CompletedSessions);
            }

            mainChart.Series.Add(workSeries);
            mainChart.Series.Add(breakSeries);
            mainChart.Series.Add(sessionSeries);

            // Pixeltype title
            mainChart.Titles.Add(new Title("Weekly Pomodoro Usage", Docking.Top, pixelFontTitle, Color.WhiteSmoke));

            var legend = new Legend
            {
                Title = "Metrics",
                Font = pixelFontSmall,
                TitleFont = pixelFontLabel,
                ForeColor = Color.WhiteSmoke,
                TitleForeColor = Color.WhiteSmoke,
                Docking = Docking.Right,
                BackColor = Color.FromArgb(45, 50, 60),
                BorderColor = Color.Gray
            };
            mainChart.Legends.Add(legend);

            mainChart.Invalidate();
            mainChart.Visible = true;
            currentView.Visible = false;
        }


        private void btnHabitStreak_Click(object sender, EventArgs e)
        {
            try
            {
                var streakData = db.GetHabitStreakData(GlobalUser.LoggedInUsername);
                Show7WeekStreakCalendar(streakData);
                mainChart.Visible = false;
                currentView.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading streak data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Show7WeekStreakCalendar(StreakAnalyticsData streakData)
        {
            currentView.Controls.Clear();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(34, 40, 49)
            };

            var table = new TableLayoutPanel
            {
                ColumnCount = 8,
                RowCount = 8,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.FromArgb(52, 73, 91),
                Dock = DockStyle.Fill,
                AutoSize = false
            };

            for (int i = 0; i < 8; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));

            for (int i = 0; i < 8; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 8));

            // Define fonts
            Font pixelHeaderFont = new Font("Pixeltype", 23, FontStyle.Bold);
            Font pixelWeekFont = new Font("Pixeltype", 14, FontStyle.Regular);
            Font pixelSummaryFont = new Font("Pixeltype", 20, FontStyle.Italic);
            Font pixelDayFont = new Font("Pixeltype", 13, FontStyle.Regular);

            // Add header
            table.Controls.Add(new Label
            {
                Text = "Week",
                Font = pixelHeaderFont,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(52, 73, 91),
                BorderStyle = BorderStyle.FixedSingle
            }, 0, 0);

            DateTime today = DateTime.Today;
            DateTime startDate = today.AddDays(-(7 * 6));

            for (int week = 0; week < 7; week++)
            {
                DateTime weekStart = startDate.AddDays(week * 7);

                var weekLabel = new Label
                {
                    Text = $"{weekStart:MMM dd}\n{weekStart.AddDays(6):MMM dd}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = pixelWeekFont,
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(52, 73, 91),
                    BorderStyle = BorderStyle.FixedSingle
                };
                table.Controls.Add(weekLabel, 0, week + 1);

                for (int day = 0; day < 7; day++)
                {
                    DateTime date = weekStart.AddDays(day);
                    var dayPanel = new Panel
                    {
                        BackColor = GetDayColor(streakData, date),
                        Margin = new Padding(0),
                        Tag = date,
                        Cursor = Cursors.Hand,
                        Dock = DockStyle.Fill,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    var dayLabel = new Label
                    {
                        Text = date.Day.ToString(),
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = pixelDayFont,
                        ForeColor = date.Date == today.Date ? Color.Yellow : Color.White,
                        BackColor = Color.Transparent
                    };
                    dayPanel.Controls.Add(dayLabel);

                    var tooltip = new StringBuilder();
                    tooltip.AppendLine($"{date:yyyy-MM-dd (dddd)}");

                    int completedCount = 0;
                    foreach (var habit in streakData.HabitStreaks)
                    {
                        if (habit.CompletionHistory.TryGetValue(date.Date, out bool completed))
                        {
                            tooltip.AppendLine($"• {habit.HabitName}: {(completed ? "✓" : "✗")}");
                            if (completed) completedCount++;
                        }
                    }

                    if (streakData.HabitStreaks.Count > 0)
                        tooltip.AppendLine($"\nCompletion: {completedCount}/{streakData.HabitStreaks.Count} habits");

                    new ToolTip().SetToolTip(dayPanel, tooltip.ToString());

                    dayPanel.Click += (sender, e) =>
                    {
                        MessageBox.Show(tooltip.ToString(), $"{date:yyyy-MM-dd} Details");
                    };

                    table.Controls.Add(dayPanel, day + 1, week + 1);
                }
            }

            panel.Controls.Add(table);
            currentView.Controls.Add(panel);

            var summaryLabel = new Label
            {
                Text = $"Showing last 7 weeks of habit completion\n" +
                       $"Current streak: {streakData.TotalCurrentStreak} days | " +
                       $"Longest streak: {streakData.TotalLongestStreak} days",
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = pixelSummaryFont,
                Height = 40,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 56, 69)
            };
            currentView.Controls.Add(summaryLabel);
            currentView.Visible = true;
            mainChart.Visible = false;
        }


        private Color GetDayColor(StreakAnalyticsData streakData, DateTime date)
        {
            if (streakData.HabitStreaks.Count == 0)
                return Color.FromArgb(40, 56, 69);

            int completedHabits = streakData.HabitStreaks
                .Count(h => h.CompletionHistory.TryGetValue(date.Date, out bool completed) && completed);

            if (completedHabits == 0)
                return Color.FromArgb(40, 56, 69);

            double ratio = (double)completedHabits / streakData.HabitStreaks.Count;

            int greenBlue = (int)(230 - (230 * ratio)); // from 230 down to 0
            return Color.FromArgb(255, greenBlue, greenBlue); // Stays red, fades green/blue
        }

        private void btnCloseAnalytics_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnTasksDoneThisWeek_Click(object sender, EventArgs e)
        {
            LoadTaskData();
        }
        private void LoadTaskData()
        {
            try
            {
                var weeklyData = db.GetThisWeeksTaskData(GlobalUser.LoggedInUsername);

                // Clear chart
                mainChart.Series.Clear();
                mainChart.ChartAreas.Clear();
                mainChart.Titles.Clear();
                mainChart.Legends.Clear();

                // Define fonts
                Font pixelFontSmall = new Font("Pixeltype", 16, FontStyle.Regular);
                Font pixelFontLabel = new Font("Pixeltype", 18, FontStyle.Regular);
                Font pixelFontTitle = new Font("Pixeltype", 20, FontStyle.Regular);

                // Set up chart area
                var area = new ChartArea("TasksArea");
                area.BackColor = Color.FromArgb(34, 40, 49);

                area.AxisX.Title = "Day";
                area.AxisX.TitleForeColor = Color.White;
                area.AxisX.TitleFont = pixelFontLabel;
                area.AxisX.Interval = 1;
                area.AxisX.IntervalType = DateTimeIntervalType.Days;
                area.AxisX.LabelStyle.Format = "ddd";
                area.AxisX.LabelStyle.Font = pixelFontSmall;
                area.AxisX.LabelStyle.ForeColor = Color.White;
                area.AxisX.LineColor = Color.White;
                area.AxisX.MajorGrid.LineColor = Color.FromArgb(52, 73, 91);

                area.AxisY.Title = "Number of Tasks";
                area.AxisY.TitleForeColor = Color.White;
                area.AxisY.TitleFont = pixelFontLabel;
                area.AxisY.Minimum = 0;
                area.AxisY.LabelStyle.Font = pixelFontSmall;
                area.AxisY.LabelStyle.ForeColor = Color.White;
                area.AxisY.LineColor = Color.White;
                area.AxisY.MajorGrid.LineColor = Color.FromArgb(52, 73, 91);

                area.AxisX.MajorTickMark.LineColor = Color.White;
                area.AxisY.MajorTickMark.LineColor = Color.White;

                mainChart.ChartAreas.Add(area);

                // Series for completed tasks
                var completedSeries = new Series("Completed Tasks")
                {
                    ChartType = SeriesChartType.StackedColumn,
                    Color = Color.FromArgb(88, 214, 141), // Green for completed
                    XValueType = ChartValueType.DateTime,
                    YValueType = ChartValueType.Int32,
                    IsValueShownAsLabel = true,
                    LabelFormat = "{0}",
                    Font = pixelFontSmall,
                    LabelForeColor = Color.White,
                    ToolTip = "Date: #AXISLABEL\nCompleted: #VAL tasks",
                    
                };
                completedSeries.IsValueShownAsLabel = false;
                
                // Series for pending tasks
                var pendingSeries = new Series("Pending Tasks")
                {
                    ChartType = SeriesChartType.StackedColumn,
                    Color = Color.FromArgb(242, 76, 76), // Red for pending
                    XValueType = ChartValueType.DateTime,
                    YValueType = ChartValueType.Int32,
                    IsValueShownAsLabel = true,
                    LabelFormat = "{0}",
                    Font = pixelFontSmall,
                    LabelForeColor = Color.White,
                    ToolTip = "Date: #AXISLABEL\nIncomplete: #VAL tasks"
                };
                pendingSeries.IsValueShownAsLabel = false;
                // Add data points
                foreach (var day in weeklyData)
                {
                    completedSeries.Points.AddXY(day.Date, day.CompletedTasks);
                    pendingSeries.Points.AddXY(day.Date, day.TotalTasks - day.CompletedTasks);
                }

                // Add series to chart (order matters for stacking)
                mainChart.Series.Add(pendingSeries);
                mainChart.Series.Add(completedSeries);

                // Title
                if (weeklyData.Any())
                {
                    string weekRange = $"{weeklyData.First().Date:MMM dd} - {weeklyData.Last().Date:MMM dd}";
                    int weeklyCompleted = weeklyData.Sum(d => d.CompletedTasks);
                    int weeklyPending = weeklyData.Sum(d => d.TotalTasks - d.CompletedTasks);

                    var chartTitle = new Title($"Task Completion This Week\n{weekRange}\nCompleted: {weeklyCompleted} | Incomplete: {weeklyPending}",
                        Docking.Top,
                        pixelFontTitle,
                        Color.White);
                    mainChart.Titles.Add(chartTitle);
                }

                // Legend
                var legend = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    Font = pixelFontSmall,
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(40, 56, 69)
                };
                mainChart.Legends.Add(legend);

                // Chart background
                mainChart.BackColor = Color.FromArgb(34, 40, 49);

                mainChart.Invalidate();
                mainChart.Visible = true;
                currentView.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading task data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

