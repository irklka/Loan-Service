namespace LoanService.Core.User.Enums;

public static class Roles
{
    public enum UserRole
    {
        Customer = 1,
        LoanOfficer = 2,
        Admin = 3
    }

    public static UserRole[] RegularUsers => new UserRole[] { UserRole.Customer };
    public static UserRole[] PriorityUsers => new UserRole[] { UserRole.LoanOfficer, UserRole.Admin };
    public static UserRole[] AdminUsers => new UserRole[] { UserRole.Admin };
}

