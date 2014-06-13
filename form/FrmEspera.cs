using System;
using System.Windows.Forms;

namespace DigoFramework.form
{
    public partial class FrmEspera : FrmBase
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Boolean _booConcluido = false;
        public Boolean booConcluido
        {
            get { return _booConcluido; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _booConcluido = value;
                    if (_booConcluido)
                    {
                        try
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.progressBarTarefa.Visible = false;
                                this.Close();
                            });
                        }
                        catch { }
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
            }
        }

        private Double _dblProgresso = 0;
        public Double dblProgresso
        {
            get { return _dblProgresso; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _dblProgresso = value;

                    if (_dblProgresso > 0)
                    {
                        try
                        {
                            this.progressBar.Invoke((MethodInvoker)delegate
                            {
                                this.progressBar.Style = ProgressBarStyle.Blocks;
                                this.progressBar.Value = Convert.ToInt32(_dblProgresso);
                                Application.DoEvents();
                            });
                        }
                        catch { }
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
            }
        }

        private int _intProgressoMaximo;
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
                #endregion
                try
                {
                    #region AÇÕES

                    _intProgressoMaximo = value;
                    try
                    {
                        this.progressBar.Invoke((MethodInvoker)delegate
                        {
                            this.progressBar.Maximum = _intProgressoMaximo;
                            Application.DoEvents();
                        });
                    }
                    catch { }

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
        }

        private Double _dblProgressoTarefa = 0;
        public Double dblProgressoTarefa
        {
            get { return _dblProgressoTarefa; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _dblProgressoTarefa = value;

                    if (_dblProgressoTarefa > 0)
                    {
                        try
                        {
                            this.progressBarTarefa.Invoke((MethodInvoker)delegate
                            {
                                if (_dblProgressoTarefa >= this.progressBarTarefa.Value)
                                {
                                    this.progressBarTarefa.Visible = false;
                                    Application.DoEvents();
                                    return;
                                }

                                this.progressBarTarefa.Style = ProgressBarStyle.Blocks;
                                this.progressBarTarefa.Visible = true;
                                this.progressBarTarefa.Value = Convert.ToInt32(_dblProgressoTarefa);
                                Application.DoEvents();
                            });
                        }
                        catch { }
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
            }
        }

        private int _intProgressoMaximoTarefa;
        public int intProgressoMaximoTarefa
        {
            get
            {
                #region VARIÁVEIS
                #endregion

                #region AÇÕES
                try
                {
                    _intProgressoMaximoTarefa = this.progressBar.Maximum;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                #endregion

                return _intProgressoMaximoTarefa;
            }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _intProgressoMaximoTarefa = value;
                    try
                    {
                        this.progressBarTarefa.Invoke((MethodInvoker)delegate
                        {
                            this.progressBarTarefa.Maximum = _intProgressoMaximoTarefa;
                            Application.DoEvents();
                        });
                    }
                    catch { }

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
        }

        private string _strTarefaDescricao = "Rotina do sistema sendo executada...";
        public string strTarefaDescricao
        {
            get { return _strTarefaDescricao; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _strTarefaDescricao = value;
                    try
                    {
                        this.lblTarefaDescricao.Invoke((MethodInvoker)delegate
                        {
                            this.lblTarefaDescricao.Text = _strTarefaDescricao;
                            Application.DoEvents();
                        });
                    }
                    catch
                    {
                        this.lblTarefaDescricao.Text = _strTarefaDescricao;
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
            }
        }

        private string _strTarefaTitulo = "Por favor, aguarde.";
        public string strTarefaTitulo
        {
            get { return _strTarefaTitulo; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _strTarefaTitulo = value;
                    try
                    {
                        this.lblTarefaTitulo.Invoke((MethodInvoker)delegate
                        {
                            this.lblTarefaTitulo.Text = _strTarefaTitulo;
                            Application.DoEvents();
                        });
                    }
                    catch
                    {
                        this.lblTarefaTitulo.Text = _strTarefaTitulo;
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
            }
        }

        #endregion

        #region CONSTRUTORES

        public FrmEspera()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            InitializeComponent();

            #endregion
        }

        #endregion

        #region MÉTODOS
        #endregion

        #region EVENTOS

        private void FrmEspera_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            if (!this.booConcluido)
            {
                e.Cancel = true;
            }

            #endregion
        }

        #endregion
    }
}
