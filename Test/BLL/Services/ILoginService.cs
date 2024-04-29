using AutoMapper;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.DAL.Repositories;

namespace Test.BLL.Services
{
    public interface ILoginService
    {
        Task<LoginResponseDTO?> IsValidUser(LoginRequestDTO LoginRequestDTO);
    }
    public class LoginService : ILoginService
    {

        private readonly IRepositoryWrapper repositoryWrapper;

        public LoginService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }


        public async Task<LoginResponseDTO?> IsValidUser(LoginRequestDTO LoginRequestDTO)
        {
            var customer = await this.repositoryWrapper.LoginRepository.ValidateUser(LoginRequestDTO.Email, LoginRequestDTO.PasswordHash);
            if (customer is not null)
            {
                
                return new LoginResponseDTO
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    PasswordHash = customer.PasswordHash,
                    PhoneNo = customer.PhoneNo,
                    IsAdmin = customer.IsAdmin,

                };
            }
            return null;
        }
    }
}

