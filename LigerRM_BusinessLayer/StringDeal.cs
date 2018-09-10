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
    /// �ַ�����
    /// </summary>
    public class StringDeal
    {
        private static Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);

        /// <summary>
        /// �õ���������������
        /// </summary>
        /// <returns>��������</returns>
        public static RegexOptions GetRegexCompiledOptions()
        {
#if NET1
            return RegexOptions.Compiled;
#else
            return RegexOptions.None;
#endif
        }

        #region ��ȡGUID���
        /// <summary>
        /// ��ȡGUID���
        /// </summary>
        /// <returns>32λ�ַ���</returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        #endregion

        #region ��ȡʱ����
        /// <summary>
        /// ��ȡʱ����
        /// </summary>
        /// <returns>17λ�ַ���</returns>
        public static string GetNow()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion

        #region �����ַ�����ʵ����
        /// <summary>
        /// �����ַ�����ʵ����, 1�����ֳ���Ϊ2
        /// </summary>
        /// <returns>�ַ�����</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }
        #endregion

        #region ����ת��
        /// <summary>
        /// object��ת��Ϊbool��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����bool���ͽ��</returns>
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
        /// object��ת��Ϊint��
        /// </summary>
        /// <param name="obj">Ҫת�����ַ���</param>
        /// <returns>����ת��������ͽ��</returns>
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
        /// object��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����float���ͽ��</returns>
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
        /// bool��ת��Ϊint��
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

        #region �ַ�������
        /// <summary>
        /// ��ʽ��Html�ַ�
        /// </summary>
        /// <param name="obj">�滻ǰ�ַ�</param>
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
                throw new Exception("�ַ����к��зǷ��ַ�!");
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
        /// ����ָ�����滻(���ֹ���)
        /// </summary>
        /// <param name="str">Ҫ�滻���ַ���</param>
        /// <param name="bantext">�໰������=���룩</param>
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
        /// �Ƴ�Html���
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
        /// �Ƴ�Html���
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string TextToHtml(object obj)
        {
            string content = obj.ToString();

            return content.Replace("\n", "<br/>");
        }

        /// <summary>
        /// ����HTML�еĲ���ȫ��ǩ
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
        /// ��ȫ������ת��Ϊ����
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

        #region ��ȡ�ļ���չ��
        /// <summary>
        /// ��ȡ�ļ���չ��
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

        #region �ж�ĳ�ļ���չ�����������Ƿ����
        /// <summary>
        /// �ж�ĳ�ļ���չ�����������Ƿ����
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

        #region �ж�ָ���ַ�����ָ���ַ��������е�λ��
        /// <summary>
        /// �ж�ָ���ַ�����ָ���ַ��������е�λ��
        /// </summary>
        /// <param name="strSearch">�ַ���</param>
        /// <param name="stringArray">�ַ�������</param>
        /// <param name="caseInsensetive">�Ƿ����ִ�Сд, trueΪ������, falseΪ����</param>
        /// <returns>�ַ�����ָ���ַ��������е�λ��, �粻�����򷵻�-1</returns>
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
        /// �ж�ָ���ַ�����ָ���ַ��������е�λ��
        /// </summary>
        /// <param name="strSearch">�ַ���</param>
        /// <param name="stringArray">�ַ�������</param>
        /// <returns>�ַ�����ָ���ַ��������е�λ��, �粻�����򷵻�-1</returns>		
        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }
        #endregion

        #region �ж�ָ���ַ����Ƿ�����ָ���ַ��������е�һ��Ԫ��
        /// <summary>
        /// �ж�ָ���ַ����Ƿ�����ָ���ַ��������е�һ��Ԫ��
        /// </summary>
        /// <param name="strSearch">�ַ���</param>
        /// <param name="stringArray">�ַ�������</param>
        /// <param name="caseInsensetive">�Ƿ����ִ�Сд, trueΪ������, falseΪ����</param>
        /// <returns>�жϽ��</returns>
        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }

        /// <summary>
        /// �ж�ָ���ַ����Ƿ�����ָ���ַ��������е�һ��Ԫ��
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="stringarray">�ַ�������</param>
        /// <returns>�жϽ��</returns>
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        /// <summary>
        /// �ж�ָ���ַ����Ƿ�����ָ���ַ��������е�һ��Ԫ��
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="stringarray">�ڲ��Զ��ŷָ�ʵ��ַ���</param>
        /// <returns>�жϽ��</returns>
        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }

        /// <summary>
        /// �ж�ָ���ַ����Ƿ�����ָ���ַ��������е�һ��Ԫ��
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="stringarray">�ڲ��Զ��ŷָ�ʵ��ַ���</param>
        /// <param name="strsplit">�ָ��ַ���</param>
        /// <returns>�жϽ��</returns>
        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }

        /// <summary>
        /// �ж�ָ���ַ����Ƿ�����ָ���ַ��������е�һ��Ԫ��
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="stringarray">�ڲ��Զ��ŷָ�ʵ��ַ���</param>
        /// <param name="strsplit">�ָ��ַ���</param>
        /// <param name="caseInsensetive">�Ƿ����ִ�Сд, trueΪ������, falseΪ����</param>
        /// <returns>�жϽ��</returns>
        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }
        #endregion

        #region ��������ַ����еĻس������з�
        /// <summary>
        /// ��������ַ����еĻس������з�
        /// </summary>
        /// <param name="str">Ҫ������ַ���</param>
        /// <returns>����󷵻ص��ַ���</returns>
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

        #region ���ַ�����ָ��λ�ý�ȡָ�����ȵ����ַ���
        /// <summary>
        /// ���ַ�����ָ��λ�ý�ȡָ�����ȵ����ַ���
        /// </summary>
        /// <param name="str">ԭ�ַ���</param>
        /// <param name="startIndex">���ַ�������ʼλ��</param>
        /// <param name="length">���ַ����ĳ���</param>
        /// <returns>���ַ���</returns>
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
        /// ���ַ�����ָ��λ�ÿ�ʼ��ȡ���ַ�����β���ַ���
        /// </summary>
        /// <param name="str">ԭ�ַ���</param>
        /// <param name="startIndex">���ַ�������ʼλ��</param>
        /// <returns>���ַ���</returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }
        #endregion

        #region ȡָ�����ȵ��ַ���
        /// <summary>
        /// ȡָ�����ȵ��ַ���
        /// </summary>
        /// <param name="obj">Ҫ�����ַ���</param>
        /// <param name="p_Length">ָ������</param>
        /// <param name="p_TailString">�����滻���ַ���</param>
        /// <returns>��ȡ����ַ���</returns>
        public static string GetSubString(object obj, int p_Length, string p_TailString)
        {
            return GetSubString(StrFormat(obj), 0, p_Length, p_TailString);
        }

        /// <summary>
        /// ȡָ�����ȵ��ַ���
        /// </summary>
        /// <param name="obj">Ҫ�����ַ���</param>
        /// <param name="p_StartIndex">��ʼλ��</param>
        /// <param name="p_Length">ָ������</param>
        /// <param name="p_TailString">�����滻���ַ���</param>
        /// <returns>��ȡ����ַ���</returns>
        public static string GetSubString(object obj, int p_StartIndex, int p_Length, string p_TailString)
        {
            string p_SrcString = obj.ToString();
            string myResult = p_SrcString;

            Byte[] bComments = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {    //�������Ļ���ʱ(ע:���ĵķ�Χ:\u4e00 - \u9fa5, ������\u0800 - \u4e00, ����Ϊ\xAC00-\xD7A3)
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    //if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") || System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
                    //����ȡ����ʼλ�ó����ֶδ�����ʱ
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

                //���ַ������ȴ�����ʼλ��
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;

                    //��Ҫ��ȡ�ĳ������ַ�������Ч���ȷ�Χ��
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {   //��������Ч��Χ��ʱ,ֻȡ���ַ����Ľ�β

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

        #region �ָ��ַ���
        /// <summary>
        /// �ָ��ַ���
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
        /// �ָ��ַ���
        /// </summary>
        /// <param name="strContent">���ָ���ַ���</param>
        /// <param name="strSplit">�ָ��</param>
        /// <param name="ignoreRepeatItem">�����ظ���</param>
        /// <returns></returns>
        public static string[] SplitString(object strContent, string strSplit, bool ignoreRepeatItem)
        {
            return SplitString(strContent, strSplit, ignoreRepeatItem, 0);
        }

        /// <summary>
        /// �ָ��ַ���
        /// </summary>
        /// <param name="strContent">���ָ���ַ���</param>
        /// <param name="strSplit">�ָ��</param>
        /// <param name="count">��ȡ���ٸ��ַ���</param>
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
        /// �ָ��ַ���
        /// </summary>
        /// <param name="strContent">���ָ���ַ���</param>
        /// <param name="strSplit">�ָ��</param>
        /// <param name="ignoreRepeatItem">�����ظ���</param>
        /// <param name="maxElementLength">����Ԫ����󳤶�</param>
        /// <returns></returns>
        public static string[] SplitString(object strContent, string strSplit, bool ignoreRepeatItem, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            return ignoreRepeatItem ? DistinctStringArray(result, maxElementLength) : result;
        }
        /// <summary>
        /// �ָ��ַ���
        /// </summary>
        /// <param name="strContent">���ָ���ַ���</param>
        /// <param name="strSplit">�ָ��</param>
        /// <param name="ignoreRepeatItem">�����ظ���</param>
        /// <param name="maxElementLength">����Ԫ����С����</param>
        /// <param name="maxElementLength">����Ԫ����󳤶�</param>
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

        #region �ϲ��ַ�
        /// <summary>
        /// �ϲ��ַ�
        /// </summary>
        /// <param name="source">Ҫ�ϲ���Դ�ַ���</param>
        /// <param name="target">Ҫ���ϲ�����Ŀ���ַ���</param>
        /// <param name="mergechar">�ϲ���</param>
        /// <returns>�ϲ�����Ŀ���ַ���</returns>
        public static string MergeString(string source, string target)
        {
            return MergeString(source, target, ",");
        }

        /// <summary>
        /// �ϲ��ַ�
        /// </summary>
        /// <param name="source">Ҫ�ϲ���Դ�ַ���</param>
        /// <param name="target">Ҫ���ϲ�����Ŀ���ַ���</param>
        /// <param name="mergechar">�ϲ���</param>
        /// <returns>�����ַ���</returns>
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

        #region ����ַ��������е��ظ���
        /// <summary>
        /// ����ַ��������е��ظ���
        /// </summary>
        /// <param name="strArray">�ַ�������</param>
        /// <param name="maxElementLength">�ַ��������е���Ԫ�ص���󳤶�</param>
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
        /// ����ַ��������е��ظ���
        /// </summary>
        /// <param name="strArray">�ַ�������</param>
        /// <returns></returns>
        public static string[] DistinctStringArray(string[] strArray)
        {
            return DistinctStringArray(strArray, 0);
        }
        #endregion

        #region ����URL�н�β���ļ���
        /// <summary>
        /// ����URL�н�β���ļ���
        /// </summary>
        /// <param name="obj">URL��ַ</param>
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

        #region ��õ�ǰ����·��
        /// <summary>
        /// ��õ�ǰ����·��
        /// </summary>
        /// <param name="strPath">ָ����·��</param>
        /// <returns>����·��</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //��web��������
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

        #region ��ȡָ����ʽ������ʱ��
        /// <summary>
        /// ��ȡָ����ʽ������ʱ��
        /// </summary>
        /// <param name="datetimestr">����ʱ��</param>
        /// <param name="replacestr">��ʽ</param>
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

        #region �����ַ���������ÿ��Ԫ��Ϊ���ʵĴ�С
        /// <summary>
        /// �����ַ���������ÿ��Ԫ��Ϊ���ʵĴ�С
        /// ������С��minLengthʱ�����Ե�,-1Ϊ��������С����
        /// �����ȴ���maxLengthʱ��ȡ��ǰmaxLengthλ
        /// �����������nullԪ�أ��ᱻ���Ե�
        /// </summary>
        /// <param name="minLength">����Ԫ����С����</param>
        /// <param name="maxLength">����Ԫ����󳤶�</param>
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

        #region ת�����ļ���Ϊ���ļ���
        /// <summary>
        /// ת�����ļ���Ϊ���ļ���
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

                throw new Exception("�ַ�����������չ����Ϣ");
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
        /// ���javascript alter��Ϣ��������ҳ
        /// </summary>
        /// <param name="str"></param>
        public static void Alter(string str)
        {
            HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>alert('" + str + "');history.back();</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// ���javascript alter��Ϣ��ת��ָ��URL
        /// </summary>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public static void Alter(string str, string url)
        {
            HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>alert('" + str + "');location.href='" + url + "';</script>");
            HttpContext.Current.Response.End();
        }
        #endregion



        #region ��ȡ����

        //�ж���Ϣ��ǰ����״̬
        public static string GetLock(object isLock, string text)
        {
            if (ToBool(isLock) == false)
            {
                return "<span title=\"������" + text + "\">����</span>";
            }
            else
            {
                return "<span style=\"color:red\" title=\"������" + text + "\">����</span>";
            }
        }

        //�ж���Ϣ��ǰ�ö�״̬
        public static string GetTop(bool isTop, string text)
        {
            if (ToBool(isTop) == false)
            {
                return "<span title=\"���ô�" + text + "�ö�\">����</span>";
            }
            else
            {
                return "<span style=\"color:red\" title=\"������" + text + "�ö�\">�ö�</span>";
            }
        }

        //�жϸ�ѡ���Ƿ�checked/selected
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

        //���ݸ���BOOLֵ�����Ϊ�淵���ַ���
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

        //���ݸ���BOOLֵ�����Ϊ�ٷ����ַ���
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
