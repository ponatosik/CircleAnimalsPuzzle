using DG.Tweening;
using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Enemy
{
	[RequireComponent(typeof(LineRenderer))]
	public class EnemyMovement : MonoBehaviour
	{
		public float moveDistance = 5f;
		public float moveDuration = 2f;

		private Vector3 startPosition;
		private LineRenderer lineRenderer;

		[SerializeField]
		private BoxCollider2D trajectoryCollider;

		void Start()
		{
			startPosition = transform.position;
			lineRenderer = GetComponent<LineRenderer>();

			lineRenderer.positionCount = 2;
			lineRenderer.SetPosition(0, startPosition);
			lineRenderer.SetPosition(1, startPosition);

			lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

			trajectoryCollider.size += new Vector2(0, moveDuration / 2);
			trajectoryCollider.offset -= new Vector2(0, moveDuration / 4);

			Movement();
		}

		void Movement()
		{
			float targetY = startPosition.y - moveDistance;

			transform.DOMoveY(targetY, moveDuration / 2)
				.SetEase(Ease.InOutQuad)
				.OnUpdate(() =>
				{
					float currentY = transform.position.y;
					float colliderSizeY = Mathf.Clamp(startPosition.y - currentY, 0f, moveDistance);


					lineRenderer.SetPosition(0, startPosition);
					lineRenderer.SetPosition(1, transform.position);
				})
				.OnComplete(() =>
				{
					transform.DOMoveY(startPosition.y, moveDuration / 2)
						.SetEase(Ease.InOutQuad)
						.OnUpdate(() =>
						{
							lineRenderer.SetPosition(0, startPosition);
							lineRenderer.SetPosition(1, transform.position);
						})
						.OnComplete(() =>
						{
							lineRenderer.SetPosition(0, startPosition);
							lineRenderer.SetPosition(1, startPosition);

							Movement();
						});
				});
		}
	}
}