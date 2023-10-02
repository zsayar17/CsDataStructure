using System;

public class DataStructures
{
	static void swap(ref int[] array, int index1, int index2)
	{
		if (index1 == index2) return;
		array[index1] = array[index1] ^ array[index2];
		array[index2] = array[index1] ^ array[index2];
		array[index1] = array[index1] ^ array[index2];
	}

	static int sort(ref int[] array, int low, int high)
	{
		int index = low - 1;
		int pivot = array[high];

		for (int i = low; i < high; i++) if (array[i] <= pivot) swap(ref array, ++index, i);
		swap(ref array, ++index, high);
		return (index);
	}

	static void quick(ref int[] array, int low, int high)
	{
		int pivot_index;

		if (low >= high) return;
		pivot_index = sort(ref array, low, high);
		quick(ref array, low, pivot_index - 1);
		quick(ref array, pivot_index + 1, array.Length - 1);
	}
	static void quickSort() //QUICK SORT
	{
		int[] array1 = {21, 13, 44, 35, 66};
		int[] array2 = {1, 22, 3, 4, 45, 6};
		int[] commanarray = new int[array1.Length + array2.Length];

		int i = 0;
		for (int j = 0; j < array1.Length; j++) commanarray[i++] = array1[j];
		for (int j = 0; j < array2.Length; j++) commanarray[i++] = array2[j];
		quick(ref commanarray, 0, commanarray.Length - 1)
		for (int j = 0; j < array2.Length; j++) Console.Write(commanarray[j] + " ");
		Console.WriteLine();
	}

	static int findMax(int[] arr)
	{
		int max = arr[0];

		for (int i = 1; i < arr.Length; i++) if (arr[i] > max) max = arr[i];
		return max;
	}

	static void boyerMooreAlgorithm()
	{
		int[] array = { 7, 9, 7, 5, 9, 11, 13 };
		int[] ctr_array = new int[findMax(array) + 1];

		for (int i = 0; i < array.Length; i++) ctr_array[array[i]]++;
		for (int i = 0; i < ctr_array.Length; i++)
		{
			if (ctr_array[i] == 0) continue;
			Console.WriteLine(i + "number " + ctr_array[i] + "count repeated");
		}
	}
	static void sieveOfEratosthenes()
	{
		int limit = 1000;
		bool[] hash_table = new bool[limit + 1];
		int last_index;
		int count = 0;

		for (last_index = 2; last_index < limit;)
		{
			Console.WriteLine(last_index);
			count++;
			hash_table[last_index] = false;
			for (int i = last_index * 2; i <= limit; i += last_index)
			{
			    count++;
			    if (hash_table[i] == false) hash_table[i] = true;
			}
			while (++last_index <= limit && hash_table[last_index] == true) count++;
		}
		Console.WriteLine(count);
	}
	public static void Main(string[] args)
	{
		quickSort();
		boyerMooreAlgorithm();
		sieveOfEratosthenes();
	}
}
