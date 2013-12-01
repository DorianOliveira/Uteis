using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Collections;

namespace Testes.Classes
{

    public class XmlDocumentation
    {

        /// <summary>
        /// 
        /// </summary>
        public enum IDSTRING
        {
            NAMESPACE = 'N',
            CLASS = 'T',
            FIELD = 'F',
            PROPERTY = 'P',
            METHOD = 'M',
            EVENT = 'E'

        }

        /// <summary>
        /// 
        /// </summary>
        public struct Member
        {
            public Dictionary<string, string> propriedades;
            public string name;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct Documentation
        {
            public IDSTRING ID_STRING;
            public List<Member> members;

        }

        /// <summary>
        /// Retorna dados da documentação XML criada pelo .net na compilação, quando disponível
        /// </summary>
        /// <param name="strFullNamespace"></param>
        /// <param name="ID_STRING"></param>
        /// <returns></returns>
        public Documentation GetXmlDocumentationClass(string strFullNamespace, IDSTRING ID_STRING)
        {
            return GetXmlDocumentationClass(strFullNamespace, ID_STRING, true, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFullNamespace"></param>
        /// <param name="ID_STRING"></param>
        /// <param name="blnGetEntireNamespace"></param>
        /// <returns></returns>
        public Documentation GetXmlDocumentationClass(string strFullNamespace, IDSTRING ID_STRING, bool blnGetEntireNamespace)
        {
            return GetXmlDocumentationClass(strFullNamespace, ID_STRING, blnGetEntireNamespace, true);
        }

        /// <summary>
        /// Retorna dados da documentação XML criada pelo .net na compilação, quando disponível
        /// </summary>
        /// <param name="strFullNamespace">Namespace do assembly desejado</param>
        /// <param name="ID_STRING">Tipo de busca desejada</param>
        /// <param name="blnGetEntireNamespace">Define se será feita busca no caminho do namespace inteiro (incluindo class), ou apenas no assembly.</param>
        /// <param name="blnSearchChildren">Defina se será feita a busca em filhos (só funciona para classes)</param>
        /// <returns></returns>
        public Documentation GetXmlDocumentationClass(string strFullNamespace, IDSTRING ID_STRING, bool blnGetEntireNamespace, bool blnSearchChildren)
        {
            string strClassName = string.Empty;
            string strAssemblyName = string.Empty;
            string strNamespaceQuery = string.Empty;
            bool blnSingle = ID_STRING == IDSTRING.CLASS || ID_STRING == IDSTRING.NAMESPACE;
            IEnumerable<XmlNode> xmlMembers;
            XmlNodeList xmlNodeList = GetXmlDocumentation(strFullNamespace, ref strAssemblyName, ref strClassName);
            List<XmlNode> xmlNodes = new List<XmlNode>(xmlNodeList.Cast<XmlNode>());
            Documentation objDocumentation = new Documentation();

            objDocumentation.ID_STRING = ID_STRING;
            objDocumentation.members = new List<Member>();

            strNamespaceQuery = strAssemblyName;

            if (blnGetEntireNamespace)
                strNamespaceQuery = strFullNamespace;

            xmlMembers = from x in xmlNodes
                         where
                             x.Attributes["name"].Value.Contains(string.Concat((char)ID_STRING, ":", strNamespaceQuery))
                             && (!blnSearchChildren && x.Attributes["name"].Value.EndsWith(strClassName) || blnSearchChildren || !blnSingle)
                         select x;

            foreach (XmlNode objXmlNode in xmlMembers)
            {
                Dictionary<string, string> objAtributos = new Dictionary<string, string>();

                foreach (XmlNode xmlNode in objXmlNode.ChildNodes)
                    objAtributos.Add(xmlNode.Name, xmlNode.InnerXml);

                Member objMember = new Member();

                objMember.name = objXmlNode.Attributes["name"].Value;
                objMember.propriedades = objAtributos;

                objDocumentation.members.Add(objMember);
            }

            return objDocumentation;

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="strAssembly"></param>
        /// <param name="strAssemblyName"></param>
        /// <param name="strClassName"></param>
        /// <returns></returns>
        public XmlNodeList GetXmlDocumentation(string strAssembly, ref string strAssemblyName, ref string strClassName)
        {
            XmlDocument objXmlDocument = new XmlDocument();

            Type objType = Type.GetType(strAssembly);

            strClassName = objType.Name;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(objType);
            string codebase = assembly.CodeBase;
            string assemblyName = assembly.GetName().Name;
            string diretorio = GetDirectory(codebase);
            string strPathXml = string.Concat(diretorio, "/", assemblyName, ".xml");

            objXmlDocument.Load(strPathXml);
            strAssemblyName = assemblyName;

            return objXmlDocument.SelectNodes("/doc/members/member");

        }

        private string GetDirectory(string strAssemblyPath)
        {
            UriBuilder uri = new UriBuilder(strAssemblyPath);
            string path = Uri.UnescapeDataString(uri.Path);
            return System.IO.Path.GetDirectoryName(path);

        }
    }
}