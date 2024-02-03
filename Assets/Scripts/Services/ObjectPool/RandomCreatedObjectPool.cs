using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RandomCreatedObjectPool<T> : ObjectPool<T> where T : MonoBehaviour
{

    public RandomCreatedObjectPool(List<T> prefabs, Transform container, int count, bool autoExpand)
    {
        _container = container;
        _pool = prefabs;
        _autoExpand = autoExpand;

        //CreatePool(count);
    }

    protected override void CreatePool(int count = 5)
    {
        throw new NotImplementedException();
    }
    protected override T CreateItem(bool isActiveByDefault = false)
    {
        throw new NotImplementedException("This method dont allowed");
    }
    
    public override bool HasFreeItem(out T item)
    {
        var random = new System.Random().Next(_pool.Count);
        if (_pool[random].gameObject.activeInHierarchy)
        {
            HasFreeItem(out item);
        }
        else
        {
            item = _pool[random];
            item.gameObject.SetActive(true);
        }
        return true;
    }
    public override T GetFreeItem()
    {
        if (HasFreeItem(out var item))
            return item;

        throw new Exception($"There is no more free elements of type {typeof(T)}");
    }
}