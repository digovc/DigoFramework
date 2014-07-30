using System;

namespace DigoFramework.ObjMain
{
    public class Cidade : ObjMain
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Pais _objPais;

        public Pais objPais
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_objPais != null)
                    {
                        return _objPais;
                    }

                    _objPais = new Pais();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _objPais;
            }

            set
            {
                _objPais = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}