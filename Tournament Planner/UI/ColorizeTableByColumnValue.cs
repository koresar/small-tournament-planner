using System.Drawing;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public class ColorizeTableByColumnValue : ColorizeTable
    {
        public ColorizeTableByColumnValue(DataGridView table, string meaningColumn) : base(table)
        {
            this.MeaningColumn = meaningColumn;            
        }

        public string MeaningColumn { get; protected set; }

        protected override void CellFormat(DataGridViewCellFormattingEventArgs e)
        {
            var val = e.Value.ToString();
            var dataColumn = this.Table.Columns[this.MeaningColumn];
            if (dataColumn == null || e.ColumnIndex != dataColumn.Index || string.IsNullOrEmpty(val))
            {
                return;
            }

            e.CellStyle.BackColor = e.CellStyle.SelectionBackColor = this.GetRandomColorByKey(val);
            e.CellStyle.ForeColor = e.CellStyle.SelectionForeColor = Color.Black;
        }
    }
}