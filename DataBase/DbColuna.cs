﻿using System;
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
            TIME_WITH_TIME_ZONE, BOOLEAN, PASSWORD
        };

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Boolean _booObrigatorio = false;
        public Boolean booObrigatorio { get { return _booObrigatorio; } set { _booObrigatorio = value; } }

        private Boolean _booVisivel = true;
        public Boolean booVisivel { get { return _booVisivel; } set { _booVisivel = value; } }

        private Int16 _intCampoTamanho = 150;
        public Int16 intCampoTamanho { get { return _intCampoTamanho; } set { _intCampoTamanho = value; } }

        private Int32 _intOrdem;
        public Int32 intOrdem { get { return _intOrdem; } set { _intOrdem = value; } }

        private DbColuna _objColunaReferencia;
        public DbColuna objColunaReferencia { get { return _objColunaReferencia; } set { _objColunaReferencia = value; } }

        private DbColuna _objColunaReferenciaVisual;
        public DbColuna objColunaReferenciaVisual { get { return _objColunaReferenciaVisual; } set { _objColunaReferenciaVisual = value; } }

        private DbColunaTipo _objDbColunaTipo = DbColunaTipo.VARCHAR;
        public DbColunaTipo objDbColunaTipo { get { return _objDbColunaTipo; } set { _objDbColunaTipo = value; } }

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

        private String _strValor = String.Empty;
        public String strValor { get { return _strValor; } set { _strValor = value; } }

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
