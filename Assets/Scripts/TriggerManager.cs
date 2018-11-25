using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    public BoxCollider[] colliders;
    public int current = 0;

    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        colliders = this.gameObject.GetComponentsInChildren<BoxCollider>();
        foreach (var boxCollider in colliders)
        {
            boxCollider.gameObject.SetActive(false);
        }
        colliders[0].gameObject.SetActive(true);
        levelManager = Object.FindObjectOfType<LevelManager>();
    }

    public int IsTrigger(Vector3 weaponPosition)
    {
        RaycastHit hit;
        if (Physics.Raycast(weaponPosition, Vector3.down, out hit))
        {
            if (hit.transform.tag == "Good")
            {
                Debug.Log("Good hit");
                levelManager.GetOnePoint();
                return NextTrigger();
            }
            else
            {
                Debug.Log("Bad hit");
                levelManager.EndGame();
            }   
        }
        else
            Debug.Log("no hit");
        return 0;
    }

    public int NextTrigger()
    {
        if (colliders[0].gameObject.activeSelf == true)
        {
            colliders[0].gameObject.SetActive(false);
            colliders[++current].gameObject.SetActive(true);
            return -1;
        }
        else
        {
            colliders[current].gameObject.SetActive(false);
            colliders[0].gameObject.SetActive(true);
            if (colliders.Length <= current + 1)
            {
                current = 0;
            }
            return 1;
        }
    }

    public void StartGame()
    {
        this.current = 0;
        foreach (var boxCollider in colliders)
        {
            boxCollider.gameObject.SetActive(false);
        }
        colliders[0].gameObject.SetActive(true);
    }
}
