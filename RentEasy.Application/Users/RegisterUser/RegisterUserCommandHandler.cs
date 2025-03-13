using RentEasy.Application.Abstractions.Authentication;
using RentEasy.Application.Abstractions.Messaging;
using RentEasy.Domain.Abstractions;
using RentEasy.Domain.Users;

namespace RentEasy.Application.Users.RegisterUser
{
    internal sealed class RegisterUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService)
        : ICommandHandler<RegisterUserCommand, Guid>
    {

        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(
                new FirstName(request.FirstName),
                new LastName(request.LastName),
                new Email(request.Email));

            var identityId = await _authenticationService.RegisterAsync(
                user,
                request.Password,
                cancellationToken);

            user.SetIdentityId(identityId);

            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync();

            return user.Id;
        }
    }
}
