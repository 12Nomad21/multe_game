using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour {
    public T _prefab { get; }
    public bool _autoExpand { get; set; }
    public Transform _container { get; }

    private List<T> _pool;

    public PoolMono(T prefab, int count, Transform container) {
        this._prefab = prefab;
        this._container = container;

        this.CreatePool(count);
    }

    private void CreatePool(int count) {
        this._pool = new List<T>();

        for(int i = 0; i < count; i++) {
            this.CreateObject();
        }
    }

    private T CreateObject(bool IsActiveByDefault = false) {
        var _createdObject = Object.Instantiate(this._prefab, this._container);
        _createdObject.gameObject.SetActive(IsActiveByDefault);
        this._pool.Add(_createdObject);
        return _createdObject;
    }

    public bool HasFreeElement(out T element) {
        foreach(var mono in _pool) {
            if(!mono.gameObject.activeInHierarchy) {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement() {
        if(this.HasFreeElement(out var element)) {
            return element;
        }

        if(this._autoExpand) {
            return this.CreateObject(true);
        }

        throw new System.Exception("Объекта нет. Пока!");
    }
}