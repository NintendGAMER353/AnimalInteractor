using UnityEngine;

public class ManageCamera : MonoBehaviour
{
    [Header("Camera")]
    public float cameraPanSpeed = 0.1f;
    public float minX = -17.1f, maxX = 19f;
    public float zoomSpeed = 0.35f;
    public Vector2 minZoom = new Vector2(5f, -22.2f);
    public Vector2 maxZoom = new Vector2(9.8f, -13.9f);

    private void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Interacción bichín

        }

        if (Input.GetMouseButton(2))
        {
            HandleMiddleMouseInput();
        }
        HandleMouseScrollInput();
    }

    private void HandleMiddleMouseInput()
    {
        float dx = Input.mousePositionDelta.x;
        Camera.main.transform.position += new Vector3(dx, 0, 0) * cameraPanSpeed;
        Vector3 camPos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(Mathf.Clamp(camPos.x, minX, maxX), camPos.y, camPos.z);
    }

    private void HandleMouseScrollInput()
    {
        float dy = (Input.mouseScrollDelta.y);
        Camera.main.transform.position += dy*Camera.main.transform.forward*zoomSpeed;
        Vector3 camPos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(camPos.x, Mathf.Clamp(camPos.y, minZoom.x, maxZoom.x), Mathf.Clamp(camPos.z, minZoom.y, maxZoom.y));
    }
}
