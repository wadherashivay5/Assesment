using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Questions
{
    namespace Q21
    {
        public class Employee
        {
            private string privateMember = "Private Data";
            protected string protectedMember = "Protected Data";
            internal string internalMember = "Internal Data";
            protected internal string protectedInternalMember = "Protected Internal Data";
            public string publicMember = "Public Data";

            public void ShowAccess()
            {
                Console.WriteLine(privateMember);
                Console.WriteLine(protectedMember);
                Console.WriteLine(internalMember);
                Console.WriteLine(protectedInternalMember);
                Console.WriteLine(publicMember);
            }
        }

        public class SameAssemblyHelper
        {
            public void TestAccess()
            {
                Employee emp = new Employee();
                Console.WriteLine(emp.internalMember);
                Console.WriteLine(emp.protectedInternalMember);
                Console.WriteLine(emp.publicMember);
            }
        }

        public class InternalDerivedEmployee : Employee
        {
            public void TestAccess()
            {
                Console.WriteLine(protectedMember);
                Console.WriteLine(internalMember);
                Console.WriteLine(protectedInternalMember);
                Console.WriteLine(publicMember);
            }
        }
    }
}
