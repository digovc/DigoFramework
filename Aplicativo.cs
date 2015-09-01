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

                    _dirTemp = System.IO.Path.GetTempPath() + Aplicativo.i.strNomeSimplificado;
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

        public FrmMain frmPrincipal
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

                    _ftpUpdate = new Ftp(ConfigMain.i.strFtpUpdateServer, ConfigMain.i.strFtpUpdateUser, ConfigMain.i.strFtpUpdateSenha);
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

        public List<ArquivoMain> lstArqDependencia
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

                #endregion Ações

                return _lstArqDependencia;
            }
        }

        public List<FrmMain> lstFrmCache
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

                    _lstFrmCache = new List<FrmMain>();
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

        public List<MensagemUsuario> lstMsgUsuario
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

        private int intVersaoBuid
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_intVersaoBuid > 0)
                    {
                        return _intVersaoBuid;
                    }

                    _intVersaoBuid = ConfigMain.i.intAppVersaoBuid;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _intVersaoBuid;
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
                Aplicativo.i = this;

                this.strNome = this.getStrAppNome();

                this.inicializarConfig();
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

        #region DESTRUTOR

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

        #endregion DESTRUTOR

        #region Métodos

        /// <summary>
        /// Cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrm(Type cls)
        {
            #region Variáveis

            DialogResult enmDialogResult;
            FrmMain frm;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return enmDialogResult;
        }

        /// <summary>
        /// Verifica se existe uma instância do "FrmBase" no cache de formulários e o coloca na
        /// tela. Caso não exista, cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrmCache(Type cls)
        {
            #region Variáveis

            DialogResult enmDialogResult;
            FrmMain frm;

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
            #region Variáveis

            ArquivoMain arq;
            ArquivoMain arqXmlUpdateLocal;
            bool booArqAtualizado;
            bool booResultado = false;
            FrmEspera frmEspera = null;
            string strArqMd5;
            string strArqNome;
            string strArqNomeSimplificado;
            XmlNodeList objXmlNodeList;

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

                        if (string.IsNullOrEmpty(dirLocalUpdate))
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

            #endregion Ações

            return booResultado;
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

            #endregion Ações
        }

        /// <summary>
        /// Cria o "xml" para ser utilizado no processo de atualização.
        /// </summary>
        public void gerarXmlAtualizacao(string dir)
        {
            #region Variáveis

            ArquivoXml xml;

            #endregion Variáveis

            #region Ações

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

                strResultado = strResultado.Replace("_app_nome", this.strNomeExibicao);
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
                strResultado += this.booBeta ? " Beta" : "";
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

        protected abstract Type getClsFrmPrincipal();

        protected abstract string getStrAppNome();

        protected abstract void inicializarConfig();

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

        private bool calcularBooAtualizado()
        {
            #region Variáveis

            ArquivoMain arqTemp;
            bool booArqAtualizado;
            string strArqMd5;
            string strArqNomeSimplificado;
            XmlNodeList objXmlNodeList;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return true;
        }

        /// <summary>
        /// Retorna a instância de um formulário do cache de formulários. Caso este formulário não
        /// exista no cache cria uma nova e o retorna.
        /// </summary>
        private FrmMain getFrmCacheInstancia(Type cls)
        {
            #region Variáveis

            FrmMain frmResultado = null;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return frmResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}