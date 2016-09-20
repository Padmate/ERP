using Padmate.ERP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Padmate.ERP.Web.Controllers
{
    public static class ExtTreeConfig
    {
        public static ExtTreeDataConfiguration Init
        {
            get
            {
                return ExtTreeDataConfiguration.GetInstance();
            }
        }
    }

    /// <summary>
    /// 树形菜单配置文件
    /// 单例模式
    /// </summary>
    public class ExtTreeDataConfiguration
    {
        // 定义一个静态变量来保存类的实例
        private static ExtTreeDataConfiguration uniqueInstance;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        static XDocument _doc;
        // 定义私有构造函数，使外界不能创建该类实例
        private ExtTreeDataConfiguration()
        {
            var mapPath = HttpContext.Current.Request.PhysicalApplicationPath;

            string configPath = Path.Combine(mapPath, "tree-data.config");
            _doc = XDocument.Load(configPath);
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static ExtTreeDataConfiguration GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new ExtTreeDataConfiguration();
                    }
                }
            }
            return uniqueInstance;
        }


        /// <summary>
        /// 根据用户角色获取菜单配置文件
        /// </summary>
        /// <param name="mapPath"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public M_ExtTreeNode ExtTreeDatas(string role)
        {
            M_ExtTreeNode extTreeData = new M_ExtTreeNode();

            var configuration = _doc.Descendants("configuration").FirstOrDefault();
            if (configuration == null)
                throw new Exception("菜单配置文件中找不到configuration节点信息");
            var rootnodesection = configuration.Elements("treenode")
                .SingleOrDefault(c => c.Attribute("role").Value.Equals(role)
                && c.Attribute("root").Value.Equals("true"));
            if(rootnodesection == null)
                throw new Exception("菜单配置文件中找不到角色为"+role+"的配置信息");

            extTreeData = ConstructExtTreeData(rootnodesection);

            return extTreeData;
        }

        private M_ExtTreeNode ConstructExtTreeData(XElement nodeElement)
        {
            M_ExtTreeNode extTreeData = new M_ExtTreeNode();
            var idAttribute = nodeElement.Attribute("id");
            var textAttribute = nodeElement.Attribute("text");
            var leafAttribute = nodeElement.Attribute("leaf");
            var iconAttribute = nodeElement.Attribute("icon");
            var iconClsAttribute = nodeElement.Attribute("iconCls");
            var expandedAttribute = nodeElement.Attribute("expanded");
            var iframesrcAttribute = nodeElement.Attribute("iframesrc");
            extTreeData.id = idAttribute != null ? idAttribute.Value : string.Empty ;
            extTreeData.text = textAttribute != null ? textAttribute.Value : string.Empty;
            extTreeData.leaf = leafAttribute != null ? System.Convert.ToBoolean(leafAttribute.Value) : false;
            extTreeData.icon = iconAttribute != null ? iconAttribute.Value : string.Empty;
            extTreeData.iconCls = iconClsAttribute != null ? iconClsAttribute.Value : string.Empty ;
            extTreeData.expanded = expandedAttribute != null ? System.Convert.ToBoolean(expandedAttribute.Value) : false;
            extTreeData.iframesrc = iframesrcAttribute != null ? iframesrcAttribute.Value : string.Empty;

            var childrenNodes = nodeElement.Elements("treenode");
            if(childrenNodes.Count() >0)
            {
                extTreeData.children = new List<M_ExtTreeNode>();
                foreach(var childnode in childrenNodes)
                {
                    M_ExtTreeNode childTreeNode = new M_ExtTreeNode();
                    childTreeNode = ConstructExtTreeData(childnode);
                    extTreeData.children.Add(childTreeNode);
                }

            }

            return extTreeData;
        }

    }
}