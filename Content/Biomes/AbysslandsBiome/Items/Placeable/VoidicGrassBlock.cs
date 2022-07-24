using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using CelestialMod.Content;
using CelestialMod.Content.Biomes.AbysslandsBiome.Tiles.Blocks;

namespace CelestialMod.Content.Biomes.AbysslandsBiome.Items.Placeable
{
	public class VoidicGrassBlock : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Acidic Dirt Block");

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
			Item.createTile = TileType<Tiles.Blocks.VoidicGrass>();
		}
	}
}
