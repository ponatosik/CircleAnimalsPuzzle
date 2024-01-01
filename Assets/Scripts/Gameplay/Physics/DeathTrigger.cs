using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Physics
{
	public class DeathTrigger : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{
				GameManager.Instance.StopLevel();
			}
		}
	}
}