using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookLinq
{
    public class AddressBookManager
    {

        DataTable dataTable;
        /// <summary>
        /// Method to create data table
        /// </summary>
        public void CreateDataTable()
        {
            dataTable = new DataTable();
            //column for Firstname
            DataColumn dataColumn = new DataColumn(); 
            dataColumn.DataType = typeof(String);
            dataColumn.ColumnName = "FirstName";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);


            //column for LastName
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(String);
            dataColumn.ColumnName = "LastName";
            dataColumn.Caption = "Last Name";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);

            // column for Address 
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(String);
            dataColumn.ColumnName = "Address";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);

            // column for City 
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(String);
            dataColumn.ColumnName = "City";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);

            // column for State 
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(String);
            dataColumn.ColumnName = "State";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);

            // column for EmailId 
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(String);
            dataColumn.ColumnName = "Email";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);

            // column for Address .    
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(Int64);
            dataColumn.ColumnName = "PhoneNumber";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);

            // column for ZipCode 
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(Int32);
            dataColumn.ColumnName = "ZipCode";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);

            //column for person id
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(Int64);
            dataColumn.ColumnName = "PersonTypeId";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);
            //column for person type
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(string);
            dataColumn.ColumnName = "PersonType";
            dataColumn.AutoIncrement = false;
            dataTable.Columns.Add(dataColumn);
        }
        /// <summary>
        /// Method to insert the data into column
        /// </summary>
        public int InsertIntoDataTable(AddressBookData Person)
        {
            //Create the table
            CreateDataTable();
            //Assign values to objects
            Person.firstName = "Ahamed";
            Person.lastName = "Sahib";
            Person.address = "Broadway";
            Person.city = "chennai";
            Person.state = "TN";
            Person.zipCode = 600001;
            Person.phoneNumber = 9765432108;
            Person.emailId = "asd@yaho.com";
            Person.personTypeId = 1;
            Person.personType = "Family";
            //Add into table
            AddRowintoDataTable(Person);
            //Assigning second value
            Person.firstName = "Ashfaq";
            Person.lastName = "MJ";
            Person.address = "Beruwala";
            Person.city = "Colombo";
            Person.state = "Srilanka";
            Person.zipCode = 628204;
            Person.phoneNumber = 8008765320;
            Person.emailId = "ashf@wertew.com";
            Person.personTypeId = 2;
            Person.personType = "Friend";
            AddRowintoDataTable(Person);

            //Assigning second value
            Person.firstName = "Aqeel";
            Person.lastName = "Ahamed";
            Person.address = "Beruwala";
            Person.city = "Colombo";
            Person.state = "Srilanka";
            Person.zipCode = 628204;
            Person.phoneNumber = 8035465320;
            Person.emailId = "aqeelf@wertew.com";
            Person.personTypeId = 3;
            Person.personType = "Relative";
            AddRowintoDataTable(Person);
            //display the table
            DisplayDataTable();
            return dataTable.Rows.Count;
        }
        /// <summary>
        /// Add row into the data table
        /// </summary>
        public void AddRowintoDataTable(AddressBookData Person)
        {
            //create object for datarow
            DataRow dataRow = dataTable.NewRow();
            dataRow["FirstName"] = Person.firstName;
            dataRow["LastName"] = Person.lastName;
            dataRow["Address"] = Person.address;
            dataRow["City"] = Person.city;
            dataRow["State"] = Person.state;
            dataRow["ZipCode"] = Person.zipCode;
            dataRow["PhoneNumber"] = Person.phoneNumber;
            dataRow["Email"] = Person.emailId;
            dataTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// modify exsistng data from the table
        /// </summary>
        public string ModifyExsistingDataByName(string name,string modifiedName, AddressBookData Person)
        {
            string output = string.Empty;
            //insert into table
            InsertIntoDataTable(Person);
            try
            {
                var res = (from person in dataTable.AsEnumerable() where person.Field<string>("FirstName").Equals(name) select person).LastOrDefault();//returns last element satisfies the condition or default value
                if (res != null)
                {
                    res["LastName"] = modifiedName;
                    //display after its modified
                    Console.WriteLine("Succesfully Updated!!!!!");
                    DisplayDataTable();
                    output = "success";
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return output;
        }

        /// <summary>
        /// Method to delete the Contact in table usin Namefield
        /// </summary>
        public string DeleteContactUsingName(string name, AddressBookData Person)
        {
            string output = string.Empty;
            //insert into table
            InsertIntoDataTable(Person);
            var result = (from contact in dataTable.AsEnumerable() where contact.Field<string>("FirstName").Equals(name) select contact).FirstOrDefault();
            if (result != null)
            {
                result.Delete();
                //display after its deleted
                Console.WriteLine("After Deletion");
                DisplayDataTable();
                output = "Deleted Successfully";
                return output;
            }
            return output;
        }

        /// <summary>
        /// Retreive records based on state or city 
        /// </summary>
        public int RetreiveContactBasedOnStateOrCity(string cityName,string stateName, AddressBookData Person)
        {
            int count = 0;
            //insert into table
            InsertIntoDataTable(Person);
            try
            {
                var result = (from person in dataTable.AsEnumerable() where (person.Field<string>("State").Equals(stateName) || person.Field<string>("City").Equals(cityName)) select person);

                    if (result != null)
                    {
                    Console.WriteLine($"Contacts of {stateName} and {cityName}");
                    foreach (DataRow row in result)
                    {

                        Console.WriteLine($"{row["FirstName"]} | { row["LastName"]} | {row["Address"]} | {row["City"]} | {row["State"]} | {row["ZipCode"]} | {row["PhoneNumber"]} | {row["Email"]}\n");
                    }
                    count = result.Count();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count;

        }

        /// <summary>
        /// method to count Contacts based on city
        /// </summary>
    
        public int CountBasedOnCity(string cityName, AddressBookData Person)
        {
            int count = 0;
            try
            {
                //insert into table
                InsertIntoDataTable(Person);
                var result = (from person in dataTable.AsEnumerable() where person.Field<string>("City").Equals(cityName) select person).ToList().Count;
                count = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count;

        }

        /// <summary>
        /// Sort records based on name in given city
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="Person"></param>
        /// <returns></returns>
        public string SortContactBasedOnNameinGivenCity(string cityName, AddressBookData Person)
        {
            string output = string.Empty;
            try
            {
                //insert into table
                InsertIntoDataTable(Person);
                var result = (from person in dataTable.AsEnumerable() orderby person.Field<string>("FirstName") where person.Field<string>("City").Equals(cityName) select person);
                if (result != null)
                {
                    Console.WriteLine("After retreiving");
                    foreach (DataRow row in result)
                    {

                        Console.WriteLine($"{row["FirstName"]} | { row["LastName"]} | {row["Address"]} | {row["City"]} | {row["State"]} | {row["ZipCode"]} | {row["PhoneNumber"]} | {row["Email"]}\n");
                    }

                }
                output = "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return output;

        }

        /// <summary>
        /// Method to get count by type
        /// </summary>
      
        public string GetCountByType(AddressBookData Person)
        {

            string output = string.Empty;
            try
            {
                //insert into table
                InsertIntoDataTable(Person);
                var result = (from person in dataTable.AsEnumerable().GroupBy(row => new { personType = row["PersonType"] }) select person);
                foreach (var value in result)
                {

                    Console.WriteLine(value.Key);
                    foreach (var row in value)
                    {
                        Console.WriteLine($"{row["FirstName"]} | { row["LastName"]} | {row["Address"]} | {row["City"]} | {row["State"]} | {row["ZipCode"]} | {row["PhoneNumber"]} | {row["Email"]} | {row["PersonTypeId"]}| {row["PersonType"]}\n");
                    }
                    Console.WriteLine("----------------------");

                }
                output = "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return output;

        }


        /// <summary>
        /// Method to display the data table
        /// </summary>
        public void DisplayDataTable()
        {
            //display the rows
            foreach (DataRow row in dataTable.Rows)
            {

                Console.WriteLine($"{row["FirstName"]} | { row["LastName"]} | {row["Address"]} | {row["City"]} | {row["State"]} | {row["ZipCode"]} | {row["PhoneNumber"]} | {row["Email"]}\n");
            }
        }
    }
}
