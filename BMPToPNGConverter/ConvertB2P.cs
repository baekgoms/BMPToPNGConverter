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
        //자동 생성 함수
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
            if (_isThreadStart && errorMessageBox("이미 변환 중입니다."))
                return;

            Init();
            BmpToPngStart();
        }
        //자동 생성 함수 종료
        /*--------------------------------------------------*/
        /*--------------------------------------------------*/
        //사용자 정의 함수
        private void Init()
        {
            //이전 실패 목록 삭제
            fail_listView.Items.Clear();
        }

        private void BmpToPngStart()
        {
            // 디렉토리 목록 가져오기
            string[] dirs = Directory.GetDirectories(_rootDir);
            if (errorMessageBox("하위 폴더가 존재하지 않습니다!", dirs.Length))
                return;

            stast_label.Text = "변환 중...";

            //스레드 시작
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
                //재귀함수로 하위 폴더 목록 가져오기
                FindSubFolder(_rootDir);
            }

            //완료 처리
            stast_label.BeginInvoke(new Action(() =>
            {
                stast_label.Text = "변환 완료!";
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

                    //파일이 존재하면 파일 변환
                    BmpToPngConvert(dir);

                    //하위 폴더가 있다면 다음 하위 폴더 호출
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
                //현재 디렉토리 내의 파일리스트 얻기
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

                    //해당 색상 마스크값으로 제거
                    bmpImg.MakeTransparent(Color.Black);
                    bmpImg.Save(copyFullPath, ImageFormat.Png);

                    //리소스 해제
                    bmpImg.Dispose();

                    //*.bmp 원본 삭제
                    if (originalFileName.Contains(".bmp") || originalFileName.Contains(".BMP"))
                        file.Delete();
                }
            }
            catch (Exception ex)
            {
                //하위 폴더가 없다면 bmp 파일 검색 후 변환 시작
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
        //사용자 정의 함수 종료
        /*--------------------------------------------------*/
    }
}