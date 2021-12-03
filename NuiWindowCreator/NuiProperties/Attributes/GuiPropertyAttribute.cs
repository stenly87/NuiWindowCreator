using System;

namespace NuiWindowCreator.NuiProperties
{
    internal class GuiPropertyAttribute: Attribute
    {
        public GuiPropertyAttribute(Type type)
        {
            TargetType = type;
        }
        public Type TargetType { get; }
    }
}