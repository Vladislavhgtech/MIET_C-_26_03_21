using System;
using System.Collections.Generic;
using System.Text;

namespace labMIET4_290421
{
    public interface IDateAndCopy
    {
        DateTime Date { get; set; }
        object DeepCopy();
    }
}
