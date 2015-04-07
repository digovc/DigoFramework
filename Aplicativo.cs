using DigoFramework.Arquivo;
using DigoFramework.DataBase;
using DigoFramework.Frm;
using DigoFramework.ObjMain;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace DigoFramework
{
    public abstract class Aplicativo : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private static Aplicativo _i;
        private ArquivoExe _arqExePrincipal;
        private ArquivoXml _arqXmlConfig;
        private ArquivoXml _arqXmlUpdate;
        private string[] _arrStrArgIn;
        private bool _booAplicativoWeb;
        private bool _booAtualizado;
        private bool _booAtualizarTituloFrmMain = true;
        private bool _booBeta = true;
        private bool _booDesenvolvimento = true;
        private bool _booIniciarComWindows;
        private string _dirExecutavel;
        private string _dirTemp;
        private FrmEspera _frmEspera;
        private FrmMain _frmPrincipal;
        private Ftp _ftpUpdate;
        private int _intVersaoBuid;
        private List<Arquivo.ArquivoMain> _lstArqDependencia;
        private List<FrmMain> _lstFrmCache;
        private List<MensagemUsuario> _lstMsgUsuario;
        private List<MensagemUsuario> _lstMsgUsuarioPadrao;
        private List<DbTabela> _lstTbl;
        private Cliente _objCliente;
        private DataBase.DataBase _objDbPrincipal;
        private Fornecedor _objFornecedor;
        private string _strInput;
        private DbTabela _tblSelec;
        private string _urlSiteOficial;

        public static Aplicativo i
        {
            get
            {
                return _i;
            }

            private set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES
            }
        }

        public ArquivoExe arqExePrincipal
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

                return _arqExePrincipal;
            }
        }

        public ArquivoXml arqXmlConfig
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_arqXmlConfig != null)
                    {
                        return _arqXmlConfig;
                    }

                    _arqXmlConfig = new ArquivoXml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _arqXmlConfig;
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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES
            }
        }

        public bool booAplicativoWeb
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

                return _booAplicativoWeb;
            }
        }

        public bool booAtualizado
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES
            }
        }

        public string dirExecutavel
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_dirExecutavel))
                    {
                        return _dirExecutavel;
                    }

                    if (this.booAplicativoWeb)
                    {
                        _dirExecutavel = HttpContext.Current.Server.MapPath("~/");
                        return _dirExecutavel;
                    }

                    _dirExecutavel = Application.StartupPath;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _dirExecutavel;
            }
        }

        public string dirExecutavelCompleto
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES
            }
        }

        public string dirTemp
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (String.IsNullOrEmpty(Aplicativo.i.strNomeSimplificado))
                    {
                        throw new NotImplementedException("O nome do aplicativo deve ser implementado.");
                    }

                    if (!String.IsNullOrEmpty(_dirTemp))
                    {
                        return _dirTemp;
                    }

                    _dirTemp = System.IO.Path.GetTempPath() + Aplicativo.i.strNomeSimplificado;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _dirTemp;
            }
        }

        public FrmEspera frmEspera
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

                return _frmEspera;
            }
        }

        public FrmMain frmPrincipal
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_frmPrincipal != null)
                    {
                        return _frmPrincipal;
                    }

                    _frmPrincipal = (FrmMain)Activator.CreateInstance(this.getClsFrmPrincipal());

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

                #endregion AÇÕES

                return _frmPrincipal;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES
            }
        }

        public Ftp ftpUpdate
        {
            get
            {
                #region VARIÁVEIS

                string strPass;
                string strServer;
                string strUser;

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_ftpUpdate != null)
                    {
                        return _ftpUpdate;
                    }

                    strPass = this.arqXmlConfig.getStrElemento("strPass");
                    strServer = this.arqXmlConfig.getStrElemento("ftpUpdate");
                    strUser = this.arqXmlConfig.getStrElemento("strUser");

                    _ftpUpdate = new Ftp(strServer, strUser, strPass);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _ftpUpdate;
            }

            set
            {
                _ftpUpdate = value;
            }
        }

        public List<ArquivoMain> lstArqDependencia
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_lstArqDependencia != null)
                    {
                        return _lstArqDependencia;
                    }

                    _lstArqDependencia = new List<Arquivo.ArquivoMain>();

                    _lstArqDependencia.Add(this.arqExePrincipal);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _lstArqDependencia;
            }
        }

        public List<FrmMain> lstFrmCache
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_lstFrmCache != null)
                    {
                        return _lstFrmCache;
                    }

                    _lstFrmCache = new List<FrmMain>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _lstFrmCache;
            }
        }

        public List<MensagemUsuario> lstMsgUsuario
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_lstMsgUsuario != null)
                    {
                        return _lstMsgUsuario;
                    }

                    _lstMsgUsuario = new List<MensagemUsuario>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _lstMsgUsuario;
            }
        }

        public List<MensagemUsuario> lstMsgUsuarioPadrao
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

                return _lstMsgUsuarioPadrao;
            }
        }

        public List<DbTabela> lstTbl
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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

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

        public DbTabela tblSelec
        {
            get
            {
                return _tblSelec;
            }

            set
            {
                _tblSelec = value;
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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

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

        private int intVersaoBuid
        {
            get
            {
                return _intVersaoBuid;
            }

            set
            {
                _intVersaoBuid = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public Aplicativo()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                Aplicativo.i = this;
                this.inicializarArqXmlConfig();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar ArquivoMain XML de configuração do Aplicativo.\n" + ex.Message);
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region DESTRUTOR

        ~Aplicativo()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.setOutObjArquivoXmlConfig();
                this.apagarPastaTemp();
            }
            catch (Exception ex)
            {
                new Erro("Erro ao criar ArquivoMain XML de configuração do Aplicativo.", ex, Erro.ErroTipo.NOTIFICACAO);
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion DESTRUTOR

        #region MÉTODOS

        /// <summary>
        /// Cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrm(Type cls)
        {
            #region VARIÁVEIS

            DialogResult enmDialogResult;
            FrmMain frm;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                frm = (FrmMain)Activator.CreateInstance(cls);
                enmDialogResult = frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return enmDialogResult;
        }

        /// <summary>
        /// Verifica se existe uma instância do "FrmBase" no cache de formulários e o coloca na
        /// tela. Caso não exista, cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrmCache(Type cls)
        {
            #region VARIÁVEIS

            DialogResult enmDialogResult;
            FrmMain frm;

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES

            return enmDialogResult;
        }

        /// <summary>
        /// Verifica se há uma nova versão de algum dos arquivos na lista de dependência do aplicativo.
        /// </summary>
        /// <returns>Retorna false se todos arquivos estiverem atualizados.</returns>
        public virtual bool atualizar()
        {
            return this.atualizar(null, null);
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
        /// <returns>Retorna false se todos arquivos estiverem atualizados.</returns>
        public bool atualizar(string dirLocalUpdate, string dirLocalUpdateSalvar)
        {
            #region VARIÁVEIS

            ArquivoMain arq;
            ArquivoMain arqXmlUpdateLocal;
            bool booArqAtualizado;
            bool booResultado = false;
            FrmEspera frmEspera = null;
            string strArqMd5;
            string strArqNome;
            string strArqNomeSimplificado;
            XmlNodeList objXmlNodeList;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                frmEspera = this.mostrarFormularioEspera("Verificando se existe uma nova versão no servidor.");

                if (!String.IsNullOrEmpty(dirLocalUpdateSalvar))
                {
                    this.gerarXmlAtualizacao(dirLocalUpdateSalvar);
                }

                if (String.IsNullOrEmpty(dirLocalUpdate))
                {
                    objXmlNodeList = this.arqXmlUpdate.getXmlNodeList();
                }
                else
                {
                    arqXmlUpdateLocal = new ArquivoXml();
                    arqXmlUpdateLocal.strNome = this.strNome + "_Update.xml";
                    objXmlNodeList = this.arqXmlUpdate.getXmlNodeList();
                }

                frmEspera.intProgressoMaximo = objXmlNodeList.Count;

                foreach (XmlNode nde in objXmlNodeList)
                {
                    frmEspera.strTarefaDescricao = "Analisando o arquivo \"" + nde.Name + "\".";

                    booArqAtualizado = false;
                    arq = null;
                    strArqNomeSimplificado = nde.Name;
                    strArqNome = nde.ChildNodes.Item(0).InnerText;
                    strArqMd5 = nde.ChildNodes.Item(1).InnerText;

                    foreach (Arquivo.ArquivoMain arq2 in this.lstArqDependencia)
                    {
                        if (strArqNomeSimplificado.Equals(arq2.strNomeSimplificado))
                        {
                            arq = arq2;
                            break;
                        }
                    }

                    if (arq == null)
                    {
                        arq = new ArquivoDiverso(Arquivo.ArquivoMain.EnmMimeTipo.TEXT_PLAIN);
                        arq.strNome = strArqNome;
                        arq.dir = this.dirExecutavel;
                    }

                    booArqAtualizado = strArqMd5.Equals(arq.strMd5);

                    if (!booArqAtualizado)
                    {
                        booResultado = true;
                        frmEspera.strTarefaDescricao = "ArquivoMain \"" + strArqNome + "\" desatualizado. Fazendo download da versão mais atual.";

                        if (String.IsNullOrEmpty(dirLocalUpdate))
                        {
                            arq.atualizarFtp(dirLocalUpdateSalvar);
                        }
                        else
                        {
                            arq.atualizarLan(dirLocalUpdate);
                        }

                        frmEspera.strTarefaDescricao = "ArquivoMain \"" + strArqNome + "\" desatualizado. Descompactando versão mais atual.";
                        arq.descompactarUpdate();
                    }

                    frmEspera.decProgresso++;
                }

                frmEspera.booConcluido = true;

                if (!booResultado)
                {
                    return booResultado;
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
                frmEspera.booConcluido = true;
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return booResultado;
        }

        /// <summary>
        /// Cria um repositório para atualização automática.
        /// </summary>
        public void gerarRepositorioUpdate(string dirRepositorioUpdate)
        {
            #region VARIÁVEIS

            FrmEspera frmEspera = null;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                frmEspera = this.mostrarFormularioEspera("", "Criando repositório local");
                frmEspera.intProgressoMaximo = this.lstArqDependencia.Count + 1;

                if (String.IsNullOrEmpty(dirRepositorioUpdate))
                {
                    dirRepositorioUpdate = this.dirExecutavel;
                }

                this.gerarXmlAtualizacao(dirRepositorioUpdate);
                frmEspera.decProgresso++;

                foreach (Arquivo.ArquivoMain objArquivo in this.lstArqDependencia)
                {
                    frmEspera.strTarefaDescricao = "Criando arquivo: " + objArquivo.strNome;
                    objArquivo.compactar(dirRepositorioUpdate);
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

            #endregion AÇÕES
        }

        /// <summary>
        /// Cria o "xml" para ser utilizado no processo de atualização.
        /// </summary>
        public void gerarXmlAtualizacao(string dir)
        {
            #region VARIÁVEIS

            ArquivoXml xml;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                xml = new ArquivoXml();
                xml.strNome = this.strNome + "_Update.xml";
                xml.dir = dir;

                foreach (Arquivo.ArquivoMain objArquivoReferencia in this.lstArqDependencia)
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

            #endregion AÇÕES
        }

        /// <summary>
        /// Retornar uma "string" contendo a mensagem destinada ao usuário.
        /// </summary>
        public string getStrMensagemUsuario(int intId, MensagemUsuario.Lingua objLingua = MensagemUsuario.Lingua.PORTUGUES)
        {
            #region VARIÁVEIS
            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES

            return null;
        }

        public string getStrMensagemUsuarioPadrao(int intId, MensagemUsuario.Lingua objLingua = MensagemUsuario.Lingua.PORTUGUES)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES

            return null;
        }

        public string getStrTituloAplicativo()
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                strResultado = "_app_nome (_app_versao) - _app_descricao";

                strResultado = strResultado.Replace("_app_nome", this.strNomeExibicao);
                strResultado = strResultado.Replace("_app_versao", this.getStrVersaoCompleta());
                strResultado = strResultado.Replace("_app_descricao", this.strDescricao);

                if (String.IsNullOrEmpty(this.strDescricao))
                {
                    strResultado = strResultado.Replace(" - ", String.Empty);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return strResultado;
        }

        public string getStrVersaoCompleta()
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                strResultado = this.arqExePrincipal.getStrVersao();
                strResultado += this.booBeta ? " Beta" : "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return strResultado;
        }

        /// <summary>
        /// Mostra um formulário para inserção de texto simples.
        /// </summary>
        public string input(string strTitulo = "Insira o texto", string strDescricao = "Utilize o campo abaixo para inserção do texto.", string strValorDefault = "")
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES

            return strResultado;
        }

        /// <summary>
        /// Termina processos que contém em seu nome o parâmetro "strProcessoNome".
        /// </summary>
        public void matarProcesso(string strProcessoNome)
        {
            #region VARIÁVEIS

            Process[] arrObjProcess;

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Termina o processo indicado pelo "pid" passado como parâmetro. Assim como os processos
        /// filhos deste.
        /// </summary>
        public void matarProcesso(int intPid)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        public FrmEspera mostrarFormularioEspera(string strTarefaDescricao = "Rotina do sistema {sis_nome} sendo realizada.", string strTarefaTitulo = "Por favor aguarde...")
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (strTarefaDescricao.Contains("{sis_nome}"))
                {
                    strTarefaDescricao = "Rotina do Sistema " + this.strNome + " sendo realizada...";
                }

                this.frmEspera.strTarefaTitulo = strTarefaTitulo;
                this.frmEspera.strTarefaDescricao = strTarefaDescricao;

                new Thread(() => this.frmEspera.ShowDialog()).Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return this.frmEspera;
        }

        protected abstract Type getClsFrmPrincipal();

        private void abrirAppUpdate(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            Process objProcess;
            Process[] pname;

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        private void apagarPastaTemp()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        private bool calcularBooAtualizado()
        {
            #region VARIÁVEIS

            ArquivoMain arqTemp;
            bool booArqAtualizado;
            string strArqMd5;
            string strArqNomeSimplificado;
            XmlNodeList objXmlNodeList;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                objXmlNodeList = this.arqXmlUpdate.getXmlNodeList();

                foreach (XmlNode nde in objXmlNodeList)
                {
                    if (nde == null)
                    {
                        continue;
                    }

                    booArqAtualizado = false;
                    arqTemp = null;
                    strArqNomeSimplificado = nde.Name;
                    strArqMd5 = nde.ChildNodes.Item(1).InnerText;

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

            #endregion AÇÕES

            return true;
        }

        /// <summary>
        /// Retorna a instância de um formulário do cache de formulários. Caso este formulário não
        /// exista no cache cria uma nova e o retorna.
        /// </summary>
        private FrmMain getFrmCacheInstancia(Type cls)
        {
            #region VARIÁVEIS

            FrmMain frmResultado = null;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                foreach (FrmMain frm in this.lstFrmCache)
                {
                    if (frm.GetType() == cls)
                    {
                        frmResultado = frm;
                        break;
                    }
                }

                if (frmResultado == null)
                {
                    frmResultado = (FrmMain)Activator.CreateInstance(cls);
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

            #endregion AÇÕES

            return frmResultado;
        }

        private void inicializarArqXmlConfig()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.arqXmlConfig.dirCompleto = this.dirExecutavel + "\\AppConfig.xml";
                this.intVersaoBuid = Convert.ToInt32(this.arqXmlConfig.getStrElemento("VersaoBuid"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private void setOutObjArquivoXmlConfig()
        {
            #region VARIÁVEIS

            int intBuidNova;
            int intQtdAcesso;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.arqXmlConfig.setStrElemento("dttUltimoAcesso", DateTime.Now.ToString());

                intQtdAcesso = Convert.ToInt32(this.arqXmlConfig.getStrElemento("intQtdAcesso"));
                intQtdAcesso++;

                this.arqXmlConfig.setStrElemento("intQtdAcesso", intQtdAcesso.ToString());

                if (this.booDesenvolvimento)
                {
                    intBuidNova = Convert.ToInt32(this.arqXmlConfig.getStrElemento("VersaoBuid"));
                    intBuidNova++;
                    this.arqXmlConfig.setStrElemento("VersaoBuid", intBuidNova.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}