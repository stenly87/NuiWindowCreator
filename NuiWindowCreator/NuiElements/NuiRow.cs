﻿using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiRow : NuiElement, IHaveChildrens
    {
        public List<INui> children { get; set; } = new List<INui>();
        public NuiRow()
        {
            type = "row";
        }

        public bool AddChildren(INui child)
        {
            children.Add(child);
            return true;
        }

        public void RemoveChildren(INui child)
        {
            children.Remove(child);
        }

        public void ReplaceChildren(INui oldChild, INui newChild)
        {
            int index = children.IndexOf(oldChild);
            children[index] = newChild;
        }
        public void MoveUpChildren(INui nuiElement)
        {
            int index = children.IndexOf(nuiElement);
            children.Remove(nuiElement);
            children.Insert(--index, nuiElement);
        }

        public void MoveDownChildren(INui nuiElement)
        {
            int index = children.IndexOf(nuiElement);
            children.Remove(nuiElement);
            children.Insert(++index, nuiElement);
        }
    }
}
