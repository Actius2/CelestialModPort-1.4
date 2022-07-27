using Terraria.ModLoader;

namespace CelestialMod.Content.WorldGeneration.BackgroundStyles.Abysslands
{
	public class VoidicUndergroundBackgroundStyle : ModUndergroundBackgroundStyle
	{
		public override void FillTextureArray(int[] textureSlots) {
			textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/Underground/VoidicBiomeUnderground");
			textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/Underground/VoidicBiomeUnderground1");
			textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/Underground/VoidicBiomeUnderground2");
			textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/Underground/VoidicBiomeUnderground3");
		}
	}
}