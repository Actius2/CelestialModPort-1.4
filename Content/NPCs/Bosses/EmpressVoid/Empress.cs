using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Content.NPCs.Bosses.EmpressVoid
{
    [AutoloadBossHead]
	public class Empress : ModNPC
	{
        readonly Random rnd = new();
		public float targetX = 0;
		public float targetY = 0;
		public float VMaxSpeed = 0;
		public float VMaxAccel = 0;
		public float tVel = 0;
		public float vMag = 0;
        public bool attacking = true;
        public int month = 0;
        public int attackingcounter = 0;
        public int counter3 = 0;
        public int counter4 = 0;
        public int broke1 = 0;
        public int broke2 = 0;
        public int broke12 = 0;
        public int chance = 0;


        public float Pog { get; private set; }
        public Vector2 Meinfrau { get; private set; }

        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress of the Void");
            Main.npcFrameCount[NPC.type] = 18;
        }

		public override void SetDefaults() {

            
            VMaxSpeed = 12;
			VMaxAccel = 1;
            NPC.width = 150;
            NPC.height = 200;
            AnimationType = NPCID.EnchantedSword;
            NPC.damage = 130;
            NPC.defense = 6;
            NPC.lifeMax = 200000;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 0;
			//BossBag = ItemType<MysticGrassBlock>();
		}

        private void MoveTowards(Vector2 targetPos, float maxVel = 20)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - NPC.Center);
            newVel *= Math.Min(Math.Min(Vector2.Distance(NPC.Center, targetPos) / 4, NPC.velocity.Length() + .6f), maxVel);
            NPC.velocity = newVel;
        }
        public void Attack1()
        {
            Main.NewText("1", 150, 250, 150);
        }
        public void Attack2()
        {
            Main.NewText("2", 150, 250, 150);
        }
        public void Attack3() {
            Main.NewText("3", 150, 250, 150);
            
        }
		public override void AI() {
            
            {
                Player player = Main.player[NPC.target];
                targetX = player.Center.X;
                targetY = player.Center.Y;
                Vector2 tPos;
                Vector2 tPos2;
                VMaxSpeed = 12;
                VMaxAccel = 1;
                counter3++;
                counter4++;
                float dist = Vector2.Distance(NPC.Center, Main.player[NPC.target].Center);
                tVel = dist / 20;


                //grab the counter, and make it so it generates a number 1 to 3, every 3 seconds
                
                if (attackingcounter == 30)
                {
                    broke12 = rnd.Next(1, 3);
                    attackingcounter = 0;
                }





                if (counter3 == 20)
                {
                    broke1 = rnd.Next(100, 700);
                    broke2 = rnd.Next(100, 700);
                    Main.NewText(Convert.ToString(broke1), 150, 250, 150);
                    Main.NewText(Convert.ToString(broke2), 150, 120, 250);
                    

                    counter3 = 0;
                }



                if (vMag < VMaxSpeed && vMag < tVel)
                {
                    vMag += VMaxAccel;
                }
                if (vMag > tVel)
                {
                    vMag -= VMaxAccel;
                }

                if (dist > 0)
                {
                    
                    tPos.X = targetX ;
                    tPos.Y = targetY ;

                    
                    tPos2.X = targetX - 300;
                    tPos2.Y = targetY;


                    //if npc position is greater than 90% of the tpos 
                    //if (npc.position.Y == tPos.Y)

                    //Pog = tPos.Y * 0.9f;
                    if (NPC.Distance(Main.player[NPC.target].Center) < 300)
                    {

                       Meinfrau = player.Center + new Vector2(300, 0).RotatedBy(counter4 * 0.02f);
                       MoveTowards(Meinfrau, 20);

                       //npc.velocity = npc.DirectionTo(tPos2) * 20;
                    }
                    if (NPC.Distance(Main.player[NPC.target].Center) > 300)
                    {
                        // I want it to back the fuck up here to 



                        MoveTowards(tPos2, 20);



                    }
                   // if (npc.Distance(Main.player[npc.target].Center) < 1200)
                    //{
                        //MoveTowards(tPos, 20);

                   // }
                }
                    tPos.X = targetX ;
                    tPos.Y = targetY ;

                    tPos2.X = targetX - 300;
                    tPos2.Y = targetY;


                //if npc position is greater than 90% of the tpos 
                //if (npc.position.Y == tPos.Y)

                //Pog = tPos.Y * 0.9f;

                if (dist < 1)
                {
                    VMaxSpeed = 0;
                    VMaxAccel = 0;

                }
                if (NPC.Distance(Main.player[NPC.target].Center) < 300)
                    {

                       Meinfrau = player.Center + new Vector2(300, 0).RotatedBy(counter4 * 0.02f);
                       MoveTowards(Meinfrau, 20);

                       //npc.velocity = npc.DirectionTo(tPos2) * 20;
                    }
                    if (NPC.Distance(Main.player[NPC.target].Center) > 300)
                    {
                        // I want it to back the fuck up here to 

                        

                        NPC.velocity = NPC.DirectionTo(tPos2) * 20;



                    }
                    if (NPC.Distance(Main.player[NPC.target].Center) < 1200)
                    {
                        NPC.velocity = NPC.DirectionTo(tPos) * vMag;
                        //npc.velocity = npc.DirectionTo(circling) * vMag;

                    }
                }
                               
                

                if (broke12 == 1)
                {
                    if (attacking == true)
                    {
                        Attack1();
                    }
                }
                if (broke12 == 2)
                {
                    if (attacking == true)
                    {
                    Attack2();
                    }
                }
                if (broke12 == 3)
                {
                    if (attacking == true)
                    {
                    Attack3();
                    }
                }

            }
        }
    }