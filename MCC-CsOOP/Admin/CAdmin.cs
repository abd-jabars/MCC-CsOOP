using System;
using System.Collections.Generic;
using System.Text;

namespace MCC_CsOOP.Admin
{
    class CAdmin : AdminMethod
    {
        private String adminName { get; }
        private String adminEmail { get; }

        public CAdmin(string adminName, string adminEmail)
        {
            this.adminName = adminName;
            this.adminEmail = adminEmail;
        }

        public override void ContactPerson()
        {
            Console.WriteLine("\t*** Admin Contact ***");
            Console.WriteLine($"Admin name \t : {this.adminName}");
            Console.WriteLine($"Admin email \t : {this.adminEmail}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

    }
}
