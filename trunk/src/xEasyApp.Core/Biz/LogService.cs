using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Repositories;
using xEasyApp.Core.Configurations;
using xEasyApp.Core.Entities;
using xEasyApp.Core.Common;
using xEasyApp.Core.Interfaces;

namespace xEasyApp.Core.Biz
{
    public class LogService:ILogService
    {

        private LogRepository _logRepository;
        protected LogRepository logRepository
        {
            get
            {
                if (_logRepository == null)
                {
                    _logRepository = new LogRepository();
                }
                return _logRepository;
            }
        }
        /// <summary>
        /// 记录业务日志
        /// </summary>
        /// <param name="log">日志</param>
        public void Log(Log log)
        {
            if (AppConfig.EnableOpLog) //如果允许记录操作日志
            {
                try
                {
                    logRepository.Save(log);
                }
                catch
                {
                    //报错了做点什么呢？
                }
            }
        }




        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="content">日志内容</param>
        /// <param name="logtype">日志类型</param>
        public void Log(string opType, string content, LogType logtype)
        {
            Log log = new Log();
            log.LogType = Convert.ToByte(logtype.GetHashCode());
            log.Content = content;
            log.IPAddress = MyContext.UserIP;
            log.OperateName = MyContext.CurrentUser.FullName;
            log.OperateTime = DateTime.Now;
            log.OperateCode = opType;
            log.OperateUID = MyContext.Identity;
            Log(log);
        }

        /// <summary>
        /// 记录跟踪的操作日志
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="content">日志内容</param>
        public void Trace(string opType, string content)
        {
            Log(opType, content, LogType.Trace);
        }

        /// <summary>
        /// 记录调试的操作日志
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="content">日志内容</param>
        public void Debug(string opType, string content)
        {
            Log(opType, content, LogType.Debug);
        }

        /// <summary>
        /// 记录错误的操作日志
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="content">日志内容</param>
        public void Error(string opType, string content)
        {
            Log(opType, content, LogType.Error);
        }

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="view">分页信息</param>
        /// <param name="qtext">查询日志内容</param>
        /// <param name="optype">操作类别</param>
        /// <param name="logtyp">日志类别</param>
        /// <returns></returns>
        public PagedList<Log> QueryOperLog(PageView view, string qtext, string optype, LogType logtype)
        {
            // 过滤字符
            qtext = Utility.ClearSafeStringParma(qtext);
            optype = Utility.ClearSafeStringParma(optype);
            return logRepository.QueryOperLog(view, qtext, optype, logtype);
        }

        public Log GetOperLog(int logid)
        {
            return logRepository.Get(logid);
        }
    }
}
