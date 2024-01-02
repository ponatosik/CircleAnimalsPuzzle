using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace CircleAnimalsPuzzle.Gameplay.Enemy
{
	[RequireComponent(typeof(LineRenderer))]
	public class EnemyMovement : MonoBehaviour
	{
		public float MoveDistance = 5f;
		public float MoveDuration = 2f;

		private Vector3 _startPosition;
		private LineRenderer _lineRenderer;

		[SerializeField]
		private BoxCollider2D TrajectoryCollider;

		void Start()
		{
			_startPosition = transform.position;
			_lineRenderer = GetComponent<LineRenderer>();

			_lineRenderer.positionCount = 2;
			_lineRenderer.SetPosition(0, _startPosition);
			_lineRenderer.SetPosition(1, _startPosition);

			_lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

			TrajectoryCollider.size += new Vector2(0, MoveDuration / 2);
			TrajectoryCollider.offset -= new Vector2(0, MoveDuration / 4);

			Movement();
		}

		void Movement()
		{
			float targetY = _startPosition.y - MoveDistance;

			transform.DOMoveY(targetY, MoveDuration / 2)
				.SetEase(Ease.InOutQuad)
				.OnUpdate(() =>
				{
					_lineRenderer.SetPosition(0, _startPosition);
					_lineRenderer.SetPosition(1, transform.position);
				})
				.OnComplete(() =>
				{
					transform.DOMoveY(_startPosition.y, MoveDuration / 2)
						.SetEase(Ease.InOutQuad)
						.OnUpdate(() =>
						{
							_lineRenderer.SetPosition(0, _startPosition);
							_lineRenderer.SetPosition(1, transform.position);
						})
						.OnComplete(() =>
						{
							_lineRenderer.SetPosition(0, _startPosition);
							_lineRenderer.SetPosition(1, _startPosition);

							Movement();
						});
				});
		}
	}
}