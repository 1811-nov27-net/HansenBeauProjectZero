using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    /// <summary>
    /// I want a list of lists of orders (dictionary would allow me to
    /// pair user fName and lName with orders. Key = userName and 
    /// entry = list of orders.
    /// I need this class to 
    /// 
    /// </summary>
    public class OrderStorageDict : IDictionary
    {
        public OrderStorageDict()
        {
        }

        object IDictionary.this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        bool IDictionary.IsFixedSize => throw new NotImplementedException();

        bool IDictionary.IsReadOnly => throw new NotImplementedException();

        ICollection IDictionary.Keys => throw new NotImplementedException();

        ICollection IDictionary.Values => throw new NotImplementedException();

        int ICollection.Count => throw new NotImplementedException();

        bool ICollection.IsSynchronized => throw new NotImplementedException();

        object ICollection.SyncRoot => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        void IDictionary.Add(object key, object value)
        {
            throw new NotImplementedException();
        }

        void IDictionary.Clear()
        {
            throw new NotImplementedException();
        }

        bool IDictionary.Contains(object key)
        {
            throw new NotImplementedException();
        }

        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        void IDictionary.Remove(object key)
        {
            throw new NotImplementedException();
        }
    }
}
