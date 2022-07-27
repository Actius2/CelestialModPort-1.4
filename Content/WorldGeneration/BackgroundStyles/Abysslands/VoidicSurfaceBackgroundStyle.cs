using Terraria.ModLoader;

namespace CelestialMod.Content.WorldGeneration.BackgroundStyles.Abysslands
{
	public class VoidicSurfaceBackgroundStyle : ModSurfaceBackgroundStyle
	{
		// Use this to keep far Backgrounds like the mountains.
		public override void ModifyFarFades(float[] fades, float transitionSpeed) {
			for (int i = 0; i < fades.Length; i++) {
				if (i == Slot) {
					fades[i] += transitionSpeed;
					if (fades[i] > 1f) {
						fades[i] = 1f;
					}
				}
				else {
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f) {
						fades[i] = 0f;
					}
				}
			}
		}

		public override int ChooseFarTexture() {
			return BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/VoidicBiomeSurfaceFar");
		}

		private static int SurfaceFrameCounter;
		private static int SurfaceFrame;
		public override int ChooseMiddleTexture() {
			if (++SurfaceFrameCounter > 12) {
				SurfaceFrame = (SurfaceFrame + 1) % 4;
				SurfaceFrameCounter = 0;
			}
            return SurfaceFrame switch
            {
                0 => BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/VoidicBiomeSurfaceMid"),
                1 => BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/VoidicBiomeSurfaceMid1"),
                2 => BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/VoidicBiomeSurfaceMid2"),
                3 => BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/VoidicBiomeSurfaceMid3"),// You can use the full path version of GetBackgroundSlot too
                _ => -1,
            };
        }

		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b) {
			return BackgroundTextureLoader.GetBackgroundSlot("CelestialMod/Content/WorldGeneration/Backgrounds/Abysslands/VoidicBiomeSurfaceClose");
		}
	}
}

