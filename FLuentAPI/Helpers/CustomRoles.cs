namespace FLuentAPI.Helpers
{
    public static class CustomRoles
    {
        private const string SuperAdmin = "SuperAdmin";
        private const string Admin = "Admin";
        private const string Mentor = "Mentor";
        private const string User = "User";

        public const string AllRoles = SuperAdmin + "," + Admin + "," + Mentor + "," + User;
        public const string AdminRoles = SuperAdmin + "," + Admin;
        public const string UserRoles = User + "," + Admin + "," + SuperAdmin;
        public const string MentorRoles = Mentor + "," + Admin + "," + SuperAdmin;
    }
}
