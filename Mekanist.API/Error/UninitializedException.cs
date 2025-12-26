namespace Mekanist.API.Error;

public class UninitializedException(string? msg, Exception? ex = null)
    : Exception(msg, ex);