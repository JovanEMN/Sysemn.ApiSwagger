using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Sysemn.ApiSwagger.Models
{
    public class FakeUserContext
    {
        private static UserContext _getContextWithData;

        public UserContext GetContextWithData()
        {
            if (_getContextWithData == null) Initializer();
            return _getContextWithData;
        }

        private void Initializer()
        {
            var options = new DbContextOptionsBuilder<UserContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _getContextWithData = new UserContext(options);

            var userModels = new List<UserModel>()
            {
               new UserModel(){ Id = Guid.NewGuid(), Login = "aluiza", Nome ="Ana Luiza", Email = "aluiza@sysemn.io" },
               new UserModel(){ Id = Guid.NewGuid(), Login = "emarques", Nome ="Erick Marques", Email = "emarques@sysemn.io" }
            };

            _getContextWithData.UserModels.AddRange(userModels);
            _getContextWithData.SaveChanges();
        }
    }
}
