using UnityEngine;
using System.Collections;

public class CoinRotation : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 100, 0));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
