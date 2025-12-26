namespace Mekanist.Services.IPC_Subscriber;

public static class AllStaticIPCSubscriptions
{
    public static void Dispose()
    {
        OrbwalkerIPC.Dispose();
    }
}