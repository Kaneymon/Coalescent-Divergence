using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    GameObject magnetizedToObject;

    [SerializeField]
    float moveForce;

    [SerializeField]
    float spinForce;


    MoneyHandler moneyScript;

    Rigidbody rb;
    void Start()
    {
         rb = this.GetComponent<Rigidbody>();
        magnetizedToObject = GameObject.Find("CoinMagnet");
        moneyScript = GameObject.Find("PlayerMoneyHandler").GetComponent<MoneyHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(magnetizedToObject.transform);
        rb.AddForce(rb.transform.forward * moveForce, ForceMode.Force);
        rb.AddTorque(rb.transform.right*spinForce, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == magnetizedToObject)
        {
            //add to moneyCount
            moneyScript.AddToMoneyToCount(1);
            //destroy coin instance
            Destroy(this.gameObject);
        }
    }

}
