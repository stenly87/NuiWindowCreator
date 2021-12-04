using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public interface IHaveChildrens : INui
    {
        List<INui> children { get; set; }

        bool AddChildren(INui child);
        void RemoveChildren(INui child);
        void ReplaceChildren(INui oldChild, INui newChild);
        void MoveUpChildren(INui nuiElement);
        void MoveDownChildren(INui nuiElement);
    }
}