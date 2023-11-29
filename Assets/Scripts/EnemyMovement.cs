using DG.Tweening;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveDuration = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        Movement();
    }

    void Movement()
    {
        transform.DOMoveY(startPosition.y - moveDistance, moveDuration)
                 .SetEase(Ease.OutQuad)
                 .OnComplete(() =>
                 {

                     transform.DOMoveY(startPosition.y + moveDistance, moveDuration)
                              .SetEase(Ease.OutQuad)
                              .OnComplete(() =>
                              {
                                  Movement();
                              });
                 });
    }

    private void ResetPosition()
    {
        
    }

}