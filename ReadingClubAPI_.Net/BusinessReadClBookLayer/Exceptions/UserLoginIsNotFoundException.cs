namespace ReadingClubSPI_.Net.BusinessReadClBookLayer.Exceptions
{
    public class UserLoginIsNotFoundException : Exception
    {
        public UserLoginIsNotFoundException()
        {
        }

        public UserLoginIsNotFoundException(string message) : base(message)
        {
        }
    }
}