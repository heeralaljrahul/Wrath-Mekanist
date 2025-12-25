namespace WrathCombo.API.Error;

public class APIBehindException(string? msg, Exception? ex) : Exception(msg, ex);