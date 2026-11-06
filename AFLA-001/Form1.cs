namespace AFLA_001
{
    public partial class Form1 : Form
    {
        //钡跑计磷篶ず跋办跑计
        private HomeForm homeform = new HomeForm();
        private RecipeForm recipeForm = new RecipeForm();
        private ManualForm manualForm = new ManualForm();
        private AlarmForm alarmForm = new AlarmForm();
        private HistoryForm historyForm = new HistoryForm();
        //private EventPage eventPage;
        //private LogPage logPage;
        private UserForm userform = new UserForm();
        private IoForm ioForm = new IoForm();
        private Sqllite _db = new Sqllite();
        

        public Form1()
        {
            InitializeComponent();
            //+= ボ璹綷ㄆン,讽 userform 祇 LoginSucceeded 硄叫磅︽娩よ猭
            //userform.LoginSucceeded += (sender, e) => Homebtn_Click(Homebtn, e);
            userform.LoginSucceeded += LoginSucceeded;
            userform.LogoutSucceeded += LogoutSucceeded;
            Userbtn_Click(Userbtn, EventArgs.Empty);
            logintxt.Text = UserSession.LoginUser;
            recipeForm.WriteRecipe += WriteRecipeSucceeded;

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

        private void WriteRecipeSucceeded(object sender,EventArgs e)
        {
            showrecipetxt.Text = UserSession.WritedRecipe;
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
             Loghelper.Userlog(UserSession.LoginUser, "舦ぃ镑ぃち传Recipe");
            }
            else
            {
            PageSwitchManger.ShowPage(MainPage, recipeForm);
            PageSwitchManger.ActiveButton(Recipebtn);
            Loghelper.Userlog(UserSession.LoginUser, "ち传ΘRecipe");
            }
            
        }
        private void Manualbtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "舦ぃ镑ぃち传Recipe");
            }
            else
            {
            PageSwitchManger.ShowPage(MainPage, manualForm);
            PageSwitchManger.ActiveButton(Manualbtn);
            Loghelper.Userlog(UserSession.LoginUser, "ち传ΘManual");
            }
            
        }
        private void Alarmbtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "舦ぃ镑ぃち传Alarm");
            }
            else
            {
                PageSwitchManger.ShowPage(MainPage, alarmForm);
                PageSwitchManger.ActiveButton(Alarmbtn);
                Loghelper.Userlog(UserSession.LoginUser, "ち传ΘAlarm");
            }
            
        }               
        private void Historybtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "舦ぃ镑ぃち传History");
            }
            else
            {
                PageSwitchManger.ShowPage(MainPage, historyForm);
                PageSwitchManger.ActiveButton(Historybtn);
                Loghelper.Userlog(UserSession.LoginUser, "ち传ΘHistory");
            }            
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
            Loghelper.Userlog(UserSession.LoginUser, "ち传ΘUser");
        }
        private void Iobtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "舦ぃ镑ぃち传Io");
            }
            else
            {
                PageSwitchManger.ShowPage(MainPage, ioForm);
                PageSwitchManger.ActiveButton(Iobtn);
                Loghelper.Userlog(UserSession.LoginUser, "ち传ΘIo");
            }
        }


    }
}
