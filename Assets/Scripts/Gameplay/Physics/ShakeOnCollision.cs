using CircleAnimalsPuzzle.Systems;
using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Physics
{
	[RequireComponent(typeof(Collider2D))]
	[RequireComponent(typeof(Animator))]
	public class ShakeOnCollision : MonoBehaviour
	{
		Animator _animator;

		[SerializeField]
		private string _soundOnCollision = "ThreeSound";


		private void Start()
		{
			_animator = GetComponent<Animator>();
		}

		void OnCollisionEnter2D(Collision2D collision)
		{
			_animator.SetTrigger("Shake");
			AudioManager.instance.PlaySound(_soundOnCollision);
		}
	}
}