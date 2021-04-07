using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Ball : MonoBehaviour
{
    public TextMeshProUGUI Countdown;
    public float speed;
    public Rigidbody2D body;
    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(asspc());
        startpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        
    }

    // Update is called once per frame

    private void Update()
    {
        body.velocity = speed * (body.velocity.normalized);
    }

    public void launch()
    {
        body.velocity = new Vector2(0.3f * speed, speed);
    }


    IEnumerator asspc()
    {
        Countdown.text = "3";
        yield return new WaitForSeconds(1f);
        FindObjectOfType<AudioManager>().playRetry();
        Countdown.text = "2";
        yield return new WaitForSeconds(1f);
        FindObjectOfType<AudioManager>().playRetry();
        Countdown.text = "1";
        yield return new WaitForSeconds(1f);

        Countdown.text = "0";
        Countdown.enabled = false;
        launch();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touching");
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Debug.Log("Paddle");
            FindObjectOfType<GameManager>().UpdateScore();
            FindObjectOfType<AudioManager>().playHit();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameField"))
        {
            FindObjectOfType<GameManager>().LOSE();
        }
    }

    public void resetpos()
    {
        body.velocity = new Vector2(0f, 0f);
        this.transform.position = startpos;
        
        StartCoroutine(asspc());
    }

}
