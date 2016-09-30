
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain
{
    public static class MailUtils
    {
        public static string GetLink(string name, string link)
        {
            var instance =
                new
                {
                    Salt = Guid.NewGuid().ToString(),
                    Username = name,
                    Link = link
                };

            var encrypted =
                instance
                    .ToJson()
                    .Encrypt(EncryptionConfiguration.SymmetricKey, EncryptionConfiguration.SymmetricInitVector)
                    .ToBytes()
                    .ToBase58();

            return encrypted;
        }
    }
}
