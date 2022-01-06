namespace SortAPI.Services.SortingService
{
    public interface ISortingService
    {
        IEnumerable<int> Sort(IEnumerable<int> numbers);
    }
}
