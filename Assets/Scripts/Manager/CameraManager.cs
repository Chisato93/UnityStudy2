using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera cam;

    const float fovmin = 50, fovmax = 120;
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            cam.fieldOfView--;
            if (cam.fieldOfView >= fovmax)
                cam.fieldOfView = fovmax;
        }
        else if (scroll < 0f)
        {
            cam.fieldOfView++;
            if (cam.fieldOfView <= fovmin)
                cam.fieldOfView = fovmin;
        }
    }
}
