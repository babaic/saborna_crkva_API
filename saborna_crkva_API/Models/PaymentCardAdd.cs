using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Models
{
    public class PaymentCardAdd
    {
        public string BrojKartice { get; set; }
        public int Mjesec { get; set; }
        public int Godina { get; set; }
        public int CVV { get; set; }
        public string ImePrezime { get; set; }
        public int UserId { get; set; }
        public long Amount { get; set; }
        public string Desc { get; set; }
    }
}
