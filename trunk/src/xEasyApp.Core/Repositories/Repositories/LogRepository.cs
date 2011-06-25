using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Entities;
using System.Data;

namespace xEasyApp.Core.Repositories
{
    public partial class LogRepository
    {
        public PagedList<Log> QueryOperLog(PageView view, string qtext, string optype, LogType logtype)
        {
            string where = "";

            if (logtype != LogType.None)
            {
                where += " and LogType=" + logtype.GetHashCode();
            }
            if (!string.IsNullOrEmpty(optype))
            {
                where += " and OperateCode='" + optype + "'";
            }
            if (!string.IsNullOrEmpty(qtext))
            {
                where += " and [Content] like '%" + qtext + "%'";
            }
            StoredProcedure sp = StoredProcedures.SP_PAGESELECT(where, view.PageSize, view.PageIndex
              , "[Logs]", "[Id],[Content],[OperateCode],[LogType],[OperateUID],[OperateName],[IPAddress],[OperateTime]", "[Id]",
              "Order By Id DESC");
            var pl = new PagedList<Log>();
            pl.DataList = new List<Log>();
            using (IDataReader dr = base.SPExecuteDataReader(sp))
            {
                while (dr.Read())
                {
                    Log log = new Log();
                    log.Id = dr.GetInt32(0);
                 
                    log.Content = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    log.OperateCode = dr.GetString(2);
                    log.LogType = dr.GetByte(3);
                    log.OperateUID = dr.GetString(4);
                    log.OperateName = dr.GetString(5);
                    log.IPAddress = dr.GetString(6);
                    log.OperateTime = dr.GetDateTime(7);
                 
                    log.IsNew = false;
                    pl.DataList.Add(log);
                }
            }

            if (view.PageIndex == 0)
            {
                pl.Total = Convert.ToInt32(sp.GetParameterValue(sp.ParamsCount - 1));
            }
            pl.PageIndex = view.PageIndex;


            return pl;
        }
    }
}
