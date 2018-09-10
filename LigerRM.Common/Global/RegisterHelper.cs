using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net.NetworkInformation;

namespace LigerRM.Common.Global
{
    public static class RegisterHelper
    {
        public static string GetNetworkAdpater()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac += mo["MacAddress"].ToString() + " ";
                        break;
                    }
                moc = null;
                mc = null;
                return mac.Trim();
            }
            catch (Exception e)
            {
                return "uMnIk";
            }
        }

        public static string GetMacAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = string.Empty;
            long maxSpeed = -1;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed &&
                    !string.IsNullOrEmpty(tempMac) &&
                    tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }
            }

            return macAddress;
        }

        /// <summary>
/// 根据网卡类型来获取mac地址
/// </summary>
/// <param name="networkType">网卡类型</param>
/// <param name="macAddressFormatHanlder">格式化获取到的mac地址</param>
/// <returns>获取到的mac地址</returns>
        public static string GetMacAddress(NetworkInterfaceType networkType, Func<string, string> macAddressFormatHanlder)
{
  string _mac = string.Empty;
  NetworkInterface[] _networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
  foreach (NetworkInterface adapter in _networkInterfaces)
  {
 if (adapter.NetworkInterfaceType == networkType)
 {
   _mac = adapter.GetPhysicalAddress().ToString();
   if (!String.IsNullOrEmpty(_mac))
 break;
 }
  }
  if (macAddressFormatHanlder != null)
 _mac = macAddressFormatHanlder(_mac);
  return _mac;
}
/// <summary>
/// 根据网卡类型以及网卡状态获取mac地址
/// </summary>
/// <param name="networkType">网卡类型</param>
/// <param name="status">网卡状态</param>
///Up 网络接口已运行，可以传输数据包。 
///Down 网络接口无法传输数据包。 
///Testing 网络接口正在运行测试。 
///Unknown 网络接口的状态未知。 
///Dormant 网络接口不处于传输数据包的状态；它正等待外部事件。 
///NotPresent 由于缺少组件（通常为硬件组件），网络接口无法传输数据包。 
///LowerLayerDown 网络接口无法传输数据包，因为它运行在一个或多个其他接口之上，而这些“低层”接口中至少有一个已关闭。 
/// <param name="macAddressFormatHanlder">格式化获取到的mac地址</param>
/// <returns>获取到的mac地址</returns>
        public static string GetMacAddress(NetworkInterfaceType networkType, OperationalStatus status, Func<string, string> macAddressFormatHanlder)
{
  string _mac = string.Empty;
  NetworkInterface[] _networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
  foreach (NetworkInterface adapter in _networkInterfaces)
  {
 if (adapter.NetworkInterfaceType == networkType)
 {
   if (adapter.OperationalStatus != status) continue;
   _mac = adapter.GetPhysicalAddress().ToString();
   if (!String.IsNullOrEmpty(_mac)) break;
 }
  }
  if (macAddressFormatHanlder != null)
 _mac = macAddressFormatHanlder(_mac);
  return _mac;
}
/// <summary>
/// 获取读到的第一个mac地址
/// </summary>
/// <returns>获取到的mac地址</returns>
        public static string GetMacAddress(Func<string, string> macAddressFormatHanlder)
{
    string _mac = string.Empty;
    NetworkInterface[] _networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
    foreach (NetworkInterface adapter in _networkInterfaces)
    {
        _mac = adapter.GetPhysicalAddress().ToString();
        if (!string.IsNullOrEmpty(_mac))
            break;
    }
    if (macAddressFormatHanlder != null)
        _mac = macAddressFormatHanlder(_mac);
    return _mac;
}
    }
}
