using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DigoFramework.DataBase;

namespace DigoFramework.Formulário
{
    public partial class FrmEdicao : FrmBase
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Boolean _booObrigatorio;
        public Boolean booObrigatorio
        {
            get { return _booObrigatorio; }
            set
            {
                _booObrigatorio = value;
                this.chbObrigatorio.Checked = _booObrigatorio;
            }
        }

        private int _intCampoIndex = 0;
        public int intCampoIndex
        {
            get { return _intCampoIndex; }
            set
            {
                this.atualizaColunasValores(_intCampoIndex);
                _intCampoIndex = value;
                if (_intCampoIndex + 1 == this.lstObjDbColuna.Count) { this.btnDireita.Visible = false; }
                else { this.btnDireita.Visible = true; }
                if (_intCampoIndex == 0) { this.btnEsquerda.Visible = false; }
                else { this.btnEsquerda.Visible = true; }
                this.preparaCampo();
            }
        }

        private List<Control> _lstObjControl = new List<Control>();
        public List<Control> lstObjControl { get { return _lstObjControl; } set { _lstObjControl = value; } }

        private List<DbColuna> _lstObjDbColuna = new List<DbColuna>();
        public List<DbColuna> lstObjDbColuna { get { return _lstObjDbColuna; } set { _lstObjDbColuna = value; } }

        private DbColuna _objDbColunaSelecionada;
        public DbColuna objDbColunaSelecionada
        {
            get { return _objDbColunaSelecionada; }
            set
            {
                _objDbColunaSelecionada = value;
                this.strTitulo = _objDbColunaSelecionada.strNomeExibicao;
                this.strDescricao = _objDbColunaSelecionada.strDescricao;
                this.booObrigatorio = _objDbColunaSelecionada.booObrigatorio;
                this.objDbColunaTipo = _objDbColunaSelecionada.objDbColunaTipo;
            }
        }

        private DigoFramework.DataBase.DbColuna.DbColunaTipo _objDbColunaTipo;
        private DigoFramework.DataBase.DbColuna.DbColunaTipo objDbColunaTipo
        {
            get { return _objDbColunaTipo; }
            set
            {
                #region VARIÁVEIS

                Control objComponentInsercaoDados;
                CheckBox objCheckBox = new CheckBox();
                ComboBox objComboBox = new ComboBox();
                DateTimePicker objDateTimePicker = new DateTimePicker();
                MaskedTextBox objMaskedTextBox = new MaskedTextBox();
                RichTextBox objRichTextBox = new RichTextBox();

                #endregion

                #region AÇÕES

                _objDbColunaTipo = value;

                objCheckBox.Checked = this.objDbColunaSelecionada.strValorPadrao.Equals("TRUE");
                objComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                objMaskedTextBox.Width = 487;
                objMaskedTextBox.MaxLength = this.objDbColunaSelecionada.intCampoTamanho;
                objRichTextBox.Width = 487;
                objRichTextBox.Height = 250;
                objRichTextBox.MaxLength = this.objDbColunaSelecionada.intCampoTamanho;
                if (this.lstObjControl.Count - 1 < this.intCampoIndex)
                {
                    objDateTimePicker.Format = DateTimePickerFormat.Custom;
                    objDateTimePicker.CustomFormat = "dd MMMM yyyy - H:mm:ss";
                    objMaskedTextBox.Mask = objDbColunaSelecionada.strMascara;
                    this.pnlCampoDados.Controls.Clear();
                    if (this.objDbColunaSelecionada.objDbViewReferencia != null)
                    {
                        objComboBox.DataSource = this.objDbColunaSelecionada.objDbViewReferencia.objDataTable;
                        objComboBox.ValueMember = "intId";
                        objComboBox.DisplayMember = "strColunaVisivel";
                        objComponentInsercaoDados = objComboBox;
                    }
                    else
                    {
                        switch (_objDbColunaTipo)
                        {
                            case DbColuna.DbColunaTipo.BOOLEAN:
                                objComponentInsercaoDados = objCheckBox;
                                break;
                            case DbColuna.DbColunaTipo.DATE:
                                objDateTimePicker.CustomFormat = "dd MMMM yyyy";
                                objComponentInsercaoDados = objDateTimePicker;
                                break;
                            case DbColuna.DbColunaTipo.ENUM:
                                foreach (String strItemNome in this.objDbColunaSelecionada.lstStrOpcoes)
                                {
                                    objComboBox.DisplayMember = "Text";
                                    objComboBox.ValueMember = "Value";
                                    objComboBox.Items.Add(new { Text = strItemNome, Value = strItemNome });
                                }
                                objComboBox.Text = this.objDbColunaSelecionada.strValorPadrao;
                                objComponentInsercaoDados = objComboBox;
                                break;
                            case DbColuna.DbColunaTipo.PASSWORD:
                                objMaskedTextBox.PasswordChar = '#';
                                objComponentInsercaoDados = objMaskedTextBox;
                                break;
                            case DbColuna.DbColunaTipo.TEXT:
                                objComponentInsercaoDados = objRichTextBox;
                                break;
                            case DbColuna.DbColunaTipo.TIME_WITH_TIME_ZONE:
                                objDateTimePicker.CustomFormat = "H:mm:ss";
                                objComponentInsercaoDados = objDateTimePicker;
                                break;
                            case DbColuna.DbColunaTipo.TIME_WITHOUT_TIME_ZONE:
                                objDateTimePicker.CustomFormat = "H:mm:ss";
                                objComponentInsercaoDados = objDateTimePicker;
                                break;
                            case DbColuna.DbColunaTipo.TIMESTAMP_WITH_TIME_ZONE:
                                objComponentInsercaoDados = objDateTimePicker;
                                break;
                            case DbColuna.DbColunaTipo.TIMESTAMP_WITHOUT_TIME_ZONE:
                                objComponentInsercaoDados = objDateTimePicker;
                                break;
                            default:
                                objComponentInsercaoDados = objMaskedTextBox;
                                break;
                        }
                    }
                    objComponentInsercaoDados.Location = new Point(10, 10);
                    objComponentInsercaoDados.Enabled = !this.objDbColunaSelecionada.booSomenteLeitura;
                    this.lstObjControl.Add(objComponentInsercaoDados);
                    this.pnlCampoDados.Controls.Add(objComponentInsercaoDados);
                }
                else
                {
                    this.lstObjControl[this.intCampoIndex].BringToFront();
                    this.pnlCampoDados.Controls.Clear();
                    this.pnlCampoDados.Controls.Add(this.lstObjControl[this.intCampoIndex]);
                }
                this.pnlCampoDados.Controls[0].Focus();

                #endregion
            }
        }

