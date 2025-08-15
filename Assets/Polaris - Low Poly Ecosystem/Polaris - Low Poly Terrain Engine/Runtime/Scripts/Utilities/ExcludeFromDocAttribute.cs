//#if GRIFFIN
using System;

namespace Pinwheel.Griffin
{
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    [ExcludeFromDoc]
    public class ExcludeFromDocAttribute : Attribute
    {
    }
}
//#endif
