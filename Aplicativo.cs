using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using DigoFramework.Arquivos;
using DigoFramework.Formulário;
using Microsoft.Win32;
using System.Web;

namespace DigoFramework
{
    public abstract class Aplicativo : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private static Aplicativo _appInstancia;
        public static Aplicativo appInstancia { get { return _appInstancia; } }

        private bool _booAplicativoWeb = false;
        public bool booAplicativoWeb { get { return _booAplicativoWeb; } set { _booAplicativoWeb = value; } }

        public Boolean booAtualizado { get { return this.getBooAtualizado(); } }

        private Boolean _booBeta = true;
        public Boolean booBeta { get { return _booBeta; } set { _booBeta = value; } }

        private Boolean _booDesenvolvimentoProducao = true;
        public Boolean booDesenvolvimentoProducao { get { return _booDesenvolvimentoProducao; } set { _booDesenvolvimentoProducao = value; } }

        private Boolean _booIniciarComWindows;
        public Boolean booIniciarComWindows
        {
            get { return _booIniciarComWindows; }
            set
            {
                _booIniciarComWindows = value;
                RegistryKey objRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (_booIniciarComWindows) { objRegistryKey.SetValue(this.strNome, this.dirExecutavelCompleto); }
                else { objRegistryKey.DeleteValue(this.strNome, false); }
            }
        }

        private String _dirExecutavel = Application.StartupPath;
        public String dirExecutavel
        {
            get
            {
                if (this.booAplicativoWeb)
                {
                    return HttpContext.Current.Server.MapPath("~/");
                }
                return _dirExecutavel;
            }
        }

        public String dirExecutavelCompleto { get { return Application.ExecutablePath; } }

        //private FrmCadastro _frmCadastro;
        //public FrmCadastro frmCadastro
        //{
        //    get
        //    {
        //        if (_frmCadastro == null)
        //        {
        //            _frmCadastro = new FrmCadastro();
        //        }
        //        return _frmCadastro;
        //    }
        //}

        //private FrmEdicao _frmEdicao;
        //public FrmEdicao frmEdicao
        //{
        //    get
        //    {
        //        if (_frmEdicao == null)
        //        {
        //            _frmEdicao = new FrmEdicao();
        //        }
        //        return _frmEdicao;
        //    }
        //}

        private FrmEspera _frmEspera;
        private FrmEspera frmEspera
        {
            get
            {
                if (_frmEspera == null)
                {
                    _frmEspera = new FrmEspera();
                }
                return _frmEspera;
            }
        }

        private Form _frmMain;
        public Form frmMain
        {
            get { return _frmMain; }
            set
            {
                _frmMain = value;
                _frmMain.Text = this.getStrTituloAplicativo();
            }
        }

        private Int16 _intVersao = 1;
        public Int16 intVersao { get { return _intVersao; } set { _intVersao = value; } }

        private Int16 _intVersaoSub = 0;
        public Int16 intVersaoSub { get { return _intVersaoSub; } set { _intVersaoSub = value; } }

        private Int32 _intVersaoBug = 0;
        public Int32 intVersaoBug
        {
            get { return _intVersaoBug; }
            set
            {
                _intVersaoBug = value;
                try { frmMain.Text = this.getStrTituloAplicativo(); }
                catch (Exception) { }
            }
        }

        private Int32 _intVersaoBuid = 0;
        public Int32 intVersaoBuid
        {
            get { return _intVersaoBuid; }
            set
            {
                _intVersaoBuid = value;
                try { frmMain.Text = this.getStrTituloAplicativo(); }
                catch (Exception) { }
            }
        }

        private List<Arquivo> _lstObjArquivoDependencia = new List<Arquivo>();
        public List<Arquivo> lstObjArquivoDependencia
        {
            get
            {
                for (int intTemp = 0; intTemp < _lstObjArquivoDependencia.Count; intTemp++)
                {
                    if (_lstObjArquivoDependencia[intTemp].intId == this.objArquivoExePrincipal.intId)
                    {
                        _lstObjArquivoDependencia.RemoveAt(intTemp);
                    }
                }
                _lstObjArquivoDependencia.Insert(0, this.objArquivoExePrincipal);

                return _lstObjArquivoDependencia;
            }
            set { _lstObjArquivoDependencia = value; }
        }

        private List<MensagemUsuario> _lstObjMensagemUsuario = new List<MensagemUsuario>();
        public List<MensagemUsuario> lstObjMensagemUsuario { get { return _lstObjMensagemUsuario; } set { _lstObjMensagemUsuario = value; } }

        private ArquivoExe _objArquivoExePrincipal = new ArquivoExe();
        public ArquivoExe objArquivoExePrincipal
        {
            get
            {
                _objArquivoExePrincipal.booPrincipal = true;
                _objArquivoExePrincipal.strNome = this.strNome;
                _objArquivoExePrincipal.strDescricao = this.strDescricao;
                _objArquivoExePrincipal.dirDiretorio = this.dirExecutavel;
                return _objArquivoExePrincipal;
            }
        }

        private ArquivoXml _objArquivoXmlConfig = new ArquivoXml();
        public ArquivoXml objArquivoXmlConfig { get { return _objArquivoXmlConfig; } set { _objArquivoXmlConfig = value; } }

        //private DbTabela _objTabelaSelecionada;
        //public DbTabela objTabelaSelecionada { get { return _objTabelaSelecionada; } set { _objTabelaSelecionada = value; } }

