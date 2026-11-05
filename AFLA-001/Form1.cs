namespace AFLA_001
{
    public partial class Form1 : Form
    {
        //直接宣告變數避免在建構子內宣告為區域變數
        private HomeForm homeform = new HomeForm();
        private RecipeForm recipeForm = new RecipeForm();
        private ManualForm manualForm = new ManualForm();
        private AlarmForm alarmForm = new AlarmForm();
        //private HistoryPage historyPage;
        //private EventPage eventPage;
        //private LogPage logPage;
        private UserForm userform = new UserForm();
        //private IoPage ioPage;
        private Sqllite _db = new Sqllite();
        

        public Form1()
        {
            InitializeComponent();
            //+= 表示「訂閱事件」,當 userform 發出 LoginSucceeded 通知時，請執行右邊的方法
            //userform.LoginSucceeded += (sender, e) => Homebtn_Click(Homebtn, e);
            userform.LoginSucceeded += LoginSucceeded;
            userform.LogoutSucceeded += LogoutSucceeded;
            Userbtn_Click(Userbtn, EventArgs.Empty);
            logintxt.Text = UserSession.LoginUser;

        }

        private void LoginSucceeded(object sender, EventArgs e)
        {
            logintxt.Text = UserSession.LoginUser;
            Homebtn_Click(Homebtn,e);
        }
      
        private void LogoutSucceeded(object sender,EventArgs e)
        {
            logintxt.Text = UserSession.LoginUser;
        }
        private void Homebtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, homeform);
            PageSwitchManger.ActiveButton(Homebtn);
        }
        private void Recipebtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
             Loghelper.Userlog(UserSession.LoginUser, "權限不夠不能切換Recipe頁面");
            }
            else
            {
            PageSwitchManger.ShowPage(MainPage, recipeForm);
            PageSwitchManger.ActiveButton(Recipebtn);
            Loghelper.Userlog(UserSession.LoginUser, "切換成Recipe頁面");
            }
            
        }
        private void Manualbtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "權限不夠不能切換Recipe頁面");
            }
            else
            {
            PageSwitchManger.ShowPage(MainPage, manualForm);
            PageSwitchManger.ActiveButton(Manualbtn);
            Loghelper.Userlog(UserSession.LoginUser, "切換成Manual頁面");
            }
            
        }
        private void Alarmbtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "權限不夠不能切換Alarm頁面");
            }
            else
            {
                PageSwitchManger.ShowPage(MainPage, alarmForm);
                PageSwitchManger.ActiveButton(Alarmbtn);
                Loghelper.Userlog(UserSession.LoginUser, "切換成Alarm頁面");
            }
            
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
            userform.ClearloginResult();
        }
        private void Iobtn_Click(object sender, EventArgs e)
        {
            //PageSwitchManger.ShowPage(MainPage, ioPage);
            //PageSwitchManger.ActiveButton(Iobtn);
        }


    }
}
