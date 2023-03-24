using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    
    [Range(1f, 100f)]   //dice all'editor che il valore puo' andare da 1 a 100, in questo modo le basse vengono presentate come slider. vedi THRUST in inspector
    public float THRUST = 30f;
    [Range(1f, 100f)]
    public float ROT_SPEED = 100f;
    public bool INVERT_Y = true;

    public Transform COM;
    private Rigidbody body;

    private float thrust = 0f;

    private void Start() {
        body = GetComponent<Rigidbody>();
        body.centerOfMass = COM.localPosition;  //centro di massa
    }

    void FixedUpdate() {
        // get the user's vertical input
        float pitch = Input.GetAxis("Vertical") * (INVERT_Y ? 1 : -1);//questo per scegliere freccia su o giu per andare su o giu, a seconda delle pref del giocatore, modificabile in inspector
        float roll = -Input.GetAxis("Horizontal");
        float yaw = Input.GetAxis("Horizontal2");

        // Rotational Forces
        body.AddRelativeTorque(Vector3.forward * roll * ROT_SPEED, ForceMode.Acceleration);  //applica le forze al rigid body, proporzionale
        body.AddRelativeTorque(Vector3.right * pitch * ROT_SPEED * 0.5f, ForceMode.Acceleration);
        body.AddRelativeTorque(Vector3.up * yaw * ROT_SPEED * 0.1f, ForceMode.Acceleration);

        // Engine Thrust
        body.AddRelativeForce(Vector3.forward * thrust, ForceMode.Acceleration);  //analogo per lo spostamento in avanti

        // Gravity
        body.AddForce(Physics.gravity * (1.0f - (thrust / THRUST)), ForceMode.Acceleration);//la gravia' e' tanto minorre quanto piu' vado veloce (barando) cioe' simulo la portanza
    }

    public void ChangeThrottle(float throttle) {
        thrust = THRUST * Mathf.Clamp01(throttle);
    }
}
