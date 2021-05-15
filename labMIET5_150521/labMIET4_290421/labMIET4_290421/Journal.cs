using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labMIET4_290421
{
    class Journal
    {
        private List<JournalEntry> JournalEntries;

        public Journal()
        {
            JournalEntries = new List<JournalEntry>();
        }

        public void ProcessStudentCountChange(object source, StudentListHandlerEventArg args)
        {
            JournalEntries.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.ChangeObject));
        }

        public void ProcessStudentReferenceChange(object source, StudentListHandlerEventArg args)
        {
            JournalEntries.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.ChangeObject));
        }

        public override string ToString()
        {
            string result = "";
            foreach (var n in JournalEntries)
            {
                result += n.ToString();
            }
            return result;
        }
    }
}

