using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class GetNewPassword : IGetPasswordService
    {
        public string GetNewPassord()
        {
            Random rnd = new Random();
            string password = "";
            for (int i = 0; i < 8; i++)
            {
                char tav1 = (char)rnd.Next(65, 91);
                char tav2 = (char)rnd.Next(97, 123);
                char num1 = (char)rnd.Next(48, 58);
                char num2 = (char)rnd.Next(48, 58);
                int index = rnd.Next(0, 4);
                switch (index)
                {
                    case 0: password += tav1; break;
                    case 1: password += tav2; break;
                    case 2: password += num1; break;
                    case 3: password += num2; break;
                }
            }
            return password;
        }
    }
}
