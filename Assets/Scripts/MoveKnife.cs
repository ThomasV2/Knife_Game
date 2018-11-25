using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKnife : MonoBehaviour
{

    int direction;
    bool isStab = false;
    bool isPause = false;
    Animation anim;
    Ray stabRaycast;

    public float speed = 50f;
    public GameObject weapon;
    public TriggerManager triggerManager;

    // Use this for initialization
    void Start()
    {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 300f, this.transform.eulerAngles.z);
        this.direction = 1;
        anim = weapon.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStab && !isPause)
        {
            this.transform.Rotate(Vector3.up, Time.deltaTime * speed * direction);
            if (this.transform.eulerAngles.y >= 90 && this.transform.eulerAngles.y <= 300)
            {
                if (direction == 1)
                {
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 90f, this.transform.eulerAngles.z);
                    direction = -1;
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 300f, this.transform.eulerAngles.z);
                    direction = 1;
                }
            }
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
                StartCoroutine(Stab());
#else
            if (Input.touchCount > 0)
                StartCoroutine(Stab());
#endif
        }
    }

    IEnumerator Stab() {
        this.isStab = true;
        this.anim.Play();
        while (this.anim.isPlaying)
            yield return null;
        int newDirection = triggerManager.IsTrigger(weapon.transform.position);
        if (newDirection != 0)
            direction = newDirection;
        this.isStab = false;
        yield return null;
    }

    public void Pause()
    {
        isPause = true;
        return;
    }

    public void Run()
    {
        isPause = false;
        return;
    }

    public void StartGame()
    {
        isPause = false;
        isStab = false;
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 300f, this.transform.eulerAngles.z);
        this.direction = 1;
    }
}
