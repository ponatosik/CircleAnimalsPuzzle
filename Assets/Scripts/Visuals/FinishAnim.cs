using UnityEngine;

namespace CircleAnimalsPuzzle.Visuals
{
	public class FinishAnim : MonoBehaviour
	{
		[SerializeField] private Animator myAnimationController;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{
				myAnimationController.SetBool("PlayAnimation", true);
			}

		}
	}
}