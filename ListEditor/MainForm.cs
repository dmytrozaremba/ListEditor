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
        }

        string fileName = string.Empty;
        bool isSaved = true;


        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                var result = MessageBox.Show("Do you want to save changes?", "List Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Save();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dgvBookList.Rows.Clear();
                    fileName = openFileDialog.FileName;
                    string[] lines = File.ReadAllLines(fileName);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        dgvBookList.Rows.Add();
                        string[] line = lines[i].Split(',').Select(s => s.Trim()).ToArray();
                        for (int j = 0; j < line.Length; j++)
                        {
                            var stringValue = line[j];
                            var cell = dgvBookList[j, i];
                            switch (j)
                            {
                                case 2:
                                case 3:
                                    cell.Value = (stringValue == string.Empty) ? (int?)null : int.Parse(stringValue);
                                    break;
                                case 4:
                                    cell.Value = (stringValue == string.Empty) ? (double?)null : double.Parse(stringValue, CultureInfo.InvariantCulture);
                                    break;
                                default:
                                    cell.Value = stringValue;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void Save()
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < dgvBookList.RowCount - 1; i++)
            {
                var line = string.Empty;

                for (int j = 0; j < dgvBookList.Rows[i].Cells.Count; j++)
                {
                    string strValue;

                    var cell = dgvBookList[j, i];

                    if (cell.Value == null || cell.Value is string && string.Empty == ((string)cell.Value))
                    {
                        strValue = string.Empty;
                    }
                    else
                    {
                        switch (j)
                        {
                            case 2:
                            case 3:
                                strValue = ((int?)cell.Value)?.ToString() ?? string.Empty;
                                break;
                            case 4:
                                strValue = ((double?)cell.Value)?.ToString(CultureInfo.InvariantCulture) ?? string.Empty;
                                break;
                            default:
                                strValue = (string)cell.Value;
                                break;
                        }
                    }

                    line = string.Concat(line, (line == string.Empty ? string.Empty : ","), strValue);
                }

                lines.Add(line);
            }

            File.WriteAllLines(fileName, lines);
            isSaved = true;
        }

        private void SaveAs()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    Save();
                }
            }
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
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
                    var stringValue = dgvBookList.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                    if (stringValue.Contains(searchTerm))
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

            var stringValue = e.FormattedValue.ToString();

            switch (e.ColumnIndex)
            {
                case 2:
                case 3:
                    if (stringValue != string.Empty && !int.TryParse(stringValue, out int intValue))
                    {
                        errorText = string.Format("{0} must be an integer", dgvBookList.Columns[e.ColumnIndex].HeaderText);
                    }
                    break;
                case 4:
                    if (stringValue != string.Empty && !double.TryParse(stringValue.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out double doubleValue))
                    {
                        errorText = "Price must be a double";
                    }
                    break;
            }

            if (errorText != string.Empty)
            {
                dgvBookList.Rows[e.RowIndex].ErrorText = errorText;
                e.Cancel = true;

                MessageBox.Show(errorText, "Data Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                isSaved = false;
            }

            Console.WriteLine($"Validating [{e.ColumnIndex},{e.RowIndex}]: {e.FormattedValue}");
        }

        private void dgvBookList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvBookList.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dgvBookList_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var stringValue = e.Value.ToString();

            switch (e.ColumnIndex)
            {
                case 2:
                case 3:
                    e.Value = (stringValue == string.Empty) ? (int?)null : int.Parse(stringValue);
                    e.ParsingApplied = true;

                    break;
                case 4:
                    e.Value = (stringValue == string.Empty) ? (double?)null : double.Parse(stringValue, CultureInfo.InvariantCulture);
                    e.ParsingApplied = true;

                    break;
            }

            Console.WriteLine($"Parsing({e.ParsingApplied}) [{e.ColumnIndex},{e.RowIndex}]: {e.Value} {(e.Value == null ? "null" : e.Value.GetType().Name)}");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                var result = MessageBox.Show("Do you want to save changes?", "List Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Save();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            dgvBookList.Rows.Clear();
            isSaved = true;
        }

        private void pictureBoxFilter_Click(object sender, EventArgs e)
        {
            textBoxFilter.Focus();
        }

        private void panelFilter_Click(object sender, EventArgs e)
        {
            textBoxFilter.Focus();
        }
    }
}
