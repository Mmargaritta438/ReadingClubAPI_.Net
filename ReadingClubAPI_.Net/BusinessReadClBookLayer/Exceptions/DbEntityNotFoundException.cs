namespace ReadingClubSPI_.Net.BusinessReadClBookLayer.Exceptions
{
    public class DbEntityNotFoundException : Exception
    {
        public DbEntityNotFoundException()
        {
        }

        public DbEntityNotFoundException(string message) : base(message)
        {
        }
    }
}