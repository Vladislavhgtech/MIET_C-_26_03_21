using System;
using System.Collections.Generic;
using System.Text;

namespace labMIET4_290421
{
    class StudentListHandlerEventArg : System.EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public Student ChangeObject { get; set; }

        public StudentListHandlerEventArg()
        {
            CollectionName = "Unknown";
            ChangeType = "Unknown";
            ChangeObject = new Student();
        }

        public StudentListHandlerEventArg(string collectionName, string changeType, Student changeObject)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangeObject = changeObject;
        }

        public override string ToString()
        {
            return CollectionName + ";" + ChangeType + ";" + ChangeObject.ToString() + ";" + "|";
        }

    }
}

