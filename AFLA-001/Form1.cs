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
            PageSwitchManger.ShowPage(MainPage, userPage);
            //Userbtn_Click(Userbtn, EventArgs.Empty);

        }

        
      

        private void Homebtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, homePage);
            PageSwitchManger.ActiveButton(Homebtn);
        }
        private void Recipebtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, recipePage);
            PageSwitchManger.ActiveButton(Recipebtn);
        }
        private void Manualbtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, manualPage);
            PageSwitchManger.ActiveButton(Manualbtn);
        }
        private void Alarmbtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, alarmPage);
            PageSwitchManger.ActiveButton(Alarmbtn);
        }               
        private void Historybtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, historyPage);
            PageSwitchManger.ActiveButton(Historybtn);
        }
        private void Eventbtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, eventPage);
            PageSwitchManger.ActiveButton(Eventbtn);
        }
        private void Logbtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, logPage);
            PageSwitchManger.ActiveButton(Logbtn);
        }
        private void Userbtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, userPage);
            PageSwitchManger.ActiveButton(Userbtn);
        }
        private void Iobtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, ioPage);
            PageSwitchManger.ActiveButton(Iobtn);
        }


    }
}
