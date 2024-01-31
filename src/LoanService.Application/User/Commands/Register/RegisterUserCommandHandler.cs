using Ardalis.Specification;

using LoanService.Application.Common.Security.Jwt.Interfaces;
using LoanService.Application.Common.Security.Password;
using LoanService.Core.User;
using LoanService.Core.User.Specifications;

using MediatR;

using static LoanService.Core.User.Enums.Roles;

namespace LoanService.Application.User.Commands.Register;

public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
{
    private readonly IJwtTokenService _tokenService;
    private readonly IRepositoryBase<UserEntity> _userRepository;

    public RegisterUserCommandHandler(IJwtTokenService tokenService,
        IRepositoryBase<UserEntity> userRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userRepository.AnyAsync(
            new GetUserByEmailSpec(request.Email),
            cancellationToken);

        if (userExists)
        {
            throw new UserAlreadyExistsException($"user already exist with email:{request.Email}");
        }

        var (passwordHash, passwordSalt) = PasswordManager.CreatePasswordHash(request.Password);

        var userEntity = new UserEntity
        {
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            IdNumber = request.IdNumber,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            Password = passwordHash,
            Salt = passwordSalt
        };

        var user = await _userRepository.AddAsync(userEntity, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);

        var token = await _tokenService.GenerateTokenAsync(user.Id, UserRole.Customer);

        return new RegisterUserCommandResponse(
            new(user.Id, $"{user.Firstname} {user.Lastname}"),
            token);
    }
}
