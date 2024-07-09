using NuiWindowCreator.NuiElements;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiScrollSelectProperty : NuiEnumSelectProperty<NuiScrollbars>
    {
        public NuiScrollSelectProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        {
        }
    }
}