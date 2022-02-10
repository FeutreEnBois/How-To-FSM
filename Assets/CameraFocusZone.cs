using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusZone : MonoBehaviour
{
    public Transform camera;
    public int id = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter Zone : " + id);
        camera.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }
}
