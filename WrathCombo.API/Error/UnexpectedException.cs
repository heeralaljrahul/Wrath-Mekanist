namespace WrathCombo.API.Error;

public class UnexpectedException(string? msg, Exception? ex) : Exception(msg, ex);