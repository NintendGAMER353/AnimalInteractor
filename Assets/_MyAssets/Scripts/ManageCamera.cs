using UnityEngine;
using UnityEngine.Rendering;

public class ManageCamera : MonoBehaviour
{
    [Header("Camera")]
    public float cameraPanSpeed = 0.1f;
    public float minX = -8f, maxX = 14f;
    public float minZ = -26f, maxZ = 2f;
    public float zoomSpeed = 0.35f;
    public float minZoom = 25f;
    public float maxZoom = 50f;
    ObjectStats present;
    Animal hitAnimal;
    private void Update()
    {
        HandleMouseInput();
        if (present != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == present.gameObject)
                {
                    return;
                }

                if (hit.collider.TryGetComponent(out Animal hitAn))
                    hitAnimal = hitAn;
                else
                    hitAnimal = null;

                present.transform.position = new Vector3(hit.point.x, hit.point.y + 0.3f, hit.point.z);


            }

        }
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PickObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReleaseObject();
        }

        if (Input.GetMouseButton(2))
        {
            HandleMiddleMouseInput();
        }
        HandleMouseScrollInput();
    }

    private void HandleMiddleMouseInput()
    {
        (float dx, float dy, float dz) = (Input.mousePositionDelta.x, Input.mousePositionDelta.y, Input.mousePositionDelta.z);
        Camera.main.transform.position -= new Vector3(dx, 0, dy) * cameraPanSpeed;
        Vector3 camPos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(Mathf.Clamp(camPos.x, minX, maxX), camPos.y, Mathf.Clamp(camPos.z, minZ, maxZ));
    }

    private void HandleMouseScrollInput()
    {
        float dy = (Input.mouseScrollDelta.y);
        Camera.main.fieldOfView -= dy * zoomSpeed;
        float zoom = Camera.main.fieldOfView;
        Camera.main.fieldOfView = Mathf.Clamp(zoom, minZoom, maxZoom);
    }

    private void PickObject()
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

    private void ReleaseObject()
    {
        if (present == null)
            return;
        if (hitAnimal != null && hitAnimal.currentBehaviour.IsInterrumpible)
        {
            hitAnimal.GetComponentInChildren<GivePresentBehaviour>().actualPresent = present;
            hitAnimal.changeState(IAnimalBehaviour.StateClass.GIVE_PRESENT);

            return;
        }



        present.GetComponent<Collider>().enabled = true;
        present = null;

    }
}
