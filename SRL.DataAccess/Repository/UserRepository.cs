﻿using System;
using System.Collections.Generic;
using System.Linq;
using SRL.Models;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Adapter;

namespace SRL.Data_Access.Repository
{
    public class UserRepository
    {
        public List<User> GetUsersFromActor(int actorId, int retailerChainId)
        {
            var users = new List<User>();
            using (var ctx = new SRLManagementEntities())
            {
                var result = ctx.sp_GetUserForActor(actorId, retailerChainId);
                foreach (var userdata in result)
                {
                    var user = new User
                        {Email = userdata.Email, FirstName = userdata.FirstName, LastName = userdata.LastName};
                    users.Add(user);
                }
            }

            ;
            return users;
        }

        public List<User> GetUsersList(UserListRequest userFilter)
        {
            List<User> users = new List<User>();
            if (userFilter != null)
            {
                using (var ctx = new SRLManagementEntities())
                {
                    users = (ctx.GetAllUsers(
                                userFilter.ViewingUserEmail,
                                userFilter.FirstName,
                                userFilter.LastName,
                                userFilter.Email,
                                userFilter.IsAssigned,
                                userFilter.IsActive,
                                userFilter.HasTemplate,
                                userFilter.IsAdmin,
                                userFilter.RetailerChainCode,
                                userFilter.IsInternal)
                            .ToList<Data_Access.Entity.GetAllUsers_Result>())
                        .ToEntityUserList();
                }

                ;
            }

            return users;
        }

        public UserProfile GetUserProfile(string userEmail)
        {
            UserProfile userProfile = new UserProfile();
            Users user = new Users();
            if (!string.IsNullOrEmpty(userEmail))
            {

                using (var ctx = new SRLManagementEntities())
                {
                    user = ctx.Users.Where(u => u.Email == userEmail).FirstOrDefault();
                }

                if (!string.IsNullOrEmpty(user.Email))
                {
                    userProfile.FirstName = user.FirstName;
                    userProfile.LastName = user.LastName;
                    userProfile.EmailAddress = user.Email;
                    using (var ctx = new SRLManagementEntities())
                    {
                        userProfile.Roles = ctx.sp_GetUserRoles(userEmail).Select(r => r.RoleName).ToList();
                    }
                }
            }

            return userProfile;
        }

        public List<Role> GetUserRoles(string userEmail)
        {
            List<Role> roles = new List<Role>();
            using (var ctx = new SRLManagementEntities())
            {
                roles = ctx.sp_GetUserRoles(userEmail).ToList().ToEntityRoleList();
            }

            return roles;
        }

        public List<Screen> GetUserScreens(string userEmail)
        {
            List<Screen> screens = new List<Screen>();
            using (var ctx = new SRLManagementEntities())
            {
                screens = ctx.sp_GetScreensForUser(userEmail).ToList().ToEntityScreenList();
            }

            return screens;
        }

        public bool IsUserInRole(string userEmail, string[] roles)
        {
            List<Role> roleList = GetUserRoles(userEmail);

            return roleList.Any(r => roles.Contains(r.RoleName));
        }

        public bool IsExternalUser(string userEmail)
        {
            bool isExternal = false;
            using (var ctx = new SRLManagementEntities())
            {
                var result = ctx.sp_CheckIfUserExternal(userEmail).FirstOrDefault();
                isExternal = (result ?? 0) != 0 ? true : false;
            }

            return isExternal;

        }

        public List<int?> GetRetailerChainIdList(string userEmail)
        {
            using (var ctx = new SRLManagementEntities())
            {
                return ctx.sp_GetRetailerChainForUser(userEmail).ToList();
            }
        }


        public List<int> GetActorIdList(string userEmail)
        {

            List<int?> actorIdList = new List<int?>();
            string retailerChainList = string.Empty;
            List<int> actorIds = new List<int>();
            //get all the actors assigned to the user
            using (var ctx = new SRLManagementEntities())
            {
                actorIdList = ctx.sp_GetActorsForUser(userEmail).ToList();
            }

            if (actorIdList.Any())
            {
                actorIdList.ForEach(a =>
                {
                    if (a.HasValue)
                        actorIds.Add(a.Value);
                });
            }

            //get all retailer chains assigned to the user
            using (var ctx = new SRLManagementEntities())
            {
                retailerChainList = string.Join(",", ctx.sp_GetRetailerChainForUser(userEmail).ToArray());
            }

            if (!string.IsNullOrEmpty(retailerChainList))
            {
                List<Common.ActorRetailerChain> actorRetailerChainlist = new List<Common.ActorRetailerChain>();

                //get list of actors and their assigned retailer chain
                using (var ctx = new BACKUP_SRL_20180613Entities())
                {
                    actorRetailerChainlist = ctx.API_LIST_ACTORID_FOR_RETAILERCHAIN(retailerChainList).ToList()
                        .ToEntityActorRetailerChain();
                }

                if (actorRetailerChainlist.Any())
                {
                    //remove retailer chains whose actors are assigned to the user, so as to get retailer chains for whom no actors are assigned directly to the user
                    List<Common.ActorRetailerChain> toBeRemoved =
                        actorRetailerChainlist.Where(a => actorIds.Contains(a.ActorId)).ToList();
                    if (toBeRemoved.Any())
                    {
                        List<int> toBeRemovedRetailerChain =
                            toBeRemoved.Select(a => a.RetailerChainId).Distinct().ToList();
                        toBeRemovedRetailerChain.ForEach(r =>
                        {
                            actorRetailerChainlist.RemoveAll(a => a.RetailerChainId == r);
                        });
                    }

                    actorRetailerChainlist.ForEach(a => actorIds.Add(a.ActorId));
                }

            }

            return actorIds;

        }

        public void AddUsers(IEnumerable<User> insertUsers, int createdUserId)
        {
            var dbUsers = insertUsers.Select(user => new Users
                {
                    CreatedDate = DateTime.Now,
                    Language = "English",
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsInternal = user.IsInteranlUser,
                    CreatedUserId = createdUserId
                })
                .ToList();
            using (var ctx = new SRLManagementEntities())
            {
                ctx.Users.AddRange(dbUsers);
                ctx.SaveChanges();
            }
        }

        public void RemoveUsers(IEnumerable<Users> unverifiedUsers, int modifiedUserId)
        {
            using (var ctx = new SRLManagementEntities())
            {
                foreach (var unverifiedUser in unverifiedUsers)
                {
                    var user = ctx.Users.Find(unverifiedUser.UserId);
                    if (user == null)
                    {
                        continue;
                    }

                    user.Active = false;
                    user.ModifiedUserId = modifiedUserId;
                    user.ModifiedDate = DateTime.Now;
                    ctx.SaveChanges();
                }
            }
        }

        public List<Users> GetAllUsers()
        {
            using (var ctx = new SRLManagementEntities())
            {
                return ctx.Database.SqlQuery<Users>("Select * from Users").ToList();
            }
        }
    }
}
