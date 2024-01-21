using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolObjects {
    private List<Ball> _pool;
    private bool _canExpand = false;
    private Transform _parentContainer;
    private Ball _prefab;
    private Factory _factory = new ();
    
    public void Initialize(Ball prefab, int poolAmount, bool canExpand, Transform parentContainer) {
        _canExpand = canExpand;
        _parentContainer = parentContainer;
        _prefab = prefab;

        CreatePool(poolAmount);
    }
    private void CreatePool(int poolAmount) {
        _pool = new List<Ball>();

        for (int i = 0; i < poolAmount; i++)
            CreateElement();
    }
   private Ball CreateElement(bool isActiveAsDefault = false) {
        var createdObj = _factory.Get(_prefab, _parentContainer.position, _parentContainer.rotation);
        createdObj.gameObject.SetActive(isActiveAsDefault);
        _pool.Add(createdObj);
        return createdObj;
    }
    public bool HasFreeElement(out Ball element) {
        foreach (var obj in _pool) {
            if (!obj.gameObject.activeInHierarchy) {
                element = obj;
                element.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public Ball GetFreeElement() {
        if (HasFreeElement(out var element))
            return element;
        if (_canExpand)
            return CreateElement(true);
        throw new Exception($"в пуле закончились {typeof(Ball)}");
    }
}

