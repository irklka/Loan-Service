namespace LoanService.Application.User.Commands.Login;

public record LoginUserCommandResponse(Guid UserId, string Token);
