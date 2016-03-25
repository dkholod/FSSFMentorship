namespace SimpleEditor
{
    using System;
    using System.Windows.Forms;

    using SimpleEditor.Services;

    public partial class MainForm : Form
    {
        private readonly IStorageService _service;

        public MainForm(IStorageService service)
        {
            _service = service;
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _service.Save(this.tbx_Text.Text);
            this.lbxLog.Items.Add("Save");
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            this.tbx_Text.Text = _service.Load();
            this.lbxLog.Items.Add("Reload");
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.lbxLog.Items.Clear();
        }
    }
}