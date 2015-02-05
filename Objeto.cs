using Newtonsoft.Json;
using System;

namespace DigoFramework
{
    public abstract class Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private static int _intObjetoIdStatic;
        private int _intObjetoId;
        private object _lockCode;
        private string _strDescricao;
        private string _strNome;
        private string _strNomeExibicao;
        private string _strNomeSimplificado;

        public int intObjetoId
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

                return _intObjetoId;
            }
        }

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

        public string strNomeExibicao
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (String.IsNullOrEmpty(_strNomeExibicao))
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

                #endregion AÇÕES

                return _strNomeExibicao;
            }

            set
            {
                _strNomeExibicao = value;
            }
        }

        public string strNomeSimplificado
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _strNomeSimplificado = Utils.simplificarStr(_strNome);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _strNomeSimplificado;
            }
        }

        protected object lockCode
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_lockCode != null)
                    {
                        return _lockCode;
                    }

                    _lockCode = new object();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _lockCode;
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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}