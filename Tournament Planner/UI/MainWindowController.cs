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
        private TournamentData tournamentData;

        public MainWindowController(MainWindow mainForm)
        {
            this.mainForm = mainForm;

            this.InitializeData();

            this.mainForm.NextClicked += this.mainForm_NextClicked;
        }

        private void InitializeData()
        {
            this.tournamentData = new TournamentData();
            this.steps = new List<StepController>();
            this.steps.Add(new EnterPlayersController(this.tournamentData));
            this.steps.Add(new ShuffleController(this.tournamentData));
        }

        private void mainForm_NextClicked()
        {
            if (this.currentStep == null)
            {
                this.SetCurrentStep(this.steps.First());
            }
            else if (this.currentStep == this.steps.Last())
            {
                throw new InvalidOperationException("No more steps.");
            }
            else if (!this.currentStep.AllowProceed)
            {
                MessageBox.Show(this.currentStep.ProceedError, "Impossible to proceed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.SetCurrentStep(this.steps[this.steps.IndexOf(this.currentStep) + 1]);
            }
        }

        private void SetCurrentStep(StepController newCurrentStep)
        {
            this.currentStep = newCurrentStep;
            this.mainForm.SetCurrentControl(this.currentStep.Control);
            if (this.currentStep == this.steps.Last())
            {
                this.mainForm.FrobindFurtherMove();
            }
        }
    }
}
