using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using static Cozify.dbHelper;
using OxyPlot.Legends;

namespace Cozify
{
    public partial class ANALYTICS : BaseForm
    {
        private PlotView plotView;
        public ANALYTICS()
        {
            InitializeComponent();
            InitializePlotView();
        }

        private void InitializePlotView()
        {
            plotView = new PlotView
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            pnlChartContainer.Controls.Add(plotView); 
        }

        private void btnHabitStreak_Click(object sender, EventArgs e)// tracks streaks of habit
        {

        }

        private void btnPomoUsage_Click(object sender, EventArgs e)// tracks usage of pomodoro timer over the past weeks
        {
            var data = db.GetWeeklyPomodoroData(GlobalUser.LoggedInUsername);
        }

        private void btnTasksDoneWeek(object sender, EventArgs e)// tracks tasks done over the past weeks
        {

        }
    }
}

        
