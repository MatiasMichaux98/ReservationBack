using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Exceptions
{
    public class BussinessExceptions : Exception
    {
        public BussinessExceptions(string messege)
            :base(messege)
        {
            
        }
    }
}
