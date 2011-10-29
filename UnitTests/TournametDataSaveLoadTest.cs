using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tournament_Planner.BL;
using Tournament_Planner.UI;
using System.IO;
using Tournament_Planner.BL.XmlSerializable;

namespace UnitTests
{
    [TestClass]
    public class TournametDataSaveLoadTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void SaveLoadCompaniesTest()
        {
            var tournament = new Tournament();
            tournament.Companies.Add(new Company() { Name = "123" });

            var fileOperator = new TournametDataSaveLoad(tournament);
            string fileName = Path.Combine(this.TestContext.DeploymentDirectory, "123.tmp");
            Assert.IsTrue(fileOperator.SavePlayersList(fileName));

            var tournament2 = new Tournament();
            Assert.IsTrue(new TournametDataSaveLoad(tournament2).LoadPlayersList(fileName));

            Assert.IsTrue(tournament.Companies.SequenceEqual(tournament2.Companies));
        }

        [TestMethod]
        public void SaveLoadPlayersTest()
        {
            var tournament = new Tournament();
            tournament.Companies.Add(new Company() { Name = "123" });
            tournament.Players.Add(new Player(new PlayerData()
            {
                CompanyId = tournament.Companies.GetByName("123").Id,
                FirstName = "1",
                SecondName = "2",
                Gender = Gender.Female,
                Present = true,
                Skill = Skill.Good,
            }, tournament.Companies));

            var fileOperator = new TournametDataSaveLoad(tournament);
            string fileName = Path.Combine(this.TestContext.DeploymentDirectory, "123.tmp");
            Assert.IsTrue(fileOperator.SavePlayersList(fileName));

            var tournament2 = new Tournament();
            Assert.IsTrue(new TournametDataSaveLoad(tournament2).LoadPlayersList(fileName));

            Assert.IsTrue(tournament.Players.SequenceEqual(tournament2.Players));
        }

        [TestMethod]
        public void SaveLoadGroupsTest()
        {
            var tournament = new Tournament();
            tournament.Companies.Add(new Company() { Name = "123" });
            tournament.Players.Add(new Player(new PlayerData()
            {
                CompanyId = tournament.Companies.GetByName("123").Id,
                FirstName = "1",
                SecondName = "2",
                Gender = Gender.Female,
                Present = true,
                Skill = Skill.Good,
            }, tournament.Companies));
            tournament.Groups.Add(new Group(tournament.Players, "A"));

            var fileOperator = new TournametDataSaveLoad(tournament);
            string fileName = Path.Combine(this.TestContext.DeploymentDirectory, "123.tmp");
            Assert.IsTrue(fileOperator.SavePlayersList(fileName));

            var tournament2 = new Tournament();
            Assert.IsTrue(new TournametDataSaveLoad(tournament2).LoadPlayersList(fileName));

            Assert.IsTrue(tournament.Groups.SequenceEqual(tournament2.Groups));
        }
    }
}
