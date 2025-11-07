using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.MappingProfiles;
using MIS.Core.OutputModels;
using MIS.Web.IRepositories;

namespace MIS.BLL
{
    public class MedicalServiceManager
    {
        private IMedicalServiceRepository _rep;
        private Mapper _mapper;

        public MedicalServiceManager(IMedicalServiceRepository rep)
        {
            _rep = rep;

            MapperConfiguration configuration = new MapperConfiguration((cfg =>
            {
                cfg.AddProfile(new MedicalServiceMappingProfile());
            }), new LoggerFactory());

            _mapper = new Mapper(configuration);

        }

        public List<MedicalServiceOutputModel> GetAll()
        {
            var dto = _rep.GetAll();
            var result = _mapper.Map<List<MedicalServiceOutputModel>>(dto);
            return result;
        }

        public MedicalServiceOutputModel GetById(int id)
        {
            var dto = _rep.GetById(id);
            var result = _mapper.Map<MedicalServiceOutputModel>(dto);
            return result;
        }

        //public MedicalServiceOutputModel GetByDocId(int id)
        //{
        //    var dto = _rep.GetById(id);
        //    var result = _mapper.Map<MedicalServiceOutputModel>(dto);
        //    return result;
        //}

        public MedicalServiceOutputModel Add(MedicalServiceInputModel inputModel)
        {
            var dto = _mapper.Map<MedicalServiceDto>(inputModel);
            var result = _rep.Add(dto);
            return _mapper.Map<MedicalServiceOutputModel>(result);
        }              

        public bool Update(int id, MedicalServiceOutputModel om)
        {
            var dto = _mapper.Map<MedicalServiceDto>(om);
            var result = _rep.Update(id, dto);
            return true;
        }

        public bool Remove(int id) => _rep.Remove(id);

        public bool Delete(int id) => _rep.Delete(id);

        public bool Exists(int id) => _rep.Exists(id);
    }
}

