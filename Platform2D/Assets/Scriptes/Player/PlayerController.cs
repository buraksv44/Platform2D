using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 5f;
    [SerializeField] float currentAttackTimer;
    [SerializeField] float defaultAttackTimer;
    float mySpeedX;
    [SerializeField] float jumpAmount = 3f;
    [SerializeField] GameObject arrow;
    [SerializeField] bool attacked; 
    Vector3 defaultlocalScale;
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] int arrowNumber;
    [SerializeField] TextMeshProUGUI ArrowText;
    [SerializeField] AudioClip dieMusic;
    [SerializeField] GameObject winPanel, losePanel;
    [SerializeField] GameObject game;
    void Start()
    {
        attacked = false;
        rb = GetComponent<Rigidbody2D>();
        defaultlocalScale = transform.localScale;
        anim = GetComponent<Animator>();
        ArrowText.text = arrowNumber.ToString();
    }
    void Update()
    {
        
        mySpeedX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(mySpeedX * Speed, rb.velocity.y );
        anim.SetFloat("Speed", Mathf.Abs(mySpeedX));
        #region player sag sol yukarýya
        if (mySpeedX > 0)
        {
            transform.localScale = new Vector3(defaultlocalScale.x, defaultlocalScale.y, defaultlocalScale.z);
        }
        else if (mySpeedX < 0)
        {
            transform.localScale = new Vector3(-defaultlocalScale.x, defaultlocalScale.y, defaultlocalScale.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Approximately(rb.velocity.y,0))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }
        #endregion

        #region  Ok atma
        if (Input.GetMouseButtonDown(0) && arrowNumber >0)
        {
            if (attacked ==false)
            {
                attacked = true;
                anim.SetTrigger("Attack");
                Invoke("Fire", 0.5f);
            }
            

        }
       

        if (attacked == true)
        {
          currentAttackTimer -= Time.deltaTime;
        }
        else
        {
          currentAttackTimer = defaultAttackTimer;    
        }
        if (currentAttackTimer <= 0 )
        {
         attacked = false;
        }
    }
    #endregion
    void Fire()
    {
        GameObject ok = Instantiate(arrow, transform.position, Quaternion.identity);
        ok.transform.parent = GameObject.Find("Arrows").transform;
        if (transform.localScale.x > 0)
        {
            ok.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);

        }
        else
        {
            Vector3 okScale = ok.transform.localScale;
            ok.transform.localScale = new Vector3(-okScale.x, okScale.y, okScale.z);
            ok.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
        }

        arrowNumber--;
        ArrowText.text = arrowNumber.ToString();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Enemy")
        {
           Die();
           
        }
        if (collision.gameObject.tag == "Enem")
        {
            Die();
            
        }

        else if (collision.gameObject.CompareTag ("Finish"))
        {
            //winPanel.SetActive(true);
            
            StartCoroutine(Wait(true));
            Destroy(game);
        }
    }


    void Die()
    {
        GameObject.Find("SoundManagers").GetComponent<AudioSource>().clip = null;
        GameObject.Find("SoundManagers").GetComponent<AudioSource>().PlayOneShot(dieMusic);
        anim.SetTrigger("Die");
        anim.SetFloat("Speed", 0);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        enabled = false;
        StartCoroutine(Wait(false));
        // losePanel.SetActive(true);

    }
    IEnumerator Wait(bool win)
    {
        yield return new WaitForSecondsRealtime(2f);
        if (win == true)
        {
            winPanel.SetActive(true);
        }

        else
        {
            losePanel.SetActive(true);
        }
        
       
    }
}
     
