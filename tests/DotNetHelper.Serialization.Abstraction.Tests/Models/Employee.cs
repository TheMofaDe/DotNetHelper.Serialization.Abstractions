using System;

namespace DotNetHelper.Serialization.Abstractions.Tests.Models
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
