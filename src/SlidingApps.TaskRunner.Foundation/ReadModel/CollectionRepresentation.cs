
namespace SlidingApps.TaskRunner.Foundation.ReadModel
{
    public abstract class CollectionRepresentation
        : Representation, ICollectionRepresentation
    {
        protected CollectionRepresentation(int? page = null, int? pageSize = null)
        {
            this.Page = page;
            this.PageSize = pageSize;
        }

        public int? Page { get; set; }

        public int? PageSize { get; set; }


        public override void FormatLinks(IFormatValues values)
        {
            base.FormatLinks(values);

            this.FormatEmbeddedObjectLinks(values);
        }

        public abstract void FormatEmbeddedObjectLinks(IFormatValues values);
    }
}
