using DigoFramework.arquivo;

namespace DigoFramework.google
{
    public class ContaServico : Conta
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private Arquivo _arqPkcs12;
        public Arquivo arqPkcs12
        {
            get
            {
                if (_arqPkcs12 == null)
                {
                    return this.criaArqPkcs12();
                }
                return _arqPkcs12;
            }
            set { _arqPkcs12 = value; }
        }

        #endregion

        #region CONSTRUTORES
        #endregion

        #region MÉTODOS

        private Arquivo criaArqPkcs12()
        {
            #region VARIÁVEIS

            ArquivoDiverso objArquivo = new ArquivoDiverso(Arquivo.EnmMimeTipo.TEXT_PLAIN);

            #endregion

            #region AÇÕES
            
            objArquivo.strNome = "f0ad0bc2d0de965987ac3eb733ea0551dd92784e-privatekey.p12";
            objArquivo.dir = System.IO.Path.GetTempPath();
            System.IO.File.Copy("GoogleApi/GoogleKey", objArquivo.dirCompleto, true);
            return objArquivo;

            #endregion
        }

        #endregion

        #region EVENTOS
        #endregion
    }
}
