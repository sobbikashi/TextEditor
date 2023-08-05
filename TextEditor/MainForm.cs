using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextEditor

{
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSybmolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            btnOpenfile.Click += new EventHandler(btnOpenfile_Click);
            btnSaveFile.Click += btnSaveFile_Click;
            fldContent.TextChanged += tbContent_TextChanged;
            btnSelectFile.Click += btnSelectFile_Click;
            numFont.ValueChanged += numFont_ValueChanged;
        }
        #region Проброс событий
        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnOpenfile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }

        private void tbContent_TextChanged(object sender, EventArgs e)
        {
            if(ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        }
        #endregion



        #region Реализация интерфейса IMainForm 
        public string FilePath
        {
            get { return tbChooseFile.Text; }
        }

        public string Content
        {
            get { return fldContent.Text; }
            set { fldContent.Text = value; }
        }        

        public void SetSybmolCount(int count)
        {
            lbSymbolCount.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;
        #endregion

         

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файты | *.txt | Все файлы| *.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbChooseFile.Text = dlg.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        private void numFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.Font = new Font("Calibri", (float)numFont.Value);
        }
    }
}
