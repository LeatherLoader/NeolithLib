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
	public class PreTakeDamageEvent
	{
		public TakeDamage Target { get; set; }
		public DamageEvent DamageEvent { get; set; }
		public bool Cancelled { get; set; }
		public bool Handled { get; set; }

		public PreTakeDamageEvent (TakeDamage target, DamageEvent dmgEvent)
		{
			this.Target = target;
			this.DamageEvent = dmgEvent;
			this.Cancelled = false;
			this.Handled = false;
		}
	}
}
