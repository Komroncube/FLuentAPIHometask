namespace FLuentAPI.Helpers
{
    public static class CustomRoles
    {
        private const string SuperAdmin = "SuperAdmin";
        private const string Admin = "admin";
        private const string Mentor = "mentor";
        private const string User = "user";

        public const string AllRoles = SuperAdmin + "," + Admin + "," + Mentor + "," + User;
        public const string AdminRoles = SuperAdmin + "," + Admin;
        public const string UserRoles = User + "," + Admin + "," + SuperAdmin;
        public const string MentorRoles = Mentor + "," + Admin + "," + SuperAdmin;
    }
}
