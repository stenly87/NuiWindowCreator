using System;

namespace NuiWindowCreator.NuiProperties
{
    internal class GuiPropertyAttribute: Attribute
    {
        public GuiPropertyAttribute(Type type, string description = null)
        {
            TargetType = type;
            Description = description;
        }
        public Type TargetType { get; }
        public string Description { get; }
    }
}