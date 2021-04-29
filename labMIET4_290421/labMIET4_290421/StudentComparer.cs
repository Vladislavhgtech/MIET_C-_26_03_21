using System;
using System.Collections.Generic;
using System.Text;

namespace labMIET4_290421
{
    class StudentComparer : IComparer<Student>
    {

     
            public int Compare(Student student1, Student student2)
            {
                if (student1.AverageScore > student2.AverageScore)
                {
                    return 1;
                }
                else if (student1.AverageScore < student2.AverageScore)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

