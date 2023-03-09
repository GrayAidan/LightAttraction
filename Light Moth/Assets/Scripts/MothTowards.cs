using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothTowards : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public float mothOverlap;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] lights = Physics2D.OverlapCircleAll((Vector2)this.transform.position, mothOverlap, LayerMask.GetMask("Light"));

        if (lights.Length > 0)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                Dimmer dim = lights[i].GetComponent<Dimmer>();

                Vector2 vectorTowardsLight = lights[i].transform.position - transform.position;

                _rb.AddForce(vectorTowardsLight.normalized * dim.intensity * speed * Time.deltaTime);

                Vector2 velocity = Vector2.ClampMagnitude(_rb.velocity, maxSpeed);
                _rb.velocity = velocity;
                print(lights[i]);
            }
        }

        if(_rb.velocity.x < 0)
        {
            _sr.flipX = false;
        }
        else
        {
            _sr.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            GameObject.Find("SpawnPoint").gameObject.GetComponent<SpawnPoint>().Respawn(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, mothOverlap);
    }
}
