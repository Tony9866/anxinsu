namespace LigerRM.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using Liger.Common.Extensions;
    using Liger.Data;
    using Liger.Common;

    /// <summary>
    /// 将检索规则 翻译成 where sql 语句,并生成相应的参数列表
    /// 如果遇到{CurrentUserID}这种，翻译成对应的参数
    /// </summary>
    public class FilterTranslator
    {
        //几个前缀/后缀
        protected char leftToken = '[';
        protected char paramPrefixToken = '@';
        protected char rightToken = ']';
        protected char groupLeftToken = '(';
        protected char groupRightToken = ')';
        protected char likeToken = '%';
        /// <summary>
        /// 参数计数器
        /// </summary>
        private int paramCounter = 0;

        //几个主要的属性
        public FilterGroup Group { get; set; }
        public string CommandText { get; private set; }
        public IList<FilterParam> Parms { get; private set; }

        public FilterTranslator()
            : this(null)
        {
        }

        public FilterTranslator(FilterGroup group)
        {
            this.Group = group;
            this.Parms = new List<FilterParam>();
        }
        public void Translate()
        {
            this.CommandText = TranslateGroup(this.Group);

            this.CommandText = this.CommandText.Replace("()","(1=1)");
        }

        public string TranslateGroup(FilterGroup group)
        {
            StringBuilder bulider = new StringBuilder();
            if (group == null) return " 1=1 ";
            var appended = false;
            bulider.Append(groupLeftToken);
            if (group.rules != null)
            {
                foreach (var rule in group.rules)
                {
                    string sb = TranslateRule(rule);
                    
                    
                    if (!string.IsNullOrEmpty(sb))
                    {
                        if (appended)
                            bulider.Append(GetOperatorQueryText(group.op));
                        bulider.Append(sb);
                    }

                    appended = true;
                }
            }
            if (group.groups != null)
            {
                foreach (var subgroup in group.groups)
                {
                    if (subgroup!=null)
                        subgroup.rules = subgroup.rules.Where(i => i.value != null && i.value.ToString() != "全部").ToList();
                    string sb = TranslateGroup(subgroup);
                    if (!string.IsNullOrEmpty(sb))
                    {
                        if (appended)
                            bulider.Append(GetOperatorQueryText(group.op));
                        bulider.Append(sb);
                    }
                    appended = true;
                }
            }
            bulider.Append(groupRightToken);
            if (appended == false) return " 1=1 ";
            return bulider.ToString();
        }

        /// <summary>
        /// 注册用户匹配管理，当不方便修改ligerRM.dll时，可以通过这种方式，在外部注册
        /// </summary>
        /// <param name="match"></param>
        public static void RegCurrentParmMatch(string key,Func<int> fn)
        {
            if (!currentParmMatch.ContainsKey(key))
                currentParmMatch.Add(key, fn);
        }

        private static Dictionary<string, Func<string>> currentStringMath = new Dictionary<string, Func<string>>()
        {
            {"{CurrentAreaIDs}",()=> SysContext.CurrentAreaIDs},
            {"{CurrentCarveIDs}",()=> SysContext.CurrentCarveIDs},
            {"{CurrentDeptID}",()=> SysContext.CurrentDeptID},
            {"{CurrentEmployeeID}",()=> SysContext.CurrentEmployeeID},
            {"{CurrentSupplierID}",()=> SysContext.CurrentSupplierID}
        };

        /// <summary>
        /// 匹配当前用户信息，都是int类型
        /// 对于CurrentRoleID，只返回第一个角色
        /// </summary>
        private static Dictionary<string, Func<int>> currentParmMatch = new Dictionary<string, Func<int>>()
        {
            {"{CurrentUserID}",()=> SysContext.CurrentUserID},
            {"{CurrentRoleID}",()=> SysContext.CurrentRoleID.ToStr().Split(',')[0].ToInt()}

        };


        
        public string TranslateRule(FilterRule rule)
        {
            StringBuilder bulider = new StringBuilder();
            if (rule == null) return " 1=1 ";

            //如果字段名采用了 用户信息参数

            if (currentParmMatch.ContainsKey(rule.field))
            {
                var field = currentParmMatch[rule.field]();
                bulider.Append(paramPrefixToken + CreateFilterParam(field, "int"));
            }
            else
            {
                if (currentStringMath.ContainsKey(rule.field))
                {
                    var field = currentStringMath[rule.field]();
                    bulider.Append(paramPrefixToken + CreateFilterParam(field, "sting"));
                }
                bulider.Append(leftToken + rule.field + rightToken);
            }
            //操作符
            bulider.Append(GetOperatorQueryText(rule.op));

            var op = rule.op.ToLower();
            if (op == "like" || op == "endwith")
            {
                var value = rule.value.ToString().Trim();
                if (!value.StartsWith(this.likeToken.ToString()))
                {
                    rule.value = this.likeToken + value;
                }
            }
            if (op == "like" || op == "startwith")
            {
                var value = rule.value.ToString().Trim();
                if (!value.EndsWith(this.likeToken.ToString()))
                {
                    rule.value = value + this.likeToken;
                }
            }
            if (op == "in" || op == "notin")
            {
                var values = rule.value.ToString().Split(',');
                var appended = false;
                bulider.Append("(");
                foreach (var value in values)
                {
                    if (appended) bulider.Append(",");
                    //如果值使用了 用户信息参数 比如： in ({CurrentRoleID},4)
                    if (currentParmMatch.ContainsKey(value))
                    {
                        var val = currentParmMatch[value]();
                        bulider.Append(paramPrefixToken + CreateFilterParam(val, "int"));
                    }
                    else
                    {
                        if (currentStringMath.ContainsKey(value))
                        {
                            int v=0;
                            var val = currentStringMath[value]();
                            if (val.ToString() == "'undefined'")
                                return string.Empty;
                            bulider.Append(paramPrefixToken + CreateFilterParam(val, "string"));
                            if (!int.TryParse(val,out v))
                            {
                                bulider.Replace(bulider.ToString().Substring(bulider.ToString().IndexOf("(") + 1), val);
                            }
                        }
                        else
                            bulider.Append(paramPrefixToken + CreateFilterParam(value, rule.type)); 
                    }
                    appended = true;
                }
                bulider.Append(")");
            } 
            //is null 和 is not null 不需要值
            else if (op != "isnull" && op != "isnotnull")
            {
                //如果值使用了 用户信息参数 比如 [EmptID] = {CurrentEmptID}
                if (rule.value != null && currentParmMatch.ContainsKey(rule.value.ToStr()))
                {
                    var value = currentParmMatch[rule.value.ToStr()]();
                    bulider.Append(paramPrefixToken + CreateFilterParam(value, "int"));
                }
                else
                {
                    bulider.Append(paramPrefixToken + CreateFilterParam(rule.value, rule.type));

                }
            } 
            return bulider.ToString();
        }

        private string CreateFilterParam(object value,string type)
        {
            string paramName = "p" + ++paramCounter;
            object val = value;
            if (type.EqualsTo("int", true) || type.EqualsTo("digits", true))
                val = DataHelper.ConvertValue(typeof(int), val);
            else if (type.EqualsTo("float", true) || type.EqualsTo("number", true))
                val = DataHelper.ConvertValue(typeof(decimal),val);
            FilterParam param = new FilterParam(paramName, val);
            this.Parms.Add(param);
            return paramName;
        }


        public override string ToString()
        {
            StringBuilder bulider = new StringBuilder();
            bulider.Append("CommandText:");
            bulider.Append(this.CommandText);
            bulider.AppendLine();
            bulider.AppendLine("Parms:");
            foreach (var parm in this.Parms)
            {
                bulider.AppendLine(string.Format("{0}:{1}", parm.Name, parm.Value));
            }
            return bulider.ToString();
        }

        #region 公共工具方法
        /// <summary>
        /// 获取操作符的SQL Text
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns> 
        public static string GetOperatorQueryText(string op)
        {
            switch (op.ToLower())
            {
                case "add":
                    return " + ";
                case "bitwiseand":
                    return " & ";
                case "bitwisenot":
                    return " ~ ";
                case "bitwiseor":
                    return " | ";
                case "bitwisexor":
                    return " ^ ";
                case "divide":
                    return " / ";
                case "equal":
                    return " = ";
                case "greater":
                    return " > ";
                case "greaterorequal":
                    return " >= ";
                case "isnull":
                    return " is null ";
                case "isnotnull":
                    return " is not null ";
                case "less":
                    return " < ";
                case "lessorequal":
                    return " <= ";
                case "like":
                    return " like ";
                case "startwith":
                    return " like ";
                case "endwith":
                    return " like ";
                case "modulo":
                    return " % ";
                case "multiply":
                    return " * ";
                case "notequal":
                    return " <> ";
                case "subtract":
                    return " - ";
                case "and":
                    return " and ";
                case "or":
                    return " or ";
                case "in":
                    return " in ";
                case "notin":
                    return " not in ";
                default:
                    return " = ";
            }
        }
        #endregion

    }
}
