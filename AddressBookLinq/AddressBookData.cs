using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookLinq
{
    public class AddressBookData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public Int64 phoneNumber { get; set; }
        public int zipCode { get; set; }
        public string emailId { get; set; }
        public int personTypeId { get; set; }
        public string personType { get; set; }
    }
}
