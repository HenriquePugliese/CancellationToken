using Application.Data;
using Application.Models;
using Newtonsoft.Json;

namespace Application.Service
{
    public class CancellationTokenService : ICancellationTokenService
    {
        private readonly ILogger<CancellationTokenService> _logger;
        private readonly DataContext _dataContext;

        public CancellationTokenService(ILogger<CancellationTokenService> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        public async Task RegisterWithoutTransaction(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando");
            var userName = $"User-{Guid.NewGuid()}";
            _dataContext.Logins.Add(new Login(userName));

            await Task.Delay(5000, cancellationToken);

            var statistics = _dataContext.Statistics.FirstOrDefault();
            if (statistics is null)
            {
                statistics = new Statistics();
                _dataContext.Add(statistics);
            }
            statistics.Accounts++;

            await _dataContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Finalizando");
        }

        public async Task RegisterWithUnitOfWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando");
            var userName = $"User-{Guid.NewGuid()}";
            _dataContext.Logins.Add(new Login(userName));

            await Task.Delay(5000, cancellationToken);

            var statistics = _dataContext.Statistics.FirstOrDefault();
            if (statistics is null)
            {
                statistics = new Statistics();
                _dataContext.Add(statistics);
            }
            statistics.Accounts++;

            await _dataContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Finalizando");
        }

        public async Task RegisterWithThirdPartyApi(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando");
            var userName = $"User-{Guid.NewGuid()}";
            var login = new Login(userName);

            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(login);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await httpClient.PostAsync("https://localhost:5003/api/Login", httpContent, cancellationToken);

            _dataContext.Logins.Add(login);

            var statistics = _dataContext.Statistics.FirstOrDefault();
            if (statistics is null)
            {
                statistics = new Statistics();
                _dataContext.Add(statistics);
            }
            statistics.Accounts++;

            await _dataContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Finalizando");
        }

        public async Task RegisterWithThirdPartyApiTwo(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando");
            var userName = $"User-{Guid.NewGuid()}";
            var login = new Login(userName);

            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(login);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await httpClient.PostAsync("https://localhost:5003/api/Login2", httpContent, cancellationToken);

            _dataContext.Logins.Add(login);

            var statistics = _dataContext.Statistics.FirstOrDefault();
            if (statistics is null)
            {
                statistics = new Statistics();
                _dataContext.Add(statistics);
            }
            statistics.Accounts++;

            await _dataContext.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Finalizando");
        }
    }
}
