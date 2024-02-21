using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomMode : MonoBehaviour
{
    public Weapon weapon;
    public Camera cam;

    public bool activated;
    public float cameraZoom = 2;

    public Vector3 cameraOffset;


    public void zoomActivate()
    {
        activated = !activated;
        cam.usePhysicalProperties = activated;

        var zoom = activated ? cameraZoom : 1/ cameraZoom;
        cam.sensorSize = new Vector2(cam.sensorSize.x, cam.sensorSize.y * zoom);

        var localX = weapon.transform.localPosition.x;
        var localY = weapon.transform.localPosition.y;
        var localZ = weapon.transform.localPosition.z;
        weapon.transform.localPosition = activated ? new Vector3(localX - cameraOffset.x, localY + cameraOffset.y, localZ + cameraOffset.z) : 
            new Vector3(localX + cameraOffset.x, localY - cameraOffset.y, localZ + cameraOffset.z);
    }
}
