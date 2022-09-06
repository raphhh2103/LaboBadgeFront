using LaboBadge.Models;

namespace LaboBadge.Mapper
{
    public static class UserMapper
    {
        public static User ToUser(this UserToken user)
        {
            return new User
            {
                IdUser = user.Id,
                Email = user.Email,
                Passwd = "",
                Rule = user.Rule
            };
        }

        public static UserToken ToToken(this User user)
        {
            return new UserToken
            {
                Id = user.IdUser,
                Email = user.Email,
                Token = "",
                Rule = user.Rule
            };
        }

    }
}
