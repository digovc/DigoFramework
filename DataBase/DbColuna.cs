using System;
using System.Collections.Generic;
using System.Data;

namespace DigoFramework.DataBase
{
    public class DbColuna : Objeto, IComparable<DbColuna>
    {
        #region CONSTANTES

        public enum DbColunaTipo
        {
            SMALLINT, INTEGER, BIGINT, DECIMAL, NUMERIC, REAL, DOUBLE, SERIAL, BIGSERIAL, MONEY, VARCHAR,
            CHAR, TEXT, TIMESTAMP_WITHOUT_TIME_ZONE, TIMESTAMP_WITH_TIME_ZONE, INTERVAL, DATE, TIME_WITHOUT_TIME_ZONE,
            TIME_WITH_TIME_ZONE, BOOLEAN, PASSWORD, ENUM
        };

        public enum DbColunaTipoGrupo
        {
            ALFANUMERICO, TEMPORAL, NUMERAL
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
                    foreach (DbColuna objDbColuna in this.objDbTabela.lstObjDbColuna)
                    {
                        objDbColuna.booObrigatorio = false;
                    }
                }
                _booChavePrimaria = value;
            }
        }

        private Boolean _booObrigatorio = false;
        public Boolean booObrigatorio { get { return _booObrigatorio; } set { _booObrigatorio = value; } }

        private Boolean _booVisivel = true;
        public Boolean booVisivel { get { return _booVisivel; } set { _booVisivel = value; } }

        private Int16 _intCampoTamanho = 150;
        public Int16 intCampoTamanho { get { return _intCampoTamanho; } set { _intCampoTamanho = value; } }

        private Int32 _intOrdem;
        public Int32 intOrdem
        {
            get { return _intOrdem; }
            set
            {
                foreach (DbColuna objDbColuna in this.objDbTabela.lstObjDbColuna)
                {
                    if (value == objDbColuna.intOrdem)
                    {
                        value = objDbColuna.intOrdem + 1;
                    }
                }
                _intOrdem = value;
            }
        }

        private List<String> _lstStrOpcoes = new List<String>();
        public List<String> lstStrOpcoes { get { return _lstStrOpcoes; } set { _lstStrOpcoes = value; } }

        private DbColuna _objColunaReferencia;
        public DbColuna objColunaReferencia { get { return _objColunaReferencia; } set { _objColunaReferencia = value; } }

        private DbColuna _objColunaReferenciaVisual;
        public DbColuna objColunaReferenciaVisual { get { return _objColunaReferenciaVisual; } set { _objColunaReferenciaVisual = value; } }

        private DbColunaTipo _objDbColunaTipo = DbColunaTipo.VARCHAR;
        public DbColunaTipo objDbColunaTipo { get { return _objDbColunaTipo; } set { _objDbColunaTipo = value; } }

        public DbColunaTipoGrupo objDbColunaTipoGrupo
        {
            get
            {
                switch (this.objDbColunaTipo)
                {
                    case DbColunaTipo.SMALLINT:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.INTEGER:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.BIGINT:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.DECIMAL:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.NUMERIC:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.REAL:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.DOUBLE:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.SERIAL:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.BIGSERIAL:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.MONEY:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.VARCHAR:
                        return DbColunaTipoGrupo.ALFANUMERICO;
                    case DbColunaTipo.CHAR:
                        return DbColunaTipoGrupo.ALFANUMERICO;
                    case DbColunaTipo.TEXT:
                        return DbColunaTipoGrupo.ALFANUMERICO;
                    case DbColunaTipo.TIMESTAMP_WITHOUT_TIME_ZONE:
                        return DbColunaTipoGrupo.TEMPORAL;
                    case DbColunaTipo.TIMESTAMP_WITH_TIME_ZONE:
                        return DbColunaTipoGrupo.TEMPORAL;
                    case DbColunaTipo.INTERVAL:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.DATE:
                        return DbColunaTipoGrupo.TEMPORAL;
                    case DbColunaTipo.TIME_WITHOUT_TIME_ZONE:
                        return DbColunaTipoGrupo.TEMPORAL;
                    case DbColunaTipo.TIME_WITH_TIME_ZONE:
                        return DbColunaTipoGrupo.TEMPORAL;
                    case DbColunaTipo.BOOLEAN:
                        return DbColunaTipoGrupo.NUMERAL;
                    case DbColunaTipo.PASSWORD:
                        return DbColunaTipoGrupo.ALFANUMERICO;
                    case DbColunaTipo.ENUM:
                        return DbColunaTipoGrupo.ALFANUMERICO;
                    default:
                        return DbColunaTipoGrupo.ALFANUMERICO;
                }
            }
        }

        private DbTabela _objDbTabela;
        public DbTabela objDbTabela
        {
            get { return _objDbTabela; }
            set
            {
                _objDbTabela = value;
                _objDbTabela.lstObjDbColuna.Add(this);
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
