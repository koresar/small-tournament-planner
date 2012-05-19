using System;
using System.Windows.Forms;
using Tournament_Planner.BL;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.UI
{
    public partial class EnterPlayersControl : UserControl
    {
        public EnterPlayersControl()
        {
            this.InitializeComponent();
            new ColorizeTableByColumnValue(this.tblPlayers, "Company");
        }

        public event Action AddClicked;

        public event Action ApplyClicked;

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

        public Company Company
        {
            get { return this.cmbCompany.SelectedItem as Company; }
            set { this.cmbCompany.SelectedItem = value; }
        }

        public Skill Skill
        {
            get { return (Skill)this.cmbSkill.SelectedItem; }
            set { this.cmbSkill.SelectedItem = value; }
        }

        public bool Present
        {
            get { return this.chkPresent.Checked; }
            set { this.chkPresent.Checked = value; }
        }

        public string NumberOfPlayersText
        {
            get { return this.lblNumberOfPlayer.Text; }
            set { this.lblNumberOfPlayer.Text = value; }
        }

        public void SetDataSources(Tournament data)
        {
            var bsCompany = new BindingSource();
            bsCompany.DataSource = data.Companies;
            bsCompany.AllowNew = true;
            this.tblCompanies.DataSource = bsCompany;

            var bsPlayers = new BindingSource();
            bsPlayers.DataSource = data.Players;
            this.tblPlayers.DataSource = bsPlayers;

            this.cmbGender.DataSource = Enum.GetValues(typeof(Gender));

            this.cmbCompany.DataSource = data.Companies;
            this.cmbCompany.DisplayMember = "Name";

            cmbSkill.DataSource = Enum.GetValues(typeof(Skill));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.AddClicked != null)
            {
                this.AddClicked();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (this.ApplyClicked != null)
            {
                this.ApplyClicked();
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
            if (e.KeyCode == Keys.Delete && this.tblPlayers.SelectedRows.Count > 0)
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
            this.cmbSkill.SelectedItem = player.Skill;
            this.chkPresent.Checked = player.Present;
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
            this.tblCompanies.AutoSizeAllCells();
            this.tblPlayers.AutoSizeAllCells();
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
