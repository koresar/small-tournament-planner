using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public partial class GroupControl : UserControl
    {
        private DataGridViewCell lastSelectedCell;

        public GroupControl()
        {
            this.InitializeComponent();
            this.tblData.SelectionChanged += this.tblData_SelectionChanged;
            new ColorizeTableByValueData(
                this.tblData, 
                (val, cellStyle)  =>
                    {
                        if (val.Length < 2 || val[1] != ':')
                        {
                            return;
                        }

                        if (val.StartsWith("2"))
                        {
                            cellStyle.BackColor = Color.LightGreen;
                            cellStyle.ForeColor = Color.Black;
                        }

                        if (val.StartsWith("1") || val.StartsWith("0"))
                        {
                            cellStyle.BackColor = Color.LightPink;
                            cellStyle.ForeColor = Color.Black;
                        }
                });
        }

        public event Action<object> CellSelected;

        private void tblData_SelectionChanged(object sender, EventArgs e)
        {
            if (this.tblData.SelectedCells.Count == 1)
            {
                if (this.CellSelected != null)
                {
                    var cell = this.tblData.SelectedCells[0];
                    this.lastSelectedCell = cell;
                    this.CellSelected(cell.Tag);
                }
            }
        }

        public void ClearData()
        {
            this.tblData.Rows.Clear();
        }

        public void AddRow(string[] rowValues, object[] rowTags)
        {
            try
            {
                if (this.tblData.Columns.Count == 0)
                {
                    for (int i = 0; i < rowValues.Length; i++)
                    {
                        this.tblData.Columns.Add(new DataGridViewColumn() { CellTemplate = new DataGridViewTextBoxCell() });
                        this.tblData.AutoSizeAllCells();
                    }
                }

                var rowIndex = this.tblData.Rows.Add(rowValues);
                var row = this.tblData.Rows[rowIndex];

                for (int i = 0; i < rowValues.Length; i++)
                {
                    row.Cells[i].Tag = rowTags[i];
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void SelectCellWithTag(object obj)
        {
            foreach (DataGridViewRow row in this.tblData.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Tag == obj)
                    {
                        cell.Selected = true;
                        return;
                    }
                }
            }
        }
    }
}
