﻿using ReadingClubSPI_.Net.BusinessReadClBookLayer.Models.UserBook;

namespace ReadingClubSPI_.Net.BusinessReadClBookLayer.Services.Contracts
{
    public interface IUserBookService
    {
        AuthorizedUserBook Register(RegistrationUserBook item);

        AuthorizedUserBook Login(LoginUserBook item);
    }
}