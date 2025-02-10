using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float direction;
    public float speed;

    void Update()
    {
        transform.position += new Vector3(Mathf.Cos(direction)*speed,Mathf.Sin(direction)*speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Player") 
        {
            Destroy(gameObject);
        }
    }
}
