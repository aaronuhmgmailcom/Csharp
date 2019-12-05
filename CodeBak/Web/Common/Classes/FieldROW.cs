using System;
using System.Collections.Generic;
using System.Web;

namespace eChartProject.Web.Common
{
    public class FieldsROW
    {
        private string name;


        public FieldsROW() { }

        public FieldsROW(string name)
        {
            this.name = name;
           
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

     
    }
}