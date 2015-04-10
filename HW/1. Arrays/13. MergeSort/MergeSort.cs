using System;

class Merge
{
    private static void DoMerge(int[] numbers, int left, int mid, int right)
    {
        int[] temp = new int[25];
        int i;
        int left_end;
        int num_elements;
        int tmp_pos;

        left_end = (mid - 1);
        tmp_pos = left;
        num_elements = (right - left + 1);

        while ((left <= left_end) && (mid <= right))
        {
            if (numbers[left] <= numbers[mid])
            {
                temp[tmp_pos++] = numbers[left++];
            }
            else
            {
                temp[tmp_pos++] = numbers[mid++];
            }
        }

        while (left <= left_end)
        {
            temp[tmp_pos++] = numbers[left++];
        }

        while (mid <= right)
        {
            temp[tmp_pos++] = numbers[mid++];
        }

        for (i = 0; i < num_elements; i++)
        {
            numbers[right] = temp[right];
            right--;
        }
    }

    private static void MergeSort(int[] numbers, int left, int right)
    {
        int mid;

        if (right > left)
        {
            mid = (right + left) / 2;
            MergeSort(numbers, left, mid);
            MergeSort(numbers, (mid + 1), right);

            DoMerge(numbers, left, (mid + 1), right);
        }
    }

    static void Main(string[] args)
    {
        int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
        int len = 9;

        MergeSort(numbers, 0, len - 1);
        for (int i = 0; i < 9; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }

        Console.WriteLine();
    }
}