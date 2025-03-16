namespace Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        Task Save();
    }
}
