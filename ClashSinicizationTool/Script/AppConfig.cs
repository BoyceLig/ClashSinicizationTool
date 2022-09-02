using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using ClashSinicizationToolBase;

namespace ClashSinicizationTool
{
    public class AppConfig
    {
        #region 公有变量
        /// <summary>
        /// 配置信息
        /// </summary>
        public static Dictionary<string, string> Conf = new Dictionary<string, string>
        {
            // 启动时自动程序检查更新
            { "AutoCheck", "0" }
        };

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string FilePath = GlobalData.FilePath.configPath;
        #endregion

        #region 公有方法
        /// <summary>
        /// 从文件中加载配置
        /// - 启动时调用
        /// </summary>
        /// <returns></returns>
        public static bool LoadConfig()
        {
            if (!File.Exists(FilePath))
            {
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FilePath);
            XmlElement root = xmlDoc.DocumentElement;
            List<string> keys = new List<string>(Conf.Keys);
            foreach (string key in keys)
            {
                XmlNode itemNode = root.SelectSingleNode(key);
                if (itemNode != null)
                {
                    Conf[key] = itemNode.InnerText;
                }
            }
            return true;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <returns></returns>
        public static bool SaveConfig()
        {
            try
            {
                XmlDocument xmlDoc = CreateXMLDocument();
                xmlDoc.Save(FilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SetValue(string key, string value)
        {
            if (Conf.ContainsKey(key))
            {
                Conf[key] = value;
                return SaveConfig();
            }
            return false;
        }

        public static string GetValue(string key)
        {
            if (Conf.ContainsKey(key))
            {
                return Conf[key];
            }
            return string.Empty;
        }
        #endregion

        private static XmlDocument CreateXMLDocument()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclar = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDeclar);

            XmlElement xmlEle = xmlDoc.CreateElement("", "settings", "");
            xmlDoc.AppendChild(xmlEle);

            XmlNode root = xmlDoc.SelectSingleNode("settings");
            List<string> keys = new List<string>(Conf.Keys);
            foreach (string key in keys)
            {
                XmlElement xe = xmlDoc.CreateElement(key);
                xe.InnerText = Conf[key];
                root.AppendChild(xe);
            }

            return xmlDoc;
        }
    }
}
