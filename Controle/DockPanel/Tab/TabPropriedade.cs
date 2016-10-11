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
                if (_objSelecionado == value)
                {
                    return;
                }

                _objSelecionado = value;

                this.setObjSelecionado(_objSelecionado);
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

                return _ppgPropriedade;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override DockState getEnmDockStateDefault()
        {
            return DockState.DockRight;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.Text = "Propriedades";

            this.lblNome.Dock = DockStyle.Top;
            this.pnlEspaco.Dock = DockStyle.Top;
            this.ppgPropriedade.Dock = DockStyle.Fill;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.pnlConteudo.Controls.Add(this.ppgPropriedade);
            this.pnlConteudo.Controls.Add(this.pnlEspaco);
            this.pnlConteudo.Controls.Add(this.lblNome);
        }

        protected override void setEventos()
        {
            base.setEventos();

            this.ppgPropriedade.PropertyValueChanged += this.ppgPropriedade_PropertyValueChanged;
        }

        private void processarObjetoAlterado()
        {
        }

        private void setObjSelecionado(Objeto objSelecionado)
        {
            if (objSelecionado == null)
            {
                return;
            }

            this.ppgPropriedade.SelectedObject = objSelecionado;

            this.lblNome.Text = objSelecionado.strNome;
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