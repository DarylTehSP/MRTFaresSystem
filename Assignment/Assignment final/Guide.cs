using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_final
{
    class Guide
    {
        string line1, line2, name;
        public Guide(string line1, string line2, string name)
        {
            this.line1 = line1;
            this.line2 = line2;
            this.name = name;
        }

        public string matchLine(string start, string stop)
        {
            if ((start == line1 || start == line2) && (stop == line1 || stop == line2))
                return name;
            else
                return null;
        }

        public string getLine1()
        {
            return line1;
        }

        public string getLine2()
        {
            return line2;
        }
    }
}
