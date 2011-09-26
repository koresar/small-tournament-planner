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
        private TournamentData data;

        public ShuffleControl()
        {
            this.InitializeComponent();
        }

        public event Action DoShuffleClicked;

        public void SetDataSources(TournamentData tournamentData)
        {
            this.data = tournamentData;
        }

        private void ShuffleControl_Load(object sender, EventArgs e)
        {
            this.tblPlayers.Rows.Clear();
            foreach (var p in this.data.Players)
            {
                this.tblPlayers.Rows.Add(p.FullName);
            }
        }

        private void btnDoShuffle_Click(object sender, EventArgs e)
        {
            if (this.DoShuffleClicked != null)
            {
                this.DoShuffleClicked();
            }
        }

        public void DrawGroups(List<Group> groups)
        {
            this.flowLayoutPanel.Controls.Clear();

            foreach (var group in groups)
            {
                var gridControl = new DataGridView();
                gridControl.RowHeadersVisible = false;

                var bs = new BindingSource();
                bs.DataSource = group;
                gridControl.DataSource = bs;

                gridControl.AutoSizeAllCells();
                this.flowLayoutPanel.Controls.Add(gridControl);
            }
        }
    }
}
