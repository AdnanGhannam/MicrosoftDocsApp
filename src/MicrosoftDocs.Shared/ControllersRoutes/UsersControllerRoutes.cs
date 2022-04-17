using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.ControllersRoutes;

public static class UsersControllerRoutes
{
    public const string Root = "/api/[controller]";
    public const string Login = "login";
    public const string Register = "register";
    public const string VerifyEmail = "verify-email";
    public const string ChangePassword = "password/change";
    public const string ResetPassword = "password/reset";
    public const string ConfirmResetPassword = "password/reset-confirm";
    public const string GetMyInformations = "me";
}
