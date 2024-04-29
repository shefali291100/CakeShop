using AutoMapper;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.DAL.Entities;
using Test.DAL.Repositories;

namespace Test.BLL.Services.ICustomerService
{
        public interface ICustomerService : IBaseService<CustomerRequestDTO, CustomerResponseDTO>
        {
        }
        public class CustomerService : ICustomerService
        {
            private readonly IRepositoryWrapper repositoryWrapper;
            private readonly IMapper mapper;

            public CustomerService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
            {
                this.repositoryWrapper = repositoryWrapper;
                this.mapper = mapper;
            }

            public async Task<CustomerResponseDTO> Add(CustomerRequestDTO requestDTO)
            {
                var customer = mapper.Map<Customer>(requestDTO);
                var responseCustomer = await this.repositoryWrapper.CustomerRepository.CreateAsync(customer);
                await this.repositoryWrapper.SaveAsync();
                var result = mapper.Map<CustomerResponseDTO>(responseCustomer);
                return result;
            }

            public async Task<bool> Delete(int id)
            {
                var customertodelete = await this.repositoryWrapper.CustomerRepository.GetById(id);
                if (customertodelete == null)
                {
                    return false;
                }
                await this.repositoryWrapper.CustomerRepository.DeleteAsync(customertodelete);
                await this.repositoryWrapper.SaveAsync();
                return true;
            }

            public async Task<IEnumerable<CustomerResponseDTO>> GetAll()
            {
                var customer = await this.repositoryWrapper.CustomerRepository.GetAllAsync();
                var result = mapper.Map<IEnumerable<CustomerResponseDTO>>(customer);
                return result;
            }

        public async Task<CustomerResponseDTO> GetById(int id)
        {
            var customer = await this.repositoryWrapper.CustomerRepository.GetById(id);
            var result = mapper.Map<CustomerResponseDTO>(customer);
            return result;
        }

        public async Task<CustomerResponseDTO> Update(int id, CustomerRequestDTO requestDTO)
        {
            var f = mapper.Map<Customer>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.CustomerRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<CustomerResponseDTO>(v);
            return k;
        }
    }
    }