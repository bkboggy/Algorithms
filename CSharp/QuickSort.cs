using System;
using System.Collections.Generic;
using System.Text;
					
public class Program
{
	public static void Main()
	{
		var data = new [] { 7, 5, 10, 2, 4, 1, -1, 11, 6, 3, -2, 0, 9 };
		PrintIEnumerable(data);
		Func<int, int, int> compareInt = (a, b) => (a < b) ? -1 : (a > b) ? 1 : 0;
		QuickSort(data, compareInt);
	}
	
	public static void QuickSort<T>(T[] data, Func<T, T, int> compare)
	{
		Sort(data, 0, data.Length - 1, compare);
	}
	
	public static void Sort<T>(T[] data, int i, int r, Func<T, T, int> compare)
	{
		if (i < r)
		{
			var p = Partition(data, i, r, compare);
			Sort(data, i, p - 1, compare);
			Sort(data, p + 1, r, compare);
		}
	}
	
	public static int Partition<T>(T[] data, int i, int r, Func<T, T, int> compare)
	{
		var pivot = data[r];
		
		for (var j = i; j < r; ++j)
		{
			if (compare(data[j], pivot) < 0)
			{
				Swap(ref data[i], ref data[j]);
				++i;
			}
		}
		
		Swap(ref data[i], ref data[r]);		
		PrintIEnumerable(data);
		
		return i;
	}
	
	public static void Swap<T>(ref T a, ref T b)
	{
		var temp = a;
		a = b;
		b = temp;
	}
	
	public static void PrintIEnumerable<T>(IEnumerable<T> data)
	{
		var sb = new StringBuilder();
		foreach (var item in data)
		{
			sb.Append($"{item}, ");
		}
		var s = sb.ToString(0, sb.Length - 2);
		Console.WriteLine(s);
	}
}
