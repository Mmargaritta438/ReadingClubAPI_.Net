namespace ReadingClubSPI_.Net.BusinessReadClBookLayer.Exceptions
{
    public class WrongUserPasswordException : Exception
    {
        public WrongUserPasswordException()
        {
        }

        public WrongUserPasswordException(string message) : base(message)
        {
        }
    }
}