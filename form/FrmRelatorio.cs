using DigoFramework.arquivo;
using DigoFramework.relatorio.objeto;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DigoFramework.form
{
    public partial class FrmRelatorio : FrmBase
    {
        #region CONSTANTES

        public enum EnmTipoRelatorio
        {
            EXCEL, PDF
        }

        #endregion

        #region ATRIBUTOS

        private List<ObjRelatorioMain> _lstObjRelatorioMain;
        public List<ObjRelatorioMain> lstObjRelatorioMain
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_lstObjRelatorioMain == null)
                    {
                        _lstObjRelatorioMain = new List<ObjRelatorioMain>();
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

                return _lstObjRelatorioMain;
            }
            set { _lstObjRelatorioMain = value; }
        }

        private ArquivoDiverso _objArquivoRelatorio;
        protected ArquivoDiverso objArquivoRelatorio
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_objArquivoRelatorio==null)
                    {

                        _objArquivoRelatorio = new ArquivoDiverso(Arquivo.EnmMimeTipo.TEXT_PLAIN);
                        _objArquivoRelatorio.strNome = "Relatório desconhecido";
                        _objArquivoRelatorio.strDescricao = "Uso desconhecido";
                        _objArquivoRelatorio.dir = Aplicativo.i.dirExecutavel;
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
                return _objArquivoRelatorio;
            }
            set { _objArquivoRelatorio = value; }
        }

        #endregion

        #region CONSTRUTORES

        public FrmRelatorio()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

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

        #region DESTRUTOR
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Adiciona os parâmetros ao relatório.
        /// </summary>
        protected virtual void adicionarRelatorioParametros(ReportViewer rpv)
        {
            #region VARIÁVEIS

            List<ReportParameter> lstReportParameter = new List<ReportParameter>();

            #endregion
            try
            {
                #region AÇÕES

                lstReportParameter = new List<ReportParameter>();
                lstReportParameter.Add(new ReportParameter("strEmpresaNome", Aplicativo.i.objCliente.strNomeExibicao));
                lstReportParameter.Add(new ReportParameter("strEmpresaDescricao", Aplicativo.i.objCliente.strDescricao));
                lstReportParameter.Add(new ReportParameter("strRelatorioNome", this.objArquivoRelatorio.strNomeExibicao));
                lstReportParameter.Add(new ReportParameter("strRelatorioDescricao", this.objArquivoRelatorio.strDescricao));
                lstReportParameter.Add(new ReportParameter("strSistemaNome", Aplicativo.i.strNomeExibicao));
                lstReportParameter.Add(new ReportParameter("strSistemaDescricao", Aplicativo.i.strDescricao));
                lstReportParameter.Add(new ReportParameter("strSistemaSite", Aplicativo.i.strSiteOficial));

                rpv.LocalReport.SetParameters(lstReportParameter);

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

        /// <summary>
        /// Instancia a lista de objetos que comporão o relatório.
        /// </summary>
        protected void carregarDados()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES



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

        /// <summary>
        /// Imprime o relatório na tela
        /// </summary>
        protected virtual void imprimirRelatorio(ReportViewer rpv, EnmTipoRelatorio enmTipoRelatorio = EnmTipoRelatorio.PDF)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.adicionarRelatorioParametros(rpv);

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

        /// <summary>
        /// Abre o relatório na forma de uma planilha
        /// do excel.
        /// </summary>
        private void imprimirRelatorioExcel(ReportViewer rpv)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                throw new NotImplementedException();

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

        /// <summary>
        /// Abre o relatório na forma de um arquivo
        /// do Adobe Reader (pdf).
        /// </summary>
        private void imprimirRelatorioPdf(ReportViewer rpv)
        {
            #region VARIÁVEIS

            Byte[] arrByte;
            Warning[] arrObjWarnings;
            String[] arrStrStreams;

            String strEncoding;
            String strFileNameExtension;
            String strMimeType;

            BinaryWriter objBinaryWriterEscritor;
            FileStream objFileStreamLeitorPdf;

            #endregion
            try
            {
                #region AÇÕES

                arrByte = rpv.LocalReport.Render("PDF", null, out strMimeType, out strEncoding, out strFileNameExtension, out arrStrStreams, out arrObjWarnings);

                objFileStreamLeitorPdf = new FileStream(this.objArquivoRelatorio.dirCompleto, FileMode.Create);

                objBinaryWriterEscritor = new BinaryWriter(objFileStreamLeitorPdf);
                objBinaryWriterEscritor.Write(arrByte);
                objBinaryWriterEscritor.Close();

                Process.Start(this.objArquivoRelatorio.dirCompleto);


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

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES



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

        #endregion
    }
}
