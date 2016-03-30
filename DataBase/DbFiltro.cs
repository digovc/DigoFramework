using System;

namespace DigoFramework.DataBase
{
    public class DbFiltro : Objeto
    {
        #region Constantes

        public enum EnmCondicao
        {
            DIFERENTE,
            IGUAL,
            MAIOR,
            MAIOR_IGUAL,
            MENOR,
            MENOR_IGUAL
        }

        #endregion Constantes

        #region Atributos

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _strOperador;
            }
        }

        #endregion Atributos

        #region Construtores

        public DbFiltro(string sqlFiltro)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        public DbFiltro(DbColuna cln, string strFiltro)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        public DbFiltro(DbColuna cln, decimal decFiltro)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.cln = cln;
                this.strFiltro = decFiltro.ToString();
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

        public DbFiltro(DbColuna cln, int intFiltro)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Retorna uma "string" com o filtro formatado para ser usado no "select".
        /// </summary>
        public string getStrFiltroFormatado(bool booPrimeiroTermo = false)
        {
            #region Variáveis

            string strResultado = string.Empty;

            #endregion Variáveis

            #region Ações

            try
            {
                if (!string.IsNullOrEmpty(this.sqlFiltro))
                {
                    strResultado = this.sqlFiltro;
                }
                else
                {
                    strResultado = string.Empty;

                    strResultado += !booPrimeiroTermo ? (this.booAnd ? "and " : "or ") : "";
                    strResultado += this.cln.strNomeSimplificado;
                    strResultado += " ";
                    strResultado += this.strOperador;
                    strResultado += " '";
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

            #endregion Ações

            return strResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}