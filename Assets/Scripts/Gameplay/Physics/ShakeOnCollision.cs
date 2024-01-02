using CircleAnimalsPuzzle.Systems;
using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Physics
{
	[RequireComponent(typeof(Collider2D))]
	[RequireComponent(typeof(Animator))]
	public class ShakeOnCollision : MonoBehaviour
	{
		[SerializeField]
		private string _soundOnCollision = "ThreeSound";

		private Animator _animator;

		private void Start()
		{
			_animator = GetComponent<Animator>();
		}

		void OnCollisionEnter2D(Collision2D collision)
		{
			_animator.SetTrigger("Shake");
			AudioManager.Instance.PlaySound(_soundOnCollision);
		}
	}
}