using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public partial class ShuffleControl : UserControl
    {
        private Tournament data;

        public ShuffleControl()
        {
            this.InitializeComponent();
        }

        public event Action DoShuffleClicked;

        public int SelectedNumberOfPlayersInGroup
        {
            get { return (int)this.cmbPlayersInGroup.SelectedItem; }
        }

        public void SetDataSources(Tournament tournamentData)
        {
            this.data = tournamentData;
            this.tblPlayers.Rows.Clear();
            foreach (var p in this.data.Players)
            {
                this.tblPlayers.Rows.Add(p.FullName);
            }

            this.cmbPlayersInGroup.Items.AddRange(this.data.Players.GetPossibleNumberOfPlayersInGroup().Cast<object>().ToArray());
            this.cmbPlayersInGroup.SelectedItem = this.data.Players.GetSuggestedNumberOfPlayersInGroup();
        }

        private void btnDoShuffle_Click(object sender, EventArgs e)
        {
            if (this.DoShuffleClicked != null)
            {
                this.DoShuffleClicked();
            }
        }

        public void DrawGroups(IEnumerable<Group> groups)
        {
            this.flowLayoutPanel.Controls.Clear();

            foreach (var group in groups)
            {
                var gridControl = new DataGridView();
                gridControl.Height += 5; // This is a magic number. Nope. It's a MAAAGIC number. UI magic happened after this line introduced.
                gridControl.RowHeadersVisible = false;

                var bs = new BindingSource();
                bs.DataSource = group.Players;
                gridControl.DataSource = bs;

                gridControl.AutoSizeAllCells();
                gridControl.AutoSize = true;
                this.flowLayoutPanel.Controls.Add(gridControl);
            }

            var sum = groups.Select(g => g.GenerateNewGroupMatches().Count).Sum();
            this.lblNumberOfGames.Text = sum.ToString();
        }
    }
}
