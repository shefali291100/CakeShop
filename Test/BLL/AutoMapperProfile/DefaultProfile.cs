using AutoMapper;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.DAL.Entities;

namespace Test.BLL.AutoMapperProfile
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<CakeRequestDTO, Cake>();
            CreateMap<Cake, CakeResponseDTO>();

            CreateMap<CartRequestDTO, Cart>();
            CreateMap<Cart, CartResponseDTO>();

            CreateMap<OrderDetailRequestDTO, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailResponseDTO>();

            CreateMap<OrderRequestDTO, Order>();
            CreateMap<Order, OrderResponseDTO>();

            CreateMap<AddressRequestDTO, Address>();
            CreateMap<Address, AddressResponseDTO>();

            CreateMap<CustomerRequestDTO, Customer>();
            CreateMap<Customer, CustomerResponseDTO>();

            CreateMap<LoginRequestDTO, Customer>();
            CreateMap<Customer,  LoginResponseDTO>();
        }

        
    }
}
