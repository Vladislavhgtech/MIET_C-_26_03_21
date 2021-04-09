using System;
using System.Collections.Generic;
using System.Text;

namespace labMIET_2_260321
{
    class Test
    {
        string name;
        bool testState;
        public int _ifPass { get; set; }

        public Test(string name, bool testState)
        {
            this.name = name;
            this.testState = testState;
        }

        public Test(string testName, int ifPass)
        {
            name = testName;
            _ifPass = ifPass;
        }

        public Test()
        {
            name = "";
            testState = false;
        }

        public override string ToString()
        {
            string result = "";
            result += name + ' ';
            if (testState)
            {
                result += " Сдано /n";
            }
            else
            {
                result += " Не сдано /n";
            }
            return result;
        }




    }

}
