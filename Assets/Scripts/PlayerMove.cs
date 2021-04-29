using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject goal1;
    public GameObject goal2;

    bool check = false;

    public GameObject scoretxt;
    private int score;

    public GameObject RestartButton;
    public GameObject TapButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        gameObject.tag = "Player";
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // направление движения
        if (!check) transform.position = Vector3.MoveTowards(transform.position, goal1.transform.position, 2f * Time.deltaTime);
        if (check) transform.position = Vector3.MoveTowards(transform.position, goal2.transform.position, 2f * Time.deltaTime);

        //вращение при движении
        transform.rotation *= Quaternion.Euler(0f, 0f, 1f);
    }

    //по нажатию меняем направление
    public void change()
    {
        check = !check;
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        //когда коснулся цели
        if (other.tag == "Goal1")
        {
            check = !check;

            // изменение позиции точки
            goal1.SetActive(false);
            goal2.SetActive(true);
            goal2.transform.position = new Vector3(Random.Range(-1.2f, 1.5f), -2f, 0);

            score++;
            scoretxt.GetComponent<Text>().text = "" + score;
        }
        if (other.tag == "Goal2")
        {
            check = !check;

            // изменение позиции точки
            goal2.SetActive(false);
            goal1.SetActive(true);
            goal1.transform.position = new Vector3(Random.Range(-1.2f, 1.5f), 1.5f, 0);

            score++;
            scoretxt.GetComponent<Text>().text = "" + score;
        }
        if(other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;
            TapButton.SetActive(false);
            RestartButton.SetActive(true);
        }
    }
}
