using Swashbuckle.AspNetCore.Filters;

namespace WebApplication1.ViewModels
{
    public class UpdateUserRequestExample : IExamplesProvider<ModifyUserViewModel>
    {
        public ModifyUserViewModel GetExamples()
        {
            return new ModifyUserViewModel()
            {
                Sid = "0P221565115918943503",
                CName = "使用者1-1",
                EName = "User1-1",
                SName = "u1-1",
                EMail = "user1_1@com.tw",
                Account = "user1",
                AccountPwd = "1234567890"
            };
        }
    }
}
