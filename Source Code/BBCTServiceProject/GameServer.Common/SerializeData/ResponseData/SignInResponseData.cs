
using DynamicDBModel;
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SignInResponseData : ISerializeData
    {
        public Entity entities;


        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1);
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<Entity>(entities));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            byte[] bData = (byte[])data[1];
            entities = ProtoBufSerializerHelper.Handler().Deserialize<Entity>(bData);

            if (entities.equips == null)
                entities.equips = new List<UserEquip>();

            if (entities.charSouls == null)
                entities.charSouls = new List<UserCharSoul>();

            if (entities.items == null)
                entities.items = new List<UserItem>();

            if (entities.mails == null)
                entities.mails = new List<UserMail>();

            if (entities.power_up_item == null)
                entities.power_up_item = new List<UserPowerUpItem>();

            if (entities.characters == null)
                entities.characters = new List<UserCharacter>();

            if (entities.system_mails == null)
                entities.system_mails = new List<SystemMail>();

            if (entities.equip_pieces == null)
                entities.equip_pieces = new List<UserEquipPiece>();

            if (entities.indexRankLuanKiemRewarded == null)
                entities.indexRankLuanKiemRewarded = new List<int>();

            if (entities.info.vipRewarded == null)
                entities.info.vipRewarded = new List<int>();

            if (entities.index_level_rewarded == null)
                entities.index_level_rewarded = new List<int>();

            if (entities.star_rewards == null)
                entities.star_rewards = new List<UserStarReward>();
        }
    }
}
