using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        FindObjectOfType<GameManager>().Reset();
    }
}
