using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.BLL;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;

namespace MIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private MedicalServiceManager _medicalServiceManager;

        public ProductController(MedicalServiceManager medicalServiseManager)
        {
            _medicalServiceManager = medicalServiseManager;
        }

        /// <summary>
        /// Возвращает полный список медицинских услуг.
        /// Доступен для всех
        /// </summary>
        /// 
       [HttpGet("all")]
        public ActionResult<IEnumerable<MedicalServiceOutputModel>> GetAll()
        {
            return Ok(_medicalServiceManager.GetAll());
        }

        /// <summary>
        /// Возвращает список медицинских услуг по Id.
        /// Доступен только для Admin
        /// </summary>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<MedicalServiceOutputModel>> GetById(int id)
        {
            var result = _medicalServiceManager.GetById(id);

            if (result == null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        /// <summary>
        /// Добавляет новую медицинскую услугу.
        /// Доступен только для Admin
        [HttpPost ("Add")]
        [Authorize(Roles = "Admin")]
        public ActionResult<MedicalServiceOutputModel> Add(MedicalServiceInputModel service)
        {
            var result = _medicalServiceManager.Add(service);

            return Ok(result);
        }
    }
}
