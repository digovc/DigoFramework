using System;

namespace DigoFramework.Arquivos
{
    public class ArquivoExe : Arquivo
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Boolean _booPrincipal = false;
        public Boolean booPrincipal { get { return _booPrincipal; } set { _booPrincipal = value; } }

        #endregion

        #region CONSTRUTORES

        public ArquivoExe()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES


            #endregion
        }

        #endregion

        #region MÉTODOS

        protected override void setInMimeType()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objMimeTipo = Arquivo.MimeTipo.APPLICATION_OCTET_STREAM;

            #endregion
        }

        #endregion
    }
}
