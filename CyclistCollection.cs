using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborat._4
{
    internal class CyclistCollection
    {
        private List<Cyclist> cyclists = new List<Cyclist>();
        public delegate void CyclistListHandler(object source, CyclistListHandlerEventArgs args);
        public string CollectionName { get; set; }

        public List<Cyclist> Cyclists
        {
            get { return cyclists; }
            set { cyclists = value; }
        }
        //public void AddDefaults(int count)
        //{
        //    cyclists = new List<Cyclist>(count);
        //}

        public void AddDefaults(int count)
        {
            cyclists.Clear();
            for (int i = 0; i < count; i++)
            {
                cyclists.Add(new Cyclist());
                //OnCyclistsCountChanged("Added", new Cyclist());
                //CyclistsCountChanged?.Invoke(this, new CyclistListHandlerEventArgs(CollectionName, "Added", new Cyclist()));
                OnCyclistChanged(CyclistsCountChanged, new CyclistListHandlerEventArgs(CollectionName, "Added", new Cyclist()));
            }
        }
        public void AddCyclists(params Cyclist[] cyclist)
        {
            for (int i = 0; i < cyclist.Length; i++)
            {
                cyclists.Add(cyclist[i]);
                //OnCyclistsCountChanged("Added", cyclist[i]);
                //CyclistsCountChanged?.Invoke(this, new CyclistListHandlerEventArgs(CollectionName, "Added", cyclist[i]));
                OnCyclistChanged(CyclistsCountChanged, new CyclistListHandlerEventArgs(CollectionName, "Added", cyclist[i]));
            }
        }

        public bool Remove(int j)
        {
            if (j >= 0 && j < cyclists.Count)
            {
                var removedCyclist = cyclists[j];
                cyclists.RemoveAt(j);
                //OnCyclistsCountChanged("Removed", removedCyclist);
                //CyclistsCountChanged?.Invoke(this, new CyclistListHandlerEventArgs(CollectionName, "Removed", removedCyclist));
                OnCyclistChanged(CyclistsCountChanged, new CyclistListHandlerEventArgs(CollectionName, "Removed", removedCyclist));
                return true;
            }
            return false;
        }
        public Cyclist this[int index]
        {
            get
            {
                if (index >= 0 && index < cyclists.Count)
                {
                    return cyclists[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("index", "Index is out of range.");
                }
            }
            set
            {
                if (index >= 0 && index < cyclists.Count)
                {
                    cyclists[index] = value;
                    //OnCyclistReferenceChanged("Replaced", value);
                    //OnCyclistsCountChanged("Replaced", value);
                    //CyclistsCountChanged?.Invoke(this, new CyclistListHandlerEventArgs(CollectionName, "Replaced", value));
                    OnCyclistChanged(CyclistReferenceChanged, new CyclistListHandlerEventArgs(CollectionName, "Replaced", value));
                }
                else
                {
                    throw new ArgumentOutOfRangeException("index", "Index is out of range.");
                }
            }
        }

        public event CyclistListHandler CyclistsCountChanged;
        public event CyclistListHandler CyclistReferenceChanged;

        private void OnCyclistChanged(object source, CyclistListHandlerEventArgs args)
        {
            if (source != null)
            {
                CyclistListHandler handler = (CyclistListHandler)source;
                handler?.Invoke(this, args);
            }
        }
        //private void OnCyclistsCountChanged(string changeType, Cyclist cyclist)
        //{
        //    CyclistsCountChanged?.Invoke(this, new CyclistListHandlerEventArgs(CollectionName, changeType, cyclist));
        //}

        //private void OnCyclistReferenceChanged(string changeType, Cyclist cyclist)
        //{
        //    CyclistReferenceChanged?.Invoke(this, new CyclistListHandlerEventArgs(CollectionName, changeType, cyclist));
        //}
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < cyclists.Count; i++)
            {
                str += cyclists[i].ToString() + "\n________________________________________________________________________\n";
            }
            return str;
        }
        public string ToShortString()
        {
            string str = "";
            for (int i = 0; i < cyclists.Count; i++)
            {
                str += cyclists[i].ToShortString() 
                    + $"Amount bikes: {cyclists[i].Bikes.Count}\nAmount equipments: {cyclists[i].Equipment.Count}"
                    + "\n________________________________________________________________________";
            }
            return str;
        }
    }
}