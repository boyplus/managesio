namespace Managesio.Core.Configs;

public class AssemblyInfo
{
    public string Version => typeof(AssemblyInfo).Assembly.GetName().Version.ToString();
}