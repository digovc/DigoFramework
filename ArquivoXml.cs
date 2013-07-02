using System;
using System.Xml;

namespace DigoFramework
{
    public class ArquivoXml : Arquivo
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

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

        public String getStrElementoConteudo(String strElementoNome)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            XmlNode objXmlNode = objXmlDocument.SelectSingleNode(strElementoNome);
            if (objXmlNode == null)
            {
                objXmlNode = objXmlDocument.SelectSingleNode("DigoFramework/" + strElementoNome);
            }
            return objXmlNode.InnerText;

            #endregion
        }

        public void setStrElementoConteudo(String strElementoNome, String strElementoConteudo)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            XmlNode objXmlNode = objXmlDocument.SelectSingleNode(strElementoNome);
            if (objXmlNode == null)
            {
                objXmlNode = objXmlDocument.SelectSingleNode("DigoFramework/" + strElementoNome);
            }
            objXmlNode.InnerText = strElementoConteudo;
            this.objXmlDocument.Save(this.dirDiretorio);

            #endregion
        }

        #endregion
    }
}