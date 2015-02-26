using DigoFramework.Arquivo;
using DigoFramework.Relatorio.ObjMain;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DigoFramework.Frm
{
    public partial class FrmRelatorio : FrmMain
    {
        #region CONSTANTES

        public enum EnmTipoRelatorio
        {
            EXCEL,
            PDF
        }

        #endregion CONSTANTES

        #region ATRIBUTOS

        private List<ObjRelatorioMain> _lstObjRelatorioMain;
        private ArquivoDiverso _objArquivoRelatorio;

        public List<ObjRelatorioMain> lstObjRelatorioMain
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_lstObjRelatorioMain == null)
                    {
                        _lstObjRelatorioMain = new List<ObjRelatorioMain>();
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

                return _lstObjRelatorioMain;
            }

            set
            {
                _lstObjRelatorioMain = value;
            }
        }

        protected ArquivoDiverso objArquivoRelatorio
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_objArquivoRelatorio == null)
                    {
                        _objArquivoRelatorio = new ArquivoDiverso(Arquivo.ArquivoMain.EnmMimeTipo.TEXT_PLAIN);
                        _objArquivoRelatorio.strNome = "Relatório desconhecido";
                        _objArquivoRelatorio.strDescricao = "Uso desconhecido";
                        _objArquivoRelatorio.dir = Aplicativo.i.dirExecutavel;
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

                return _objArquivoRelatorio;
            }

            set
            {
                _objArquivoRelatorio = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public FrmRelatorio()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        /// <summary>
        /// Adiciona os parâmetros ao relatório.
        /// </summary>
        protected virtual void addRelatorioParam(ReportViewer rpv)
        {
            #region VARIÁVEIS

            List<ReportParameter> lstReportParameter = new List<ReportParameter>();

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lstReportParameter = new List<ReportParameter>();
                lstReportParameter.Add(new ReportParameter("strEmpresaNome", Aplicativo.i.objCliente.strNomeExibicao));
                lstReportParameter.Add(new ReportParameter("strEmpresaDescricao", Aplicativo.i.objCliente.strDescricao));
                lstReportParameter.Add(new ReportParameter("strRelatorioNome", this.objArquivoRelatorio.strNomeExibicao));
                lstReportParameter.Add(new ReportParameter("strRelatorioDescricao", this.objArquivoRelatorio.strDescricao));
                lstReportParameter.Add(new ReportParameter("strSistemaNome", Aplicativo.i.strNomeExibicao));
                lstReportParameter.Add(new ReportParameter("strSistemaDescricao", Aplicativo.i.strDescricao));
                lstReportParameter.Add(new ReportParameter("strSistemaSite", Aplicativo.i.strSiteOficial));

                rpv.LocalReport.SetParameters(lstReportParameter);
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
        /// Instancia a lista de objetos que comporão o relatório.
        /// </summary>
        protected virtual void carregarDados()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Imprime o relatório na tela
        /// </summary>
        protected virtual void imprimirRelatorio(ReportViewer rpv, EnmTipoRelatorio enmTipoRelatorio = EnmTipoRelatorio.PDF)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Abre o relatório na forma de uma planilha do excel.
        /// </summary>
        private void imprimirRelatorioExcel(ReportViewer rpv)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Abre o relatório na forma de um arquivo do Adobe Reader (pdf).
        /// </summary>
        private void imprimirRelatorioPdf(ReportViewer rpv)
        {
            #region VARIÁVEIS

            Byte[] arrByte;
            Warning[] arrObjWarnings;
            String[] arrStrStreams;

            string strEncoding;
            string strFileNameExtension;
            string strMimeType;

            BinaryWriter objBinaryWriterEscritor;
            FileStream objFileStreamLeitorPdf;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                arrByte = rpv.LocalReport.Render("PDF", null, out strMimeType, out strEncoding, out strFileNameExtension, out arrStrStreams, out arrObjWarnings);

                objFileStreamLeitorPdf = new FileStream(this.objArquivoRelatorio.dirCompleto, FileMode.Create);

                objBinaryWriterEscritor = new BinaryWriter(objFileStreamLeitorPdf);
                objBinaryWriterEscritor.Write(arrByte);
                objBinaryWriterEscritor.Close();

                Process.Start(this.objArquivoRelatorio.dirCompleto);
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

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        #endregion EVENTOS
    }
}