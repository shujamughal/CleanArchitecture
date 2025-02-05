namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }
        Task Save();
    }
}
