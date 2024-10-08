namespace CustomMovesetPack
{
    using SideLoader;
    using BepInEx;
    using System;
    using InstanceIDs;
    using CustomWeaponBehaviour;
    using TinyHelper;
    using System.IO;

    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency(TinyHelper.GUID, TinyHelper.VERSION)]
    [BepInDependency(CustomWeaponBehaviour.GUID, CustomWeaponBehaviour.VERSION)]
    public class CustomMovesetPack : BaseUnityPlugin
    {
        public const string GUID = "com.ehaugw.custommovesetpack";
        public const string VERSION = "4.0.8";
        public const string NAME = "Custom Moveset Pack";

        public static string ModFolderName = Directory.GetParent(typeof(CustomMovesetPack).Assembly.Location).Name.ToString();

        internal void Awake()
        {
            SL.OnPacksLoaded += OnPackLoaded;
        }

        private void OnPackLoaded()
        {
            IronSword.MakeItem();

            foreach (var tup in new Tuple<int, string[]>[] {
                new Tuple<int, string[]>(IDs.ironSwordID,               new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.ceruleanSabreID,           new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.steelSabreID,              new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.macheteID,                 new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.goldenMacheteID,           new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.marbleSwordID,             new string[]{IDs.BastardTag, IDs.MaulShoveTag}),
                new Tuple<int, string[]>(IDs.marbleAxeID,               new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.oldLegionGladiusID,        new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.deserKhopeshID,            new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.jadeScimitarID,            new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.tsarSwordID,               new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.wolfSwordID,               new string[]{IDs.BastardTag, IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.brutalClubID,              new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.obsidianSwordID,           new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.brutalAxeID,               new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.prayerClaymoreID,          new string[]{IDs.HolyTag, IDs.MaulShoveTag}),
                new Tuple<int, string[]>(IDs.wolfAxeID,                 new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.goldLichSwordID,           new string[]{IDs.BastardTag}),
                new Tuple<int, string[]>(IDs.fangSwordID,               new string[]{IDs.FinesseTag}),
                new Tuple<int, string[]>(IDs.virginSwordID,             new string[]{IDs.BastardTag, IDs.MaulShoveTag}),

                new Tuple<int, string[]>(IDs.palladiumAxeID,            new string[]{IDs.BastardTag, IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumClaymoreID,       new string[]{IDs.HolyTag, IDs.MaulShoveTag}),
                new Tuple<int, string[]>(IDs.palladiumGreataxeID,       new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumGreathammerID,    new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumHalberdID,        new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumKnucklesID,       new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumMaceID,           new string[]{IDs.BastardTag, IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumShieldID,         new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumSpearID,          new string[]{IDs.HolyTag}),
                new Tuple<int, string[]>(IDs.palladiumSwordID,          new string[]{IDs.BastardTag, IDs.HolyTag, IDs.MaulShoveTag}),
                //new Tuple<int, string[]>(IDs.oldLanternID,              new string[]{IDs.HandsFreeTag}),
                //new Tuple<int, string[]>(IDs.lanternOfSouldID,          new string[]{IDs.HandsFreeTag}),

                // new Tuple<int, string[]>(IDs.virginKnucklesID,          new string[]{IDs.PointyTag}),
                // new Tuple<int, string[]>(IDs.cannonPistolID,            new string[]{IDs.PointyTag}),

        }) if (ResourcesPrefabManager.Instance.GetItemPrefab(tup.Item1) is Item item) CustomItems.SetItemTags(item, TinyTagManager.GetSafeTags(tup.Item2), false);
        }
    }
}
