﻿using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiSimpleBoolProperty : NuiSimpleProperty<bool>
    {
        public NuiSimpleBoolProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        { 

        }
    }
}