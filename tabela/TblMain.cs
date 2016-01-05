using System;
using DigoFramework.DataBase;

namespace DigoFramework.Tabela
{
    public abstract class TblMain : DataBase.Tabela
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Coluna _clnBooAtivo;
        private Coluna _clnDttAlteracao;
        private Coluna _clnDttCadastro;
        private Coluna _clnDttDelecao;
        private Coluna _clnIntId;

        public Coluna clnBooAtivo
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

                    _clnBooAtivo = new Coluna("boo_ativo", this);

                    _clnBooAtivo.booVisivelCadastro = false;
                    _clnBooAtivo.booVisivelConsulta = false;
                    _clnBooAtivo.enmTipo = Coluna.EnmTipo.BOOLEAN;
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

        public Coluna clnDttAlteracao
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

                    _clnDttAlteracao = new Coluna("dtt_alteracao", this);

                    _clnDttAlteracao.booVisivelCadastro = false;
                    _clnDttAlteracao.booVisivelConsulta = false;
                    _clnDttAlteracao.enmTipo = Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
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

        public Coluna clnDttCadastro
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

                    _clnDttCadastro = new Coluna("dtt_cadastro", this);

                    _clnDttCadastro.booVisivelCadastro = false;
                    _clnDttCadastro.booVisivelConsulta = false;
                    _clnDttCadastro.enmTipo = Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
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

        public Coluna clnDttDelecao
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

                    _clnDttDelecao = new Coluna("dtt_delecao", this);

                    _clnDttDelecao.booVisivelCadastro = false;
                    _clnDttDelecao.booVisivelConsulta = false;
                    _clnDttDelecao.enmTipo = Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE;
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

        public Coluna clnIntId
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

                    _clnIntId = new Coluna("int_id", this);

                    _clnIntId.booChavePrimaria = true;
                    _clnIntId.enmTipo = Coluna.EnmTipo.BIGINT;
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