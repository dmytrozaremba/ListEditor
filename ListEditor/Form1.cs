using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ListEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //addRows();
        }

        string fileName = string.Empty;

        //private void addRows()
        //{
        //    dgvBookList.RowCount = 16;
        //}

        //private void dgvBookList_Scroll(object sender, ScrollEventArgs e)
        //{
        //    dgvBookList.Rows.Add();
        //    foreach (DataGridViewRow row in dgvBookList.Rows)
        //    {
        //        row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
        //    }
        //}

        //private void dgvBookList_SizeChanged(object sender, EventArgs e)
        //{
        //    if (dgvBookList.RowCount < 60)
        //    {
        //        dgvBookList.RowCount = 60;
        //        foreach (DataGridViewRow row in dgvBookList.Rows)
        //        {
        //            row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
        //        }
        //    }
        //}
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dgvBookList.RowCount = 1;
                fileName = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(fileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    dgvBookList.Rows.Add();
                    string[] row = lines[i].Split(',').Select(s => s.Trim()).ToArray();
                    for (int j = 0; j < row.Length; j++)
                    {
                        if (j == 2 || j == 3)
                        {
                            dgvBookList.Rows[i].Cells[j].Value = int.Parse(row[j]);
                        }
                        else if (j == 4)
                        {
                            dgvBookList.Rows[i].Cells[j].Value = double.Parse(row[j], CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            dgvBookList.Rows[i].Cells[j].Value = row[j];
                        }
                    }
                }
            }
        }

        private void Save()
        {
            string[] tableContent = new string[dgvBookList.RowCount - 1];
            for (int i = 0; i < dgvBookList.RowCount - 1; i++)
            {
                var row = string.Empty;

                for (int j = 0; j < dgvBookList.Rows[i].Cells.Count; j++)
                {
                    var strValue = string.Empty;
                    if (j == 2 || j == 3)
                    {
                        strValue = Convert.ToInt32(dgvBookList.Rows[i].Cells[j].Value).ToString(CultureInfo.InvariantCulture);
                    }
                    else if (j == 4)
                    {
                        strValue = ((double)dgvBookList.Rows[i].Cells[j].Value).ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        strValue = dgvBookList.Rows[i].Cells[j].Value.ToString();
                    }

                    if (j == dgvBookList.Rows[i].Cells.Count - 1)
                    {
                        row = string.Concat(row, strValue);
                    }
                    else
                    {
                        row = string.Concat(row, strValue, ',');
                    }
                }

                tableContent[i] = row;
            }
            File.WriteAllLines(fileName, tableContent);
        }

        private void SaveAs()
        {
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                Save();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            var searchTerm = textBoxFilter.Text;
            for (int i = 0; i < dgvBookList.RowCount - 1; i++)
            {
                var matchesSearchTerm = false;
                for (int j = 0; j < dgvBookList.Rows[i].Cells.Count; j++)
                {
                    if (dgvBookList.Rows[i].Cells[j].Value.ToString().Contains(searchTerm))
                    {
                        matchesSearchTerm = true;
                        break;
                    }
                }
                dgvBookList.Rows[i].Visible = matchesSearchTerm;
            }
        }

        private void dgvBookList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string errorText = string.Empty;

            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int intValue))
                {
                    errorText = string.Format("{0} must be an integer", dgvBookList.Columns[e.ColumnIndex].HeaderText);
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (!double.TryParse(e.FormattedValue.ToString().Replace(',', '.'),NumberStyles.Number, CultureInfo.InvariantCulture, out double doubleValue))
                {
                    errorText = "Price must be a double";
                }
            }

            if(errorText != string.Empty)
            {
                dgvBookList.Rows[e.RowIndex].ErrorText = errorText;
                e.Cancel = true;

                MessageBox.Show(errorText, "Data Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBookList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvBookList.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dgvBookList_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                if (int.TryParse(e.Value.ToString(), out int intValue))
                {
                    e.Value = intValue;
                    e.ParsingApplied = true;
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (double.TryParse(e.Value.ToString().Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out double doubleValue))
                {
                    e.Value = doubleValue;
                    e.ParsingApplied = true;
                }
            }
        }
    }
}
