using QY.DBtools.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace QY.DBtools
{
    public class BatchHandler : IDisposable
    {
        public const int STATUS_ITEM = -1;

        public const int MSG_ITEM = -2;

        private List<DBWorker> _workers = new List<DBWorker>();

        public Action<Host> OnHostStatusChanged { get; set; }

        public Action<HostMessage> OnHostMessage { get; set; }

        public Action<TimeSpan> OnWorkersCompleted { get; set; }

        private long _beginTicks;

        /// <summary>
        /// 正在执行的线程
        /// </summary>
        private int _workCount;

        public bool IsBusy
        {
            get
            {
                //foreach (var item in _workers)
                //{
                //    if (item.IsBusy)
                //    {
                //        return true;
                //    }
                //}
                //return false;
                return _workCount > 0;
            }
        }

        public void Execute(WorkArguments args)
        {
            var mt = args.MaxThreads;
            if (mt > args.Hosts.Count)
            {
                mt = args.Hosts.Count;
            }
            _workers.Clear();
            _beginTicks = DateTime.Now.Ticks;
            _workCount = mt;
            for (int i = 0; i < mt; i++)
            {
                DBWorker dw = new DBWorker(i);
                _workers.Add(dw);
                dw.ProgressChanged += DBWorker_ProgressChanged;
                dw.RunWorkerCompleted += DBWorker_RunWorkerCompleted;
                dw.RunWorkerAsync(args);
            }
        }

        private void DBWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == STATUS_ITEM)
            {
                OnHostStatusChanged?.Invoke((Host)e.UserState);
            }
            else if (e.ProgressPercentage == MSG_ITEM)
            {
                OnHostMessage?.Invoke((HostMessage)e.UserState);
            }
        }

        private void DBWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _workCount--;
            _workers.Remove((DBWorker)sender);
            if (_workCount == 0)
            {
                OnWorkersCompleted?.Invoke(new TimeSpan(DateTime.Now.Ticks - _beginTicks));
            }
        }

        internal void CancelAll()
        {
            foreach (var item in _workers)
            {
                if (!item.CancellationPending)
                {
                    item.CancelAsync();
                }
            }
        }

        public void Dispose()
        {
            CancelAll();
        }

        public static DataTable CreateResultTable()
        {
            var dt = new DataTable();
            dt.Columns.AddRange
            (new DataColumn[] {
                        CreateDataColumn(nameof(HostMessage.Name),Host.HostName,typeof(string)),
                        CreateDataColumn(nameof(HostMessage.Status),"状态",typeof(MessageStatus)),
                        CreateDataColumn(nameof(HostMessage.Time),"时间",typeof(DateTime)),
                        CreateDataColumn(nameof(HostMessage.Message),"消息",typeof(string)),
                        CreateDataColumn(nameof(HostMessage.AffectedRows),"影响行数",typeof(int)),
                        CreateDataColumn(nameof(HostMessage.ResultSet),"返回行数",typeof(int))
            });
            return dt;
        }

        private static DataColumn CreateDataColumn(string name, string caption, Type dataType)
        {
            return new DataColumn()
            {
                ColumnName = name,
                Caption = caption,
                DataType = dataType
            };
        }
    }
}
