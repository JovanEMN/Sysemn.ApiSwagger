using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sysemn.ApiSwagger.Models;

namespace Sysemn.ApiSwagger.Controllers
{
    [Route("Sysemn/[controller]")]
    public class UserController : Controller
    {
        private UserContext _context;
        public UserController()
        {
            _context = new FakeUserContext().GetContextWithData();
        }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return _context.UserModels.ToList();
        }

        [HttpGet("{login}")]
        public UserModel Get(string login)
        {            
            return _context.UserModels.Where(x => x.Login == login).FirstOrDefault();
        }

        [HttpPost]
        public void Post([FromBody]UserModel userModel)
        {
            _context.UserModels.Add(userModel);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody]UserModel userModel)
        {
            _context.Entry(_context.UserModels.Where(x => x.Id == userModel.Id).FirstOrDefault()).CurrentValues.SetValues(userModel);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _context.UserModels.Remove(_context.UserModels.Where(x => x.Id == id).FirstOrDefault());
            _context.SaveChanges();
        }
    }
}
