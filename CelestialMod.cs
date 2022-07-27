
using CelestialMod.Content.SkyShader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace CelestialMod
{
	public class CelestialMod : Mod
	{
        public override void Load()
        {
            VoidSky VSky = new VoidSky();
            Filters.Scene["CelestialMod:VoidSky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.25f, 0.1f, 0.01f).UseOpacity(0.5f), EffectPriority.VeryHigh);
            SkyManager.Instance["CelestialMod:VoidSky"] = VSky;
        }
    }
}