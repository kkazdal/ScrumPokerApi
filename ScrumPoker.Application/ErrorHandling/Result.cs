using System;

namespace ScrumPoker.Application.ErrorHandling;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public string ErrorMessage { get; }
    public string ErrorCode { get; }

    private Result(bool isSuccess, T data, string errorMessage = "", string errorCode = "")
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }

    public static Result<T> Success(T data) => new Result<T>(true, data);
    public static Result<T> Failure(string errorMessage, string errorCode) => new Result<T>(false, default, errorMessage, errorCode);
}
