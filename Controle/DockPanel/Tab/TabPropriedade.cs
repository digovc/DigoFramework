using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using DigoFramework.Controle.Label;
using DigoFramework.Controle.Painel;
using WeifenLuo.WinFormsUI.Docking;

namespace DigoFramework.Controle.DockPanel.Tab
{
    public class TabPropriedade : TabToolBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private LabelTitulo _lblNome;
        private Objeto _objSelecionado;
        private PainelEspaco _pnlEspaco;
        private PropertyGrid _ppgPropriedade;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Objeto objSelecionado
        {
            get
            {
                return _objSelecionado;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _objSelecionado = value;

                    if (_objSelecionado == null)
                    {
                        return;
                    }

                    this.ppgPropriedade.SelectedObject = _objSelecionado;
                    this.lblNome.Text = _objSelecionado.strNome;
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

        private LabelTitulo lblNome
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lblNome != null)
                    {
                        return _lblNome;
                    }

                    _lblNome = new LabelTitulo();
                    _lblNome.Dock = DockStyle.Top;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lblNome;
            }
        }

        private PainelEspaco pnlEspaco
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_pnlEspaco != null)
                    {
                        return _pnlEspaco;
                    }

                    _pnlEspaco = new PainelEspaco();

                    _pnlEspaco.Dock = DockStyle.Top;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _pnlEspaco;
            }
        }

        private PropertyGrid ppgPropriedade
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_ppgPropriedade != null)
                    {
                        return _ppgPropriedade;
                    }

                    _ppgPropriedade = new PropertyGrid();

                    _ppgPropriedade.Dock = DockStyle.Fill;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _ppgPropriedade;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void carregarDados()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.objSelecionado == null)
                {
                    return;
                }

                PropertyInfo[] arrObjPropriedades = this.objSelecionado.GetType().GetProperties();

                foreach (PropertyInfo objPropriedade in arrObjPropriedades)
                {
                    this.carregarDados(objPropriedade);
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
        }

        protected override DockState getEnmDockStateDefault()
        {
            return DockState.DockRight;
        }

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.Text = "Propriedades";
                this.ppgPropriedade.PropertyValueChanged += this.ppgPropriedade_PropertyValueChanged;
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

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.pnlConteudo.Controls.Add(this.ppgPropriedade);
                this.pnlConteudo.Controls.Add(this.pnlEspaco);
                this.pnlConteudo.Controls.Add(this.lblNome);
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

        private void processarObjetoAlterado()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                //this.objSelecionado.chamarOnValorAlterado();
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

        private void carregarDados(PropertyInfo objPropriedade)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objPropriedade == null)
                {
                    return;
                }

                //foreach (CustomAttributeData objCustomAttributeData in objPropriedade.CustomAttributes)
                //{
                //    if (objCustomAttributeData == null)
                //    {
                //        continue;
                //    }

                //    if ("[System.ComponentModel.BrowsableAttribute((Boolean)False)]".Equals(objCustomAttributeData.ToString()))
                //    {
                //        return;
                //    }
                //}
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

        #endregion Métodos

        #region Eventos

        private void ppgPropriedade_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.processarObjetoAlterado();
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