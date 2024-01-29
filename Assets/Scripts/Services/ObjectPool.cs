using System;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private Transform _container;

    private List<T> _pool;

    public ObjectPool(T prefab, Transform container, int count)
    {
        _container = container;
        _prefab = prefab;

        CreatePool(count);
    }

    private void CreatePool(int count = 5)
    {
        _pool = new List<T>();
        
        for(int i = 0; i < count; i++)
        {
            CreateItem();
        }
    }

    private T CreateItem(bool isActiveByDefault = false)
    {
        var item = UnityEngine.Object.Instantiate(_prefab, _container);
        item.gameObject.SetActive(isActiveByDefault);
        _pool.Add(item);
        return item;
    }
    public bool HasFreeItem(out T item)
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
    public T GetFreeItem()
    {
        if(HasFreeItem(out var item))
            return item;
        else if (_autoExpand)
            return CreateItem();

        throw new Exception($"There is no more free elements of type {typeof(T)}");
    }
}