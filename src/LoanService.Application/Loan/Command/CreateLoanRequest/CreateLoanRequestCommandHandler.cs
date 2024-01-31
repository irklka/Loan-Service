using Ardalis.Specification;

using LoanService.Core.Loan;
using LoanService.Core.User;

using MediatR;

namespace LoanService.Application.Loan.Command.CreateLoanRequest;

public class CreateLoanRequestCommandHandler
    : IRequestHandler<CreateLoanRequestCommand, Unit>
{
    private readonly IRepositoryBase<LoanRequest> _loandRepository;
    private readonly IReadRepositoryBase<UserEntity> _userReadRepository;

    public CreateLoanRequestCommandHandler(IRepositoryBase<LoanRequest> loandRepository,
        IReadRepositoryBase<UserEntity> userReadRepository)
    {
        _loandRepository = loandRepository;
        _userReadRepository = userReadRepository;
    }

    public async Task<Unit> Handle(CreateLoanRequestCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userReadRepository.GetByIdAsync(
            request.UserId,
            cancellationToken);

        if (userExists is null)
        {
            throw new UserDoesNotExistException($"user does not exist with id:{request.UserId}");
        }

        var loanRequest = new LoanRequest
        {
            Type = request.Type,
            RequestedAmount = request.RequestedAmount,
            Currency = request.Currency,
            LoanPeriod = request.LoanPeriod,
            Status = LoanStatus.Sent,
            UserId = request.UserId
        };

        await _loandRepository.AddAsync(loanRequest, cancellationToken);
        await _loandRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
