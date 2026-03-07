using UnityEngine;

public class ManageCamera : MonoBehaviour
{
    [Header("Camera")]
    public float cameraPanSpeed = 0.1f;
    public float minX = -17.1f, maxX = 19f;
    public float zoomSpeed = 0.35f;
    public Vector2 minZoom = new Vector2(5f, -22.2f);
    public Vector2 maxZoom = new Vector2(9.8f, -13.9f);
    ObjectStats present;

    private void Update()
    {
        HandleMouseInput();
        if (present != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.collider.gameObject == present.gameObject)
                {
                    return;
                }
                    present.transform.position = new Vector3(hit.point.x, hit.point.y + 0.3f, hit.point.z);
            }
        }
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pickObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            releaseObject();
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

    private void pickObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Hit pickPresent: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.TryGetComponent<ObjectStats>(out ObjectStats present))
            {
                this.present = present;
                present.GetComponent<Collider>().enabled = false;
            }
        }
    }

    private void releaseObject()
    {
        present.GetComponent<Collider>().enabled = true;
        present = null;
    }
}
