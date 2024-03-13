using Domain.Entities.Branches;

namespace Domain.Entities.Users;
public class UserBranch
{

    public UserId UserId { get; private set; }

    public BranchId BranchId { get; private set; }
}
