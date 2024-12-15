using System;

namespace ScrumPoker.Application.BaseResponse;

public class BaseResponse<T>
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public string ErrorMessage { get; }
    public string ErrorCode { get; }

    private BaseResponse(bool isSuccess, T data, string errorMessage = "", string errorCode = "")
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }

    public static BaseResponse<T> Success(T data) => new BaseResponse<T>(true, data);
    public static BaseResponse<T> Failure(string errorMessage, string errorCode) => new BaseResponse<T>(false, default, errorMessage, errorCode);
}
