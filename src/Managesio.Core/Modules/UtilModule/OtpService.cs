using Agoda.IoC.Core;

namespace Managesio.Core.Modules.UtilModule;

public interface IOtpService
{
    public int Generate6DigitsOtp();
}

[RegisterSingleton]
public class OtpService : IOtpService
{
    public int Generate6DigitsOtp()
    {
        Random random = new Random();
        return random.Next(1000000,9999999);
    }
}