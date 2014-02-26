
using System;
namespace DigoFramework.database
{
    public class DbFiltro : Objeto
    {
        #region CONSTANTES

        public enum EnmCondicao
        {
            DIFERENTE, IGUAL, MAIOR, MAIOR_IGUAL, MENOR, MENOR_IGUAL
        }

        #endregion

        #region ATRIBUTOS

        private Boolean _booAnd = true;
        public Boolean booAnd { get { return _booAnd; } set { _booAnd = value; } }

        private DbColuna _cln;
        public DbColuna cln { get { return _cln; } set { _cln = value; } }

        private EnmCondicao _enmCondicao = EnmCondicao.IGUAL;
        public EnmCondicao enmCondicao { get { return _enmCondicao; } set { _enmCondicao = value; } }

        private String _sqlFiltro;
        public String sqlFiltro { get { return _sqlFiltro; } set { _sqlFiltro = value; } }

        private String _strFiltro;
        public String strFiltro { get { return _strFiltro; } set { _strFiltro = value; } }

        private String _strOperador;
        private String strOperador
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

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

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _strOperador;
            }
        }

        #endregion

        #region CONSTRUTORES

        public DbFiltro(String sqlFiltro)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.sqlFiltro = sqlFiltro;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public DbFiltro(DbColuna cln, String strFiltro)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.cln = cln;
                this.strFiltro = strFiltro;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public DbFiltro(DbColuna cln, double dblFiltro)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.cln = cln;
                this.strFiltro = dblFiltro.ToString();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public DbFiltro(DbColuna cln, int intFiltro)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.cln = cln;
                this.strFiltro = intFiltro.ToString();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        #endregion

        #region DESTRUTOR
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Retorna uma "string" com o filtro formatado para ser usado no "select".
        /// </summary>
        public String getStrFiltroFormatado(Boolean booPrimeiroTermo = false)
        {
            #region VARIÁVEIS

            String strResultado = Utils.STRING_VAZIA;

            #endregion
            try
            {
                #region AÇÕES

                if (!String.IsNullOrEmpty(this.sqlFiltro))
                {
                    strResultado = this.sqlFiltro;
                }
                else
                {

                    strResultado = Utils.STRING_VAZIA;
                    strResultado += !booPrimeiroTermo ? (this.booAnd ? "and " : "or ") : "";
                    strResultado += this.cln.strNomeSimplificado;
                    strResultado += this.strOperador;
                    strResultado += "'";
                    strResultado += this.strFiltro;
                    strResultado += "'";
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;
        }

        #endregion

        #region EVENTOS
        #endregion
    }
}
