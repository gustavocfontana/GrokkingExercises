internal class BinarySearchClass
{
    static int BinarySearch(int[] sortedList, int target)
    {
        var left = 0;
        var right = sortedList.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (sortedList[mid] == target)
            {
                return mid;
            }
            else if (sortedList[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}