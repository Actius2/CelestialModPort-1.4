using CelestialMod.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace CelestialMod.Content.WorldGeneration.BackgroundStyles.Abysslands
{
    // Shows setting up two basic biomes. For a more complicated example, please request.
    public class VoidicSurfaceBiome : ModBiome
	{
		// Select all the scenery
		public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("CelestialMod/VoidWaterStyle"); // Sets a water style for when inside this biome
		public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("CelestialMod/VoidicSurfaceBackgroundStyle");

		// Select Music
		public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/VoidMusic");

		// Populate the Bestiary Filter
		public override string BestiaryIcon => base.BestiaryIcon;
		public override string BackgroundPath => base.BackgroundPath;
		public override Color? BackgroundColor => base.BackgroundColor;
		public override string MapBackground => BackgroundPath; // Re-uses Bestiary Background for Map Background

		// Use SetStaticDefaults to assign the display name
		public override void SetStaticDefaults() {
			// This translation is set in localization files
			// DisplayName.SetDefault("Example Surface");
		}

		public override void SpecialVisuals(Player player, bool isActive)
		{
			if (isActive)
				player.ManageSpecialBiomeVisuals("CelestialMod:VoidSky", isActive, player.Center);
		}
		public override void OnLeave(Player player)
		{
			player.ManageSpecialBiomeVisuals("CelestialMod:VoidSky", false, player.Center);
		}



		// Calculate when the biome is active.
		public override bool IsBiomeActive(Player player) {
			// First, we will use the exampleBlockCount from our added ModSystem for our first custom condition
			bool b1 = ModContent.GetInstance<VoidicBiomeTileCount>().VoidicTileCount >= 40;

			// Second, we will limit this biome to the inner horizontal third of the map as our second custom condition
			bool b2 = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2) < Main.maxTilesX / 6;

			// Finally, we will limit the height at which this biome can be active to above ground (ie sky and surface). Most (if not all) surface biomes will use this condition.
			bool b3 = player.ZoneSkyHeight || player.ZoneOverworldHeight;
			return b1 && b2 && b3;
		}
	}
}
