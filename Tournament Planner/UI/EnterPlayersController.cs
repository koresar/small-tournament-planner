using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class EnterPlayersController : StepController
    {
        private EnterPlayersControl editControl;

        public EnterPlayersController(TournamentData tournamentData) : base(tournamentData)
        {
            this.editControl = new EnterPlayersControl();
            this.Control = this.editControl;

            this.editControl.SetDataSources(this.TournamentData);

            this.editControl.AddClicked += this.control_AddClicked;
            this.editControl.DataChanged += this.editControl_DataChanged;
            this.editControl.SelectedPlayerChanged += this.editControl_SelectedPlayerChanged;
            this.editControl.DeletePlayerClicked += this.editControl_DeletePlayerClicked;
            this.TournamentData.Players.ListChanged += this.Players_ListChanged;
        }

        private void editControl_DeletePlayerClicked(Player player)
        {
            this.TournamentData.Players.Remove(player);
        }

        private void editControl_SelectedPlayerChanged(Player player)
        {
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
                this.TournamentData.Players.Add(new Player(
                    this.editControl.FirstNameText,
                    this.editControl.SecondNameText, 
                    this.editControl.Gender,
                    this.editControl.Comapny));
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

            if (this.editControl.Comapny == null)
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
            this.AllowProceed = this.TournamentData.Players.IsNumberOfPlayersAcceptable();
            this.ProceedError = "Number of players should divide by 3 or 4.";
        }
    }
}
