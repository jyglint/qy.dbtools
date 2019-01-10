using Newtonsoft.Json;
using QY.DBtools.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QY.DBtools.Models
{
    public class WorkArguments
    {
        public string ConnectionString { get; set; }

        public string DataBase { get; set; }

        public int LimitRows { get; set; }

        public int MaxThreads { get; set; }

        [JsonIgnore]
        public string Source { get; set; }

        [JsonIgnore]
        public ConcurrentQueue<Host> Hosts { get; set; }

        public static WorkArguments CreateDefault()
        {
            var was = new WorkArguments()
            {
                ConnectionString = "server={0};port={1};user id={2};password={3};persistsecurityinfo=True;database={4};characterset=utf8;allowuservariables=True;keepalive=30;defaultcommandtimeout=1800",
                DataBase = null,//为显示控件的NullText
                LimitRows = 10,
                MaxThreads = 16
            };
            return was;
        }

        internal string CreateConnectionString(string address, int port, string user, string password)
        {
            return CreateConnectionString(ConnectionString, address, port, user, password, DataBase);
        }

        public static string CreateConnectionString(string connectionString, string address, int port, string user, string password, string dataBase)
        {
            return string.Format(connectionString, address, port, user, password, dataBase);
        }
    }
}
