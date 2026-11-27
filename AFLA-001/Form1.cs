using System.Data;

namespace AFLA_001
{
    public partial class Form1 : Form
    {
        //直接宣告變數避免在建構子內宣告為區域變數
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
        bool isEnglish = true;//原先是中文


        private IReadOnlyList<string>? OldEventTickerMessages;//記住上次已交給事件跑馬燈的清單

        private IReadOnlyList<string>? OldAlarmTickerMessages;//記住上次已交給警告跑馬燈的清單

        internal void RefreshManualValues(double[]? values) => manualForm.RefreshEcValues(values);

        public Form1()
        {
            InitializeComponent();
            //+= 表示「訂閱事件」,當 userform 發出 LoginSucceeded 通知時，請執行右邊的方法
            //userform.LoginSucceeded += (sender, e) => Homebtn_Click(Homebtn, e);
            userform.LoginSucceeded += LoginSucceeded;
            userform.LogoutSucceeded += LogoutSucceeded;
            Userbtn_Click(Userbtn, EventArgs.Empty);
            logintxt.Text = UserSession.LoginUser;
            Recipebtn.Tag = new LanguageManger("配方", "Recipe");
            Manualbtn.Tag = new LanguageManger("手動", "Manual");
            Userbtn.Tag = new LanguageManger("使用者", "User");
            Languagebtn.Tag = new LanguageManger("中文", "Language");
            Historybtn.Tag = new LanguageManger("歷史", Historybtn.Text);
            Iobtn.Tag = new LanguageManger("接點", Iobtn.Text);
            Alarmbtn.Tag = new LanguageManger("警告", Alarmbtn.Text);
            Eventbtn.Tag = new LanguageManger("事件", Eventbtn.Text);
            Homebtn.Tag = new LanguageManger("首頁", Homebtn.Text);
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
        #region 主列Button判斷
        private void Homebtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, homeform ??= new HomeForm());
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
                if (recipeForm == null)
                {
                    recipeForm = new RecipeForm();
                    recipeForm.WriteRecipe += WriteRecipeSucceeded;
                    recipeForm.WriteRecipeData += TransferRecipe;
                }
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
                PageSwitchManger.ShowPage(MainPage, alarmForm ??= new AlarmForm());
                PageSwitchManger.ActiveButton(Alarmbtn);
                Loghelper.Userlog(UserSession.LoginUser, "切換成Alarm頁面");
            }

        }
        private void Historybtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "權限不夠不能切換History頁面");
            }
            else
            {
                PageSwitchManger.ShowPage(MainPage, historyForm ??= new HistoryForm());
                PageSwitchManger.ActiveButton(Historybtn);
                Loghelper.Userlog(UserSession.LoginUser, "切換成History頁面");
            }
        }
        private void Eventbtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "權限不夠不能切換Event頁面");
            }
            else
            {
                PageSwitchManger.ShowPage(MainPage, eventForm ??= new EventForm());
                PageSwitchManger.ActiveButton(Eventbtn);
                Loghelper.Userlog(UserSession.LoginUser, "切換成Event頁面");
            }

        }
        private void Userbtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(MainPage, userform);
            PageSwitchManger.ActiveButton(Userbtn);
            userform.ClearloginResult();
            Loghelper.Userlog(UserSession.LoginUser, "切換成User頁面");
        }
        private void Iobtn_Click(object sender, EventArgs e)
        {
            if (!_db.CheckLevel(_db.CheckRole(UserSession.LoginUser)))
            {
                Loghelper.Userlog(UserSession.LoginUser, "權限不夠不能切換Io頁面");
            }
            else
            {
                PageSwitchManger.ShowPage(MainPage, ioForm ??= new IoForm());
                PageSwitchManger.ActiveButton(Iobtn);
                Loghelper.Userlog(UserSession.LoginUser, "切換成Io頁面");
            }
        }
        
        private void Languagebtn_Click(object sender, EventArgs e)
        {
            isEnglish = !isEnglish;//互相切換

            changeLanguage();
        }
        #endregion
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
            manualForm.loadUpData();//測試上方六格用
        }

        private void TransferRecipe(object sender, RecipeAppliedEventArgs e)
        {
            (homeform ??= new HomeForm()).RecipeForm_RecipeApplied(sender, e);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private  void ticker_Tick(object sender, EventArgs e)
        {
            
            eventpanel.Advance();

            //接收ads的最新event值
            var latestEvents = AdsService.LatestEventTickerMessages;
            //ReferenceEquals:判斷兩個參數是否指向同一個物件(參數無順序問題)
            if (!ReferenceEquals(OldEventTickerMessages, latestEvents))
            {
                eventpanel.SetMessages(latestEvents.ToArray());
                OldEventTickerMessages = latestEvents;
            }
            
            var latestAlarms = AdsService.LatestAlarmTickerMessages;
            //ReferenceEquals:判斷兩個參數是否指向同一個物件(參數無順序問題)
            if (!ReferenceEquals(OldAlarmTickerMessages, latestAlarms))
            {
                alarmpanel.SetMessages(latestAlarms.ToArray());
                OldAlarmTickerMessages = latestAlarms;
            }
            alarmpanel.Advance();

        }
    }
}
