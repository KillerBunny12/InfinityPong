using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public Rigidbody2D body;
   public float HorizontalMovement = 0;
    public float speed = 10f;
    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
       // HorizontalMovement = Input.GetAxisRaw("Horizontal");
        if (Left.GetComponent<TouchControls>().Touched() && !Right.GetComponent<TouchControls>().Touched())
        {
            HorizontalMovement = -1;
        }
        else
        {
            if (!Left.GetComponent<TouchControls>().Touched() && Right.GetComponent<TouchControls>().Touched())
            {
                HorizontalMovement = 1;
            }
            else
            {
                HorizontalMovement = 0;
            }
        }

       
    }

    private void FixedUpdate()
    {
        if (HorizontalMovement != 0)
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, HorizontalMovement * Time.fixedDeltaTime * -speed);
        }
        
    }

    public void resetpos()
    {
        this.transform.position = startpos;
    }
}
