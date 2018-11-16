using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;
 
namespace GTKUtilites.HelpMethods
{
    public class GTKExcelDownLoad
    {
        int rowIndex = 1;
        public static int rowCount = 1;

        public void GenerateReportTemplate(string SavedPath, List<string> sColumnNames, List<string> sSheetNames)
        {
            int HdrRowIndex = 1;

            ExcelPackage pck = new ExcelPackage();

            var exlWS = pck.Workbook.Worksheets.Add((sSheetNames == null || sSheetNames.Count == 0) ? "GTKReport" : sSheetNames[0]);

            int ikk = sColumnNames.Count;
            for (int i = 0; i < sColumnNames.Count; i++)
            {
                exlWS.Cells[HdrRowIndex, i + 1].Value = sColumnNames[i];
                exlWS.Column(i + 1).AutoFit();

                //GetDataTypeValue(exlWS, i + 1, sDataTypes[i]);
            }

            using (var Hdrrange = exlWS.Cells[HdrRowIndex, 1, HdrRowIndex, sColumnNames.Count])
            {
                Hdrrange.Style.Font.Bold = true;
                Hdrrange.Style.Font.Italic = false;
                Hdrrange.Style.Font.UnderLine = false;
                Hdrrange.Style.Font.Size = 12;
                Hdrrange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Hdrrange.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#8F6048"));
                Hdrrange.Style.Font.Color.SetColor(Color.White);
                Hdrrange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Hdrrange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                Hdrrange.Style.Font.Name = "Calibri";
                Border hdrBorder = Hdrrange.Style.Border;
                hdrBorder.Bottom.Style = ExcelBorderStyle.Medium;
                hdrBorder.Top.Style = ExcelBorderStyle.Medium;
                hdrBorder.Left.Style = ExcelBorderStyle.Medium;
                hdrBorder.Right.Style = ExcelBorderStyle.Medium;
                //range.Style.HorizontalAlignment = HorizontalAlignment(GetSettingValue("Questionier Header", "Alignment", "Horizontal"));
                //range.Style.VerticalAlignment = VerticalAlignment(GetSettingValue("Questionier Header", "Alignment", "Vertical"));
            }

            //dtDtl.Columns.RemoveAt(0);

            FileInfo newFile = new FileInfo(SavedPath);
            pck.SaveAs(newFile);
        }

