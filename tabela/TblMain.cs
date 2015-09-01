using DigoFramework.DataBase;
using System;

namespace DigoFramework.Tabela
{
    public abstract class TblMain : DbTabela
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DbColuna _clnBooAtivo;
        private DbColuna _clnDttAlteracao;
        private DbColuna _clnDttCadastro;
        private DbColuna _clnDttDelecao;
        private DbColuna _clnIntId;

        public DbColuna clnBooAtivo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnBooAtivo != null)
                    {
                        return _clnBooAtivo;
                    }

                    _clnBooAtivo = new DbColuna("boo_ativo", this);

                    _clnBooAtivo.booVisivelCadastro = false;
                    _clnBooAtivo.booVisivelConsulta = false;
                    _clnBooAtivo.enmTipo = DbColuna.EnmTipo.BOOLEAN;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnBooAtivo;
            }
        }

        public DbColuna clnDttAlteracao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnDttAlteracao != null)
                    {
                        return _clnDttAlteracao;
                    }

                    _clnDttAlteracao = new DbColuna("dtt_alteracao", this);

                    _clnDttAlteracao.booVisivelCadastro = false;
                    _clnDttAlteracao.booVisivelConsulta = false;
                    _clnDttAlteracao.enmTipo = DbColuna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnDttAlteracao;
            }
        }

        public DbColuna clnDttCadastro
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnDttCadastro != null)
                    {
                        return _clnDttCadastro;
                    }

                    _clnDttCadastro = new DbColuna("dtt_cadastro", this);

                    _clnDttCadastro.booVisivelCadastro = false;
                    _clnDttCadastro.booVisivelConsulta = false;
                    _clnDttCadastro.enmTipo = DbColuna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnDttCadastro;
            }
        }

        public DbColuna clnDttDelecao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnDttDelecao != null)
                    {
                        return _clnDttDelecao;
                    }

                    _clnDttDelecao = new DbColuna("dtt_delecao", this);

                    _clnDttDelecao.booVisivelCadastro = false;
                    _clnDttDelecao.booVisivelConsulta = false;
                    _clnDttDelecao.enmTipo = DbColuna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnDttDelecao;
            }
        }

        public DbColuna clnIntId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnIntId != null)
                    {
                        return _clnIntId;
                    }

                    _clnIntId = new DbColuna("int_id", this);
                    
                    _clnIntId.booChavePrimaria = true;
                    _clnIntId.enmTipo = DbColuna.EnmTipo.BIGINT;
                    _clnIntId.intTamanho = 25;
                    _clnIntId.strNomeExibicao = "Código";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnIntId;
            }
        }

        #endregion Atributos

        #region Construtores

        public TblMain(string strNome)
            : base(strNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.objDataBase = Aplicativo.i.objDbPrincipal;
                this.strNome = strNome;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        protected override int inicializarColunas(int intOrdem)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
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

            #endregion Ações

            return intOrdem;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}