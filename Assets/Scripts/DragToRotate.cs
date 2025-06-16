using UnityEngine;

public class DragToRotate : MonoBehaviour
{
    [SerializeField] private float rotationRate = 1f; //how quick the object rotates

    [SerializeField] private MouseRegionCheck regionChecker;

    //for calculating mouse position difference each frame
    private float m_previousX;
    private float m_previousY;

    //Todo: don't use update
    private void Update()
    {
        //Only works if the mouse is in the display region
        if (regionChecker != null && regionChecker.IsMouseOverRegion())
        {
            //Drag left mouse button to rotate
            if (Input.GetMouseButtonDown(0))
            {
                m_previousX = Input.mousePosition.x;
                m_previousY = Input.mousePosition.y;
            }

            // get the user touch input
            if (Input.GetMouseButton(0))
            {
                var deltaX = -(Input.mousePosition.y - m_previousY) * rotationRate;
                var deltaY = -(Input.mousePosition.x - m_previousX) * rotationRate;
                transform.Rotate(-deltaX, deltaY, 0, Space.World);

                m_previousX = Input.mousePosition.x;
                m_previousY = Input.mousePosition.y;
            }
        }
    }

    public void Reset()
    {
        transform.rotation = Quaternion.identity;
    }
}
