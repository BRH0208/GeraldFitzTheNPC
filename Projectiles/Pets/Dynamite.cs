using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GeraldFitzTheNPC.Projectiles.Pets {
	public class Dynamite : ModProjectile {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Living Dynamite"); // Automatic from .lang files
			Main.projFrames[projectile.type] = 5;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Parrot);
			aiType = ProjectileID.Parrot;
			projectile.width = 8;
			projectile.height = 24;
			drawOffsetX = -18;
			drawOriginOffsetY = -16;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.parrot = false; // Relic from aiType
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			playerMod modPlayer = player.GetModPlayer<playerMod>();
			if (player.dead) {
				modPlayer.dynamitePet = false;
			}
			if (modPlayer.dynamitePet) {
				projectile.timeLeft = 2;
			}
		}
	}
}
