using System;
using System.Xml;

namespace DigoFramework.Arquivos
{
    public class ArquivoXml : Arquivo
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private XmlDocument _objXmlDocument;
        public XmlDocument objXmlDocument
        {
            get
            {
                if (!this.booExiste)
                {
                    XmlTextWriter objXmlTextWriter = new XmlTextWriter(this.dirDiretorioCompleto, System.Text.Encoding.UTF8);
                    objXmlTextWriter.WriteStartDocument();
                    objXmlTextWriter.WriteElementString("DigoFramework", "");
                    objXmlTextWriter.Close();
                }
                if (_objXmlDocument == null)
                {
                    _objXmlDocument = new XmlDocument();
                    _objXmlDocument.Load(this.dirDiretorioCompleto);
                }
                return _objXmlDocument;
            }
        }

        #endregion

        #region CONSTRUTORES

        public ArquivoXml()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES


            #endregion
        }

        #endregion

        #region MÉTODOS

        // TODO: Criar possibilidade de adicionar node dentro de node pai
        public void addNode(String strNodeNome, String strNodeConteudo = "0", String strNodePai = "")
        {
            #region VARIÁVEIS

            XmlElement objXmlElement = this.objXmlDocument.CreateElement(strNodeNome);
            XmlText objXmlText = this.objXmlDocument.CreateTextNode(strNodeConteudo);

            #endregion

            #region AÇÕES

            try
            {
                this.objXmlDocument.DocumentElement.AppendChild(objXmlElement);
                this.objXmlDocument.DocumentElement.LastChild.AppendChild(objXmlText);
                this.objXmlDocument.Save(this.dirDiretorioCompleto);
            }
            catch (Exception ex)
            {
                new Erro("Erro ao tentar criar elemento dentro do Arquivo XML.", ex, Erro.ErroTipo.ArquivoXml);
            }

            #endregion
        }

        public String getStrElementoConteudo(String strElementoNome, String strValorDefault = "-1")
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            try
            {
                XmlNode objXmlNode = this.objXmlDocument.SelectSingleNode(strElementoNome);
                if (objXmlNode == null)
                {
                    objXmlNode = this.objXmlDocument.SelectSingleNode("DigoFramework/" + strElementoNome);
                }
                if (objXmlNode == null)
                {
                    this.addNode(strElementoNome, strValorDefault);
                    return strValorDefault;
                }

                return objXmlNode.InnerText;
            }
            catch (Exception ex)
            {
                throw new Erro("Erro ao ler Arquivo XML.", ex, Erro.ErroTipo.ArquivoXml);
            }

            #endregion
        }

        protected override void setInMimeType()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objMimeTipo = Arquivo.MimeTipo.APPLICATION_XML;

            #endregion
        }

        public void setStrElementoConteudo(String strElementoNome, String strElementoConteudo)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            try
            {
                XmlNode objXmlNode = this.objXmlDocument.SelectSingleNode(strElementoNome);
                if (objXmlNode == null)
                {
                    objXmlNode = objXmlDocument.SelectSingleNode("DigoFramework/" + strElementoNome);
                }
                if (objXmlNode == null)
                {
                    this.addNode(strElementoNome, strElementoConteudo);
                }
                else
                {
                    objXmlNode.InnerText = strElementoConteudo;
                    this.objXmlDocument.Save(this.dirDiretorioCompleto);
                }
            }
            catch (Exception ex)
            {
                new Erro("Erro ao escrever no Arquivo XML.", ex, Erro.ErroTipo.ArquivoXml);
            }

            #endregion
        }

        #endregion
    }
}