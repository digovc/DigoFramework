using System;

namespace DigoFramework.ObjMain
{
    public class Bairro : ObjMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private Cidade _objCidade;

        public Cidade objCidade
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_objCidade != null)
                    {
                        return _objCidade;
                    }

                    _objCidade = new Cidade();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _objCidade;
            }

            set
            {
                _objCidade = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS
    }
}