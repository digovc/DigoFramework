using System;

namespace DigoFramework.ObjMain
{
    public class Pessoa : ObjMain
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private string _strNomeCompleto;
        private string _strSobrenome;

        public string strNomeCompleto
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _strNomeCompleto = this.strNome;
                    _strNomeCompleto += String.IsNullOrEmpty(this.strSobrenome) ? "" : " ";
                    _strNomeCompleto += this.strSobrenome;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _strNomeCompleto;
            }
        }

        public string strSobrenome
        {
            get
            {
                return _strSobrenome;
            }

            set
            {
                _strSobrenome = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region DESTRUTOR

        #endregion

        #region MÉTODOS

        #endregion

        #region EVENTOS

        #endregion
    }
}