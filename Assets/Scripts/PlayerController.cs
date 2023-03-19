using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerHorizontalSpeed;
    private float _horizontalValue;
    private float newXPosition,xLimitPosition;
    public float horizontalLimitValue;
    public CanvasController canvasController;
    public GameObject playerGameObject;
    public bool canMove;
    Rigidbody rb;


 
    void Start()
    {
        canMove = true;
        rb= GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        PlayerMovement();
    }
    public void PlayerMovement()
    {
        if (canMove)
        {
            xLimitPosition = transform.position.x;
            xLimitPosition=Mathf.Clamp(xLimitPosition,-horizontalLimitValue,horizontalLimitValue);
            transform.position = new Vector3(xLimitPosition, transform.position.y, transform.position.z);
            newXPosition = _horizontalValue * playerHorizontalSpeed * Time.fixedDeltaTime;
            rb.velocity = new Vector3(newXPosition, rb.velocity.y, rb.velocity.z);
            transform.rotation = Quaternion.identity;
        }
       
    }
    public void Left()
    {   
            _horizontalValue = -1;
    }
    public void Right()
    {      
            _horizontalValue = 1;
    }
    public void Up()
    {
            _horizontalValue = 0;
    }
 


}
