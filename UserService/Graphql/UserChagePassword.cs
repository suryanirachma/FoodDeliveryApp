﻿namespace UserService.Graphql
{
    public partial class UserChangePassword
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
