// using System;

// public class SimpleHashTable
// {
//     private int size = 10;
//     private string[] keys;
//     private int[] values;

//     public SimpleHashTable()
//     {
//         keys = new string[size]; // Stores keys
//         values = new int[size]; // Stores values
//     }

//     private int GetHash(string key)
//     {
//         int hash = 0;
//         foreach (char c in key)
//         {
//             hash += c;
//         }
//         // Modulo ensures hash is within the range of indices
//         return hash % size;
//     }

//     public void Insert(string key, int value)
//     {
//         int index = GetHash(key);
        
//         // If the key matches or the slot is empty, insert or overwrite the value
//         if (keys[index] == key || keys[index] == null)
//         {
//             keys[index] = key;
//             values[index] = value;
//         }
//         else
//         {
//             throw new InvalidOperationException("Hash collision occurred");
//         }
//     }

//     public int? GetValue(string key)
//     {
//         int index = GetHash(key);

//         // If the key is found, return the value; otherwise, return null
//         if (keys[index] == key)
//         {
//             return values[index];
//         }
//         return null;
//     }
// }