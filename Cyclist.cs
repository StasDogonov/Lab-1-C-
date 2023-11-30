using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborat._4
{
    enum QUALIFICATION
    {
        No_specialization,
        Beginner,
        Professional,
        MasterOfSport
    }
    internal class Cyclist : Person
    {
        private QUALIFICATION qualification;
        private int height;
        private List<Equipment> equipment;
        private List<Bike> bike;

        public Person PPerson
        {
            get
            {
                return new Person(Name, Secondname, Dateofbirthday);
            }
            set
            {
                Name = value.Name;
                Secondname = value.Secondname;
                Dateofbirthday = value.Dateofbirthday;
            }
        }

        public QUALIFICATION Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value > 250)
                {
                    height = 250;
                    throw new ArgumentOutOfRangeException("\nATTENTION!!! Height cannot be more than 250");
                }
                if (value <= 100)
                {
                    height = 100;
                    throw new ArgumentOutOfRangeException("\nATTENTION!!! Height cannot be less than 100");
                }
                else { height = value; }
            }
        }

        //public Bike getBikes(int number)
        //{
        //    return bike[number];
        //}
        //public void setBikes(int amount)
        //{
        //    bike = new Bike[amount];
        //}
        public List<Equipment> Equipment
        {
            get { return equipment; }
            set { equipment = value; }
        }
        public List<Bike> Bikes
        {
            get { return bike; }
            set { bike = value; }
        }
        public Cyclist(Person person, QUALIFICATION qualification, int height)
            : base(person.Name, person.Secondname, person.Dateofbirthday)
        {
            Qualification = qualification;
            Height = height;
            Equipment = new List<Equipment>();
            Bikes = new List<Bike>();
        }

        public Cyclist()
        {
            //PPerson = new Person();
            Qualification = 0;
            height = 0;
            Equipment = new List<Equipment>();
            Bikes = new List<Bike>();
        }

        public double MaxWeight
        {
            get
            {
                double MaxWeight = 0;
                if (bike.Count >= 1)
                {
                    MaxWeight = bike[0].weight;
                    for (int i = 1; i < bike.Count; i++)
                    {
                        if (MaxWeight < bike[i].weight)
                        {
                            MaxWeight = bike[i].weight;
                        }
                    }
                    return MaxWeight;
                }
                return MaxWeight;
            }
        }

        public void AddNewBikes(params Bike[] bike)
        {
            //int size = this.bike.Length + bike.Length;
            //Bike[] newbike = new Bike[size];

            for (int i = 0; i < bike.Length; i++)
            {
                this.bike.Add(bike[i]);
            }

            //for (int i = 0; i < bike.Length; i++)
            //{
            //    newbike[i + this.bike.Length] = bike[i];
            //}
            //this.bike = newbike;
        }

        public override string ToString()
        {
            string equipmentes = $"\nAll equipmentes:";
            for (int i = 0; i < Equipment.Count; i++)
            {
                equipmentes += $"\nEquipmente №{i + 1} \t {Equipment[i].ToString()}";
            }
            string bikes = $"\nAll bikes:";
            for (int i = 0; i < Bikes.Count; i++)
            {
                bikes += $"\nBike №{i + 1} {Bikes[i].ToString()}";
            }
            return $"{PPerson.ToString()}" +
                   $"\nHeight: {Height}" +
                   $"\nQualification: {Qualification}" +
                   "\n" + bikes + "\n" + equipmentes;
        }

        public override string ToShortString()
        {
            return $"\n{PPerson.ToString()}" +
                   $"\nHeight: {Height}" +
                   $"\nQualification: {Qualification}" +
                   $"\nMaximum weight among all bicycles: {MaxWeight}\n";
        }
    }
}
