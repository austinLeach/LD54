using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetLogic : MonoBehaviour
{
    public WinScreen winScreen;
    public PlayerMotor player;
    public List<string> tags = new List<string>();
    bool playerDead = false;
    private void Awake()
    {
        tags.Add("Player");
        tags.Add("Enemy");
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            tags.Add("Enemy2");
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            tags.Add("Enemy2");
            tags.Add("Enemy3");
            tags.Add("Enemy4");
        }
    }


    private void Update()
    {
        if (tags.Count == 1 && playerDead == false)
        {
            if (tags[0] == "Player")
            {
                winScreen.ShowWinScreen();
                player.StopMovement();
            }
        }
    }

    public string ChooseTarget(string myTag)
    {
        string targetTag = "";
        do
        {
            targetTag = tags[Random.Range(0, tags.Count)];
        } while (myTag == targetTag);

        return targetTag;
    }

    public void RemoveTarget(string target)
    {
        if(target == "Player")
        {
            playerDead = true;
        }
        Debug.Log("Remove: " + target);
        for (int i = 0; i < tags.Count; i++) {
            GameObject findingWhoIsFollowing = GameObject.Find(tags[i]);
            string compare;
            try
            {
                compare = findingWhoIsFollowing.GetComponent<Enemy>().targetName;
            } catch
            {
                continue;
            }
            
            if (target == compare)
            {
                findingWhoIsFollowing.GetComponent<Enemy>().targetName = "NULL";
            }
        }
        for (int i = 1;i < tags.Count;i++)
        {
            Debug.Log(tags[i].ToString());
            if (tags[i].ToString() == target)
            {
                tags.RemoveAt(i);
                break;
            }
        }
    }
}
