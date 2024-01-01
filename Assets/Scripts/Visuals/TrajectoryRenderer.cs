using CircleAnimalsPuzzle.Gameplay;
using UnityEngine;

namespace CircleAnimalsPuzzle.Visuals
{
	[RequireComponent(typeof(Collider2D))]
	public class TrajectoryRenderer : MonoBehaviour
	{
		[Header("Line renderer")]
		[SerializeField]
		private LineRenderer _trajectoryLine;

		[Header("Optimizations")]
		[SerializeField]
		[Range(1, 60)]
		private int _fixedFramesBetweenPoints = 10;
		private int _fixedFramesCount = 0;

		private Vector3 _lastPos;
		private float _trajectoryLineZPos;

		public void ResetTrajectory()
		{
			_trajectoryLineZPos = _trajectoryLine.gameObject.transform.position.z;
			_trajectoryLine.positionCount = 0;
			_fixedFramesCount = 0;
			_lastPos = transform.position;
		}

		public void AddTrajectoryPoint(Vector2 point)
		{
			if (transform.position == _lastPos)
			{
				return;
			}

			_lastPos = transform.position;
			_trajectoryLine.positionCount++;
			_trajectoryLine.SetPosition(_trajectoryLine.positionCount - 1, new Vector3(point.x, point.y, _trajectoryLineZPos));
		}

		void Start()
		{
			GameManager.OnLevelStarted += ResetTrajectory;
		}

		void OnDestroy()
		{
			GameManager.OnLevelStarted -= ResetTrajectory;
		}

		void FixedUpdate()
		{
			_fixedFramesCount++;
			if (_fixedFramesCount >= _fixedFramesBetweenPoints && GameManager.LevelStarted)
			{
				AddTrajectoryPoint(transform.position);
				_fixedFramesCount = 0;
			}
		}

		void OnCollisionEnter2D(Collision2D collision)
		{
			AddTrajectoryPoint(transform.position);
		}
	}
}