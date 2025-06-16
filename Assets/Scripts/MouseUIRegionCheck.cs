using UnityEngine;

public class MouseRegionCheck : MonoBehaviour
{
    [SerializeField] private RectTransform region;   // target UI Panel
    [SerializeField] private Canvas canvas;          // The canvas in Camera Space

    // Returns true if the mouse is over the rect transform region
    public bool IsMouseOverRegion()
    {
        return RectTransformUtility.RectangleContainsScreenPoint(
            region,
            Input.mousePosition,
            canvas.worldCamera
        );
    }
}