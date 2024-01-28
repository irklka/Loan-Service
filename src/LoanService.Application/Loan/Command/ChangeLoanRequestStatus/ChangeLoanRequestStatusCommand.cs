using FluentValidation;

using LoanService.Core.Loan;

using MediatR;

namespace LoanService.Application.Loan.Command.ChangeLoanRequestStatus;

public record ChangeLoanRequestStatusCommand : IRequest<Unit>
{
    public Guid LoanRequestId { get; set; } = Guid.Empty;
    public Guid LoanOfficerId { get; set; } = Guid.Empty;
    public LoanStatus Status { get; set; } = default!;
}

public class ChangeLoanRequestStatusCommandValidator
    : AbstractValidator<ChangeLoanRequestStatusCommand>
{
    public ChangeLoanRequestStatusCommandValidator()
    {
        RuleFor(command => command.LoanRequestId)
            .NotEmpty();

        RuleFor(command => command.LoanOfficerId)
            .NotEmpty();

        RuleFor(command => command.Status)
            .NotEmpty()
            .IsInEnum();
    }
}
