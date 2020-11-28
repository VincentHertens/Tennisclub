using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Tennisclub_UI.Commands;

namespace Tennisclub_UI.ViewModels
{
    public class MembersViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string FederationNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
        public DateTime? BirthDate { get; set; }









        /*public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "Id":
                        if (Id == 0 || Id == null)
                        {
                            result = "No member selected.";
                        }
                        break;
                    
                }
                return result;
            }
        }*/

        /*public string Error { get { return null; } }*/

        /*public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "FederationNr":
                        if (string.IsNullOrWhiteSpace(FederationNr))
                        {
                            result = "FederationNr is required!";
                        }
                        else if (FederationNr.Length > 10)
                        {
                            result = "FederationNr is too long!";
                        }
                        break;
                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            result = "First Name is required!";
                        }
                        else if (FirstName.Length > 25)
                        {
                            result = "First Name is too long!";
                        }
                        break;
                    case "LastName":
                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            result = "Last Name is required!";
                        }
                        else if (LastName.Length > 35)
                        {
                            result = "Last Name is too long!";
                        }
                        break;
                    case "BirthDate":
                        if (BirthDate == null)
                        {
                            result = "Birth Date is required!";
                        }
                        break;
                    case "Address":
                        if (string.IsNullOrWhiteSpace(Address))
                        {
                            result = "Address is required!";
                        }
                        else if (Address.Length > 70)
                        {
                            result = "Address is too long!";
                        }
                        break;
                    case "Number":
                        if (string.IsNullOrWhiteSpace(Number))
                        {
                            result = "Number is required!";
                        }
                        else if (Number.Length > 6)
                        {
                            result = "Number is too long!";
                        }
                        break;
                    case "Addition":
                        if (Addition?.Length > 2)
                        {
                            result = "Addition is too long!";
                        }
                        break;
                    case "Zipcode":
                        if (string.IsNullOrWhiteSpace(Zipcode))
                        {
                            result = "ZIP code is required!";
                        }
                        else if (Zipcode.Length > 6)
                        {
                            result = "ZIP code is too long!";
                        }
                        break;
                    case "City":
                        if (string.IsNullOrWhiteSpace(City))
                        {
                            result = "City is required!";
                        }
                        else if (City.Length > 30)
                        {
                            result = "City is too long!";
                        }
                        break;
                    case "PhoneNr":
                        if (PhoneNr?.Length > 15)
                        {
                            result = "PhoneNr is too long!";
                        }
                        break;
                }
                return result;
            }
        }

        public string Error { get { return null; } }*/
    }
}
