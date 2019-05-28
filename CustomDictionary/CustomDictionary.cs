using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    public class CustomDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {        
        private struct KeyValue
        {
            public TKey key;
            public TValue value;
        }

        private IEqualityComparer<TKey> _comparer;
        private KeyValue[] keyValuePairs;
        private ICollection<TKey> _keys;
        private ICollection<TValue> _values;

        public CustomDictionary(IEqualityComparer<TKey> comparer)
        {
            _comparer = comparer;
            Count = 0;
        }
        public TValue this[TKey key]
        {
            get => keyValuePairs
                .Single(keyValuePair => _comparer.Equals(key, keyValuePair.key))
                .value;
            set
            {
                if (keyValuePairs == null)
                    Initialize();
                for (int i=0; i<keyValuePairs.Length; i++)
                {
                    if (_comparer.Equals(keyValuePairs[i].key, key))
                    {
                        keyValuePairs[i].value = value;
                    }                   
                }
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                if (_keys == null)
                    _keys = new KeyCollection(this);
                return _keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                if (_values == null)
                    _values = new ValueCollection(this);
                return _values;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false; 

        private void Initialize()
        {
            keyValuePairs = new KeyValue[5];
            Count = 0;
        }
        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));            
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (keyValuePairs == null)
                Initialize();
            if (Count >= keyValuePairs.Length)
                Resize();

            if (ContainsKey(item.Key))
                throw new ArgumentException("Key is already exists");

            keyValuePairs[Count] = new KeyValue()
            {
                key = item.Key,
                value = item.Value,
            };
            Count++;
        }

        void Resize()
        {
            KeyValue[] newKeyValuePairs = new KeyValue[Count + 5];
            Array.Copy(keyValuePairs, newKeyValuePairs, keyValuePairs.Length);
            keyValuePairs = newKeyValuePairs;
        }

        public void Clear()
        {
            Keys.Clear();
            Values.Clear();
            keyValuePairs = new KeyValue[0];
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            KeyValue keyValue = new KeyValue()
            {
                key = item.Key,
                value = item.Value
            };
            return keyValuePairs.Contains(keyValue);
        }

        public bool ContainsKey(TKey key)
        {
            return Keys.Count == 0 ? false : Keys.Any(item => Comparer.Equals(item, key));
        }

        public bool ContainsValue(TValue value)
        {
            return Values.Count == 0 ? false : Keys.Any(item => Comparer.Equals(item, value));
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new Enumerator(this);
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public class Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            CustomDictionary<TKey, TValue> _dictionary;
            KeyValuePair<TKey, TValue> _currentValue;
            int _currentIndex;
            public Enumerator(CustomDictionary<TKey, TValue> dictionary)
            {
                _dictionary = dictionary;
                _currentIndex = 0;
                _currentValue = new KeyValuePair<TKey, TValue>(default(TKey), default(TValue));
            }
            public KeyValuePair<TKey, TValue> Current => _currentValue;

            object IEnumerator.Current => _currentValue;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                while (_currentIndex<_dictionary.Count)
                {
                    _currentValue = new KeyValuePair<TKey, TValue>(
                        _dictionary.keyValuePairs[_currentIndex].key, 
                        _dictionary.keyValuePairs[_currentIndex].value);
                    _currentIndex++;
                    return true;
                }
                _currentIndex = _dictionary.Count + 1;
                _currentValue = new KeyValuePair<TKey, TValue>(default(TKey), default(TValue));
                return false;
            }

            public void Reset()
            {
                _currentIndex = 0;
                _currentValue = new KeyValuePair<TKey, TValue>(default(TKey), default(TValue));
            }
        }

        class KeyCollection : ICollection<TKey>
        {
            private CustomDictionary<TKey, TValue> _dictionary;

            public KeyCollection(CustomDictionary<TKey, TValue> dictionary)
            {
                _dictionary = dictionary;
            }

            public int Count => _dictionary.Count;

            public bool IsReadOnly => true;

            public void Add(TKey item)
            {
                throw new NotSupportedException();  
            }

            public void Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(TKey item)
            {
                return _dictionary.ContainsKey(item);
            }

            public void CopyTo(TKey[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<TKey> GetEnumerator()
            {
                return new Enumerator(_dictionary);
            }

            public bool Remove(TKey item)
            {
                throw new NotSupportedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new Enumerator(_dictionary);
            }

            public class Enumerator : IEnumerator<TKey>, IEnumerator
            {
                int _currentIndex;
                TKey _currentValue;

                CustomDictionary<TKey, TValue> _dictionary;

                public Enumerator(CustomDictionary<TKey, TValue> dictionary)
                {
                    _dictionary = dictionary;
                }

                public object Current => _currentValue;

                TKey IEnumerator<TKey>.Current => _currentValue;

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    while (_currentIndex < _dictionary.Count)
                    {
                        _currentValue = _dictionary.keyValuePairs[_currentIndex].key;
                        _currentIndex++;
                        return true;
                    }
                    _currentIndex = _dictionary.Count + 1;
                    _currentValue = default(TKey);
                    return false;
                }

                public void Reset()
                {
                    _currentIndex = 0;
                    _currentValue = default(TKey);
                }
            }
        }

        class ValueCollection : ICollection<TValue>
        {
            private CustomDictionary<TKey, TValue> _dictionary;

            public ValueCollection(CustomDictionary<TKey, TValue> dictionary)
            {
                _dictionary = dictionary;
            }

            public int Count => throw new NotImplementedException();

            public bool IsReadOnly => true;

            public void Add(TValue item)
            {
                throw new NotSupportedException();
            }

            public void Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(TValue item)
            { 
                return _dictionary.ContainsValue(item);
            }

            public void CopyTo(TValue[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<TValue> GetEnumerator()
            {
                return new Enumerator(_dictionary);
            }

            public bool Remove(TValue item)
            {
                throw new NotSupportedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new Enumerator(_dictionary);
            }

            public class Enumerator : IEnumerator<TValue>, IEnumerator
            {
                int _currentIndex;
                TValue _currentValue;

                CustomDictionary<TKey, TValue> _dictionary;

                public Enumerator(CustomDictionary<TKey, TValue> dictionary)
                {
                    _dictionary = dictionary;
                }

                public object Current => _currentValue;

                TValue IEnumerator<TValue>.Current => _currentValue;

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    while (_currentIndex < _dictionary.Count)
                    {
                        _currentValue = _dictionary.keyValuePairs[_currentIndex].value;
                        _currentIndex++;
                        return true;
                    }
                    _currentIndex = _dictionary.Count + 1;
                    _currentValue = default(TValue);
                    return false;
                }

                public void Reset()
                {
                    _currentIndex = 0;
                    _currentValue = default(TValue);
                }
            }
        }        
    }
}
