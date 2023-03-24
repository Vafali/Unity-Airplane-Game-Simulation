using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    
    public Transform TARGET;
    public Transform[] POSITIONS;
    private Vector3 currentOffset;

    private int offsetIndex = 0;

    private void Start() {
        if (POSITIONS != null && POSITIONS.Length > 0) {   //POSITIONS e' un array di posizioni
            transform.localRotation = POSITIONS[0].localRotation;
            currentOffset = POSITIONS[0].localPosition;
        } else {
            currentOffset = transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update() {
        if (TARGET != null) {
            transform.position = TARGET.position + currentOffset;
        }
        if (Input.GetButtonDown("Jump") && POSITIONS.Length > 0) {  //ogni volta che premo la barra spaziatrice (jump) cambio posizione
            offsetIndex = (offsetIndex + 1) % POSITIONS.Length;
            transform.localRotation = POSITIONS[offsetIndex].localRotation;
            currentOffset = POSITIONS[offsetIndex].localPosition;
        }
    }
}
