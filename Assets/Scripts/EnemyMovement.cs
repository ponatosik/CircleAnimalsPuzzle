using DG.Tweening;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveDuration = 2f;

    private Vector3 startPosition;
    private BoxCollider2D collider2D;
    private LineRenderer lineRenderer;

    void Start()
    {
        startPosition = transform.position;
        collider2D = GetComponent<BoxCollider2D>();
        lineRenderer = GetComponent<LineRenderer>();

        collider2D.size = new Vector2(collider2D.size.x, moveDistance);

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, startPosition);

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

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
                collider2D.size = new Vector2(collider2D.size.x, colliderSizeY);

                lineRenderer.SetPosition(0, startPosition);
                lineRenderer.SetPosition(1, transform.position);
            })
            .OnComplete(() =>
            {
                collider2D.size = new Vector2(collider2D.size.x, moveDistance);

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
