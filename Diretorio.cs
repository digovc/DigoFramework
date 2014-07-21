using System;

namespace DigoFramework
{
    public class Diretorio : Objeto
    {
        #region CONSTANTES

        #endregion

        #region  ATRIBUTOS

        private string _dirDiretorio;

        public string dirDiretorio
        {
            get
            {
                return _dirDiretorio;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _dirDiretorio = value;
                    System.IO.Directory.CreateDirectory(_dirDiretorio);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}