        #endregion

        #region CONSTRUTORES

        //public Aplicativo()
        //{
        //    #region VARIÁVEIS

        //    //this.booDesenvolvimentoProducao = booDesenvolvimentoProducao;

        //    #endregion

        //    #region AÇÕES

        //    try
        //    {
        //        this.setInObjArquivoXmlConfig();
        //    }
        //    catch (Exception ex)
        //    {
        //        new Erro("Erro ao criar Arquivo XML de configuração do Aplicativo.", ex, Erro.ErroTipo.Notificao);
        //    }

        //    #endregion
        //}

        public Aplicativo(bool booAplicativoWeb)
        {
            #region VARIÁVEIS

            Aplicativo._appInstancia = this;
            this.booAplicativoWeb = booAplicativoWeb;

            #endregion

            #region AÇÕES

            try
            {
                this.setInObjArquivoXmlConfig();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar Arquivo XML de configuração do Aplicativo.\n" + ex.Message);
            }

            #endregion
        }



        #endregion

        #region DESTRUTOR

        ~Aplicativo()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            try { this.setOutObjArquivoXmlConfig(); }
            catch (Exception ex) { new Erro("Erro ao criar Arquivo XML de configuração do Aplicativo.", ex, Erro.ErroTipo.Notificao); }

            #endregion
        }

        #endregion

        #region MÉTODOS

        private bool getBooAtualizado()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            foreach (Arquivo objArquivoDependencia in this.lstObjArquivoDependencia)
            {
                if (!objArquivoDependencia.booAtualizado)
                {
                    return false;
                }
            }
            return true;

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>

        public String getStrMensagemUsuario(Int32 intId, DigoFramework.MensagemUsuario.Lingua objLingua = MensagemUsuario.Lingua.Portugues)
        {
            #region VARIÁVEIS

            String strMensagem = "";

            #endregion

            #region AÇÕES

            foreach (MensagemUsuario objMensagem in this.lstObjMensagemUsuario)
            {
                if (objMensagem.intId == intId & objMensagem.objLingua == objLingua)
                {
                    strMensagem = objMensagem.strMensagem;
                }
            }
            return strMensagem;

            #endregion
        }

        public String getStrTituloAplicativo()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            return String.Format("{0} - {1} ({2})", this.strNome, this.strDescricao, this.getStrVersaoCompleta());

            #endregion
        }

        public String getStrVersaoCompleta()
        {
            // EXTERNOS
            // VARIÁVEIS
            String strVersaoCompleta = Utils.STRING_VAZIA;

            // AÇÕES
            strVersaoCompleta += Convert.ToString(this.intVersao);
            strVersaoCompleta += '.';
            strVersaoCompleta += Convert.ToString(this.intVersaoSub);
            strVersaoCompleta += '.';
            strVersaoCompleta += Convert.ToString(this.intVersaoBug);
            strVersaoCompleta += '.';
            strVersaoCompleta += Convert.ToString(this.intVersaoBuid);
            strVersaoCompleta += (this.booBeta ? " Beta" : "");

            return strVersaoCompleta;
        }

        public FrmEspera mostraFormularioEspera(String strTarefaDescricao = "Rotina do Sistema {sis_nome} sendo realizada...", String strTarefaTitulo = "Por favor, aguarde...")
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            if (strTarefaDescricao == "Rotina do Sistema {sis_nome} sendo realizada...")
            {
                strTarefaDescricao = "Rotina do Sistema " + this.strNome + " sendo realizada...";
            }
            this.frmEspera.strTarefaTitulo = strTarefaTitulo;
            this.frmEspera.strTarefaDescricao = strTarefaDescricao;
            new Thread(() => this.frmEspera.ShowDialog()).Start();
            return this.frmEspera;

            #endregion
        }

        private void setInObjArquivoXmlConfig()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objArquivoXmlConfig.dirDiretorioCompleto = this.dirExecutavel + "\\AppConfig.xml";
            this.intVersaoBuid = Convert.ToInt32(this.objArquivoXmlConfig.getStrElementoConteudo("VersaoBuid"));

            #endregion
        }

        private void setOutObjArquivoXmlConfig()
        {
            #region VARIÁVEIS

            Int32 intBuidNova = 0;
            Int32 intQtdAcesso = 0;

            #endregion

            #region AÇÕES

            this.objArquivoXmlConfig.setStrElementoConteudo("dttUltimoAcesso", DateTime.Now.ToString());
            intQtdAcesso = Convert.ToInt32(this.objArquivoXmlConfig.getStrElementoConteudo("intQtdAcesso"));
            intQtdAcesso++;
            this.objArquivoXmlConfig.setStrElementoConteudo("intQtdAcesso", intQtdAcesso.ToString());
            if (this.booDesenvolvimentoProducao)
            {
                intBuidNova = Convert.ToInt32(this.objArquivoXmlConfig.getStrElementoConteudo("VersaoBuid"));
                intBuidNova++;
                this.objArquivoXmlConfig.setStrElementoConteudo("VersaoBuid", intBuidNova.ToString());
            }

            #endregion
        }

        #endregion

        #region EVENTOS

        //delegate void nomeAlteradoHandler(object source, EventArgs e);
        //public event nomeAlteradoHandler nomeAlterado;
        //public virtual void onNomeAlteradoHandler(EventArgs e)
        //{
        //    if (nomeAlterado != null)
        //        nomeAlterado(this, e);
        //}

        #endregion
    }
}
