using DigoFramework.DataBase;
using System;

namespace DigoFramework.Tabelas
{
    public class TblBase : DbTabela
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private DbColuna _clnBooAtivo;
        public DbColuna clnBooAtivo
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_clnBooAtivo == null)
                    {
                        _clnBooAtivo = new DbColuna("boo_ativo", this);
                        _clnBooAtivo.enmDbColunaTipo = DbColuna.EnmDbColunaTipo.BOOLEAN;
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

                return _clnBooAtivo;
            }
        }

        private DbColuna _clnDttAlteracao;
        public DbColuna clnDttAlteracao
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_clnDttAlteracao == null)
                    {
                        _clnDttAlteracao = new DbColuna("dtt_alteracao", this);
                        _clnDttAlteracao.enmDbColunaTipo = DbColuna.EnmDbColunaTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
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

                return _clnDttAlteracao;
            }
        }

        private DbColuna _clnDttCadastro;
        public DbColuna clnDttCadastro
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_clnDttCadastro == null)
                    {
                        _clnDttCadastro = new DbColuna("dtt_cadastro", this);
                        _clnDttCadastro.enmDbColunaTipo = DbColuna.EnmDbColunaTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
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

                return _clnDttCadastro;
            }
        }

        private DbColuna _clnDttDelecao;
        public DbColuna clnDttDelecao
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_clnDttDelecao == null)
                    {
                        _clnDttDelecao = new DbColuna("dtt_delecao", this);
                        _clnDttDelecao.enmDbColunaTipo = DbColuna.EnmDbColunaTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
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

                return _clnDttDelecao;
            }
        }

        private DbColuna _clnIntId;
        public DbColuna clnIntId
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_clnIntId == null)
                    {
                        _clnIntId = new DbColuna("int_id", this);
                        _clnIntId.enmDbColunaTipo = DbColuna.EnmDbColunaTipo.BIGINT;
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

                return _clnIntId;
            }
        }

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// 
        /// </summary>
        public TblBase(string strNome)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.objDataBase = Aplicativo.i.objDataBasePrincipal;
                this.strNome = strNome;

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

        #region DESTRUTORES
        #endregion

        #region MÉTODOS
        #endregion

        #region EVENTOS
        #endregion
    }
}
