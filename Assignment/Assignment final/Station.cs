using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_final
{
    class Station
    {
        string sName;
        int id;

        public Station(String name, int id)
        {
            this.sName = name;
            this.id = id;
        }

        public Station()
        {
            this.sName = "";
            this.id = 0;
        }

        public String getName()
        {
            return sName;
        }

        public void setName(String name)
        {
            this.sName = name;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }
    }
}
