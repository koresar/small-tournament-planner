﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tournament_Planner.BL;
using Tournament_Planner.BL.XmlSerializable;

namespace UnitTests
{
    [TestClass]
    public class CompaniesCollectionTest
    {
        CompaniesCollection collection;

        public CompaniesCollectionTest()
        {
            this.collection = new CompaniesCollection();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddTest()
        {
            var addedCompany = this.collection.AddNew();
            addedCompany.Name = "0";

            var company = new Company(new CompanyData() { Name = "1" });
            this.collection.Add(company);
            Assert.AreNotEqual(0, company.Id);
            Assert.IsNotNull(this.collection.GetById(company.Id));
            Assert.IsNotNull(this.collection.GetByName(company.Name));

            Assert.IsTrue(this.collection.All(c => c.Id != 0));
        }
    }
}