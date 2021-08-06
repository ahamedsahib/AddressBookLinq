using AddressBookLinq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [TestCategory("Insert Values in Data Table")]
        public void TestForInsertIntoDataTable()
        {
            int actual, expected = 2;
            actual = manager.InsertIntoDataTable(person);
            Assert.AreEqual(expected, actual);
        }
    }
}
