using Microsoft.Win32;

namespace ClashSinicizationTool
{
    class ProxySetting
    {
        //关闭代理
        public void CloseProxy()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            //设置代理可用 
            rk.SetValue("ProxyEnable", 0);
            //设置代理IP和端口 
            rk.SetValue("ProxyServer", "");
            rk.Close();
        }

        // 设置代理IP，参数ip的格式为是 ip：port
        public void setProxy(string ip)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            //设置代理可用 
            rk.SetValue("ProxyEnable", 1);
            //设置代理IP和端口 
            rk.SetValue("ProxyServer", ip);
            rk.Close();
        }
    }
}
