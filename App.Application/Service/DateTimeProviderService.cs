using App.Application.Common.Interface.ReservacionInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Service
{
    public class DateTimeProviderService : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
