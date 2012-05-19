using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public abstract class ColorizeTable
    {
        private readonly Dictionary<string, Color> knownValuesToColorsMap = new Dictionary<string, Color>();
        private readonly Color[] backColors = new[]
            {
                Color.LightBlue, Color.LightCoral, Color.LightCyan, Color.LightGoldenrodYellow, Color.LightGray, Color.LightGreen, Color.LightPink, Color.LightSalmon, Color.LightSeaGreen,
                Color.LightSkyBlue, Color.LightSlateGray, Color.LightSteelBlue, Color.LightYellow,
            };

        private int backColorIterator;

        protected ColorizeTable(DataGridView table)
        {
            this.Table = table;
            this.Table.CellFormatting += this.TableOnCellFormatting;
        }

        protected DataGridView Table { get; private set; }

        protected Color GetRandomColorByKey(string key)
        {
            if (!this.knownValuesToColorsMap.ContainsKey(key))
            {
                this.knownValuesToColorsMap.Add(key, this.backColors[this.backColorIterator++]);
            }

            return this.knownValuesToColorsMap[key];
        }

        protected abstract void CellFormat(DataGridViewCellFormattingEventArgs e);

        private void TableOnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            this.CellFormat(e);
        }
    }
}