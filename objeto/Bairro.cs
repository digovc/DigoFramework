using System;

namespace DigoFramework.objeto
{
    public class Bairro : ObjMain
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Cidade _objCidade;

        public Cidade objCidade
        {
            get
            {
                #region VARIÁVEIS

                #endregion

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

                #endregion

                return _objCidade;
            }

            set
            {
                _objCidade = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}