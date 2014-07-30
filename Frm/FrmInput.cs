using System;

namespace DigoFramework.Frm
{
    public partial class FrmInput : FrmMain
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private static FrmInput _i;
        private string _strDescricao;
        private string _strTitulo;
        private string _strValorDefault;

        public static FrmInput i
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

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

                #endregion

                return _i;
            }
        }

        public string strDescricao
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

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

                #endregion

                return _strDescricao;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

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

                #endregion
            }
        }

        public string strTitulo
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

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

                #endregion

                return _strTitulo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

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

                #endregion
            }
        }

        public string strValorDefault
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

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

                #endregion

                return _strValorDefault;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

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

                #endregion
            }
        }

        #endregion

        #region CONSTRUTORES

        private FrmInput()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

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

            #endregion
        }

        #endregion

        #region DESTRUTOR

        #endregion

        #region MÉTODOS

        #endregion

        #region EVENTOS

        private void btnOk_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                Aplicativo.i.strInput = this.txt.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion
        }

        private void FrmInput_Load(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.txt.SelectAll();
                this.txt.Focus();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion
        }

        #endregion
    }
}