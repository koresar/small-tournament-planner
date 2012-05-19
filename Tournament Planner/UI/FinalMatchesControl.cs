using System;
using System.Windows.Forms;

using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public partial class FinalMatchesControl : UserControl
    {
        public FinalMatchesControl()
        {
            this.InitializeComponent();
        }

        public event Action LoadClicked;

        public event Action SaveClicked;

        public event Action<Player> DeletePlayerClicked;

        public event Action AddPlayerClicked;

        public DataGridView GetPlayersTable()
        {
            return this.tblPlayers;
        }

        private void tblPlayers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && this.tblPlayers.SelectedRows.Count > 0)
            {
                if (this.DeletePlayerClicked != null)
                {
                    var player = this.tblPlayers.SelectedRows[0].DataBoundItem as Player;
                    this.DeletePlayerClicked(player);
                }
            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (this.AddPlayerClicked != null)
            {
                this.AddPlayerClicked();
            }
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
    }
}
