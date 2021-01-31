using CLCMilestone1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLCMilestone1.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();
        List<UserModel> knownUsers = new List<UserModel>();

        public SecurityService()
        {
            knownUsers.Add(new UserModel { Id = 0, UserName = "BillGates", Password = "bucks" });
            knownUsers.Add(new UserModel { Id = 1, UserName = "WatsonCrick", Password = "dna" });
            knownUsers.Add(new UserModel { Id = 2, UserName = "Alexander", Password = "penicillin" });
        }
        public bool isValid(UserModel user)
        {
            return securityDAO.FindUserByNameAndPassword(user);
            //return knownUsers.Any(x => x.UserName == user.UserName && x.Password == user.Password);
        }

    }
}
