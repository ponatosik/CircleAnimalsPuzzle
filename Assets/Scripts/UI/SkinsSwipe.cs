using UnityEngine;
using UnityEngine.UI;

public class SkinsSwipe : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;
    float distance = 1f;

    // Use this for initialization
    void Start()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
    }

    public void ScrollLeft()
    {
        int currentIndex = Mathf.RoundToInt(scrollbar.GetComponent<Scrollbar>().value / distance);
        int targetIndex = Mathf.Clamp(currentIndex - 1, 0, pos.Length - 1);
        scrollbar.GetComponent<Scrollbar>().value = pos[targetIndex];
    }

    public void ScrollRight()
    {
        int currentIndex = Mathf.RoundToInt(scrollbar.GetComponent<Scrollbar>().value / distance);
        int targetIndex = Mathf.Clamp(currentIndex + 1, 0, pos.Length - 1);
        scrollbar.GetComponent<Scrollbar>().value = pos[targetIndex];
    }
}
