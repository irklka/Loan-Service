using Ardalis.Specification;

using LoanService.Application.Loan.Command.CreateLoanRequest;
using LoanService.Core.Loan;
using LoanService.Core.User;

using MediatR;

namespace LoanService.Application.Loan.Command.ChangeLoanRequestStatus;

public class ChangeLoanRequestStatusCommandHandler
    : IRequestHandler<ChangeLoanRequestStatusCommand, Unit>
{
    private readonly IRepositoryBase<LoanRequest> _loanRepository;
    private readonly IReadRepositoryBase<UserEntity> _userReadRepository;

    public ChangeLoanRequestStatusCommandHandler(IRepositoryBase<LoanRequest> loanRepository,
        IReadRepositoryBase<UserEntity> userReadRepository)
    {
        _loanRepository = loanRepository;
        _userReadRepository = userReadRepository;
    }

    public async Task<Unit> Handle(ChangeLoanRequestStatusCommand request, CancellationToken cancellationToken)
    {
        var loanRequest = await _loanRepository.GetByIdAsync(
            request.LoanRequestId,
            cancellationToken);

        if (loanRequest is null)
        {
            throw new LoanRequestNotFoundException($"loan request does not exist with id: {request.LoanRequestId}");
        }

        if (loanRequest.Status == request.Status)
        {
            return Unit.Value;
        }

        var loanOfficer = await _userReadRepository.GetByIdAsync(
            request.LoanOfficerId,
            cancellationToken);

        if (loanOfficer is null)
        {
            throw new UserDoesNotExistException($"loan officer does not exist with id: {request.LoanOfficerId}");
        }

        loanRequest.Status = request.Status;

        await _loanRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
