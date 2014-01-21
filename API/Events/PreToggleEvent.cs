using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NeolithLib.API.Events
{
    public class PreToggleEvent
    {
        public Character Instigator { get; private set; }
        public GameObject Target { get; private set; }
        public IActivatableToggle Toggle { get; private set; }
        public ulong Timestamp { get; private set; }
        public ActivationToggleState State { get; private set; }
        public ActivationResult Result { get; set; }
        public bool Handled { get; set; }

        public PreToggleEvent(Character instigator, GameObject target, IActivatableToggle toggle, ulong timestamp, ActivationToggleState state)
        {
            this.Instigator = instigator;
            this.Target = target;
            this.Toggle = toggle;
            this.Timestamp = timestamp;
            this.State = state;
            this.Result = ActivationResult.Success;
            this.Handled = false;
        }
    }
}
