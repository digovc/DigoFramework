using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.OleDb;

namespace DigoFramework.Office
{
    public class PlanilhaExcel : Arquivo.ArquivoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DataSet _objDataSet;

        public DataSet objDataSet
        {
            get
            {
                if (_objDataSet != null)
                {
                    return _objDataSet;
                }

                _objDataSet = new DataSet();

                return _objDataSet;
            }

            set
            {
                _objDataSet = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// </summary>
        public DateTime convertDataExcelToDateTime(int intDte)
        {
            if (intDte > 59)
            {
                intDte -= 1; //Excel/Lotus 2/29/1900 bug
            }

            return new DateTime(1899, 12, 31).AddDays(intDte);
        }

        /// <summary>
        /// Retorna um objeto "DataTable" com o conteúdo da tabela da planilha com o mesmo nome do
        /// parâmetro "strTabelaNome".
        /// </summary>
        public DataTable getObjDataTable(string strTabelaNome)
        {
            string strConexao = string.Empty;
            DataSet objDataSet;
            DataTable objDataTableResultado = null;
            OleDbDataAdapter objOleDbDataAdapter;

            if (System.IO.File.Exists(this.dirCompleto))
            {
                strConexao = "Provider=Microsoft.ACE.OLEDB.12.0; data source=" + this.dirCompleto + "; Extended Properties=Excel 12.0 Xml;";

                objOleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM [" + strTabelaNome + "$]", strConexao);
                objDataSet = new DataSet();
                objOleDbDataAdapter.Fill(objDataSet, strTabelaNome);
                objDataTableResultado = objDataSet.Tables[strTabelaNome];
            }

            return objDataTableResultado;
        }

        /// <summary>
        /// Retorna um objeto "IXLWorksheet" com o conteúdo da tabela da planilha com o mesmo nome do
        /// parâmetro "strTabelaNome".
        /// </summary>
        public IXLWorksheet getPlanilha(string strPlanilhaNome)
        {
            IXLWorksheet objIXLWorksheetResultado = null;
            XLWorkbook objXLWorkbook = null;

            if (this.booExiste)
            {
                objXLWorkbook = new XLWorkbook(this.dirCompleto);
                objIXLWorksheetResultado = objXLWorkbook.Worksheet(strPlanilhaNome);
            }
            else
            {
                throw new Exception(AppBase.i.getStrMensagemUsuario(100));
            }

            return objIXLWorksheetResultado;
        }

        public override bool salvar()
        {
            string XMLDatetostring;

            System.IO.StreamWriter excelDoc;
            excelDoc = new System.IO.StreamWriter(this.dir);
            const string startExcelXML = "<xml version>\r\n<Workbook " +
                  "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                  " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                  "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                  "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                  "office:spreadsheet\">\r\n <Styles>\r\n " +
                  "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                  "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                  "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                  "\r\n <Protection/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                  "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                  "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                  " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                  "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                  "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                  "ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n " +
                  "</Styles>\r\n ";
            const string endExcelXML = "</Workbook>";

            int rowCount = 0;
            int sheetCount = 1;

            excelDoc.Write(startExcelXML);
            excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
            excelDoc.Write("<Table>");
            excelDoc.Write("<Row>");
            for (int x = 0; x < this.objDataSet.Tables[0].Columns.Count; x++)
            {
                excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                excelDoc.Write(this.objDataSet.Tables[0].Columns[x].ColumnName);
                excelDoc.Write("</Data></Cell>");
            }
            excelDoc.Write("</Row>");
            foreach (DataRow x in this.objDataSet.Tables[0].Rows)
            {
                rowCount++;
                //if the number of rows is > 64000 create a new page to continue output
                if (rowCount == 64000)
                {
                    rowCount = 0;
                    sheetCount++;
                    excelDoc.Write("</Table>");
                    excelDoc.Write(" </Worksheet>");
                    excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                    excelDoc.Write("<Table>");
                }
                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                for (int y = 0; y < this.objDataSet.Tables[0].Columns.Count; y++)
                {
                    System.Type rowType;
                    rowType = x[y].GetType();
                    switch (rowType.ToString())
                    {
                        case "System.String":
                            string XMLstring = x[y].ToString();
                            XMLstring = XMLstring.Trim();
                            XMLstring = XMLstring.Replace("&", "&");
                            XMLstring = XMLstring.Replace(">", ">");
                            XMLstring = XMLstring.Replace("<", "<");
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                           "<Data ss:Type=\"String\">");
                            excelDoc.Write(XMLstring);
                            excelDoc.Write("</Data></Cell>");
                            break;

                        case "System.DateTime":
                            //Excel has a specific Date Format of YYYY-MM-DD followed by
                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                            //The Following Code puts the date stored in XMLDate
                            //to the format above
                            DateTime XMLDate = (DateTime)x[y];
                            XMLDatetostring = XMLDate.Year.ToString() +
                                 "-" +
                                 (XMLDate.Month < 10 ? "0" +
                                 XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                 "-" +
                                 (XMLDate.Day < 10 ? "0" +
                                 XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                 "T" +
                                 (XMLDate.Hour < 10 ? "0" +
                                 XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                 ":" +
                                 (XMLDate.Minute < 10 ? "0" +
                                 XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                 ":" +
                                 (XMLDate.Second < 10 ? "0" +
                                 XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                 ".000";
                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                         "<Data ss:Type=\"DateTime\">");
                            excelDoc.Write(XMLDatetostring);
                            excelDoc.Write("</Data></Cell>");
                            break;

                        case "System.Boolean":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                        "<Data ss:Type=\"String\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;

                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                    "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;

                        case "System.Decimal":
                        case "System.Double":
                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                  "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;

                        case "System.DBNull":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                  "<Data ss:Type=\"String\">");
                            excelDoc.Write("");
                            excelDoc.Write("</Data></Cell>");
                            break;

                        default:
                            throw (new Exception(rowType.ToString() + " not handled."));
                    }
                }
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("</Table>");
            excelDoc.Write(" </Worksheet>");
            excelDoc.Write(endExcelXML);
            excelDoc.Close();

            return true;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}