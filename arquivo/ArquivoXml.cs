using System;
using System.Xml;

namespace DigoFramework.Arquivo
{
    public class ArquivoXml : ArquivoMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private XmlDocument _xmlDocument;

        private XmlDocument xmlDocument
        {
            get
            {
                #region VARIÁVEIS

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _xmlDocument;
            }
        }

        #endregion Atributos

        #region CONSTRUTORES

        public ArquivoXml()
            : base(ArquivoMain.EnmMimeTipo.TEXT_XML)
        {
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Adiciona um "node" ao arquivo XML.
        /// </summary>
        public void addNode(string strNodeNome, string strNodeConteudo = "0", string strPaiNode = "root")
        {
            #region VARIÁVEIS

            XmlNode xmlNodeFilho;
            XmlNode xmlNodePai;
            XmlNode xmlNodeRoot;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Adiciona um "xmlElemente" ao arquivo XMl atual.
        /// </summary>
        public void addXmlElemento(XmlElement xmlElement)
        {
            #region VARIÁVEIS

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Retorna o valor contido no "node" com o nome passado por parâmetro. Caso este "node" não
        /// exista, ele será criado com o valor "default".
        /// </summary>
        public bool getBooElemento(string strElementoNome, bool booValorDefault = false)
        {
            #region VARIÁVEIS

            bool booResultado = false;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

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

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

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

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return dttResultado;
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
            #region VARIÁVEIS

            XmlNode objXmlNode = null;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return objXmlNode.InnerText;
        }

        /// <summary>
        /// Retorna um "xmlNodeList" com a lista de "node" dentro do arquivo XMl.
        /// </summary>
        public XmlNodeList getXmlNodeList()
        {
            #region VARIÁVEIS

            XmlNodeList xmlNodeListResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

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

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
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

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
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
            #region VARIÁVEIS

            XmlNode xmlNode;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void criarXml()
        {
            #region VARIÁVEIS

            XmlTextWriter xmlTextWriter;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}