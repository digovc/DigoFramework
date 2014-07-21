using System;
using System.Collections.Generic;
using System.Data;

namespace DigoFramework.database
{
    public class DbColuna : Objeto, IComparable<DbColuna>
    {
        #region CONSTANTES

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

        public enum EnmGrupo
        {
            ALFANUMERICO,
            BOOLEANO,
            TEMPORAL,
            NUMERICO
        };

        #endregion

        #region ATRIBUTOS

        private Boolean _booChavePrimaria = false;
        private Boolean _booNome;
        private Boolean _booObrigatorio = false;
        private Boolean _booSomenteLeitura = false;
        private Boolean _booVisivelCadastro = true;
        private Boolean _booVisivelConsulta = true;
        private EnmTipo _enmTipo = EnmTipo.VARCHAR;
        private Int32 _intOrdem;
        private Int16 _intTamanho;
        private List<String> _lstStrOpcoes;
        private DbColuna _objColunaReferencia;
        private DbColuna _objColunaReferenciaVisual;
        private DbView _objDbViewReferencia;
        private String _strMascara = String.Empty;
        private String _strSqlValor;
        private String _strValor = String.Empty;
        private String _strValorPadrao = String.Empty;
        private DbTabela _tbl;

        public Boolean booChavePrimaria
        {
            get
            {
                return _booChavePrimaria;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    if (value)
                    {
                        this.tbl.clnChavePrimaria = null;
                        foreach (DbColuna cln in this.tbl.lstCln)
                        {
                            cln._booChavePrimaria = false;
                        }
                    }

                    _booChavePrimaria = value;

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
        }

        public Boolean booNome
        {
            get
            {
                return _booNome;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    if (value)
                    {
                        this.tbl.clnNome = null;
                        foreach (DbColuna cln in this.tbl.lstCln)
                        {
                            cln._booNome = false;
                        }
                    }

                    _booNome = value;

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
        }

        public Boolean booObrigatorio
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

        public Boolean booSomenteLeitura
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

                #endregion

                try
                {
                    #region AÇÕES

                    if (strValor.Equals("T") || strValor.Equals("t") || strValor.Equals("1"))
                    {
                        return true;
                    }
                    else if (strValor.Equals("F") || strValor.Equals("f") || strValor.Equals("0"))
                    {
                        return false;
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

                return Convert.ToBoolean(strValor);
            }

            set
            {
                strValor = Convert.ToString(value);
            }
        }

        public Boolean booVisivelCadastro
        {
            get
            {
                return _booVisivelCadastro;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    _booVisivelCadastro = value;
                    this.tbl.lstClnVisivelCadastro = null;

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
        }

        public Boolean booVisivelConsulta
        {
            get
            {
                return _booVisivelConsulta;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    _booVisivelConsulta = value;
                    this.tbl.lstClnVisivelConsulta = null;

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
        }

        public double dblValor
        {
            get
            {
                #region VARIÁVEIS

                double dblResultado;

                #endregion

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

                #endregion
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

        public EnmGrupo enmGrupo
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

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
        }

        public Int32 intOrdem
        {
            get
            {
                return _intOrdem;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    foreach (DbColuna objDbColuna in this.tbl.lstCln)
                    {
                        if (value == objDbColuna.intOrdem)
                        {
                            value = objDbColuna.intOrdem + 1;
                        }
                    }

                    _intOrdem = value;

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
        }

        public Int16 intTamanho
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

                #endregion

                try
                {
                    #region AÇÕES

                    intResultado = Convert.ToInt32(strValor);

                    #endregion
                }
                catch
                {
                    intResultado = 0;
                }
                finally
                {
                }

                return intResultado;
            }

            set
            {
                strValor = Convert.ToString(value);
            }
        }

        public List<String> lstStrOpcoes
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    if (_lstStrOpcoes == null)
                    {
                        _lstStrOpcoes = new List<string>();
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

        public String strMascara
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

        public String strSqlValor
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

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

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _strSqlValor;
            }
        }

        public String strValor
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

        public String strValorPadrao
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    if (_strValorPadrao.Equals(Utils.STRING_VAZIA) && this.lstStrOpcoes.Count > 0)
                    {
                        return this.lstStrOpcoes[0];
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

                #endregion

                try
                {
                    #region AÇÕES

                    _tbl = value;
                    _tbl.lstCln.Add(this);

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
        }

        #endregion

        #region CONSTRUTORES

        public DbColuna(String strNome, DbTabela tbl, EnmTipo enmTipo = EnmTipo.TEXT)
        {
            #region VARIÁVEIS

            #endregion

            try
            {
                #region AÇÕES

                this.strNome = strNome;
                this.tbl = tbl;
                this.enmTipo = enmTipo;

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

        #region MÉTODOS

        public int CompareTo(DbColuna objDbColuna)
        {
            return this.intOrdem.CompareTo(objDbColuna.intOrdem);
        }

        public DataTable getDataSorceColunaReferencia()
        {
            #region VARIÁVEIS

            DataTable tblResultado;
            String sql;

            #endregion

            try
            {
                #region AÇÕES

                sql = Utils.STRING_VAZIA;
                sql = String.Format("SELECT intid, strnome FROM pessoa;");
                tblResultado = this.tbl.objDataBase.execSqlGetObjDataTable(sql);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return tblResultado;
        }

        public List<String> getLstStrDadosColunaReferencia()
        {
            #region VARIÁVEIS

            List<String> lstStrResultado;

            #endregion

            try
            {
                #region AÇÕES

                lstStrResultado = new List<string>();

                if (this.objColunaReferencia != null)
                {
                    lstStrResultado = this.tbl.objDataBase.execSqlGetLstStr(this.objColunaReferencia);
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

            return lstStrResultado;
        }

        #endregion
    }
}