using System.Diagnostics;

namespace DigoFramework.Arquivo
{
    public class ArquivoExe : ArquivoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booPrincipal;

        public bool booPrincipal
        {
            get
            {
                return _booPrincipal;
            }

            set
            {
                _booPrincipal = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Retorna a versão do executável.
        /// </summary>
        public string getStrVersao()
        {
            FileVersionInfo objFileVersionInfo = FileVersionInfo.GetVersionInfo(this.dirCompleto);

            return objFileVersionInfo.FileVersion;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.enmContentType = EnmContentType.BIN_APPLICATION_OCTET_STREAM;
        }

        #endregion Métodos
    }
}