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
using UnityEngine;
using NeolithLib.API.Events;
using NeolithLib.Bootstrapper;


namespace NeolithLib
{
	[Bootstrap]
	public class ActivatableEvents : Facepunch.MonoBehaviour
	{
		private static ActivatableEvents mInstance = null;

		public ActivatableEvents ()
		{
			mInstance = this;
		}

		public void Awake()
		{
			DontDestroyOnLoad (this.gameObject);
		}

		public static void RegisterConsoleSystemHandler<T>() where T : UnityEngine.MonoBehaviour
		{
			ActivatableEvents.mInstance.gameObject.AddComponent<T> ();
		}

		public static ActivationResult InvokeActivate(Activatable target, Character instigator, IActivatable activatable, ulong timestamp)
		{
			PreActivateEvent preEvent = new PreActivateEvent (instigator, target.gameObject, activatable, timestamp);
			target.gameObject.SendMessage ("PreActivateCommand", preEvent, SendMessageOptions.DontRequireReceiver);
			ActivatableEvents.mInstance.gameObject.SendMessage ("PreActivateCommand", preEvent, SendMessageOptions.DontRequireReceiver);

			if (!preEvent.Cancelled) 
			{
				preEvent.Result = preEvent.Activatable.ActTrigger(preEvent.Instigator, preEvent.Timestamp);
			}

			PostActivateEvent postEvent = new PostActivateEvent (preEvent.Instigator, preEvent.Target, preEvent.Activatable, preEvent.Timestamp, preEvent.Result, preEvent.Handled, preEvent.Cancelled);
			target.gameObject.SendMessage ("PostActivateCommand", postEvent, SendMessageOptions.DontRequireReceiver);
			ActivatableEvents.mInstance.gameObject.SendMessage ("PostActivateCommand", postEvent, SendMessageOptions.DontRequireReceiver);

			return postEvent.Result;
		}

		public static ActivationResult InvokeToggle(Activatable target, Character instigator, IActivatableToggle activatable, ActivationToggleState state, ulong timestamp)
		{
			PreToggleEvent preEvent = new PreToggleEvent (instigator, target.gameObject, activatable, timestamp, state);
			target.gameObject.SendMessage ("PreToggleCommand", preEvent, SendMessageOptions.DontRequireReceiver);
			ActivatableEvents.mInstance.gameObject.SendMessage ("PreToggleCommand", preEvent, SendMessageOptions.DontRequireReceiver);

			if (!preEvent.Cancelled) {
				preEvent.Result = preEvent.Toggle.ActTrigger(preEvent.Instigator, preEvent.State, preEvent.Timestamp); 
			}

			PostToggleEvent postEvent = new PostToggleEvent (preEvent.Instigator, preEvent.Target, preEvent.Toggle, preEvent.Timestamp, preEvent.State, preEvent.Result, preEvent.Handled, preEvent.Cancelled);
			target.gameObject.SendMessage ("PostToggleCommand", postEvent, SendMessageOptions.DontRequireReceiver);
			ActivatableEvents.mInstance.gameObject.SendMessage ("PostToggleCommand", postEvent, SendMessageOptions.DontRequireReceiver);

			return postEvent.Result;
		}
	}
}
