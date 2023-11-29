using System.Collections.Generic;

namespace CustomMovesetPack
{
    using SideLoader;
    using InstanceIDs;
    using TinyHelper;

    public class IronSword
    {
        public const string SubfolderName = "IronSword";

        //private static Item[] testItem;
        
        public static Item MakeItem()
        {
            var myitem = new SL_Weapon()
            {
                Target_ItemID = IDs.ironSwordID,
                New_ItemID = -1,
                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_Name = "iron_sword_Prefab",
                    Prefab_AssetBundle = "iron_sword",
                    Prefab_SLPack = CustomMovesetPack.ModFolderName,
                    //PositionOffset = new UnityEngine.Vector3(-0.03f, 0, 0)
                },
                SLPackName = CustomMovesetPack.ModFolderName,
                SubfolderName = SubfolderName,
            };

            myitem.ApplyTemplate();
            Item item = ResourcesPrefabManager.Instance.GetItemPrefab(myitem.New_ItemID);
            return item;
        }
    }
}
