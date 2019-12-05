using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Data;

namespace eChartProject.Web.Common
{
    public class XmlSerialization<T> where T : class
    {
        public static string Serialize(T instance)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, instance);
                ms.Seek(0, SeekOrigin.Begin);
                return new StreamReader(ms, Encoding.UTF8).ReadToEnd();
            }
        }

        public static T DeSerialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);
                sw.Write(xml);
                sw.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                return (T)serializer.Deserialize(ms);
            }
        }

        public static string AvoidXmlns(string xml)
        {
            Regex reg = new Regex("xmlns\\s*\\S*\\s*=\\s*\"[^\"]*\"", RegexOptions.IgnoreCase);
            return reg.Replace(xml, "");
        }
    }

    public class XmlOperator
    {
        public static string JoinPath(params string[] nodeName)
        {
            return string.Join(".", nodeName);
        }

        private XmlDocument objXmlDoc = new XmlDocument();



        public XmlNode RootNode
        {
            get
            {
                return objXmlDoc.DocumentElement;
            }
        }

        public XmlDocument XmlDoc
        {
            get { return objXmlDoc; }
        }

        /// <summary>
        /// Load an XmlFile by it's fullname
        /// </summary>
        /// <param name="fileName">Fullname of the xml file</param>
        public XmlOperator(string xml)
        {
            try
            {
                objXmlDoc.LoadXml(xml);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public XmlOperator(XmlDocument xmlDoc)
        {
            objXmlDoc = xmlDoc;
        }

        public XmlOperator()
        {
            objXmlDoc = new XmlDocument();
        }

        public XmlNode CreateRootNode(string rootNode)
        {
            objXmlDoc = new XmlDocument();
            XmlNode node = objXmlDoc.CreateNode(XmlNodeType.Element, rootNode, "");
            XmlDeclaration declaration = objXmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            objXmlDoc.AppendChild(declaration);
            objXmlDoc.AppendChild(node);
            return node;

        }

        /// <summary>
        /// Read a node from xml file, return a DataSet
        /// </summary>
        /// <param name="XmlPathNode">an xpath string used to search an XmlNode</param>
        /// <returns>DataSet</returns>
        public DataSet GetData(string XmlPathNode)
        {
            DataSet ds = new DataSet();
            StringReader read = new StringReader(objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds;
        }

        /// <summary>
        /// Replace the inner text of an XmlNode
        /// </summary>
        /// <param name="XmlPathNode">an xpath string used to search an XmlNode</param>
        /// <param name="Content"></param>
        public XmlNode SetInnerText(string XmlPathNode, string Content)
        {
            XmlNode node = objXmlDoc.SelectSingleNode(this.xpath(XmlPathNode));
            if (!string.IsNullOrEmpty(Content))
            {
                XmlCDataSection cdata = objXmlDoc.CreateCDataSection(Content);

                node.AppendChild(cdata);
            }
            return node;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="XmlPathNode"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public XmlNode SetInnerText(XmlNode XmlPathNode, string Content)
        {
            XmlNode node = XmlPathNode;
            if (!string.IsNullOrEmpty(Content))
            {
                XmlCDataSection cdata = objXmlDoc.CreateCDataSection(Content);

                node.AppendChild(cdata);
            }
            return node;
        }

        /// <summary>
        /// Delete an XmlNode
        /// </summary>
        /// <param name="Node">an xpath string used to search an XmlNode</param>
        public XmlNode Delete(string Node)
        {
            XmlNode node = objXmlDoc.SelectSingleNode(this.xpath(Node));
            node.ParentNode.RemoveChild(node);
            return node;
        }

        /// <summary>
        /// Insert a node and one of it's child node
        /// </summary>
        /// <param name="MainNode">an xpath string used to search an parent node</param>
        /// <param name="ChildNode">Name of the child node</param>
        /// <param name="Element">Name of the child node's element</param>
        /// <param name="Content">Content of the child node's element</param>
        public XmlNode InsertNode(string MainNode, string ChildNode, string Element, string Content)
        {
            XmlNode objRootNode = objXmlDoc.SelectSingleNode(this.xpath(MainNode));
            XmlElement objChildNode = objXmlDoc.CreateElement(ChildNode);
            objRootNode.AppendChild(objChildNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            if (!string.IsNullOrEmpty(Content))
            {
                XmlCDataSection cdata = objXmlDoc.CreateCDataSection(Content);
                objElement.AppendChild(cdata);
            }
            objChildNode.AppendChild(objElement);
            return objChildNode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MainNode"></param>
        /// <param name="ChildNode"></param>
        /// <param name="Element"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public XmlNode InsertNode(XmlNode MainNode, string ChildNode, string Element, string Content)
        {
            XmlNode objRootNode = MainNode;
            XmlElement objChildNode = objXmlDoc.CreateElement(ChildNode);
            objRootNode.AppendChild(objChildNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            if (!string.IsNullOrEmpty(Content))
            {
                XmlCDataSection cdata = objXmlDoc.CreateCDataSection(Content);
                objElement.AppendChild(cdata);
            }
            objChildNode.AppendChild(objElement);
            return objChildNode;
        }

        /// <summary>
        /// Insert a node, with an attribute
        /// </summary>
        /// <param name="MainNode">an xpath string used to search parent node</param>
        /// <param name="Element">Name of the node</param>
        /// <param name="Attrib">Name of the attribute</param>
        /// <param name="AttribContent">Value of the attribute</param>
        /// <param name="Content">Inner text of the node</param>
        public XmlNode InsertElement(string MainNode, string Element, string Attrib, string AttribContent, string Content)
        {
            XmlNode objNode = objXmlDoc.SelectSingleNode(this.xpath(MainNode));
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.SetAttribute(Attrib, AttribContent);
            if (!string.IsNullOrEmpty(Content))
            {
                XmlCDataSection cdata = objXmlDoc.CreateCDataSection(Content);
                objElement.AppendChild(cdata);
            }
            objNode.AppendChild(objElement);
            return objElement;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MainNode"></param>
        /// <param name="Element"></param>
        /// <param name="Attrib"></param>
        /// <param name="AttribContent"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public XmlNode InsertElement(XmlNode MainNode, string Element, string Attrib, string AttribContent, string Content)
        {
            XmlNode objNode = MainNode;
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.SetAttribute(Attrib, AttribContent);
            if (!string.IsNullOrEmpty(Content))
            {
                XmlCDataSection cdata = objXmlDoc.CreateCDataSection(Content);
                objElement.AppendChild(cdata);
            }
            objNode.AppendChild(objElement);
            return objElement;
        }

        /// <summary>
        /// Insert a node, without any attribute
        /// </summary>
        /// <param name="MainNode">an xpath string used to search parent node</param>
        /// <param name="Element">Name of the node</param>
        /// <param name="Content">Inner text of the node</param>
        public XmlNode InsertElement(string MainNode, string Element, string Content)
        {
            XmlNode objNode = objXmlDoc.SelectSingleNode(this.xpath(MainNode));
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            if (!string.IsNullOrEmpty(Content))
            {
                XmlCDataSection cdata = objXmlDoc.CreateCDataSection(Content);
                objElement.AppendChild(cdata);
            }
            objNode.AppendChild(objElement);
            return objElement;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MainNode"></param>
        /// <param name="Element"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public XmlNode InsertElement(XmlNode MainNode, string Element, string Content)
        {
            XmlNode objNode = MainNode;
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            if (!string.IsNullOrEmpty(Content))
            {
                XmlCDataSection cdata = objXmlDoc.CreateCDataSection(Content);
                objElement.AppendChild(cdata);
            }
            objNode.AppendChild(objElement);
            return objElement;
        }



        /// <summary>
        /// Select an XmlNode using a standard xpath string
        /// </summary>
        /// <param name="xpath">a standard xpath string</param>
        /// <returns>XmlNode</returns>
        public XmlNode SelectSingleNode(string xpath)
        {
            return objXmlDoc.SelectSingleNode(this.xpath(xpath));
        }

        /// <summary>
        /// Select an array of XmlNode using a standard xpath string
        /// </summary>
        /// <param name="xpath">a standard xpath string</param>
        /// <returns>XmlNodeList</returns>
        public XmlNodeList SelectNodes(string xpath)
        {
            return objXmlDoc.SelectNodes(this.xpath(xpath));
        }


        /// <summary>
        /// Get the value of an attribute from an XmlNode
        /// </summary>
        /// <param name="node">an XmlNode whose attribute is to be readed</param>
        /// <param name="attributeName">name of the attribute</param>
        /// <returns>value of the attribute</returns>
        public string GetNodeAttribute(XmlNode node, string attributeName)
        {
            try
            {
                return node.Attributes[attributeName].Value;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the value of an XmlNode by it's node path
        /// </summary>
        /// <param name="nodePath">The path of the XmlNode, it should be write from the root and split every childnode by "."</param>
        /// <param name="attributeName">name of the attribute</param>
        /// <returns>value of the attribute</returns>
        public string GetNodeAttribute(string nodePath, string attributeName)
        {
            XmlNode node = this.GetSelectNode(this.xpath(nodePath));
            if (node == null)
            {
                throw new System.Exception(string.Format("Could not find the XmlNode with the path \"{0}\"", nodePath));
            }
            return this.GetNodeAttribute(node, attributeName);
        }

        /// <summary>
        /// Get the value of an attribute from a childnode defined by name
        /// </summary>
        /// <param name="node">current XmlNode</param>
        /// <param name="childNodeName">name of the childnode</param>
        /// <param name="attrName">attribute's name of the childnode</param>
        /// <returns>value of the attribute</returns>
        public string GetNodeAttribute(XmlNode node, string childNodeName, string attributeName)
        {
            string xpath = string.Format("./{0}", childNodeName);
            XmlNode child = node.SelectSingleNode(xpath);
            if (child == node)
            {
                string error = string.Format("Could not find the child node named '{0}' from current XmlNode", childNodeName);
                throw new System.Exception(error);
            }
            return this.GetNodeAttribute(child, attributeName);
        }

        /// <summary>
        /// Save the value of an attribute
        /// </summary>
        /// <param name="node">current XmlNode</param>
        /// <param name="attributeName">name of the attribute</param>
        /// <param name="value">value of the attribute</param>
        public XmlNode SetNodeAttribute(XmlNode node, string attributeName, string value)
        {
            if (node.Attributes[attributeName] == null)
            {
                XmlAttribute attr = objXmlDoc.CreateAttribute(attributeName);
                node.Attributes.Append(attr);
            }
            node.Attributes[attributeName].Value = value;
            return node;
        }

        /// <summary>
        /// Save the value of an attribute by the path of an XmlNode
        /// </summary>
        /// <param name="nodePath">The path of the XmlNode, it should be write from the root and split every childnode by "."</param>
        /// <param name="attributeName">name of the attribute</param>
        /// <param name="value">value of the attribute</param>
        public XmlNode SetNodeAttribute(string nodePath, string attributeName, string value)
        {
            XmlNode node = this.GetSelectNode(this.xpath(nodePath));
            if (node == null)
            {
                throw new System.Exception(string.Format("Could not find the XmlNode with the path \"{0}\"", nodePath));
            }
            this.SetNodeAttribute(node, attributeName, value);
            return node;
        }

        /// <summary>
        /// Save the value of an XmlNode
        /// </summary>
        /// <param name="node">current XmlNode</param>
        /// <param name="value">value of the XmlNode</param>
        public XmlNode SetNode(XmlNode node, string value)
        {
            node.Value = value;
            return node;
        }

        /// <summary>
        /// Save the value of an XmlNode by it's node path
        /// </summary>
        /// <param name="nodePath">The path of the XmlNode, it should be write from the root and split every childnode by "."</param>
        /// <param name="value">value of the XmlNode</param>
        public XmlNode SetNode(string nodePath, string value)
        {
            XmlNode node = this.GetSelectNode(this.xpath(nodePath));
            if (node == null)
            {
                throw new System.Exception(string.Format("Could not find the XmlNode with the path \"{0}\"", nodePath));
            }
            this.SetNode(node, value);
            return node;
        }

        /// <summary>
        /// Get an XmlNode using it's node path
        /// </summary>
        /// <param name="nodePath">The path of the XmlNode, it should be write from the root and split every childnode by "."</param>
        /// <returns>XmlNode</returns>
        public XmlNode GetSelectNode(string nodePath)
        {
            string xpath = this.xpath(nodePath);
            return objXmlDoc.SelectSingleNode(xpath);
        }

        /// <summary>
        /// Get an XmlNode using it's node path with condition
        /// </summary>
        /// <param name="nodePath">The path of the XmlNode, it should be write from the root and split every childnode by "."</param>
        /// <param name="attributeName">name of the attribute</param>
        /// <param name="value">value of the attribute</param>
        /// <returns>XmlNode</returns>
        public XmlNode GetSelectNode(string nodePath, string attributeName, string value)
        {
            string xpath = this.xpath(nodePath, attributeName, value);
            return objXmlDoc.SelectSingleNode(xpath);
        }

        /// <summary>
        /// Get a child node of an XmlNode by name
        /// </summary>
        /// <param name="node">current XmlNode</param>
        /// <param name="childName">name of the child node</param>
        /// <returns>a XmlNode, it will return the first one if there's more than one result</returns>
        public XmlNode GetSelectNode(XmlNode node, string childName)
        {
            string xpath = string.Format("./{0}", childName);
            return node.SelectSingleNode(xpath);
        }

        /// <summary>
        /// Get a child node of an XmlNode by name with condition
        /// </summary>
        /// <param name="node">current XmlNode</param>
        /// <param name="childName">name of the child node</param>
        /// <param name="attributeName">name of the attribute of the child node</param>
        /// <param name="value">value of the attribute</param>
        /// <returns>a XmlNode, it will return the first one if there's more than one result</returns>
        public XmlNode GetSelectNode(XmlNode node, string childName, string attributeName, string value)
        {
            string xpath = string.Format("./{0}[@{1}='{2}']", childName, attributeName, value);
            return node.SelectSingleNode(xpath);
        }

        /// <summary>
        /// Get all the child nodes of an XmlNode
        /// </summary>
        /// <param name="node">current XmlNode</param>
        /// <returns>an array contains all the child nodes</returns>
        public XmlNode[] GetChildsNode(XmlNode node)
        {
            List<XmlNode> nodeList = new List<XmlNode>();
            foreach (XmlNode n in node.ChildNodes)
            {
                nodeList.Add(n);
            }
            return nodeList.ToArray();
        }

        /// <summary>
        /// Convert the node path to a standard xpath
        /// </summary>
        /// <param name="nodePath">a string of the node path</param>
        /// <returns>a standard xpath string</returns>
        private string xpath(string nodePath)
        {
            Regex format = new Regex(@"^[^\.]+(\.[^\.]+)*$");
            if (!format.IsMatch(nodePath))
            {
                throw new FormatException(string.Format("The node path \"{0}\" does not meet the required format", nodePath));
            }
            return nodePath.Replace(".", "/").Insert(0, "/");
        }

        /// <summary>
        /// Convert the node path to a standard xpath, with condition
        /// </summary>
        /// <param name="nodePath">a string of the node path</param>
        /// <param name="attrName">attribute's name of the target node</param>
        /// <param name="value">value of the attribute</param>
        /// <returns>a standard xpath string</returns>
        private string xpath(string nodePath, string attrName, string value)
        {
            string xpath = this.xpath(nodePath);
            return string.Format("{0}[@{1}='{2}']", xpath, attrName, value);
        }
    }

    public class XmlNodeName
    {
        public const string Message = "Message";
        public const string Table = "Table";
        public const string Field = "Field";
     
    }

    public class XmlAttributeName
    {
        public const string Name = "Name";
  
    }

   
}
