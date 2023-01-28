using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform receiver;

    private bool overlap = false;

    void LateUpdate() {
        if(overlap){

            Vector3 portalToPlayer = player.position - transform.position;
           float dot = Vector3.Dot(transform.up,portalToPlayer);

           if(dot <0f){
            //teleport
            float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
            rotationDiff += 180;
            player.Rotate(Vector3.up, rotationDiff);

            Vector3 posOffset = Quaternion.Euler(0f, rotationDiff,0f)* portalToPlayer;
            player.position = receiver.position + posOffset;

            overlap = false;

           }
        }
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Player"){
            overlap = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            overlap = false;
        }
    }
}
