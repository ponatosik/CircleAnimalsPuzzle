using CircleAnimalsPuzzle.Systems;
using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Collectables
{
	[RequireComponent(typeof(Collider2D))]
	public class CollectableObject : MonoBehaviour
	{
		private bool _isActive;
		private CollectablesCollection _collectablesPool;

		void Start()
		{
			_isActive = gameObject.activeSelf;
			GameManager.OnLevelStopped += Uncollect;
			_collectablesPool = GameManager.Instance.Collectables;
			_collectablesPool.Register(this);
		}

		private void OnDestroy()
		{
			GameManager.OnLevelStopped -= Uncollect;
		}

		void OnTriggerEnter2D(Collider2D collision)
		{
			Collect();
		}

		private void Collect()
		{
			_collectablesPool.Collect(this);
			gameObject.SetActive(false);
			AudioManager.instance.PlaySound("AppleSound");
		}

		private void Uncollect()
		{
			_collectablesPool.Uncollect(this);
			gameObject.SetActive(true);
		}
	}
}