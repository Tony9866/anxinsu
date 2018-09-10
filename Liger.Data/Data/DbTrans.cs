using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Liger.Common;
using Liger.Common.Extensions;
using Liger.Data.Resources;

namespace Liger.Data
{
    /// <summary>
    /// 事务
    /// </summary>
    public class DbTrans : IDisposable
    {

        /// <summary>
        /// 事务
        /// </summary>
        public DbTransaction Trans { get; private set; }
        /// <summary>
        /// 连接
        /// </summary>
        public DbConnection Connection { get; private set; }
        /// <summary>
        /// 事务级别
        /// </summary>
        public IsolationLevel IsolationLevel { get; private set; }

        /// <summary>
        /// 判断是否有提交或回滚
        /// </summary>
        private bool isCommitOrRollback = false; 
        /// <summary>
        /// 是否关闭
        /// </summary>
        private bool isClose = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="DbContext"></param>
        public DbTrans(DbTransaction trans)
        { 
            Guard.IsNotNull(trans, "trans");
            this.Trans = trans;
            this.Connection = trans.Connection;
            if (this.Connection.State != ConnectionState.Open)
                this.Connection.Open(); 
        }


        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            Trans.Commit(); 
            isCommitOrRollback = true; 
            Close();
        }


        /// <summary>
        /// 回滚
        /// </summary>
        public void Rollback()
        {
            Trans.Rollback();

            isCommitOrRollback = true;

            Close();
        }


        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="dbTrans"></param>
        /// <returns></returns>
        public static implicit operator DbTransaction(DbTrans dbTrans)
        {
            return dbTrans.Trans;
        }


        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            if (isClose)
                return; 
            if (!isCommitOrRollback)
            {
                isCommitOrRollback = true;

                Trans.Rollback();
            }

            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            } 
            Trans.Dispose(); 
            isClose = true;
        }

        /// <summary>
        /// 关闭连接并释放资源
        /// </summary>
        public void Dispose()
        {
            Close();
        }
           
    }
}
