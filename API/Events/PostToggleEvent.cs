using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NeolithLib.API.Events
{
    public class PostToggleEvent
    {
        public Character Instigator { get; private set; }
        public GameObject Target { get; private set; }
        public IActivatableToggle Toggle { get; private set; }
        public ulong Timestamp { get; private set; }
        public ActivationToggleState State { get; private set; }
        public ActivationResult Result { get; private set; }
        public bool WasHandled { get; private set; }
		public bool WasCancelled { get; private set; }
        public bool Handled { get; set; }

        public PostToggleEvent(Character instigator, GameObject target, IActivatableToggle toggle, ulong timestamp, ActivationToggleState state, ActivationResult result, bool wasHandled, bool wasCancelled)
        {
            this.Instigator = instigator;
            this.Target = target;
            this.Toggle = toggle;
            this.Timestamp = timestamp;
            this.State = state;
            this.Result = result;
            this.WasHandled = wasHandled;
            this.Handled = false;
			this.WasCancelled = false;
        }
    }
}
