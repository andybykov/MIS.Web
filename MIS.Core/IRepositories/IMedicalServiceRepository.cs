using MIS.Core.Dtos;

namespace MIS.Web.IRepositories
{
    public interface IMedicalServiceRepository
    {
        public List<MedicalServiceDto> GetAll();

        public List<MedicalServiceDto> GetAllWithRemoved();

        public MedicalServiceDto GetById(int id);

        public MedicalServiceDto Add(MedicalServiceDto dto);

        public bool Update(int id, MedicalServiceDto dto);

        public bool Delete(int id);

        bool Remove(int id);

        public bool Exists(int id); //проверка существует ли запись
    }
}
