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
                this.objXmlDocument.Load(_dirDiretorio);
            }
        }

        private XmlDocument _objXmlDocument = new XmlDocument();
        public XmlDocument objXmlDocument { get { return _objXmlDocument; } set { _objXmlDocument = value; } }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        public String getStrNodeValor(String strNodeNome)
        {
            #region VARIÁVEIS

            XmlTextReader objXmlTextReader = new XmlTextReader(this.dirDiretorio);

            #endregion

            #region AÇÕES

            throw new NotImplementedException();

            #endregion
        }

        #endregion
    }
}