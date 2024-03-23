using ReadingClubSPI_.Net.BusinessReadClBookLayer.Exceptions;
using ReadingClubSPI_.Net.BusinessReadClBookLayer.Models.UserBook;
using ReadingClubSPI_.Net.Services.Services.Contracts;

namespace ReadingClubSPI_.Net.Services.Services.Implementations
{
    public class UserBookService : IUserBookService
    {
        private readonly IRepositoriesWrapper _repositoriesWrapper;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;

        public UserBookService(IRepositoriesWrapper repositoriesWrapper, IMapper mapper, ITokenService tokenService, IPasswordService passwordService)
        {
            _repositoriesWrapper = repositoriesWrapper;
            _mapper = mapper;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public AuthorizedUserBook Register(RegistrationUserBook item)
        {
            var isUniqueLogin = _repositoriesWrapper.Users.IsUniqueLogin(item.Login);

            if (!isUniqueLogin)
            {
                throw new ItemAlreadyExistsException($"Login: '{item.Login}' is already used!");
            }

            var user = _mapper.Map<UserBookService>(item);
            user.Password = _passwordService.HashPassword(user.Password);
            _repositoriesWrapper.Users.Save(user);

            var authorizedUser = _mapper.Map<AuthorizedUserBook>(user);
            authorizedUser.JwtToken = _tokenService.CreateToken(user);

            return authorizedUser;
        }

        public AuthorizedUserBook Login(LoginUserBook loginUserBook)
        {
            var user = _repositoriesWrapper.Users.GetUserByLogin(loginUserBook.Login);

            if (user is null)
            {
                throw new UserLoginIsNotFoundException($"Wrong login or password!");
            }

            var result = _passwordService.IsPasswordCorrect(loginUserBook.Password, user.Password);

            if (!result)
            {
                throw new WrongUserPasswordException($"Wrong login or password!");
            }

            var authorizedUser = _mapper.Map<AuthorizedUserBook>(user);
            authorizedUser.JwtToken = _tokenService.CreateToken(user);

            return authorizedUser;
        }
    }
}