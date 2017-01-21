using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Tab
{
    public partial class TabBase : TabControl
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string AccessibleDescription
        {
            get
            {
                return base.AccessibleDescription;
            }

            protected set
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

            protected set
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

            protected set
            {
                base.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TabAlignment Alignment
        {
            get
            {
                return base.Alignment;
            }

            protected set
            {
                base.Alignment = value;
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

            protected set
            {
                base.AllowDrop = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AnchorStyles Anchor
        {
            get
            {
                return base.Anchor;
            }

            protected set
            {
                base.Anchor = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TabAppearance Appearance
        {
            get
            {
                return base.Appearance;
            }

            protected set
            {
                base.Appearance = value;
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

            protected set
            {
                base.AutoSize = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            protected set
            {
                base.BackColor = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }

            protected set
            {
                base.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }

            protected set
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

            protected set
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

            protected set
            {
                base.ContextMenuStrip = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Cursor Cursor
        {
            get
            {
                return base.Cursor;
            }

            protected set
            {
                base.Cursor = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DockStyle Dock
        {
            get
            {
                return base.Dock;
            }

            protected set
            {
                base.Dock = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TabDrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }

            protected set
            {
                base.DrawMode = value;
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

            protected set
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

            protected set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool HotTrack
        {
            get
            {
                return base.HotTrack;
            }

            protected set
            {
                base.HotTrack = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageList ImageList
        {
            get
            {
                return base.ImageList;
            }

            protected set
            {
                base.ImageList = value;
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

            protected set
            {
                base.ImeMode = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size ItemSize
        {
            get
            {
                return base.ItemSize;
            }

            protected set
            {
                base.ItemSize = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Point Location
        {
            get
            {
                return base.Location;
            }

            protected set
            {
                base.Location = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Margin
        {
            get
            {
                return base.Margin;
            }

            protected set
            {
                base.Margin = value;
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

            protected set
            {
                base.MaximumSize = value;
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

            protected set
            {
                base.MinimumSize = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Multiline
        {
            get
            {
                return base.Multiline;
            }

            protected set
            {
                base.Multiline = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Point Padding
        {
            get
            {
                return base.Padding;
            }

            protected set
            {
                base.Padding = value;
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

            protected set
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

            protected set
            {
                base.RightToLeftLayout = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool ShowToolTips
        {
            get
            {
                return base.ShowToolTips;
            }

            protected set
            {
                base.ShowToolTips = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get
            {
                return base.Size;
            }

            protected set
            {
                base.Size = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TabSizeMode SizeMode
        {
            get
            {
                return base.SizeMode;
            }

            protected set
            {
                base.SizeMode = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool TabStop
        {
            get
            {
                return base.TabStop;
            }

            protected set
            {
                base.TabStop = value;
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

            protected set
            {
                base.Tag = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            protected set
            {
                base.Text = value;
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

        #endregion Atributos

        #region Construtores

        public TabBase()
        {
            this.InitializeComponent();

            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

        protected virtual void finalizar()
        {
        }

        protected virtual void inicializar()
        {
            this.Appearance = TabAppearance.FlatButtons;
            this.Dock = DockStyle.Bottom;
            this.Padding = new Point(10, 2);
            this.ShowToolTips = true;
            this.SizeMode = TabSizeMode.Fixed;
        }

        protected virtual void montarLayout()
        {
        }

        protected virtual void setEventos()
        {
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

        #endregion Eventos
    }
}