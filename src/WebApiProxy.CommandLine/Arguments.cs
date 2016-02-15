
using CommandLine;
using CommandLine.Text;

namespace WebApiProxy.CommandLine
{
    class Arguments
    {
        [Option('e', "endpoint", Required = true, HelpText = "API endpoint.")]
        public string Endpoint { get; set; }

        [Option('o', "output", Required = true, HelpText = "The output filename.")]
        public string OutputFileName { get; set; }

        [Option('n', "namespace", Required = false, HelpText = "The class namespace.")]
        public string Namespace { get; set; }

        [Option('c', "name", Required = false, HelpText = "The class name.")]
        public string Name { get; set; }

        [HelpOption]
        public string GetHelpText()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
