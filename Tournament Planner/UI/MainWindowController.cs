using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class MainWindowController
    {
        private MainWindow mainForm;
        private List<StepController> steps;
        private StepController currentStep;
        private Tournament tournamentData;

        public MainWindowController(MainWindow mainForm)
        {
            this.mainForm = mainForm;

            this.InitializeData();

            this.mainForm.NextClicked += this.mainForm_NextClicked;
            this.mainForm.GoToGroupGamesClicked += this.mainForm_GoToGroupGamesClicked;
            this.mainForm.GoToPlayOffClicked += new Action(mainForm_GoToPlayOffClicked);
        }

        private void mainForm_GoToPlayOffClicked()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Schedule snapshot file (*.stpss)|*.stpss";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                new TournametDataSaveLoad(this.tournamentData).LoadPlayersList(dialog.FileName);
                this.SetCurrentStep(this.steps.OfType<PlayOffController>().First());
            }
        }

        private void mainForm_GoToGroupGamesClicked()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Schedule snapshot file (*.stpss)|*.stpss";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                new TournametDataSaveLoad(this.tournamentData).LoadPlayersList(dialog.FileName);
                this.SetCurrentStep(this.steps.OfType<ScheduleAndResultsController>().First());
            }
        }

        private void InitializeData()
        {
            this.tournamentData = new Tournament();
            this.tournamentData.Reloaded += () => this.mainForm.Text = this.tournamentData.Name;
            this.steps = new List<StepController>();
            this.steps.Add(new EnterPlayersController(this.tournamentData));
            this.steps.Add(new ShuffleController(this.tournamentData));
            this.steps.Add(new ScheduleAndResultsController(this.tournamentData));
            this.steps.Add(new PlayOffController(this.tournamentData));
            this.steps.Add(new FinalController(this.tournamentData));
        }

        private void mainForm_NextClicked()
        {
            if (this.currentStep == null)
            {
                if (string.IsNullOrWhiteSpace(this.mainForm.TournamentName))
                {
                    MsgBox.Error("Enter tournament name.");
                }
                else
                {
                    this.tournamentData.Name = this.mainForm.TournamentName;
                    this.mainForm.Text = this.tournamentData.Name;
                    this.SetCurrentStep(this.steps.First());
                }
            }
            else if (this.currentStep == this.steps.Last())
            {
                throw new InvalidOperationException("No more steps.");
            }
            else if (!this.currentStep.IsAllowProceed())
            {
                MsgBox.Error(this.currentStep.ProceedError, "Impossible to proceed");
            }
            else
            {
                this.SetCurrentStep(this.steps[this.steps.IndexOf(this.currentStep) + 1]);
            }
        }

        private void SetCurrentStep(StepController newCurrentStep)
        {
            this.currentStep = newCurrentStep;
            this.currentStep.OnEnteringStep();
            this.mainForm.SetCurrentControl(this.currentStep.Control);
            if (this.currentStep == this.steps.Last())
            {
                this.mainForm.FrobindFurtherMove();
            }
        }
    }
}
