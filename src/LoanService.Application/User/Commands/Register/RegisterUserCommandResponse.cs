namespace LoanService.Application.User.Commands.Register;

public record RegisterUserCommandResponse(User User, string Token);

public record User(Guid UserId, string Fullname);
