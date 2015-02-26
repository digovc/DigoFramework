using System;
using System.Collections.Generic;
using System.Data;

namespace DigoFramework.DataBase
{
    public class DbColuna : Objeto, IComparable<DbColuna>
    {
        #region CONSTANTES

        public enum EnmGrupo
        {
            ALFANUMERICO,
            BOOLEANO,
            TEMPORAL,
            NUMERICO
        };

        public enum EnmTipo
        {
            SMALLINT,
            INTEGER,
            BIGINT,
            DECIMAL,
            NUMERIC,
            REAL,
            DOUBLE,
            SERIAL,
            BIGSERIAL,
            MONEY,
            VARCHAR,
            CHAR,
            TEXT,
            TIMESTAMP_WITHOUT_TIME_ZONE,
            TIMESTAMP_WITH_TIME_ZONE,
            INTERVAL,
            DATE,
            TIME_WITHOUT_TIME_ZONE,
            TIME_WITH_TIME_ZONE,
            BOOLEAN,
            PASSWORD,
            ENUM
        };

        #endregion CONSTANTES

        #region ATRIBUTOS

        private bool _booChavePrimaria;
        private bool _booNome;
        private bool _booObrigatorio;
        private bool _booSomenteLeitura;
        private bool _booVisivelCadastro = true;
        private bool _booVisivelConsulta = true;
        private EnmTipo _enmTipo;
        private int _intOrdem;
        private int _intTamanho;
        private List<string> _lstStrOpcoes;
        private DbColuna _objColunaReferencia;
        private DbColuna _objColunaReferenciaVisual;
        private DbView _objDbViewReferencia;
        private string _strMascara;
        private string _strSqlValor;
        private string _strValor;
        private string _strValorPadrao;
        private DbTabela _tbl;

        public bool booChavePrimaria
        {
            get
            {
                return _booChavePrimaria;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (value)
                    {
                        this.tbl.clnChavePrimaria = null;
                        foreach (DbColuna cln in this.tbl.lstCln)
                        {
                            cln._booChavePrimaria = false;
                        }
                    }

                    _booChavePrimaria = value;
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
        }

        public bool booNome
        {
            get
            {
                return _booNome;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (value)
                    {
                        this.tbl.clnNome = null;

                        foreach (DbColuna cln in this.tbl.lstCln)
                        {
                            cln._booNome = false;
                        }
                    }

                    _booNome = value;
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
        }

        public bool booObrigatorio
        {
            get
            {
                return _booObrigatorio;
            }

            set
            {
                _booObrigatorio = value;
            }
        }

        public bool booSomenteLeitura
        {
            get
            {
                return _booSomenteLeitura;
            }

            set
            {
                _booSomenteLeitura = value;
            }
        }

        public bool booValor
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    switch (this.strValor.ToLower())
                    {
                        case "true":
                        case "t":
                        case "sim":
                        case "s":
                        case "1":
                            return true;

                        case "false":
                        case "f":
                        case "não":
                        case "nao":
                        case "n":
                        case "0":
                            return false;

                        default:
                            return false;
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

                return Convert.ToBoolean(strValor);
            }

            set
            {
                strValor = Convert.ToString(value);
            }
        }

        public bool booVisivelCadastro
        {
            get
            {
                return _booVisivelCadastro;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _booVisivelCadastro = value;
                    this.tbl.lstClnVisivelCadastro = null;
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
        }

        public bool booVisivelConsulta
        {
            get
            {
                return _booVisivelConsulta;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _booVisivelConsulta = value;
                    this.tbl.lstClnVisivelConsulta = null;
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
        }

        public double dblValor
        {
            get
            {
                #region VARIÁVEIS

                double dblResultado;

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    dblResultado = Convert.ToDouble(strValor);
                }
                catch
                {
                    dblResultado = 0;
                }
                finally
                {
                }

                return dblResultado;

                #endregion AÇÕES
            }

            set
            {
                strValor = Convert.ToString(dblValor);
            }
        }

        public DateTime dttValor
        {
            get
            {
                return Convert.ToDateTime(strValor);
            }

            set
            {
                strValor = value.ToString();
            }
        }

        public EnmGrupo enmGrupo
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    switch (this.enmTipo)
                    {
                        case EnmTipo.SMALLINT:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.INTEGER:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.BIGINT:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.BOOLEAN:
                            return EnmGrupo.BOOLEANO;

                        case EnmTipo.DECIMAL:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.NUMERIC:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.REAL:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.DOUBLE:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.SERIAL:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.BIGSERIAL:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.MONEY:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.VARCHAR:
                            return EnmGrupo.ALFANUMERICO;

                        case EnmTipo.CHAR:
                            return EnmGrupo.ALFANUMERICO;

                        case EnmTipo.TEXT:
                            return EnmGrupo.ALFANUMERICO;

                        case EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE:
                            return EnmGrupo.TEMPORAL;

                        case EnmTipo.TIMESTAMP_WITH_TIME_ZONE:
                            return EnmGrupo.TEMPORAL;

                        case EnmTipo.INTERVAL:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.DATE:
                            return EnmGrupo.TEMPORAL;

                        case EnmTipo.TIME_WITHOUT_TIME_ZONE:
                            return EnmGrupo.TEMPORAL;

                        case EnmTipo.TIME_WITH_TIME_ZONE:
                            return EnmGrupo.TEMPORAL;

                        case EnmTipo.PASSWORD:
                            return EnmGrupo.ALFANUMERICO;

                        case EnmTipo.ENUM:
                            return EnmGrupo.ALFANUMERICO;

                        default:
                            return EnmGrupo.ALFANUMERICO;
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
            }
        }

        public EnmTipo enmTipo
        {
            get
            {
                return _enmTipo;
            }

            set
            {
                _enmTipo = value;
            }
        }

        public int intOrdem
        {
            get
            {
                return _intOrdem;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    foreach (DbColuna objDbColuna in this.tbl.lstCln)
                    {
                        if (value == objDbColuna.intOrdem)
                        {
                            value = objDbColuna.intOrdem + 1;
                        }
                    }

                    _intOrdem = value;
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
        }

        public int intTamanho
        {
            get
            {
                return _intTamanho;
            }

            set
            {
                _intTamanho = value;
            }
        }

        public int intValor
        {
            get
            {
                #region VARIÁVEIS

                int intResultado;

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    intResultado = Convert.ToInt32(strValor);
                }
                catch
                {
                    intResultado = 0;
                }
                finally
                {
                }

                #endregion AÇÕES

                return intResultado;
            }

            set
            {
                strValor = Convert.ToString(value);
            }
        }

        public List<string> lstStrOpcoes
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_lstStrOpcoes != null)
                    {
                        return _lstStrOpcoes;
                    }

