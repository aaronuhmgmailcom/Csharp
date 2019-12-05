using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.Script.Serialization;
using eChartProject.eChartManagement.Entity;
using System.Data;

namespace eChartProject.Web.Common
{
    public static class TableXmlRowHelper
    {
        public static string GetHtmlRows(DataTable dt)
        {
            string htmlString = string.Empty;

            //if (dt != null)
            //{
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        List<FieldInfo> fieldList = new List<FieldInfo>();
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            FieldInfo mi = new FieldInfo();
            //            mi.Name = dr["Name"].ToString();
            //            fieldList.Add(mi);
            //        }
            //        TableEnt rows = new TableEnt();

            //        htmlString = XmlSerialization<TableEnt>.Serialize(rows);
            //    }
            //}

            return htmlString;
        }

        //private static List<FieldsROW> GetFieldRowsByFieldList(List<FieldInfo> fl)
        //{
        //    List<FieldsROW> rows = new List<FieldsROW>();
        //    if (fl != null)
        //    {
        //        for (int i = 0; i < fl.Count; i++)
        //        {
        //            rows.Add(ConvertRowFromFileInfo(fl[i]));
        //        }
        //    }
        //    return rows;
        //}

        //private static FieldsROW ConvertRowFromFileInfo(FieldInfo f)
        //{
        //    FieldsROW r = new FieldsROW(f.Name

        //        );
        //    return r;
        //}


    }

}