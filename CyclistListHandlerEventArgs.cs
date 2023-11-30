using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborat._4
{
    internal class CyclistListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public Cyclist ChangedCyclist { get; set; }

        public CyclistListHandlerEventArgs(string collectionName, string changeType, Cyclist changedCyclist)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangedCyclist = changedCyclist;
        }

        public override string ToString()
        {
            return $"{ChangeType} in collection {CollectionName}: {ChangedCyclist}";
        }
    }
}