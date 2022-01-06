using MediatR;
using SortAPI.Commands.SortAndSaveNumbersCommand;
using SortAPI.Services.SortingService;

namespace SortAPI.CommandHandlers
{
    public class SortedNumbersCommandHandler : IRequestHandler<SortAndSaveNumbersCommand>
    {
        private readonly IConfiguration _configuration;
        private readonly ISortingService _sortingService;
        public SortedNumbersCommandHandler(IConfiguration configuration, ISortingService sortingService)
        {
            _configuration = configuration;
            _sortingService = sortingService;
        }

        public async Task<Unit> Handle(SortAndSaveNumbersCommand command, CancellationToken token)
        {
            var filePath = _configuration["FileSettings:Path"];
            var sortedNumbers = _sortingService.Sort(command.Numbers);

            File.WriteAllText(filePath, String.Join(' ', sortedNumbers));

            return Unit.Value;
        }
    }
}
