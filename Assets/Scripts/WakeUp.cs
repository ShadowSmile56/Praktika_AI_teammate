using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class WakeUp : MonoBehaviour
{
    private Animator animator;
    public KeyCode wakeUp;
    float wakeUpRange = 3;
    float runRange = 7;
    public Text wakeText;
    Transform player;
    public GameObject dialog;
    private bool isawake=false;
    NavMeshAgent agent;
    private bool isgo = false;
    public TextMesh dialogText;
    public Text Hint;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        dialogText = dialog.GetComponent<TextMesh>(); 
        
    }

    void Start()
    {


    }
    void Update()
    {

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (isawake && distance < 15)
            animator.transform.LookAt(player);
        else
            wakeText.text = "Нажмите [E] , чтобы разбудить";
        if (distance <= wakeUpRange) {
            wakeText.gameObject.SetActive(true);
            if (Input.GetKeyUp(wakeUp)) { 
                if (!isawake)
                {
                    {
                        animator.Play("Idle_Battle");
                        isawake = true;
                        dialog.gameObject.SetActive(true);
                        wakeText.text = "Нажмите [Е], чтобы он следовал завами";
                        Hint.gameObject.SetActive(false);
                    }
                }
                else if(!isgo)
                {
                    isgo = true;
                    wakeText.text = "Нажмите [Е], чтобы он стоял на месте";
                }
                else
                {
                    isgo = false;
                    wakeText.text = "Нажмите [Е], чтобы он следовал завами";
                    dialogText.text = "Жду приказаний";
                }

            }   
        }
        else
        {
            wakeText.gameObject.SetActive(false);
            
        }
        if (isgo)
        {
            if(distance > wakeUpRange && distance<runRange) {
                agent.speed = 3;
                animator.Play("WalkForwardBattle");
                agent.SetDestination(player.transform.position);
                dialogText.text = "Следую за вами";
            }
            else if (distance> runRange)
            {
                agent.speed = 6;
                animator.Play("RunForwardBattle");
                agent.SetDestination(player.transform.position);
                dialogText.text = "Подождите, вы слишком быстры";
            }
            else
            {
                animator.Play("Idle_Battle");
                dialogText.text = "Я с вами";
            }
        }

    }
}
