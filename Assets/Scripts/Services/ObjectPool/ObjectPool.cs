using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] protected bool _autoExpand = true;
    [SerializeField] protected Transform _container;

    protected List<T> _pool;
    protected ObjectPool() { }

    public ObjectPool(T prefab, Transform container, int count, bool autoExpand)
    {
        _container = container;
        _prefab = prefab;
        _autoExpand = autoExpand;

        CreatePool(count);
    }

    protected virtual void CreatePool(int count = 5)
    {
        _pool = new List<T>();
        
        for(int i = 0; i < count; i++)
        {
            CreateItem();
        }
    }

    protected virtual T CreateItem(bool isActiveByDefault = false)
    {
        var item = UnityEngine.Object.Instantiate(_prefab, _container);
        item.gameObject.SetActive(isActiveByDefault);
        _pool.Add(item);
        return item;
    }
    public virtual bool HasFreeItem(out T item)
    {
        foreach(var el in _pool)
        {
            if(!el.gameObject.activeInHierarchy)
            {
                el.gameObject.SetActive(true);
                item = el;
                return true;
            }
        }
        item = null;
        return false;
    }
    public virtual T GetFreeItem()
    {
        if(HasFreeItem(out var item))
            return item;
        else if (_autoExpand)
            return CreateItem();

        throw new Exception($"There is no more free elements of type {typeof(T)}");
    }
}