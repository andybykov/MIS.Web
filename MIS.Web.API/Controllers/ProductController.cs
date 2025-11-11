using MIS.BLL;
using MIS.Core;
using MIS.Core.OutputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MIS.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private MedicalServiceManager _productServise;

        public ProductController(ProductServise productServise)
        {
            _productServise = productServise;
        }

        [HttpGet("all", Name = "Получить все продукты")]
        public ActionResult<IEnumerable<ProductOutputModel>> GetAll()
        {
            var result = _productServise.GetAll();

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public ActionResult<ProductOutputModel> GetById(int id)
        {
            try
            {
                var result = GetProductById(id);
                return Ok(result);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ProductOutputModel> Add(ProductInputModel product)
        {
            var result = _productServise.Add(product);

            return Ok(result);
        }


        private ProductOutputModel GetProductById(int id)
        {
            var tmp = _productServise.GetAll();

            var result = tmp.Single(p => p.Id == id);

            return result;
        }
    }
}
