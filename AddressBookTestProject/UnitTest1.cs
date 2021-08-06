using AddressBookLinq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AddressBookTestProject
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookManager manager;
        AddressBookData person;

        [TestInitialize]
        public void SetUp()
        {
            manager = new AddressBookManager();
            person = new AddressBookData();
        }
        /// <summary>
        /// Returns the count of inserted data
        /// </summary>
        [TestMethod]
        public void TestForInsertIntoDataTable()
        {
            try
            {
                int actual, expected = 2;
                actual = manager.InsertIntoDataTable(person);
                Assert.AreEqual(expected, actual);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// test method to modify existing data
        /// </summary>
        [TestMethod]

        public void TestForModifyData()
        {
            try
            {
                string actual, expected = "success";
                actual = manager.ModifyExsistingDataByName("Ashfaq","ahamed",person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
