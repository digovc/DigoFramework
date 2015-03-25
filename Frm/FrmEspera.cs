﻿using System;
using System.Windows.Forms;

namespace DigoFramework.Frm
{
    public partial class FrmEspera : FrmMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private bool _booConcluido;
        private decimal _decProgresso;
        private decimal _decProgressoTarefa;
        private int _intProgressoMaximo;
        private int _intProgressoMaximoTarefa;
        private string _strTarefaDescricao;
        private string _strTarefaTitulo;

        public bool booConcluido
        {
            get
            {
                return _booConcluido;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _booConcluido = value;

                    if (!_booConcluido)
                    {
                        return;
                    }

                    try
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.decProgresso = 0;
                            this.decProgressoTarefa = 0;
                            this.progressBarTarefa.Visible = false;
                            this.Close();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public decimal decProgresso
        {
            get
            {
                return _decProgresso;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _decProgresso = value;

                    try
                    {
                        this.progressBar.Invoke((MethodInvoker)delegate
                        {
                            if (_decProgresso >= this.progressBar.Maximum)
                            {
                                this.progressBar.Value = this.progressBar.Maximum;
                                this.progressBar.Refresh();
                                return;
                            }

                            this.progressBar.Style = ProgressBarStyle.Blocks;
                            this.progressBar.Value = Convert.ToInt32(_decProgresso);
                            this.progressBar.Refresh();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public decimal decProgressoTarefa
        {
            get
            {
                return _decProgressoTarefa;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _decProgressoTarefa = value;

                    try
                    {
                        this.progressBarTarefa.Invoke((MethodInvoker)delegate
                        {
                            if (_decProgressoTarefa >= this.progressBarTarefa.Maximum)
                            {
                                this.progressBarTarefa.Visible = false;
                                this.progressBarTarefa.Refresh();
                                return;
                            }

                            this.progressBarTarefa.Style = ProgressBarStyle.Blocks;
                            this.progressBarTarefa.Visible = true;
                            this.progressBarTarefa.Value = Convert.ToInt32(_decProgressoTarefa);
                            this.progressBarTarefa.Refresh();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public int intProgressoMaximo
        {
            get
            {
                _intProgressoMaximo = this.progressBar.Maximum;
                return _intProgressoMaximo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _intProgressoMaximo = value;
                    try
                    {
                        this.progressBar.Invoke((MethodInvoker)delegate
                        {
                            this.progressBar.Maximum = _intProgressoMaximo;
                            this.progressBar.Refresh();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public int intProgressoMaximoTarefa
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _intProgressoMaximoTarefa = this.progressBarTarefa.Maximum;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _intProgressoMaximoTarefa;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _intProgressoMaximoTarefa = value;

                    try
                    {
                        this.progressBarTarefa.Invoke((MethodInvoker)delegate
                        {
                            this.progressBarTarefa.Maximum = _intProgressoMaximoTarefa;
                            this.progressBarTarefa.Refresh();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public string strTarefaDescricao
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_strTarefaDescricao))
                    {
                        return _strTarefaDescricao;
                    }

                    _strTarefaDescricao = "Rotina do sistema sendo executada...";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _strTarefaDescricao;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _strTarefaDescricao = value;
                    try
                    {
                        this.lblTarefaDescricao.Invoke((MethodInvoker)delegate
                        {
                            this.lblTarefaDescricao.Text = _strTarefaDescricao;
                            this.lblTarefaDescricao.Refresh();
                        });
                    }
                    catch
                    {
                        this.lblTarefaDescricao.Text = _strTarefaDescricao;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public string strTarefaTitulo
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_strTarefaTitulo))
                    {
                        return _strTarefaTitulo;
                    }

                    _strTarefaTitulo = "Por favor, aguarde.";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _strTarefaTitulo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _strTarefaTitulo = value;
                    try
                    {
                        this.lblTarefaTitulo.Invoke((MethodInvoker)delegate
                        {
                            this.lblTarefaTitulo.Text = _strTarefaTitulo;
                            this.lblTarefaTitulo.Refresh();
                        });
                    }
                    catch
                    {
                        this.lblTarefaTitulo.Text = _strTarefaTitulo;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public FrmEspera()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS

        #region EVENTOS

        private void FrmEspera_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (!this.booConcluido)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion EVENTOS
    }
}