﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiButton : NuiElement
    {
        public NuiButton()
        {
            type = "button";
            label = "Кнопка";
        }
    }
}
