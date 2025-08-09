using Swashbuckle.AspNetCore.Filters;

namespace WebApplication1.ViewModels
{
    public class CreateUserRequestExample : IExamplesProvider<UserViewModel>
    {
        public UserViewModel GetExamples()
        {
            return new UserViewModel()
            {
                CName = "使用者2",
                EName = "User2",
                SName = "u2",
                EMail = "user2@com.tw",
                Account = "user2",
                AccountPwd = "12345678"
            };
        }
    }
}
