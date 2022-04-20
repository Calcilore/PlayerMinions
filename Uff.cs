using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace PlayerMinion {
    public static class Uff {
        public static void Talk(object msg, Color color) {
            string message = msg.ToString();
            
            if (Main.netMode != NetmodeID.Server) {
                Main.NewText(message, color);
            }
            else {
                NetworkText text = NetworkText.FromLiteral(message);
                NetMessage.BroadcastChatMessage(text, color);
            }
        }
        
        public static void Talk(object msg) {
            Talk(msg, Color.CornflowerBlue);
        }

        public static int FromSeconds(float seconds) {
            return (int)(seconds * 60);
        }
    }
}