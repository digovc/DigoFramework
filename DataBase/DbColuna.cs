﻿using System;
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
        private bool _booSenha;
        private bool _booSomenteLeitura;
        private bool _booVisivelCadastro = true;
        private bool _booVisivelConsulta = true;
        private DbColuna _clnRef;
        private EnmTipo _enmTipo;
        private int _intOrdem;
        private int _intTamanho;
        private List<string> _lstStrOpcoes;
        private string _strValorSql;
        private string _strValor;
        private string _strValorPadrao;
        private DbTabela _tbl;
        private DbView _viwRef;

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
                    _booChavePrimaria = value;
                    this.tbl.clnChavePrimaria = null;

                    if (_booChavePrimaria)
                    {
                        this.tbl.clnChavePrimaria = this;

                        foreach (DbColuna cln in this.tbl.lstCln)
                        {
                            if (this.Equals(cln))
                            {
                                continue;
                            }

                            cln._booChavePrimaria = false;
                        }
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
                    _booNome = value;
                    this.tbl.clnNome = null;

                    if (_booNome)
                    {
                        this.tbl.clnNome = this;

                        foreach (DbColuna cln in this.tbl.lstCln)
                        {
                            if (this.Equals(cln))
                            {
                                continue;
                            }

                            cln._booNome = false;
                        }
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

        public bool booSenha
        {
            get
            {
                return _booSenha;
            }

            set
            {
                _booSenha = value;
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
                    this.tbl.lstClnCadastro = null;
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
                    this.tbl.lstClnConsulta = null;
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

        public DbColuna clnRef
        {
            get
            {
                return _clnRef;
            }

            set
            {
                _clnRef = value;
            }
        }

        public decimal decValor
        {
            get
            {
                #region VARIÁVEIS

                decimal decResultado;

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    decResultado = Convert.ToDecimal(strValor);
                }
                catch
                {
                    decResultado = 0;
                }
                finally
                {
                }

                return decResultado;

                #endregion AÇÕES
            }

            set
            {
                strValor = Convert.ToString(decValor);
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
                        case EnmTipo.BIGINT:
                        case EnmTipo.BIGSERIAL:
                        case EnmTipo.DECIMAL:
                        case EnmTipo.DOUBLE:
                        case EnmTipo.INTEGER:
                        case EnmTipo.INTERVAL:
                        case EnmTipo.MONEY:
                        case EnmTipo.NUMERIC:
                        case EnmTipo.REAL:
                        case EnmTipo.SERIAL:
                        case EnmTipo.SMALLINT:
                            return EnmGrupo.NUMERICO;

                        case EnmTipo.BOOLEAN:
                            return EnmGrupo.BOOLEANO;

                        case EnmTipo.DATE:
                        case EnmTipo.TIME_WITH_TIME_ZONE:
                        case EnmTipo.TIME_WITHOUT_TIME_ZONE:
                        case EnmTipo.TIMESTAMP_WITH_TIME_ZONE:
                        case EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE:
                            return EnmGrupo.TEMPORAL;

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
                _intOrdem = value;
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

        public string strValorSql
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
                            _strValorSql = "'" + this.strValor + "'";
                            break;

                        case DbColuna.EnmGrupo.BOOLEANO:
                            if (this.booValor)
                            {
                                _strValorSql = "1";
                            }
                            else
                            {
                                _strValorSql = "0";
                            }
                            break;

                        case DbColuna.EnmGrupo.TEMPORAL:
                            _strValorSql = "'" + this.dttValor.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                            break;

                        case DbColuna.EnmGrupo.NUMERICO:
                            _strValorSql = "'" + this.strValor.Replace(",", ".") + "'";
                            break;

                        default:
                            _strValorSql = "'" + this.strValor + "'";
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

                return _strValorSql;
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
                    if (_strValorPadrao.Equals(String.Empty) && this.lstStrOpcoes.Count > 0)
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

        public DbView viwRef
        {
            get
            {
                return _viwRef;
            }

            set
            {
                _viwRef = value;
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
                sql = String.Empty;
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

                if (this.clnRef != null)
                {
                    lstStrResultado = this.tbl.objDataBase.execSqlGetLstStr(this.clnRef);
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