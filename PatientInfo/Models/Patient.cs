using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatientInfo.Models
{
    public class Patient
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        private DateTime _DateOfBirth;
        private string _PhoneNumber;

        public string DateOfBirth
        {
            get => _DateOfBirth.Date.ToShortDateString();
            set
            {
                if (DateTime.Compare(DateTime.Now.Date, DateTime.Parse(value).Date) < 0)
                {
                    throw new Exception("Date of Birth cannot be in the future");
                }
                else
                {
                    _DateOfBirth = DateTime.Parse(value).Date;
                }
            }
        }

        public string PhoneNumber
        {
            get => _PhoneNumber;

            set
            {
                // Assume US/CA number
                // remove formatting and possible initial 1 and check for 10 digits (no extensions)
                string unformattedValue = value;
                unformattedValue = Regex.Replace(unformattedValue, @"\D", String.Empty); 
                if (unformattedValue.StartsWith("1"))
                {
                    unformattedValue = unformattedValue.Remove(0, 1);
                }
                if (unformattedValue.Length == 10)
                {
                    _PhoneNumber = unformattedValue;
                }
                else
                {
                    throw new Exception("Phone number must be standard US/CA format of 10 digits");
                }

            }
        }

        public Patient() { }

        public Patient(string lastName, string firstName, string dateOfBirth, string phoneNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }

    }
}
