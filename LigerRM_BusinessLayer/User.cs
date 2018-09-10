using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignetInternet_BusinessLayer.Models.User;

namespace SignetInternet_BusinessLayer
{
    public class User : BaseHelper
    {
        public List<UserModel> GetUserName()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT *,LoginName as UserName  FROM CF_User");
                List<UserModel> userList = GetList<UserModel>(str.ToString());
                return userList;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
