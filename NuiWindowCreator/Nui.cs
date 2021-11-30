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
    public static class Nui
    {
        public static string GetJsonFromWindow(NuiWindow window)
        {
            return JsonConvert.SerializeObject(window, 
                new JsonSerializerSettings {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore 
                });
        }
    }
}
