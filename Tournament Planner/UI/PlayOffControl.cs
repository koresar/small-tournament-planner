using System;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public partial class PlayOffControl : UserControl
    {
        public PlayOffControl()
        {
            this.InitializeComponent();
        }

        public event Action LoadClicked;

        public event Action SaveClicked;

        public event Action ManuallyEnterPlayersClicked;

        public EditMatchControl GetMatchControl()
        {
            return this.editMatchControl;
        }

        public GroupControl GetGroupControl()
        {
            return this.groupControl;
        }

        public ListBox GetManualPlayersControl()
        {
            return this.lstManualPlayers;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (this.LoadClicked != null)
            {
                this.LoadClicked();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.SaveClicked != null)
            {
                this.SaveClicked();
            }
        }

        private void btnManualPlayers_Click(object sender, EventArgs e)
        {
            if (this.ManuallyEnterPlayersClicked != null)
            {
                this.ManuallyEnterPlayersClicked();
            }
        }
    }
}
