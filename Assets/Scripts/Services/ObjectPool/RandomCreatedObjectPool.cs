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