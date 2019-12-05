using System;
using System.Collections.Generic;
using System.Web;

namespace eChartProject.Web.Common
{
    public class VariarionsROW
    {
        private bool? isoffline;
        private bool? isDeleted;
        private int type;
        private int? id;

        private string name;


        public VariarionsROW() { }

        public VariarionsROW(string name,  int? id, int type, bool? isDeleted, bool? isoffline)
        {
            this.name = name;
            this.id = id;
            this.type = type;
            this.IsDeleted = isDeleted;
            this.isoffline = isoffline;
        }
      

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id == null ? 0 : id.Value; }
            set { id = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool? Isoffline
        {
            get { return isoffline; }
            set { isoffline = value; }
        }
        public bool? IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}