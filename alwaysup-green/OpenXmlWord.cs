using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace alwaysup_green
{
    public static class OpenXmlWord
    {
        // 動作確認用
        private const string _fileName = @"C:\Users\Administrator\Desktop\sample.docx";

        // テキスト追加するだけ
        public static void OpenAndAddTextToWordDocument(string filepath = _fileName, string txt = "addText")
        {
            try
            {
                // Open a WordprocessingDocument for editing using the filepath.
                WordprocessingDocument wordprocessingDocument =
                    WordprocessingDocument.Open(filepath, true);

                // Assign a reference to the existing document body.
                Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

                // Add new text.
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text(txt));

                // Close the handle explicitly.
                wordprocessingDocument.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // 表を追加するだけ
        // Take the data from a two-dimensional array and build a table at the 
        // end of the supplied document.
        public static void AddTable(string fileName = _fileName)
        {
            using (var document = WordprocessingDocument.Open(fileName, true))
            {

                var doc = document.MainDocumentPart.Document;

                Table table = new Table();

                TableProperties props = new TableProperties(
                    new TableBorders(
                    new TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    }));

                table.AppendChild<TableProperties>(props);
                var data = new string[,] { { "Texas", "TX" }, { "California", "CA" }, { "New York", "NY" }, { "Massachusetts", "MA" } };
                for (var i = 0; i <= data.GetUpperBound(0); i++)
                {
                    var tr = new TableRow();
                    for (var j = 0; j <= data.GetUpperBound(1); j++)
                    {
                        var tc = new TableCell();
                        tc.Append(new Paragraph(new Run(new Text(data[i, j]))));

                        // Assume you want columns that are automatically sized.
                        tc.Append(new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Auto }));

                        tr.Append(tc);
                    }
                    table.Append(tr);
                }
                doc.Body.Append(table);
                doc.Save();
            }
        }

        // テーブルと行列を指定してテキストを置き換える
        // Change the text in a table in a word processing document.
        public static void ChangeTextInCell(string filepath = _fileName, string txt = "changed text")
        {
            // Use the file name and path passed in as an argument to 
            // open an existing document.            
            using (WordprocessingDocument doc =
                WordprocessingDocument.Open(filepath, true))
            {
                // Find the first table in the document.
                Table table =
                    doc.MainDocumentPart.Document.Body.Elements<Table>().First();

                // Find the second row in the table.
                TableRow row = table.Elements<TableRow>().ElementAt(1);

                // Find the third cell in the row.
                TableCell cell = row.Elements<TableCell>().ElementAt(1);

                // Find the first paragraph in the table cell.
                Paragraph p = cell.Elements<Paragraph>().First();

                // Find the first run in the paragraph.
                Run r = p.Elements<Run>().First();

                // Set the text for the run.
                Text t = r.Elements<Text>().First();
                t.Text = txt;
            }
        }

        // テキストを指定して置き換える
        // To search and replace content in a document part.
        public static void SearchAndReplace(string document = _fileName)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
            {
                string docText = null;
                using (System.IO.StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                Regex regexText = new Regex("Example text");
                docText = regexText.Replace(docText, "Hi Everyone!");

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }
    }
}

