using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborat._4
{
    internal class Journal
    {
        private List<JournalEntry> journalEntries = new List<JournalEntry>();

        public void SubscribeToCollection(CyclistCollection collection)
        {
            collection.CyclistsCountChanged += HandleCyclistsCountChanged;
            collection.CyclistReferenceChanged += HandleCyclistReferenceChanged;
            //collection.CyclistsCountChanged += HandleCyclistsCountChanged;
            //collection.CyclistReferenceChanged += HandleCyclistReferenceChanged;
        }

        //public void HandleCyclistsChanged(object source, CyclistListHandlerEventArgs args)
        //{
        //    var entry = new JournalEntry(args.CollectionName, args.ChangeType, args.ChangedCyclist);
        //    journalEntries.Add(entry);
        //}
        public void HandleCyclistsCountChanged(object source, CyclistListHandlerEventArgs args)
        {
            var entry = new JournalEntry(args.CollectionName, args.ChangeType, args.ChangedCyclist);
            journalEntries.Add(entry);
        }

        public void HandleCyclistReferenceChanged(object source, CyclistListHandlerEventArgs args)
        {
            var entry = new JournalEntry(args.CollectionName, args.ChangeType, args.ChangedCyclist);
            journalEntries.Add(entry);
        }

        public override string ToString()
        {
            string result = "Journal Entries:\n";
            foreach (var entry in journalEntries)
            {
                result += entry.ToString() + "\n________________________________________________________________________\n";
            }
            return result;
        }
    }
}