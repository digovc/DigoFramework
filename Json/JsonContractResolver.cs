using System;
using Newtonsoft.Json.Serialization;

namespace DigoFramework.Json
{
    internal class JsonContractResolver : DefaultContractResolver
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override string ResolvePropertyName(string strPropertyName)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strPropertyName))
                {
                    return base.ResolvePropertyName(strPropertyName);
                }

                strPropertyName = "_" + strPropertyName;

                return base.ResolvePropertyName(strPropertyName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}