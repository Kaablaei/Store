﻿using Domain.Base;



namespace Domain.Users
{
    public class UseAddress : BaseEntity<int>
    {



        public int UserId { get; set; }
        public User User { get; set; }

        public int AddresId { get; set; }

        public static UseAddress Create(int userId, int address)
        {
            return new UseAddress
            {
                UserId = userId,
                AddresId = address
            };

        }
    }


}
