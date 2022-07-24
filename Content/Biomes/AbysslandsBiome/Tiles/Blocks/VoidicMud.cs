using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Content.Biomes.AbysslandsBiome.Tiles.Blocks
{
	public class VoidicMud : ModTile
	{
		public override void SetStaticDefaults() {
			
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			Main.tileMerge[ModContent.TileType<CelestialRemnantsTempleTile>()][ModContent.TileType<VoidicGrass>()] = true;
			Main.tileMerge[ModContent.TileType<CelestialRemnantsTempleTile>()][ModContent.TileType<VoidicStone>()] = true;
			Main.tileMergeDirt[Type] = true;
			AddMapEntry(new Color(86, 60, 58));
			ItemDrop = ItemType<Content.Biomes.AbysslandsBiome.Items.Placeable.VoidicMudBlock>();
		}
	}
}