using MediatR;

namespace SortAPI.Commands.SortAndSaveNumbersCommand
{
    public class SortAndSaveNumbersCommand : IRequest
    {
        public IEnumerable<int> Numbers { get; set; } = new List<int>();
    }
}
