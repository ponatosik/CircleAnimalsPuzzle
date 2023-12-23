using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectSwipe : MonoBehaviour
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;

    [SerializeField] float tweenTime;
    [SerializeField] Ease tweenEase;

    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
        UpdateButtonVisibility();
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        levelPagesRect.DOLocalMove(targetPos, tweenTime).SetEase(tweenEase);
        UpdateButtonVisibility();
    }

    void UpdateButtonVisibility()
    {
        if (leftButton != null)
        {
            leftButton.gameObject.SetActive(currentPage > 1);
        }

        if (rightButton != null)
        {
            rightButton.gameObject.SetActive(currentPage < maxPage);
        }
    }
}
