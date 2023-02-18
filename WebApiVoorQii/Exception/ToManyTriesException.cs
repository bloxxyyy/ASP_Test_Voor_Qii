namespace WebApiVoorQii.Exceptions;

public class ToManyTriesException : Exception {
    private ToManyTriesException(string message) : base(message) {}

    public static ToManyTriesException Create(string message, ILogger logger) {
        message ??= "Default message for ToManyTriesException";
        logger.LogError(message: message);
        return new ToManyTriesException(message);
    }
}
