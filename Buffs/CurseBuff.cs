using PlayerMinion;
using Terraria;
using Terraria.ModLoader;

namespace PlayerMinion.Buffs {
    class CurseBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Minions Curse");
            Description.SetDefault("allows you to use teleport to your master at any time\nEnemies wont target you\nYou cannot take damage");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;

            base.SetDefaults();
        }

        public override bool ReApply(Player player, int time, int buffIndex) { // when reapplying just remove
            player.buffTime[buffIndex] = -1;
            player.GetModPlayer<MinionPlayer>().IsMinion = false;

            return true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MinionPlayer>().IsMinion = true;

            base.Update(player, ref buffIndex);
        }
    }
}
