using System;
using System.Diagnostics;

namespace DigoFramework.arquivo
{
    public class ArquivoExe : Arquivo
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Boolean _booPrincipal = false;

        public Boolean booPrincipal
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

        #endregion

        #region CONSTRUTORES

        public ArquivoExe()
            : base(Arquivo.EnmMimeTipo.APPLICATION_OCTET_STREAM)
        {
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Retorna a versão do executável.
        /// </summary>
        public String getStrVersao()
        {
            #region VARIÁVEIS

            String strResultado;
            FileVersionInfo objFileVersionInfo;

            #endregion

            try
            {
                #region AÇÕES

                objFileVersionInfo = FileVersionInfo.GetVersionInfo(this.dirCompleto);
                strResultado = objFileVersionInfo.FileVersion;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;
        }

        #endregion
    }
}