using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using DigoFramework.Arquivo;
using DigoFramework.Frm;
using DigoFramework.ObjMain;
using Microsoft.Win32;

namespace DigoFramework
{
    public abstract class Aplicativo : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static Aplicativo _i;

        private ArquivoExe _arqExePrincipal;
        private ArquivoXml _arqXmlUpdate;
        private string[] _arrStrArgIn;
        private bool _booAplicativoWeb;
        private bool _booAtualizado;
        private bool _booAtualizarTituloFrmMain = true;
        private bool _booBeta = true;
        private bool? _booConsole;
        private bool _booDesenvolvimento = true;
        private bool _booIniciarComWindows;
        private string _dirExecutavel;
        private string _dirTemp;
        private FrmEspera _frmEspera;
        private Form _frmPrincipal;
        private Ftp _ftpUpdate;
        private List<ArquivoMain> _lstArqDependencia;
        private List<FrmBase> _lstFrmCache;
        private List<MensagemUsuario> _lstMsgUsuario;
        private List<MensagemUsuario> _lstMsgUsuarioPadrao;
        private List<DataBase.Tabela> _lstTbl;
        private Cliente _objCliente;
        private DataBase.DataBase _objDbPrincipal;
        private Fornecedor _objFornecedor;
        private string _strInput;
        private string _urlSiteOficial;

        public static Aplicativo i
        {
            get
            {
                return _i;
            }

            private set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return;
                    }

                    _i = value;
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

