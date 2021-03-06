namespace CustomMovesetPack
{
    using SideLoader;
    using BepInEx;
    using System;
    using InstanceIDs;
    using CustomWeaponBehaviour;

    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency(CustomWeaponBehaviour.GUID, CustomWeaponBehaviour.VERSION)]
    public class CustomMovesetPack : BaseUnityPlugin
    {
        public const string GUID = "com.ehaugw.custommovesetpack";
        public const string VERSION = "3.3.0";
        public const string NAME = "Custom Moveset Pack";

        //public const string sideloaderFolder = "CustomMovesetPack";

        internal void Awake()
        {
            SL.OnPacksLoaded += OnPackLoaded;
        }

        private void OnPackLoaded()
        {
            foreach (var tup in new Tuple<int, string[]>[] {
                new Tuple<int, string[]>(IDs.ceruleanSabreID,   new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.steelSabreID,      new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.macheteID,         new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.goldenMacheteID,   new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.marbleSwordID,     new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.marbleAxeID,       new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.oldLegionGladiusID,new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.deserKhopeshID,    new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.jadeScimitarID,    new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.tsarSwordID,       new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.wolfSwordID,       new string[]{IDs.BastardTag, IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.brutalClubID,      new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.obsidianSwordID,   new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.brutalAxeID,       new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.prayerClaymoreID,  new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.wolfAxeID,         new string[]{IDs.HolyTag}),

                new Tuple<int, string[]>(IDs.fangSwordID,       new string[]{IDs.FinesseTag}),

                new Tuple<int, string[]>(IDs.palladiumAxeID,  new string[]{IDs.BastardTag, IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumClaymoreID,  new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumGreataxeID,  new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumGreathammerID,  new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumHalberdID,  new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumKnucklesID,  new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumMaceID,  new string[]{IDs.BastardTag, IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumShieldID,  new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumSpearID,  new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumSwordID,  new string[]{IDs.BastardTag, IDs.HolyTag}),

        }) if (ResourcesPrefabManager.Instance.GetItemPrefab(tup.Item1) is Item item) CustomItems.SetItemTags(item, tup.Item2, false);
        }
    }
}