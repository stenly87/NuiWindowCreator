using Newtonsoft.Json;
using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuiWindowCreator
{
    internal static class Nui
    {
        internal static string GetJsonFromWindow(NuiWindow window)
        {
            string result = JsonConvert.SerializeObject(window,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                });
            if (!result.Contains("\"collapsed\":"))
            {
                result = result.Insert(1, "\n\"collapsed\": null,");
            }    
            return result;
        }

        internal static NuiElement GetElementByName(string elementName)
        {
            var type = System.Reflection.Assembly.GetExecutingAssembly().GetType($"NuiWindowCreator.NuiElements.{elementName}");
            if (type == null)
                return null;
            return (NuiElement)Activator.CreateInstance(type);
        }
    }
}
