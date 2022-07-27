using System;
using CelestialMod.Content.Biomes.AbysslandsBiome.Tiles.Blocks;
using Terraria.ModLoader;

namespace CelestialMod.Common.Systems
{
	public class VoidicBiomeTileCount : ModSystem
	{
		public int VoidicTileCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts) {
			VoidicTileCount = tileCounts[ModContent.TileType<VoidicGrass>()] + tileCounts[ModContent.TileType<VoidicStone>()] + tileCounts[ModContent.TileType<VoidicMud>()];
		}
	}
}
