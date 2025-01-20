namespace School.Data.Route
{
    public static class BaseRoute
    {
        public const string root = "API";
        public const string version = "V1";
        public const string rule = root + "/" + version + "/";
        public const string id = "/{id}";

        public static class studentrouting
        {
            public const string prefix = rule + "student";
            public const string getlist = prefix + "/getall";
            public const string getbyid = prefix + id;
            public const string AddStudent = prefix + "/Add";
            public const string UpdateStudent = prefix + "/update";
            public const string DeleteStudent = prefix + "/delete" + id;
            public const string GetPaginatedStudent = prefix + "/paginatedstudent";

        }
        public static class departmentrouting
        {
            public const string prefix = rule + "department";
            public const string getbyid = prefix + "/id";
            public const string getdepartmentwithstdcount = prefix + "/getdepartmentwithstdcount";
            public const string getspecificdepartmentwithstdcount = prefix + "/getspecificdepartmentwithstdcount/{id}";
        }
        public static class AuthRouting
        {
            public const string prefix = rule + "Auth";
            public const string Register = prefix + "/Register";
            public const string getbyid = prefix + id;
            public const string getlist = prefix + "/getall";
            public const string Update = prefix + "/Update";
            public const string Delete = prefix + "/delete" + id;
            public const string Changepassword = prefix + "/changepassword";
        }

    }
}
