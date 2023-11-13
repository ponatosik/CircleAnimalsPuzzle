using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CollectablesCollection
{
    [SerializeField]
    private List<CollectableObject> _collectedObjects = new();

    public void AddCollectable(CollectableObject collectable) 
    {
        _collectedObjects.Add(collectable);
    }

	public void RemoveCollectable(CollectableObject collectable)
	{
		_collectedObjects.Remove(collectable);
	}

	public IEnumerable<CollectableObject> GetCollected() 
    {
        return _collectedObjects;
    }
}
