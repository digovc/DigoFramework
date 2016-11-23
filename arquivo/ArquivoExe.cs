using System.Diagnostics;

namespace DigoFramework.Arquivo
{
    public class ArquivoExe : ArquivoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booPrincipal;
        private string _strVersao;

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

        public string strVersao
        {
            get
            {
                if (_strVersao != null)
                {
                    return _strVersao;
                }

                _strVersao = this.getStrVersao();

                return _strVersao;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.enmContentType = EnmContentType.BIN_APPLICATION_OCTET_STREAM;
        }

        private string getStrVersao()
        {
            if (!this.booExiste)
            {
                return "0.0.0";
            }

            return FileVersionInfo.GetVersionInfo(this.dirCompleto).FileVersion;
        }

        #endregion Métodos
    }
}