using System;

namespace NuiWindowCreator.NuiProperties
{
    internal class JsonBindStringAttribute : Attribute
    {
        public JsonBindStringAttribute(string v)
        {
            Value = v;
        }

        public string Value { get; }
    }
}