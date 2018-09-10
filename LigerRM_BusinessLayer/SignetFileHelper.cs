using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SignetInternet_DataLayer.SignetDataSetTableAdapters;

namespace SignetInternet_BusinessLayer
{
    public class SignetFileHelper
    {
        t_signet_filesTableAdapter adapter = new t_signet_filesTableAdapter();
        public DataTable SignetFileSelectBySignetId(string signetId)
        {
            return adapter.up_SignetInternet_SignetFilesSelectBySignetID(signetId);
        }

        public DataTable SignetFileSelectByID(long id)
        {
            return adapter.up_SignetInternet_SignetFilesSelectByID(id);
        }

        public void AddSignetFile(string signetId, string type, string file, byte[] data, string demo)
        {
            adapter.up_SignetInternet_SignetFilesInsert(signetId, type, file, data, demo);
        }

        public void DeleteSignetFile(long id)
        {
            adapter.up_SignetInternet_SignetFilesDeleteByID(id);
        }

        public void UpdateSignetFile(string filename, byte[] data, string memo, long id)
        {
            adapter.up_SignetInternet_SignetFilesUpdateByID(filename, data, memo, id);
        }
    }
}
