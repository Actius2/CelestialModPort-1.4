using CelestialMod;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Content.Biomes.AbysslandsBiome.Items.Placeable
{
	public class VoidicStoneBlock : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gloomstone Block");

		}

		public override void SetDefaults() {
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.Blocks.VoidicStone>();
		}
	}
}
