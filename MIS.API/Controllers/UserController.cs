using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIS.BLL;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;

namespace MIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private UserManager _userManager;

        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Возвращает весь список список юзеров.
        /// Доступен только для Admin
        /// </summary>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public ActionResult<IEnumerable<MedicalServiceOutputModel>> GetAll()
        {
            return Ok(_userManager.GetAll());
        }

        /// <summary>
        /// Возвращает список список юзеров по Id.
        /// Доступен только для Admin
        /// </summary>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpGet("get/{id:int}")]
        public ActionResult<IEnumerable<UserOutputModel>> GetById(int id)
        {
            var result = _userManager.GetById(id);

            if (result == null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // <summary>
        /// Добавляет нового пользователя.
        /// Доступен только для Admin
        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserOutputModel> Add(UserInputModel service)
        {
            var result = _userManager.Add(service);

            return Ok(result);
        }
    }
}
