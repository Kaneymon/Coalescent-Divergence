using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInstanceKiller : MonoBehaviour
{
    [SerializeField]
    float deathTime = 2;
    [SerializeField]
    string originalObjectName;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name != originalObjectName)
        {
            deathTime -= Time.deltaTime;
            if (deathTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }


    }
}
