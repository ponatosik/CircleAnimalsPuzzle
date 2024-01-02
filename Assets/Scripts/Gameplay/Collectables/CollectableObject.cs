using CircleAnimalsPuzzle.Systems;
using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Collectables
{
	[RequireComponent(typeof(Collider2D))]
	public class CollectableObject : MonoBehaviour
	{
		private CollectablesCollection _collectablesPool;

		void Start()
		{
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
			AudioManager.Instance.PlaySound("AppleSound");
		}

		private void Uncollect()
		{
			_collectablesPool.Uncollect(this);
			gameObject.SetActive(true);
		}
	}
}