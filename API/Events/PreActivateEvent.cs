using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NeolithLib.API.Events
{
    public class PreActivateEvent
    {
        public Character Instigator { get; private set; }
        public GameObject Target { get; private set; }
        public IActivatable Activatable { get; private set; }
        public ulong Timestamp { get; private set; }
        public ActivationResult Result { get; set; }
        public bool Handled { get; set; }

        public PreActivateEvent(Character instigator, GameObject target, IActivatable activatable, ulong timestamp)
        {
            this.Instigator = instigator;
            this.Target = target;
            this.Activatable = activatable;
            this.Timestamp = timestamp;
            this.Result = ActivationResult.Success;
            this.Handled = false;
        }
    }
}
