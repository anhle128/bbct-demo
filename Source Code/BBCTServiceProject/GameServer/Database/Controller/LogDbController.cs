using GameServer.Database.MainDatabaseCollection;
using GameServer.Database.SubDatataseCollection;
using MongoDB.Driver;

namespace GameServer.Database.Controller
{
    public class LogDbController
    {
        private readonly TransactionCollection _trans;
        private readonly GiftCodeLogCollection _giftCode;
        private readonly UsedGoldLogCollection _usedGold;
        private readonly UsedSilverLogCollection _usedSilver;
        private readonly LoginLogCollection _loginLog;
        private readonly UserLevelUpLogCollection _userLevelUp;
        private readonly RewardedGoldLogCollection _rewardedGold;
        private readonly ActionGoldLogCollection _actionGold;
        private readonly ChieuMoLogCollection _chieuMo;
        private readonly RequestLogCollection _request;


        public LogDbController(IMongoDatabase database)
        {
            _trans = new TransactionCollection("transactions", database);
            _giftCode = new GiftCodeLogCollection("gift_code_log", database);
            _usedGold = new UsedGoldLogCollection("used_gold_log", database);
            _usedSilver = new UsedSilverLogCollection("used_silver_log", database);
            _loginLog = new LoginLogCollection("login_log", database);
            _userLevelUp = new UserLevelUpLogCollection("level_up_log", database);
            _rewardedGold = new RewardedGoldLogCollection("rewarded_gold_log", database);
            _actionGold = new ActionGoldLogCollection("action_gold_log", database);
            _chieuMo = new ChieuMoLogCollection("chieu_mo_log", database);
            _request = new RequestLogCollection("request_log", database);

        }

        public TransactionCollection Trans
        {
            get { return _trans; }
        }

        public GiftCodeLogCollection GiftCode
        {
            get { return _giftCode; }
        }

        public UsedGoldLogCollection UsedGold
        {
            get { return _usedGold; }
        }

        public LoginLogCollection LoginLog
        {
            get { return _loginLog; }
        }

        public UserLevelUpLogCollection UserLevelUp
        {
            get { return _userLevelUp; }
        }

        public UsedSilverLogCollection UsedSilver
        {
            get { return _usedSilver; }
        }

        public RewardedGoldLogCollection RewardedGold
        {
            get { return _rewardedGold; }
        }

        public ActionGoldLogCollection ActionGold
        {
            get { return _actionGold; }
        }

        public ChieuMoLogCollection ChieuMo
        {
            get { return _chieuMo; }
        }

        public RequestLogCollection Request
        {
            get { return _request; }
        }
    }
}
