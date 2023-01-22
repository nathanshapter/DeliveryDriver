using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    //Components
    TopDownCarController topDownCarController;
    VFX vfx;

    

    //Awake is called when the script instance is being loaded.
    void Awake()
    {
        topDownCarController = GetComponent<TopDownCarController>();
        vfx = GetComponent<VFX>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame and is frame dependent
    void FixedUpdate()
    {

        if(Input.GetKey(KeyCode.Space))
        {
            topDownCarController.driftFactor = topDownCarController.driftFactorBrake;
            
            topDownCarController.turnFactor = 3;
        }
        else {           topDownCarController.driftFactor = topDownCarController.driftFactorOriginal;
            topDownCarController.turnFactor = 1.4f;
        }

        Vector2 inputVector = Vector2.zero;

        //Get input from Unity's input system.
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        if(inputVector.x != 0 || inputVector.y != 0)
        {
            vfx.smokeTrail.Play();
        }
        else { vfx.smokeTrail.Stop();}

        //Send the input to the car controller.
        topDownCarController.SetInputVector(inputVector);


     
    }
}
