﻿public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int j = 0;
        int added = m;
        for (int i = 0; i < nums1.Length; i++)
        {
            if (j < n)
            {
                if (nums2[j] <= nums1[i])
                {
                    int k;
                    for (k = nums1.Length - 1; k > i; k--)
                    {
                        nums1[k] = nums1[k - 1];

                    }
                    nums1[k] = nums2[j++];
                    i++;
                }
                if (m <= 0)
                {
                    nums1[i] = nums2[j++];
                }
                m--;

            }
            
        }

for (int i = 0; i < nums1.Length; i++)
        {
            Console.Write(nums1[i] + " ");
        }
    }
}

public class Test
{
    public static void Main()
    {
        Solution solution = new Solution();
        int[] nums1 = new int[] { 1, 0};
        int[] nums2 = new int[] { 2 };
        solution.Merge(nums1, 1, nums2, nums2.Length);
    }
}