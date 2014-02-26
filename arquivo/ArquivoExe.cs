using System;

namespace DigoFramework.arquivo
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

        public ArquivoExe() : base(Arquivo.EnmMimeTipo.APPLICATION_OCTET_STREAM) { }

        #endregion

        #region MÉTODOS
        #endregion
    }
}
