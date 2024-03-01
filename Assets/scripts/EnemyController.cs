using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    

    [SerializeField]
    float moveForce;
    [SerializeField]
    float JumpTime;
    [SerializeField]
    float JumpForce;
    [SerializeField]
    float EnemyHealth = 5;

    [SerializeField]
    ParticleSystem deathParticles;
    [SerializeField]
    GameObject coinObject;

    EnemySpawner enemySpawnerClass;
    Rigidbody rb;
    GameObject movementTarget;
    MoneyHandler moneyHandlingScript;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        JumpTimer = JumpTime;
        enemySpawnerClass = GameObject.Find("EnemySpawnerManager").GetComponent<EnemySpawner>();
        moneyHandlingScript = GameObject.Find("PlayerMoneyHandler").GetComponent<MoneyHandler>();
        deathParticles = GameObject.Find("EnemyDeathParticles").GetComponent<ParticleSystem>();
    }

    private void Awake()
    {
        movementTarget = GameObject.Find("Player");
    }

    void Movement()
    {
        this.transform.LookAt(movementTarget.transform);
        rb.AddForce(rb.transform.forward * moveForce, ForceMode.Force);
        //add a small jump force occasionally so it doesnt get stuck against the floor
    }

    private float JumpTimer;
    void EnemyJump()
    {
        JumpTimer -= Time.deltaTime;
        if (JumpTimer <= 0)
        {
            rb.AddForce(rb.transform.up * JumpForce, ForceMode.Impulse);
            JumpTimer = JumpTime;
        }
    }

    //function that runs enemy regen stuff, checks if the enemy health is at a value suitable for death. maybe multiple enemy health states will be added here (you have to get past 3 of the healthbars before it dies for example)
    void EnemyHealthHandler()
    {
        if (EnemyHealth <= 0)
        {
            EnemyDie();
        }
    }

    //health getter and setter for enemy damage functions
    public float GetEnemiesHealth()
    {
        return EnemyHealth;
    }
    public void SetEnemiesHealth(float newHealtVal)
    {
        EnemyHealth = newHealtVal;
    }

    //function that runs all functions and things associated with the enemy dying.
    void EnemyDie()
    {
        //death particles 
        //death sound
        //add to players score? or maybe spawn coins that then fly towards the players score for extra satisfaction
        enemySpawnerClass.TakeFromEnemyCount();
        Instantiate(coinObject, this.transform.position, Quaternion.identity);
        ParticleSystem newparticle = Instantiate(deathParticles, this.transform.position, Quaternion.identity);
        newparticle.Play();
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        EnemyJump();
        EnemyHealthHandler();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            moneyHandlingScript.TakeFromMoneyCount(1);
            collision.transform.GetComponent<Rigidbody>().AddForce(this.transform.forward * 40, ForceMode.Impulse);
            //take 1 coin from the player
            //maybe change to oncollission stay? and add a timer?
            //maybe add a impulse force to the player too
        }
    }
}
