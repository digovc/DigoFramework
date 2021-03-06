﻿using System;
using System.Xml;

namespace DigoFramework.Arquivo
{
    public class ArquivoXml : ArquivoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private XmlDocument _xmlDocument;

        private XmlDocument xmlDocument
        {
            get
            {
                if (_xmlDocument != null)
                {
                    return _xmlDocument;
                }

                _xmlDocument = this.getXmlDocument();

                return _xmlDocument;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Adiciona um "node" ao arquivo XML.
        /// </summary>
        public void addNode(string strNodeNome, string strNodeConteudo = "0", string strPaiNode = "root")
        {
            if (this.xmlDocument == null)
            {
                return;
            }

            var xmlNodeRoot = this.xmlDocument.GetElementsByTagName("root").Item(0);

            if (xmlNodeRoot == null)
            {
                this.deletar();
                this.criarXml();
            }

            var xmlNodeFilho = this.xmlDocument.CreateElement(strNodeNome);

            xmlNodeFilho.InnerText = strNodeConteudo;

            var xmlNodePai = this.xmlDocument.GetElementsByTagName(strPaiNode).Item(0);

            xmlNodePai.AppendChild(xmlNodeFilho);
        }

        /// <summary>
        /// Adiciona um "xmlElemente" ao arquivo XMl atual.
        /// </summary>
        public void addXmlElemento(XmlElement xmlElement)
        {
            this.xmlDocument.AppendChild(xmlElement);
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
            XmlNode objXmlNode = null;

            try
            {
                objXmlNode = this.xmlDocument.SelectSingleNode(strElementoNome);
            }
            catch (XmlException ex)
            {
                if ("Root element is missing.".Equals(ex.Message) || "Elemento raiz inexistente.".Equals(ex.Message))
                {
                    this.addNode(strElementoNome, strValorDefault);

                    return strValorDefault;
                }

                throw ex;
            }

            if (objXmlNode == null)
            {
                objXmlNode = this.xmlDocument.SelectSingleNode("root/" + strElementoNome);
            }

            if (objXmlNode == null)
            {
                this.addNode(strElementoNome, strValorDefault);

                return strValorDefault;
            }

            return objXmlNode.InnerText;
        }

        /// <summary>
        /// Retorna um "xmlNodeList" com a lista de "node" dentro do arquivo XMl.
        /// </summary>
        public XmlNodeList getXmlNodeList()
        {
            return this.xmlDocument.SelectSingleNode("root").ChildNodes;
        }

        public override bool salvar()
        {
            if (base.salvar())
            {
                return true;
            }

            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                return false;
            }

            if (this.xmlDocument == null)
            {
                return false;
            }

            this.xmlDocument.Save(this.dirCompleto);

            return true;
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
        /// <param name="strElementoNome">Nome do "node" que vai ser atualizado.</param>
        /// <param name="strElementoConteudo">Valor que o node vai ter.</param>
        public void setStrElemento(string strElementoNome, string strElementoConteudo)
        {
            var xmlNode = this.xmlDocument.SelectSingleNode(strElementoNome);

            if (xmlNode == null)
            {
                xmlNode = xmlDocument.SelectSingleNode("root/" + strElementoNome);
            }

            if (xmlNode == null)
            {
                this.addNode(strElementoNome, strElementoConteudo);
            }
            else
            {
                xmlNode.InnerText = strElementoConteudo;
            }
        }

        private void criarXml()
        {
            using (var xmlTextWriter = new XmlTextWriter(this.dirCompleto, System.Text.Encoding.UTF8))
            {
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteElementString("root", "");

                xmlTextWriter.Close();
            }
        }

        private XmlDocument getXmlDocument()
        {
            if (!this.booExiste)
            {
                this.criarXml();
            }

            var xmlDocumentResultado = new XmlDocument();

            xmlDocumentResultado.Load(this.dirCompleto);

            return xmlDocumentResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}