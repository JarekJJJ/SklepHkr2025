namespace SklepHkr2025.Services.Incom
{
    public interface IIncomService
    {
        Task AddIncomGroup(string connectionId);
        Task AddProducentDetail(string connectionId);
    }
}
