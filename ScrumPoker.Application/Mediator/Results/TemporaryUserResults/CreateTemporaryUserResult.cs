using System;

namespace ScrumPoker.Application.Mediator.Results.TemporaryUserResults;

public class CreateTemporaryUserResult
{
    public int Id { get; set; }
    public string SessionId { get; set; }//Her geçici kullanıcı için bir oturum kimliği. Bu, geçici kullanıcının benzersizliğini sağlamak için kullanılabilir.
    public string Username { get; set; }
    public DateTime JoinedAt { get; set; }
}
