namespace GameServer.Common.Enum
{
    public enum EventCode : byte
    {
        ItemMoved = 1,
        ItemSubscribed = 2,
        ItemUnsubscribed = 3,
        UpdateInterestArea = 4,
        ChatServer = 5,
        MoiRuou = 6,
        NotifyMessage = 7,
        ChangeAvatar = 8,
        BossDeath = 9,
        ChatGuild = 10,
        ForceDisconnected = 11
    }
}
