namespace LoanService.Application.User.Commands.Register;

public record RegisterUserCommandResponse(Guid UserId, string Token);
