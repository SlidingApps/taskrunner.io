
namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain
{
    public abstract class CommunicationInfo
    {
        protected Entities.Communication Parent { get; private set; }

        public virtual void SetParent(Entities.Communication parent)
        {
            this.Parent = parent;
        }
    }
}
