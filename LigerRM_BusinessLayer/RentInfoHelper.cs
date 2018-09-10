using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LigerRM.Common;
using System.Collections;
using System.Net;
using System.Xml;
using System.IO;
using LigerRM_BusinessLayer;

namespace SignetInternet_BusinessLayer
{
    public class RentInfoHelper
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;

        public void UpdateRent(RentInfo rentInfo)
        {
            StringBuilder strSql = new StringBuilder();
            if (IsExistsRentNo(rentInfo.RentNo))
            {
                //Update
                strSql.Append("Update Rent_Rent set ");
                strSql.Append(" RDName='" + rentInfo.RDName + "',RSName='" + rentInfo.RSName + "',RRName='" + rentInfo.RRName + "',");
                strSql.Append(" RPSParentName = '" + rentInfo.RPSParentName + "', RPSName = '" + rentInfo.RPSName + "',RAddress='" + rentInfo.RAddress + "',RDoor='" + rentInfo.RDoor + "',");
                strSql.Append(" RTotalDoor='" + rentInfo.RTotalDoor + "',RRoomType='" + rentInfo.RRoomType + "',RDirection='" + rentInfo.RDirection + "',");
                strSql.Append(" RStructure='" + rentInfo.RStructure + "',RBuildingType='" + rentInfo.RBuildingType + "',RFloor='" + rentInfo.RFloor + "', ");
                strSql.Append(" RTotalFloor='" + rentInfo.RTotalFloor + "', RHouseAge='" + rentInfo.RHouseAge + "',RProperty='" + rentInfo.RProperty + "', ");
                strSql.Append(" RRentArea='" + rentInfo.RRentArea + "' ,RBuildArea='" + rentInfo.RBuildArea + "', ROwner='" + rentInfo.ROwner + "',");
                strSql.Append(" ROwnerTel='" + rentInfo.ROwnerTel + "' ,RIDCard='" + rentInfo.RIDCard + "', RLocationDescription='" + rentInfo.RLocationDescription + "',");
                strSql.Append(" RMapID='" + rentInfo.RMapID + "' ,RPSID='" + rentInfo.RPSID + "',");
                strSql.Append(" RModifiedBy='" + rentInfo.RModifiedBy + "',");
                strSql.Append(" RModifiedDate='" + rentInfo.RModifiedDate.Value.ToString("yyyy-MM-dd hh:mm:ss") + "',RRentType='"+rentInfo.RentType+"',ROwnType='"+rentInfo.OwnType+"'");
                strSql.Append(" where RentNo = '" + rentInfo.RentNo + "'");
                SysLogHelper.AddLog(rentInfo.RModifiedBy, "修改房源信息ID：" + rentInfo.RentNo, "修改-房源信息");
            }
            else
            {
                //Insert
                strSql.Append("Insert into Rent_Rent ([RentNO],[RDName],[RSName],[RRName],"+
                    "[RPSName],[RAddress],[RDoor],[RTotalDoor],"+
                    "[RRoomType],[RDirection],[RStructure],[RBuildingType]," +
                    "[RFloor] ,[RTotalFloor],[RHouseAge] ,[RProperty],"+
                    "[RRentArea],[RBuildArea],[ROwner],[ROwnerTel],"+
                    "[RIDCard],[RLocationDescription],[RMapID],[RPSID],"+
                    "[RCreatedBy],[RCreatedDate],[RModifiedBy],"+
                    "[RModifiedDate],[RPSParentName],[RRentType],[ROwntype],[IsAvailable],[IsObsoleted],[RentNumber]) values (");
                strSql.Append("'" + rentInfo.RentNo + "','" + rentInfo.RDName + "','" + rentInfo.RSName + "','" + rentInfo.RRName + "',");
                strSql.Append("'" + rentInfo.RPSName + "','" + rentInfo.RAddress + "','" + rentInfo.RDoor + "','" + rentInfo.RTotalDoor + "',");
                strSql.Append("'" + rentInfo.RRoomType + "','" + rentInfo.RDirection + "','" + rentInfo.RStructure + "','" + rentInfo.RBuildingType + "',");
                strSql.Append("'" + rentInfo.RFloor + "','" + rentInfo.RTotalFloor + "','" + rentInfo.RHouseAge + "','" + rentInfo.RProperty + "',");
                strSql.Append("'" + rentInfo.RRentArea + "','" + rentInfo.RBuildArea + "','" + rentInfo.ROwner + "','" + rentInfo.ROwnerTel + "',");
                strSql.Append("'" + rentInfo.RIDCard + "','" + rentInfo.RLocationDescription + "','" + rentInfo.RMapID + "','" + rentInfo.RPSID + "',");
                strSql.Append("'" + rentInfo.RCreatedBy + "','" + rentInfo.RCreatedDate.ToString("yyyy-MM-dd hh:mm:ss") + "','"+rentInfo.RCreatedBy+"',");
                strSql.Append("'" + rentInfo.RCreatedDate.ToString("yyyy-MM-dd hh:mm:ss") + "','" + rentInfo.RPSParentName + "','" + rentInfo.RentType + "','" + rentInfo.OwnType + "','" + rentInfo.IsAvailable + "','" + rentInfo.IsObsoleted + "','0'");
                strSql.Append(")");
                UpdateRentExternal(rentInfo);
                SysLogHelper.AddLog(rentInfo.RCreatedBy, "添加房源信息ID：" + rentInfo.RentNo, "添加-房源信息");

            }
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(strSql.ToString()));
            if (!string.IsNullOrEmpty(rentInfo.Longitude) && !string.IsNullOrEmpty(rentInfo.Latitude))
            {
                StringBuilder strSql1 = new StringBuilder();
                if (IsExistsMapInfo(rentInfo.RentNo))
                {
                    strSql1.Append("Update Rent_Map set Longitude='" + rentInfo.Longitude + "', Latitude='" + rentInfo.Latitude + "' where RentNO='" + rentInfo.RentNo + "'");
                }
                else
                {
                    strSql1.Append("Insert into Rent_Map values('" + rentInfo.RentNo + "', '" + rentInfo.Longitude + "', '" + rentInfo.Latitude + "')");
                }

                MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(strSql1.ToString()));
            }
        }

        public void UpdateRentExternal(RentInfo rentInfo)
        {
            string sql = "select * from Rent_External where rent_No='"+rentInfo.RentNo+"'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sql = "insert into Rent_External values ('" + rentInfo.RentNo + "','','"+rentInfo.RHouseID+"','"+rentInfo.RRentID+"','"+DateTime.Now.ToString()+"','" + rentInfo.ROwner + "','" + rentInfo.RIDCard + "','" + rentInfo.ROwnerTel + "')";
            }
            else
            {
                sql = "insert into Rent_External values ('"+rentInfo.RentNo+"','','','',null,'"+rentInfo.ROwner+"','"+rentInfo.RIDCard+"','"+rentInfo.ROwnerTel+"')";
                
            }
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void UpdateRentExternal(RentInfo rentInfo,bool isService)
        {
            string sql = "select * from Rent_External where rent_No='" + rentInfo.RentNo + "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sql = "update Rent_External set HZHouseID='"+rentInfo.RHouseID.ToString()+"',HZRentID='"+rentInfo.RRentID+"',HZUploadDate='"+DateTime.Now.ToString()+"',RentRealOwner='"+rentInfo.RRealOwner+"',RentRealOwnerID='"+rentInfo.RRealIDCard+"',RentRealOwnerPhone='"+rentInfo.RRealOwnerTel+"' where rent_No='" + rentInfo.RentNo + "'";
            }
            else
            {
                sql = "insert into Rent_External values ('" + rentInfo.RentNo + "','','" + rentInfo.RHouseID + "','" + rentInfo.RRentID + "','" + DateTime.Now.ToString() + "','" + rentInfo.ROwner + "','" + rentInfo.RIDCard + "','" + rentInfo.ROwnerTel + "')";
               
            }
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void ExcuteSql(string sql)
        {
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public bool IsExistsRentNo(string rentNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT 1 FROM Rent_Rent WITH(NOLOCK) WHERE RentNo=@rentNo");
            SqlParameter[] parameters = {
                                        new SqlParameter("@rentNo",SqlDbType.VarChar,50),
                                        };
            parameters[0].Value = rentNo;
            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //房源是否绑定锁
        public bool IsExistsRentNoBindLock(string rentNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT 1 FROM Rent_Locks WITH(NOLOCK) WHERE RentNo=@rentNo");
            SqlParameter[] parameters = {
                                        new SqlParameter("@rentNo",SqlDbType.VarChar,50),
                                        };
            parameters[0].Value = rentNo;
            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public void UpdateRentExternal(string rentNO, string desc)
        { 
            string sql = "delete from Rent_External where Rent_NO='"+rentNO+"'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            sql = "insert into Rent_External values ('"+rentNO+"','"+desc+"')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public bool IsOrderConfirmed(string id)
        {
            RentAttributeHelper helper = new RentAttributeHelper();
            DataTable dt = helper.GetRentAttribute(id);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["RRAStatus"].ToString() == ((int)RentAttributeHelper.AttributeStatus.NeedPay).ToString() || dt.Rows[0]["RRAStatus"].ToString() == ((int)RentAttributeHelper.AttributeStatus.Complete).ToString())
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool IsExistsMapInfo(string rentNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT 1 FROM Rent_Map WITH(NOLOCK) WHERE RentNo=@rentNo");
            SqlParameter[] parameters = {
                                        new SqlParameter("@rentNo",SqlDbType.VarChar,50),
                                        };
            parameters[0].Value = rentNo;
            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool IsExists(string rentNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT 1 FROM Rent_Rent rr WITH(NOLOCK) INNER JOIN Rent_RentAttribute rra WITH(NOLOCK) ON rr.RentNO =rra.RentNo   WHERE rr.RentNo=@rentNo");
            SqlParameter[] parameters = {
                                        new SqlParameter("@rentNo",SqlDbType.VarChar,12),
                                        };
            parameters[0].Value = rentNo;
            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool IsExistsSameAddressRent(string rdName,string rsName, string rrName, string rDoor)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select 1 from Rent_Rent where RDName=@rdName AND RSName=@rsName AND RRName=@rrName and RDoor=@rDoor");
            SqlParameter[] parameters = {
                                        new SqlParameter("@rdName",SqlDbType.NVarChar,50),
                                        new SqlParameter("@rsName",SqlDbType.NVarChar,50),
                                        new SqlParameter("@rrName",SqlDbType.NVarChar,50),
                                        new SqlParameter("@rDoor",SqlDbType.NVarChar,50),
                                        };
            parameters[0].Value = rdName;
            parameters[1].Value = rsName;
            parameters[2].Value = rrName;
            parameters[3].Value = rDoor;
            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public string GetRentNo(string RDID)
        {

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select LDShortName,LDName from Rent_District WITH (NOLOCK) where LDID='" + RDID + "'");
            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];

            string ldName = rentTable.Rows[0]["LDName"].ToString();
            string shortName = rentTable.Rows[0]["LDShortName"].ToString();

            StringBuilder sqlStrId = new StringBuilder();
            sqlStrId.Append("select top 1 substring(RentNo,charindex('-',RentNo)+1 ,len(RentNo)) as [LatestNo] from Rent_Rent where RDName='" + RDID + "' order by RID desc");
            DataTable rentTable1 = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStrId.ToString())).Tables[0];

            if (rentTable1 != null && rentTable1.Rows.Count > 0)
            {
                int maxRentNo = Convert.ToInt32(rentTable1.Rows[0]["LatestNo"]) + 1;
                return shortName + "-" + maxRentNo.ToString();
            }
                
            else
                return shortName + "-10000001";
        }

        public string GetRentsByCoordinate(string lat, string lon, string radios)
        {
            var list = new List<Hashtable>();
            string sql = "select rid,rentno,ROwner,ROwnerTel,RIDCard,RAddress,RDName,RRName,RRentTypeDesc,RLocationDescription,Latitude,Longitude,RentNumber as Status,RRentType,rFloor,rtotalfloor,rrentarea,rroomtypedesc, rdirectiondesc, RPropertyDesc from v_RentDetail_view where IsObsoleted = 0 order by RCreatedDate desc";
            DataSet ds = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sql));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
               
                if (row["Latitude"] != null && row["Longitude"] != null)
                {
                    double la, lo;
                   
                    if (double.TryParse(row["Latitude"].ToString(), out la) && double.TryParse(row["Longitude"].ToString(), out lo))
                    {

                        DataTable dt = ds.Tables[0].Clone();
                        double distance = GetDistance(double.Parse(lat), double.Parse(lon), double.Parse(row["Latitude"].ToString()), double.Parse(row["Longitude"].ToString()));
                        if (distance <= double.Parse(radios))
                        {
                            //retRows.Add(row);

                            var item = new Hashtable();
                         
                            for (var i = 0; i < dt.Columns.Count; i++)
                            {
                                var name = dt.Columns[i].ColumnName;
                                var value = row[i].ToString();
                                item[name] = value;
                               
                            }

                            if (IsExistsRedPackage(item["rentno"].ToString(), null))
                            {
                                item["IsRedPackage"] = "1";
                            }
                            else
                            {
                                item["IsRedPackage"] = "0";
                            }
                            list.Add(item);
                          
                        }
                    }
                    else
                    {
                        var item = new Hashtable();
                        DataTable dt = ds.Tables[0].Clone();
                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            var name = dt.Columns[i].ColumnName;
                            var value = row[i].ToString();
                            item[name] = value;
                        }
                        list.Add(item);
                      
                    }
                }
                else
                {
                    var item = new Hashtable();
                    DataTable dt = ds.Tables[0].Clone();
                    for (var i = 0; i < dt.Columns.Count; i++)
                    {
                        var name = dt.Columns[i].ColumnName;
                        var value = row[i].ToString();
                        item[name] = value;
                    }
                    list.Add(item);
                  
                }
            }

            return JSONHelper.ToJson(list);
        }

        public bool IsExistsRedPackage(string rentno, DateTime? checkDate)
        {
            DateTime checkTime = DateTime.Now;
            if (checkDate.HasValue)
                checkTime = checkDate.Value;
            string redsql = "select * from dbo.Sys_RedPackage where RedPackageObject='" + rentno + "' and RedPackageStartDate<='" + checkTime.ToString() + "' and RedPackageEndDate>'" + checkTime.ToString() + "' and RedPackageStatus='0'";
            DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(redsql)).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetRentsByCoordinatePopular(string lat, string lon, string radios)
        {
            var list = new List<Hashtable>();
            string sql = "select rid,rentno,ROwner,ROwnerTel,RIDCard,RAddress,RDName,RRName,RRentTypeDesc,RLocationDescription,RRentType,Latitude,Longitude,RentNumber as Status,rFloor,rtotalfloor,rrentarea,rroomtypedesc, rdirectiondesc, RPropertyDesc from v_RentDetail_view where IsObsoleted = 0 and rid in(380,451,419,417,375,452,379,363,418,365,377,366) order by RCreatedDate desc";
            DataSet ds = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sql));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["Latitude"] != null && row["Longitude"] != null)
                {
                    double la, lo;
                    if (double.TryParse(row["Latitude"].ToString(), out la) && double.TryParse(row["Longitude"].ToString(), out lo))
                    {

                        DataTable dt = ds.Tables[0].Clone();
                        double distance = GetDistance(double.Parse(lat), double.Parse(lon), double.Parse(row["Latitude"].ToString()), double.Parse(row["Longitude"].ToString()));
                        if (distance <= double.Parse(radios))
                        {
                            //retRows.Add(row);

                            var item = new Hashtable();

                            for (var i = 0; i < dt.Columns.Count; i++)
                            {
                                var name = dt.Columns[i].ColumnName;
                                var value = row[i].ToString();
                                item[name] = value;
                            }

                            if (IsExistsRedPackage(row["rentno"].ToString(), null))
                            {
                                item["IsRedPackage"] = "1";
                            }
                            else
                            {
                                item["IsRedPackage"] = "0";
                            }

                            list.Add(item);
                            if (list.Count == 10)
                            {
                                break;
                            }

                        }
                    }
                    else
                    {
                        var item = new Hashtable();
                        DataTable dt = ds.Tables[0].Clone();
                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            var name = dt.Columns[i].ColumnName;
                            var value = row[i].ToString();
                            item[name] = value;
                        }
                        list.Add(item);
                        if (list.Count == 10)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    var item = new Hashtable();
                    DataTable dt = ds.Tables[0].Clone();
                    for (var i = 0; i < dt.Columns.Count; i++)
                    {
                        var name = dt.Columns[i].ColumnName;
                        var value = row[i].ToString();
                        item[name] = value;
                    }
                    list.Add(item);
                    if (list.Count == 10)
                    {
                        break;
                    }
                }
            }
            ////查询符合地区的所有数据
            //string sqlArray = string.Empty;
            //for (int j = 0; j < list.Count; j++)
            //{
            //    if (j == (list.Count - 1))
            //    {
            //        sqlArray += "'" + list[j]["rentno"].ToString() + "'";
            //    }
            //    else
            //    {
            //        sqlArray += "'" + list[j]["rentno"].ToString() + "',";
            //    }
            //}
            //var arrayKayObject = new Hashtable();  //配凑Key=>value
            //if (!string.IsNullOrEmpty(sqlArray))
            //{
            //    //根据地区的房屋id获取该地区评分高的数据
            //    string sqlEvaluation = "SELECT top 10 RentNO, sum(count)/count(*) as count FROM (SELECT RentNO, (EvaluateItem0+EvaluateItem1+EvaluateItem2)/3 as count FROM v_Rent_Evaluation_view WHERE EvaluateType = 1 and RentNO in(" + sqlArray + ")) as a GROUP BY a.RentNO ORDER BY count DESC";
            //    DataSet dataEvaluation = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlEvaluation));
            //    foreach (DataRow row in dataEvaluation.Tables[0].Rows)
            //    {
            //        var name = row["RentNO"].ToString();
            //        var value = row["count"].ToString();
            //        arrayKayObject[name] = value;
            //    }
            //}
            ////筛选需要的数据
            //var jsonList = new List<Hashtable>();
            //for (int k = 0; k < list.Count; k++)
            //{
            //    string rentNo = list[k]["rentno"].ToString();
            //    //筛选key
            //    if (arrayKayObject.Contains(rentNo))
            //    {
            //        RentImageHelper helper = new RentImageHelper();
            //        string count = string.Empty;
            //        List<Hashtable> images = helper.GetRentImages(rentNo, out count);
            //        var item1 = new Hashtable();
            //        for (int q = 0; q < images.Count; q++)
            //        {
            //            list[k].Add("Image" + q, images[q]["ImagePath"].ToString());  //添加图片
            //        }
            //        list[k].Add("Evaluate", arrayKayObject[rentNo]);   //添加评分
            //        jsonList.Add(list[k]);
            //    }
            //}

            for (int j = 0; j < list.Count; j++)
            {
                string rentNo = list[j]["rentno"].ToString();
                RentImageHelper helper = new RentImageHelper();
                string count = string.Empty;
                List<Hashtable> images = helper.GetRentImages(rentNo, out count);
                var item1 = new Hashtable();
                for (int k = 0; k < images.Count; k++)
                {
                    list[j].Add("Image" + k, images[k]["ImagePath"].ToString());
                }
                //string sqlEvaluation = "select * from v_Rent_Evaluation_view where RentNO = '" + rentNo + "'";
                //DataSet dataEvaluation = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlEvaluation));
                //Double numAll = 0;
                //Int32 numberPeople = 0;
                //foreach (DataRow row in dataEvaluation.Tables[0].Rows)
                //{
                //    Double EvaluateItem0 = double.Parse(row["EvaluateItem0"].ToString());
                //    Double EvaluateItem1 = double.Parse(row["EvaluateItem1"].ToString());
                //    Double EvaluateItem2 = double.Parse(row["EvaluateItem2"].ToString());
                //    Double num = (EvaluateItem0 + EvaluateItem1 + EvaluateItem2) / 3;
                //    numAll += num;
                //    numberPeople++;
                //}
                //Double average = double.IsNaN(numAll / numberPeople) ? 0 : (numAll / numberPeople);
                //list[j].Add("Evaluate", average);
                int[] strArr1 = {0,1,2};
                bool exists1 = ((IList)strArr1).Contains(j);
                int[] strArr2 = {3,4,5,6};
                bool exists2 = ((IList)strArr2).Contains(j);
                int[] strArr3 = {7,8,9};
                bool exists3 = ((IList)strArr3).Contains(j);
                if (exists1)
                {
                    list[j].Add("Evaluate", 5.0);
                }
                else if (exists2)
                {
                    list[j].Add("Evaluate", 4.9);
                }
                else
                {
                    list[j].Add("Evaluate", 4.8);
                }
               
            }

            return JSONHelper.ToJson(list);
        }

        public DataTable GetRentsByStreet(string streetId)
        {
            string sql = "select * from v_RentDetail_view where IsObsoleted = 0 and RRNameID="+streetId+" order by RCreatedDate desc";
            return MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        }

        public int GetCount(string strSql)
        {
            object obj = MySQLHelper.ExecuteScalar(SqlConnString, MySQLHelper.CreateCommand(strSql));
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        private const double EARTH_RADIUS = 6378137;
        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns></returns>
        public double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }

        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }

        public string CreateVerifyCode(int maxInt)
        {
            string tempStr = string.Empty;
            Random ran = new Random();
            for (int i = 0; i < maxInt; i++)
            {
                tempStr += ran.Next(maxInt).ToString();
            }
            return tempStr;
        }

        public string CreateUserCode(int maxInt)
        {
            string tempStr = string.Empty;
            Random ran = new Random();
            return ran.Next(100000, 999999).ToString();
        }

        public void DeleteCorporation(string rentNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("delete from  Rent_Rent where RentNo='" + rentNo + "'");
            MySQLHelper.ExecuteNonQuery(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString()));
        }

        public DataTable dtStreet(string LDID)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@ldID",SqlDbType.Int,4),
                                        };
            parameters[0].Value = LDID;
            DataTable streetDataTable = SQLHelper.ExecuteDataTable("up_Rent_StreetSelectByLDID", parameters);
            if (streetDataTable != null && streetDataTable.Rows.Count > 0)
            {
                return streetDataTable;
            }
            else
                return null;
        }
        public DataTable dtRoad(string LDID,string LSID)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@ldID",SqlDbType.Int,4),
                                        new SqlParameter("@lsID",SqlDbType.Int,4),
                                        };
            parameters[0].Value = LDID;
            parameters[1].Value = LSID;
            DataTable roadDataTable = SQLHelper.ExecuteDataTable("up_Rent_RoadSelectByLDIDLSID", parameters);
            if (roadDataTable != null && roadDataTable.Rows.Count > 0)
            {
                return roadDataTable;
            }
            else
                return null;
        }

        public DataTable dtPoliceStation(string parentPSID)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@psParentID",SqlDbType.Int,4),
                                        };
            parameters[0].Value = parentPSID;
            DataTable policeStationDataTable = SQLHelper.ExecuteDataTable("up_Rent_PoliceStationSelectByParentID", parameters);
            if (policeStationDataTable != null && policeStationDataTable.Rows.Count > 0)
            {
                return policeStationDataTable;
            }
            else
                return null;
        }

        #region For report
        public DataTable GetStatisticTimeData(string category,string type, string year, string month, string day, string psName,string userId)
        {
            DataTable dataTable = null;

            SqlParameter[] parameters = {
            new SqlParameter("@statistictype", SqlDbType.VarChar, 50),
            new SqlParameter("@statisticyear", SqlDbType.VarChar, 50),
            new SqlParameter("@statisticmonth", SqlDbType.VarChar, 50),
            new SqlParameter("@statisticday", SqlDbType.VarChar, 50),
            new SqlParameter("@psname", SqlDbType.NVarChar, 50),
            new SqlParameter("@userId", SqlDbType.NVarChar, 50)
            };
            parameters[0].Value = type;
            parameters[1].Value = year;
            parameters[2].Value = month;
            parameters[3].Value = day;
            parameters[4].Value = psName;
            parameters[5].Value = userId;
            if (!string.IsNullOrEmpty(category)||category=="0")
                dataTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "up_RentReport_RentStatisticByPoliceStation", parameters)).Tables[0];
            else
                dataTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "up_RentReport_RentHouseStatisticByPoliceStation", parameters)).Tables[0];
            return dataTable;
        }

        public DataTable GetStatisticData(string category, string sDate, string eDate, string regDept,string userId)
        {
            DataTable dataTable = null;
            switch (category)
            {
                case "AllCorp":
                    SqlParameter[] parameters = {
                    new SqlParameter("@adt_from_date", SqlDbType.VarChar, 50),
                    new SqlParameter("@adt_to_date", SqlDbType.VarChar, 50),
                    new SqlParameter("@regDept", SqlDbType.VarChar, 50)
                    };
                    parameters[0].Value = sDate;
                    parameters[1].Value = eDate;
                    parameters[2].Value = regDept;
                    dataTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "up_PostInternet_PostStatisticAllByCorp", parameters)).Tables[0];
                    break;
                case "AllPoliceStation":
                    SqlParameter[] parameters1 = {
                    new SqlParameter("@adt_from_date", SqlDbType.VarChar, 50),
                    new SqlParameter("@adt_to_date", SqlDbType.VarChar, 50),
                    new SqlParameter("@psname", SqlDbType.VarChar, 50),
                    new SqlParameter("@userId", SqlDbType.VarChar, 50)
                    };
                    parameters1[0].Value = sDate;
                    parameters1[1].Value = eDate;
                    parameters1[2].Value = regDept;
                    parameters1[3].Value = userId;
                    dataTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "up_RentReport_RentInfoStatisticAllByPoliceStation", parameters1)).Tables[0];
                    break;

                case "AllPoliceHouse":
                    SqlParameter[] parameters2 = {
                    new SqlParameter("@adt_from_date", SqlDbType.VarChar, 50),
                    new SqlParameter("@adt_to_date", SqlDbType.VarChar, 50),
                    new SqlParameter("@psname", SqlDbType.VarChar, 50),
                    new SqlParameter("@userId", SqlDbType.VarChar, 50)
                    };
                    parameters2[0].Value = sDate;
                    parameters2[1].Value = eDate;
                    parameters2[2].Value = regDept;
                    parameters2[3].Value = userId;
                    dataTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "up_RentReport_RentInfoStatisticAllByPoliceHouseStation", parameters2)).Tables[0];
                    break;
            }
            return dataTable;
        }

        public DataTable GetDataTable(string sql)
        {
            SqlParameter[] parameters = {
                                        };
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sql, parameters)).Tables[0];
        }

        #endregion

        public bool ValidateLogin(string username, string password,string userType)
        {
            string tempPass = Encrypt.DESEncrypt(password);
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from cf_user WITH (NOLOCK) where LoginName='" + username + "' and LoginPassword='" + tempPass+"'");
            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString())).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public string GetJSONInfo(string sql)
        {
            var reader = MySQLHelper.ExecuteReader(SqlConnString, MySQLHelper.CreateCommand(sql));
            return JSONHelper.ToJson( JSONHelper.DbReaderToHash(reader));
        }

        public string GetJSONInfo(SqlDataReader reader)
        {
            return JSONHelper.ToJson(JSONHelper.DbReaderToHash(reader));
        }

        public SqlDataReader  GetList(int PageSize, int PageIndex, string tableName, string key, string strWhere, string Fields, string SortStr, bool IsRetCount)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.VarChar, 500),
					new SqlParameter("@Fields", SqlDbType.VarChar, 255),
					new SqlParameter("@SortStr", SqlDbType.VarChar, 255),
					new SqlParameter("@Pkey", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsRetCount", SqlDbType.Bit),
					new SqlParameter("@WhereStr", SqlDbType.VarChar,3000),
					};
            parameters[0].Value = tableName;
            parameters[1].Value = Fields;
            parameters[2].Value = SortStr;
            parameters[3].Value = key;
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = IsRetCount;
            parameters[7].Value = strWhere;
            return MySQLHelper.ExecuteReader(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "UP_GetRecordByPageOrder", parameters));
        }

        public DataTable GetList(string tableName, string key, string strWhere, string Fields, string SortStr, bool IsRetCount)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.VarChar, 500),
					new SqlParameter("@Fields", SqlDbType.VarChar, 255),
					new SqlParameter("@SortStr", SqlDbType.VarChar, 255),
					new SqlParameter("@Pkey", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsRetCount", SqlDbType.Bit),
					new SqlParameter("@WhereStr", SqlDbType.VarChar,3000),
					};
            parameters[0].Value = tableName;
            parameters[1].Value = Fields;
            parameters[2].Value = SortStr;
            parameters[3].Value = key;
            parameters[4].Value = 800000;
            parameters[5].Value = 1;
            parameters[6].Value = IsRetCount;
            parameters[7].Value = strWhere;
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(CommandType.StoredProcedure, "UP_GetRecordByPageOrder", parameters)).Tables[0];
        }

        public bool IsExistsLoginName(string loginName)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT 1 FROM cf_user where LoginName=@loginName");
            SqlParameter[] parameters = {
                                        new SqlParameter("@loginName",SqlDbType.VarChar,50),
                                        };
            parameters[0].Value = loginName;
            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public DataTable GetScattergramData(string startDate, string enddate, string psname,string userId)
        {
            string sql = string.Empty;
            if (int.Parse(userId)>1)
                sql = "select * from v_RentDetail_view inner join Rent_user_dept_relationship u on u.t_ad_reg_dept_id = Region and u.t_wu_user_id ="+userId+" where RCreatedDate>='" + startDate + "' and RCreatedDate<'" + enddate + "'";
            else
                sql = "select * from v_RentDetail_view where RCreatedDate>='" + startDate + "' and RCreatedDate<'" + enddate + "'";

            if (!string.IsNullOrEmpty(psname))
            {
                sql += " and RPSParentName='" + psname + "'";
            }
            SqlParameter[] parameters = {
                                        };
            return MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sql, parameters)).Tables[0];
        }

        public string OverString(string source)
        {
            if (string.IsNullOrEmpty(source) || source.Length <= 3)
                return "***********";
            else
            {
                int len = source.Length;
                if (len <= 6)
                    return source.Substring(0, 3).PadRight(len, '*');
                else
                    return source.Substring(0, 3).PadRight(len - 3, '*') + source.Substring(len - 3, 3);
            }
        }

        public string GetLocationInfo(string address, string city)
        {
            string tempAddress = System.Web.HttpUtility.UrlEncode(address).ToUpper();
            string tempCity = System.Web.HttpUtility.UrlEncode(city).ToUpper();

            //http://api.map.baidu.com/geocoder/v2/?address=北京市海淀区上地十街10号&output=json&ak=OG00ESUZvs88soSk5aDuxxw1R8r5NGtn&callback=showLocation //GET请求
            string url = "http://api.map.baidu.com/geocoder/v2/?address=" + tempAddress + "&ak=OG00ESUZvs88soSk5aDuxxw1R8r5NGtn";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            XmlDocument xmlDoc = new XmlDocument();
            string sendData = xmlDoc.InnerXml;
            byte[] byteArray = Encoding.Default.GetBytes(sendData);

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.GetEncoding("utf-8"));
            string responseXml = reader.ReadToEnd();
            return responseXml;

        }

        public string GetNewRentsByCoordinate(string lat, string lon, string radios, string startdate, string enddate)
        {
            var list = new List<Hashtable>();
            //筛选所有的出租的房屋
            string sqlR = "select distinct RentNo from dbo.v_RentHistory_view where  IsExpired='0' and rrastatus not in ('5','9','8','7','11') and ((RRAEndDate >'" + enddate + "' and RRAStartDate<='" + enddate + "') or ('" + startdate + "'>=RRAStartDate and '" + startdate + "'<RRAEndDate) or ('" + startdate + "'<=RRAStartDate and '" + enddate + "'>=RRAEndDate))";
            DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlR)).Tables[0];
            string dateSql = string.Empty;
            foreach (DataRow row in dt1.Rows)
            {
                dateSql += "'" + row["RentNo"].ToString() + "',";
            }
            dateSql = " RentNo not in (" + dateSql + "'')";
            string sql = "select rid,rentno,ROwner,RHouseAge,ROwnerTel,RIDCard,RAddress,RDName,RRName,RRentTypeDesc,RLocationDescription,Latitude,Longitude,RentNumber as Status,RRentType,rFloor,rtotalfloor,rrentarea,rroomtypedesc, rdirectiondesc, RPropertyDesc from v_RentDetail_view where IsObsoleted = 0 and " + dateSql + "order by RCreatedDate desc";
            DataSet ds = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sql));
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                if (row["Latitude"] != null && row["Longitude"] != null)
                {
                    double la, lo;

                    if (double.TryParse(row["Latitude"].ToString(), out la) && double.TryParse(row["Longitude"].ToString(), out lo))
                    {

                        DataTable dt = ds.Tables[0].Clone();
                        if (lat == string.Empty && lon == string.Empty) //经纬度都为空   返回所有
                        {

                            var item = new Hashtable();

                            for (var i = 0; i < dt.Columns.Count; i++)
                            {
                                var name = dt.Columns[i].ColumnName;
                                var value = row[i].ToString();
                                item[name] = value;

                            }

                            if (IsExistsRedPackage(item["rentno"].ToString(), null))
                            {
                                item["IsRedPackage"] = "1";
                            }
                            else
                            {
                                item["IsRedPackage"] = "0";
                            }
                            list.Add(item);
                        }
                        else   // 经纬度不为空  判断距离
                        {
                            double distance = GetDistance(double.Parse(lat), double.Parse(lon), double.Parse(row["Latitude"].ToString()), double.Parse(row["Longitude"].ToString()));
                            if (distance <= double.Parse(radios))
                            {
                                //retRows.Add(row);

                                var item = new Hashtable();

                                for (var i = 0; i < dt.Columns.Count; i++)
                                {
                                    var name = dt.Columns[i].ColumnName;
                                    var value = row[i].ToString();
                                    item[name] = value;

                                }

                                if (IsExistsRedPackage(item["rentno"].ToString(), null))
                                {
                                    item["IsRedPackage"] = "1";
                                }
                                else
                                {
                                    item["IsRedPackage"] = "0";
                                }
                                list.Add(item);

                            }
                        }
                    }
                    else
                    {
                        var item = new Hashtable();
                        DataTable dt = ds.Tables[0].Clone();
                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            var name = dt.Columns[i].ColumnName;
                            var value = row[i].ToString();
                            item[name] = value;
                        }
                        list.Add(item);

                    }
                }
                else
                {
                    var item = new Hashtable();
                    DataTable dt = ds.Tables[0].Clone();
                    for (var i = 0; i < dt.Columns.Count; i++)
                    {
                        var name = dt.Columns[i].ColumnName;
                        var value = row[i].ToString();
                        item[name] = value;
                    }
                    list.Add(item);

                }
            }

            return JSONHelper.ToJson(list);
        }

    }
}
