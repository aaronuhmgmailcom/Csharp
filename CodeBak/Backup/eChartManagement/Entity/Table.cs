using System;
using System.Collections.Generic;
using System.Text;

namespace eChartProject.eChartManagement.Entity
{

    public class TableEnt
    {
        /// <summary>
        /// Table info
        /// </summary>
        public TableInfo TableInfo
        {
            get;
            set;
        }
        /// <summary>
        /// 目录下Field
        /// </summary>
        public FieldInfo FieldInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 目录下table
        /// </summary>
        public TableEnt ITable
        {
            get;
            set;
        }
    }
}
