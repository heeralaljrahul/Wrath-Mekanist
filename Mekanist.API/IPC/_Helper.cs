#region

using Dalamud.Plugin.Ipc.Exceptions;
using Mekanist.API.Error;

#endregion

namespace Mekanist.API;

public static partial class WrathIPCWrapper
{
    private static T SafeInvokeRawMethod<T>(Func<T> ipcCall)
    {
        if (Interface == null)
            throw new UninitializedException(
                "WrathCombo IPC Wrapper not initialized.");

        try
        {
            return ipcCall();
        }
        catch (IpcError ex) when (ex is IpcTypeMismatchError or
                                      IpcValueNullError or
                                      IpcLengthMismatchError)
        {
            throw new APIBehindException(
                "WrathCombo.API needs updated; " +
                "it is behind WrathCombo.IPC: invalid signatures.",
                ex);
        }
        catch (IpcError ex) when (ex is IpcNotReadyError)
        {
            throw new UninitializedException(
                "WrathCombo.IPC isn't ready.", ex);
        }
        catch (IpcError ex)
        {
            throw new IPCException(
                "WrathCombo.API encountered an IPC error " +
                "in using Mekanist.IPC.",
                ex);
        }
        catch (Exception ex)
        {
            throw new UnexpectedException(
                "WrathCombo.API encountered an unexpected " +
                "error in using Mekanist.IPC.",
                ex);
        }
    }

    private static void SafeInvokeRawMethod(Action ipcCall)
    {
        SafeInvokeRawMethod(() =>
        {
            ipcCall();
            return 0L;
        });
    }
}