using System;
/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100  
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                List<int> uniqueElements = new List<int>();
                for (int i = 0; i < nums.Length; i++) // Looping through the array
                {
                    if (!uniqueElements.Contains(nums[i])) // Checking if the element is present in the list
                    {
                        uniqueElements.Add(nums[i]); // adding it to the list if the element is not in the list.
                    }
                }
                return uniqueElements.Count; // Return the count of elements in the List
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
       Self-Reflection:
       This solution removes duplicates from the input array by utilizing a List to keep
       track of unique elements. One potential improvement could be to use a HashSet instead of a List for better 
        performance when checking for element existence, as HashSet has constant-time complexity for lookup operations. 
        The function focuses on determining the number of unique elements rather than directly modifying the original 
        array. It includes a try-catch block for general exception handling, but potential for more specific 
        exception types remains.
        */

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Initializing an empty list to store the result
                List<int> result = new List<int>();

                // Initializing  counter to keep track of the number of zeroes encountered
                int count = 0;

                // Iterate through each element in the input array
                foreach (int num in nums)
                {
                    // If the current element is not zero, adding it to the result list
                    if (num != 0)
                        result.Add(num);
                    else
                        count++; // Adding the count of zeroes encountered
                }

                // Adding the required number of zeroes to the end of the result list
                result.AddRange(Enumerable.Repeat(0, count));

                // Returning the resulting list
                return result;
            }
            catch (Exception)
            {
                throw; 
            }
        }



        /*
        Self-Reflection:
        This solution moves all non-zero elements to the beginning of the array 
        while maintaining their relative order, by utilizing a two-pointer approach. The solution achieves the task 
        in-place without using additional space, which is required by the problem statement.
        The code iterates through the array twice and the code maintains a separate counter variable count to 
        track the number of zeroes encountered.
         */


        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.



        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.


        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Initializing the result list
                IList<IList<int>> result = new List<IList<int>>();

                // Checking for null input or array length less than 3
                if (nums == null || nums.Length < 3)
                    return result;

                // Sorting the input array
                Array.Sort(nums);


                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skipping the duplicates
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    int l = i + 1;
                    int r = nums.Length - 1;

                    while (l < r)
                    {
                        int sum = nums[i] + nums[l] + nums[r];

                        // Adding the triplet to the result when the sum is zero
                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[i], nums[l], nums[r] });

                            // Skipping the duplicates for the second and third pointers
                            while (l < r && nums[l] == nums[l + 1])
                                l++;
                            while (l < r && nums[r] == nums[r - 1])
                                r--;

                            // Moving the pointers
                            l++;
                            r--;
                        }
                        // Incresing the sum, if the sum is less than zero
                        else if (sum < 0)
                        {
                            l++;
                        }
                        // Decreasing the sum, if the sum is greater than zero
                        else
                        {
                            r--;
                        }
                    }
                }

                // Returning the result
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         Self-reflection:
         This problem is an example of the three-pointer approach, where we use three pointers
        to traverse the array and find triplets that sum up to a target value. By sorting the array first, 
        we can optimize the process. Additionally, we skip duplicates to ensure unique triplets in the result.
        
        */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2

        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {

                int i = 0; // to store the maximum consecutive 1s
                int j = 0; // to track current consecutive 1s

                // Iterate through the array
                foreach (int num in nums)
                {
                    // Increasing the j and update i with the maximum consecutive count when the element is 1
                    if (num == 1)
                    {
                        j++;
                        i = Math.Max(i, j);
                    }
                    // Resetting j to 0 when the number is not 1
                    else
                    {
                        j = 0;
                    }
                }

                // Returning the maximum consecutive count
                return i;
            }
            // Catching exceptions and rethrow them
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Self-reflection:
        In this problem, we are iterating through an array and tracking consecutive 1s. The code provided 
        utilizes two pointers, i and j, to track the length of consecutive 1s. This approach efficiently
        finds the maximum number of consecutive 1s in the array.
         */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int dv = 0; // Initializing the decimal value
                int bv = 1; // Base value for the binary place value calculation

                while (binary > 0) // Iterate through the binary digits from right to left
                {
                    int ld = binary % 10; // Extracting the last digit in the binary number
                    binary = binary / 10; // Removing the last digit from the binary number

                    dv += ld * bv; // Multiplying the last digit with its place value and adding it to the decimal value
                    bv *= 2; // Incrementing the base value for the next place value
                }

                return dv;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.


        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Checking the case of an array contains less than two elements
                if (nums == null || nums.Length < 2)
                    return 0;

                // Sorting the array in ascending order
                Array.Sort(nums);

                int maxDiff = 0; // Initializing the variable

                // finding the maximum difference between successive elements
                for (int i = 1; i < nums.Length; i++)
                {
                    // Calculate the difference between the elements
                    int diff = nums[i] - nums[i - 1];

                    // Updating the maximum difference if the current difference is greater
                    maxDiff = Math.Max(maxDiff, diff);
                }

                // Returning the maximum difference
                return maxDiff;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        Self-reflection:
        This problem finds the maximum difference between two successive elements in a given array. 
        The provided solution sorts the array and then iterates through it to find the maximum difference. 
        Arranging the elements in the ascending order makes it easy to compute the differences. 
        
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Checking for an array contains less than three elements
                if (nums == null || nums.Length < 3)
                    return 0;

                // Sorting the array in ascending order
                Array.Sort(nums);

                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Checking if the current element and the two preceding elements can form a triangle
                    if (nums[i - 2] + nums[i - 1] > nums[i])
                        return nums[i - 2] + nums[i - 1] + nums[i]; // Returning the largest valid triangle perimeter
                }

                return 0; // Returning zero if no valid triangle found 
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Self-reflection:
        This problem finds the largest perimeter of a triangle that can be formed using three 
        side lengths from a given array. It's essential to understand the triangle inequality theorem, 
        which states that the sum of the lengths of any two sides of a triangle must be greater than 
        the length of the third side. The solution sorts the array and iterates from the 
        end to find the largest valid triangle perimeter efficiently.
         */


        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.



        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Iterating until all the substrings are removed
                int i;
                while ((i = s.IndexOf(part)) != -1)
                {
                    // Finding the leftmost occurrence of the substring and removing it from the original string
                    s = s.Remove(i, part.Length);
                }
                return s; // Returning the string after all occurrences of the substring are removed
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
/*
Self-reflection:
This problem removes occurrences of a substring from a given string until no more occurrences are left. 
This solution efficiently utilizes the IndexOf method to find the leftmost occurrence of the substring and then 
removes it using the Remove method. 
*/

