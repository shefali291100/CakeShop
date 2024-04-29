using AutoMapper;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.DAL.Entities;
using Test.DAL.Repositories;

namespace Test.BLL.Services
{
    public interface IOrderDetailService : IBaseService<OrderDetailRequestDTO, OrderDetailResponseDTO>
    {
        Task<IEnumerable<OrderDetailResponseDTO>?> GetByOrderId(int OrderId);
    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public OrderDetailService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<OrderDetailResponseDTO> Add(OrderDetailRequestDTO requestDTO)
        {
            var orderdetail = mapper.Map<OrderDetail>(requestDTO);
            var responseOrderDetail = await this.repositoryWrapper.OrderDetailRepository.CreateAsync(orderdetail);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<OrderDetailResponseDTO>(responseOrderDetail);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var orderdetailtodelete = await this.repositoryWrapper.OrderDetailRepository.GetById(id);
            if (orderdetailtodelete == null)
            {
                return false;
            }
            await this.repositoryWrapper.OrderDetailRepository.DeleteAsync(orderdetailtodelete);
            await this.repositoryWrapper.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<OrderDetailResponseDTO>> GetAll()
        {
            var orderdetail = await this.repositoryWrapper.OrderDetailRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<OrderDetailResponseDTO>>(orderdetail);
            return result;
        }

        public async Task<OrderDetailResponseDTO> GetById(int id)
        {
            var order = await this.repositoryWrapper.OrderDetailRepository.GetById(id);
            var result = mapper.Map<OrderDetailResponseDTO>(order);
            return result;
        }

        public async Task<OrderDetailResponseDTO> Update(int id, OrderDetailRequestDTO requestDTO)
        {
            var f = mapper.Map<OrderDetail>(requestDTO);
            f.Id = id;
            var v = await repositoryWrapper.OrderDetailRepository.UpdateAsync(id, f);
            await repositoryWrapper.SaveAsync();
            var k = mapper.Map<OrderDetailResponseDTO>(v);
            return k;
        }

        public async Task<IEnumerable<OrderDetailResponseDTO>?> GetByOrderId(int OrderId)
        {
            var result = await this.repositoryWrapper.OrderDetailRepository.GetByOrderId(OrderId);
            if (result is not null)
            {
                var orderdetailDTO = mapper.Map<IEnumerable<OrderDetailResponseDTO>?>(result);
                return orderdetailDTO;
            }
            else
            {
                return null;
            }
        }
    }
     
}
