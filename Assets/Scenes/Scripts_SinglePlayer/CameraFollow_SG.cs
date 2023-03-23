using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_SG : MonoBehaviour
{
    public float speed = 4f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 new_position = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, new_position, speed * Time.deltaTime);
    }
}
