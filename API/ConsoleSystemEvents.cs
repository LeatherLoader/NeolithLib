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
using System.Reflection;
using NeolithLib.Bootstrapper;
using NeolithLib.API.Events;

namespace NeolithLib.API
{
	[Bootstrap]
	public class ConsoleSystemEvents : Facepunch.MonoBehaviour
	{
		private static ConsoleSystemEvents mInstance = null;

		public ConsoleSystemEvents() 
		{
			ConsoleSystemEvents.mInstance = this;
		}

		public void Awake()
		{
			DontDestroyOnLoad (this.gameObject);
		}

		public static void InvokeConsoleSystem(MethodInfo methodToInvoke, object[] parameters)
		{
			ConsoleSystem.Arg arguments = (ConsoleSystem.Arg)parameters [0];

			PreConsoleSystemEvent preEvent = new PreConsoleSystemEvent (arguments);
			ConsoleSystemEvents.mInstance.gameObject.SendMessage ("PreConsoleSystemCommand", preEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);

			parameters[0] = preEvent.Argument;

			if (!preEvent.IsCancelled)
			{
				methodToInvoke.Invoke((object)null, parameters);
			}

			PostConsoleSystemEvent postEvent = new PostConsoleSystemEvent ((ConsoleSystem.Arg)parameters [0], preEvent.IsCancelled, preEvent.IsHandled);
			ConsoleSystemEvents.mInstance.gameObject.SendMessage ("PostConsoleSystemCommand", postEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			parameters [0] = postEvent.Argument;
		}

		public static void RegisterConsoleSystemHandler<T>() where T : UnityEngine.MonoBehaviour
		{
			ConsoleSystemEvents.mInstance.gameObject.AddComponent<T> ();
		}
	}
}

