﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeolithLib.Bootstrapper
{
    /// <summary>
    /// A dummy custom attribute- classes in mods that have this attribute & extend UnityEngine.MonoBehaviour will be loaded as scripts.
    /// </summary>
    public class BootstrapAttribute : Attribute
    {
    }
}
