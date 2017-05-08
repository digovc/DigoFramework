using System;
using System.Xml;

namespace DigoFramework.Arquivo
{
    public class ArquivoXml : ArquivoBase
    {
        #region Constantes

        private const string STR_ERRO_DIR_NULL = "Diretório do XML não definido.";

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Adiciona um "node" ao arquivo XML.
        /// </summary>
        public void addNode(string strNodeNome, string strNodeConteudo = "0", string strNodePai = "root")
        {
            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                throw new NullReferenceException(STR_ERRO_DIR_NULL);
            }

            if (!this.booExiste)
            {
                this.criarXml();
            }

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(this.dirCompleto);

            XmlNode xmlNodeRoot = xmlDocument["root"];

            if (xmlNodeRoot == null)
            {
                xmlNodeRoot = xmlDocument.CreateElement("root", null);

                xmlDocument.AppendChild(xmlNodeRoot);
            }

            XmlNode xmlNodePai = xmlNodeRoot;

            if (!"root".Equals(strNodePai))
            {
                xmlNodePai = xmlNodeRoot[strNodePai];
            }

            if (xmlNodeRoot == null)
            {
                xmlNodeRoot = xmlDocument.CreateElement("root", null);

                xmlDocument.AppendChild(xmlNodeRoot);
            }

            XmlNode xmlNodeFilho = xmlDocument.CreateElement(strNodeNome);

            xmlNodeFilho.InnerText = strNodeConteudo;

            xmlNodeRoot.AppendChild(xmlNodeFilho);

