using System;

namespace DigoFramework
{
    public class Diretorio : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirDiretorio;

        public string dirDiretorio
        {
            get
            {
                return _dirDiretorio;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}