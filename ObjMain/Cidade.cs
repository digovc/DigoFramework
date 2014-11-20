using System;

namespace DigoFramework.ObjMain
{
    public class Cidade : ObjMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private Pais _objPais;

        public Pais objPais
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

                return _objPais;
            }

            set
            {
                _objPais = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS
    }
}