using System;

namespace DigoFramework.ObjMain
{
    public class Pessoa : ObjMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _strNomeCompleto;
        private string _strSobrenome;

        public string strNomeCompleto
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strNomeCompleto = this.strNome;
                    _strNomeCompleto += string.IsNullOrEmpty(this.strSobrenome) ? "" : " ";
                    _strNomeCompleto += this.strSobrenome;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}