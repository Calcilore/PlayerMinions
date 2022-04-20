using Terraria.ModLoader;

namespace PlayerMinion {
	
	/*
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 *  IS NOT THE PLAYER CLASS
	 */
	
	public class PlayerMinion : Mod {

		public static ModHotKey TeleportMasterHotkey;

		public override void Load() {
			TeleportMasterHotkey = RegisterHotKey("Teleport Master", "T");
		}

		public override void Unload() {
			TeleportMasterHotkey = null;
		}
	}
}