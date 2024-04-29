using AutoMapper;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.DAL.Entities;
using Test.DAL.Repositories;

namespace Test.BLL.Services
{
 
        public interface IAddressService : IBaseService<AddressRequestDTO, AddressResponseDTO>
        {
        Task<IEnumerable<AddressResponseDTO>?> GetByCustomerId(int CustomerId);
    }
        public class AddressService : IAddressService
        {
            private readonly IRepositoryWrapper repositoryWrapper;
            private readonly IMapper mapper;

            public AddressService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
            {
                this.repositoryWrapper = repositoryWrapper;
                this.mapper = mapper;
            }

            public async Task<AddressResponseDTO> Add(AddressRequestDTO requestDTO)
            {
                var address = mapper.Map<Address>(requestDTO);
                var responseAddress = await this.repositoryWrapper.AddressRepository.CreateAsync(address);
                await this.repositoryWrapper.SaveAsync();
                var result = mapper.Map<AddressResponseDTO>(responseAddress);
                return result;
            }

        public async Task<bool> Delete(int id)
        {
            var addresstodelete = await this.repositoryWrapper.AddressRepository.GetById(id);
            if (addresstodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.AddressRepository.DeleteAsync(addresstodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<AddressResponseDTO>> GetAll()
            {
                var address = await this.repositoryWrapper.AddressRepository.GetAllAsync();
                var result = mapper.Map<IEnumerable<AddressResponseDTO>>(address);
                return result;
            }

        public async Task<AddressResponseDTO> GetById(int id)
        {
            var address = await this.repositoryWrapper.AddressRepository.GetById(id);
            var result = mapper.Map<AddressResponseDTO>(address);
            return result;
        }

        public async Task<AddressResponseDTO> Update(int id, AddressRequestDTO requestDTO)
        {
            var f = mapper.Map<Address>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.AddressRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<AddressResponseDTO>(v);
            return k;
        }
        public async Task<IEnumerable<AddressResponseDTO>?> GetByCustomerId(int CustomerId)
        {
            var result = await this.repositoryWrapper.AddressRepository.GetByCustomerId(CustomerId);
            if (result is not null)
            {
                var addressDTO = mapper.Map<IEnumerable<AddressResponseDTO>?>(result);
                return addressDTO;
            }
            else
            {
                return null;
            }
        }
    }
    
}
