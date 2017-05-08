using System;

namespace DigoFramework.ObjMain
{
    public class Cidade : ObjMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Pais _objPais;

        public Pais objPais
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _objPais;
            }

            set
            {
                _objPais = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos
    }
}