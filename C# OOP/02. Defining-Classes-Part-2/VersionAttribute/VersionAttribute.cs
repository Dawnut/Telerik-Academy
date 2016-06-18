using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DSpace;
using GenericClass;

namespace Attribute
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]

    public class VersionAttribute : Attribute
    {
        public VersionAttribute(string version)
        {
            this.Version = version;
        }

        public string Version { get; private set; }
    }
}
