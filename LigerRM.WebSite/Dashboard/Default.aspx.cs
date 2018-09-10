using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.Data;
using LigerRM.Common;

public partial class Dashboard_Default : System.Web.UI.Page
{
    public string HOUSE_TOTALCOUNT = string.Empty;
    public string HOUSE_LEFTCOUNT = string.Empty;
    public string HOUSE_USEDCOUNT = string.Empty;

    public string MOTOR_TOTALCOUNT = string.Empty;
    public string MOTOR_LEFTCOUNT = string.Empty;
    public string MOTOR_USEDCOUNT = string.Empty;

    public string WEATHER_CATEGORIES = string.Empty;
    public string WEATHER_DATA = string.Empty;

    public string ENV_DATA = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetHouseInfo();
            GetMotorInfo();
            GetCommunity();
            GetWeatherData();

            GetEnviromentData();
        }
    }

    private void GetHouseInfo()
    {
        RentInfoHelper helper = new RentInfoHelper();
        DataTable dt = helper.GetRentsByStreet("9");
        HOUSE_TOTALCOUNT = dt.Rows.Count.ToString();
        int leftCount = 0;
        int usedCount = 0;
        
        foreach (DataRow row in dt.Rows)
        {
            if (row["Available"].ToString() == "True")
            {
                leftCount++;
            }
            else
                usedCount++;
        }

        HOUSE_LEFTCOUNT = leftCount.ToString();
        HOUSE_USEDCOUNT = usedCount.ToString();

    }

    private void GetMotorInfo()
    {
        string sql = "select 'UsedCount' = (select COUNT(0) from dbo.Motor_BerthesInfo where status='0'),'LeftCount' = (select COUNT(0) from dbo.Motor_BerthesInfo where status='1')";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        MOTOR_LEFTCOUNT = dt.Rows[0]["LeftCount"].ToString();
        MOTOR_USEDCOUNT = dt.Rows[0]["UsedCount"].ToString();
        MOTOR_TOTALCOUNT = (int.Parse(dt.Rows[0]["LeftCount"].ToString()) + int.Parse(dt.Rows[0]["UsedCount"].ToString())).ToString();

    }

    private void GetCommunity()
    {
        string sql = "select * from service_community order by rank asc";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        rpCommunity.DataSource = dt;
        rpCommunity.DataBind();
    }

    protected void timer_Tick(object sender, EventArgs e)
    {
        lblTimer.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    protected void GetWeatherData()
    {
        string url = "https://free-api.heweather.com/s6/weather/forecast?location=auto_ip&key=0ee001fdc5c7401d82d9f683a93fb881";
        string ret =  LigerRM.Common.WebRequestHelper.WebRequestPoster.Post(url);

        RootObject r= JSONHelper.FromJson<RootObject>(ret);
        for (int i = 0; i < r.HeWeather6[0].daily_forecast.Count; i++)
        {
            WEATHER_CATEGORIES += DateTime.Parse(r.HeWeather6[0].daily_forecast[i].date).ToString("MM-dd") + ",";
            WEATHER_DATA +=  r.HeWeather6[0].daily_forecast[i].tmp_max + ",";
        }
        if (!string.IsNullOrEmpty(WEATHER_CATEGORIES))
        {
            WEATHER_CATEGORIES = WEATHER_CATEGORIES.Substring(0, WEATHER_CATEGORIES.Length - 1);
            WEATHER_DATA = WEATHER_DATA.Substring(0, WEATHER_DATA.Length - 1);
        }
    }

    protected void GetEnviromentData()
    {
        string url = "https://free-api.heweather.com/s6/air/now?location=auto_ip&key=0ee001fdc5c7401d82d9f683a93fb881";
        string ret = LigerRM.Common.WebRequestHelper.WebRequestPoster.Post(url);

        EnvObject r = JSONHelper.FromJson<EnvObject>(ret);
        ENV_DATA = r.HeWeather6[0].air_now_city.pm25 + "," + r.HeWeather6[0].air_now_city.pm10;
    }

}