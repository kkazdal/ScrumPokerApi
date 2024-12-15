using System;
using ScrumPoker.Application.ErrorHandling;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Services;

namespace ScrumPoker.Infrastructure.Repositories;

public class ErrorHandler : IErrorHandler
{
    public async Task<Result<T>> Handle<T>(Func<Task<T>> action)
    {
        try
        {
            var result = await action();
            return Result<T>.Success(result);
        }
        catch (CustomException ex)
        {
            return Result<T>.Failure(ex.Message, ex.ErrorCode);
        }
        catch (Exception ex)
        {
            return Result<T>.Failure("An unexpected error occurred.", "UNKNOWN_ERROR");
        }
    }
}
