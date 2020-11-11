using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientInfo.Models.Tests
{
    [TestClass()]
    public class PatientTests
    {
        [TestMethod()]
        public void PatientCreateTest()
        {
            Patient patient = new Patient("X", "Mr", "05/07/1954", "1-234-567-8901");
            Assert.IsNotNull(patient);
        }
    }
}