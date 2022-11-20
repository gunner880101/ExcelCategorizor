using ClosedXML.Excel;

namespace ParseExcelPostalCode
{
    public partial class Form1 : Form
    {
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
                    var list = ExcelUtil.ImportExcel<IndustryJob>(file.FileName, "Sheet2");
                    list = ExcelUtil.FillEmptyCells(list);
                    list = ExcelUtil.SplitJobs(list);
                    dataGridView.DataSource = list;
                    MessageBox.Show(list.Count.ToString() + " records imported successfully!");
                }
                else
                {
                    MessageBox.Show("Please choose.xls or.xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error
                }
            }
        }
    }

    public class IndustryJob
    {
        public string Industry1 { get; set; }
        public string Industry2 { get; set; }
        public string Job { get; set; }
    }
}