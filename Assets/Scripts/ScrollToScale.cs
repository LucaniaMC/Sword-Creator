using UnityEngine;

public class ScrollToScale : MonoBehaviour
{
    [SerializeField] private float scaleRate = 0.2f; // how quickly the object scales each scroll
    [SerializeField] private float minScale = 1f;
    [SerializeField] private float maxScale = 3f;
    [SerializeField] private float smoothingSpeed = 10f; // how quickly the scale interpolates

    [SerializeField] private MouseRegionCheck regionChecker;

    private float targetScale = 1f;

    //Todo: don't use update
    private void Update()
    {
        //Only works if the mouse is in the display region
        if (regionChecker != null && regionChecker.IsMouseOverRegion())
        {
            float delta = Input.mouseScrollDelta.y * scaleRate;
            if (!Mathf.Approximately(delta, 0f))
            {
                // Only update the target when there's actual scroll input
                targetScale = Mathf.Clamp(targetScale + delta, minScale, maxScale);
            }

            // Smoothly interpolate current scale towards the target scale over time
            float current = transform.localScale.x;
            float smooth = Mathf.Lerp(current, targetScale, smoothingSpeed * Time.deltaTime);
            transform.localScale = Vector3.one * smooth;
        }
    }

    public void Reset()
    {
        targetScale = 1f;
        transform.localScale = Vector3.one;
    }
}