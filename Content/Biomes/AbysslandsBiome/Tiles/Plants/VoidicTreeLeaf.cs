using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialMod.Content.Biomes.AbysslandsBiome.Tiles.Plants
{
	public class VoidicTreeLeaf : ModGore
	{
		public override string Texture => "CelestialMod/Content/Biomes/AbysslandsBiome/Tiles/Plants/VoidicTree_Leaf";

		public override void SetStaticDefaults() {
			
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}
