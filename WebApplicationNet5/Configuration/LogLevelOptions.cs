using System.Runtime.Serialization;

namespace WebApplicationNet5
{
    public class LogLevelOptions
    {

        public string Default { get; set; }

        public string Microsoft { get; set; }

        [DataMember(Name = "Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }

    }
}
