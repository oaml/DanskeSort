namespace SortAPI.Services.SortingService
{
    public class BubbleSortService : ISortingService
    {
        public BubbleSortService()
        {

        }

        public IEnumerable<int> Sort(IEnumerable<int> numbers)
        {
            var numberArray = numbers.ToArray();

            //This was copy pasted, sorry
            int n = numberArray.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (numberArray[j] > numberArray[j + 1])
                    {
                        int temp = numberArray[j];
                        numberArray[j] = numberArray[j + 1];
                        numberArray[j + 1] = temp;
                    }

            return numberArray;
        }

    }
}
