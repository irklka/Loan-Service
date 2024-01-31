namespace LoanService.Application.User.Commands.Login;

public record LoginUserCommandResponse(User User, string Token);

public record User(Guid UserId, string Fullname);
