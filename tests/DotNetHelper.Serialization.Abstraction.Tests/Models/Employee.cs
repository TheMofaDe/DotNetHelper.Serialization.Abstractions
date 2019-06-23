using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetHelper.Serialization.Abstraction.Tests.Models
{

    [Serializable]
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            FirstName = "Kate";
            LastName = "Blake";
        }
    }
}
