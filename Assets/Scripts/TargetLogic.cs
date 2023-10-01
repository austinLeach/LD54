using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    public List<string> tags = new List<string>();
    private void Awake()
    {
        tags.Add("Player");
        tags.Add("Enemy");
        tags.Add("Enemy2");
        tags.Add("Enemy3");
        tags.Add("Enemy4");
    }
    
    void Start()
    {
        
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
        for (int i = 0; i < tags.Count; i++)
        {
            Debug.Log(tags[i].ToString());
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