        public void GenerateReport(string SavedPath, DataSet dsDetails)
        {
             string ReportExpType = string.Empty;
               if (dsDetails.Tables[1].Select("PropType='ReportExpType'") != null && dsDetails.Tables[1].Select("PropType='ReportExpType'").Length > 0)
                {
                    ReportExpType = dsDetails.Tables[1].Select("PropType='ReportExpType'")[0]["PropValue"].ToString();

                }
               if (dsDetails.Tables.Count > 3 && dsDetails.Tables[3] != null && dsDetails.Tables[3].Rows.Count > 0 && dsDetails.Tables[3].Rows[0]["PageNumber"] != null)
               {
                   int pagenumber = Convert.ToInt32(dsDetails.Tables[3].Rows[0]["PageNumber"].ToString());
                   GenerateReportByBatch(SavedPath, dsDetails, pagenumber);
               }
               else if (ReportExpType.ToLower() == "render")
                {
                    Generatereportfromdataset(SavedPath, dsDetails);
                }
                else
                {
                    ExcelPackage pck = new ExcelPackage();
                    var exlWS = pck.Workbook.Worksheets.Add("GTKReport");
                    SetColumnWidths(dsDetails.Tables[1], exlWS, ref rowIndex, dsDetails.Tables[2]);
                    DataTable dtDtl = dsDetails.Tables[0];
                    //dtDtl.Columns.RemoveAt(0);
                    foreach (DataRow drDtl in dtDtl.Rows)
                    {
                        rowIndex++;
                        int col = 1;
                        foreach (DataColumn dc in dtDtl.Columns)
                        {
                            if (rowCount > col)
                            {

                                if (dc.ColumnName != "RecType" && dc.ColumnName != "RecStyle" && dc.ColumnName != "HiddenId" && dc.ColumnName != "S.No.")
                                {


                                    var cell = exlWS.Cells[rowIndex, col];

                                    Border headerBorder = cell.Style.Border;
                                    headerBorder.Bottom.Style = ExcelBorderStyle.Thin;
                                    headerBorder.Top.Style = ExcelBorderStyle.Thin;
                                    headerBorder.Left.Style = ExcelBorderStyle.Thin;
                                    headerBorder.Right.Style = ExcelBorderStyle.Thin;
                                    cell.Style.Font.Bold = false;
                                    cell.Style.Font.Italic = false;
                                    cell.Style.Font.UnderLine = false;
                                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;

                                    cell.Style.Font.Name = "Calibri";
                                    cell.Style.Font.Size = 10;
                                    cell.Style.Fill.BackgroundColor.SetColor(Color.White);
                                    cell.Style.Font.Color.SetColor(Color.Black);


                                    if (dtDtl.Columns.Contains("RecStyle"))
                                    {

                                        if (drDtl["RecStyle"].ToString() == "HDR")
                                        {

                                            cell.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#F6E4CC"));
                                            cell.Style.Font.Color.SetColor(Color.Black);
                                        }
                                        else if (drDtl["RecStyle"].ToString() == "DATA")
                                        {

                                            cell.Style.Fill.BackgroundColor.SetColor(Color.White);
                                            cell.Style.Font.Color.SetColor(Color.Black);
                                        }
                                        else if (drDtl["RecStyle"].ToString() == "FTR")
                                        {

                                            cell.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#EEECE1"));
                                            cell.Style.Font.Color.SetColor(Color.Black);
                                        }
                                    }

                                    cell.Value = drDtl[dc.ColumnName].ToString();
                                    col++;
                                }
                            }
                        }

                    }
                    exlWS.Cells.AutoFitColumns();

                    FileInfo newFile = new FileInfo(SavedPath);
                    pck.SaveAs(newFile);
                }
        }

