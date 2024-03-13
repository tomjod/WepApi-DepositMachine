using Domain.Repositories;
using Application.Abstractions.Messaging;
using Domain.Entities.Users;
using MediatR;
using SharedKernel;

namespace Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetUserByIdAsync(request.userId);

        if (user is null)
        {
            return Result.Failure<GetUserByIdResponse>(new Error(
               "User.NotFound",
               $"The User with Id {request.userId.Value} was not found"));
        }

        var response = new GetUserByIdResponse(
            user.Id.Value, 
            user.UserName.Value, 
            user.FirstName.Value, 
            user.LastName.Value, 
            user.Email.Value);

        return response;
    }
}

