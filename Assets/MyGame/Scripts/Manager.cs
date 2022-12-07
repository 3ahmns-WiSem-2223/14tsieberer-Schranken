using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject schranke1;
    [SerializeField] private GameObject schranke2;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject end;
    [SerializeField] private float speed;

    bool open1;
    bool open2;

    public void SchrankeEins()
    {
        Debug.Log("S1");
        if(open1 != true)
        {
            schranke1.transform.position = new Vector2(0, 5.5f);
            open1 = true;
        }
        else
        {
            schranke1.transform.position = new Vector2(0, 2.65f);
            open1 = false;
        }
    }
    public void SchrankeZwei()
    {
        Debug.Log("S2");
        if (open2 != true)
        {
            schranke2.transform.position = new Vector2(0, -5.5f);
            open2 = true;
        }
        else
        {
            schranke2.transform.position = new Vector2(0, -2.65f);
            open2 = false;
        }
    }

    void MovePlayer()
    {
        if (player.transform.position != end.transform.position)
        {
            player.GetComponent<Animator>().SetBool("walkthrough", true);
            player.transform.position = Vector2.MoveTowards(player.transform.position, end.transform.position, speed * Time.deltaTime);
        }
        else
        {
            player.GetComponent<Animator>().SetBool("walkthrough", false);
        }
    }

    private void FixedUpdate()
    {
        if(open1 && open2 == true)
        {
            MovePlayer();
        }
        else
        {
            player.GetComponent<Animator>().SetBool("walkthrough", false);
        }
    }
}
