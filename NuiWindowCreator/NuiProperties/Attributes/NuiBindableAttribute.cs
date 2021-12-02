using System;

namespace NuiWindowCreator
{
    internal class NuiBindableAttribute : Attribute
    {
        public NuiBindableAttribute(Type type)
        {
            TargetType = type;
        }

        public Type TargetType { get; }
    }
}