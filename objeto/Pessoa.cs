using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigoFramework.objeto
{
    public class Pessoa : ObjMain
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private String _strNomeCompleto;
        public String strNomeCompleto
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _strNomeCompleto = this.strNome;
                    _strNomeCompleto += String.IsNullOrEmpty(this.strSobrenome) ? "" : " ";
                    _strNomeCompleto += this.strSobrenome;

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _strNomeCompleto;
            }
        }

        private String _strSobrenome;
        public String strSobrenome { get { return _strSobrenome; } set { _strSobrenome = value; } }

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
