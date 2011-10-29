using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            this.InitializeComponent();
            new MainWindowController(this);
            this.txtTournamentName.Focus();
            this.txtTournamentName.SelectAll();
        }

        public event Action NextClicked;

        public event Action GoToGroupGamesClicked;

        public event Action GoToPlayOffClicked;

        public string TournamentName
        {
            get { return this.txtTournamentName.Text; }
        }

        public void SetCurrentControl(Control control)
        {
            this.pnlCurrentStepContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            this.pnlCurrentStepContainer.Controls.Add(control);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.NextClicked != null)
            {
                this.NextClicked();
            }
        }

        public void FrobindFurtherMove()
        {
            this.btnNext.Enabled = false;
        }

        private void btnGroupGames_Click(object sender, EventArgs e)
        {
            if (this.GoToGroupGamesClicked != null)
            {
                this.GoToGroupGamesClicked();
            }
        }

        private void btnGoToPLayOff_Click(object sender, EventArgs e)
        {
            if (this.GoToPlayOffClicked != null)
            {
                this.GoToPlayOffClicked();
            }
        }
    }
}
