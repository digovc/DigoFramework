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
                _objSelecionado = value;

                if (_objSelecionado == null)
                {
                    return;
                }

                this.ppgPropriedade.SelectedObject = _objSelecionado;
                this.lblNome.Text = _objSelecionado.strNome;
            }
        }

        private LabelTitulo lblNome
        {
            get
            {
                if (_lblNome != null)
                {
                    return _lblNome;
                }

                _lblNome = new LabelTitulo();
                _lblNome.Dock = DockStyle.Top;

                return _lblNome;
            }
        }

        private PainelEspaco pnlEspaco
        {
            get
            {
                if (_pnlEspaco != null)
                {
                    return _pnlEspaco;
                }

                _pnlEspaco = new PainelEspaco();

                _pnlEspaco.Dock = DockStyle.Top;

                return _pnlEspaco;
            }
        }

        private PropertyGrid ppgPropriedade
        {
            get
            {
                if (_ppgPropriedade != null)
                {
                    return _ppgPropriedade;
                }

                _ppgPropriedade = new PropertyGrid();

                _ppgPropriedade.Dock = DockStyle.Fill;

                return _ppgPropriedade;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void carregarDados()
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

        protected override DockState getEnmDockStateDefault()
        {
            return DockState.DockRight;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.Text = "Propriedades";
            this.ppgPropriedade.PropertyValueChanged += this.ppgPropriedade_PropertyValueChanged;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.pnlConteudo.Controls.Add(this.ppgPropriedade);
            this.pnlConteudo.Controls.Add(this.pnlEspaco);
            this.pnlConteudo.Controls.Add(this.lblNome);
        }

        private void processarObjetoAlterado()
        {
        }

        private void carregarDados(PropertyInfo objPropriedade)
        {
            if (objPropriedade == null)
            {
                return;
            }
        }

        #endregion Métodos

        #region Eventos

        private void ppgPropriedade_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.processarObjetoAlterado();
        }

        #endregion Eventos
    }
}