using MySql.Data.MySqlClient;
using QY.DBtools.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace QY.DBtools
{
    public class DBWorker : BackgroundWorker
    {
        private int _index;

        public DBWorker(int index)
        {
            _index = index;
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
            var args = e.Argument as WorkArguments;
            if (args == null)
            {
                return;
            }
            if (_index > 0)
            {//在起始阶段让线程尽量按序执行
                Thread.Sleep(_index * 100);
            }
            while (args.Hosts.TryDequeue(out Host item))
            {
                if (item.IsBusy)
                {
                    continue;
                }
                item.IsBusy = true;
                try
                {
                    DoWorkCore(item, args);
                }
                catch (Exception ex)
                {
                    ReportException(item, ex);
                }
                finally
                {
                    item.IsBusy = false;
                    ReportProgress(BatchHandler.STATUS_ITEM, item);
                }
            }
            e.Result = args;
        }

        private void ReportException(Host item, Exception e)
        {
            item.HasError = true;
            ReportProgress(BatchHandler.MSG_ITEM, new HostMessage(item.Name, e));
        }

        private void DoWorkCore(Host item, WorkArguments args)
        {
            ReportProgress(BatchHandler.MSG_ITEM,
                new HostMessage(item.Name, MessageStatus.Info, "开始连接数据库"));
            var connStr = args.CreateConnectionString(item.Address, item.Port, item.User, item.Password);
            using (var conn = new MySqlConnection(connStr))
            using (var cmd = conn.CreateCommand())
            //using (var sr = new StringReader(source))
            {
                if (!conn.State.HasFlag(ConnectionState.Open))
                {
                    conn.Open();
                }
                int resultSetIndex = 0;
                //string line;
                //while ((line = sr.ReadLine()) != null)
                //{

                //}
                cmd.CommandText = args.Source;
                using (var rdr = cmd.ExecuteReader())
                {
                    int rc = rdr.RecordsAffected;
                    if (!rdr.HasRows)
                    {
                        ReportProgress(BatchHandler.MSG_ITEM, new HostMessage(item.Name, MessageStatus.Info, "执行成功", rc));
                    }
                    RetrieveData(item, rdr, args.LimitRows, resultSetIndex);
                    while (rdr.NextResult())
                    {
                        resultSetIndex++;
                        RetrieveData(item, rdr, args.LimitRows, resultSetIndex);
                    }
                }
            }
        }

        private void RetrieveData(Host item, MySqlDataReader rdr, int limitRows, int resultSetIndex)
        {
            var fieldCount = rdr.FieldCount;
            if (fieldCount <= 0)
            {
                return;
            }
            var dt = new DataTable();
            var cols = dt.Columns;
            cols.Add(new DataColumn(Host.HostName, typeof(string)));
            for (int i = 0; i < fieldCount; i++)
            {
                cols.Add(rdr.GetName(i), rdr.GetFieldType(i));
            }
            object[] vals = new object[fieldCount + 1];
            int rowIndex = 0;
            bool allRetrieved = true;
            while (rdr.Read())
            {
                if (rowIndex >= limitRows)
                {
                    allRetrieved = false;
                    break;
                }
                vals[0] = item.Name;//第一列为主机名
                for (int i = 0; i < fieldCount; i++)
                {
                    vals[i + 1] = rdr.GetValue(i);
                }
                dt.Rows.Add(vals);
                rowIndex++;
            }
            ReportProgress(BatchHandler.MSG_ITEM, new HostMessage(item.Name, dt, allRetrieved, resultSetIndex));
        }
    }
}
