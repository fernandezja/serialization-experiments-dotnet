namespace SystemTextJsonConsole
{
    public interface ICurrentConfiguration
    {
        string ApiUrl { get; set; }
        string BranchOfficesMapUrl { get; set; }
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string Facebook { get; set; }
        string FacebookClientId { get; set; }
        string GoogleAndroidClientId { get; set; }
        string GoogleiOSClientId { get; set; }
        string Instagram { get; set; }
        string Scope { get; set; }
        string Twitter { get; set; }
        string Web { get; set; }
        string Whatsapp { get; set; }
    }
}