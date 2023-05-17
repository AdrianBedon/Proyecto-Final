using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public float speed = 15;
    public GameObject player;
    public Rigidbody rb;
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    public GameObject collisionExplosion;
    Animator anim;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
	}

    void Start()
    {
        FindPlayer();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            FindPlayer();
        }
        else
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(player.transform.position, transform.position) < 10)
            {
                anim.SetBool("Walk_Anim", false);
                anim.SetBool("Roll_Anim", true);
                pos = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime * 2);
            }                
            else
            { 
                anim.SetBool("Roll_Anim", false);
                anim.SetBool("Walk_Anim", true);
                pos = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            rb.MovePosition(pos);
            this.gameObject.transform.LookAt(player.transform);
        }
    }

    void FindPlayer()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void die()
    {
        if (gameObject != null)
        {
            Destroy(gameObject, 3f);
            GameObject explosion = (GameObject)Instantiate(collisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }
        if(OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
    }
}
