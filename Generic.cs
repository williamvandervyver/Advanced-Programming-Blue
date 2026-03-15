using System;
using System.Collections.Generic;

public class Box<T>
{
    private T item;

    public void SetItem(T newItem)
    {
        item = newItem;
    }

    public T GetItem()
    {
        return item;
    }
}

public class SortedCollection<T> where T : IComparable<T>
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
        items.Sort(); // Sort automatically whenever a new item is added
    }

    public void PrintAll()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}

public class Transaction : IComparable<Transaction>
{
    public decimal Amount { get; set; }

    public int CompareTo(Transaction other)
    {
        return Amount.CompareTo(other.Amount);
    }

    public override string ToString()
    {
        return $"Transaction Amount: {Amount:C}";
    }
}