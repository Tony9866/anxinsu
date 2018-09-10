using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///WeatherInfo 的摘要说明
/// </summary>
public class Basic
{
    public string cid { get; set; }
    public string location { get; set; }
    public string parent_city { get; set; }
    public string admin_area { get; set; }
    public string cnty { get; set; }
    public string lat { get; set; }
    public string lon { get; set; }
    public string tz { get; set; }
}

public class Update
{
    public string loc { get; set; }
    public string utc { get; set; }
}

public class Daily_forecast
{
    public string cond_code_d { get; set; }
    public string cond_code_n { get; set; }
    public string cond_txt_d { get; set; }
    public string cond_txt_n { get; set; }
    public string date { get; set; }
    public string hum { get; set; }
    public string mr { get; set; }
    public string ms { get; set; }
    public string pcpn { get; set; }
    public string pop { get; set; }
    public string pres { get; set; }
    public string sr { get; set; }
    public string ss { get; set; }
    public string tmp_max { get; set; }
    public string tmp_min { get; set; }
    public string uv_index { get; set; }
    public string vis { get; set; }
    public string wind_deg { get; set; }
    public string wind_dir { get; set; }
    public string wind_sc { get; set; }
    public string wind_spd { get; set; }
}

public class Air_now_city
{
    public string aqi { get; set; }
    public string qlty { get; set; }
    public string main { get; set; }
    public string pm25 { get; set; }
    public string pm10 { get; set; }
    public string no2 { get; set; }
    public string so2 { get; set; }
    public string co { get; set; }
    public string o3 { get; set; }
    public string pub_time { get; set; }
}

public class Air_now_station
{
    public string air_sta { get; set; }
    public string aqi { get; set; }
    public string asid { get; set; }
    public string co { get; set; }
    public string lat { get; set; }
    public string lon { get; set; }
    public string main { get; set; }
    public string no2 { get; set; }
    public string o3 { get; set; }
    public string pm10 { get; set; }
    public string pm25 { get; set; }
    public string pub_time { get; set; }
    public string qlty { get; set; }
    public string so2 { get; set; }
}

public class HeWeather6
{
    public Basic basic { get; set; }
    public Update update { get; set; }
    public string status { get; set; }
    public List<Daily_forecast> daily_forecast { get; set; }
}

public class RootObject
{
    public List<HeWeather6> HeWeather6 { get; set; }
}

public class HeWeather7
{
    public Basic basic { get; set; }
    public Update update { get; set; }
    public string status { get; set; }
    public Air_now_city air_now_city { get; set; }
    public List<Air_now_station> air_now_station { get; set; }
}

public class EnvObject
{
    public List<HeWeather7> HeWeather6 { get; set; }
}