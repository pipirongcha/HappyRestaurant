using UnityEngine;

public class SafeArea : MonoBehaviour
{
    Rect safeArea;
    Vector2 minAnchor;
    Vector2 maxAnchor;

    private void Awake()
    {
        RectTransform rect = GetComponent<RectTransform>();

        safeArea = Screen.safeArea;

        minAnchor = safeArea.min;
        maxAnchor = safeArea.max;

        minAnchor.x /= Screen.width;
        maxAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.y /= Screen.height;

        rect.anchorMin = minAnchor;
        rect.anchorMax = maxAnchor;
    }
}
