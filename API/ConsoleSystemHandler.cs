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
using NeolithLib.Bootstrap;

namespace NeolithLib
{
	[Bootstrap]
	public class ConsoleSystemHandler : Facepunch.MonoBehaviour
	{
		private static ConsoleSystemHandler mInstance = null;

		public ConsoleSystemHandler() 
		{
			ConsoleSystemHandler.mInstance = this;
		}

		public void Awake()
		{
			DontDestroyOnLoad (this.gameObject);
		}

		public static void InvokeConsoleSystem(MethodInfo methodToInvoke, object[] parameters)
		{
			ConsoleSystem.Arg arguments = (ConsoleSystem.Arg)parameters [0];

			PreConsoleSystemEvent preEvent = new PreConsoleSystemEvent (arguments);
			ConsoleSystemHandler.mInstance.gameObject.SendMessage ("PreConsoleSystemCommand", preEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);

			parameters[0] = preEvent.Argument;

			if (!preEvent.IsCancelled)
			{
				methodToInvoke.Invoke((object)null, parameters);
			}

			PostConsoleSystemEvent postEvent = new PostConsoleSystemEvent ((ConsoleSystem.Arg)parameters [0], preEvent.IsCancelled, preEvent.IsHandled);
			ConsoleSystemHandler.mInstance.gameObject.SendMessage ("PostConsoleSystemCommand", postEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			parameters [0] = postEvent.Argument;
		}

		public static void RegisterConsoleSystemHandler<T>() where T : UnityEngine.MonoBehaviour
		{
			ConsoleSystemHandler.mInstance.gameObject.AddComponent<T> ();
		}
	}
}
