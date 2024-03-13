using Domain.Repositories;
using Domain.Entities.Users;
using MediatR;
using Application.Abstractions.Messaging;
using SharedKernel;
using Domain.Errors;

namespace Application.Users.Commands.DeactivateUser;

public class DeactivateUserHandler : ICommand<DeactivateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeactivateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
    {
        if (request.userId == null)
        {
            throw new Exception("El id del usuario no puede ser null");
        }
        var user = await _userRepository.GetUserByIdAsync(request.userId);

        if (user == null)
        {
            return Result.Failure(
               DomainErrors.User.NotFound(request.userId.Value));
        }

        user.Deactivate();

        _userRepository.DeactivateUserAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}