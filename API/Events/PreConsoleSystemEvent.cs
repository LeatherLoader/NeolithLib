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


namespace NeolithLib
{
	public class PreConsoleSystemEvent
	{
		public ConsoleSystem.Arg Argument { get; set; }
		public bool IsCancelled { get; set; }
		public bool IsHandled { get; set; }

		public PreConsoleSystemEvent (ConsoleSystem.Arg arg)
		{
			this.Argument = arg;
		}
	}
}
