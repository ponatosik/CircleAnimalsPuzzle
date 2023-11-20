using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    public GameObject emptyStarPrefab;
    public GameObject yellowStarPrefab;

    void Start()
    {
        Initialize();
    }

    public void InitializeStars(Level level)
    {
        if (level != null && level.Unlocked)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < level.MaxStars; i++)
            {
                GameObject star;

                if (i < level.Stars)
                {
                    star = Instantiate(yellowStarPrefab, transform);
                }
                else
                {
                    star = Instantiate(emptyStarPrefab, transform);
                }

                Destroy(star.GetComponent<SpriteRenderer>());

                Image starImage = star.AddComponent<Image>();
                RectTransform rectTransform = star.GetComponent<RectTransform>();

                rectTransform.sizeDelta = new Vector2(300f, 289f) * 0.25f;

                float xPos = 0f;
                float yPos = 0f;

                if (i == 0)
                {
                    xPos = -70f;
                    yPos = -20f;
                }
                else if (i == 1)
                {
                    xPos = 0f;
                    yPos = -70f;
                }
                else if (i == 2)
                {
                    xPos = 70f;
                    yPos = -20f;
                }

                rectTransform.localPosition = new Vector3(xPos, yPos, 0f);
            }

        }
        else
        {
            Debug.LogWarning("Level is not unlocked or is null.");
        }
    }

    public void Initialize()
    {
        SelectLevelButton selectLevelButton = GetComponentInParent<SelectLevelButton>();

        if (selectLevelButton != null && selectLevelButton.initialLevel != null)
        {
            InitializeStars(selectLevelButton.initialLevel);
        }
        else
        {
            Debug.LogError("SelectLevelButton script or initialLevel not found in parent.");
        }
    }
}
