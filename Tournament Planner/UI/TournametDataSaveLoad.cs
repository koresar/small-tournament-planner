using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class TournametDataSaveLoad
    {
        private TournamentData data;

        public TournametDataSaveLoad(TournamentData data)
        {
            this.data = data;
        }

        public bool SavePlayersList(string fileName)
        {
            try
            {
                using (var stream = File.CreateText(fileName))
                {
                    foreach (var player in this.data.Players)
                    {
                        stream.WriteLine(player.ToCsvString());
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
                return false;
            }
        }

        public bool LoadPlayersList(string fileName)
        {
            try
            {
                List<Player> players = new List<Player>();

                using (var stream = File.OpenText(fileName))
                {
                    string line = stream.ReadLine();
                    while (line != null)
                    {
                        players.Add(Player.FromCsvString(line));
                        line = stream.ReadLine();
                    }
                }

                this.data.Players.Clear();
                foreach (var player in players)
                {
                    this.data.Players.Add(player);

                }

                this.data.Companies.Clear();
                foreach (var company in players.Select(p => p.Company).Distinct().ToList())
                {
                    this.data.Companies.Add(company);
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
                return false;
            }
        }
    }
}
