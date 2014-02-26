using DigoFramework.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.form
{
    public partial class FrmCadastro : FrmBase, IFrmCadastro
    {
        #region CONSTANTES

        public enum EnmDialogResult
        {
            REGISTRO_ALTERADO, REGISTRO_INALTERADO
        }

        #endregion

        #region ATRIBUTOS

        private Boolean _booObrigatorio;
        public Boolean booObrigatorio
        {
            get { return _booObrigatorio; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _booObrigatorio = value;
                    this.chbObrigatorio.Checked = _booObrigatorio;

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

        private int _intCampoIndex = 0;
        public int intCampoIndex
        {
            get { return _intCampoIndex; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    this.atualizarClnValor(_intCampoIndex);

                    _intCampoIndex = value;

                    if (_intCampoIndex + 1 == this.lstCln.Count)
                    {
                        this.btnDireita.Visible = false;
                    }
                    else
                    {
                        this.btnDireita.Visible = true;
                    }

                    if (_intCampoIndex == 0)
                    {
                        this.btnEsquerda.Visible = false;
                    }
                    else
                    {
                        this.btnEsquerda.Visible = true;
                    }

                    this.prepararCampo();

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

        private int _intRegistroId;
        protected int intRegistroId { get { return _intRegistroId; } set { _intRegistroId = value; } }

        private List<Control> _lstObjControl;
        public List<Control> lstObjControl
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_lstObjControl == null)
                    {
                        _lstObjControl = new List<Control>();
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
                return _lstObjControl;
            }
            set { _lstObjControl = value; }
        }

        private List<DbColuna> _lstCln;
        public List<DbColuna> lstCln
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_lstCln == null)
                    {
                        _lstCln = this.tbl.lstCln;
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

                return _lstCln;
            }
        }

        private DbColuna _clnSelecionada;
        public DbColuna clnSelecionada
        {
            get { return _clnSelecionada; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _clnSelecionada = value;

                    this.strTitulo = _clnSelecionada.strNomeExibicao;
                    this.strDescricao = _clnSelecionada.strDescricao;
                    this.booObrigatorio = _clnSelecionada.booObrigatorio;
                    this.enmDbColunaTipo = _clnSelecionada.enmDbColunaTipo;

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

        private DigoFramework.database.DbColuna.EnmDbColunaTipo _enmDbColunaTipo;
        private DigoFramework.database.DbColuna.EnmDbColunaTipo enmDbColunaTipo
        {
            get { return _enmDbColunaTipo; }
            set
            {
                #region VARIÁVEIS

                Control objComponentInsercaoDados;
                CheckBox objCheckBox;
                ComboBox objComboBox;
                DateTimePicker objDateTimePicker;
                MaskedTextBox objMaskedTextBox;
                RichTextBox objRichTextBox;

                #endregion
                try
                {
                    #region AÇÕES

                    _enmDbColunaTipo = value;

                    objCheckBox = new CheckBox();
                    objCheckBox.Checked = this.clnSelecionada.strValorPadrao.Equals("TRUE");

                    objComboBox = new ComboBox();
                    objComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                    objMaskedTextBox = new MaskedTextBox();
                    objMaskedTextBox.Width = 487;
                    objMaskedTextBox.MaxLength = this.clnSelecionada.intTamanho;

                    objRichTextBox = new RichTextBox();
                    objRichTextBox.Width = 487;
                    objRichTextBox.Height = 250;
                    objRichTextBox.MaxLength = this.clnSelecionada.intTamanho;

                    if (this.lstObjControl.Count - 1 < this.intCampoIndex)
                    {
                        objDateTimePicker = new DateTimePicker();
                        objDateTimePicker.Format = DateTimePickerFormat.Custom;
                        objDateTimePicker.CustomFormat = "dd MMMM yyyy - H:mm:ss";

                        objMaskedTextBox.Mask = clnSelecionada.strMascara;
                        this.pnlCampoDados.Controls.Clear();

                        if (this.clnSelecionada.objDbViewReferencia != null)
                        {
                            objComboBox.DataSource = this.clnSelecionada.objDbViewReferencia.objDataTable;
                            objComboBox.ValueMember = "int_id";
                            objComboBox.DisplayMember = "str_coluna_visivel";
                            objComponentInsercaoDados = objComboBox;
                        }
                        else
                        {
                            switch (_enmDbColunaTipo)
                            {
                                case DbColuna.EnmDbColunaTipo.BOOLEAN:
                                    objComponentInsercaoDados = objCheckBox;
                                    break;
                                case DbColuna.EnmDbColunaTipo.DATE:
                                    objDateTimePicker.CustomFormat = "dd MMMM yyyy";
                                    objComponentInsercaoDados = objDateTimePicker;
                                    break;
                                case DbColuna.EnmDbColunaTipo.ENUM:
                                    foreach (String strItemNome in this.clnSelecionada.lstStrOpcoes)
                                    {
                                        objComboBox.DisplayMember = "Text";
                                        objComboBox.ValueMember = "Value";
                                        objComboBox.Items.Add(new { Text = strItemNome, Value = strItemNome });
                                    }
                                    objComboBox.Text = this.clnSelecionada.strValorPadrao;
                                    objComponentInsercaoDados = objComboBox;
                                    break;
                                case DbColuna.EnmDbColunaTipo.PASSWORD:
                                    objMaskedTextBox.PasswordChar = '#';
                                    objComponentInsercaoDados = objMaskedTextBox;
                                    break;
                                case DbColuna.EnmDbColunaTipo.TEXT:
                                    objComponentInsercaoDados = objRichTextBox;
                                    break;
                                case DbColuna.EnmDbColunaTipo.TIME_WITH_TIME_ZONE:
                                    objDateTimePicker.CustomFormat = "H:mm:ss";
                                    objComponentInsercaoDados = objDateTimePicker;
                                    break;
                                case DbColuna.EnmDbColunaTipo.TIME_WITHOUT_TIME_ZONE:
                                    objDateTimePicker.CustomFormat = "H:mm:ss";
                                    objComponentInsercaoDados = objDateTimePicker;
                                    break;
                                case DbColuna.EnmDbColunaTipo.TIMESTAMP_WITH_TIME_ZONE:
                                    objComponentInsercaoDados = objDateTimePicker;
                                    break;
                                case DbColuna.EnmDbColunaTipo.TIMESTAMP_WITHOUT_TIME_ZONE:
                                    objComponentInsercaoDados = objDateTimePicker;
                                    break;
                                default:
                                    objComponentInsercaoDados = objMaskedTextBox;
                                    break;
                            }
                        }

                        objComponentInsercaoDados.Location = new Point(10, 10);
                        objComponentInsercaoDados.Enabled = !this.clnSelecionada.booSomenteLeitura;

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
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
        }

        private DbTabela _tbl;
        public DbTabela tbl
        {
            get { return _tbl; }
            set
            {
                _tbl = value;
            }
        }

        private string _strDescricao = string.Empty;
        public string strDescricao
        {
            get { return _strDescricao; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _strDescricao = value;
                    this.lblCampoDescricao.Text = _strDescricao;

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

        private string _strTitulo = string.Empty;
        public string strTitulo
        {
            get { return _strTitulo; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _strTitulo = value;
                    this.lblCampoTitulo.Text = _strTitulo;

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

        public FrmCadastro(int intRegistroId = 0)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.intRegistroId = intRegistroId;
                this.InitializeComponent();

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

        #endregion

        #region MÉTODOS

        private void atualizarClnValor(Int32 intCampoIndex)
        {
            #region VARIÁVEIS

            String strCampoValor = Utils.STRING_VAZIA;
            Control objControl;

            #endregion
            try
            {
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

                    this.clnSelecionada.strValor = strCampoValor;
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

        public virtual void carregarDados()
        {
        }

        public virtual void carregarRegistro()
        {
        }

        public virtual void salvarRegistro()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.atualizarClnValor(this.intCampoIndex);
                this.tbl.salvarRegistro();
                MessageBox.Show("Registro salvo com sucesso.", "Confirmação");
                this.Close();

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

        private void prepararCampo()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.clnSelecionada = this.lstCln[this.intCampoIndex];

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

        public virtual void setFocoInicial()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.btnSalvar.Focus();

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

        protected override void verificarAtalhoAcionado(KeyEventArgs e)
        {

            base.verificarAtalhoAcionado(e);

            #region VARIÁVEIS
            #endregion
            try
            {
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

                if (e.Control && e.KeyCode == Keys.S)
                {
                    this.btnSalvar_Click(this, e);
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

        #endregion

        #region EVENTOS

        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                if (this.DesignMode)
                {
                    return;
                }

                this.carregarDados();

                if (this.tbl.intIdRegistroSelecionado > 0)
                {
                    this.carregarRegistro();
                }

                this.carregarTitulo(this.tbl.strNomeExibicao);

                #endregion
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.Fatal);
            }
            finally
            {
            }
        }

        private void btnDireita_Click(object sender, System.EventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.intCampoIndex = this.intCampoIndex + 1;

                #endregion
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.Fatal);
            }
            finally
            {
            }
        }

        private void btnEsquerda_Click(object sender, System.EventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.intCampoIndex = this.intCampoIndex - 1;

                #endregion
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.Fatal);
            }
            finally
            {
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.Close();

                #endregion
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.Fatal);
            }
            finally
            {
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.salvarRegistro();

                #endregion
            }
            catch (Exception ex)
            {
                new Erro("Erro ao salvar registro.", ex, Erro.ErroTipo.BancoDados);
            }
            finally
            {
            }
        }

        #endregion
    }
}
