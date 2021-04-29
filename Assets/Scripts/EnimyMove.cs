using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnimyMove : MonoBehaviour
{
    public GameObject enemy_finish;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemy_finish.transform.position, 2f * Time.deltaTime);

        transform.rotation *= Quaternion.Euler(0f, 0f, 1f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //когда коснулся цели
        if (other.tag == "EnemyFinish")
        {
            // респаун врага
            transform.position = new Vector3(-3f, Random.Range(-1.5f, 1.5f), 0f);
            transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-25f, 25f));
        }
    }
}
