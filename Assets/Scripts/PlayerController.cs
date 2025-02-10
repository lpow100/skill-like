using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;

    [SerializeField] GameObject bullet;

    public float speed = 1f;
    public float DMG = 1;
    public float range = 5;
    public float bulletSpeed = 1;
    public float fireRate = 1;
    float fireTimer;

    float dashTimer;
    float noDashTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += 1;

        Vector3 movement = new Vector3(Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0, Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0);
        movement.Normalize(); movement *= speed * Time.deltaTime; // this fixes a bug where dignol movements are equal to 1.4 times speed
        transform.position += movement;

        if (Input.GetMouseButton(0) && 12 / fireRate < fireTimer){
            fireTimer = 0;
            GameObject shot = Instantiate(bullet);
            shot.GetComponent<BulletController>().direction = Mathf.Atan2(-(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).y,
                                                                          -(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).x);
            shot.GetComponent<BulletController>().speed = bulletSpeed / 2;
            shot.transform.position = transform.position;
        }
    }
}
