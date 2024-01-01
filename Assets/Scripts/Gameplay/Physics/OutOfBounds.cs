using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Physics
{
    public class OutOfBounds : MonoBehaviour
    {
        private void Update()
        {
            CheckIfOutOfBounds();
        }

        private void CheckIfOutOfBounds()
        {
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

            if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
            {
                GameManager.Instance.StopLevel();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("JustTree"))
            {
                GameManager.Instance.StopLevel();
            }
        }
    }
}