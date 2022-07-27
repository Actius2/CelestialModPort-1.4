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

namespace CelestialMod.Content.Biomes.AbysslandsBiome.Tiles.Blocks

{
	public class VoidicStone : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			HitSound = SoundID.Tink;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			Main.tileMerge[ModContent.TileType<VoidicStone>()][ModContent.TileType<VoidicGrass>()] = true;
			Main.tileMerge[ModContent.TileType<VoidicStone>()][ModContent.TileType<VoidicMud>()] = true;
			Main.tileMergeDirt[Type] = true;
			AddMapEntry(new Color(96, 96, 96));
			ItemDrop = ItemType<Content.Biomes.AbysslandsBiome.Items.Placeable.VoidicStoneBlock>();
		}
	}
}