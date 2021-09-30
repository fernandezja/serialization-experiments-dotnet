using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTextJsonConsole
{
    public class CurrentConfiguration : ICurrentConfiguration
    {
        public string ApiUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string GoogleAndroidClientId { get; set; }
        public string GoogleiOSClientId { get; set; }
        public string FacebookClientId { get; set; }
        public string BranchOfficesMapUrl { get; set; }
        public string Web { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Whatsapp { get; set; }
    }
}
