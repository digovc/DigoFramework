using System;

namespace DigoFramework.ObjMain
{
    public class Pessoa : ObjMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private string _strNomeCompleto;
        private string _strSobrenome;

        public string strNomeCompleto
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        #endregion CONSTRUTORES

        #region DESTRUTOR

        #endregion DESTRUTOR

        #region MÉTODOS

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}