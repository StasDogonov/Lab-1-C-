using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborat._4
{
    internal class Bike
    {
        public string model { get; set; }
        public int weight { get; set; }
        public System.DateTime date { get; set; }

        public Bike(string model, int weight, DateTime date)
        {
            this.model = model;
            this.weight = weight;
            this.date = date;
        }

        public Bike()
        {
            this.model = "Not specified";
            this.weight = 0;
            this.date = new DateTime(1, 1, 1);
        }

        public override string ToString()
        {
            return $"Model: {this.model}; Weight: {this.weight}; Date {this.date.ToShortDateString()}.";
        }
    }
}
