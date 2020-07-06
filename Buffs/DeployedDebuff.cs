using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace GeraldFitzTheNPC.Buffs {
	public class DeployedDebuff : ModBuff {
		public override void SetDefaults() {
			// DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Deployed!");
			Description.SetDefault("While Deployed, you cannot move");
			
		}

		public override void Update(Player player, ref int buffIndex) {
			player.moveSpeed = 0.0f;
		}
	}
}
