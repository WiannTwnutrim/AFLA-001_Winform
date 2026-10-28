namespace AFLA_001
{
    public partial class Form1 : Form
    {
        private HomePage homePage;//直接宣告變數避免在建構子內宣告為區域變數
        private RecipePage recipePage;
        private Manualpage manualPage;
        private AlarmPage alarmPage;
        public Form1()
        {
            InitializeComponent();
            homePage = new HomePage();
            recipePage = new RecipePage();
            manualPage = new Manualpage();
            alarmPage = new AlarmPage();
            SwitchPage(10);

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
                    ShowPage(homePage);
                    break;
                case 15:
                    ShowPage(homePage);
                    break;
                case 16:
                    ShowPage(homePage);
                    break;
                case 18:
                    ShowPage(homePage);
                    break;
            }
        }

        //頁面切換
        private void ShowPage(UserControl page)
        {
            MainPage.Controls.Clear();// 清除原本顯示的頁面
            page.Dock = DockStyle.Fill;// 新頁面填滿 Panel
            MainPage.Controls.Add(page);// 加入並顯示新頁面
        }

       
    }
}
