﻿using DigoFramework.Arquivo;
using DigoFramework.Frm;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace DigoFramework
{
    public abstract class AppBase : Objeto
    {
#if DEBUG
        private bool _booDesenvolvimento = true;
#else
        private bool _booDesenvolvimento = false;
#endif

        #region Constantes

        private const string STR_ARG_AUTO_LIGAMENTO = "--auto-ligamento";

        #endregion Constantes

        #region Atributos

        private static AppBase _i;

        private ArquivoExe _arqPrincipal;
        private ArquivoXml _arqXmlUpdate;
        private string[] _arrStrArgumento;
        private bool? _booAtualizado;
        private bool _booAtualizarTitulo = true;
        private bool? _booAutoLigamento;
        private bool _booBeta = true;
        private bool? _booConsole;
        private bool? _booIniciarComWindows;
        private ConfigBase _cfg;
        private string _dirExecutavel;
        private string _dirExecutavelCompleto;
        private string _dirTemp;
        private FrmEspera _frmEspera;
        private Form _frmPrincipal;
        private Ftp _ftpUpdate;
        private List<ArquivoBase> _lstArqDependencia;
        private List<FrmBase> _lstFrmCache;
        private List<MensagemUsuario> _lstMsgUsuario;
        private TemaBase _objTema;
        private string _strInput;
        private string _strVersao;
        private string _strVersaoCompleta;
        private string _urlSiteOficial;

        public static AppBase i
        {
            get
            {
                return _i;
            }

            private set
            {
                if (_i != null)
                {
                    return;
                }

                _i = value;
            }
        }

        public ArquivoExe arqPrincipal
        {
            get
            {
                if (_arqPrincipal != null)
                {
                    return _arqPrincipal;
                }

                _arqPrincipal = this.getArqPrincipal();

                return _arqPrincipal;
            }
        }

        public string[] arrStrArgumento
        {
            get
            {
                return _arrStrArgumento;
            }

            set
            {
                _arrStrArgumento = value;
            }
        }

        public bool booAtualizado
        {
            get
            {
                if (_booAtualizado != null)
                {
                    return (bool)_booAtualizado;
                }

                _booAtualizado = this.getBooAtualizado();

                return (bool)_booAtualizado;
            }
        }

        /// <summary>
        /// Indica se a aplicação foi ligada automaticamente quando o Windows iniciou.
        /// </summary>
        public bool booAutoLigamento
        {
            get
            {
                if (_booAutoLigamento != null)
                {
                    return (bool)_booAutoLigamento;
                }

                _booAutoLigamento = this.getBooAutoLigamento();

                return (bool)_booAutoLigamento;
            }
        }

        public bool booBeta
        {
            get
            {
                return _booBeta;
            }

            set
            {
                _booBeta = value;
            }
        }

        /// <summary>
        /// Indica se a aplicação é uma aplicação de console.
        /// </summary>
        public bool booConsole
        {
            get
            {
                if (_booConsole != null)
                {
                    return (bool)_booConsole;
                }

                _booConsole = this.getBooConsole();

                return (bool)_booConsole;
            }
        }

        public bool booDesenvolvimento
        {
            get
            {
                return _booDesenvolvimento;
            }

            private set
            {
                _booDesenvolvimento = value;
            }
        }

        public bool booIniciarComWindows
        {
            get
            {
                if (_booIniciarComWindows != null)
                {
                    return (bool)_booIniciarComWindows;
                }

                _booIniciarComWindows = this.getBooIniciarComWindows();

                return (bool)_booIniciarComWindows;
            }

            set
            {
                if (_booIniciarComWindows == value)
                {
                    return;
                }

                _booIniciarComWindows = value;

                this.setBooIniciarComWindows((bool)_booIniciarComWindows);
            }
        }

        public ConfigBase cfg
        {
            get
            {
                if (_cfg != null)
                {
                    return _cfg;
                }

                _cfg = this.getCfg();

                return _cfg;
            }
        }

        public string dirExecutavel
        {
            get
            {
                if (!string.IsNullOrEmpty(_dirExecutavel))
                {
                    return _dirExecutavel;
                }

                _dirExecutavel = this.getDirExecutavel();

                return _dirExecutavel;
            }
        }

        public string dirExecutavelCompleto
        {
            get
            {
                if (!string.IsNullOrEmpty(_dirExecutavelCompleto))
                {
                    return _dirExecutavelCompleto;
                }

                _dirExecutavelCompleto = Application.ExecutablePath.Replace("EXE", "exe");

                return _dirExecutavelCompleto;
            }
        }

        public string dirTemp
        {
            get
            {
                if (!string.IsNullOrEmpty(_dirTemp))
                {
                    return _dirTemp;
                }

                _dirTemp = Path.Combine(Path.GetTempPath(), this.strNomeSimplificado);

                return _dirTemp;
            }
        }

        public FrmEspera frmEspera
        {
            get
            {
                if (_frmEspera != null)
                {
                    return _frmEspera;
                }

                _frmEspera = new FrmEspera();

                return _frmEspera;
            }
        }

        public Form frmPrincipal
        {
            get
            {
                if (_frmPrincipal != null)
                {
                    return _frmPrincipal;
                }

                _frmPrincipal = this.getFrmPrincipal();

                return _frmPrincipal;
            }

            set
            {
                if (_frmPrincipal == value)
                {
                    return;
                }

                _frmPrincipal = value;

                this.setFrmPrincipal(frmPrincipal);
            }
        }

        public Ftp ftpUpdate
        {
            get
            {
                if (_ftpUpdate != null)
                {
                    return _ftpUpdate;
                }

                _ftpUpdate = this.getFtpUpdate();

                return _ftpUpdate;
            }

            set
            {
                _ftpUpdate = value;
            }
        }

        public List<FrmBase> lstFrmCache
        {
            get
            {
                if (_lstFrmCache != null)
                {
                    return _lstFrmCache;
                }

                _lstFrmCache = new List<FrmBase>();

                return _lstFrmCache;
            }
        }

        public TemaBase objTema
        {
            get
            {
                if (_objTema != null)
                {
                    return _objTema;
                }

                _objTema = this.getObjTema();

                return _objTema;
            }
        }

        public string strInput
        {
            get
            {
                return _strInput;
            }

            set
            {
                _strInput = value;
            }
        }

        public string strVersao
        {
            get
            {
                if (_strVersao != null)
                {
                    return _strVersao;
                }

                _strVersao = this.getStrVersao();

                return _strVersao;
            }
        }

        public string urlSiteOficial
        {
            get
            {
                return _urlSiteOficial;
            }

            set
            {
                _urlSiteOficial = value;
            }
        }

        protected ArquivoXml arqXmlUpdate
        {
            get
            {
                if (_arqXmlUpdate != null)
                {
                    return _arqXmlUpdate;
                }

                _arqXmlUpdate = this.getArqXmlUpdate();

                return _arqXmlUpdate;
            }
        }

        protected bool booAtualizarTitulo
        {
            get
            {
                return _booAtualizarTitulo;
            }

            set
            {
                _booAtualizarTitulo = value;
            }
        }

        private List<ArquivoBase> lstArqDependencia
        {
            get
            {
                if (_lstArqDependencia != null)
                {
                    return _lstArqDependencia;
                }

                _lstArqDependencia = this.getLstArqDependencia();

                return _lstArqDependencia;
            }
        }

        private List<MensagemUsuario> lstMsgUsuario
        {
            get
            {
                if (_lstMsgUsuario != null)
                {
                    return _lstMsgUsuario;
                }

                _lstMsgUsuario = this.getLstMsgUsuario();

                return _lstMsgUsuario;
            }
        }

        private string strVersaoCompleta
        {
            get
            {
                if (_strVersaoCompleta != null)
                {
                    return _strVersaoCompleta;
                }

                _strVersaoCompleta = this.getStrVersao();

                return _strVersaoCompleta;
            }
        }

        #endregion Atributos

        #region Construtores

        protected AppBase(string strNome)
        {
            i = this;

            this.strNome = strNome;
        }

        #endregion Construtores

        #region Destrutor

        ~AppBase()
        {
            this.apagarPastaTemp();
        }

        #endregion Destrutor

        #region Métodos

        /// <summary>
        /// Cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrm(Type cls)
        {
            if (cls == null)
            {
                return DialogResult.Cancel;
            }

            if (!typeof(FrmBase).IsAssignableFrom(cls))
            {
                return DialogResult.Cancel;
            }

            FrmBase frm = (FrmBase)Activator.CreateInstance(cls);

            return frm.ShowDialog();
        }

        /// <summary>
        /// Verifica se existe uma instância do "FrmBase" no cache de formulários e o coloca na tela.
        /// Caso não exista, cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrmCache(Type cls)
        {
            if (cls == null)
            {
                return DialogResult.Cancel;
            }

            if (!typeof(FrmBase).IsAssignableFrom(cls))
            {
                return DialogResult.Cancel;
            }

            FrmBase frm = this.getFrmCache(cls);

            return frm.ShowDialog();
        }

        public virtual void atualizar()
        {
            try
            {
                this.mostrarFormularioEspera("Verificando se existe uma nova versão no servidor.");

                XmlNodeList xmlNodeList = this.arqXmlUpdate.getXmlNodeList();

                this.frmEspera.intProgressoMaximo = xmlNodeList.Count;

                bool booResultado = false;

                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    if (!this.atualizar(xmlNode))
                    {
                        continue;
                    }

                    booResultado = true;
                }

                if (!booResultado)
                {
                    return;
                }

                this.gerarXmlAtualizacao();

                this.frmEspera.booConcluido = true;

                this.abrirAppUpdate();

                this.frmPrincipal.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(string.Format("Para concluir a atualização o sistema \"{0}\" será reiniciado.", this.strNome));

                    Application.Exit();
                });
            }
            finally
            {
                this.frmEspera.booConcluido = true;
            }
        }

        /// <summary>
        /// Termina processos que contém em seu nome o parâmetro "strProcessoNome".
        /// </summary>
        public void finalizarProcesso(string strProcessoNome)
        {
            foreach (Process objProcess in Process.GetProcessesByName(strProcessoNome))
            {
                objProcess.Kill();
            }
        }

        /// <summary>
        /// Cria um repositório para atualização automática.
        /// </summary>
        /// <param name="dirRepositorioUpdate">
        /// Diretório onde o repositório será salvo. Caso este valor seja passado vazio, criará o
        /// repositório no mesmo diretório do executável.
        /// </param>
        public void gerarRepositorioUpdate()
        {
            try
            {
                this.mostrarFormularioEspera("Repositório local", "Criando repositório local");

                this.frmEspera.intProgressoMaximo = (this.lstArqDependencia.Count + 1);

                this.gerarXmlAtualizacao();

                this.frmEspera.decProgresso++;

                foreach (ArquivoBase arq in this.lstArqDependencia)
                {
                    this.frmEspera.strTarefaDescricao = ("Criando arquivo: " + arq.strNome);

                    arq.compactar(this.dirExecutavel);

                    this.frmEspera.decProgresso++;
                }

                this.frmEspera.booConcluido = true;
            }
            finally
            {
                this.frmEspera.booConcluido = true;
            }
        }

        public bool getBooRodando()
        {
            var strAppNome = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

            foreach (Process prc in Process.GetProcesses())
            {
                if (Process.GetCurrentProcess().Id.Equals(prc.Id))
                {
                    continue;
                }

                if (prc.ProcessName.Contains(strAppNome))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retornar uma "string" contendo a mensagem destinada ao usuário.
        /// </summary>
        public string getStrMensagemUsuario(int intId, MensagemUsuario.EnmLingua objLingua = MensagemUsuario.EnmLingua.PORTUGUES)
        {
            foreach (MensagemUsuario msg in this.lstMsgUsuario)
            {
                if (!intId.Equals(msg.intId) || !objLingua.Equals(msg.enmLingua))
                {
                    continue;
                }

                return msg.strMsg;
            }

            return null;
        }

        public string getStrTituloAplicativo()
        {
            string strResultado = "_app_nome (_app_versao) - _app_descricao";

            strResultado = strResultado.Replace("_app_nome", this.strNome);
            strResultado = strResultado.Replace("_app_versao", this.strVersaoCompleta);
            strResultado = strResultado.Replace("_app_descricao", this.strDescricao);

            if (string.IsNullOrEmpty(this.strDescricao))
            {
                strResultado = strResultado.Replace(" - ", string.Empty);
            }

            return strResultado;
        }

        public void iniciar()
        {
            this.inicializar();
            this.setEventos();
            this.finalizar();
        }

        /// <summary>
        /// Mostra um formulário para inserção de texto simples.
        /// </summary>
        public string input(string strTitulo = "Insira o texto", string strDescricao = "Utilize o campo abaixo para inserção do texto.", string strValorDefault = "")
        {
            FrmInput.i.strTitulo = strTitulo;
            FrmInput.i.strDescricao = strDescricao;
            FrmInput.i.strValorDefault = strValorDefault;
            FrmInput.i.ShowDialog();

            return this.strInput;
        }

        public FrmEspera mostrarFormularioEspera(string strTarefaDescricao = "Rotina do sistema {sis_nome} sendo realizada.", string strTarefaTitulo = "Por favor aguarde...")
        {
            this.frmEspera.booConcluido = false;
            this.frmEspera.decProgresso = 0;
            this.frmEspera.decProgressoTarefa = 0;
            this.frmEspera.intProgressoMaximo = 0;
            this.frmEspera.intProgressoMaximoTarefa = 0;
            this.frmEspera.strTarefaDescricao = strTarefaDescricao.Replace("{sis_nome}", this.strNome);
            this.frmEspera.strTarefaTitulo = strTarefaTitulo;

            new Thread(() => this.frmEspera.ShowDialog()).Start();

            return this.frmEspera;
        }

        /// <summary>
        /// Reinicia a máquina e roda a aplicação quando ela voltar.
        /// </summary>
        public void reiniciarReligar()
        {
            using (RegistryKey objRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true))
            {
                objRegistryKey.SetValue(this.strNome, string.Format("\"{0}\" {1}", this.dirExecutavelCompleto, STR_ARG_AUTO_LIGAMENTO));
            }

            Process.Start("shutdown.exe", "-r -t 5");
        }

        protected virtual void finalizar()
        {
        }

        protected virtual bool getBooInstanciaUnica()
        {
            return false;
        }

        protected virtual ConfigBase getCfg()
        {
            return null;
        }

        protected virtual Type getClsFrmPrincipal()
        {
            return null;
        }

        protected virtual Ftp getFtpUpdate()
        {
            if (this.cfg == null)
            {
                return null;
            }

            return new Ftp(this.cfg.strFtpUpdateServer, this.cfg.strFtpUpdateUser, this.cfg.strFtpUpdateSenha);
        }

        protected abstract TemaBase getObjTema();

        /// <summary>
        /// Método que é chamado no construtor desta classe e pode ser usado para inicializar valores
        /// para essa instância.
        /// </summary>
        protected virtual void inicializar()
        {
            this.inicializarInstanciaUnica();

            this.inicializarCfg();
        }

        /// <summary>
        /// Este método deve ser sobescrito para inicializar a lista de arquivos que fazem parte do
        /// projeto para que fiquem disponíveis no processo de atualização automática.
        /// </summary>
        /// <param name="lstArqDependencia">Instância de <see cref="lstArqDependencia"/>.</param>
        protected virtual void inicializarLstArqDependencia(List<ArquivoBase> lstArqDependencia)
        {
            lstArqDependencia.Add(this.arqPrincipal);
        }

        protected virtual void inicializarLstMsgUsuario(List<MensagemUsuario> lstMsgUsuario)
        {
            lstMsgUsuario.Add(new MensagemUsuario("ArquivoMain não existe.", 100));
        }

        /// <summary>
        /// Método chamado dentro do construtor desta classe e deve ser utilizado para inicializar os
        /// eventos necessários ao funcionamento da aplicação.
        /// </summary>
        protected virtual void setEventos()
        {
        }

        private void abrirAppUpdate()
        {
            using (var objProcess = new Process())
            {
                objProcess.StartInfo.FileName = "AppUpdate.exe";
                objProcess.StartInfo.Arguments = string.Format("\"{0}\"", this.arqPrincipal.dirCompleto);
                objProcess.StartInfo.CreateNoWindow = true;

                objProcess.Start();
            }
        }

        private void apagarPastaTemp()
        {
            if (!Directory.Exists(this.dirTemp))
            {
                return;
            }

            foreach (string dirCompleto in Directory.GetFiles(this.dirTemp))
            {
                File.Delete(dirCompleto);
            }

            Directory.Delete(this.dirTemp);
        }

        private bool atualizar(XmlNode xmlNode)
        {
            try
            {
                this.frmEspera.strTarefaDescricao = "Analisando o arquivo \"" + xmlNode.Name + "\".";

                ArquivoBase arq = null;

                foreach (ArquivoBase arqDependencia in this.lstArqDependencia)
                {
                    if (xmlNode.Name.Equals(arqDependencia.strNomeSimplificado))
                    {
                        arq = arqDependencia;
                        break;
                    }
                }

                if (arq == null)
                {
                    arq = new ArquivoDiverso();

                    arq.strNome = xmlNode.ChildNodes.Item(0).InnerText;

                    arq.dir = this.dirExecutavel;
                }

                if (xmlNode.ChildNodes.Item(1).InnerText.Equals(arq.strMd5))
                {
                    return false;
                }

                this.frmEspera.strTarefaDescricao = "Arquivo \"" + xmlNode.ChildNodes.Item(0).InnerText + "\" desatualizado. Fazendo download.";

                arq.atualizarFtp();

                this.frmEspera.strTarefaDescricao = "Arquivo \"" + xmlNode.ChildNodes.Item(0).InnerText + "\" desatualizado. Descompactando.";

                arq.descompactarUpdate();

                return true;
            }
            finally
            {
                this.frmEspera.decProgresso++;
            }
        }

        private void gerarXmlAtualizacao()
        {
            ArquivoXml arqXmlAtualizacao = new ArquivoXml();

            arqXmlAtualizacao.strNome = (this.strNomeSimplificado + "_update.xml");

            arqXmlAtualizacao.dir = this.dirExecutavel;

            foreach (ArquivoBase objArquivoReferencia in this.lstArqDependencia)
            {
                arqXmlAtualizacao.setStrElemento(objArquivoReferencia.strNomeSimplificado, string.Empty);

                arqXmlAtualizacao.addNode("nome", objArquivoReferencia.strNome, objArquivoReferencia.strNomeSimplificado);
                arqXmlAtualizacao.addNode("md5", objArquivoReferencia.strMd5, objArquivoReferencia.strNomeSimplificado);
            }

            arqXmlAtualizacao.salvar();
        }

        private ArquivoExe getArqPrincipal()
        {
            ArquivoExe arqResultado = new ArquivoExe();

            arqResultado.booPrincipal = true;
            arqResultado.dirCompleto = this.dirExecutavelCompleto;
            arqResultado.strDescricao = this.strDescricao;

            return arqResultado;
        }

        private ArquivoXml getArqXmlUpdate()
        {
            ArquivoXml arqXmlUpdateResultado = new ArquivoXml();

            arqXmlUpdateResultado.strNome = (this.strNomeSimplificado + "_update.xml");

            arqXmlUpdateResultado.dirCompleto = arqXmlUpdateResultado.dirTempCompleto;

            this.ftpUpdate.downloadArquivo(arqXmlUpdateResultado.strNome, arqXmlUpdateResultado.dirTempCompleto);

            return arqXmlUpdateResultado;
        }

        private bool getBooAtualizado()
        {
            this.gerarXmlAtualizacao();

            foreach (XmlNode xmlNode in this.arqXmlUpdate.getXmlNodeList())
            {
                if (!this.getBooAtualizado(xmlNode))
                {
                    return false;
                }
            }

            return true;
        }

        private bool getBooAtualizado(XmlNode xmlNodeArq)
        {
            foreach (ArquivoBase arq in this.lstArqDependencia)
            {
                if (arq == null)
                {
                    continue;
                }

                if (!arq.getBooAtualizado(xmlNodeArq, arq))
                {
                    return false;
                }
            }

            return true;
        }

        private bool getBooAutoLigamento()
        {
            var arrStrArgumento = Environment.GetCommandLineArgs();

            if (arrStrArgumento == null)
            {
                return false;
            }

            if (arrStrArgumento.Length < 1)
            {
                return false;
            }

            foreach (var strArgumento in arrStrArgumento)
            {
                if (STR_ARG_AUTO_LIGAMENTO.Equals(strArgumento))
                {
                    return true;
                }
            }

            return false;
        }

        private bool getBooConsole()
        {
            try
            {
                Console.WindowHeight = Console.WindowHeight;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool getBooIniciarComWindows()
        {
            using (RegistryKey objRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"))
            {
                return (objRegistryKey.GetValue(this.strNome) != null);
            }
        }

        private string getDirExecutavel()
        {
            return Application.StartupPath;
        }

        /// <summary>
        /// Retorna a instância de um formulário do cache de formulários. Caso este formulário não
        /// exista no cache cria uma nova e o retorna.
        /// </summary>
        private FrmBase getFrmCache(Type cls)
        {
            if (cls == null)
            {
                return null;
            }

            FrmBase frmResultado = null;

            foreach (FrmBase frm in this.lstFrmCache)
            {
                if (!frm.GetType().Equals(cls))
                {
                    continue;
                }

                frmResultado = frm;
                break;
            }

            if (frmResultado == null)
            {
                frmResultado = (FrmBase)Activator.CreateInstance(cls);

                this.lstFrmCache.Add(frmResultado);
            }

            return frmResultado;
        }

        private Form getFrmPrincipal()
        {
            if (this.getClsFrmPrincipal() == null)
            {
                return null;
            }

            var frmPrincipalResultado = (Form)Activator.CreateInstance(this.getClsFrmPrincipal());

            if (this.booAtualizarTitulo)
            {
                frmPrincipalResultado.Text = this.getStrTituloAplicativo();
            }

            return frmPrincipalResultado;
        }

        private List<ArquivoBase> getLstArqDependencia()
        {
            List<ArquivoBase> lstArqDependenciaResultado = new List<ArquivoBase>();

            this.inicializarLstArqDependencia(lstArqDependenciaResultado);

            return lstArqDependenciaResultado;
        }

        private List<MensagemUsuario> getLstMsgUsuario()
        {
            List<MensagemUsuario> lstMsgUsuarioResultado = new List<MensagemUsuario>();

            this.inicializarLstMsgUsuario(lstMsgUsuarioResultado);

            return lstMsgUsuarioResultado;
        }

        private string getStrVersao()
        {
            if (this.arqPrincipal == null)
            {
                return "0.0.0";
            }

            return string.Format("{0} {1}", this.arqPrincipal.strVersao, (this.booBeta ? "beta" : null));
        }

        private void inicializarCfg()
        {
            if (this.cfg == null)
            {
                return;
            }

            this.cfg.iniciar();
        }

        private void inicializarInstanciaUnica()
        {
            if (!this.getBooInstanciaUnica())
            {
                return;
            }

            if (!this.getBooRodando())
            {
                return;
            }

            new Erro("Aplicação já está sendo executada."); // TODO: Dar foco para instância da aplicação que já está aberta.

            Environment.Exit(0);
        }

        private void setBooIniciarComWindows(bool booIniciarComWindows)
        {
            using (RegistryKey objRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (booIniciarComWindows)
                {
                    objRegistryKey.SetValue(this.strNome, string.Format("\"{0}\" {1}", this.dirExecutavelCompleto, STR_ARG_AUTO_LIGAMENTO));
                }
                else
                {
                    objRegistryKey.DeleteValue(this.strNome, false);
                }
            }
        }

        private void setFrmPrincipal(Form frmPrincipal)
        {
            if (!this.booAtualizarTitulo)
            {
                return;
            }

            if (frmPrincipal == null)
            {
                return;
            }

            frmPrincipal.Text = this.getStrTituloAplicativo();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}