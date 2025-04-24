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

            // Clear existing elements
            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            mainChart.Titles.Clear();
            mainChart.Legends.Clear();

            // Set up chart area
            var area = new ChartArea("MainArea")
            {
                AxisX =
        {
            Title = "Date",
            Interval = 1,
            IntervalType = DateTimeIntervalType.Days,
            LabelStyle = { Format = "MMM dd" }
        },
                AxisY =
        {
            Title = "Minutes",
            Minimum = 0
        },
                AxisY2 =
        {
            Title = "Sessions",
            Minimum = 0,
            Enabled = AxisEnabled.True
        }
            };
            mainChart.ChartAreas.Add(area);

            // Create series
            var workSeries = new Series("Work Time")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(76, 175, 80),
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Int32
            };

            var breakSeries = new Series("Break Time")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(244, 67, 54),
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Int32
            };

            var sessionSeries = new Series("Sessions Completed")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.FromArgb(33, 150, 243),
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Int32,
                YAxisType = AxisType.Secondary
            };

            // Add data points
            foreach (var day in dailyData)
            {
                workSeries.Points.AddXY(day.Date, day.WorkMinutes);
                breakSeries.Points.AddXY(day.Date, day.BreakMinutes);
                sessionSeries.Points.AddXY(day.Date, day.CompletedSessions);
            }

            // Add series to chart
            mainChart.Series.Add(workSeries);
            mainChart.Series.Add(breakSeries);
            mainChart.Series.Add(sessionSeries);

            // Add title
            mainChart.Titles.Add(new Title("Weekly Pomodoro Usage",
                Docking.Top,
                new Font("Segoe UI", 12, FontStyle.Bold),
                Color.Black));

            // Add legend
            var legend = new Legend
            {
                Title = "Metrics",
                Docking = Docking.Right,
                BackColor = Color.WhiteSmoke,
                BorderColor = Color.LightGray
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
                BackColor = Color.FromArgb(40, 56, 69)
            };

            var table = new TableLayoutPanel
            {
                ColumnCount = 8,
                RowCount = 8, // Header row + 7 data rows
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.FromArgb(52, 73, 91),
                Dock = DockStyle.Fill, // Make the table fill the panel
                AutoSize = false // Disable auto-sizing, we'll control the size
            };

            // Set equal width columns
            for (int i = 0; i < 8; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            }

            // Set equal height rows
            for (int i = 0; i < 8; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 8)); // Divide total height equally
            }

            // Add headers
            table.Controls.Add(new Label
            {
                Text = "Week",
                Font = new Font("Pixeltype", 23, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(52, 73, 91),
                BorderStyle = BorderStyle.FixedSingle
            }, 0, 0);

            // Show last 7 weeks
            DateTime today = DateTime.Today;
            DateTime startDate = today.AddDays(-(7 * 6));

            for (int week = 0; week < 7; week++)
            {
                DateTime weekStart = startDate.AddDays(week * 7);

                // Week label
                var weekLabel = new Label
                {
                    Text = $"{weekStart:MMM dd}\n{weekStart.AddDays(6):MMM dd}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Pixeltype", 14, FontStyle.Regular),
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
                        ForeColor = date.Date == today.Date ? Color.Yellow : Color.White,
                        BackColor = Color.Transparent
                    };
                    dayPanel.Controls.Add(dayLabel);

                    // Build detailed tooltip
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
                    {
                        tooltip.AppendLine($"\nCompletion: {completedCount}/{streakData.HabitStreaks.Count} habits");
                    }

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

            // Add summary label below the calendar
            var summaryLabel = new Label
            {
                Text = $"Showing last 7 weeks of habit completion\n" +
               $"Current streak: {streakData.TotalCurrentStreak} days | " +
               $"Longest streak: {streakData.TotalLongestStreak} days",
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Pixeltype", 20, FontStyle.Italic),
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
            try
            {
                var weeklyData = db.GetThisWeeksTaskData(GlobalUser.LoggedInUsername);

                // Clear existing elements
                mainChart.Series.Clear();
                mainChart.ChartAreas.Clear();
                mainChart.Titles.Clear();
                mainChart.Legends.Clear();

                // Set up chart area
                var area = new ChartArea("TasksArea")
                {
                    AxisX =
            {
                Title = "Day",
                Interval = 1,
                IntervalType = DateTimeIntervalType.Days,
                LabelStyle =
                {
                    Format = "ddd",
                    Font = new Font("Arial", 8, FontStyle.Bold)
                }
            },
                    AxisY =
            {
                Title = "Tasks Completed",
                Minimum = 0,
                MajorGrid = { Interval = 1 }
            }
                };
                mainChart.ChartAreas.Add(area);

                // Add completed tasks series
                var completedSeries = new Series("Completed Tasks")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.FromArgb(76, 175, 80),
                    XValueType = ChartValueType.DateTime,
                    YValueType = ChartValueType.Int32,
                    IsValueShownAsLabel = true,
                    LabelFormat = "{0}",
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    ToolTip = "Date: #AXISLABEL\nCompleted: #VAL tasks"
                };

                // Add data points
                foreach (var day in weeklyData)
                {
                    completedSeries.Points.AddXY(day.Date, day.CompletedTasks);
                }

                mainChart.Series.Add(completedSeries);

                // Add title
                if (weeklyData.Any())
                {
                    string weekRange = $"{weeklyData.First().Date:MMM dd} - {weeklyData.Last().Date:MMM dd}";
                    int weeklyTotal = weeklyData.Sum(d => d.CompletedTasks);

                    mainChart.Titles.Add(new Title($"Tasks Completed This Week\n{weekRange}\nTotal: {weeklyTotal} tasks",
                        Docking.Top,
                        new Font("Segoe UI", 10, FontStyle.Bold),
                        Color.Black));
                }

                // Add legend
                var legend = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Arial", 9)
                };
                mainChart.Legends.Add(legend);

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

