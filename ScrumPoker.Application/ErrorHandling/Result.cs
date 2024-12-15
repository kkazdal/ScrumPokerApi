using System;

namespace ScrumPoker.Application.ErrorHandling;

public class ErrorHandling<T>
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public string ErrorMessage { get; }
    public string ErrorCode { get; }

    private ErrorHandling(bool isSuccess, T data, string errorMessage = "", string errorCode = "")
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }

    public static ErrorHandling<T> Success(T data) => new ErrorHandling<T>(true, data);
    public static ErrorHandling<T> Failure(string errorMessage, string errorCode) => new ErrorHandling<T>(false, default, errorMessage, errorCode);
}
