using System;
using System.Diagnostics;

namespace DigoFramework.Arquivo
{
    public class ArquivoExe : ArquivoMain
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

        public ArquivoExe()
            : base(ArquivoMain.EnmMimeTipo.APPLICATION_OCTET_STREAM)
        {
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Retorna a versão do executável.
        /// </summary>
        public string getStrVersao()
        {
            #region Variáveis

            string strResultado;
            FileVersionInfo objFileVersionInfo;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return strResultado;
        }

        #endregion Métodos
    }
}