using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QY.DBtools.Models
{
    public enum MessageStatus
    {
        None,
        Info,
        Warning,
        Error,
        Stop
    }

    public class HostMessage : HostBase
    {
        public const int INVISIBLE_ROWS = -1;

        public MessageStatus Status { get; private set; }

        public DateTime Time { get; private set; }

        public string Message { get; private set; }

        public int AffectedRows { get; private set; }

        public DataTable Table { get; private set; }

        public int ResultSet { get; private set; }

        public HostMessage(string name, MessageStatus status, string message, int affectedRows = INVISIBLE_ROWS)
        {
            Name = name;
            Status = status;
            Message = message;
            Time = DateTime.Now;
            AffectedRows = affectedRows;
        }

        /// <summary>
        /// 实例化带数据的HostMessage
        /// </summary>
        /// <param name="name">主机名</param>
        /// <param name="t">数据表</param>
        /// <param name="allRetrieved">是否提取了查询结果集中的所有记录</param>
        /// <param name="resultSetIndex">返回的数据集的序号</param>
        public HostMessage(string name, DataTable t, bool allRetrieved, int resultSetIndex)
            : this(name, MessageStatus.Info, null)
        {
            Table = t;
            if (allRetrieved)
            {//当查询返回的结果集获取了全部行的，则将AffectedRows置为行数，否则为默认值 INVISIBLE_ROWS
                AffectedRows = t.Rows.Count;
            }
            ResultSet = resultSetIndex;
        }

        public HostMessage(string name, Exception e)
            : this(name, MessageStatus.Error, e.Message)
        {
        }
    }
}
