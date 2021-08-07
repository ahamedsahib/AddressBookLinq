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
                int actual, expected = 3;
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
        /// <summary>
        /// test method to delete Contact using name
        /// </summary>
        [TestMethod]

        public void TestForDeleteData()
        {
            try
            {
                string actual, expected = "Deleted Successfully";
                actual = manager.DeleteContactUsingName("Ashfaq", person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// test method to delete Contact using name
        /// </summary>
        [TestMethod]
        public void TestForRetreiveBasedOnStateOrCity()
        {
            try
            {
                int actual, expected = 2;
                actual = manager.RetreiveContactBasedOnStateOrCity("Colombo", "Srilanka", person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// test to count Contact based on city 
        /// </summary>
        [TestMethod]
        public void TestForCountBasedOnCity()
        {
            try
            {
                int actual, expected = 2;
                actual = manager.CountBasedOnCity("Colombo", person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// test method Sort Contacts based on Cityname
        /// </summary>
        [TestMethod]
        public void TestForSortBasedOnNameinGivenCity()
        {
            try
            {
                string actual, expected = "success";
                actual = manager.SortContactBasedOnNameinGivenCity("Colombo", person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// test method to get no of contact by ContactType
        /// </summary>

        [TestMethod]
        public void TestMethodForCountBasedOnContactType()
        {
            try
            {
                string actual, expected = "success";
                actual = manager.GetCountByType(person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
