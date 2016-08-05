
namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain
{
    public partial class Communication<TConmmunicationInfo>
    {
        public abstract class ConmmunicationInfo
        {
            protected Communication<TConmmunicationInfo> Parent { get; private set; }

            public virtual void SetParent(Communication<TConmmunicationInfo> parent)
            {
                this.Parent = parent;
            }
        }
    }
}
