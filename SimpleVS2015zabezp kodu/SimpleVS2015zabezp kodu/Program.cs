using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Threading;

namespace SimpleVS2015zabezp_kodu
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericIdentity gid = new GenericIdentity("Administrator");

            String[] Roles = { "Administrator", "Programista" };

            GenericPrincipal gp = new GenericPrincipal(gid, Roles);

            Thread.CurrentPrincipal = gp;

            if (gp.Identity.Name == "Administrator")
            {
                Console.WriteLine("Do dzieła!");
            }
            else
            {
                Console.WriteLine("Nie w tym życiu!");
            }
            Console.ReadKey();
        }
    }
}