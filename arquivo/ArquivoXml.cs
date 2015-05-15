using System;
using System.Xml;

namespace DigoFramework.Arquivo
{
    public class ArquivoXml : ArquivoMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private XmlDocument _xmlDocument;

        private XmlDocument xmlDocument
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!this.booExiste)
                    {
                        this.criarXml();
                    }

                    if (_xmlDocument != null)
                    {
                        return _xmlDocument;
                    }

                    _xmlDocument = new XmlDocument();
                    _xmlDocument.Load(this.dirCompleto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _xmlDocument;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public ArquivoXml()
            : base(ArquivoMain.EnmMimeTipo.TEXT_XML)
        {
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        /// <summary>
        /// Adiciona um "node" ao arquivo XML.
        /// </summary>
        public void addNode(string strNodeNome, string strNodeConteudo = "0", string strPaiNode = "root")
        {
            #region VARIÁVEIS

            XmlNode xmlNodeFilho;
            XmlNode xmlNodePai;
            XmlNode xmlNodeRoot;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                xmlNodeRoot = this.xmlDocument.GetElementsByTagName("root").Item(0);

                if (xmlNodeRoot == null)
                {
                    this.deletar();
                    this.criarXml();
                }

                xmlNodeFilho = this.xmlDocument.CreateElement(strNodeNome);
                xmlNodeFilho.InnerText = strNodeConteudo;

                xmlNodePai = this.xmlDocument.GetElementsByTagName(strPaiNode).Item(0);
                xmlNodePai.AppendChild(xmlNodeFilho);

                this.xmlDocument.Save(this.dirCompleto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Adiciona um "xmlElemente" ao arquivo XMl atual.
        /// </summary>
        public void addXmlElemento(XmlElement xmlElement)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.xmlDocument.AppendChild(xmlElement);
                this.xmlDocument.Save(this.dirCompleto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public bool getBooElemento(string strElementoNome, bool booValorDefault = false)
        {
            #region VARIÁVEIS

            bool booResultado = false;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                booResultado = this.getIntElemento(strElementoNome, booValorDefault ? 1 : 0).Equals(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return booResultado;
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public decimal getDecElemento(string strElementoNome, decimal decValorDefault = -1)
        {
            #region VARIÁVEIS

            decimal decResultado = -1;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                decResultado = Convert.ToDecimal(this.getStrElemento(strElementoNome, decValorDefault.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return decResultado;
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public DateTime getDttElemento(string strElementoNome, DateTime dttValorDefault)
        {
            #region VARIÁVEIS

            DateTime dttResultado = DateTime.MinValue;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                dttResultado = Convert.ToDateTime(this.getStrElemento(strElementoNome, dttValorDefault.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return dttResultado;
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public int getIntElemento(string strElementoNome, int intValorDefault = -1)
        {
            #region VARIÁVEIS

            int intResultado = -1;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                intResultado = Convert.ToInt32(this.getStrElemento(strElementoNome, intValorDefault.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return intResultado;
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public string getStrElemento(string strElementoNome, string strValorDefault = "-1")
        {
            #region VARIÁVEIS

            XmlNode objXmlNode = null;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
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

                    throw new Erro("Erro ao ler ArquivoMain XML.", ex, Erro.ErroTipo.ARQUIVO_XML);
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
            }
            catch (Exception ex)
            {
                throw new Erro("Erro ao ler ArquivoMain XML.", ex, Erro.ErroTipo.ARQUIVO_XML);
            }

            #endregion AÇÕES

            return objXmlNode.InnerText;
        }

        /// <summary>
        /// Retorna um "xmlNodeList" com a lista de "node" dentro do arquivo XMl.
        /// </summary>
        public XmlNodeList getXmlNodeList()
        {
            #region VARIÁVEIS

            XmlNodeList xmlNodeListResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                xmlNodeListResultado = this.xmlDocument.SelectSingleNode("root").ChildNodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return xmlNodeListResultado;
        }

        /// <summary>
        /// Atualiza o valor da "tag" no arquivo "XML".
        /// </summary>
        /// <param name="strElementoNome">Nome do "node" que vai ser atualizado.</param>
        /// <param name="booElementoConteudo">Valor que o node vai ter.</param>
        public void setBooElemento(string strElementoNome, bool booElementoConteudo)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.setIntElemento(strElementoNome, booElementoConteudo ? 1 : 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
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
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (dttElementoConteudo == null)
                {
                    dttElementoConteudo = DateTime.MinValue;
                }

                this.setStrElemento(strElementoNome, dttElementoConteudo.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
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
        /// <param name="strElementoConteudo">Valor que o node vai ter.</param>
        public void setStrElemento(string strElementoNome, string strElementoConteudo)
        {
            #region VARIÁVEIS

            XmlNode xmlNode;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                xmlNode = this.xmlDocument.SelectSingleNode(strElementoNome);

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
                    this.xmlDocument.Save(this.dirCompleto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.xmlDocument.Load(this.dirCompleto);
            }

            #endregion AÇÕES
        }

        private void criarXml()
        {
            #region VARIÁVEIS

            XmlTextWriter xmlTextWriter;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                xmlTextWriter = new XmlTextWriter(this.dirCompleto, System.Text.Encoding.UTF8);
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteElementString("root", "");
                xmlTextWriter.Close();

                this.xmlDocument.Load(this.dirCompleto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}