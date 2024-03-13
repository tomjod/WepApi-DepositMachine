using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities.Users;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Commands.SetUserRole
{
    public class UserRoleCommandHandler : ICommandHandler<SetUserRoleCommand, UserRoleResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<UserRoleResponse>> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
        {

            if (!await _userRepository.CheckIfRoleExistsAsync(request.RoleName))
            {
                return Result.Failure<UserRoleResponse>(new Error(
                   "Role.NotFound",
                   $"Role with name {request.RoleName} was not found"));
            }

            var user = await _userRepository.GetUserByIdAsync(request.Id);

            if (user is null)
            {
                return Result.Failure<UserRoleResponse>(new Error(
                    "User.NotFound",
                    message: $"The user with Id {request.Id} was not found"));
            }

            var role = await _userRepository.GetRoleByNameAsync(request.RoleName);

            if (role is null)
            {
                return Result.Failure<UserRoleResponse>(new Error(
                    "Role.NotFound",
                    message: $"The Role with name {request.RoleName} was not found"));
            }

            if (await _userRepository.CheckIfUserAreInRoleAsync(user.Id))
            {
                return Result.Failure<UserRoleResponse>(new Error(
                    "User.InRole",
                    message: $"The User with Id {user.Id.Value} has role assigned"));
            }

            var identityRole = new IdentityUserRole<UserId>
            {
                RoleId = role.Id,
                UserId = user.Id
            };

           _userRepository.SetUserRole(identityRole);

            await _unitOfWork.SaveChangesAsync();

            var response = new UserRoleResponse(
                user.Id.Value, 
                user.FirstName.Value, 
                user.LastName.Value,
                user.UserName.Value,
                user.Email.Value,
                new RoleResponse(role.Id.Value, role.Name!));

            return response;
                       
        }
    }
}
