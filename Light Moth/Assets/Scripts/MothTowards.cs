using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothTowards : MonoBehaviour
{
    public float maxSpeed;
    public float mothOverlap;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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

                _rb.AddForce(vectorTowardsLight.normalized * dim.intensity * maxSpeed * Time.deltaTime);

                Vector2 velocity = Vector2.ClampMagnitude(_rb.velocity, 1);
                _rb.velocity = velocity;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            GameObject.Find("SpawnPoint").gameObject.GetComponent<SpawnPoint>().Respawn();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, mothOverlap);
    }
}
