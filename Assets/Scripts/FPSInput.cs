using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {
    private CharacterController _charController; //reference to connected character controller for this script

    //character speed value
    public float speed = 6.0f;

    //player gravity field
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start() {
        //on script start, locate character controller and assign it to _charController var
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        //If input is horizontal coded, multiply it by speed (assuming input get axis returns either a 1 or 0)
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
