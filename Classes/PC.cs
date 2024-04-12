using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace var10_graf.Classes
{
    public class PC
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Time { get; set; }
        public string FIO { get; set; }
        public string phone_number { get; set; }
        public string passport { get; set; }

        public PC(int Id, DateTime Data, string Time, string FIO, string phone_number, string passport)
        {
            this.Id = Id;
            this.Data= Data;
            this.Time = Time;
            this.FIO = FIO;
            this.phone_number = phone_number;
            this.passport = passport;
        }
    }
}
