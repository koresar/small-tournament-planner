using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public partial class SelectPlayersWindow : Form
    {
        private readonly int necessaryNumber;

        public SelectPlayersWindow(IEnumerable<Player> players, int necessaryNumber = 0)
        {
            this.necessaryNumber = necessaryNumber;
            this.InitializeComponent();
            this.lstPlayers.DataSource = players.ToList();
        }

        public IEnumerable<Player> SelectedPlayers
        {
            get
            {
                return this.lstPlayers.CheckedItems.Cast<Player>();
            }
        }

        private void lstPlayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.necessaryNumber == 0)
            {
                this.btnOk.Enabled = true;
                return;
            }

            int checkedCount = this.SelectedPlayers.Count() + (e.NewValue == CheckState.Checked ? 1 : -1);
            this.btnOk.Enabled = checkedCount == this.necessaryNumber;
        }
    }
}
