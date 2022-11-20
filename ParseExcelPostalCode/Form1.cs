using ClosedXML.Excel;
using ParseExcelPostalCode.models;

namespace ParseExcelPostalCode
{
    public partial class Form1 : Form
    {
        private List<IndustryJob> industryJobList;
        private List<Industry> industryList;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
            if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
            {
                string fileExt = Path.GetExtension(file.FileName); //get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    industryJobList = ExcelUtil.ImportExcel<IndustryJob>(file.FileName, "Sheet2");
                    industryJobList = ExcelUtil.FillEmptyCells(industryJobList);
                    industryJobList = ExcelUtil.SplitJobs(industryJobList);
                    dataGridView.DataSource = industryJobList;
                    btnGenerateIndustryRecords.Enabled = true;
                    MessageBox.Show(industryJobList.Count.ToString() + " records reformatted successfully!");
                }
                else
                {
                    MessageBox.Show("Please choose.xls or.xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            industryList = ExcelUtil.GenerateIndustryRecordList(industryJobList);
            dgvIndustry.DataSource = industryList;
            MessageBox.Show(industryList.Count.ToString() + " industry records generated successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}