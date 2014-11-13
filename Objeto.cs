using System;

namespace DigoFramework
{
    public abstract class Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private static int _intIndex;
        private int _intId;
        private object _lockCode;
        private string _strDescricao;
        private string _strNome;
        private string _strNomeExibicao;
        private string _strNomeSimplificado;

        public int intId
        {
            get
            {
                return _intId;
            }

            set
            {
                _intId = value;
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

                #endregion

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

                #endregion

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

                #endregion

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

                #endregion

                return _strNomeSimplificado;
            }
        }

        protected object lockCode
        {
            get
            {
                #region VARIÁVEIS

                #endregion

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

                #endregion

                return _lockCode;
            }
        }

        private static int intIndex
        {
            get
            {
                return _intIndex;
            }

            set
            {
                _intIndex = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        public Objeto()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.intId = ++Objeto.intIndex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        #endregion

        #region MÉTODOS

        #endregion
    }
}