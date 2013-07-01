using System;

namespace DigoFramework
{
    public class DbColuna : Objeto
    {
        #region CONSTANTES

        public enum DbColunaTipo
        {
            SMALLINT, INTEGER, BIGINT, DECIMAL, NUMERIC, REAL, DOUBLE, SERIAL, BIGSERIAL, MONEY, VARCHAR,
            CHAR, TEXT, TIMESTAMP_WITHOUT_TIME_ZONE, TIMESTAMP_WITH_TIME_ZONE, INTERVAL, DATE, TIME_WITHOUT_TIME_ZONE,
            TIME_WITH_TIME_ZONE, BOOLEAN
        };

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Boolean _booVisivel = true;
        public Boolean booVisivel { get { return _booVisivel; } set { _booVisivel = value; } }

        private DbColuna _objColunaReferencia;
        public DbColuna objColunaReferencia { get { return _objColunaReferencia; } set { _objColunaReferencia = value; } }

        private DbColuna _objColunaReferenciaVisual;
        public DbColuna objColunaReferenciaVisual { get { return _objColunaReferenciaVisual; } set { _objColunaReferenciaVisual = value; } }

        private DbColunaTipo _objColunaTipo = DbColunaTipo.VARCHAR;
        public DbColunaTipo objColunaTipo { get { return _objColunaTipo; } set { _objColunaTipo = value; } }

        private DbTabela _objTabela;
        public DbTabela objTabela
        {
            get { return _objTabela; }
            set
            {
                _objTabela = value;
                _objTabela.lstObjColuna.Add(this);
            }
        }

        private Int16 _intCampoTamanho = 150;
        public Int16 intCampoTamanho { get { return _intCampoTamanho; } set { _intCampoTamanho = value; } }

        #endregion

        #region CONSTRUTORES

        public DbColuna(DbTabela tblTabela)
        {
            // EXTERNOS
            // VARIÁVEIS
            // AÇÕES
            this.objTabela = tblTabela;
        }

        public DbColuna(String strNome, DbTabela tblTabela)
        {
            // EXTERNOS
            // VARIÁVEIS
            // AÇÕES
            this.strNome = strNome;
            this.objTabela = tblTabela;
        }

        public DbColuna(String strNome, DbTabela tblTabela, DbColuna clnReferencia)
        {
            // EXTERNOS
            // VARIÁVEIS
            // AÇÕES
            this.strNome = strNome;
            this.objTabela = tblTabela;
            this.objColunaReferencia = clnReferencia;
        }

        #endregion

        #region MÉTODOS

        #endregion
    }
}
