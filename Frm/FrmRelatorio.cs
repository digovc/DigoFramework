using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DigoFramework.Arquivo;
using DigoFramework.Relatorio.ObjMain;
using Microsoft.Reporting.WinForms;

namespace DigoFramework.Frm
{
    public partial class FrmRelatorio : FrmBase
    {
        #region Constantes

        public enum EnmTipoRelatorio
        {
            EXCEL,
            PDF
        }

        #endregion Constantes

        #region Atributos

        private ArquivoDiverso _arqRelatorio;
        private List<ObjRelatorioMain> _lstObjRelatorioMain;

        public List<ObjRelatorioMain> lstObjRelatorioMain
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstObjRelatorioMain != null)
                    {
                        return _lstObjRelatorioMain;
                    }

                    _lstObjRelatorioMain = new List<ObjRelatorioMain>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstObjRelatorioMain;
            }

            set
            {
                _lstObjRelatorioMain = value;
            }
        }

        protected ArquivoDiverso arqRelatorio
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_arqRelatorio != null)
                    {
                        return _arqRelatorio;
                    }

                    _arqRelatorio = new ArquivoDiverso(Arquivo.ArquivoMain.EnmMimeTipo.TEXT_PLAIN);

                    _arqRelatorio.dir = Aplicativo.i.dirExecutavel;
                    _arqRelatorio.strDescricao = "Uso desconhecido";
                    _arqRelatorio.strNome = "Relatório desconhecido";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _arqRelatorio;
            }

            set
            {
                _arqRelatorio = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public FrmRelatorio()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
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

        /// <summary>
        /// Adiciona os parâmetros ao relatório.
        /// </summary>
        protected virtual void addRelatorioParam(ReportViewer rpv)
        {
            #region Variáveis

            List<ReportParameter> lstReportParameter = new List<ReportParameter>();

            #endregion Variáveis

            #region Ações

            try
            {
                lstReportParameter = new List<ReportParameter>();

                lstReportParameter.Add(new ReportParameter("strEmpresaNome", Aplicativo.i.objCliente.strNomeExibicao));
                lstReportParameter.Add(new ReportParameter("strEmpresaDescricao", Aplicativo.i.objCliente.strDescricao));
                lstReportParameter.Add(new ReportParameter("strRelatorioNome", this.arqRelatorio.strNomeExibicao));
                lstReportParameter.Add(new ReportParameter("strRelatorioDescricao", this.arqRelatorio.strDescricao));
                lstReportParameter.Add(new ReportParameter("strSistemaNome", Aplicativo.i.strNomeExibicao));
                lstReportParameter.Add(new ReportParameter("strSistemaDescricao", Aplicativo.i.strDescricao));
                lstReportParameter.Add(new ReportParameter("strSistemaSite", Aplicativo.i.urlSiteOficial));

                rpv.LocalReport.SetParameters(lstReportParameter);
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
        /// Instancia a lista de objetos que comporão o relatório.
        /// </summary>
        protected virtual void carregarDados()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
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
        /// Imprime o relatório na tela
        /// </summary>
        protected virtual void imprimirRelatorio(ReportViewer rpv, EnmTipoRelatorio enmTipoRelatorio = EnmTipoRelatorio.PDF)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addRelatorioParam(rpv);

                switch (enmTipoRelatorio)
                {
                    case EnmTipoRelatorio.EXCEL:
                        this.imprimirRelatorioExcel(rpv);
                        break;

                    case EnmTipoRelatorio.PDF:
                        this.imprimirRelatorioPdf(rpv);
                        break;

                    default:
                        this.imprimirRelatorioPdf(rpv);
                        break;
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
        /// Abre o relatório na forma de uma planilha do excel.
        /// </summary>
        private void imprimirRelatorioExcel(ReportViewer rpv)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                throw new NotImplementedException();
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
        /// Abre o relatório na forma de um arquivo do Adobe Reader (pdf).
        /// </summary>
        private void imprimirRelatorioPdf(ReportViewer rpv)
        {
            #region Variáveis

            BinaryWriter objBinaryWriter;
            byte[] arrBte;
            FileStream objFileStream;

            string strEncoding;
            string strFileNameExtension;
            string strMimeType;

            string[] arrStr;
            Warning[] arrObjWarning;

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.arqRelatorio == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(this.arqRelatorio.dirCompleto))
                {
                    return;
                }

                if (string.IsNullOrEmpty(this.arqRelatorio.strNome))
                {
                    return;
                }

                this.arqRelatorio.strNome = this.arqRelatorio.strNome + ".pdf";

                arrBte = rpv.LocalReport.Render("PDF", null, out strMimeType, out strEncoding, out strFileNameExtension, out arrStr, out arrObjWarning);

                objFileStream = new FileStream(this.arqRelatorio.dirCompleto, FileMode.Create);

                objBinaryWriter = new BinaryWriter(objFileStream);
                objBinaryWriter.Write(arrBte);
                objBinaryWriter.Close();

                Process.Start(this.arqRelatorio.dirCompleto);
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

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
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