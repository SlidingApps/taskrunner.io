
using HalJsonNet.Configuration.Interfaces;

namespace SlidingApps.TaskRunner.Foundation.ReadModel
{
    public interface IRepresentation
        : IHaveHalJsonLinks
    { 
        void FormatLinks(IFormatValues values);
    }
}
