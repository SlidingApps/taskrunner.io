
using SlidingApps.TaskRunner.Foundation.ReadModel;

namespace SlidingApps.TaskRunner.Foundation.Extension
{
    public static class RepresentationExtension
    {
        public static TRepresentation FormatHalJsonLinks<TRepresentation>(this TRepresentation representation, IFormatValues values)
            where TRepresentation: IRepresentation
        {
            if (representation!=null) representation.FormatLinks(values);

            return representation;
        }
    }
}
