using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public Camera cameraa;
    public RaycastHit hit;

    public bool BeingTouched = false;
    // Start is called before the first frame update

    

    private void FixedUpdate()
    {

        
        if (Input.GetMouseButton(0))
        {
            
          //  RaycastHit2D hit = Physics2D.Raycast(new Vector2(cameraa.ScreenToWorldPoint(Input.GetTouch(0).position).x, cameraa.ScreenToWorldPoint(Input.GetTouch(0).position).x), Vector2.zero, 0);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(cameraa.ScreenToWorldPoint(Input.mousePosition).x, cameraa.ScreenToWorldPoint(Input.mousePosition).x), Vector2.zero, 0);
            if (hit)
            {
                if (hit.collider.CompareTag("Left") && this.gameObject.CompareTag("Left")){

                    BeingTouched = true;

                }
                else
                {
                    if (hit.collider.CompareTag("Right") && this.gameObject.CompareTag("Right"))
                    {

                        BeingTouched = true;

                    }
                    else
                    {
                        BeingTouched = false;
                    }
                }
                {

                }
            }

        }
        else
        {
            BeingTouched = false;
        }
    }

    

    public bool Touched()
    {
        return BeingTouched;
    }
}
