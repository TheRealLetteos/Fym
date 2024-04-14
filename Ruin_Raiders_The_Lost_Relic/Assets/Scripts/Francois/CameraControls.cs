using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float zoomSensitivity = 0.5f; // SerializeField 
    public float zoomSpeed = 10f;
    public float minOrthoSize = 1f;
    public float maxOrthoSize = 20f;
    public float panSpeed = 20f;

    private Camera cam;
    private Vector3 dragOrigin;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Simple camera script.
        // Zooming 
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float newSize = cam.orthographicSize - scroll * zoomSensitivity;
            cam.orthographicSize = Mathf.Clamp(Mathf.Lerp(cam.orthographicSize, newSize, Time.deltaTime * zoomSpeed), minOrthoSize, maxOrthoSize);
        }

        // Panning 
        if (Input.GetMouseButtonDown(1)) 
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position += difference;
        }
    }
}