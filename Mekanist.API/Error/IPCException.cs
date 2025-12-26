namespace Mekanist.API.Error;

public class IPCException(string? msg, Exception? ex) : Exception(msg, ex);