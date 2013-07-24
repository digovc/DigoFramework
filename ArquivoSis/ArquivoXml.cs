using System;
using System.Xml;

namespace DigoFramework.ArquivoSis
{
    public class ArquivoXml : Arquivo
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private String _dirDiretorio;
        public override String dirDiretorio
        {
            get { return _dirDiretorio; }
            set
            {
                _dirDiretorio = value;
                if (!System.IO.File.Exists(_dirDiretorio))
                {
                    XmlTextWriter objXmlTextWriter = new XmlTextWriter(_dirDiretorio, System.Text.Encoding.UTF8);
                    objXmlTextWriter.WriteStartDocument();
                    objXmlTextWriter.WriteElementString("DigoFramework", "");
                    objXmlTextWriter.Close();

                }
                this.objXmlDocument.Load(_dirDiretorio);
            }
        }

        private XmlDocument _objXmlDocument = new XmlDocument();
        public XmlDocument objXmlDocument { get { return _objXmlDocument; } set { _objXmlDocument = value; } }

        #endregion

        #region CONSTRUTORES

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

            this.objXmlDocument.DocumentElement.AppendChild(objXmlElement);
            this.objXmlDocument.DocumentElement.LastChild.AppendChild(objXmlText);
            this.objXmlDocument.Save(this.dirDiretorio);

            #endregion
        }

        public String getStrElementoConteudo(String strElementoNome, String strValorDefault = "-1")
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            try
            {
                XmlNode objXmlNode = objXmlDocument.SelectSingleNode(strElementoNome);
                if (objXmlNode == null)
                {
                    objXmlNode = objXmlDocument.SelectSingleNode("DigoFramework/" + strElementoNome);
                }
                if (objXmlNode == null)
                {
                    objXmlNode.InnerText = strValorDefault;
                }

                return objXmlNode.InnerText;
            }
            catch (Exception ex)
            {
                throw new Erro("Erro ao ler Arquivo XML.", ex, Erro.ErroTipo.ArquivoXml);
            }

            #endregion
        }

        public override void salvar()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES
            #endregion
        }

        public void setStrElementoConteudo(String strElementoNome, String strElementoConteudo)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            try
            {
                XmlNode objXmlNode = objXmlDocument.SelectSingleNode(strElementoNome);
                if (objXmlNode == null)
                {
                    objXmlNode = objXmlDocument.SelectSingleNode("DigoFramework/" + strElementoNome);
                }
                objXmlNode.InnerText = strElementoConteudo;
                this.objXmlDocument.Save(this.dirDiretorio);
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