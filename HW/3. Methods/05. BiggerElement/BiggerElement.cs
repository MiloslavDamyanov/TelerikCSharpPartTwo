using System;

class BiggerElement
{
    static void Check(int[] array, int number)
    {
        int currentIndex = 0;
        int? next = null;
        int? previous = null;
        for (int i = 0; i < array.Length; i++)
        {
            if (number == array[i])
            {
                currentIndex = i;
                if (currentIndex == 0)
                {
                    next = array[currentIndex + 1].CompareTo(array[currentIndex]);
                }
                else if (currentIndex >= array.Length - 1)
                {
                    previous = array[currentIndex - 1].CompareTo(array[currentIndex]);
                }
                else if (currentIndex > 0)
                {
                    next = array[currentIndex + 1].CompareTo(array[currentIndex]);
                    previous = array[currentIndex - 1].CompareTo(array[currentIndex]);
                }
            }
        }        
    }


   
    static void Main()
    {
        int[] arr = { 3, 1, 8, 4, 6, 2, 9, 13, 13, 11 };
        Console.Write("3, 1, 8, 4, 6, 2, 9, 13, 13, 11 : ");
        int number = int.Parse(Console.ReadLine());
        Check(arr, number);
    }
}
/*
 * Write a method that checks if the element at given position 
 * in given array of integers is bigger than its two neighbors (when such exist).
 */

/*
* Напишете метод, който проверява дали елемент, намиращ се на дадена позиция от масив,
* е по-голям, или съответно по-малък от двата му съседа. Тествайте метода дали работи коректно.
*/
// 354 страница