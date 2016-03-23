using System;
using DigoFramework.Anotacao;
using Newtonsoft.Json;

namespace DigoFramework
{
    public abstract class Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static int _intObjetoIdStatic;

        private int _intObjetoId;
        private string _strDescricao;
        private string _strNome;
        private string _strNomeExibicao;
        private string _strNomeSimplificado;

        [AppConfigInvisivel]
        public int intObjetoId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_intObjetoId > 0)
                    {
                        return _intObjetoId;
                    }

                    _intObjetoId = Objeto.intObjetoIdStatic++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _intObjetoId;
            }
        }

        [AppConfigInvisivel]
        public string strDescricao
        {
            get
            {
                return _strDescricao;
            }

            set
            {
                _strDescricao = value;
            }
        }

        [AppConfigInvisivel]
        [JsonProperty(PropertyName = "_strNome")]
        public string strNome
        {
            get
            {
                return _strNome;
            }

            set
            {
                _strNome = value;
            }
        }

        [AppConfigInvisivel]
        public string strNomeExibicao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (string.IsNullOrEmpty(_strNomeExibicao))
                    {
                        return Utils.getStrPrimeiraMaiuscula(this.strNome);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strNomeExibicao;
            }

            set
            {
                _strNomeExibicao = value;
            }
        }

        [AppConfigInvisivel]
        public string strNomeSimplificado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strNomeSimplificado = Utils.simplificar(this.strNome);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strNomeSimplificado;
            }
        }

        private static int intObjetoIdStatic
        {
            get
            {
                return _intObjetoIdStatic;
            }

            set
            {
                _intObjetoIdStatic = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método vazio que não executa nenhuma ação.
        /// </summary>
        public void foo()
        {
            return;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}