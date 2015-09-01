using System;

namespace DigoFramework.ObjMain
{
    public class Bairro : ObjMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Cidade _objCidade;

        public Cidade objCidade
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _objCidade;
            }

            set
            {
                _objCidade = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos
    }
}