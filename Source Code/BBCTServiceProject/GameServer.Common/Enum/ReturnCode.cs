﻿namespace GameServer.Common.Enum
{
    public enum ReturnCode : short
    {
        OK,
        WorldNotFound,
        StateInvalid,
        MaxConnection,
        DBError,
        FirstSignin,
        AccountExist,
        AccountDoNotExist,
        Error,
        DoesNotEnoughItem,
        LackOfRequirement,
        PromotionIsMax,
        PointEnergyIsMax,
        InvalidSlot,
        MaxLevel,
        InvalidUpPoint,
        NotEnoughSliver,
        NotEnoughGold,
        MaxPointCanUp,
        InvalidData,
        PowerUpIsMax,
        StarLevelIsMax,
        DurabilityIsMax,
        SkillIsMax,
        StarIsMax,
        MaxResetTimes,
        DoesNotEnoughStamina,
        MaxAttackTimes,
        AlreadyReceived,
        AlreadyDone,
        InvalidStage,
        UserLogined,
        CharacterExisted,
        GiftCodeNotForThisServer,
        GiftCodeBeUsed,
        CategoryGiftCodeBeUsed,
        ExceptionError,
        MaxMoiRuouTmies,
        MaxFriends,
        FriendExist,
        InvalidTime,
        InvalidItem,
        AlreadyDoneBefore,
        MaxTimesCanBuy,
        MaxStar,
        OperationCodeError,
        MaxVanTieuTimes,
        MaxCuopTieuTimes,
        EndVanTieu,
        LevelNotEnough,
        MaxDoPhuongTimes,
        MaxCauCaTimes,
        RankChanged,
        NotEnoughPoint,
        IsMasterAGuild,
        IsMemberInGuild,
        NameGuildExist,
        MemberLockGuild,
        RequestedJoinThisGuild,
        NotHavePermission,
        IsNotMemberInGuild,
        MaxMember,
        NotEnoughContribution,
        ExistMember,
        MaxLuaTraiTimes,
        AccountLocked,
        ReloadThanThap,
        MaxReceived,
        CannotSellOnMarket,
        OutOfStock,
        CannotLessBasePrice,
        MaxAmountItemCanSell,
        MaxMailCanSend,
        ServerNotReady,
        NotEnoughRuby,
        DoNotHaveConfig,
        NumberCharInFormationIsWrong,
        MaxExchangeTimes,
        ItemsBought,
        WrongGiftCode,
        DoNotHaveTrans,
        IsMaxRequestJoin,
        MaxHuaNguyenTimes,
        CharInFormation,
        InvalidChar,
        InvalidNumCharInMainFormation,
        MaxPowerupLevel,
        PowerupNotEnough
    }
}
