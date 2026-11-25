using System.Data;

namespace AFLA_001
{
    public partial class Form1 : Form
    {
        //钡跑计磷篶ず跋办跑计
        private HomeForm? homeform;
        private RecipeForm? recipeForm;
        private ManualForm manualForm = new ManualForm();
        private AlarmForm? alarmForm;
        private HistoryForm? historyForm;
        private EventForm? eventForm;
        //private LogPage logPage;
        private UserForm userform = new UserForm();
        private IoForm? ioForm;
        private Sqllite _db = new Sqllite();
        bool isEnglish = true;//琌いゅ

        private bool loadingTicker;
        private long nextTickerRefresh;

        internal void RefreshManualValues(double[]? values) => manualForm.RefreshEcValues(values);

        public Form1()
        {
            InitializeComponent();
            //+= ボ璹綷ㄆン,讽 userform 祇 LoginSucceeded 硄叫磅︽娩よ猭
            //userform.LoginSucceeded += (sender, e) => Homebtn_Click(Homebtn, e);
            userform.LoginSucceeded += LoginSucceeded;
            userform.LogoutSucceeded += LogoutSucceeded;
            Userbtn_Click(Userbtn, EventArgs.Empty);
            logintxt.Text = UserSession.LoginUser;
            Recipebtn.Tag = new LanguageManger("皌よ", "Recipe");
            Manualbtn.Tag = new LanguageManger("も笆", "Manual");
            Userbtn.Tag = new LanguageManger("ㄏノ", "User");
            Languagebtn.Tag = new LanguageManger("いゅ", "Language");
            Historybtn.Tag = new LanguageManger("菌", Historybtn.Text);
            Iobtn.Tag = new LanguageManger("钡翴", Iobtn.Text);
            Alarmbtn.Tag = new LanguageManger("牡", Alarmbtn.Text);
            Eventbtn.Tag = new LanguageManger("ㄆン", Eventbtn.Text);
            Homebtn.Tag = new LanguageManger("", Homebtn.Text);
            ticker.Start();
           
        }

        private void LoginSucceeded(object sender, EventArgs e)
        {
            logintxt.Text = UserSession.LoginUser;
            Homebtn_Click(Homebtn, e);
        }
        private void LogoutSucceeded(object sender, EventArgs e)
        {
            logintxt.Text = UserSession.LoginUser;
        }
        private void WriteRecipeSucceeded(object sender, EventArgs e)
        {
            showrecipetxt.Text = UserSession.WritedRecipe;
        }
        private void Homebtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, homeform ??= new HomeForm());
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
                if (recipeForm == null)
                {
                    recipeForm = new RecipeForm();
                    recipeForm.WriteRecipe += WriteRecipeSucceeded;
                    recipeForm.WriteRecipeData += TransferRecipe;
                }
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
                PageSwitchManger.ShowPage(MainPage, alarmForm ??= new AlarmForm());
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
                PageSwitchManger.ShowPage(MainPage, historyForm ??= new HistoryForm());
                PageSwitchManger.ActiveButton(Historybtn);
                Loghelper.Userlog(UserSession.LoginUser, "ち传ΘHistory");
            }
        }
        private void Eventbtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "舦ぃ镑ぃち传Event");
            }
            else
            {
                PageSwitchManger.ShowPage(MainPage, eventForm ??= new EventForm());
                PageSwitchManger.ActiveButton(Eventbtn);
                Loghelper.Userlog(UserSession.LoginUser, "ち传ΘEvent");
            }

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
                PageSwitchManger.ShowPage(MainPage, ioForm ??= new IoForm());
                PageSwitchManger.ActiveButton(Iobtn);
                Loghelper.Userlog(UserSession.LoginUser, "ち传ΘIo");
            }
        }
        private void Languagebtn_Click(object sender, EventArgs e)
        {
            isEnglish = !isEnglish;//がち传

            changeLanguage();
        }

        public void SetButton(Button button)
        {

            LanguageManger text = (LanguageManger)button.Tag;

            if (text == null)
            {
                return;
            }
            if (isEnglish)
            {
                button.Text = text.English;
            }
            else
            {
                button.Text = text.Taiwan;
            }

        }
        public void changeLanguage()
        {
            SetButton(Historybtn);
            SetButton(Userbtn);
            SetButton(Recipebtn);
            SetButton(Languagebtn);
            SetButton(Alarmbtn);
            SetButton(Homebtn);
            SetButton(Iobtn);
            SetButton(Eventbtn);
            SetButton(Manualbtn);
        }

        private void nowtime_Tick(object sender, EventArgs e)
        {
            nowtxt.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            manualForm.loadUpData();//代刚よせノ
        }

        private void TransferRecipe(object sender, RecipeAppliedEventArgs e)
        {
            (homeform ??= new HomeForm()).RecipeForm_RecipeApplied(sender, e);
        }

        private static string[] ReadTickerMessages(DataTable rows, string messageColumn)
        {
            using (rows)
            {
                return rows.Rows.Cast<DataRow>()
                    .Select(row => $"{row["TriggerTime"]} {row[messageColumn]}")
                    .ToArray();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void ticker_Tick(object sender, EventArgs e)
        {
            alarmpanel.Advance();
            eventpanel.Advance();
            if (loadingTicker || Environment.TickCount64 < nextTickerRefresh)
                return;

            loadingTicker = true;
            try
            {
                var (alarms, events) = await Task.Run(() =>
                    (ReadTickerMessages(_db.LoadAlarm(3), "Alarm"),
                     ReadTickerMessages(_db.LoadEvent(3), "Event")));
                if (!IsDisposed)
                {
                    alarmpanel.SetMessages(alarms);
                    eventpanel.SetMessages(events);
                }
            }
            finally
            {
                nextTickerRefresh = Environment.TickCount64 + 3000;
                loadingTicker = false;
            }
        }
    }
}
