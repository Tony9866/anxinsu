﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.239
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Liger.Data.Resources {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TextResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TextResource() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Liger.Data.Resources.TextResource", typeof(TextResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 {0} 必须 和 {1} 相等 的本地化字符串。
        /// </summary>
        internal static string ArgumentShouldEqual {
            get {
                return ResourceManager.GetString("ArgumentShouldEqual", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 参数 {0} 必须大于 {1} 的本地化字符串。
        /// </summary>
        internal static string ArgumentShouldGreaterThan {
            get {
                return ResourceManager.GetString("ArgumentShouldGreaterThan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 没有设置标示列,无法完成此查询 的本地化字符串。
        /// </summary>
        internal static string AutoKeyToSearchAllow {
            get {
                return ResourceManager.GetString("AutoKeyToSearchAllow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} 不能为空 的本地化字符串。
        /// </summary>
        internal static string CanNotBeNull {
            get {
                return ResourceManager.GetString("CanNotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} 不能是只读的 的本地化字符串。
        /// </summary>
        internal static string CanNotReadOnly {
            get {
                return ResourceManager.GetString("CanNotReadOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 必须设置标示列 的本地化字符串。
        /// </summary>
        internal static string MustSetupID {
            get {
                return ResourceManager.GetString("MustSetupID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 必须设置主键 的本地化字符串。
        /// </summary>
        internal static string MustSetupPK {
            get {
                return ResourceManager.GetString("MustSetupPK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 需要实现 的本地化字符串。
        /// </summary>
        internal static string NeedComplete {
            get {
                return ResourceManager.GetString("NeedComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不支持这种类型 的本地化字符串。
        /// </summary>
        internal static string NotSupportThisType {
            get {
                return ResourceManager.GetString("NotSupportThisType", resourceCulture);
            }
        }
    }
}
