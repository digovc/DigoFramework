using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Frm
{
    public partial class FrmBase : Form
    {
        #region Constantes

        public enum EnmTipo
        {
            NORMAL,
            SOBRE,
        }

        #endregion Constantes

        #region Atributos

        protected ToolTip ttp;

        private static int _intFrmIdStatic;
        private bool _booSairEsc = true;
        private EnmTipo _enmTipo = EnmTipo.NORMAL;
        private int _intFrmId;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string AccessibleDescription
        {
            get
            {
                return base.AccessibleDescription;
            }

            private set
            {
                base.AccessibleDescription = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string AccessibleName
        {
            get
            {
                return base.AccessibleName;
            }

            private set
            {
                base.AccessibleName = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return base.AccessibleRole;
            }

            private set
            {
                base.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }

            private set
            {
                base.AllowDrop = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new SizeF AutoScaleDimensions
        {
            get
            {
                return base.AutoScaleDimensions;
            }

            private set
            {
                base.AutoScaleDimensions = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AutoScaleMode AutoScaleMode
        {
            get
            {
                return base.AutoScaleMode;
            }

            private set
            {
                base.AutoScaleMode = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }

            private set
            {
                base.AutoScroll = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size AutoScrollMargin
        {
            get
            {
                return base.AutoScrollMargin;
            }

            private set
            {
                base.AutoScrollMargin = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size AutoScrollMinSize
        {
            get
            {
                return base.AutoScrollMinSize;
            }

            private set
            {
                base.AutoScrollMinSize = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }

            private set
            {
                base.AutoSize = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AutoSizeMode AutoSizeMode
        {
            get
            {
                return base.AutoSizeMode;
            }

            private set
            {
                base.AutoSizeMode = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AutoValidate AutoValidate
        {
            get
            {
                return base.AutoValidate;
            }

            private set
            {
                base.AutoValidate = value;
            }
        }

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Color BackColor
        //{
        //    get
        //    {
        //        return base.BackColor;
        //    }

        //    private set
        //    {
        //        base.BackColor = value;
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Image BackgroundImage
        //{
        //    get
        //    {
        //        return base.BackgroundImage;
        //    }

        //    private set
        //    {
        //        base.BackgroundImage = value;
        //    }
        //}

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }

            private set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool CausesValidation
        {
            get
            {
                return base.CausesValidation;
            }

            private set
            {
                base.CausesValidation = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return base.ContextMenuStrip;
            }

            private set
            {
                base.ContextMenuStrip = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool ControlBox
        {
            get
            {
                return base.ControlBox;
            }

            private set
            {
                base.ControlBox = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool DoubleBuffered
        {
            get
            {
                return base.DoubleBuffered;
            }

            private set
            {
                base.DoubleBuffered = value;
            }
        }

        /// <summary>
        /// Indica o tipo deste formulário.
        /// </summary>
        [Description("Tipo deste formulário.")]
        [DefaultValue(EnmTipo.NORMAL)]
        public EnmTipo enmTipo
        {
            get
            {
                return _enmTipo;
            }

            set
            {
                if (_enmTipo == value)
                {
                    return;
                }

                _enmTipo = value;

                this.setEnmTipo(_enmTipo);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get
            {
                return base.Font;
            }

            private set
            {
                base.Font = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            private set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return base.FormBorderStyle;
            }

            protected set
            {
                base.FormBorderStyle = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool HelpButton
        {
            get
            {
                return base.HelpButton;
            }

            private set
            {
                base.HelpButton = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Icon Icon
        {
            get
            {
                return base.Icon;
            }

            protected set
            {
                base.Icon = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }

            private set
            {
                base.ImeMode = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool KeyPreview
        {
            get
            {
                return base.KeyPreview;
            }

            private set
            {
                base.KeyPreview = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool MaximizeBox
        {
            get
            {
                return base.MaximizeBox;
            }

            protected set
            {
                base.MaximizeBox = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }

            private set
            {
                base.MaximumSize = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool MinimizeBox
        {
            get
            {
                return base.MinimizeBox;
            }

            protected set
            {
                base.MinimizeBox = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }

            private set
            {
                base.MinimumSize = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new double Opacity
        {
            get
            {
                return base.Opacity;
            }

            private set
            {
                base.Opacity = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }

            private set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool RightToLeftLayout
        {
            get
            {
                return base.RightToLeftLayout;
            }

            private set
            {
                base.RightToLeftLayout = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool ShowIcon
        {
            get
            {
                return base.ShowIcon;
            }

            private set
            {
                base.ShowIcon = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool ShowInTaskbar
        {
            get
            {
                return base.ShowInTaskbar;
            }

            private set
            {
                base.ShowInTaskbar = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new SizeGripStyle SizeGripStyle
        {
            get
            {
                return base.SizeGripStyle;
            }

            private set
            {
                base.SizeGripStyle = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormStartPosition StartPosition
        {
            get
            {
                return base.StartPosition;
            }

            private set
            {
                base.StartPosition = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new object Tag
        {
            get
            {
                return base.Tag;
            }

            private set
            {
                base.Tag = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool TopMost
        {
            get
            {
                return base.TopMost;
            }

            protected set
            {
                base.TopMost = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color TransparencyKey
        {
            get
            {
                return base.TransparencyKey;
            }

            private set
            {
                base.TransparencyKey = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseWaitCursor
        {
            get
            {
                return base.UseWaitCursor;
            }

            protected set
            {
                base.UseWaitCursor = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormWindowState WindowState
        {
            get
            {
                return base.WindowState;
            }

            protected set
            {
                base.WindowState = value;
            }
        }

        protected bool booSairEsc
        {
            get
            {
                return _booSairEsc;
            }

            set
            {
                _booSairEsc = value;
            }
        }

        protected int intFrmId
        {
            get
            {
                if (_intFrmId > 0)
                {
                    return _intFrmId;
                }

                _intFrmId = intFrmIdStatic++;

                return _intFrmId;
            }
        }

        private static int intFrmIdStatic
        {
            get
            {
                return _intFrmIdStatic;
            }

            set
            {
                _intFrmIdStatic = value;
            }
        }

        #endregion Atributos

        #region Construtores

        protected FrmBase()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Carrega o título do formulário com o nome de exibição da tabela.
        /// </summary>
        protected void carregarTitulo(string strTitulo)
        {
            string strTituloDefault = string.IsNullOrEmpty(strTitulo) ? string.Empty : " ";

            strTituloDefault += strTitulo;

            this.Text = strTituloDefault;
        }

        protected virtual void finalizar()
        {
        }

        protected virtual void inicializar()
        {
        }

        /// <summary>
        /// Método chamado dentro do "load" do formulário para configurar componentes e outras
        /// alterações de layout.
        /// </summary>
        protected virtual void montarLayout()
        {
        }

        /// <summary>
        /// Método que deve ser sobescrito para interceptar os atalhos do teclado acionados.
        /// </summary>
        protected virtual void onKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && this.booSairEsc)
            {
                this.Close();
            }
        }

        protected virtual void setEventos()
        {
        }

        private void setEnmTipo(EnmTipo enmTipo)
        {
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            switch (enmTipo)
            {
                case EnmTipo.SOBRE:
                    this.ControlBox = false;
                    this.FormBorderStyle = FormBorderStyle.FixedDialog;
                    return;
            }
        }

        private void iniciar()
        {
            this.inicializar();
            this.montarLayout();
            this.setEventos();
            this.finalizar();
        }

        #endregion Métodos

        #region Eventos

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            try
            {
                this.onKeyDown(e);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.EnmTipo.ERRO);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                this.iniciar();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.EnmTipo.ERRO);
            }
        }

        #endregion Eventos
    }
}