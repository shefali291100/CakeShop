using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test.DAL.DBContext;
using Test.DAL.Entities;

namespace Test.DAL.Repositories
{

    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(int id, T entity);

        Task<bool> DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync(); 

        Task<T?> GetById(int id);

        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition);
    }

    public abstract class RepositoryBase<T> : IBaseRepository<T> where T: class
    {
        private readonly CakeContext dbContext;

        private readonly DbSet<T> dbSet;

        public RepositoryBase(CakeContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            var result = await this.dbSet.AddAsync(entity);
            return result.Entity;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            var result = this.dbSet.Remove(entity);
            return Task.FromResult(result.Entity is not null);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = this.dbSet.AsEnumerable();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            var result = this.dbSet.Where(condition);
            return await Task.FromResult(result);
        }

        public async Task<T?> GetById(int id)
        {
           return await this.dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var dbEntity = await this.dbSet.FindAsync(id);
            if (dbEntity == null)
                throw new KeyNotFoundException($"Resource with Id:{id} not Found");
            dbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            return entity;
        }
    }

    public interface ICakeRepository : IBaseRepository<Cake> { }

    public class CakeRepository : RepositoryBase<Cake>, ICakeRepository 
    {
        public CakeRepository(CakeContext dbContext) : base(dbContext) 
        {
        }
    
    }

    public interface ICustomerRepository : IBaseRepository<Customer> { }

    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CakeContext dbContext) : base(dbContext)
        {
        }

    }

    public interface IAddressRepository : IBaseRepository<Address> {
        Task<IEnumerable<Address>?> GetByCustomerId(int CustomerId);
    }

    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        private readonly CakeContext dbContext;
        public AddressRepository(CakeContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Address>?> GetByCustomerId(int CustomerId)
        {
            var address = dbContext.Addresses.Where(x => x.CustomerId == CustomerId);
            if (address is not null) return await Task.FromResult(address.AsEnumerable());
            return null;
        }

    }

    public interface IOrderRepository : IBaseRepository<Order> {
        Task<IEnumerable<Order>?> GetByUserId(int UserId);
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly CakeContext dbContext;
        public OrderRepository(CakeContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Order>?> GetByUserId(int UserId)
        {
            var order = dbContext.Orders.Where(x => x.UserId == UserId);
            if (order is not null) return await Task.FromResult(order.AsEnumerable());
            return null;
        }

    }

    public interface IOrderDetailRepository : IBaseRepository<OrderDetail> {
        Task<IEnumerable<OrderDetail>?> GetByOrderId(int OrderId);
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        private readonly CakeContext dbContext;
        public OrderDetailRepository(CakeContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<OrderDetail>?> GetByOrderId(int OrderId)
        {
            var orderdetail = dbContext.OrderDetails.Where(x => x.OrderId == OrderId);
            if (orderdetail is not null) return await Task.FromResult(orderdetail.AsEnumerable());
            return null;
        }

    }

    //public interface ICartRepository : IBaseRepository<Cart> 
   // {
     //   Task<IEnumerable<Cart>>  
    //}
    public interface ICartRepository : IBaseRepository<Cart> { }

    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(CakeContext dbContext) : base(dbContext)
        {
        }

    }

    public interface ILoginRepository : IBaseRepository<Customer> {
        Task<Customer?> ValidateUser(string email, string password);
    }

    public class LoginRepository : RepositoryBase<Customer>, ILoginRepository
    {
        private readonly CakeContext dbContext;

        public LoginRepository(CakeContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Customer?> ValidateUser(string email, string password)
        {
            var customer = await dbContext.Customers
            //.Include(x => x.IsAdmin)
            .FirstOrDefaultAsync(x => x.Email == email && x.PasswordHash == password);
            if (customer is not null) return customer;
            return null;

        }
    }

    public interface IRepositoryWrapper
    {
        public ICakeRepository CakeRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IAddressRepository AddressRepository { get; set; }
        public IOrderRepository OrderRepository { get;set; }
        public IOrderDetailRepository OrderDetailRepository { get; set; }
        public ICartRepository CartRepository { get; set; }
        public ILoginRepository LoginRepository { get; set; }   

        Task<int> SaveAsync();
    
    }


    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly CakeContext dbContext;

        public ICakeRepository CakeRepository { get; set ; }
        public ICustomerRepository CustomerRepository { get; set ; }
        public IAddressRepository AddressRepository { get; set ; }
        public IOrderRepository OrderRepository { get ; set ; }
        public IOrderDetailRepository OrderDetailRepository { get ; set; }
        public ICartRepository CartRepository { get ; set ; }
        public ILoginRepository LoginRepository { get; set; }
        public RepositoryWrapper(CakeContext dbContext)
        {
            this.dbContext = dbContext;

            CakeRepository = new CakeRepository(dbContext);
            CustomerRepository = new CustomerRepository(dbContext);
            AddressRepository = new AddressRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
            OrderDetailRepository = new OrderDetailRepository(dbContext);
            CartRepository = new CartRepository(dbContext);
            LoginRepository = new LoginRepository(dbContext);
        }

        public async Task<int>  SaveAsync()
        {
            return await this.dbContext.SaveChangesAsync();
            
        }

    }
}
