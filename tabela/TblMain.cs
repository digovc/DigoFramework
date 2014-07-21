using DigoFramework.database;
using System;

namespace DigoFramework.tabela
{
    public abstract class TblMain : DbTabela
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private DbColuna _clnBooAtivo;
        private DbColuna _clnDttAlteracao;
        private DbColuna _clnDttCadastro;
        private DbColuna _clnDttDelecao;
        private DbColuna _clnIntId;

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
                        _clnBooAtivo.enmTipo = DbColuna.EnmTipo.BOOLEAN;
                        _clnBooAtivo.booVisivelCadastro = false;
                        _clnBooAtivo.booVisivelConsulta = false;
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
                        _clnDttAlteracao.enmTipo = DbColuna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
                        _clnDttAlteracao.booVisivelCadastro = false;
                        _clnDttAlteracao.booVisivelConsulta = false;
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
                        _clnDttCadastro.enmTipo = DbColuna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
                        _clnDttCadastro.booVisivelCadastro = false;
                        _clnDttCadastro.booVisivelConsulta = false;
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
                        _clnDttDelecao.enmTipo = DbColuna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
                        _clnDttDelecao.booVisivelCadastro = false;
                        _clnDttDelecao.booVisivelConsulta = false;
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
                        _clnIntId.booChavePrimaria = true;
                        _clnIntId.enmTipo = DbColuna.EnmTipo.BIGINT;
                        _clnIntId.intTamanho = 25;
                        _clnIntId.strNomeExibicao = "Código";
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

        public TblMain(string strNome)
            : base(strNome)
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

        #region DESTRUTOR

        #endregion

        #region MÉTODOS

        protected override int inicializarColunas(int intOrdem)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES
            try
            {
                intOrdem = base.inicializarColunas(intOrdem);

                this.clnBooAtivo.intOrdem = ++intOrdem;
                this.clnDttAlteracao.intOrdem = ++intOrdem;
                this.clnDttCadastro.intOrdem = ++intOrdem;
                this.clnDttDelecao.intOrdem = ++intOrdem;
                this.clnIntId.intOrdem = ++intOrdem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            #endregion

            return intOrdem;
        }

        #endregion

        #region EVENTOS

        #endregion
    }
}