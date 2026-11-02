namespace AFLA_001
{
    public partial class Form1 : Form
    {
        //直接宣告變數避免在建構子內宣告為區域變數
        private HomeForm homeform = new HomeForm();
        //private RecipePage recipePage;
        //private Manualpage manualPage;
        //private AlarmPage alarmPage;
        //private HistoryPage historyPage;
        //private EventPage eventPage;
        //private LogPage logPage;
        private UserForm userform = new UserForm();
        //private IoPage ioPage;

        //建立公開屬性好讓其他頁面可以傳送mainpage
        public Panel MainPanel
		{
            get { return  MainPage  ; }
        }

        public Form1()
        {
            InitializeComponent();

            Userbtn_Click(Userbtn, EventArgs.Empty);

        }

        
      

        private void Homebtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, homeform);
            PageSwitchManger.ActiveButton(Homebtn);
        }
        private void Recipebtn_Click(object sender, EventArgs e)
        {
            //PageSwitchManger.ShowPage(MainPage, recipePage);
            //PageSwitchManger.ActiveButton(Recipebtn);
        }
        private void Manualbtn_Click(object sender, EventArgs e)
        {
            //PageSwitchManger.ShowPage(MainPage, manualPage);
            //PageSwitchManger.ActiveButton(Manualbtn);
        }
        private void Alarmbtn_Click(object sender, EventArgs e)
        {
            //PageSwitchManger.ShowPage(MainPage, alarmPage);
            //PageSwitchManger.ActiveButton(Alarmbtn);
        }               
        private void Historybtn_Click(object sender, EventArgs e)
        {
            //PageSwitchManger.ShowPage(MainPage, historyPage);
            //PageSwitchManger.ActiveButton(Historybtn);
        }
        private void Eventbtn_Click(object sender, EventArgs e)
        {
            //PageSwitchManger.ShowPage(MainPage, eventPage);
            //PageSwitchManger.ActiveButton(Eventbtn);
        }
        private void Logbtn_Click(object sender, EventArgs e)
        {
            //PageSwitchManger.ShowPage(MainPage, logPage);
            //PageSwitchManger.ActiveButton(Logbtn);
        }
        private void Userbtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, userform);
            PageSwitchManger.ActiveButton(Userbtn);
        }
        private void Iobtn_Click(object sender, EventArgs e)
        {
            //PageSwitchManger.ShowPage(MainPage, ioPage);
            //PageSwitchManger.ActiveButton(Iobtn);
        }


    }
}