        private DbTabela _objDbTabelaPrincipal;
        public DbTabela objDbTabelaPrincipal
        {
            get { return _objDbTabelaPrincipal; }
            set
            {
                _objDbTabelaPrincipal = value;
                this.lstObjDbColuna = _objDbTabelaPrincipal.lstObjDbColunaVisivel;

            }
        }

        private string _strDescricao = string.Empty;
        public string strDescricao
        {
            get { return _strDescricao; }
            set
            {
                _strDescricao = value;
                this.lblCampoDescricao.Text = _strDescricao;
            }
        }

        private string _strTitulo = string.Empty;
        public string strTitulo
        {
            get { return _strTitulo; }
            set
            {
                _strTitulo = value;
                this.lblCampoTitulo.Text = _strTitulo;
            }
        }

        #endregion

        #region CONSTRUTORES

        public FrmEdicao()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            InitializeComponent();

            #endregion
        }

        #endregion

        #region MÉTODOS

        private void preparaCampo()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objDbColunaSelecionada = this.lstObjDbColuna[this.intCampoIndex];

            #endregion
        }

        private void atualizaColunasValores(Int32 intCampoIndex)
        {
            #region VARIÁVEIS

            String strCampoValor = Utils.STRING_VAZIA;
            Control objControl;

            #endregion

            #region AÇÕES

            if (this.lstObjControl.Count > 0)
            {
                objControl = this.lstObjControl[intCampoIndex];
                if (objControl.GetType() == typeof(CheckBox))
                {
                    CheckBox objControlTemp = (CheckBox)objControl;
                    strCampoValor = (objControlTemp.Checked ? "TRUE" : "FALSE");
                }
                if (objControl.GetType() == typeof(ComboBox))
                {
                    ComboBox objControlTemp = (ComboBox)objControl;
                    try { strCampoValor = objControlTemp.SelectedValue.ToString(); }
                    catch { strCampoValor = objControlTemp.Text; }
                }
                if (objControl.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker objControlTemp = (DateTimePicker)objControl;
                    strCampoValor = objControlTemp.Value.ToString();
                }
                if (objControl.GetType() == typeof(MaskedTextBox))
                {
                    strCampoValor = objControl.Text;
                }
                if (objControl.GetType() == typeof(RichTextBox))
                {
                    strCampoValor = objControl.Text;
                }
                this.objDbColunaSelecionada.strValor = strCampoValor;
            }

            #endregion
        }

        #endregion

        #region EVENTOS

        private void FrmEdicao_KeyDown(object sender, KeyEventArgs e)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            if (e.Control && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Back:
                        if (this.btnEsquerda.Visible) { this.btnEsquerda_Click(this, e); }
                        break;
                    case Keys.Enter:
                        if (this.btnDireita.Visible) { this.btnDireita_Click(this, e); }
                        break;
                    case Keys.Left:
                        if (this.btnEsquerda.Visible) { this.btnEsquerda_Click(this, e); }
                        break;
                    case Keys.Right:
                        if (this.btnDireita.Visible) { this.btnDireita_Click(this, e); }
                        break;
                    default:
                        break;
                }
                e.Handled = true;
            }

            #endregion
        }

        private void FrmEdicao_Shown(object sender, System.EventArgs e)
        {
            #region VARIÁVEIS

            //this.objDbTabelaPrincipal = Program.objAplicativoGetemp.objTabelaSelecionada;

            #endregion

            #region AÇÕES

            preparaCampo();

            #endregion
        }

        private void btnDireita_Click(object sender, System.EventArgs e)
        {
            this.intCampoIndex = this.intCampoIndex + 1;
        }

        private void btnEsquerda_Click(object sender, System.EventArgs e)
        {
            this.intCampoIndex = this.intCampoIndex - 1;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.atualizaColunasValores(this.intCampoIndex);
            try
            {
                this.objDbTabelaPrincipal.salvarRegistro();
                MessageBox.Show("Registro salvo com sucesso.", "Confirmação");
                this.Close();
            }
            catch (Exception ex) { new Erro("Erro ao salvar registro.", ex, Erro.ErroTipo.BancoDados); }

            #endregion
        }

        #endregion
    }
}
