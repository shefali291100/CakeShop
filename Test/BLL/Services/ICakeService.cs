using AutoMapper;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.DAL.Entities;
using Test.DAL.Repositories;

namespace Test.BLL.Services
{
   
        public interface ICakeService : IBaseService<CakeRequestDTO, CakeResponseDTO>
        {
        }
    public class CakeService : ICakeService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public CakeService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<CakeResponseDTO> Add(CakeRequestDTO requestDTO)
        {
            var cake = mapper.Map<Cake>(requestDTO);
            var responseCake = await this.repositoryWrapper.CakeRepository.CreateAsync(cake);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<CakeResponseDTO>(responseCake);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var caketodelete = await this.repositoryWrapper.CakeRepository.GetById(id);
            if (caketodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.CakeRepository.DeleteAsync(caketodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<CakeResponseDTO>> GetAll()
        {
            var cake = await this.repositoryWrapper.CakeRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<CakeResponseDTO>>(cake);
            return result;
        }

        public async Task<CakeResponseDTO> GetById(int id)
        {
            var cake = await this.repositoryWrapper.CakeRepository.GetById(id);
            var result = mapper.Map<CakeResponseDTO>(cake);
            return result;
        }

        public async Task<CakeResponseDTO> Update(int id, CakeRequestDTO requestDTO)
        {
            var f = mapper.Map<Cake>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.CakeRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<CakeResponseDTO>(v);
            return k;
        }
    }

}
