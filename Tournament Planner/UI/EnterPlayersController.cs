using System.ComponentModel;
using System.Windows.Forms;
using Tournament_Planner.BL;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.UI
{
    public class EnterPlayersController : StepController
    {
        private EnterPlayersControl editControl;
        private Player lastSelectedPlayer;

        public EnterPlayersController(Tournament tournamentData) : base(tournamentData)
        {
            this.ProceedError = "Number of players should be multiple of 4 or 3.";

            this.editControl = new EnterPlayersControl();
            this.Control = this.editControl;

            this.editControl.SetDataSources(this.TournamentData);

            this.editControl.AddClicked += this.control_AddClicked;
            this.editControl.ApplyClicked += this.control_ApplyClicked;
            this.editControl.DataChanged += this.editControl_DataChanged;
            this.editControl.SelectedPlayerChanged += this.editControl_SelectedPlayerChanged;
            this.editControl.DeletePlayerClicked += this.editControl_DeletePlayerClicked;
            this.editControl.SaveClicked += this.editControl_SaveClicked;
            this.editControl.LoadClicked += this.editControl_LoadClicked;

            this.TournamentData.Players.ListChanged += this.Players_ListChanged;
            this.AllowProceed = this.TournamentData.Players.IsNumberOfPlayersAcceptable();
        }

        private void editControl_SaveClicked()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Players list file (*.stppl)|*.stppl";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                new TournametDataSaveLoad(this.TournamentData).SavePlayersList(dialog.FileName);
            }
        }

        private void editControl_LoadClicked()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Players list file (*.stppl)|*.stppl";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                new TournametDataSaveLoad(this.TournamentData).LoadPlayersList(dialog.FileName);
                this.ValidateEnteredData();
            }
        }

        private void editControl_DeletePlayerClicked(Player player)
        {
            this.TournamentData.Players.Remove(player);
        }

        private void editControl_SelectedPlayerChanged(Player player)
        {
            this.lastSelectedPlayer = player;
            this.editControl.PopulateData(player);
        }

        private void editControl_DataChanged()
        {
            this.ValidateEnteredData();
        }

        private void control_AddClicked()
        {
            if (this.ValidateEnteredData())
            {
                this.TournamentData.Players.Add(new Player(new PlayerData()
                {
                    FirstName = this.editControl.FirstNameText,
                    SecondName = this.editControl.SecondNameText, 
                    Gender = this.editControl.Gender,
                    Company = this.editControl.Company.Name,
                    Skill = this.editControl.Skill,
                    Present = this.editControl.Present,
                }));
            }
        }

        private void control_ApplyClicked()
        {
            if (this.lastSelectedPlayer != null && this.ValidateEnteredData())
            {                
                this.lastSelectedPlayer.FirstName = this.editControl.FirstNameText;
                this.lastSelectedPlayer.SecondName = this.editControl.SecondNameText;
                this.lastSelectedPlayer.Gender = this.editControl.Gender;
                this.lastSelectedPlayer.Company = this.editControl.Company;
                this.lastSelectedPlayer.Skill = this.editControl.Skill;
                this.lastSelectedPlayer.Present = this.editControl.Present;
                this.editControl.Refresh();
            }
        }

        private bool ValidateEnteredData()
        {
            bool result = true;
            if (string.IsNullOrEmpty(this.editControl.FirstNameText))
            {
                this.editControl.SetFirstNameError("Fill me.");
                result = false;
            }
            else
            {
                this.editControl.SetFirstNameError(null);
            }

            if (string.IsNullOrEmpty(this.editControl.SecondNameText))
            {
                this.editControl.SetSecondNameError("Fill me too.");
                result = false;
            }
            else
            {
                this.editControl.SetSecondNameError(null);
            }

            if (this.editControl.Company == null)
            {
                this.editControl.SetCompanyError("Add some companies first.");
                result = false;
            }
            else
            {
                this.editControl.SetCompanyError(null);
            }

            return result;
        }

        private void Players_ListChanged(object sender, ListChangedEventArgs e)
        {
            this.editControl.NumberOfPlayersText = string.Format("Number of players: {0}", this.TournamentData.Players.Count);

            this.AllowProceed = this.TournamentData.Players.IsNumberOfPlayersAcceptable();
        }
    }
}
