using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Entities;
using System.Reflection;

namespace xEasyApp.Core.JsonEntities
{
    public class JsonFlexiGridData
    {
        public JsonFlexiGridData()
        {
        }

        public JsonFlexiGridData(
            int pageIndex, int totalCount, IList<FlexiGridRow> data)
        {
            page = pageIndex;
            total = totalCount;
            rows = data;
        }
        public int page { get; set; }
        public int total { get; set; }
        public IList<FlexiGridRow> rows { get; set; }
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        public FlexiGridError error { get; set; }

        public static JsonFlexiGridData ConvertFromList<T>(List<T> list,string key,string[] cols) where T:class
        {
            JsonFlexiGridData data = new JsonFlexiGridData();
            data.page = 1;
            if (list != null)
            {
                data.total = list.Count;
                data.rows = new List<FlexiGridRow>();
                foreach (T t in list)
                { 
                    FlexiGridRow row =new FlexiGridRow();
                    row.id = getValue<T>(t,key);
                    row.cell = new List<string>();
                    foreach(string col in cols)
                    {
                        row.cell.Add(getValue<T>(t, col));
                    }
                    data.rows.Add(row);
                }
            }
            else
            {
                data.total = 0;
            }
            return data;
        }

        private static string getValue<T>(T t,string pname) where T:class
        {
            Type type = t.GetType();
            PropertyInfo pinfo = type.GetProperty(pname);
            if (pinfo != null)
            {
                object v = pinfo.GetValue(t, null);
                return v != null ? v.ToString() : "";
            }
            return "";
        }
        public static JsonFlexiGridData ConvertFromPagedList<T>(PagedList<T> pagelist, string key, string[] cols) where T : class
        {
            JsonFlexiGridData data = new JsonFlexiGridData();
            data.page = pagelist.PageIndex+1;
            if (pagelist.PageIndex == 0)
            {
                data.total = pagelist.Total;
            }
            data.rows = new List<FlexiGridRow>();
            foreach (T t in pagelist.DataList)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = getValue<T>(t, key);
                row.cell = new List<string>();
                foreach (string col in cols)
                {
                    row.cell.Add(getValue<T>(t, col));
                }
                data.rows.Add(row);
            }
            return data;
        }
    }
    /// <summary>
    /// flexigrid的数据行
    /// </summary>
    public class FlexiGridRow
    {
        public string id { get; set; }
        public List<string> cell { get; set; }
    }
    public class FlexiGridError
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage { get; set; }
    }
}
