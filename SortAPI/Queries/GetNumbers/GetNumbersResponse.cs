namespace SortAPI.Queries.GetNumbers
{
    public class GetNumbersResponse
    {
        public IEnumerable<int> SortedNumbers { get; set; } = new List<int>();
    }
}
