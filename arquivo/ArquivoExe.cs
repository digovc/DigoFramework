using System;
using System.Diagnostics;

namespace DigoFramework.Arquivo
{
    public class ArquivoExe : ArquivoMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public ArquivoExe()
            : base(ArquivoMain.EnmMimeTipo.APPLICATION_OCTET_STREAM)
        {
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        /// <summary>
        /// Retorna a versão do executável.
        /// </summary>
        public string getStrVersao()
        {
            #region VARIÁVEIS

            string strResultado;
            FileVersionInfo objFileVersionInfo;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                objFileVersionInfo = FileVersionInfo.GetVersionInfo(this.dirCompleto);
                strResultado = objFileVersionInfo.FileVersion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return strResultado;
        }

        #endregion MÉTODOS
    }
}