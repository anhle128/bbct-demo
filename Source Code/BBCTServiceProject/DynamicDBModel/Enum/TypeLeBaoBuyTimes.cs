
namespace DynamicDBModel.Enum
{
    public enum TypeLeBaoBuyTimes : int
    {
        OnlyOne, // chỉ mua được 1 lần duy nhất
        Manytimes, // nhiều lần nhưng có giới hạn
        ManytimesWithVip // nhiều lần và giới hạn theo cấp vip
    }
}
