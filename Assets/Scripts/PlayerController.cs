using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    float moveVelocity;

    private int eaten;

    public Text score;
    public Text wintext;

    bool grounded;
    bool doubleJumpAble;

    void Start()
    {
        score.text = "";
        wintext.text = "";
        eaten = 0;
    }

    void Update()
    {
        moveVelocity = 0;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                doubleJumpAble = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed * Time.deltaTime*100);
            }
            else if (doubleJumpAble)
            {
                doubleJumpAble = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed * Time.deltaTime*100);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -moveSpeed * Time.deltaTime*100;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = moveSpeed * Time.deltaTime*100;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        if(eaten == 8)
        {
            wintext.text = "Mission Complete";
            gameObject.SetActive(false);
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
        if(collision.CompareTag("Pick up"))
        {
            eaten++;
            score.text = eaten.ToString();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }

}
