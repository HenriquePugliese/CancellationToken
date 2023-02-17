namespace Application.Service
{
    public interface ICancellationTokenService
    {
        Task RegisterWithoutTransaction(CancellationToken cancellationToken);
        Task RegisterWithUnitOfWork(CancellationToken cancellationToken);
        Task RegisterWithThirdPartyApi(CancellationToken cancellationToken);
        Task RegisterWithThirdPartyApiTwo(CancellationToken cancellationToken);
    }
}
