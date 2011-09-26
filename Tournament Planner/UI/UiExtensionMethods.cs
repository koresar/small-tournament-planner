using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public static class UiExtensionMethods
    {
        public static void AutoSizeAllCells(this DataGridView grid, DataGridViewAutoSizeColumnMode mode = DataGridViewAutoSizeColumnMode.AllCells)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.AutoSizeMode = mode;
            }
        }
    }
}