            xmlDocument.Save(this.dirCompleto);
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public bool getBooElemento(string strElementoNome, bool booValorDefault = false)
        {
            return this.getIntElemento(strElementoNome, booValorDefault ? 1 : 0).Equals(1);
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public decimal getDecElemento(string strElementoNome, decimal decValorDefault = -1)
        {
            return Convert.ToDecimal(this.getStrElemento(strElementoNome, decValorDefault.ToString()));
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public DateTime getDttElemento(string strElementoNome, DateTime dttValorDefault)
        {
            return Convert.ToDateTime(this.getStrElemento(strElementoNome, dttValorDefault.ToString()));
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public float getFltElemento(string strElementoNome, float fltValorDefault = -1)
        {
            return (float)Convert.ToDecimal(this.getStrElemento(strElementoNome, fltValorDefault.ToString()));
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public int getIntElemento(string strElementoNome, int intValorDefault = -1)
        {
            return Convert.ToInt32(this.getStrElemento(strElementoNome, intValorDefault.ToString()));
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public long getLngElemento(string strElementoNome, long lngValorDefault = -1)
        {
            return Convert.ToInt64(this.getStrElemento(strElementoNome, lngValorDefault.ToString()));
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public string getStrElemento(string strElementoNome, string strValorDefault = "-1")
        {
            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                throw new NullReferenceException(STR_ERRO_DIR_NULL);
            }

            if (!this.booExiste)
            {
                this.criarXml();
            }

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(this.dirCompleto);

            XmlNode xmlNodeRoot = xmlDocument["root"];

            if (xmlNodeRoot == null)
            {
                xmlNodeRoot = xmlDocument.CreateElement("root", null);

                xmlDocument.AppendChild(xmlNodeRoot);
            }

            XmlNode xmlNode = xmlNodeRoot[strElementoNome];

            if (xmlNode == null)
            {
                xmlNode = xmlDocument.CreateElement(strElementoNome, null);

                xmlNode.InnerText = strValorDefault;

                xmlNodeRoot.AppendChild(xmlNode);
            }

            xmlDocument.Save(this.dirCompleto);

            return xmlNode.InnerText;
        }

        /// <summary>
        /// Retorna um "xmlNodeList" com a lista de "node" dentro do arquivo XMl.
        /// </summary>
        public XmlNodeList getXmlNodeList()
        {
            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                throw new NullReferenceException(STR_ERRO_DIR_NULL);
            }

            if (!this.booExiste)
            {
                this.criarXml();
            }

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(this.dirCompleto);

            return xmlDocument.SelectSingleNode("root").ChildNodes;
        }

        /// <summary>
        /// Atualiza o valor da "tag" no arquivo "XML".
        /// </summary>
        /// <param name="strElementoNome">Nome do "node" que vai ser atualizado.</param>
        /// <param name="booElementoConteudo">Valor que o node vai ter.</param>
        public void setBooElemento(string strElementoNome, bool booElementoConteudo)
        {
            this.setIntElemento(strElementoNome, booElementoConteudo ? 1 : 0);
        }

        /// <summary>
        /// Atualiza o valor da "tag" no arquivo "XML".
        /// </summary>
        /// <param name="strElementoNome">Nome do "node" que vai ser atualizado.</param>
        /// <param name="decElementoConteudo">Valor que o node vai ter.</param>
        public void setDecElemento(string strElementoNome, decimal decElementoConteudo)
        {
            this.setStrElemento(strElementoNome, decElementoConteudo.ToString());
        }

        /// <summary>
        /// Atualiza o valor da "tag" no arquivo "XML".
        /// </summary>
        /// <param name="strElementoNome">Nome do "node" que vai ser atualizado.</param>
        /// <param name="dttElementoConteudo">Valor que o node vai ter.</param>
        public void setDttElemento(string strElementoNome, DateTime dttElementoConteudo)
        {
            if (dttElementoConteudo == null)
            {
                dttElementoConteudo = DateTime.MinValue;
            }

            this.setStrElemento(strElementoNome, dttElementoConteudo.ToString());
        }

        /// <summary>
        /// Atualiza o valor da "tag" no arquivo "XML".
        /// </summary>
        /// <param name="strElementoNome">Nome do "node" que vai ser atualizado.</param>
        /// <param name="fltElementoConteudo">Valor que o node vai ter.</param>
        public void setFltElemento(string strElementoNome, float fltElementoConteudo)
        {
            this.setStrElemento(strElementoNome, fltElementoConteudo.ToString());
        }

        /// <summary>
        /// Atualiza o valor da "tag" no arquivo "XML".
        /// </summary>
        /// <param name="strElementoNome">Nome do "node" que vai ser atualizado.</param>
        /// <param name="intElementoConteudo">Valor que o node vai ter.</param>
        public void setIntElemento(string strElementoNome, int intElementoConteudo)
        {
            this.setStrElemento(strElementoNome, intElementoConteudo.ToString());
        }

        /// <summary>
        /// Atualiza o valor da "tag" no arquivo "XML".
        /// </summary>
        /// <param name="strElementoNome">Nome do "node" que vai ser atualizado.</param>
        /// <param name="lngElementoConteudo">Valor que o node vai ter.</param>
        public void setLngElemento(string strElementoNome, long lngElementoConteudo)
        {
            this.setStrElemento(strElementoNome, lngElementoConteudo.ToString());
        }

        /// <summary>
        /// Atualiza o valor da "tag" no arquivo "XML".
        /// </summary>
        /// <param name="strNome">Nome do "node" que vai ser atualizado.</param>
        /// <param name="strValor">Valor que o node vai ter.</param>
        public void setStrElemento(string strNome, string strValor)
        {
            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                throw new NullReferenceException(STR_ERRO_DIR_NULL);
            }

            if (!this.booExiste)
            {
                this.criarXml();
            }

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(this.dirCompleto);

            XmlNode xmlNodeRoot = xmlDocument["root"];

            if (xmlNodeRoot == null)
            {
                xmlNodeRoot = xmlDocument.CreateElement("root", null);

                xmlDocument.AppendChild(xmlNodeRoot);
            }

            XmlNode xmlNode = xmlNodeRoot[strNome];

            if (xmlNode == null)
            {
                xmlNode = xmlDocument.CreateElement(strNome, null);

                xmlNodeRoot.AppendChild(xmlNode);
            }

            xmlNode.InnerText = strValor;

            xmlDocument.Save(this.dirCompleto);
        }

        private void criarXml()
        {
            using (XmlTextWriter xmlTextWriter = new XmlTextWriter(this.dirCompleto, System.Text.Encoding.UTF8))
            {
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteElementString("root", "");
                xmlTextWriter.Close();
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}