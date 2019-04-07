using Appliances.data.Models.UserManagement;
using Appliances.Kernel.Framework.Modules.StoreManagement;
using Appliances.Kernel.Framework.Modules.UserManagement;
using Appliances.Kernel.Framework.Repository;
using Appliances.Kernel.Framework.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Appliances.data.Controllers
{
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        private IRepository<AppUser> _userRepository = new Repository<AppUser>();

        /// <summary>
        /// Get all User
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<UserDTO>))]
        public IHttpActionResult GetUser()
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Reading))
            {
                var users = _userRepository.Find(new GetAllSpecification<AppUser>()).OrderBy(x => x.FirstName);
                if (users == null)
                    return NotFound();

                return Ok(users.ToList());
            }
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<UserDTO>))]
        public IHttpActionResult Post(UserDTO userDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                AppUser user = AppUser.Create(userDTO.FirstName, userDTO.LastName, userDTO.EmailId, userDTO.PhoneNo,userDTO.Password);
                _userRepository.Add(user);
                unitOfWork.SaveChanges();

                return GetUser();
            }
        }
        /// <summary>
        /// Update User
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<UserDTO>))]
        public IHttpActionResult Put(UserDTO userDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                var userRep = _userRepository.GetById(userDTO.Id);
                if (userRep == null)
                {
                    return NotFound();
                }
                userRep.Update(userDTO.FirstName, userDTO.LastName,userDTO.EmailId, userDTO.PhoneNo);
                unitOfWork.SaveChanges();

                return Ok(GetDTO(userRep));
            }
        }
        

        private UserDTO GetDTO(AppUser user)
        {
            UserDTO userDTO = new UserDTO();
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.EmailId = user.EmailId;
            userDTO.PhoneNo = user.PhoneNo;
            return userDTO;
        }
    }
}