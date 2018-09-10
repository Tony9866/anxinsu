using System;
using System.Web;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace SignetInternet_BusinessLayer
{
    /// <summary>
    /// 字符处理
    /// </summary>
    public class StringDeal
    {
        private static Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);

        /// <summary>
        /// 得到正则编译参数设置
        /// </summary>
        /// <returns>参数设置</returns>
        public static RegexOptions GetRegexCompiledOptions()
        {
#if NET1
            return RegexOptions.Compiled;
#else
            return RegexOptions.None;
#endif
        }

        #region 获取GUID编号
        /// <summary>
        /// 获取GUID编号
        /// </summary>
        /// <returns>32位字符串</returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        #endregion

        #region 获取时间编号
        /// <summary>
        /// 获取时间编号
        /// </summary>
        /// <returns>17位字符串</returns>
        public static string GetNow()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion

        #region 返回字符串真实长度
        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns>字符长度</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }
        #endregion

        #region 类型转换
        /// <summary>
        /// object型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool ToBool(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                string temp = obj.ToString();

                if (temp == "1" || temp.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// object型转换为int型
        /// </summary>
        /// <param name="obj">要转换的字符串</param>
        /// <returns>返回转换后的类型结果</returns>
        public static int ToInt(object obj)
        {
            try
            {
                return int.Parse(obj.ToString());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// object型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的float类型结果</returns>
        public static float ToFloat(object obj)
        {
            if (obj == null)
                return 0.00F;
            else
            {
                try
                {
                    return float.Parse(obj.ToString());
                }
                catch
                {
                    return 0.00F;
                }
            }
        }

        /// <summary>
        /// bool型转换为int型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int BoolToInt(object obj)
        {
            if (ToBool(obj))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 字符串处理
        /// <summary>
        /// 格式化Html字符
        /// </summary>
        /// <param name="obj">替换前字符</param>
        /// <returns></returns>
        public static string StrFormat(object obj)
        {
            string str = "";
            try
            {
                str = obj.ToString();
            }
            catch { }
            string str2;

            if (str.Length == 0)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("<", "&lt;");
                str = str.Replace(">", "&gt;");
                str = str.Replace("\"", "&quot;");
                str = str.Replace('\n'.ToString(), "<br>");
                str = str.Replace("\r\n", "<br />");
                str2 = str;
            }
            return str2;
        }

        public static string Filter(string sInput)
        {
            if (sInput == null || sInput == "")
                return "";
            string sInput1 = sInput.ToLower();
            string output = sInput;
            string pattern = @"*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
            {
                throw new Exception("字符串中含有非法字符!");
            }
            else
            {
                output = output.Replace("'", "");
            }
            return output;
        }




        public static string ReplaceSql(object Val)
        {
            string str = "";
            try
            {
                str = Val.ToString();
            }
            catch { }
            if (!String.IsNullOrEmpty(str))
            {
                str = Regex.Replace(str, @"'", "''");
            }
            else
            {
                return str = "";
            }
            return str;
        }

        /// <summary>
        /// 进行指定的替换(脏字过滤)
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <param name="bantext">脏话（我日=我想）</param>
        /// <returns></returns>
        public static string StrFilter(string str, string bantext)
        {
            string text1 = "";
            string text2 = "";
            string[] textArray1 = SplitString(bantext, "\r\n");
            for (int num1 = 0; num1 < textArray1.Length; num1++)
            {
                text1 = textArray1[num1].Substring(0, textArray1[num1].IndexOf("="));
                text2 = textArray1[num1].Substring(textArray1[num1].IndexOf("=") + 1);
                str = str.Replace(text1, text2);
            }
            return str;
        }

        /// <summary>
        /// 移除Html标记
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveHtml(object obj)
        {
            string content = obj.ToString();
            string regexstr = @"<[^>]*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 移除Html标记
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string TextToHtml(object obj)
        {
            string content = obj.ToString();

            return content.Replace("\n", "<br/>");
        }

        /// <summary>
        /// 过滤HTML中的不安全标签
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveUnsafeHtml(object obj)
        {
            string content = obj.ToString();
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }

        /// <summary>
        /// 将全角数字转换为数字
        /// </summary>
        /// <param name="SBCCase"></param>
        /// <returns></returns>
        public static string SBCCaseToNumberic(object obj)
        {
            string SBCCase = obj.ToString();
            char[] c = SBCCase.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            return new string(c);
        }
        #endregion

        #region 获取文件扩展名
        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetFileExtName(object obj)
        {
            string filename = obj.ToString();
            string[] array = filename.Trim().Split('.');
            Array.Reverse(array);
            return array[0].ToString();
        }
        #endregion

        #region 判断某文件扩展名在数组中是否存在
        /// <summary>
        /// 判断某文件扩展名在数组中是否存在
        /// </summary>
        /// <param name="Arry"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static bool GetExtNameIsArry(string[] Arry, object FileName)
        {
            bool temp = false;
            foreach (string x in Arry)
            {
                if (x.ToLower() == GetFileExtName(FileName).ToLower())
                {
                    temp = true;
                }
            }
            return temp;
        }
        #endregion

        #region 判断指定字符串在指定字符串数组中的位置
        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else
                {
                    if (strSearch == stringArray[i])
                    {
                        return i;
                    }
                }

            }
            return -1;
        }


        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>		
        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }
        #endregion

        #region 判断指定字符串是否属于指定字符串数组中的一个元素
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">字符串数组</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }
        #endregion

        #region 清除给定字符串中的回车及换行符
        /// <summary>
        /// 清除给定字符串中的回车及换行符
        /// </summary>
        /// <param name="str">要清除的字符串</param>
        /// <returns>清除后返回的字符串</returns>
        public static string ClearBR(string str)
        {
            Match m = null;
            for (m = RegexBr.Match(str); m.Success; m = m.NextMatch())
            {
                str = str.Replace(m.Groups[0].ToString(), "");
            }
            return str;
        }
        #endregion

        #region 从字符串的指定位置截取指定长度的子字符串
        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }


                if (startIndex > str.Length)
                {
                    return "";
                }


            }
            else
            {
                if (length < 0)
                {
                    return "";
                }
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            if (str.Length - startIndex < length)
            {
                length = str.Length - startIndex;
            }

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 从字符串的指定位置开始截取到字符串结尾的字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }
        #endregion

        #region 取指定长度的字符串
        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="obj">要检查的字符串</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(object obj, int p_Length, string p_TailString)
        {
            return GetSubString(StrFormat(obj), 0, p_Length, p_TailString);
        }

        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="obj">要检查的字符串</param>
        /// <param name="p_StartIndex">起始位置</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(object obj, int p_StartIndex, int p_Length, string p_TailString)
        {
            string p_SrcString = obj.ToString();
            string myResult = p_SrcString;

            Byte[] bComments = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {    //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    //if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") || System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
                    //当截取的起始位置超出字段串长度时
                    if (p_StartIndex >= p_SrcString.Length)
                    {
                        return "";
                    }
                    else
                    {
                        return p_SrcString.Substring(p_StartIndex,
                                                       ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                    }
                }
            }


            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);

                //当字符串长度大于起始位置
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;

                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {   //当不在有效范围内时,只取到字符串的结尾

                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }



                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {

                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                            {
                                nFlag = 1;
                            }
                        }
                        else
                        {
                            nFlag = 0;
                        }

                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                    {
                        nRealLength = p_Length + 1;
                    }

                    bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);

                    myResult = Encoding.Default.GetString(bsResult);

                    myResult = myResult + p_TailString;
                }
            }

            return myResult;
        }
        #endregion

        #region 分割字符串
        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] SplitString(object obj, string strSplit)
        {
            string strContent = obj.ToString();
            if (!String.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                {
                    string[] tmp = { strContent };
                    return tmp;
                }
                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
            {
                return new string[0] { };
            }
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <returns></returns>
        public static string[] SplitString(object strContent, string strSplit, bool ignoreRepeatItem)
        {
            return SplitString(strContent, strSplit, ignoreRepeatItem, 0);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="count">提取多少个字符串</param>
        /// <returns></returns>
        public static string[] SplitString(object strContent, string strSplit, int count)
        {
            string[] result = new string[count];

            string[] splited = SplitString(strContent, strSplit);

            for (int i = 0; i < count; i++)
            {
                if (i < splited.Length)
                    result[i] = splited[i];
                else
                    result[i] = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] SplitString(object strContent, string strSplit, bool ignoreRepeatItem, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            return ignoreRepeatItem ? DistinctStringArray(result, maxElementLength) : result;
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="maxElementLength">单个元素最小长度</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] SplitString(object strContent, string strSplit, bool ignoreRepeatItem, int minElementLength, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            if (ignoreRepeatItem)
            {
                result = DistinctStringArray(result);
            }
            return PadStringArray(result, minElementLength, maxElementLength);
        }
        #endregion

        #region 合并字符
        /// <summary>
        /// 合并字符
        /// </summary>
        /// <param name="source">要合并的源字符串</param>
        /// <param name="target">要被合并到的目的字符串</param>
        /// <param name="mergechar">合并符</param>
        /// <returns>合并到的目的字符串</returns>
        public static string MergeString(string source, string target)
        {
            return MergeString(source, target, ",");
        }

        /// <summary>
        /// 合并字符
        /// </summary>
        /// <param name="source">要合并的源字符串</param>
        /// <param name="target">要被合并到的目的字符串</param>
        /// <param name="mergechar">合并符</param>
        /// <returns>并到字符串</returns>
        public static string MergeString(string source, string target, string mergechar)
        {
            if (String.IsNullOrEmpty(target))
            {
                target = source;
            }
            else
            {
                target += mergechar + source;
            }
            return target;
        }
        #endregion

        #region 清除字符串数组中的重复项
        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <param name="maxElementLength">字符串数组中单个元素的最大长度</param>
        /// <returns></returns>
        public static string[] DistinctStringArray(string[] strArray, int maxElementLength)
        {
            Hashtable h = new Hashtable();

            foreach (string s in strArray)
            {
                string k = s;
                if (maxElementLength > 0 && k.Length > maxElementLength)
                {
                    k = k.Substring(0, maxElementLength);
                }
                h[k.Trim()] = s;
            }

            string[] result = new string[h.Count];

            h.Keys.CopyTo(result, 0);

            return result;
        }

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <returns></returns>
        public static string[] DistinctStringArray(string[] strArray)
        {
            return DistinctStringArray(strArray, 0);
        }
        #endregion

        #region 返回URL中结尾的文件名
        /// <summary>
        /// 返回URL中结尾的文件名
        /// </summary>
        /// <param name="obj">URL地址</param>
        /// <returns></returns>
        public static string GetFilename(object obj)
        {
            string url = obj.ToString();
            if (url == null)
            {
                return "";
            }
            string[] strs1 = url.Split(new char[] { '/' });
            return strs1[strs1.Length - 1].Split(new char[] { '?' })[0];
        }
        #endregion

        #region 获得当前绝对路径
        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        #endregion

        #region 获取指定格式的日期时间
        /// <summary>
        /// 获取指定格式的日期时间
        /// </summary>
        /// <param name="datetimestr">日期时间</param>
        /// <param name="replacestr">格式</param>
        /// <returns></returns>
        public static string GetDateTime(object datetimestr, string replacestr)
        {
            try
            {
                DateTime mytime = Convert.ToDateTime(datetimestr.ToString());
                return mytime.ToString(replacestr);
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 过滤字符串数组中每个元素为合适的大小
        /// <summary>
        /// 过滤字符串数组中每个元素为合适的大小
        /// 当长度小于minLength时，忽略掉,-1为不限制最小长度
        /// 当长度大于maxLength时，取其前maxLength位
        /// 如果数组中有null元素，会被忽略掉
        /// </summary>
        /// <param name="minLength">单个元素最小长度</param>
        /// <param name="maxLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] PadStringArray(string[] strArray, int minLength, int maxLength)
        {
            if (minLength > maxLength)
            {
                int t = maxLength;
                maxLength = minLength;
                minLength = t;
            }

            int iMiniStringCount = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (minLength > -1 && strArray[i].Length < minLength)
                {
                    strArray[i] = null;
                    continue;
                }
                if (strArray[i].Length > maxLength)
                {
                    strArray[i] = strArray[i].Substring(0, maxLength);
                }
                iMiniStringCount++;
            }

            string[] result = new string[iMiniStringCount];
            for (int i = 0, j = 0; i < strArray.Length && j < result.Length; i++)
            {
                if (strArray[i] != null && strArray[i] != string.Empty)
                {
                    result[j] = strArray[i];
                    j++;
                }
            }


            return result;
        }
        #endregion

        #region 转换长文件名为短文件名
        /// <summary>
        /// 转换长文件名为短文件名
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="repstring"></param>
        /// <param name="leftnum"></param>
        /// <param name="rightnum"></param>
        /// <param name="charnum"></param>
        /// <returns></returns>
        public static string ConvertSimpleFileName(string fullname, string repstring, int leftnum, int rightnum, int charnum)
        {
            string simplefilename = "", leftstring = "", rightstring = "", filename = "";

            string extname = GetFileExtName(fullname);
            if (extname == "" || extname == null)
            {

                throw new Exception("字符串不含有扩展名信息");
            }
            int filelength = 0, dotindex = 0;

            dotindex = fullname.LastIndexOf('.');
            filename = fullname.Substring(0, dotindex);
            filelength = filename.Length;
            if (dotindex > charnum)
            {
                leftstring = filename.Substring(0, leftnum);
                rightstring = filename.Substring(filelength - rightnum, rightnum);
                if (repstring == "" || repstring == null)
                {
                    simplefilename = leftstring + rightstring + "." + extname;
                }
                else
                {
                    simplefilename = leftstring + repstring + rightstring + "." + extname;
                }
            }
            else
            {

                simplefilename = fullname;
            }
            return simplefilename;

        }
        #endregion




        #region alter
        /// <summary>
        /// 输出javascript alter信息，返回上页
        /// </summary>
        /// <param name="str"></param>
        public static void Alter(string str)
        {
            HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>alert('" + str + "');history.back();</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 输出javascript alter信息，转向指定URL
        /// </summary>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public static void Alter(string str, string url)
        {
            HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>alert('" + str + "');location.href='" + url + "';</script>");
            HttpContext.Current.Response.End();
        }
        #endregion



        #region 获取操作

        //判断信息当前备案状态
        public static string GetLock(object isLock, string text)
        {
            if (ToBool(isLock) == false)
            {
                return "<span title=\"锁定此" + text + "\">解锁</span>";
            }
            else
            {
                return "<span style=\"color:red\" title=\"解锁此" + text + "\">锁定</span>";
            }
        }

        //判断信息当前置顶状态
        public static string GetTop(bool isTop, string text)
        {
            if (ToBool(isTop) == false)
            {
                return "<span title=\"设置此" + text + "置顶\">正常</span>";
            }
            else
            {
                return "<span style=\"color:red\" title=\"撤消此" + text + "置顶\">置顶</span>";
            }
        }

        //判断复选框是否checked/selected
        public static string GetChecked(object val1, object val2)
        {
            if (StrFormat(val1) == StrFormat(val2))
            {
                return " checked=\"checked\"";
            }
            else
            {
                return "";
            }
        }

        public static string GetSelected(object val1, object val2)
        {
            if (StrFormat(val1) == StrFormat(val2))
            {
                return " selected=\"selected\"";
            }
            else
            {
                return "";
            }
        }

        public static string GetSelected(object Arry, char Cut, object val)
        {
            string str = StrFormat(Arry);
            string Results = "";
            if (!String.IsNullOrEmpty(str))
            {
                string[] Arrary = str.Split(Cut);
                for (int x = 0; x < Arrary.Length; x++)
                {
                    if (StrFormat(val) == Arrary[x])
                    {
                        Results = " selected=\"selected\"";
                    }
                }
            }
            return Results;
        }

        public static string GetYesOrNo(object obj)
        {
            if (ToBool(obj))
            {
                return "<img src=\"../Skin/01/ico/yes.gif\" />";
            }
            else
            {
                return "<img src=\"../Skin/01/ico/no.gif\" />";
            }
        }

        //根据给定BOOL值，如果为真返回字符串
        public static string GetTrueOfStr(object obj, string str)
        {
            if (ToBool(obj))
            {
                return str;
            }
            else
            {
                return "";
            }
        }

        //根据给定BOOL值，如果为假返回字符串
        public static string GetFalseOfStr(object obj, string str)
        {
            if (!ToBool(obj))
            {
                return str;
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
