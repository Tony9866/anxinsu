using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Services.Protocols;
using System.Xml;
using System.IO;
using System.Security.Principal;

namespace LigerRM.WebService
{
    public delegate void WebServiceAuthenticationEventHandler(Object sender, WebServiceAuthenticationEvent e);
    public class Authentication : SoapHeader
    {
        public string UserID;
        public string PassWord;
        public string TimeStamp;
        public string Token;
        //header校验规则  UserID：admin  PassWord：Pa$$w0rd780419  TimeStamp：时间戳 Token：“guardts”+时间戳+“house”拼接后进行md5加密 
        //Lockheader校验规则  UserID：admin  PassWord：Lock$$123654  TimeStamp：时间戳 Token：“locks”+时间戳+“dock”拼接后进行md5加密 

        public Authentication()
        { 
        
        }

        public bool ValideUser()
        {
            if (UserID == "admin" && PassWord == "Pa$$w0rd780419")
            {
                if (string.IsNullOrEmpty(TimeStamp))
                    return false;
                string str = LigerRM.Common.Global.Encryp.MD5("guardts" + TimeStamp + "house");
                if (str.Equals(Token))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool ValideLockUser()
        {
            LigerRM.Common.LogManager.WriteLog("User: " + UserID + " Password:" + PassWord);
            if (UserID == "admin" && PassWord == "Lock$$123654")
            {
                if (string.IsNullOrEmpty(TimeStamp))
                    return false;
                string str = LigerRM.Common.Global.Encryp.MD5("locks" + TimeStamp + "dock");
                LigerRM.Common.LogManager.WriteLog("Source Token: " + Token + " Validate Token:" + str);
                if (str.Equals(Token))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }

    public  class WebServiceAuthenticationModule : IHttpModule
    {
        private WebServiceAuthenticationEventHandler
                      _eventHandler = null;

        public event WebServiceAuthenticationEventHandler Authenticate
        {
            add { _eventHandler += value; }
            remove { _eventHandler -= value; }
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {
            app.AuthenticateRequest += new
                       EventHandler(this.OnEnter);
        }

        private void OnAuthenticate(WebServiceAuthenticationEvent e)
        {
            if (_eventHandler == null)
                return;

            _eventHandler(this, e);
            if (e.User != null)
                e.Context.User = e.Principal;
        }

        public string ModuleName
        {
            get { return "WebServiceAuthentication"; }
        }

        void OnEnter(Object source, EventArgs eventArgs)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;
            Stream HttpStream = context.Request.InputStream;

            // Save the current position of stream.
            long posStream = HttpStream.Position;

            // If the request contains an HTTP_SOAPACTION 
            // header, look at this message.
            if (context.Request.ServerVariables["HTTP_SOAPACTION"]
                           == null)
                return;

            // Load the body of the HTTP message
            // into an XML document.
            XmlDocument dom = new XmlDocument();
            string soapUser;
            string soapPassword;

            try
            {
                dom.Load(HttpStream);

                // Reset the stream position.
                HttpStream.Position = posStream;

                // Bind to the Authentication header.
                soapUser =
                    dom.GetElementsByTagName("User").Item(0).InnerText;
                soapPassword =
                    dom.GetElementsByTagName("Password").Item(0).InnerText;
            }
            catch (Exception e)
            {
                // Reset the position of stream.
                HttpStream.Position = posStream;

                // Throw a SOAP exception.
                XmlQualifiedName name = new
                             XmlQualifiedName("Load");
                SoapException soapException = new SoapException(
                          "Unable to read SOAP request", name, e);
                throw soapException;
            }

            // Raise the custom global.asax event.
            OnAuthenticate(new WebServiceAuthenticationEvent
                         (context, soapUser, soapPassword));
            return;
        }
    }

    public class WebServiceAuthenticationEvent : EventArgs
    {
        private IPrincipal _IPrincipalUser;
        private HttpContext _Context;
        private string _User;
        private string _Password;

        public WebServiceAuthenticationEvent(HttpContext context)
        {
            _Context = context;
        }

        public WebServiceAuthenticationEvent(HttpContext context,
                        string user, string password)
        {
            _Context = context;
            _User = user;
            _Password = password;
        }
        public HttpContext Context
        {
            get { return _Context; }
        }
        public IPrincipal Principal
        {
            get { return _IPrincipalUser; }
            set { _IPrincipalUser = value; }
        }
        public void Authenticate()
        {
            GenericIdentity i = new GenericIdentity(User);
            this.Principal = new GenericPrincipal(i, new String[0]);
        }
        public void Authenticate(string[] roles)
        {
            GenericIdentity i = new GenericIdentity(User);
            this.Principal = new GenericPrincipal(i, roles);
        }
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public bool HasCredentials
        {
            get
            {
                if ((_User == null) || (_Password == null))
                    return false;
                return true;
            }
        }
    }

    public class ServiceCredential : SoapHeader
    {
        public string User;
        public string Password;
        public bool ValideUser(string User, string Password)
        {
            return true;
        }
        public void CheckUser(Object sender, WebServiceAuthenticationEvent e)
        {
            if (ValideUser(e.User, e.Password))
            {
                return;
            }
            else
            {
                WebServiceAuthenticationModule module = sender as WebServiceAuthenticationModule;
                //return "Invalid user.";
            }
        }
    }
}