                    _lstStrOpcoes = new List<string>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _lstStrOpcoes;
            }

            set
            {
                _lstStrOpcoes = value;
            }
        }

        public DbColuna objColunaReferencia
        {
            get
            {
                return _objColunaReferencia;
            }

            set
            {
                _objColunaReferencia = value;
            }
        }

        public DbColuna objColunaReferenciaVisual
        {
            get
            {
                return _objColunaReferenciaVisual;
            }

            set
            {
                _objColunaReferenciaVisual = value;
            }
        }

        public DbView objDbViewReferencia
        {
            get
            {
                return _objDbViewReferencia;
            }

            set
            {
                _objDbViewReferencia = value;
            }
        }

        public string strMascara
        {
            get
            {
                return _strMascara;
            }

            set
            {
                _strMascara = value;
            }
        }

        public string strSqlValor
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    switch (this.enmGrupo)
                    {
                        case DbColuna.EnmGrupo.ALFANUMERICO:
                            _strSqlValor = "'" + this.strValor + "'";
                            break;

                        case DbColuna.EnmGrupo.BOOLEANO:
                            if (this.booValor)
                            {
                                _strSqlValor = "1";
                            }
                            else
                            {
                                _strSqlValor = "0";
                            }
                            break;

                        case DbColuna.EnmGrupo.TEMPORAL:
                            _strSqlValor = "'" + this.dttValor.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                            break;

                        case DbColuna.EnmGrupo.NUMERICO:
                            _strSqlValor = "'" + this.strValor.Replace(",", ".") + "'";
                            break;

                        default:
                            _strSqlValor = "'" + this.strValor + "'";
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

                return _strSqlValor;
            }
        }

        public string strValor
        {
            get
            {
                return _strValor;
            }

            set
            {
                _strValor = value;
            }
        }

        public string strValorPadrao
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_strValorPadrao.Equals(Utils.STR_VAZIA) && this.lstStrOpcoes.Count > 0)
                    {
                        return this.lstStrOpcoes[0];
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

                return _strValorPadrao;
            }

            set
            {
                _strValorPadrao = value;
            }
        }

        public DbTabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _tbl = value;
                    _tbl.lstCln.Add(this);
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
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public DbColuna(string strNome, DbTabela tbl, EnmTipo enmTipo = EnmTipo.TEXT)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.strNome = strNome;
                this.tbl = tbl;
                this.enmTipo = enmTipo;
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

        #region MÉTODOS

        public int CompareTo(DbColuna objDbColuna)
        {
            return this.intOrdem.CompareTo(objDbColuna.intOrdem);
        }

        public DataTable getDataSorceColunaReferencia()
        {
            #region VARIÁVEIS

            DataTable tblResultado;
            string sql;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                sql = Utils.STR_VAZIA;
                sql = String.Format("SELECT intid, strnome FROM pessoa;");
                tblResultado = this.tbl.objDataBase.execSqlGetObjDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return tblResultado;
        }

        public List<String> getLstStrDadosColunaReferencia()
        {
            #region VARIÁVEIS

            List<String> lstStrResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lstStrResultado = new List<string>();

                if (this.objColunaReferencia != null)
                {
                    lstStrResultado = this.tbl.objDataBase.execSqlGetLstStr(this.objColunaReferencia);
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

            return lstStrResultado;
        }

        #endregion MÉTODOS

        #region EVENTOS
        #endregion EVENTOS
    }
}