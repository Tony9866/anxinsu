using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SignetInternet_DataLayer.BaseDataSetTableAdapters;


namespace SignetInternet_BusinessLayer
{
    public class SignetBaseInfoManager
    {
        //For register management////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable GetAllRegisters()
        {
            t_reg_deptTableAdapter adapter = new t_reg_deptTableAdapter();
            DataTable returnTable = null;
            returnTable = adapter.up_SignetInternet_RegisterSelectAll();
            return returnTable;
        }

        public void UpdateRegisters(string newId, string name, string pic, string address, string phone, string emailcode, string memo)
        {
            t_reg_deptTableAdapter adapter = new t_reg_deptTableAdapter();
            adapter.up_SignetInternet_RegisterUpdateByID(name, pic, address, phone, emailcode, string.Empty, "A", memo, newId);
        }

        public void DeleteRegister(string regId)
        {
            t_reg_deptTableAdapter adapter = new t_reg_deptTableAdapter();
            adapter.up_SignetInternet_RegisterDeleteByID(regId);
        }

        public void AddRegister(string newId, string name, string pic, string address, string phone, string emailcode, string memo)
        {
            t_reg_deptTableAdapter adapter = new t_reg_deptTableAdapter();
            adapter.up_SignetInternet_RegisterInsert(newId, name, pic, address, phone, emailcode, string.Empty, "A", memo);
        }

        public bool ExistsRegister(string registerId)
        {
            t_reg_deptTableAdapter adapter = new t_reg_deptTableAdapter();
            return adapter.up_SignetInternet_RegisterSelectByID(registerId).Rows.Count > 0;
        }

        public DataTable GetReisterArea(string regId)
        {
            t_reg_deptTableAdapter adapter = new t_reg_deptTableAdapter();
            return adapter.up_SignetInternet_RegisterSelectByID(regId);
        }

        //For general code management///////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable GetGeneralCode(string group)
        {
            string sql = "select * from t_general_code where gc_code_group='" + group + "'";
            return MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        }

        public void UpdateGeneralCode(string name, string newId, string group, string oldId)
        {
            string sql = "update t_general_code set gc_id='"+newId+"', gc_name='"+name+"' where gc_group_code='"+group+"' and gc_id='"+oldId+"'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void DeleteGeneralCode(string group, string id)
        {
            string sql = "delete from t_general_code where gc_code_group='"+group+"' and gc_id='"+id+"'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void AddGeneralCode(string group, string id, string name)
        {
            string sql = "INSERT INTO t_general_code (gc_code_group, gc_id, gc_name, gc_status) VALUES     ('" + group + "','" + id + "','" + name + "','A')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public bool ExistsGeneralCode(string group, string name)
        {
            string sql = "select * from t_general_code where gc_code_group='"+group+"' and gc_id='"+name+"'";
            return MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0].Rows.Count > 0;
        }

    }
}
