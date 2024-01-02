using CircleAnimalsPuzzle.Visuals;
using System.Linq;
using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Physics
{
	public class DisableOnIntersection : MonoBehaviour
	{
		[SerializeField]
		private ObjectEffect _effect;
		private Collider2D[] _colliders;
		private bool _isDisabled;

		void Start()
		{
			GameManager.OnLevelStarted += OnLevelStarted;
			GameManager.OnLevelStopped += OnLevelStopped;

			_colliders = GetComponents<Collider2D>();
			_isDisabled = HasIntersection();
			_effect.SetEffectActive(_isDisabled);
		}

		private void OnDestroy()
		{
			GameManager.OnLevelStarted -= OnLevelStarted;
			GameManager.OnLevelStopped -= OnLevelStopped;
		}

		void FixedUpdate()
		{
			if (GameManager.LevelStarted)
			{
				return;
			}

			bool wasDisabled = _isDisabled;
			_isDisabled = HasIntersection();

			if (wasDisabled != _isDisabled)
			{
				_effect.SetEffectActive(_isDisabled);
			}
		}

		private bool HasIntersection()
		{
			Collider2D[] contactColliders = new Collider2D[10];
			ContactFilter2D filter = new ContactFilter2D().NoFilter();

			foreach (var collider in _colliders)
			{
				int hits = collider.OverlapCollider(filter, contactColliders);
				for (int i = 0; i < hits; i++)
				{
					if (!_colliders.Contains(contactColliders[i]))
					{
						return true;
					}
				}
			}

			return false;
		}


		private void OnLevelStarted()
		{
			if (!_isDisabled)
			{
				return;
			}

			foreach (var collider in _colliders)
			{
				collider.enabled = false;
			}
		}

		private void OnLevelStopped()
		{
			foreach (var collider in _colliders)
			{
				collider.enabled = true;
			}
		}
	}
}