using CelestialMod.Content.Shaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialMod.Content.Projectiles
{
    // This Example show how to implement simple homing projectile
    // Can be tested with ExampleCustomAmmoGun
    public class M7SProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("M7SProjectile2"); // Name of the projectile. It can be appear in chat

			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		}

		// Setting the default parameters of the projectile
		// You can check most of Fields and Properties here https://github.com/tModLoader/tModLoader/wiki/Projectile-Class-Documentation
		public override void SetDefaults()
		{
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
			Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = DamageClass.Ranged; // What type of damage does this projectile affect?
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.light = 0f; // How much light emit around the projectile
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
		}

		// Custom AI
		public override void AI()
		{
			float maxDetectRadius = 400f; // The maximum radius at which a projectile can detect a target
			float projSpeed = 5f; // The speed at which the projectile moves towards the target

			// Trying to find NPC closest to the projectile
			NPC closestNPC = FindClosestNPC(maxDetectRadius);
			if (closestNPC == null)
				return;

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
			Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
			Projectile.rotation = Projectile.velocity.ToRotation();
		}

		// Finding the closest NPC to attack within maxDetectDistance range
		// If not found then returns null
		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs(max always 200)
			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				// Check if NPC able to be targeted. It means that NPC is
				// 1. active (alive)
				// 2. chaseable (e.g. not a cultist archer)
				// 3. max life bigger than 5 (e.g. not a critter)
				// 4. can take damage (e.g. moonlord core after all it's parts are downed)
				// 5. hostile (!friendly)
				// 6. not immortal (e.g. not a target dummy)
				if (target.CanBeChasedBy())
				{
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}
		
		public override bool PreDraw(ref Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1)
			{
				spriteEffects = SpriteEffects.None;
			}
			Vector2 vector46 = Projectile.position + new Vector2(Projectile.width, Projectile.height) / 2f + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition;
			Texture2D value111 = (Texture2D)ModContent.Request<Texture2D>("CelestialMod/Content/Projectiles/M7SProjectile");
			Color color31 = Color.White;
			Color color71 = Projectile.GetAlpha(color31);
			Vector2 origin19 = new Vector2(value111.Width, value111.Height) / 2f;
			float num299 = Projectile.rotation;
			Vector2 vector47 = Vector2.One * Projectile.scale;
			Rectangle? sourceRectangle2 = null;
			Vector2 scale17 = vector47 * 1.1f;
			Vector2 spinningpoint8 = new Vector2(2f * scale17.X + (float)Math.Cos(Main.GlobalTimeWrappedHourly * ((float)Math.PI)) * 3f, 0f).RotatedBy(num299 + Main.GlobalTimeWrappedHourly * ((float)Math.PI * 3f));
			for (float num307 = 0f; num307 < 1f; num307 += 1f / 6f)
			{
				Color color78 = Color.Red;
				color78.A = 0;
				Main.EntitySpriteDraw(value111, vector46 + spinningpoint8.RotatedBy(num307 * ((float)Math.PI * 2f)), null, color78, num299, origin19, scale17, spriteEffects, 0);
			}
			Main.EntitySpriteDraw(value111, vector46, null, color71, num299, origin19, vector47, spriteEffects, 0);
			default(Waves).Draw(Projectile);

			return false;
		}
	}
}