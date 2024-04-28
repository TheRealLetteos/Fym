using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float zoomSensitivity = 0.5f;
    public float zoomSpeed = 10f;
    public float minOrthoSize = 1f;
    public float maxOrthoSize = 20f;
    public float followSpeed = 5f; // Speed at which camera follows the player (if any)

    private Camera cam;
    private Vector3 dragOrigin;
    private bool isPanning; // Do we pan?

    void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        // Kitty got the zoomies!!! 
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
            isPanning = true;
        }

        if (Input.GetMouseButton(1) && isPanning)
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position += difference;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isPanning = false;
        }

        // Camera follow player
        if (player != null && !isPanning && player.gameObject.activeInHierarchy)
        {
            Vector3 playerPosition = player.position + new Vector3(0, 0, -10); 
            transform.position = Vector3.Lerp(transform.position, playerPosition, followSpeed * Time.deltaTime);
        }
    }
}