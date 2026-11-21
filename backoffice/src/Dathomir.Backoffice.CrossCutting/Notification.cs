using Dathomir.Backoffice.CrossCutting.Enums;
using FluentValidation.Results;
using System.Net;

namespace Dathomir.Backoffice.CrossCutting;

public class Notification
{
    public Notification(ErrorCode errorCode)
    {
        ErrorCode = errorCode;
    }

    public Notification(ErrorCode errorCode, List<string> errors)
    {
        ErrorCode = errorCode;
        Errors = errors;
    }

    public bool Success { get => ErrorCode == ErrorCode.NoError; }
    public ErrorCode ErrorCode { get; private set; } = ErrorCode.NoError;
    public IEnumerable<string> Errors { get; private set; } = [];

    public static Notification CreateError(ErrorCode errorCode) =>
        new(errorCode);

    public static Notification CreateError(ErrorCode errorCode, string error) =>
        new(errorCode, [error]);
}

public class Notification<TEntity> where TEntity : class
{
    public Notification(ErrorCode errorCode)
    {
        ErrorCode = errorCode;
    }

    public Notification(ErrorCode errorCode, List<string> errors)
    {
        ErrorCode = errorCode;
        Errors = errors;
    }

    public Notification(TEntity data)
    {
        Data = data;
    }

    public bool Success { get => ErrorCode == ErrorCode.NoError; }
    public ErrorCode ErrorCode { get; private set; } = ErrorCode.NoError;
    public IEnumerable<string> Errors { get; private set; } = [];
    public TEntity Data { get; private set; } = null;

    public static Notification<TEntity> CreateError(ErrorCode errorCode) =>
        new(errorCode);

    public static Notification<TEntity> CreateError(ErrorCode errorCode, IEnumerable<string> errors) =>
        new(errorCode, [.. errors]);

    public static Notification<TEntity> CreateError(List<ValidationFailure> validationFailures) =>
        new(ErrorCode.EntityValidationError, [.. validationFailures.Select(vf => vf.ErrorMessage)]);

    public static Notification<TEntity> CreateSuccess(TEntity data) =>
        new(data);
}