        public ArquivoExe arqExePrincipal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_arqExePrincipal != null)
                    {
                        return _arqExePrincipal;
                    }

                    _arqExePrincipal = new ArquivoExe();

                    _arqExePrincipal.booPrincipal = true;
                    _arqExePrincipal.strDescricao = this.strDescricao;
                    _arqExePrincipal.dirCompleto = this.dirExecutavelCompleto;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _arqExePrincipal;
            }
        }

        public string[] arrStrArgIn
        {
            get
            {
                return _arrStrArgIn;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _arrStrArgIn = value;

                    foreach (var strArgumentoEntrada in _arrStrArgIn)
                    {
                        if (!"Atualizado".Equals(strArgumentoEntrada))
                        {
                            continue;
                        }

                        MessageBox.Show("Sistema " + this.strNome + " atualizado com sucesso para versão " + this.getStrVersaoCompleta() + ".");
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
        }

        public bool booAplicativoWeb
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booAplicativoWeb = HttpContext.Current != null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _booAplicativoWeb;
            }
        }

        public bool booAtualizado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booAtualizado = this.calcularBooAtualizado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _booAtualizado;
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

                try
                {
                    Console.WindowHeight = Console.WindowHeight;

                    _booConsole = true;
                }
                catch
                {
                    _booConsole = false;
                }

                return (bool)_booConsole;
            }
        }

        public bool booDesenvolvimento
        {
            get
            {
                return _booDesenvolvimento;
            }

            set
            {
                _booDesenvolvimento = value;
            }
        }

        public bool booIniciarComWindows
        {
            get
            {
                return _booIniciarComWindows;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booIniciarComWindows = value;

                    RegistryKey objRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                    if (_booIniciarComWindows)
                    {
                        objRegistryKey.SetValue(this.strNome, this.dirExecutavelCompleto);
                        return;
                    }

                    objRegistryKey.DeleteValue(this.strNome, false);
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

        public string dirExecutavel
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (!string.IsNullOrEmpty(_dirExecutavel))
                    {
                        return _dirExecutavel;
                    }

                    _dirExecutavel = this.getDirExecutavel();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _dirExecutavel;
            }
        }

        public string dirExecutavelCompleto
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    return Application.ExecutablePath.Replace("EXE", "exe");
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

        public string dirTemp
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (string.IsNullOrEmpty(Aplicativo.i.strNomeSimplificado))
                    {
                        throw new NotImplementedException("O nome do aplicativo deve ser implementado.");
                    }

                    if (!string.IsNullOrEmpty(_dirTemp))
                    {
                        return _dirTemp;
                    }

                    _dirTemp = Path.GetTempPath() + Aplicativo.i.strNomeSimplificado;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _dirTemp;
            }
        }

        public FrmEspera frmEspera
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_frmEspera != null)
                    {
                        return _frmEspera;
                    }

                    _frmEspera = new FrmEspera();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _frmEspera;
            }
        }

        public Form frmPrincipal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_frmPrincipal != null)
                    {
                        return _frmPrincipal;
                    }

                    if (this.getClsFrmPrincipal() == null)
                    {
                        return new Form();
                    }

                    _frmPrincipal = (FrmBase)Activator.CreateInstance(this.getClsFrmPrincipal());

                    if (!this.booAtualizarTituloFrmPrincipal)
                    {
                        return _frmPrincipal;
                    }

                    _frmPrincipal.Text = this.getStrTituloAplicativo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _frmPrincipal;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _frmPrincipal = value;

                    if (!this.booAtualizarTituloFrmPrincipal)
                    {
                        return;
                    }

                    _frmPrincipal.Text = this.getStrTituloAplicativo();
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

        public Ftp ftpUpdate
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_ftpUpdate != null)
                    {
                        return _ftpUpdate;
                    }

                    _ftpUpdate = this.getFtpUpdate();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstFrmCache != null)
                    {
                        return _lstFrmCache;
                    }

                    _lstFrmCache = new List<FrmBase>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstFrmCache;
            }
        }

        public List<MensagemUsuario> lstMsgUsuarioPadrao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstMsgUsuarioPadrao != null)
                    {
                        return _lstMsgUsuarioPadrao;
                    }

                    _lstMsgUsuarioPadrao = new List<MensagemUsuario>();

                    _lstMsgUsuarioPadrao.Add(new MensagemUsuario("ArquivoMain não existe.", 100));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstMsgUsuarioPadrao;
            }
        }

        public List<DataBase.Tabela> lstTbl
        {
            get
            {
                return _lstTbl;
            }

            set
            {
                _lstTbl = value;
            }
        }

        public Cliente objCliente
        {
            get
            {
                return _objCliente;
            }

            set
            {
                _objCliente = value;
            }
        }

        public DataBase.DataBase objDbPrincipal
        {
            get
            {
                return _objDbPrincipal;
            }

            set
            {
                _objDbPrincipal = value;
            }
        }

        public Fornecedor objFornecedor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objFornecedor != null)
                    {
                        return _objFornecedor;
                    }

                    _objFornecedor = new Fornecedor();

                    _objFornecedor.strNome = "Digosoftware";
                    _objFornecedor.strDescricao = "Automação e solução para Windows.";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objFornecedor;
            }

            set
            {
                _objFornecedor = value;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_arqXmlUpdate != null)
                    {
                        return _arqXmlUpdate;
                    }

                    _arqXmlUpdate = new ArquivoXml();

                    _arqXmlUpdate.strNome = this.strNome + "_Update.xml";
                    _arqXmlUpdate.dirCompleto = _arqXmlUpdate.dirTempCompleto;

                    this.ftpUpdate.downloadArquivo(_arqXmlUpdate.strNome, _arqXmlUpdate.dirTempCompleto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _arqXmlUpdate;
            }
        }

        protected bool booAtualizarTituloFrmPrincipal
        {
            get
            {
                return _booAtualizarTituloFrmMain;
            }

            set
            {
                _booAtualizarTituloFrmMain = value;
            }
        }

        private List<ArquivoMain> lstArqDependencia
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstArqDependencia != null)
                    {
                        return _lstArqDependencia;
                    }

                    _lstArqDependencia = new List<ArquivoMain>();

                    this.inicializarLstArqDependencia(_lstArqDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstArqDependencia;
            }
        }

        private List<MensagemUsuario> lstMsgUsuario
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstMsgUsuario != null)
                    {
                        return _lstMsgUsuario;
                    }

                    _lstMsgUsuario = new List<MensagemUsuario>();

                    this.inicializarLstMsgUsuario(_lstMsgUsuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstMsgUsuario;
            }
        }

        #endregion Atributos

        #region Construtores

        protected Aplicativo()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                i = this;

                if (!this.getBooAutoInicializar())
                {
                    return;
                }

                this.iniciar();
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

        #region Destrutor

        ~Aplicativo()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.apagarPastaTemp();
            }
            catch (Exception ex)
            {
                new Erro("Erro ao criar ArquivoMain XML de configuração do Aplicativo.", ex, Erro.ErroTipo.NOTIFICACAO);
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Destrutor

        #region Métodos

        /// <summary>
        /// Cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrm(Type cls)
        {
            #region Variáveis

            DialogResult enmDialogResult;
            FrmBase frm;

            #endregion Variáveis

            #region Ações

            try
            {
                frm = (FrmBase)Activator.CreateInstance(cls);
                enmDialogResult = frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return enmDialogResult;
        }

        /// <summary>
        /// Verifica se existe uma instância do "FrmBase" no cache de formulários e o coloca na tela.
        /// Caso não exista, cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrmCache(Type cls)
        {
            #region Variáveis

            DialogResult enmDialogResult;
            FrmBase frm;

            #endregion Variáveis

            #region Ações

            try
            {
                frm = Aplicativo.i.getFrmCacheInstancia(cls);
                enmDialogResult = frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return enmDialogResult;
        }

        /// <summary>
        /// Verifica se há uma nova versão de algum dos arquivos na lista de dependência do aplicativo.
        /// </summary>
        /// <param name="dirLocalUpdate">
        /// Caso seja diferente de "" o arquivo é baixado por este endereço na rede interna.
        /// </param>
        /// <param name="dirLocalUpdateSalvar">
        /// Caso seja diferente de "" o arquivo é copiado para este endereço na rede interna.
        /// </param>
        public virtual void atualizar(string dirLocalUpdate = null, string dirLocalUpdateSalvar = null)
        {
            #region Variáveis

            ArquivoXml arqXmlUpdateLocal;
            bool booResultado = false;
            FrmEspera frmEspera = null;
            XmlNodeList xmlNodeList;

            #endregion Variáveis

            #region Ações

            try
            {
                frmEspera = this.mostrarFormularioEspera("Verificando se existe uma nova versão no servidor.");

                if (!string.IsNullOrEmpty(dirLocalUpdateSalvar))
                {
                    this.gerarXmlAtualizacao(dirLocalUpdateSalvar);
                }

                if (string.IsNullOrEmpty(dirLocalUpdate))
                {
                    xmlNodeList = this.arqXmlUpdate.getXmlNodeList();
                }
                else
                {
                    arqXmlUpdateLocal = new ArquivoXml();

                    arqXmlUpdateLocal.strNome = this.strNome + "_Update.xml";

                    xmlNodeList = arqXmlUpdateLocal.getXmlNodeList();
                }

                frmEspera.intProgressoMaximo = xmlNodeList.Count;

                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    if (!this.atualizar(dirLocalUpdate, dirLocalUpdateSalvar, frmEspera, xmlNode))
                    {
                        continue;
                    }

                    booResultado = true;
                }

                this.gerarXmlAtualizacao(dirLocalUpdateSalvar);

                frmEspera.booConcluido = true;

                if (!booResultado)
                {
                    return;
                }

                Aplicativo.i.frmPrincipal.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("Para concluir a atualização o sistema " + this.strNome + " será reiniciado.");
                    Aplicativo.i.frmPrincipal.Close();
                });

                AppDomain.CurrentDomain.ProcessExit += new EventHandler(this.abrirAppUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                frmEspera.booConcluido = true;
            }

            #endregion Ações
        }

        /// <summary>
        /// Cria um repositório para atualização automática.
        /// </summary>
        /// <param name="dirRepositorioUpdate">
        /// Diretório onde o repositório será salvo. Caso este valor seja passado vazio, criará o
        /// repositório no mesmo diretório do executável.
        /// </param>
        public void gerarRepositorioUpdate(string dirRepositorioUpdate = null)
        {
            #region Variáveis

            FrmEspera frmEspera = null;

            #endregion Variáveis

            #region Ações

            try
            {
                frmEspera = this.mostrarFormularioEspera("", "Criando repositório local");
                frmEspera.intProgressoMaximo = this.lstArqDependencia.Count + 1;

                if (string.IsNullOrEmpty(dirRepositorioUpdate))
                {
                    dirRepositorioUpdate = this.dirExecutavel;
                }

                this.gerarXmlAtualizacao(dirRepositorioUpdate);
                frmEspera.decProgresso++;

                foreach (ArquivoMain arq in this.lstArqDependencia)
                {
                    frmEspera.strTarefaDescricao = "Criando arquivo: " + arq.strNome;
                    arq.compactar(dirRepositorioUpdate);
                    frmEspera.decProgresso++;
                }

                frmEspera.booConcluido = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                frmEspera.booConcluido = true;
            }

            #endregion Ações
        }

        /// <summary>
        /// Retornar uma "string" contendo a mensagem destinada ao usuário.
        /// </summary>
        public string getStrMensagemUsuario(int intId, MensagemUsuario.Lingua objLingua = MensagemUsuario.Lingua.PORTUGUES)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (MensagemUsuario msg in this.lstMsgUsuario)
                {
                    if (!intId.Equals(msg.intId) || !objLingua.Equals(msg.objLingua))
                    {
                        continue;
                    }

                    return msg.strMsg;
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

            return null;
        }

        public string getStrMensagemUsuarioPadrao(int intId, MensagemUsuario.Lingua objLingua = MensagemUsuario.Lingua.PORTUGUES)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (MensagemUsuario msg in this.lstMsgUsuarioPadrao)
                {
                    if (!intId.Equals(msg.intId) || !objLingua.Equals(msg.objLingua))
                    {
                        continue;
                    }

                    return msg.strMsg;
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

            return null;
        }

        public string getStrTituloAplicativo()
        {
            #region Variáveis

            string strResultado = null;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "_app_nome (_app_versao) - _app_descricao";

                strResultado = strResultado.Replace("_app_nome", this.strNome);
                strResultado = strResultado.Replace("_app_versao", this.getStrVersaoCompleta());
                strResultado = strResultado.Replace("_app_descricao", this.strDescricao);

                if (string.IsNullOrEmpty(this.strDescricao))
                {
                    strResultado = strResultado.Replace(" - ", string.Empty);
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

            return strResultado;
        }

        public string getStrVersaoCompleta()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = this.arqExePrincipal.getStrVersao();
                strResultado += this.booBeta ? " beta" : "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return strResultado;
        }

        /// <summary>
        /// Mostra um formulário para inserção de texto simples.
        /// </summary>
        public string input(string strTitulo = "Insira o texto", string strDescricao = "Utilize o campo abaixo para inserção do texto.", string strValorDefault = "")
        {
            #region Variáveis

            string strResultado = null;

            #endregion Variáveis

            #region Ações

            try
            {
                FrmInput.i.strTitulo = strTitulo;
                FrmInput.i.strDescricao = strDescricao;
                FrmInput.i.strValorDefault = strValorDefault;
                FrmInput.i.ShowDialog();

                strResultado = this.strInput;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return strResultado;
        }

        /// <summary>
        /// Termina processos que contém em seu nome o parâmetro "strProcessoNome".
        /// </summary>
        public void matarProcesso(string strProcessoNome)
        {
            #region Variáveis

            Process[] arrObjProcess;

            #endregion Variáveis

            #region Ações

            try
            {
                arrObjProcess = Process.GetProcessesByName(strProcessoNome);

                foreach (Process process in arrObjProcess)
                {
                    process.Kill();
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

        /// <summary>
        /// Termina o processo indicado pelo "pid" passado como parâmetro. Assim como os processos
        /// filhos deste.
        /// </summary>
        public void matarProcesso(int intPid)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                using (var searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + intPid))
                using (ManagementObjectCollection moc = searcher.Get())
                {
                    foreach (ManagementObject mo in moc)
                    {
                        this.matarProcesso(Convert.ToInt32(mo["ProcessID"]));
                    }
                    try
                    {
                        Process proc = Process.GetProcessById(intPid);
                        proc.CloseMainWindow();
                        proc.Kill();
                    }
                    catch (ArgumentException)
                    { /* process already exited */
                    }
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

        public FrmEspera mostrarFormularioEspera(string strTarefaDescricao = "Rotina do sistema {sis_nome} sendo realizada.", string strTarefaTitulo = "Por favor aguarde...")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (strTarefaDescricao.Contains("{sis_nome}"))
                {
                    strTarefaDescricao = "Rotina do Sistema " + this.strNome + " sendo realizada...";
                }

                this.frmEspera.booConcluido = false;
                this.frmEspera.decProgresso = 0;
                this.frmEspera.decProgressoTarefa = 0;
                this.frmEspera.intProgressoMaximo = 0;
                this.frmEspera.intProgressoMaximoTarefa = 0;
                this.frmEspera.strTarefaDescricao = strTarefaDescricao;
                this.frmEspera.strTarefaTitulo = strTarefaTitulo;

                new Thread(() => this.frmEspera.ShowDialog()).Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return this.frmEspera;
        }

        protected virtual bool getBooAutoInicializar()
        {
            return true;
        }

        protected virtual Type getClsFrmPrincipal()
        {
            return null;
        }

        protected virtual Ftp getFtpUpdate()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (ConfigMain.i == null)
                {
                    return null;
                }

                return new Ftp(ConfigMain.i.strFtpUpdateServer, ConfigMain.i.strFtpUpdateUser, ConfigMain.i.strFtpUpdateSenha);
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

        protected abstract string getStrAppNome();

        /// <summary>
        /// Método que é chamado no construtor desta classe e pode ser usado para inicializar valores
        /// para essa instância.
        /// </summary>
        protected virtual void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = this.getStrAppNome();
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

        /// <summary>
        /// Este método deve ser sobescrito para inicializar a lista de arquivos que fazem parte do
        /// projeto para que fiquem disponíveis no processo de atualização automática.
        /// </summary>
        /// <param name="lstArqDependencia">Instância de <see cref="lstArqDependencia"/>.</param>
        protected virtual void inicializarLstArqDependencia(List<ArquivoMain> lstArqDependencia)
        {
            lstArqDependencia.Add(this.arqExePrincipal);
        }

        protected virtual void inicializarLstMsgUsuario(List<MensagemUsuario> lstMsgUsuario)
        {
        }

        protected void iniciar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
                this.setEventos();
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

        /// <summary>
        /// Método chamado dentro do construtor desta classe e deve ser utilizado para inicializar os
        /// eventos necessários ao funcionamento da aplicação.
        /// </summary>
        protected virtual void setEventos()
        {
        }

        private void abrirAppUpdate(object sender, EventArgs e)
        {
            #region Variáveis

            Process objProcess;
            Process[] pname;

            #endregion Variáveis

            #region Ações

            try
            {
                objProcess = new Process();
                objProcess.StartInfo.FileName = "AppUpdate.exe";
                objProcess.StartInfo.Arguments = this.arqExePrincipal.dirCompleto;
                objProcess.StartInfo.CreateNoWindow = true;
                objProcess.Start();

                Thread.Sleep(1500);

                do
                {
                    pname = Process.GetProcessesByName("AppUpdate2");
                } while (pname.Length > 0);

                objProcess = new Process();
                objProcess.StartInfo.FileName = this.dirExecutavelCompleto;
                objProcess.StartInfo.Arguments = "Atualizado";
                objProcess.Start();
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

        private void apagarPastaTemp()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private bool atualizar(string dirLocalUpdate, string dirLocalUpdateSalvar, FrmEspera frmEspera, XmlNode xmlNode)
        {
            #region Variáveis

            ArquivoMain arq;

            #endregion Variáveis

            #region Ações

            try
            {
                frmEspera.strTarefaDescricao = "Analisando o arquivo \"" + xmlNode.Name + "\".";

                arq = null;

                foreach (ArquivoMain arq2 in this.lstArqDependencia)
                {
                    if (xmlNode.Name.Equals(arq2.strNomeSimplificado))
                    {
                        arq = arq2;
                        break;
                    }
                }

                if (arq == null)
                {
                    arq = new ArquivoDiverso(ArquivoMain.EnmMimeTipo.TEXT_PLAIN);
                    arq.strNome = xmlNode.ChildNodes.Item(0).InnerText;
                    arq.dir = this.dirExecutavel;
                }

                if (xmlNode.ChildNodes.Item(1).InnerText.Equals(arq.strMd5))
                {
                    return false;
                }

                frmEspera.strTarefaDescricao = "Arquivo \"" + xmlNode.ChildNodes.Item(0).InnerText + "\" desatualizado. Fazendo download.";

                arq.atualizarFtp(string.IsNullOrEmpty(dirLocalUpdate) ? dirLocalUpdateSalvar : dirLocalUpdate);

                frmEspera.strTarefaDescricao = "Arquivo \"" + xmlNode.ChildNodes.Item(0).InnerText + "\" desatualizado. Descompactando.";

                arq.descompactarUpdate();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                frmEspera.decProgresso++;
            }

            #endregion Ações
        }

        private bool calcularBooAtualizado()
        {
            #region Variáveis

            ArquivoMain arqTemp;
            bool booArqAtualizado;
            string strArqMd5;
            string strArqNomeSimplificado;

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (XmlNode xmlNode in this.arqXmlUpdate.getXmlNodeList())
                {
                    if (xmlNode == null)
                    {
                        continue;
                    }

                    booArqAtualizado = false;
                    arqTemp = null;
                    strArqNomeSimplificado = xmlNode.Name;
                    strArqMd5 = xmlNode.ChildNodes.Item(1).InnerText;

                    foreach (ArquivoMain arq in this.lstArqDependencia)
                    {
                        if (arq == null)
                        {
                            continue;
                        }

                        if (strArqNomeSimplificado.Equals(arq.strNomeSimplificado))
                        {
                            arqTemp = arq;
                            break;
                        }
                    }

                    if (arqTemp != null)
                    {
                        booArqAtualizado = strArqMd5.Equals(arqTemp.strMd5);
                    }

                    if (!booArqAtualizado)
                    {
                        return false;
                    }
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

            return true;
        }

        private void gerarXmlAtualizacao(string dir)
        {
            #region Variáveis

            ArquivoXml xml;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(dir))
                {
                    return;
                }

                xml = new ArquivoXml();
                xml.strNome = this.strNome + "_Update.xml";
                xml.dir = dir;

                foreach (ArquivoMain objArquivoReferencia in this.lstArqDependencia)
                {
                    xml.setStrElemento(objArquivoReferencia.strNomeSimplificado, "");
                    xml.addNode("nome", objArquivoReferencia.strNome, objArquivoReferencia.strNomeSimplificado);
                    xml.addNode("md5", objArquivoReferencia.strMd5, objArquivoReferencia.strNomeSimplificado);
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

        private string getDirExecutavel()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.booAplicativoWeb)
                {
                    return HttpContext.Current.Server.MapPath("~/");
                }

                return Application.StartupPath;
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

        /// <summary>
        /// Retorna a instância de um formulário do cache de formulários. Caso este formulário não
        /// exista no cache cria uma nova e o retorna.
        /// </summary>
        private FrmBase getFrmCacheInstancia(Type cls)
        {
            #region Variáveis

            FrmBase frmResultado = null;

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (FrmBase frm in this.lstFrmCache)
                {
                    if (frm.GetType() == cls)
                    {
                        frmResultado = frm;
                        break;
                    }
                }

                if (frmResultado == null)
                {
                    frmResultado = (FrmBase)Activator.CreateInstance(cls);
                    this.lstFrmCache.Add(frmResultado);
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

            return frmResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}