        private static void Generatereportfromdataset(string SavedPath, DataSet dsDetails)
        {
            string[] sDispDataTypes= null;
            string[] sDataTypes = null;
            if (dsDetails.Tables.Count > 0)
            {
                string[] sColumnWidths = dsDetails.Tables[1].Select("PropType='ColumnLengths'")[0]["PropValue"].ToString().Split('|').ToArray();
                string[] sHeaderNames = dsDetails.Tables[1].Select("PropType='AliasNames'")[0]["PropValue"].ToString().Split('|').ToArray();

                if (dsDetails.Tables[1].Select("PropType='DataTypes'") != null && dsDetails.Tables[1].Select("PropType='DataTypes'").Length > 0)
                {
                    sDataTypes = dsDetails.Tables[1].Select("PropType='DataTypes'")[0]["PropValue"].ToString().Split('|').ToArray();
                }
                
                if (dsDetails.Tables[1].Select("PropType='DispDataTypes'") != null && dsDetails.Tables[1].Select("PropType='DispDataTypes'").Length > 0)
                {
                    sDispDataTypes = dsDetails.Tables[1].Select("PropType='DispDataTypes'")[0]["PropValue"].ToString().Split('|').ToArray();
                }
                string sFilterName = "No Filter";
                if (dsDetails.Tables[2].Rows.Count > 0)
                    sFilterName = dsDetails.Tables[2].Rows[0]["FilterValue"].ToString();

                DataTable dtCloned = dsDetails.Tables[0].Clone();

                string sReportName = dsDetails.Tables[1].Select("PropType='LOVName'")[0]["PropValue"].ToString();
                int rowCount = int.Parse(dsDetails.Tables[1].Select("PropType='HideColFrom'")[0]["PropValue"].ToString())-1;
                dtCloned = dsDetails.Tables[0];

                for (int x = rowCount; x < dtCloned.Columns.Count; x++)
                {
                    dtCloned.Columns.RemoveAt(x);
                }

                if (dtCloned.Columns.Contains("S.No."))
                    dtCloned.Columns.Remove("S.No.");
                if (dtCloned.Columns.Contains("HiddenId"))
                    dtCloned.Columns.Remove("HiddenId");
                if (dtCloned.Columns.Contains("RecType"))
                    dtCloned.Columns.Remove("RecType");
                if (dtCloned.Columns.Contains("RecStyle"))
                    dtCloned.Columns.Remove("RecStyle");

                // Add a new worksheet to the empty workbook
                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("GTKReport");
                // Load data from DataTable to the worksheet
                ws.Cells["A1"].LoadFromDataTable(dtCloned, true);
                ws.Cells.AutoFitColumns();
                ws.InsertRow(1, 3);
                ws.Cells[1, 1].Value = "Report Generated Date: " + DateTime.Now.ToString();
                ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[1, 1, 1, rowCount].Merge = true;
                using (ExcelRange rng = ws.Cells[1, 1, 1, rowCount])
                {

                    rng.Style.Font.Bold = true;
                    rng.Style.Font.Size = 20;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#E9AF32"));
                    rng.Style.Font.Color.SetColor(System.Drawing.Color.White);

                    rng.Style.Font.Name = "Calibri";
                    Border headerBorder = rng.Style.Border;
                    headerBorder.Bottom.Style = ExcelBorderStyle.Medium;
                    headerBorder.Top.Style = ExcelBorderStyle.Medium;
                    headerBorder.Left.Style = ExcelBorderStyle.Medium;
                    headerBorder.Right.Style = ExcelBorderStyle.Medium;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                ws.Row(1).Height = ExcelHelper.Pixel2RowHeight(30);
             
                ws.Cells[2, 1].Value = sReportName;
                ws.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                using (var range = ws.Cells[2, 1, 2, rowCount])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 20;
                    range.Style.Font.Italic = false;
                    range.Style.Font.UnderLine = false;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#E9AF32"));
                    range.Style.Font.Color.SetColor(Color.White);

                    range.Style.Font.Name = "Calibri";
                    Border headerBorder = range.Style.Border;
                    headerBorder.Bottom.Style = ExcelBorderStyle.Medium;
                    headerBorder.Top.Style = ExcelBorderStyle.Medium;
                    headerBorder.Left.Style = ExcelBorderStyle.Medium;
                    headerBorder.Right.Style = ExcelBorderStyle.Medium;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                ws.Row(2).Height = ExcelHelper.Pixel2RowHeight(30);
                ws.Cells[2, 1, 2, rowCount].Merge = true;
                ws.Cells[3, 1].Value = sFilterName;
                ws.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                using (ExcelRange rng = ws.Cells[3, 1, 3, rowCount])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Font.Size = 15;
                    rng.Style.Font.Italic = false;
                    rng.Style.Font.UnderLine = false;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#382E1C"));
                    rng.Style.Font.Color.SetColor(Color.White);

                    rng.Style.Font.Name = "Calibri";
                    Border headerBorder = rng.Style.Border;
                    headerBorder.Bottom.Style = ExcelBorderStyle.Medium;
                    headerBorder.Top.Style = ExcelBorderStyle.Medium;
                    headerBorder.Left.Style = ExcelBorderStyle.Medium;
                    headerBorder.Right.Style = ExcelBorderStyle.Medium;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                ws.Row(3).Height = ExcelHelper.Pixel2RowHeight(30);
                ws.Cells[3, 1, 3, rowCount].Merge = true;

                for (int i = 0; i < rowCount; i++)
                {
                    if (i < rowCount )
                    {
                        ws.Column(i + 1).Width = int.Parse(sColumnWidths[i]);
                        ws.Cells[4, i + 1].Value = sHeaderNames[i];
                        ws.Column(i + 1).AutoFit();
                    }
                    //GetDataTypeValue(exlWS, i + 1, sDataTypes[i]);
                }
                               
                // Add some styling
                using (ExcelRange rng = ws.Cells[4, 1, 4, rowCount])
                {

                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#8F6048"));
                    rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    int j = 0;
                    if (sDataTypes != null && sDataTypes.Length>0)
                    {
                        foreach (string datatyp in sDataTypes)
                        {
                            GetDataTypeValue(ws, j + 1, sDataTypes[j]);
                            j = j + 1;
                        }
                    }


                    FileInfo ExcelFile = new FileInfo(SavedPath);
                    pck.SaveAs(ExcelFile);
                    // Save the new workbook
                    // pck.Save();
                }
                //ExcelPackage pck = new ExcelPackage();
                //ExcelWorksheet ws = pck.Workbook.Worksheets.Add("GTKReport");
                //ws.Cells["A1"].LoadFromDataTable(dtCloned, true);
                //pck.SaveAs(newFile);
            }
        }
        private static void GetCellText(string sValue, ExcelRange rng)
        {
            if (string.IsNullOrEmpty(sValue))
                sValue = string.Empty;

            var rt1 = rng.RichText.Add(sValue);

            rng.Style.Font.Bold = true;
            rng.Style.Font.Italic = false;
            rng.Style.Font.UnderLine = true;
            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
            rng.Style.Fill.BackgroundColor.SetColor(Color.White);
            rng.Style.Font.Color.SetColor(Color.Black);
            Border headerBorder = rng.Style.Border;
            headerBorder.Bottom.Style = ExcelBorderStyle.Medium;
            headerBorder.Top.Style = ExcelBorderStyle.Medium;
            headerBorder.Left.Style = ExcelBorderStyle.Medium;
            headerBorder.Right.Style = ExcelBorderStyle.Medium;

            rng.Style.WrapText = true;
            // }

        }

        private static void GetDataTypeValue(ExcelWorksheet exlWS, int colIndex, string sValue)
        {
            switch (sValue)
            {
                case "DBL":
                case "FLT":
                    {
                        exlWS.Column(colIndex).Style.Numberformat.Format = "#,##0.000000";
                        exlWS.Column(colIndex).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    break;
                case "DT":
                    exlWS.Column(colIndex).Style.Numberformat.Format = "mm/dd/yyyy";
                    break;
                case "DTM":
                    exlWS.Column(colIndex).Style.Numberformat.Format = "mm/dd/yyyy h:mm";
                    break;
                case "TM": exlWS.Column(colIndex).Style.Numberformat.Format = "h:mm";
                    break;
                case "INT":
                case "NUM":
                    {
                        exlWS.Column(colIndex).Style.Numberformat.Format = "#,##0";
                        exlWS.Column(colIndex).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    break;
                default: break;

            }

        }

        private static bool GetBoolValue(string sValue)
        {
            switch (sValue)
            {
                case "T": return true;
                case "F": return false;
                default: return false;

            }

        }
        private static void SetColumnWidths(DataTable dtHeader, ExcelWorksheet exlWS, ref int rowIndex, DataTable dtFilters)
        {
            string[] sColumnWidths = dtHeader.Select("PropType='ColumnLengths'")[0]["PropValue"].ToString().Split('|').ToArray();
            string[] sHeaderNames = dtHeader.Select("PropType='AliasNames'")[0]["PropValue"].ToString().Split('|').ToArray();
            //string[] sDataTypes = dtHeader.Select("PropType='DataTypes'")[0]["PropValue"].ToString().Split('|').Skip(1).ToArray();



            string sReportName = dtHeader.Select("PropType='LOVName'")[0]["PropValue"].ToString();
            exlWS.Name = dtHeader.Select("PropType='LOVName'")[0]["PropValue"].ToString();
            rowCount = int.Parse(dtHeader.Select("PropType='HideColFrom'")[0]["PropValue"].ToString());
            //string sFilterName = "No Filter";
            string sFilterName = string.Empty;
            if (dtFilters.Rows.Count > 0)
                sFilterName = dtFilters.Rows[0]["FilterValue"].ToString();
            int ikk = (sHeaderNames.Length - rowCount) + 1;
            exlWS.Cells[rowIndex, 1, rowIndex, sColumnWidths.Length - ikk].Merge = true;
            exlWS.Cells[rowIndex, 1, rowIndex, sColumnWidths.Length - ikk].AutoFitColumns();
            exlWS.Cells[rowIndex, 1].Value = sReportName;
            exlWS.Row(rowIndex).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            using (var range = exlWS.Cells[rowIndex, 1, rowIndex, sHeaderNames.Length - ikk])
            {
                if (rowCount > rowIndex)
                {
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 20;
                    range.Style.Font.Italic = false;
                    range.Style.Font.UnderLine = false;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#E9AF32"));
                    range.Style.Font.Color.SetColor(Color.White);

                    range.Style.Font.Name = "Calibri";
                    Border headerBorder = range.Style.Border;
                    headerBorder.Bottom.Style = ExcelBorderStyle.Medium;
                    headerBorder.Top.Style = ExcelBorderStyle.Medium;
                    headerBorder.Left.Style = ExcelBorderStyle.Medium;
                    headerBorder.Right.Style = ExcelBorderStyle.Medium;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
            }
            exlWS.Row(rowIndex).Height = ExcelHelper.Pixel2RowHeight(30);
            rowIndex++;

            exlWS.Cells[rowIndex, 1, rowIndex, sColumnWidths.Length - ikk].Merge = true;
            exlWS.Cells[rowIndex, 1, rowIndex, sColumnWidths.Length - ikk].AutoFitColumns();
            exlWS.Cells[rowIndex, 1].Value = sFilterName;
            exlWS.Row(rowIndex).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            using (var range = exlWS.Cells[rowIndex, 1, rowIndex, sHeaderNames.Length - ikk])
            {
                if (rowCount > rowIndex)
                {
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 15;
                    range.Style.Font.Italic = false;
                    range.Style.Font.UnderLine = false;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#382E1C"));
                    range.Style.Font.Color.SetColor(Color.White);

                    range.Style.Font.Name = "Calibri";
                    Border headerBorder = range.Style.Border;
                    headerBorder.Bottom.Style = ExcelBorderStyle.Medium;
                    headerBorder.Top.Style = ExcelBorderStyle.Medium;
                    headerBorder.Left.Style = ExcelBorderStyle.Medium;
                    headerBorder.Right.Style = ExcelBorderStyle.Medium;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
            }
            // exlWS.Row(rowIndex).Height = ExcelHelper.Pixel2RowHeight(30);
            rowIndex++;

            for (int i = 0; i < sColumnWidths.Length - 1; i++)
            {
                if (i < rowCount - 1)
                {
                    exlWS.Column(i + 1).Width = int.Parse(sColumnWidths[i]);
                    exlWS.Cells[rowIndex, i + 1].Value = sHeaderNames[i];
                    exlWS.Column(i + 1).AutoFit();
                }
                //GetDataTypeValue(exlWS, i + 1, sDataTypes[i]);
            }
            using (var Hdrrange = exlWS.Cells[rowIndex, 1, rowIndex, sHeaderNames.Length - ikk])
            {
                Hdrrange.Style.Font.Bold = true;
                Hdrrange.Style.Font.Italic = false;
                Hdrrange.Style.Font.UnderLine = false;
                Hdrrange.Style.Font.Size = 12;
                Hdrrange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Hdrrange.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#8F6048"));
                Hdrrange.Style.Font.Color.SetColor(Color.White);
                Hdrrange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Hdrrange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                Hdrrange.Style.Font.Name = "Calibri";
                Border hdrBorder = Hdrrange.Style.Border;
                hdrBorder.Bottom.Style = ExcelBorderStyle.Medium;
                hdrBorder.Top.Style = ExcelBorderStyle.Medium;
                hdrBorder.Left.Style = ExcelBorderStyle.Medium;
                hdrBorder.Right.Style = ExcelBorderStyle.Medium;
                //range.Style.HorizontalAlignment = HorizontalAlignment(GetSettingValue("Questionier Header", "Alignment", "Horizontal"));
                //range.Style.VerticalAlignment = VerticalAlignment(GetSettingValue("Questionier Header", "Alignment", "Vertical"));
            }
        }


        private static void CreateLineNo(ExcelWorksheet ws, int rowIndex, int sectionNo, int lineNo)
        {
            var lineCell = ws.Cells[rowIndex, 1];
            if (lineNo > 9)
                lineCell.Style.Numberformat.Format = "#,##0.00";
            else
                lineCell.Style.Numberformat.Format = "#,##0.0";
            lineCell.Value = double.Parse(string.Format("{0}.{1}", sectionNo, lineNo));
            lineCell.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
        }

        public void GenerateReportByBatch(string SavedPath, DataSet dsDetails, int PageNumber)
        {
            ExcelPackage pck;
            ExcelWorksheet ws;
            if (PageNumber == 0)
            {
                // Add a new worksheet to the empty workbook
                pck = new ExcelPackage();
                ws = pck.Workbook.Worksheets.Add("GTKReport");
            }
            else
            {
                // Open existing worksheet to write
                FileInfo newFile = new FileInfo(SavedPath);
                pck = new ExcelPackage(newFile);
                ws = pck.Workbook.Worksheets["GTKReport"];
            }

            if (dsDetails.Tables.Count > 0)
            {
                DataTable dtCloned = new DataTable();
                dtCloned = dsDetails.Tables[0];
                int ColCount = 0;
                if (dsDetails.Tables[1].Select("PropType='HideColFrom'") != null && dsDetails.Tables[1].Select("PropType='HideColFrom'").Length > 0)
                {
                    ColCount = int.Parse(dsDetails.Tables[1].Select("PropType='HideColFrom'")[0]["PropValue"].ToString());
                }

                for (int x = ColCount - 1; x < dtCloned.Columns.Count; x++)
                {
                    dtCloned.Columns.RemoveAt(x);
                }

                if (dtCloned.Columns.Contains("S.No.")) dtCloned.Columns.Remove("S.No.");
                if (dtCloned.Columns.Contains("HiddenId")) dtCloned.Columns.Remove("HiddenId");
                if (dtCloned.Columns.Contains("RecType")) dtCloned.Columns.Remove("RecType");
                if (dtCloned.Columns.Contains("RecStyle")) dtCloned.Columns.Remove("RecStyle");

                if (PageNumber == 0) DesignHeadings(dsDetails, ws);

                int startrow = ws.Dimension == null ? 0 : ws.Dimension.End.Row;
                ws.Cells.AutoFitColumns();
                ws.Cells["A" + Convert.ToString(startrow + 1)].LoadFromDataTable(dtCloned, false);
                FileInfo ExcelFile = new FileInfo(SavedPath);
                pck.SaveAs(ExcelFile);


            }
        }

        private void DesignHeadings(DataSet dsDetails, ExcelWorksheet ws)
        {
            string[] sDispDataTypes = null;
            string[] sDataTypes = null;
            int ColCount = 0;
            string[] sColumnWidths = dsDetails.Tables[1].Select("PropType='ColumnLengths'")[0]["PropValue"].ToString().Split('|').Skip(1).ToArray();
            if (dsDetails.Tables[1].Select("PropType='DataTypes'") != null && dsDetails.Tables[1].Select("PropType='DataTypes'").Length > 0)
            {
                sDataTypes = dsDetails.Tables[1].Select("PropType='DataTypes'")[0]["PropValue"].ToString().Split('|').Skip(1).ToArray();
            }
            
            if (dsDetails.Tables[1].Select("PropType='DispDataTypes'") != null && dsDetails.Tables[1].Select("PropType='DispDataTypes'").Length > 0)
            {
                sDispDataTypes = dsDetails.Tables[1].Select("PropType='DispDataTypes'")[0]["PropValue"].ToString().Split('|').Skip(1).ToArray();
            }

            string sFilterName = "No Filter";
            if (dsDetails.Tables[2].Rows.Count > 0)
                sFilterName = dsDetails.Tables[2].Rows[0]["FilterValue"].ToString();

            string sReportName = dsDetails.Tables[1].Select("PropType='LOVName'")[0]["PropValue"].ToString();
            if (dsDetails.Tables[1].Select("PropType='HideColFrom'") != null && dsDetails.Tables[1].Select("PropType='HideColFrom'").Length > 0)
            {
                ColCount = int.Parse(dsDetails.Tables[1].Select("PropType='HideColFrom'")[0]["PropValue"].ToString());
            }

            string[] sHeaderNames = dsDetails.Tables[1].Select("PropType='AliasNames'")[0]["PropValue"].ToString().Split('|').ToArray();
            var Hlist = new List<string>(sHeaderNames);
            for (int i = ColCount - 1; i < sHeaderNames.Length ; i++)
            {
                Hlist.RemoveAt(i);
            }
            Hlist.Remove("S.No.");
            Hlist.Remove("HiddenId");
            Hlist.Remove("RecType");
            Hlist.Remove("RecStyle");
            sHeaderNames = Hlist.ToArray();

            // Load data from DataTable to the worksheet           

            ws.InsertRow(1, 3);
            ws.Cells[1, 1].Value = "Report Generated Date: " + DateTime.Now.ToString();
            ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[1, 1, 1, sHeaderNames.Length].Merge = true;
            using (ExcelRange rng = ws.Cells[1, 1, 1, sHeaderNames.Length])
            {
                rng.Style.Font.Bold = true;
                rng.Style.Font.Size = 20;
                rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rng.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#E9AF32"));
                rng.Style.Font.Color.SetColor(System.Drawing.Color.White);

                rng.Style.Font.Name = "Calibri";
                Border headerBorder = rng.Style.Border;
                headerBorder.Bottom.Style = ExcelBorderStyle.Medium;
                headerBorder.Top.Style = ExcelBorderStyle.Medium;
                headerBorder.Left.Style = ExcelBorderStyle.Medium;
                headerBorder.Right.Style = ExcelBorderStyle.Medium;
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
            ws.Row(1).Height = ExcelHelper.Pixel2RowHeight(30);
            ws.Cells[1, 1, 1, sHeaderNames.Length].Merge = true;
            ws.Cells[2, 1].Value = sReportName;
            ws.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            using (var range = ws.Cells[2, 1, 2, sHeaderNames.Length])
            {
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 20;
                range.Style.Font.Italic = false;
                range.Style.Font.UnderLine = false;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#E9AF32"));
                range.Style.Font.Color.SetColor(Color.White);

                range.Style.Font.Name = "Calibri";
                Border headerBorder = range.Style.Border;
                headerBorder.Bottom.Style = ExcelBorderStyle.Medium;
                headerBorder.Top.Style = ExcelBorderStyle.Medium;
                headerBorder.Left.Style = ExcelBorderStyle.Medium;
                headerBorder.Right.Style = ExcelBorderStyle.Medium;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
            ws.Row(2).Height = ExcelHelper.Pixel2RowHeight(30);
            ws.Cells[2, 1, 2, sHeaderNames.Length].Merge = true;
            ws.Cells[3, 1].Value = sFilterName;
            ws.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            using (ExcelRange rng = ws.Cells[3, 1, 3, sHeaderNames.Length])
            {
                rng.Style.Font.Bold = true;
                rng.Style.Font.Size = 15;
                rng.Style.Font.Italic = false;
                rng.Style.Font.UnderLine = false;
                rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rng.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#382E1C"));
                rng.Style.Font.Color.SetColor(Color.White);

                rng.Style.Font.Name = "Calibri";
                Border headerBorder = rng.Style.Border;
                headerBorder.Bottom.Style = ExcelBorderStyle.Medium;
                headerBorder.Top.Style = ExcelBorderStyle.Medium;
                headerBorder.Left.Style = ExcelBorderStyle.Medium;
                headerBorder.Right.Style = ExcelBorderStyle.Medium;
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
            ws.Row(3).Height = ExcelHelper.Pixel2RowHeight(30);
            ws.Cells[3, 1, 3, sHeaderNames.Length].Merge = true;

            using (ExcelRange rng = ws.Cells[4, 1, 4, sHeaderNames.Length])
            {
                for (int i = 0; i < sHeaderNames.Length; i++)
                {
                    ws.Cells[4, i + 1].Value = sHeaderNames[i];
                }

                rng.Style.Font.Bold = true;
                rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rng.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#8F6048"));
                rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                int j = 0;
                if (sDataTypes != null && sDataTypes.Length > 0)
                {
                    foreach (string datatyp in sDataTypes)
                    {
                        GetDataTypeValue(ws, j + 1, sDataTypes[j]);
                        j = j + 1;
                    }
                }

            }
        }
    }
    public class ExcelHelper
    {
        //The correct method to convert width to pixel is:
        //Pixel =Truncate(((256 * {width} + Truncate(128/{Maximum DigitWidth}))/256)*{Maximum Digit Width})

        //The correct method to convert pixel to width is:
        //1. use the formula =Truncate(({pixels}-5)/{Maximum Digit Width} * 100+0.5)/100 
        //    to convert pixel to character number.
        //2. use the formula width = Truncate([{Number of Characters} * {Maximum Digit Width} + {5 pixel padding}]/{Maximum Digit Width}*256)/256 
        //    to convert the character number to width.

        public const int MTU_PER_PIXEL = 9525;

        public static int ColumnWidth2Pixel(ExcelWorksheet ws, double excelColumnWidth)
        {
            //The correct method to convert width to pixel is:
            //Pixel =Truncate(((256 * {width} + Truncate(128/{Maximum DigitWidth}))/256)*{Maximum Digit Width})

            //get the maximum digit width
            decimal mdw = ws.Workbook.MaxFontWidth;

            //convert width to pixel
            decimal pixels = decimal.Truncate(((256 * (decimal)excelColumnWidth + decimal.Truncate(128 / (decimal)mdw)) / 256) * mdw);
            //double columnWidthInTwips = (double)(pixels * (1440f / 96f));

            return Convert.ToInt32(pixels);

        }

        public static double Pixel2ColumnWidth(ExcelWorksheet ws, int pixels)
        {
            //The correct method to convert pixel to width is:
            //1. use the formula =Truncate(({pixels}-5)/{Maximum Digit Width} * 100+0.5)/100 
            //    to convert pixel to character number.
            //2. use the formula width = Truncate([{Number of Characters} * {Maximum Digit Width} + {5 pixel padding}]/{Maximum Digit Width}*256)/256 
            //    to convert the character number to width.

            //get the maximum digit width
            decimal mdw = ws.Workbook.MaxFontWidth;

            //convert pixel to character number
            decimal numChars = decimal.Truncate(decimal.Add((decimal)(pixels - 5) / mdw * 100, (decimal)0.5)) / 100;
            //convert the character number to width
            decimal excelColumnWidth = decimal.Truncate((decimal.Add(numChars * mdw, (decimal)5)) / mdw * 256) / 256;

            return Convert.ToDouble(excelColumnWidth);
        }

        public static int RowHeight2Pixel(double excelRowHeight)
        {
            //convert height to pixel
            decimal pixels = decimal.Truncate((decimal)(excelRowHeight / 0.75));

            return Convert.ToInt32(pixels);
        }

        public static double Pixel2RowHeight(int pixels)
        {
            //convert height to pixel
            double excelRowHeight = pixels * (double)0.75;

            return excelRowHeight;
        }

        public static int MTU2Pixel(int mtus)
        {
            //convert MTU to pixel
            decimal pixels = decimal.Truncate((decimal)(mtus / MTU_PER_PIXEL));

            return Convert.ToInt32(pixels);
        }

        public static int Pixel2MTU(int pixels)
        {
            //convert pixel to MTU
            int mtus = pixels * MTU_PER_PIXEL;

            return mtus;
        }
    }
}
