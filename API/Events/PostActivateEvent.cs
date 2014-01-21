using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NeolithLib.API.Events
{
    public class PostActivateEvent
    {
        public Character Instigator { get; private set; }
        public GameObject Target { get; private set; }
        public IActivatable Activatable { get; private set; }
        public ulong Timestamp { get; private set; }
        public ActivationResult Result { get; private set; }
        public bool WasHandled { get; private set; }
        public bool Handled { get; set; }

        public PostActivateEvent(Character instigator, GameObject target, IActivatable activatable, ulong timestamp, ActivationResult result, bool wasHandled)
        {
            this.Instigator = instigator;
            this.Target = target;
            this.Activatable = activatable;
            this.Timestamp = timestamp;
            this.Result = result;
            this.WasHandled = wasHandled;
            this.Handled = false;
        }
    }
}
