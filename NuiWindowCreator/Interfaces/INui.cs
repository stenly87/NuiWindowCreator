using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public interface INui
    {
    }

    public interface IHaveChildrens
    {
        List<NuiElement> children { get; set; }

        bool AddChildren(NuiElement child);
        void RemoveChildren(NuiElement child);
    }
}