using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    public Animator am;

    public float speed = 1f;

    public AudioClip runClip;
    public AudioClip groanClip;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        PlayRunSound();
        PlayGroanSound();
    }

    void Update()
    {
        agent.speed = speed;
        if (target != null)
        {
            agent.SetDestination(target.position);
            am.Play("Z_Run_InPlace");


        }
    }

    async void PlayRunSound()
    {
        if (target != null)
        {
            AudioSystem.Play(runClip, 0.3f);

            await new WaitForSeconds(runClip.length);
            PlayRunSound();
        }
    }

    async void PlayGroanSound()
    {
        if (target != null)
        {
            AudioSystem.Play(groanClip, 0.3f);

            await new WaitForSeconds(groanClip.length);
            PlayGroanSound();
        }
    }
}
