using MediatR;
using SortAPI.Queries.GetNumbers;

namespace SortAPI.QueryHandlers
{
    public class SortedNumbersQueryHandler : IRequestHandler<GetNumbersQuery, GetNumbersResponse>
    {
        private readonly IConfiguration _configuration;
        public SortedNumbersQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public async Task<GetNumbersResponse> Handle(GetNumbersQuery request, CancellationToken token)
        {
            var filePath = _configuration["FileSettings:Path"];

            var response = new GetNumbersResponse();

            if(!File.Exists(filePath))
            {
                return response;
            }

            var numbersString = await File.ReadAllTextAsync(filePath); 

            if(String.IsNullOrWhiteSpace(numbersString))
            {
                return response;
            }

            var sortedNumbers = numbersString.Split(' ').Select(n => int.Parse(n));

            response.SortedNumbers = sortedNumbers;

            return response;
        }
    }
}
