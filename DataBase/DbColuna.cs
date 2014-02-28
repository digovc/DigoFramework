using System;
using System.Collections.Generic;
using System.Data;

namespace DigoFramework.database
{
    public class DbColuna : Objeto, IComparable<DbColuna>
    {
        #region CONSTANTES

        public enum EnmDbColunaTipo
        {
            SMALLINT, INTEGER, BIGINT, DECIMAL, NUMERIC, REAL, DOUBLE, SERIAL, BIGSERIAL, MONEY, VARCHAR,
            CHAR, TEXT, TIMESTAMP_WITHOUT_TIME_ZONE, TIMESTAMP_WITH_TIME_ZONE, INTERVAL, DATE, TIME_WITHOUT_TIME_ZONE,
            TIME_WITH_TIME_ZONE, BOOLEAN, PASSWORD, ENUM
        };

        public enum EnmDbColunaTipoGrupo
        {
            ALFANUMERICO, BOOLEANO, TEMPORAL, NUMERICO
        };

        #endregion

        #region ATRIBUTOS

        private Boolean _booChavePrimaria = false;
        public Boolean booChavePrimaria
        {
            get { return _booChavePrimaria; }
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

        private Boolean _booNome;
        public Boolean booNome
        {
            get { return _booNome; }
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

        private Boolean _booObrigatorio = false;
        public Boolean booObrigatorio { get { return _booObrigatorio; } set { _booObrigatorio = value; } }

        private Boolean _booSomenteLeitura = false;
        public Boolean booSomenteLeitura { get { return _booSomenteLeitura; } set { _booSomenteLeitura = value; } }

        private Boolean _booVisivelCadastro = true;
        public Boolean booVisivelCadastro
        {
            get { return _booVisivelCadastro; }
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

        private Boolean _booVisivelConsulta = true;
        public Boolean booVisivelConsulta
        {
            get { return _booVisivelConsulta; }
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

        private EnmDbColunaTipo _enmDbColunaTipo = EnmDbColunaTipo.VARCHAR;
        public EnmDbColunaTipo enmDbColunaTipo { get { return _enmDbColunaTipo; } set { _enmDbColunaTipo = value; } }

        public EnmDbColunaTipoGrupo enmDbColunaTipoGrupo
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    switch (this.enmDbColunaTipo)
                    {
                        case EnmDbColunaTipo.SMALLINT:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.INTEGER:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.BIGINT:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.BOOLEAN:
                            return EnmDbColunaTipoGrupo.BOOLEANO;
                        case EnmDbColunaTipo.DECIMAL:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.NUMERIC:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.REAL:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.DOUBLE:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.SERIAL:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.BIGSERIAL:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.MONEY:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.VARCHAR:
                            return EnmDbColunaTipoGrupo.ALFANUMERICO;
                        case EnmDbColunaTipo.CHAR:
                            return EnmDbColunaTipoGrupo.ALFANUMERICO;
                        case EnmDbColunaTipo.TEXT:
                            return EnmDbColunaTipoGrupo.ALFANUMERICO;
                        case EnmDbColunaTipo.TIMESTAMP_WITHOUT_TIME_ZONE:
                            return EnmDbColunaTipoGrupo.TEMPORAL;
                        case EnmDbColunaTipo.TIMESTAMP_WITH_TIME_ZONE:
                            return EnmDbColunaTipoGrupo.TEMPORAL;
                        case EnmDbColunaTipo.INTERVAL:
                            return EnmDbColunaTipoGrupo.NUMERICO;
                        case EnmDbColunaTipo.DATE:
                            return EnmDbColunaTipoGrupo.TEMPORAL;
                        case EnmDbColunaTipo.TIME_WITHOUT_TIME_ZONE:
                            return EnmDbColunaTipoGrupo.TEMPORAL;
                        case EnmDbColunaTipo.TIME_WITH_TIME_ZONE:
                            return EnmDbColunaTipoGrupo.TEMPORAL;
                        case EnmDbColunaTipo.PASSWORD:
                            return EnmDbColunaTipoGrupo.ALFANUMERICO;
                        case EnmDbColunaTipo.ENUM:
                            return EnmDbColunaTipoGrupo.ALFANUMERICO;
                        default:
                            return EnmDbColunaTipoGrupo.ALFANUMERICO;
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

        private Int32 _intOrdem;
        public Int32 intOrdem
        {
            get { return _intOrdem; }
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

        private Int16 _intTamanho;
        public Int16 intTamanho { get { return _intTamanho; } set { _intTamanho = value; } }

        private List<String> _lstStrOpcoes;
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
            set { _lstStrOpcoes = value; }
        }

        private DbColuna _objColunaReferencia;
        public DbColuna objColunaReferencia { get { return _objColunaReferencia; } set { _objColunaReferencia = value; } }

        private DbColuna _objColunaReferenciaVisual;
        public DbColuna objColunaReferenciaVisual { get { return _objColunaReferenciaVisual; } set { _objColunaReferenciaVisual = value; } }

        private DbView _objDbViewReferencia;
        public DbView objDbViewReferencia { get { return _objDbViewReferencia; } set { _objDbViewReferencia = value; } }

        private String _strMascara = String.Empty;
        public String strMascara { get { return _strMascara; } set { _strMascara = value; } }

        private String _strSqlValor;
        public String strSqlValor
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    switch (this.enmDbColunaTipoGrupo)
                    {
                        case DbColuna.EnmDbColunaTipoGrupo.ALFANUMERICO:
                            _strSqlValor = "'" + this.strValor + "'";
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.BOOLEANO:
                            if (this.booValor)
                            {
                                _strSqlValor = "1";
                            }
                            else
                            {
                                _strSqlValor = "0";
                            }
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.TEMPORAL:
                            _strSqlValor = "'" + this.dttValor.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.NUMERICO:
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

        private String _strValor = String.Empty;
        public String strValor { get { return _strValor; } set { _strValor = value; } }

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

        public double dblValor
        {
            get
            {
                return Convert.ToDouble(strValor);
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

                    try
                    {
                        intResultado = Convert.ToInt32(strValor);
                    }
                    catch
                    {
                        intResultado = 0;
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

                return intResultado;
            }
            set
            {
                strValor = Convert.ToString(value);
            }
        }
        private String _strValorPadrao = String.Empty;
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
            set { _strValorPadrao = value; }
        }

        private DbTabela _tbl;
        public DbTabela tbl
        {
            get { return _tbl; }
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

        public DbColuna(String strNome, DbTabela tbl)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.strNome = strNome;
                this.tbl = tbl;
                this.intOrdem = this.intId;

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

        public DbColuna(String strNome, DbTabela tbl, DbColuna clnReferencia)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.strNome = strNome;
                this.tbl = tbl;
                this.objColunaReferencia = clnReferencia;
                this.intOrdem = this.intId;

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
                    lstStrResultado = this.tbl.objDataBase.execSqlGetLstStrColuna(this.objColunaReferencia);
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
