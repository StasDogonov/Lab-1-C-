using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborat._4
{
    internal class Person
    {
        private string name;
        private string secondname;
        private System.DateTime dateofbirthday;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Secondname
        {
            get { return secondname; }
            set { secondname = value; }
        }

        public System.DateTime Dateofbirthday
        {
            get { return dateofbirthday; }
            set { dateofbirthday = value; }
        }

        public int Editdateofbirthday
        {
            get { return dateofbirthday.Year; }
            set { dateofbirthday = new DateTime(value, dateofbirthday.Month, dateofbirthday.Day); }
        }

        public Person(string name, string secondname, System.DateTime dateofbirthday)
        {
            Name = name;
            Secondname = secondname;
            Dateofbirthday = dateofbirthday;
        }

        public Person()
        {
            name = "No information";
            secondname = "No information";
            dateofbirthday = new DateTime(1, 1, 1);
        }

        public static bool operator ==(Person left, Person right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Person other = (Person)obj;

            //if (other.Name != this.Name)
            //{
            //    return false;
            //}
            //if (other.Secondname != this.Secondname)
            //{
            //    return false;
            //}
            //if (other.Dateofbirthday != this.Dateofbirthday)
            //{
            //    return false;
            //}
            //return true;

            return Name == other.Name && Secondname == other.Secondname && Dateofbirthday == other.Dateofbirthday;
        }

        public override int GetHashCode()
        {
            return (Name, Secondname, Dateofbirthday).GetHashCode();
        }

        public override string ToString()
        {

            return $"Name: {Name} " +
                   $"\nSecond name: {Secondname}" +
                   $"\nDate of Birth: {Dateofbirthday.ToShortDateString()}";
        }

        public virtual string ToShortString()
        {
            return $"Name: {Name} " +
                   $"\nSecond name {Secondname}";
        }
    }
}