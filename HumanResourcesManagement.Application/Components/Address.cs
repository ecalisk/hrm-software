using System;
namespace HumanResourcesManagement.Application.Components
{
    public class Address
    {
        #region FIELDS
        private string addressLine;
        private string city;
        private string state;
        private string zipCode;
        #endregion

        #region CONSTRUCTOR(S)
        public Address(string addressLine, string city, string state, string zipCode)
        {
            AddressLine = addressLine;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
        #endregion

        #region PROPERTIES
        public string AddressLine
        {
            get { return addressLine; }
            set { addressLine = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
        #endregion

    }
}

