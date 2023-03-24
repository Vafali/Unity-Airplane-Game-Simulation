using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    
    public float SPEED = 100f;
    private float speed = 0f;
    public Vector3 AXIS = Vector3.forward;

    private void FixedUpdate() {
        transform.Rotate(AXIS * speed * Time.deltaTime);
    }

    public void ChangeSpeed(float scale) {
        speed = SPEED * scale;
    }
}
