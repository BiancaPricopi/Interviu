public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        int mid;
        while (left < right)
        {
            mid = (left + right) / 2;

            if (target > nums[mid])
            {
                left = mid + 1;
            }
            else if(target < nums[mid])
            {
                right = mid - 1;
            }
            else
            {
                return mid;
            }
        }
        if(target <= nums[left])
        {
            return left;
        }
        else
        {
            return left + 1;
        }

    }
}

public class Test
{
    public static void Main()
    {


        Solution solution = new Solution();
        int[] nums = { 1, 3, 6, 9 };

        Console.Write(solution.SearchInsert(nums, 10));

    }
}