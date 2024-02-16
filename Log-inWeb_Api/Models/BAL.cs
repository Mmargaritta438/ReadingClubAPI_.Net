namespace Log_inWeb_Api.Models
{
    public class BAL
    {
        public string GetLogin(LoginModel loginModel)
        {
            DAL dal = new DAL();
            string response = dal.GetLogin(loginModel);
            return response;
        }
    }
}