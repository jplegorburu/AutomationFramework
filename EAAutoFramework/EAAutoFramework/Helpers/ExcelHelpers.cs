using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;

namespace EAAutoFramework.Helpers
{
    public class ExcelHelpers
    {
        private static List<Datacollection> _dataCol = new List<Datacollection>();

        /// <summary>
        /// Storing all the excel values in to the InMemory Collection
        /// </summary>
        /// <param name="fileName">File name.</param>
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through rows and collumns of table
            for (int row = 1; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    _dataCol.Add(dtTable);
                }
            }
        }

        /// <summary>
        /// Reading all the data form Excel sheet
        /// </summary>
        /// <returns>The to data table.</returns>
        /// <param name="fileName">File name.</param>
        private static DataTable ExcelToDataTable(string fileName)
        {
            // Open File and returns a Stream
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                //CreateReader via ExcelReaderFactory
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    //Return as DataSet
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable =(data)=> new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    // Get all the tables
                    DataTableCollection table = result.Tables;
                    //Store it in DataTable
                    DataTable resultTable = table["Sheet1"];

                    return resultTable;
                }
            }

        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}
