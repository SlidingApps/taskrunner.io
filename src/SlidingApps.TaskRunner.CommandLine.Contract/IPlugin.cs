
using System;

namespace SlidingApps.TaskRunner.CommandLine
{
    public interface IPlugin
    {
        string SessionId { get; }

        void Start(string sessionId, string[] args);
    }
}
