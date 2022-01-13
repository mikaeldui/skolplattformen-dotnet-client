using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Skolplattformen
{
    [JsonIReadOnlyCollection]
    public class SkolplattformenCollection<T> : ReadOnlyCollection<T>
    {
        public SkolplattformenCollection(IList<T> list) : base(list)
        {
        }
    }
}
