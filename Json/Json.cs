using Newtonsoft.Json;

namespace DigoFramework.Json
{
    public class Json
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static Json _i;

        private JsonSerializerSettings _cfg;

        public static Json i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new Json();

                return _i;
            }

            private set
            {
                if (_i != null)
                {
                    return;
                }

                _i = value;
            }
        }

        private JsonSerializerSettings cfg
        {
            get
            {
                if (_cfg != null)
                {
                    return _cfg;
                }

                _cfg = this.getCfg();

                return _cfg;
            }
        }

        #endregion Atributos

        #region Construtores

        protected Json()
        {
            i = this;
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Converte um objeto no formato de JSON no text.
        /// </summary>
        public T fromJson<T>(string jsn)
        {
            if (string.IsNullOrEmpty(jsn))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(jsn, this.cfg);
        }

        /// <summary>
        /// Serializa a instância do objeto para o formato JSON.
        /// </summary>
        /// <param name="obj">Objeto que será convertido para JSON.</param>
        /// <returns>Retorna o texto contendo o objeto convertido para JSON.</returns>
        public string toJson(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            return JsonConvert.SerializeObject(obj, this.cfg);
        }

        protected virtual JsonSerializerSettings getCfg()
        {
            JsonSerializerSettings cfgResultado = new JsonSerializerSettings();

            cfgResultado.ContractResolver = new JsonContractResolver();
            cfgResultado.DateTimeZoneHandling = DateTimeZoneHandling.Local;

            return cfgResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}