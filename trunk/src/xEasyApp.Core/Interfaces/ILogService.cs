using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Entities;
using xEasyApp.Core.Repositories;

namespace xEasyApp.Core.Interfaces
{
    public interface ILogService
    {
        /// <summary>
        /// 记录业务日志
        /// </summary>
        /// <param name="log">The log.</param>
        void Log(Log log);

        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="content">日志内容</param>
        /// <param name="logtype">日志类型</param>
        void Log(string opType, string content, LogType logtype);

        /// <summary>
        ///  记录跟踪的操作日志
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="content">日志内容</param>
        void Trace(string opType, string content);

        /// <summary>
        /// 记录调试的操作日志
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="content">日志内容</param>
        void Debug(string opType, string content);

        /// <summary>
        /// 记录错误的操作日志
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="content">日志内容</param>
        void Error(string opType, string content);

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="view">分页信息</param>
        /// <param name="qtext">查询日志内容</param>
        /// <param name="optype">操作类别</param>
        /// <param name="logtype">操作类型</param>
        /// <returns></returns>
        PagedList<Log> QueryOperLog(PageView view, string qtext, string optype, LogType logtype);

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="logid">The logid.</param>
        /// <returns></returns>
        Log GetOperLog(int logid);
    }
}
