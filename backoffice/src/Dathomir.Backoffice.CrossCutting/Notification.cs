using Dathomir.Backoffice.CrossCutting.Enums;
using System.Net;

namespace Dathomir.Backoffice.CrossCutting;

public class Notification
{
    public Notification(HttpStatusCode statusCode) =>
        StatusCode = statusCode;

    public Notification(HttpStatusCode statusCode, ErrorCode errorCode)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }

    public Notification(HttpStatusCode statusCode, ErrorCode errorCode, List<string> errors)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        Errors = errors;
    }

    public bool Success { get => ErrorCode == ErrorCode.NoError; }
    public HttpStatusCode StatusCode { get; private set; }
    public ErrorCode ErrorCode { get; private set; } = ErrorCode.NoError;
    public IEnumerable<string> Errors { get; private set; } = [];

    public static Notification CreateError(HttpStatusCode statusCode, ErrorCode errorCode) =>
        new(statusCode, errorCode);

    public static Notification CreateError(HttpStatusCode statusCode, ErrorCode errorCode, string error) =>
        new(statusCode, errorCode, [error]);

    public static Notification CreateSuccess(HttpStatusCode statusCode) =>
        new(statusCode);
}

public class Notification<TEntity> where TEntity : class
{
    public Notification(HttpStatusCode statusCode, ErrorCode errorCode)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }

    public Notification(HttpStatusCode statusCode, ErrorCode errorCode, List<string> errors)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        Errors = errors;
    }

    public Notification(HttpStatusCode statusCode, TEntity data)
    {
        StatusCode = statusCode;
        Data = data;
    }

    public bool Success { get => ErrorCode == ErrorCode.NoError; }
    public HttpStatusCode StatusCode { get; private set; }
    public ErrorCode ErrorCode { get; private set; } = ErrorCode.NoError;
    public IEnumerable<string> Errors { get; private set; } = [];
    public TEntity Data { get; private set; } = null;

    public static Notification<TEntity> CreateError(HttpStatusCode statusCode, ErrorCode errorCode) =>
        new(statusCode, errorCode);

    public static Notification<TEntity> CreateError(HttpStatusCode statusCode, ErrorCode errorCode, IEnumerable<string> errors) =>
        new(statusCode, errorCode, [.. errors]);

    public static Notification<TEntity> CreateSuccess(HttpStatusCode statusCode, TEntity data) =>
        new(statusCode, data);
}
