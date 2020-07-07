using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace GeraldFitzTheNPC.Projectiles
{
	public class MortarProjectile : ModProjectile
	{
		int c = 0;
		float startY;
		float startX;
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Morar Shell");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 15;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}
		
		public override void SetDefaults() {
			projectile.width = 8;               //The width of projectile hitbox
			projectile.height = 8;              //The height of projectile hitbox
			projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 3600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 0.1f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 5;            //Set to above 0 if you want the projectile to update multiple time in a frame
			aiType = ProjectileID.Bullet;           //Act exactly like default Bullet
		}
		public override void AI(){
			
			float spacing = 5.0f;
			float circle = 500.0f;
			if(c == 0){
				if(projectile.ai[1] < projectile.position.X){
					circle = projectile.position.X - projectile.ai[1];
				}else{
					circle =  projectile.ai[1] - projectile.position.X;
				}
				circle = circle / 10;
			}
			
			if(projectile.position.Y < 50){
				c = (int) (circle+spacing)+1;
				Main.NewText(c);
				projectile.position.X = projectile.ai[1];
			}
			projectile.velocity.X = 0;
			c++;
			if(c < spacing){
				projectile.velocity.Y = -1-Main.rand.Next(20);
			}else if(c <= spacing+circle){
				if(c == spacing){
					startY = projectile.position.Y;
					startX = projectile.position.X;
				}
				projectile.rotation = -(10.0f/3.0f)* (float) Math.PI * (float) Math.Sin((1.0f/600.0f) * (float) Math.PI * (c - 310.0f));
				//Main.NewText(projectile.ai[1]);
				projectile.velocity.Y = 0;
				//Main.NewText((((((float) c)-100.0f)/600.0f)*(projectile.ai[1]-startX)));
				//Main.NewText((2.0f*(float) Math.Cos((((c-100.0f)/600.0f)-(float)(1/2))*Math.PI)));
				//Main.NewText("("+startX+","+startY+")");
				//Main.NewText(((c-(spacing))/(circle))-(float)(1/2));
				projectile.position.Y = startY-(5000.0f*(float) Math.Cos((((c-(spacing))/(circle))-(float)(1.0f/2.0f))*Math.PI));
				projectile.position.X = startX+(((((float) c)-(spacing))/(circle))*(projectile.ai[1]-startX));
			}else if(c > circle + spacing){
				projectile.velocity.Y = 5;
			}
			
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			//Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++) {
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}