using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class GroupController
    {
        private GroupControl control;
        private Group group;

        public GroupController(GroupControl groupControl)
        {
            this.control = groupControl;
            this.control.CellSelected += this.control_CellSelected;
        }

        /// <summary>
        /// Can be null;
        /// </summary>
        public event Action<Match> MatchSelected;

        public void SetDataSource(Group group)
        {
            if (this.group == group)
            {
                return;
            }

            this.group = group;
            this.control.ClearData();

            if (group == null)
            {
                this.control.Visible = false;
                return;
            }

            this.control.Visible = true;
            var firstRow = this.GetFirstRowStrings();
            this.control.AddRow(firstRow, firstRow.Cast<object>().ToArray());
            for (int i = 0; i < this.group.Count; i++)
            {
                this.control.AddRow(this.GetPlayerRowStrings(i), this.GetPlayerRowTags(i));
            }
        }

        private int GetNumberOfColumnsInGrid()
        {
            // First with players names, several more with match vs each other player, and one more for score.
            return this.group.Count + 2;
        }

        private string[] GetFirstRowStrings()
        {
            var headers = new string[this.GetNumberOfColumnsInGrid()];
            headers[0] = string.Format("Group {0}", this.group.Name);
            headers[1] = "Score";

            for (int i = 0; i < this.group.Count; i++)
            {
                headers[i + 2] = this.group[i].FullName;
            }

            return headers;
        }

        private string[] GetPlayerRowStrings(int playerOrderNumberInGroup)
        {
            var player = this.group[playerOrderNumberInGroup];
            var cells = new string[this.GetNumberOfColumnsInGrid()];
            cells[0] = player.FullName;
            cells[1] = this.group.GetPlayerScore(player).ToString();

            var playerMatches = this.group.GetPlayerMatches(player).ToList();
            int playerMatchesCounter = 0;
            for (int i = 0; i < this.group.Count; i++)
            {
                string cellValue;
                if (i == playerOrderNumberInGroup)
                {
                    cellValue = "-";
                }
                else
                {
                    cellValue = playerMatches[playerMatchesCounter].GetStringResult(player);
                    playerMatchesCounter++;
                }

                cells[i + 2] = cellValue;
            }

            return cells;
        }

        private object[] GetPlayerRowTags(int playerNumberInGroup)
        {
            var player = this.group[playerNumberInGroup];
            var cells = new object[this.GetNumberOfColumnsInGrid()];
            cells[0] = player.FullName;
            var playerMatches = this.group.GetPlayerMatches(player).ToList();
            int playerMatchesCounter = 0;
            for (int i = 0; i < this.group.Count; i++)
            {
                object cellValue;
                if (i == playerNumberInGroup)
                {
                    cellValue = "-";
                }
                else
                {
                    cellValue = playerMatches[playerMatchesCounter];
                    playerMatchesCounter++;
                }

                cells[i + 2] = cellValue;
            }

            return cells;
        }

        private Match lastSelectedMatch;

        private void control_CellSelected(object cellTag)
        {
            this.lastSelectedMatch = cellTag as Match;
            if (this.MatchSelected != null)
            {
                this.MatchSelected(this.lastSelectedMatch);
            }
        }

        public GroupControl Control
        {
            get { return this.control; }
        }

        public void TrySelectMatch(Match match)
        {
            if (this.lastSelectedMatch == null)
            {
                this.control.SelectCellWithTag(match);
            }
        }

        public void ForceSelectMatch(Match match)
        {
            this.control.SelectCellWithTag(match);
        }
    }
}
