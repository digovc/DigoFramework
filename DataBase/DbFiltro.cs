using System;

namespace DigoFramework.DataBase
{
    public class DbFiltro : Objeto
    {
        #region CONSTANTES

        public enum EnmCondicao
        {
            DIFERENTE,
            IGUAL,
            MAIOR,
            MAIOR_IGUAL,
            MENOR,
            MENOR_IGUAL
        }

        #endregion CONSTANTES

        #region ATRIBUTOS

        private bool _booAnd = true;
        private DbColuna _cln;
        private EnmCondicao _enmCondicao = EnmCondicao.IGUAL;
        private string _sqlFiltro;
        private string _strFiltro;
        private string _strOperador;

        public bool booAnd
        {
            get
            {
                return _booAnd;
            }

            set
            {
                _booAnd = value;
            }
        }

        public DbColuna cln
        {
            get
            {
                return _cln;
            }

            set
            {
                _cln = value;
            }
        }

        public EnmCondicao enmCondicao
        {
            get
            {
                return _enmCondicao;
            }

            set
            {
                _enmCondicao = value;
            }
        }

        public string sqlFiltro
        {
            get
            {
                return _sqlFiltro;
            }

            set
            {
                _sqlFiltro = value;
            }
        }

        public string strFiltro
        {
            get
            {
                return _strFiltro;
            }

            set
            {
                _strFiltro = value;
            }
        }

        private string strOperador
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    switch (enmCondicao)
                    {
                        case EnmCondicao.DIFERENTE:
                            _strOperador = "<>";
                            break;

                        case EnmCondicao.IGUAL:
                            _strOperador = "=";
                            break;

                        case EnmCondicao.MAIOR:
                            _strOperador = ">";
                            break;

                        case EnmCondicao.MAIOR_IGUAL:
                            _strOperador = ">=";
                            break;

                        case EnmCondicao.MENOR:
                            _strOperador = "<";
                            break;

                        case EnmCondicao.MENOR_IGUAL:
                            _strOperador = "<=";
                            break;

                        default:
                            _strOperador = "=";
                            break;
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

                return _strOperador;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public DbFiltro(string sqlFiltro)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.sqlFiltro = sqlFiltro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        public DbFiltro(DbColuna cln, string strFiltro)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.cln = cln;
                this.strFiltro = strFiltro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        public DbFiltro(DbColuna cln, double dblFiltro)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.cln = cln;
                this.strFiltro = dblFiltro.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        public DbFiltro(DbColuna cln, int intFiltro)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.cln = cln;
                this.strFiltro = intFiltro.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region DESTRUTOR

        #endregion DESTRUTOR

        #region MÉTODOS

        /// <summary>
        /// Retorna uma "string" com o filtro formatado para ser usado no "select".
        /// </summary>
        public string getStrFiltroFormatado(Boolean booPrimeiroTermo = false)
        {
            #region VARIÁVEIS

            string strResultado = Utils.STR_VAZIA;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (!String.IsNullOrEmpty(this.sqlFiltro))
                {
                    strResultado = this.sqlFiltro;
                }
                else
                {
                    strResultado = Utils.STR_VAZIA;
                    strResultado += !booPrimeiroTermo ? (this.booAnd ? "and " : "or ") : "";
                    strResultado += this.cln.strNomeSimplificado;
                    strResultado += this.strOperador;
                    strResultado += "'";
                    strResultado += this.strFiltro;
                    strResultado += "'";
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

            return strResultado;
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}