using System;
using System.Collections.Generic;
using System.Web;

namespace eChartProject.Web.Common
{
    public class Row
    {
        private bool? isoffline;
        private bool? isDeleted;
        private int type;
        private int? id;
        private string icon;
        private string name;
        List<Row> rows;

        public Row() { }

        public Row(string name, string icon, int? id, int type, bool? isDeleted, bool? isoffline, List<Row> rows)
        {
            this.name = name;
            this.icon = icon;
            this.id = id;
            this.type = type;
            this.IsDeleted = isDeleted;
            this.isoffline = isoffline;
            this.rows = rows;
        }
        public List<Row> Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
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