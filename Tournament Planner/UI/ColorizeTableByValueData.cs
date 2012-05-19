using System;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public class ColorizeTableByValueData : ColorizeTable
    {
        private readonly Action<string, DataGridViewCellStyle> colorizer;

        public ColorizeTableByValueData(DataGridView table, Action<string, DataGridViewCellStyle> colorizer)
            : base(table)
        {
            this.colorizer = colorizer;
        }

        protected override void CellFormat(DataGridViewCellFormattingEventArgs e)
        {
            var val = e.Value.ToString();
            if (string.IsNullOrEmpty(val))
            {
                return;
            }

            this.colorizer(val, e.CellStyle);
        }
    }
}