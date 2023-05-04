namespace ReimbursementApp.DataAccessLayer.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
        string GetUserEmail();
        string IsApprover();
    }
}