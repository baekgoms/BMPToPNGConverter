using System.Drawing.Imaging;

namespace BMPToPNGConverter
{
    public partial class BMPToPNGConverter : Form
    {
        private const int MAX_THREAD_COUNT = 1;

        private string _rootDir = "";
        private bool _isThreadStart = false;
        private object _lock = new object();

        /*--------------------------------------------------*/
        //�ڵ� ���� �Լ�
        public BMPToPNGConverter()
        {
            InitializeComponent();
        }

        private void folder_select_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folder_textBox.Text = fbd.SelectedPath;
                _rootDir = fbd.SelectedPath;
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (_isThreadStart && errorMessageBox("�̹� ��ȯ ���Դϴ�."))
                return;

            Init();
            BmpToPngStart();
        }
        //�ڵ� ���� �Լ� ����
        /*--------------------------------------------------*/
        /*--------------------------------------------------*/
        //����� ���� �Լ�
        private void Init()
        {
            //���� ���� ��� ����
            fail_listView.Items.Clear();
        }

        private void BmpToPngStart()
        {
            // ���丮 ��� ��������
            string[] dirs = Directory.GetDirectories(_rootDir);
            if (errorMessageBox("���� ������ �������� �ʽ��ϴ�!", dirs.Length))
                return;

            stast_label.Text = "��ȯ ��...";

            //������ ����
            _isThreadStart = true;
            for (int i = 0; i < MAX_THREAD_COUNT; i++)
            {
                Thread worker = new Thread(BmpToPng);
                worker.Name = "bmpToPngThread_" + i;
                worker.IsBackground = true;
                worker.Start();
            }
        }

        private void BmpToPng()
        {
            lock (_lock)
            {
                //����Լ��� ���� ���� ��� ��������
                FindSubFolder(_rootDir);
            }

            //�Ϸ� ó��
            stast_label.BeginInvoke(new Action(() =>
            {
                stast_label.Text = "��ȯ �Ϸ�!";
            }));

            _isThreadStart = false;
        }

        private void FindSubFolder(string rootDir)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(rootDir);
                foreach (string dir in dirs)
                {

                    //������ �����ϸ� ���� ��ȯ
                    BmpToPngConvert(dir);

                    //���� ������ �ִٸ� ���� ���� ���� ȣ��
                    FindSubFolder(dir);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BmpToPngConvert(string dir)
        {
            string originalFileName = "";
            try
            {
                //���� ���丮 ���� ���ϸ���Ʈ ���
                DirectoryInfo di = new DirectoryInfo(dir);
                FileInfo[] files = di.GetFiles();

                if (files.Length == 0)
                    return;

                foreach (FileInfo file in files)
                {
                    originalFileName = Path.GetFileName(file.Name);
                    string fileName = Path.ChangeExtension(originalFileName, ".png");
                    string copyFullPath = dir + "/" + fileName;
                    Bitmap bmpImg = new Bitmap(dir + "/" + originalFileName);

                    //�ش� ���� ����ũ������ ����
                    bmpImg.MakeTransparent(Color.Black);
                    bmpImg.Save(copyFullPath, ImageFormat.Png);

                    //���ҽ� ����
                    bmpImg.Dispose();

                    //*.bmp ���� ����
                    if (originalFileName.Contains(".bmp") || originalFileName.Contains(".BMP"))
                        file.Delete();
                }
            }
            catch (Exception ex)
            {
                //���� ������ ���ٸ� bmp ���� �˻� �� ��ȯ ����
                if (fail_listView.InvokeRequired)
                {
                    ListViewItem lvi = new ListViewItem(dir + "/" + originalFileName);
                    lvi.ForeColor = Color.Red;
                    fail_listView.BeginInvoke(new Action(() =>
                    {
                        fail_listView.Items.Add(lvi);
                    }));
                }
            }
        }

        private bool errorMessageBox(string message, int length = 0)
        {
            if (length <= 0)
            {
                MessageBox.Show(message);
                return true;
            }
            return false;
        }
        //����� ���� �Լ� ����
        /*--------------------------------------------------*/
    }
}