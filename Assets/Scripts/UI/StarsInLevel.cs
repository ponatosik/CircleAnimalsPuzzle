using UnityEngine;

public class Starsinlevel : MonoBehaviour
{

    public GameObject star1gold;
    public GameObject star2gold;
    public GameObject star3gold;

    public GameObject star1gray;
    public GameObject star2gray;
    public GameObject star3gray;

    public static Starsinlevel instance;

    private void Awake()
    {
        instance = this;
    }

    public static void OutputCollectedNumber()
    {
        int collectedNumber = GameManager.Instance.Collectables.GetCollectedNumber();
        int allStars = GameManager.Instance.Collectables.GetAllCollectablesNumber();
        Debug.Log($"Number of collectibles: {collectedNumber}");

        ActivateStars(collectedNumber, allStars);
    }

    private static void ActivateStars(int collectedNumber, int allStars)
    {
        if (allStars >= 1)
        {
           instance.star1gray.SetActive(true);
        }
        if (allStars >= 2)
        {
            instance.star2gray.SetActive(true);
        }
        if (allStars >= 3)
        {
            instance.star3gray.SetActive(true);
        }
        if (allStars >= 1 & collectedNumber >= 1)
        {
            instance.star1gold.SetActive(true);
        }
        if (allStars >= 2 & collectedNumber >= 2)
        {
            instance.star2gold.SetActive(true);
        }
        if (allStars >= 3 & collectedNumber >= 3)
        {
            instance.star3gold.SetActive(true);
        }
    }

}