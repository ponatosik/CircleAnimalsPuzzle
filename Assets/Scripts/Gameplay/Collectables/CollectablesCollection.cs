using System;
using System.Collections.Generic;
using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Collectables
{
	[Serializable]
	public class CollectablesCollection
	{
		[SerializeField]
		private List<CollectableObject> _collectedObjects = new();

		[SerializeField]
		private List<CollectableObject> _allLevelCollectables = new();

		public void Register(CollectableObject collectable)
		{
			if (!_allLevelCollectables.Contains(collectable))
			{
				_allLevelCollectables.Add(collectable);
			}
		}

		public void Collect(CollectableObject collectable)
		{
			_collectedObjects.Add(collectable);
		}

		public void Uncollect(CollectableObject collectable)
		{
			_collectedObjects.Remove(collectable);
		}

		public int GetCollectedNumber()
		{
			return _collectedObjects.Count;
		}

		public int GetAllCollectablesNumber()
		{
			return _allLevelCollectables.Count;
		}

		public IEnumerable<CollectableObject> GetCollected()
		{
			return _collectedObjects;
		}
	}
}