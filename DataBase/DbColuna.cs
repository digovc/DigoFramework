using System;
using System.Collections.Generic;
using System.Data;

namespace DigoFramework.DataBase
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
                if (_booChavePrimaria)
                {
                    foreach (DbColuna objDbColuna in this.objDbTabela.lstCln)
                    {
                        objDbColuna.booObrigatorio = false;
                    }
                }
                _booChavePrimaria = value;
            }
        }

        private Boolean _booObrigatorio = false;
        public Boolean booObrigatorio { get { return _booObrigatorio; } set { _booObrigatorio = value; } }

        private Boolean _booSomenteLeitura = false;
        public Boolean booSomenteLeitura { get { return _booSomenteLeitura; } set { _booSomenteLeitura = value; } }

        private Boolean _booVisivel = true;
        public Boolean booVisivel { get { return _booVisivel; } set { _booVisivel = value; } }

        private EnmDbColunaTipo _enmDbColunaTipo = EnmDbColunaTipo.VARCHAR;
        public EnmDbColunaTipo enmDbColunaTipo { get { return _enmDbColunaTipo; } set { _enmDbColunaTipo = value; } }

        public EnmDbColunaTipoGrupo enmDbColunaTipoGrupo
        {
            get
            {
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
            }
        }

        private Int16 _intCampoTamanho = 150;
        public Int16 intCampoTamanho { get { return _intCampoTamanho; } set { _intCampoTamanho = value; } }

        private Int32 _intOrdem;
        public Int32 intOrdem
        {
            get { return _intOrdem; }
            set
            {
                foreach (DbColuna objDbColuna in this.objDbTabela.lstCln)
                {
                    if (value == objDbColuna.intOrdem)
                    {
                        value = objDbColuna.intOrdem + 1;
                    }
                }
                _intOrdem = value;
            }
        }

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

        private DbTabela _objDbTabela;
        public DbTabela objDbTabela
        {
            get { return _objDbTabela; }
            set
            {
                _objDbTabela = value;
                _objDbTabela.lstCln.Add(this);
            }
        }

        private DbView _objDbViewReferencia;
        public DbView objDbViewReferencia { get { return _objDbViewReferencia; } set { _objDbViewReferencia = value; } }

        private String _strMascara = String.Empty;
        public String strMascara { get { return _strMascara; } set { _strMascara = value; } }

        private String _strNomeExibicao = String.Empty;
        public String strNomeExibicao
        {
            get
            {
                return (_strNomeExibicao != Utils.STRING_VAZIA ? Utils.getStrFormataTitulo(_strNomeExibicao) : Utils.getStrFormataTitulo(this.strNome));
            }
            set { _strNomeExibicao = value; }
        }

        private String _strValor = String.Empty;
        public String strValor { get { return _strValor; } set { _strValor = value; } }

        public bool booValor
        {
            get
            {
                return Convert.ToBoolean(_strValor);
            }
            set
            {
                _strValor = Convert.ToString(value);
            }
        }

        private String _strValorPadrao = String.Empty;
        public String strValorPadrao
        {
            get
            {
                if (_strValorPadrao.Equals(Utils.STRING_VAZIA) && this.lstStrOpcoes.Count > 0)
                {
                    return this.lstStrOpcoes[0];
                }
                return _strValorPadrao;
            }
            set { _strValorPadrao = value; }
        }

        #endregion

        #region CONSTRUTORES

        public DbColuna(DbTabela tblTabela)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objDbTabela = tblTabela;
            this.intOrdem = this.intId;

            #endregion
        }

        public DbColuna(String strNome, DbTabela tblTabela)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.strNome = strNome;
            this.objDbTabela = tblTabela;
            this.intOrdem = this.intId;

            #endregion
        }

        public DbColuna(String strNome, DbTabela tblTabela, DbColuna clnReferencia)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.strNome = strNome;
            this.objDbTabela = tblTabela;
            this.objColunaReferencia = clnReferencia;
            this.intOrdem = this.intId;

            #endregion
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

            DataTable objDataTable = new DataTable();
            String sql = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            sql = String.Format("SELECT intid, strnome FROM pessoa;");
            return this.objDbTabela.objDataBase.executaSqlRetornaDataTable(sql);

            #endregion
        }

        public List<String> getLstStrDadosColunaReferencia()
        {
            #region VARIÁVEIS

            List<String> lstStrDadosColunaReferencia = new List<string>();

            #endregion

            #region AÇÕES

            if (this.objColunaReferencia != null)
            {
                lstStrDadosColunaReferencia = this.objDbTabela.objDataBase.executaSqlRetornaUmaColuna(this.objColunaReferencia);
            }
            return lstStrDadosColunaReferencia;

            #endregion
        }

        #endregion
    }
}
