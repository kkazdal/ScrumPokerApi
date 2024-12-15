using System;
using ScrumPoker.Application.ErrorHandling;

namespace ScrumPoker.Application.Interfaces;

public interface IErrorHandler
{
    Task<Result<T>> Handle<T>(Func<Task<T>> action);
}
