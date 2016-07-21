using System;
using Newtonsoft.Json;

namespace DigoFramework.Json
{
    public sealed class Json
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return _i;
                    }

                    _i = new Json();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _i;
            }
        }

        private JsonSerializerSettings cfg
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cfg != null)
                    {
                        return _cfg;
                    }

                    _cfg = this.getCfg();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _cfg;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Converte um objeto no formato de JSON no text.
        /// </summary>
        public T fromJson<T>(string jsn)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(jsn))
                {
                    return default(T);
                }

                return JsonConvert.DeserializeObject<T>(jsn, this.cfg);
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

        /// <summary>
        /// Serializa a instância do objeto para o formato JSON.
        /// </summary>
        /// <param name="obj">Objeto que será convertido para JSON.</param>
        /// <returns>Retorna o texto contendo o objeto convertido para JSON.</returns>
        public string toJson(object obj)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (obj == null)
                {
                    return null;
                }

                return JsonConvert.SerializeObject(obj, this.cfg);
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

        private JsonSerializerSettings getCfg()
        {
            #region Variáveis

            JsonSerializerSettings cfgResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                cfgResultado = new JsonSerializerSettings();

                cfgResultado.ContractResolver = new JsonContractResolver();

                return cfgResultado;
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