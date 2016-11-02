
namespace MongoDBModel.Enum
{
    public enum GiftCodeType : byte
    {
        OnyOne, // chỉ dùng được 1 cài cùng category
        Unlimmit, // dùng được nhiều cái cùng category
        AnyoneCanUse // ai cũng có thể dùng nhưng chỉ được dùng 1 cái cùng category
    }
}
