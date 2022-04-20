using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace PlayerMinion {
    public class MinionPlayer : ModPlayer {
        public bool IsMinion;
        public string MasterName;
        
        public static bool IsPlayerMinion(Player player) {
            return player.GetModPlayer<MinionPlayer>().IsMinion;
        }

        private Player GetMaster() {
            Uff.Talk("Name: " + MasterName);
            
            foreach (var p in Main.player) {
                if (p.name == MasterName) return p;
            }

            return null;
        }

        public override void ResetEffects() {
            if (IsMinion) player.noBuilding = true;
        }

        public override void PostUpdate() {
            if (IsMinion) {
                player.immune = true;
                player.immuneAlpha = 0;
                player.immuneTime = 10;
                player.aggro = Int32.MinValue;

                if (PlayerMinion.TeleportMasterHotkey.JustPressed) {
                    player.Teleport(GetMaster().position);
                }
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
            ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {

            if (IsMinion) return false;
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound,
                ref genGore, ref damageSource);
        }

        public override TagCompound Save() {
            return new TagCompound() {
                {"IsMinion", IsMinion},
                {"MasterName", MasterName}
            };
        }

        public override void Load(TagCompound tag) {
            IsMinion = tag.GetBool("IsMinion");
            MasterName = tag.GetString("MasterName");
        }
    }
}