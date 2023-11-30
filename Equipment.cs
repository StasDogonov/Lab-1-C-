using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborat._4
{
    internal class Equipment
    {
        public string name { get; set; }
        public bool status { get; set; }

        public Equipment(string name, bool status)
        {
            this.name = name;
            this.status = status;
        }

        public Equipment()
        {
            name = "Not specified";
            status = false;
        }

        public override string ToString()
        {
            string strstatus;
            if (status)
            {
                strstatus = "used";
            }
            else
            {
                strstatus = "not used";
            }

            return $"|Name: {name}|" +
                   $"\t|Status: {strstatus}|";
        }
    }
}
