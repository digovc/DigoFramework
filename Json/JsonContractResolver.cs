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
            if (string.IsNullOrEmpty(strPropertyName))
            {
                return base.ResolvePropertyName(strPropertyName);
            }

            strPropertyName = ("_" + strPropertyName);

            return base.ResolvePropertyName(strPropertyName);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}