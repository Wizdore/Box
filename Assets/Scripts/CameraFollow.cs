using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    Vector2 vel;
    public GameObject player;
    public float smoothx;
    public float smoothy;

    void Update()
    {

        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x,ref vel.x, smoothx*Time.deltaTime*100);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref vel.y, smoothy * Time.deltaTime * 100);

        transform.position = new Vector3(posx, posy, transform.position.z);

    }
}
