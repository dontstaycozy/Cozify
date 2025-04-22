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
        }

        private void btnPomoUsage_Click(object sender, EventArgs e)
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
        }


        private void btnHabitStreak_Click(object sender, EventArgs e)
        {
            try
            {
                var streakData = db.GetHabitStreakData(GlobalUser.LoggedInUsername);
                Show7WeekStreakCalendar(streakData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading streak data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Show7WeekStreakCalendar(StreakAnalyticsData streakData)
        {
            pnlChartContainer.Controls.Clear();
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            var table = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 8, // Week + 7 days
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.White,
                Dock = DockStyle.Fill
            };

            // Set column widths
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70)); // Week column
            for (int i = 0; i < 7; i++)
            {
               // table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40)); // Day columns
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            }

            // Add headers with better styling
            table.Controls.Add(new Label
            {
                Text = "Week",
                Font = new Font("Arial", 9, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            }, 0, 0);

            // Show last 7 weeks (including current week)
            DateTime today = DateTime.Today;
            DateTime startDate = today.AddDays(-(7 * 6)); // 6 weeks back + current week = 7 weeks total

            for (int week = 0; week < 7; week++)
            {
                table.RowCount++;
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Fixed row height

                DateTime weekStart = startDate.AddDays(week * 7);

                // Week label with start-end dates
                var weekLabel = new Label
                {
                    Text = $"{weekStart:MMM dd}\n{weekStart.AddDays(6):MMM dd}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 8)
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
                        Cursor = Cursors.Hand // Show hand cursor on hover
                    };

                    var dayLabel = new Label
                    {
                        Text = date.Day.ToString(),
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = date.Date == today.Date ? Color.Red : Color.Black // Highlight today
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

                    // Add click event if you want to make days interactive
                    dayPanel.Click += (sender, e) =>
                    {
                        MessageBox.Show(tooltip.ToString(), $"{date:yyyy-MM-dd} Details");
                    };

                    table.Controls.Add(dayPanel, day + 1, week + 1);
                }
            }

            panel.Controls.Add(table);
            pnlChartContainer.Controls.Add(panel);

            // Add summary label at the bottom
            var summaryLabel = new Label
            {
                Text = $"Showing last 7 weeks of habit completion\n" +
                       $"Current streak: {streakData.TotalCurrentStreak} days | " +
                       $"Longest streak: {streakData.TotalLongestStreak} days",
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Italic),
                Height = 40
            };
            pnlChartContainer.Controls.Add(summaryLabel);
        }

        private Color GetDayColor(StreakAnalyticsData streakData, DateTime date)
        {
            if (streakData.HabitStreaks.Count == 0)
                return Color.LightGray;

            int completedHabits = streakData.HabitStreaks
                .Count(h => h.CompletionHistory.TryGetValue(date.Date, out bool completed) && completed);

            if (completedHabits == 0)
                return Color.FromArgb(255, 230, 230); // Light red for 0%

            double completionRatio = (double)completedHabits / streakData.HabitStreaks.Count;

            // Gradient from red (0%) to green (100%)
            return Color.FromArgb(
                255 - (int)(155 * completionRatio),    // Red component decreases
                255 - (int)(155 * (1 - completionRatio)), // Green component increases
                230);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading task data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

