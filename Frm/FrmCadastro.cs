using DigoFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Frm
{
    public partial class FrmCadastro : FrmMain, IFrmCadastro
    {
        #region CONSTANTES

        public enum EnmDialogResult
        {
            REGISTRO_ALTERADO,
            REGISTRO_INALTERADO
        }

        #endregion

        #region ATRIBUTOS

        private bool _booObrigatorio;
        private DbColuna _clnSelecionada;
        private DbColuna.EnmTipo _enmDbColunaTipo;
        private int _intCampoIndex;
        private int _intRegistroId;
        private List<DbColuna> _lstCln;
        private List<Control> _lstObjControl;
        private string _strDescricao;
        private string _strTitulo;
        private DbTabela _tbl;

        public bool booObrigatorio
        {
            get
            {
                return _booObrigatorio;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _booObrigatorio = value;

                    this.chbObrigatorio.Checked = _booObrigatorio;
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

        public DbColuna clnSelecionada
        {
            get
            {
                return _clnSelecionada;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _clnSelecionada = value;

                    this.strTitulo = _clnSelecionada.strNomeExibicao;
                    this.strDescricao = _clnSelecionada.strDescricao;
                    this.booObrigatorio = _clnSelecionada.booObrigatorio;
                    this.enmDbColunaTipo = _clnSelecionada.enmTipo;
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

        public int intCampoIndex
        {
            get
            {
                return _intCampoIndex;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
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

        public List<DbColuna> lstCln
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstCln == null)
                    {
                        _lstCln = this.tbl.lstCln;
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

                return _lstCln;
            }
        }

        public List<Control> lstObjControl
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstObjControl == null)
                    {
                        _lstObjControl = new List<Control>();
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

                return _lstObjControl;
            }

            set
            {
                _lstObjControl = value;
            }
        }

        public string strDescricao
        {
            get
            {
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

                    this.lblCampoDescricao.Text = _strDescricao;
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

                    this.lblCampoTitulo.Text = _strTitulo;
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

        public DbTabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                _tbl = value;
            }
        }

        protected int intRegistroId
        {
            get
            {
                return _intRegistroId;
            }

            set
            {
                _intRegistroId = value;
            }
        }

        private DbColuna.EnmTipo enmDbColunaTipo
        {
            get
            {
                return _enmDbColunaTipo;
            }

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

                #region AÇÕES

                try
                {
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
                                case DbColuna.EnmTipo.BOOLEAN:
                                    objComponentInsercaoDados = objCheckBox;
                                    break;

                                case DbColuna.EnmTipo.DATE:
                                    objDateTimePicker.CustomFormat = "dd MMMM yyyy";
                                    objComponentInsercaoDados = objDateTimePicker;
                                    break;

                                case DbColuna.EnmTipo.ENUM:
                                    foreach (string strItemNome in this.clnSelecionada.lstStrOpcoes)
                                    {
                                        objComboBox.DisplayMember = "Text";
                                        objComboBox.ValueMember = "Value";
                                        objComboBox.Items.Add(new
                                        {
                                            Text = strItemNome,
                                            Value = strItemNome
                                        });
                                    }
                                    objComboBox.Text = this.clnSelecionada.strValorPadrao;
                                    objComponentInsercaoDados = objComboBox;
                                    break;

                                case DbColuna.EnmTipo.PASSWORD:
                                    objMaskedTextBox.PasswordChar = '#';
                                    objComponentInsercaoDados = objMaskedTextBox;
                                    break;

                                case DbColuna.EnmTipo.TEXT:
                                    objComponentInsercaoDados = objRichTextBox;
                                    break;

                                case DbColuna.EnmTipo.TIME_WITH_TIME_ZONE:
                                    objDateTimePicker.CustomFormat = "H:mm:ss";
                                    objComponentInsercaoDados = objDateTimePicker;
                                    break;

                                case DbColuna.EnmTipo.TIME_WITHOUT_TIME_ZONE:
                                    objDateTimePicker.CustomFormat = "H:mm:ss";
                                    objComponentInsercaoDados = objDateTimePicker;
                                    break;

                                case DbColuna.EnmTipo.TIMESTAMP_WITH_TIME_ZONE:
                                    objComponentInsercaoDados = objDateTimePicker;
                                    break;

                                case DbColuna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE:
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

        public FrmCadastro(int intRegistroId = 0)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.intRegistroId = intRegistroId;
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

        #region MÉTODOS

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

            #region AÇÕES

            try
            {
                this.atualizarClnValor(this.intCampoIndex);
                this.tbl.salvarRegistro();
                MessageBox.Show("Registro salvo com sucesso.", "Confirmação");
                this.Close();
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

        public virtual void setFocoInicial()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.btnSalvar.Focus();
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

        protected override void verificarAtalhoAcionado(KeyEventArgs e)
        {
            base.verificarAtalhoAcionado(e);

            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                if (e.Control && !e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Back:
                            if (this.btnEsquerda.Visible)
                            {
                                this.btnEsquerda_Click(this, e);
                            }
                            break;

                        case Keys.Enter:
                            if (this.btnDireita.Visible)
                            {
                                this.btnDireita_Click(this, e);
                            }
                            break;

                        case Keys.Left:
                            if (this.btnEsquerda.Visible)
                            {
                                this.btnEsquerda_Click(this, e);
                            }
                            break;

                        case Keys.Right:
                            if (this.btnDireita.Visible)
                            {
                                this.btnDireita_Click(this, e);
                            }
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

        private void atualizarClnValor(Int32 intCampoIndex)
        {
            #region VARIÁVEIS

            string strCampoValor = Utils.STR_VAZIA;
            Control objControl;

            #endregion

            #region AÇÕES

            try
            {
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
                        try
                        {
                            strCampoValor = objControlTemp.SelectedValue.ToString();
                        }
                        catch
                        {
                            strCampoValor = objControlTemp.Text;
                        }
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

        private void prepararCampo()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.clnSelecionada = this.lstCln[this.intCampoIndex];
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

        #region EVENTOS

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
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

        private void btnDireita_Click(object sender, System.EventArgs e)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.intCampoIndex = this.intCampoIndex + 1;
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

        private void btnEsquerda_Click(object sender, System.EventArgs e)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.intCampoIndex = this.intCampoIndex - 1;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.salvarRegistro();
            }
            catch (Exception ex)
            {
                new Erro("Erro ao salvar registro.", ex, Erro.ErroTipo.DATA_BASE);
            }
            finally
            {
            }

            #endregion
        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
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