using System;
using System.Windows.Forms;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public partial class EnterPlayersControl : UserControl
    {
        public EnterPlayersControl()
        {
            this.InitializeComponent();
        }

        public event Action AddClicked;

        public event Action SaveClicked;

        public event Action LoadClicked;

        public event Action DataChanged;

        public event Action<Player> SelectedPlayerChanged;

        public event Action<Player> DeletePlayerClicked;

        public string FirstNameText
        {
            get { return this.textBox1.Text; }
            set { this.textBox1.Text = value; }
        }

        public string SecondNameText
        {
            get { return this.textBox2.Text; }
            set { this.textBox2.Text = value; }
        }

        public Gender Gender
        {
            get { return (Gender)this.cmbGender.SelectedItem; }
            set { this.cmbGender.SelectedItem = value; }
        }

        public Company Comapny
        {
            get { return this.cmbCompany.SelectedItem as Company; }
            set { this.cmbCompany.SelectedItem = value; }
        }

        public void SetDataSources(TournamentData data)
        {
            var bsCompany = new BindingSource();
            bsCompany.DataSource = data.Companies;
            this.tblCompanies.DataSource = bsCompany;

            var bsPlayers = new BindingSource();
            bsPlayers.DataSource = data.Players;
            this.tblPlayers.DataSource = bsPlayers;

            this.cmbGender.DataSource = Enum.GetValues(typeof(Gender));

            this.cmbCompany.DataSource = data.Companies;
            this.cmbCompany.DisplayMember = "Name";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.AddClicked != null)
            {
                this.AddClicked();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.OnDataChanged();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.OnDataChanged();
        }

        private void OnDataChanged()
        {
            if (this.DataChanged != null)
            {
                this.DataChanged();
            }
        }

        private void tblPlayers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (this.DeletePlayerClicked != null)
                {
                    var player = this.tblPlayers.SelectedRows[0].DataBoundItem as Player;
                    this.DeletePlayerClicked(player);
                }
            }
        }

        private void tblPlayers_SelectionChanged(object sender, EventArgs e)
        {
            if (this.tblPlayers.SelectedRows.Count == 1)
            {
                var player = this.tblPlayers.SelectedRows[0].DataBoundItem as Player;
                if (this.SelectedPlayerChanged != null)
                {
                    this.SelectedPlayerChanged(player);
                }
            }
        }

        public void PopulateData(Player player)
        {
            this.textBox1.Text = player.FirstName;
            this.textBox2.Text = player.SecondName;
            this.cmbGender.SelectedItem = player.Gender;
            this.cmbCompany.SelectedItem = player.Company;
        }

        internal void SetFirstNameError(string p)
        {
            this.errorProvider.SetError(this.textBox1, p);
        }

        internal void SetSecondNameError(string p)
        {
            this.errorProvider.SetError(this.textBox2, p);
        }

        internal void SetCompanyError(string p)
        {
            this.errorProvider.SetError(this.cmbCompany, p);
        }

        private void EnterPlayersControl_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in this.tblCompanies.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            foreach (DataGridViewColumn column in this.tblPlayers.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            if (this.SaveClicked != null)
            {
                this.SaveClicked();
            }
        }

        private void btnLoadList_Click(object sender, EventArgs e)
        {
            if (this.LoadClicked != null)
            {
                this.LoadClicked();
            }
        }
    }
}
