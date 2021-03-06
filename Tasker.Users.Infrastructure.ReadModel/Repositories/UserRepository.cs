﻿using System;
using Nest;
using Tasker.Infrastructure.Elasticsearch;
using Tasker.Users.Infrastructure.ReadModel.Models;

namespace Tasker.Users.Infrastructure.ReadModel.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IElasticClientFactory _elasticClientFactory;

        public UserRepository(IElasticClientFactory elasticClientFactory)
        {
            _elasticClientFactory = elasticClientFactory;
        }

        public void AddUser(UserReadModel user)
        {
            var client = GetElasticClient();

            var response = client.Index(user);
        }

        public bool CheckIfUserExist(Guid userId)
        {
            var client = GetElasticClient();

            var isUserExist = client.DocumentExists<UserReadModel>(userId).Exists;

            return isUserExist;
        }

        private IElasticClient GetElasticClient()
        {
            var elasticClient = _elasticClientFactory.CreateClient("user");

            return elasticClient;
        }
    }
}
