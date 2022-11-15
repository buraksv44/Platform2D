using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
     Rigidbody2D rb;
     bool onGround;
     float width;
    [SerializeField] LayerMask engel;
    [SerializeField] float speed;
     static int totalEnemyNumber=0;
    
    // Start is called before the first frame update
    void Start()
    {
        totalEnemyNumber++;
        //Debug.Log(totalEnemyNumber);
        rb = GetComponent<Rigidbody2D>();
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right * width / 2), Vector2.down, 2f,engel);
        if (hit.collider !=null)
        {
            onGround = true;

        }
        else
        {
            onGround = false;
        }
        Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 PlayerRealPosition = transform.position + (transform.right * width / 2);
        Gizmos.DrawLine(PlayerRealPosition, PlayerRealPosition + new Vector3(0, -2f, 0));
    }

    void Flip()
    {
        if (!onGround)
        {
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
        rb.velocity = new Vector2(transform.right.x * speed, 0f);
    }
}
