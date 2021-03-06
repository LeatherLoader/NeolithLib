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
using NeolithLib.Bootstrapper;
using NeolithLib.API.Events;


namespace NeolithLib.API
{
	[Bootstrap]
	public class TakeDamageEvents : Facepunch.MonoBehaviour
	{
		private static TakeDamageEvents mInstance = null;

		public TakeDamageEvents ()
		{
			mInstance = this;
		}

		public void Awake()
		{
			DontDestroyOnLoad (this.gameObject);
		}

		public static void RegisterDeployableHandler<T>() where T : UnityEngine.MonoBehaviour
		{
			TakeDamageEvents.mInstance.gameObject.AddComponent<T> ();
		}

		public static LifeStatus InvokeTakeDamage(TakeDamage target, DamageEvent dmgEvent) {
			PreTakeDamageEvent preEvent = new PreTakeDamageEvent (target, dmgEvent);

			target.gameObject.SendMessage ("PreTakingDamageCommand", preEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			dmgEvent.attacker.character.gameObject.SendMessage ("PreDealingDamageCommand", preEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			TakeDamageEvents.mInstance.gameObject.SendMessage ("PreTakeDamageCommand", preEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);

			if (!preEvent.Cancelled) {
				DamageEvent evt = preEvent.DamageEvent;
				evt.status = preEvent.Target.Hurt(ref evt);
				preEvent.DamageEvent = evt;
			}

			PostTakeDamageEvent postEvent = new PostTakeDamageEvent (preEvent.Target, preEvent.DamageEvent, preEvent.Handled, preEvent.Cancelled);
			target.gameObject.SendMessage ("PostTakingDamageCommand", postEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			dmgEvent.attacker.character.gameObject.SendMessage ("PostDealingDamageCommand", postEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			TakeDamageEvents.mInstance.gameObject.SendMessage ("PostTakeDamageCommand", postEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
		}

		public static RepairEvent InvokeHeal(TakeDamage target, IDBase healer, float amount, PreHealEvent.HealType type) {
			PreHealEvent preEvent = new PreHealEvent (target, healer, amount, type);
			target.gameObject.SendMessage ("PreReceiveHealingCommand", preEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			healer.gameObject.SendMessage ("PreOfferHealingCommand", preEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			TakeDamageEvents.mInstance.gameObject.SendMessage ("PreHealCommand", preEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);

			RepairEvent outEvent;
			if (!preEvent.Cancelled) {
				outEvent = preEvent.Target.Heal(preEvent.Healer, preEvent.Amount);
			} else {
				outEvent = new RepairEvent();
				outEvent.doner = healer;
				outEvent.receiver = target;
				outEvent.givenAmount = amount;
				outEvent.usedAmount = 0;
				outEvent.status = RepairStatus.Failed;
			}

			PostHealEvent postEvent = new PostHealEvent (preEvent.Target, preEvent.Healer, outEvent.usedAmount, type, outEvent, preEvent.Handled, preEvent.Cancelled);
			target.gameObject.SendMessage ("PostReceiveHealingCommand", postEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			healer.gameObject.SendMessage ("PostOfferHealingCommand", postEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);
			TakeDamageEvents.mInstance.gameObject.SendMessage ("PostHealCommand", postEvent, UnityEngine.SendMessageOptions.DontRequireReceiver);

			return postEvent.RepairEvent;
		}
	}
}

