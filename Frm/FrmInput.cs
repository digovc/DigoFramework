using System;

namespace DigoFramework.Frm
{
    public partial class FrmInput : FrmBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static FrmInput _i;

        private string _strDescricao;
        private string _strTitulo;
        private string _strValorDefault;

        public static FrmInput i
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i == null)
                    {
                        _i = new FrmInput();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _i;
            }
        }

        public string strDescricao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strDescricao = this.lbl.Text;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strDescricao;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strDescricao = value;
                    this.lbl.Text = _strDescricao;
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
        }

        public string strTitulo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strTitulo = this.Text;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strTitulo;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strTitulo = value;
                    this.Text = _strTitulo;
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
        }

        public string strValorDefault
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strValorDefault = this.txt.Text;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strValorDefault;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strValorDefault = value;
                    this.txt.Text = _strValorDefault;
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
        }

        #endregion Atributos

        #region Construtores

        private FrmInput()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.InitializeComponent();
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

        #endregion Métodos

        #region Eventos

        private void btnOk_Click(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                Aplicativo.i.strInput = this.txt.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.EnmTipo.ERRO);
            }
            finally
            {
            }

            #endregion Ações
        }

        private void FrmInput_Load(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.txt.SelectAll();
                this.txt.Focus();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.EnmTipo.ERRO);
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Eventos
    }
}