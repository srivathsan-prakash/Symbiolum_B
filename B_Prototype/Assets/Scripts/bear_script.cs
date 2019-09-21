﻿using UnityEngine;

public class bear_script : MonoBehaviour
{
    public bool is_possessed;
    public bool skill_active;

    public float sp = 8.0f;
    public Transform[] spots;
    private int goal;
    private float wait = 2.0f;

    public GameObject player;

    private void Start()
    {
        goal = Random.Range(0, spots.Length);
    }

    void Update()
    {
        if (is_possessed)
            transform.position = player.transform.position;
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, spots[goal].position, sp * Time.deltaTime);
            if (Vector3.Distance(transform.position, spots[goal].position) < 0.3f)
            {
                if (wait > 0)
                    wait -= Time.deltaTime;
                else
                {
                    wait = 2.0f;
                    goal = Random.Range(0, spots.Length);
                }

            }
        }
    }

    public void activate_skill()
    {
        if (skill_active)
            deactivate_skill();

        skill_active = true;
    }

    public void deactivate_skill()
    {
        skill_active = false;
    }

    public void start_hosting_bear()
    {
        is_possessed = true;
    }

    public void end_hosting_bear()
    {
        deactivate_skill();
        is_possessed = false;
    }
}
