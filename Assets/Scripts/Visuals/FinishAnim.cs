using UnityEngine;
using UnityEngine.Serialization;

namespace CircleAnimalsPuzzle.Visuals
{
	public class FinishAnim : MonoBehaviour
	{
		[SerializeField]
		private Animator _animationController;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{
				_animationController.SetBool("PlayAnimation", true);
			}

		}
	}
}