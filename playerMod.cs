using GeraldFitzTheNPC.Buffs;
using GeraldFitzTheNPC.Items;
using GeraldFitzTheNPC.NPCs;
using GeraldFitzTheNPC.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace GeraldFitzTheNPC {
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class playerMod : ModPlayer {
		public bool dynamitePet;

		public override void ResetEffects() {
			dynamitePet = false;
		}

        //I have no clue if this is necessary (Ronan)
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)player.whoAmI);
			packet.Send(toWho, fromWho);
		}
	}
}
