//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace NeolithLib.API.Events
{
	public class PostSteamIdHasAccessEvent
	{
		public LockableObject LockableObject { get; set; }
		public ulong SteamId { get; set; }
		public bool Result { get; set; }
		public bool WasHandled { get; set; }
		public bool WasCancelled { get; set; }
		public bool Handled { get; set; }

		public PostSteamIdHasAccessEvent (LockableObject lockableObject, ulong steamId, bool result, bool wasHandled, bool wasCancelled)
		{
			this.LockableObject = lockableObject;
			this.SteamId = steamId;
			this.Result = Result;
			this.WasHandled = wasHandled;
			this.WasCancelled = wasCancelled;
			this.Handled = false;
		}
	}
}

