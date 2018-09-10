<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        // Code that runs when an unhandled error occurs
        //Exception ex = Server.GetLastError().GetBaseException();
        Exception exception = Server.GetLastError();
        Exception innerException = exception.InnerException;
        String stackTrace = exception.StackTrace;
        String errorMessage = null;
        String errorSource = null;
        String targetSite = null;
        if (innerException != null)
        {
            stackTrace = innerException.StackTrace + "\r\n " + stackTrace;
            errorMessage = innerException.Message;
            if (string.IsNullOrEmpty(errorMessage))
                errorMessage = exception.Message;
            errorSource = innerException.Source;
            targetSite = innerException.TargetSite.ToString();
            innerException = innerException.InnerException;
        }
        else
        {
            stackTrace = exception.StackTrace + "\r\n " + stackTrace;
            errorMessage = exception.Message;
            if (string.IsNullOrEmpty(errorMessage))
                errorMessage = exception.Message;
            errorSource = exception.Source;
            targetSite = exception.TargetSite.ToString();
            innerException = exception.InnerException;
        }

        string message = "------------------------------------------------------------------------------------------------------------------"+ 
                        "\r\n Message:"+errorMessage +
                        "\r\n DateTime:" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")+
                        "\r\n SOURCE: " + errorSource +
                        "\r\n FORM: " + Request.Form.ToString() +
                        "\r\n QUERYSTRING: " + Request.QueryString.ToString() +
                        "\r\n TARGETSITE: " + targetSite +
                        "\r\n STACKTRACE: " + stackTrace+
                        "\r\n---------------------------------------------------------------------------------------------------------------";

        System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("~") + "//Exception.txt");
        sw.Write(message);
        sw.Close();

        //Response.Redirect("../Error.aspx");
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        string mac = LigerRM.Common.Global.RegisterHelper.GetMacAddress();
        string province = ConfigurationManager.AppSettings["Province"];
        string sourceCode = mac + province + "Eric";
        string code = LigerRM.Common.Global.Encryp.DESEncrypt(sourceCode);

        Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Config");
        AppSettingsSection app = config.AppSettings;

        //if (app.Settings["CrackNumber"] == null)
        //{
        //    if (!Request.RawUrl.ToLower().Contains("register.aspx"))
        //        Response.Redirect("Register.aspx?redictUrl=" + Request.RawUrl);
        //}
        //else
        //{
        //    string creackNumber = app.Settings["CrackNumber"].Value;
        //    if (!creackNumber.Equals(LigerRM.Common.Global.Encryp.MD5(code)))
        //    {
        //        Response.Redirect("Register.aspx?redictUrl=" + Request.RawUrl);
        //    }
        //}
        
        //Handle the invalid request
        /*
        string msg = app.Settings["InvalidMessage"].Value.ToString();
        string duration = app.Settings["ValidDuration"].Value.ToString();
        string IsSendMsg = app.Settings["SendMessage"].Value.ToString();

        System.Data.DataTable dt = null;
        SignetInternet_BusinessLayer.SignetHelper helper = new SignetInternet_BusinessLayer.SignetHelper();
        System.Data.DataSet ds=  helper.GetList(1, 1, "t_signet_rejectview", "sr_signet_id", "se_status='8' and sr_reject_date<'" + DateTime.Now.AddDays(- double.Parse(duration)) + "'", "*", "sr_reject_date asc", true);
        foreach (System.Data.DataRow row in ds.Tables[0].Rows)
        { 
            helper.ExcuteSQL("Update t_signet set se_status='K' where se_signet_id='"+row["sr_signet_id"].ToString()+"'");
            
            if (IsSendMsg.Equals("1"))
            {
                //Send the message
                SignetInternet_BusinessLayer.SignetInfo signet = new SignetInternet_BusinessLayer.SignetInfo(row["sr_signet_id"].ToString());
                List<string> phones = new List<string>();
                if (!phones.Contains(signet.LinkWay) &&!string.IsNullOrEmpty(signet.LinkWay))
                    phones.Add(signet.LinkWay);
                SignetInternet_BusinessLayer.CorporationInfo corp = new SignetInternet_BusinessLayer.CorporationInfo(signet.CorpID);
                if (!phones.Contains(corp.LinkWay) && !string.IsNullOrEmpty(corp.LinkWay))
                    phones.Add(corp.LinkWay);
                LigerRM.Common.Global.GSMHelper.SendMessage(phones, msg.Replace("{0}",signet.SignetID));
            }
        }*/
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Application_BeginRequest(Object sender, EventArgs e)
    {
        StartProcessRequest();
    }  

    #region SQL注入式攻击代码分析
    /// <summary>  
    /// 处理用户提交的请求  
    /// </summary>  
    private void StartProcessRequest()
    {
        try
        {
            string getkeys = "";
            string sqlErrorPage = "Error.aspx";//转向的错误提示页面  
            if (System.Web.HttpContext.Current.Request.QueryString != null)
            {

                for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                {
                    getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                    //log.Warn(System.Web.HttpContext.Current.Request.Url + " : " +System.Web.HttpContext.Current.Request.QueryString[i]);
                    if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.QueryString[getkeys]))
                    {
                        System.Web.HttpContext.Current.Response.Redirect(sqlErrorPage);
                        System.Web.HttpContext.Current.Response.End();
                    }
                }
            }
            if (System.Web.HttpContext.Current.Request.Form != null)
            {
                for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
                {
                    getkeys = System.Web.HttpContext.Current.Request.Form.Keys[i];
                    if (getkeys == "__VIEWSTATE") continue;
                    if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.Form[getkeys]))
                    {
                        System.Web.HttpContext.Current.Response.Redirect(sqlErrorPage);
                        System.Web.HttpContext.Current.Response.End();
                    }
                }
            }
        }
        catch
        {
            // 错误处理: 处理用户提交信息!  
        }
    }
    /// <summary>  
    /// 分析用户请求是否正常  
    /// </summary>  
    /// <param name="Str">传入用户提交数据 </param>  
    /// <returns>返回是否含有SQL注入式攻击代码 </returns>  
    private bool ProcessSqlStr(string Str)
    {
        bool ReturnValue = true;
        try
        {
            if (Str.Trim() != "")
            {
                string SqlStr = "and ¦exec ¦insert ¦select ¦delete ¦update ¦count ¦* ¦chr ¦mid ¦master ¦truncate ¦char ¦declare";

                string[] anySqlStr = SqlStr.Split('¦');
                foreach (string ss in anySqlStr)
                {
                    if (Str.ToLower().IndexOf(ss) >= 0)
                    {
                        ReturnValue = false;
                        break;
                    }
                }
            }
        }
        catch
        {
            ReturnValue = false;
        }
        return ReturnValue;
    }  
  #endregion
       
</script>
