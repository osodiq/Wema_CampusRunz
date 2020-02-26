using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.DTOs
{
    public static class ApiRoutes
    {

        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        //public static class Modules
        //{
        //    public const string GetAll = Base + "/modules";

        //    public const string Update = Base + "/modules/{moduleId}";

        //    public const string Delete = Base + "/modules/{moduleId}";

        //    public const string Get = Base + "/modules/{moduleId}";

        //    public const string Create = Base + "/modules";



        //}

        //public static class URoles
        //{
        //    public const string GetAll = Base + "/roles";

        //    public const string Get = Base + "/roles/{roleId}";

        //    public const string Create = Base + "/roles";

        //    public const string Update = Base + "/roles/{roleId}";

        //    public const string Delete = Base + "/roles/{roleId}";

        //}

        public static class Auth
        {
            public const string GetAll = Base + "/auth";

            public const string Signin = Base + "/auth/signin";
             
            public const string Signup = Base + "/auth/signup"; 

            public const string ForgotPassword = Base + "/auth/forgort-password/generate-token";

            public const string ValidateToken = Base + "/auth/ValidateToken";

            public const string ResetPassword = Base + "/auth/forget-password/reset-password"; 

        }

         
    }
}
