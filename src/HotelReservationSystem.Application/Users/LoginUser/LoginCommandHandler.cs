using BCrypt.Net;
using CleanArchitecture.Domain.Abstractions;
using HotelReservationSystem.Application.Abstractions.Authentication;
using HotelReservationSystem.Application.Abstractions.Messaging;
using HotelReservationSystem.Domain.Users;

namespace HotelReservationSystem.Application.Users.LoginUser
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwProvider;

        public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwProvider)
        {
            _userRepository = userRepository;
            _jwProvider = jwProvider;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //1. Verificar que el usuario exista en la base de datos
            // buscar un usuario en la bd por el email
            var user = await _userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);
            if (user is null)
            {
                return Result. Failure<string>(UserErrors.NotFound);
            }

            //2. Validar que el password es correcto
            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash!.Value))
            {
                return Result.Failure<string>(UserErrors.InvalidCredentials);
            }

            //3. Generar el JWT
            var token = await _jwProvider.Generate(user);

            //4. Return jwt;
            return token;
        }
    }
}
