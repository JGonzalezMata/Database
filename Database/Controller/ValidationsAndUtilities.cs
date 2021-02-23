using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Controller
{
    public class PrimDataVal //Validations for Form2
    {
        public string GenerateEmployeeNomber(string data)
        {
            string zero = "";
            for (int i = 0; i <= (7 - data.Length); i++)
            {
                zero += "0";
            }
            zero = zero + data;
            return zero;
        }
    }

    public class SecDataVal //Validations for Form3
    {

    }

    public class DepDataVal //Validations for Form4
    {

    }
}
