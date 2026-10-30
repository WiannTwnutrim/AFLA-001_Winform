namespace AFLA_001
{
    public partial class Form1 : Form
    {
        //直接宣告變數避免在建構子內宣告為區域變數
        private HomePage homePage;
        private RecipePage recipePage;
        private Manualpage manualPage;
        private AlarmPage alarmPage;
        private HistoryPage historyPage;
        private EventPage eventPage;
        private LogPage logPage;
        private UserPage userPage;
        private IoPage ioPage;
        public Form1()
        {
            InitializeComponent();
            homePage = new HomePage();
            recipePage = new RecipePage();
            manualPage = new Manualpage();
            alarmPage = new AlarmPage();
            historyPage = new HistoryPage();
            eventPage = new EventPage();
            logPage = new LogPage();
            userPage = new UserPage();
            ioPage = new IoPage();
            SwitchPage(17);

        }

        //頁面切換
        private void ShowPage(UserControl page)
        {
            MainPage.Controls.Clear();// 清除原本顯示的頁面
            page.Dock = DockStyle.Fill;// 新頁面填滿 Panel
            MainPage.Controls.Add(page);// 加入並顯示新頁面
        }
        //多頁面切換
        private void SwitchPage(int page)
        {
            switch (page)
            {
                case 10:
                    ShowPage(homePage);
                    break;
                case 11:
                    ShowPage(recipePage);
                    break;
                case 12:
                    ShowPage(manualPage);
                    break;
                case 13:
                    ShowPage(alarmPage);
                    break;
                case 14:
                    ShowPage(historyPage);
                    break;
                case 15:
                    ShowPage(eventPage);
                    break;
                case 16:
                    ShowPage(logPage);
                    break;
                case 17:
                    ShowPage(userPage);
                    break;
                case 18:
                    ShowPage(ioPage);
                    break;
            }
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            SwitchPage(10);
        }
        private void Recipebtn_Click(object sender, EventArgs e)
        {
            SwitchPage(11);
        }
        private void Manualbtn_Click(object sender, EventArgs e)
        {
            SwitchPage(12);
        }
        private void Alarmbtn_Click(object sender, EventArgs e)
        {
            SwitchPage(13);
        }               
        private void Historybtn_Click(object sender, EventArgs e)
        {
            SwitchPage(14);
        }
        private void Eventbtn_Click(object sender, EventArgs e)
        {
            SwitchPage(15);
        }
        private void Logbtn_Click(object sender, EventArgs e)
        {
            SwitchPage(16);
        }
        private void Userbtn_Click(object sender, EventArgs e)
        {
            SwitchPage(17);
        }
        private void Iobtn_Click(object sender, EventArgs e)
        {
            SwitchPage(18);
        }


    }
}
