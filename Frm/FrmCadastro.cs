using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DigoFramework.DataBase;

namespace DigoFramework.Frm
{
    public partial class FrmCadastro : FrmMain, IFrmCadastro
    {
        #region Constantes

        public enum EnmDialogResult
        {
            REGISTRO_ALTERADO,
            REGISTRO_INALTERADO
        }

        #endregion Constantes

        #region Atributos

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
            }
        }

        public List<DbColuna> lstCln
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _lstCln;
            }
        }

        public List<Control> lstObjControl
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _tbl = value;

                    this.atualizarTbl();
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
                #region Variáveis

                Control objComponentInsercaoDados;
                CheckBox objCheckBox;
                ComboBox objComboBox;
                DateTimePicker objDateTimePicker;
                MaskedTextBox objMaskedTextBox;
                RichTextBox objRichTextBox;

                #endregion Variáveis

                #region Ações

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

                        objMaskedTextBox.Mask = clnSelecionada.booSenha ? "*" : null;
                        this.pnlCampoDados.Controls.Clear();

                        if (this.clnSelecionada.viwRef != null)
                        {
                            objComboBox.DataSource = this.clnSelecionada.viwRef.objDataTable;
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

                #endregion Ações
            }
        }

        #endregion Atributos

        #region Construtores

        public FrmCadastro(int intRegistroId = 0)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        public virtual void carregarDados()
        {
        }

        public virtual void carregarRegistro()
        {
        }

        public virtual void salvarRegistro()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        public virtual void setFocoInicial()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        protected override void verificarAtalhoAcionado(KeyEventArgs e)
        {
            base.verificarAtalhoAcionado(e);

            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void atualizarClnValor(int intCampoIndex)
        {
            #region Variáveis

            string strCampoValor = string.Empty;
            Control objControl;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void atualizarTbl()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tbl == null)
                {
                    return;
                }

                if (this.tbl.clsFrmCadastro != null)
                {
                    return;
                }

                this.tbl.clsFrmCadastro = this.GetType();
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

        private void prepararCampo()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void btnDireita_Click(object sender, System.EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void btnEsquerda_Click(object sender, System.EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.DesignMode)
                {
                    return;
                }

                this.carregarDados();

                if (this.tbl.intIdRegSelec > 0)
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

            #endregion Ações
        }

        #endregion Eventos
    }
}