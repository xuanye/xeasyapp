using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace xEasyApp.Core.Repositories
{
    public static class SqlHelperConfig
    {
        public static int SqlCommandExecuteTimeout = 600;
    }
}