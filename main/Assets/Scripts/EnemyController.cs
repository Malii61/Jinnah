using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{
    //Enemy Animations//
    public Animator enemyAnim;
    

    public AudioClip babyBreath;
    public GameObject jumpscareCam;
    public Animator jsAnim;
    public GameObject horrorDoll;
    private float jsTimer = 0f;
    public LayerMask whatIsGround;
    /// <Patrolling>
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    /// </Patrolling>
    private float enemyMoveCheckX = 0f;
    private float enemyMoveCheckZ = 0f;
    private bool oneTimeProcess= true;
    public float lookRadius = 10f;

    public float enemyMaxSpeed = 2f;
    private AudioSource _audioSource;
    Transform target;
    NavMeshAgent agent;

    //Enemy Vision//
    public Transform enemyCam;
    public float enemyActivateDistence;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
    }
    private bool EnemyMovingOrNot()
    {
        if (enemyMoveCheckZ == transform.position.z && enemyMoveCheckX == transform.position.x)
        {
            return false;
        }
        else
        {
            return true;    
        }
    } 
    // Update is called once per frame
    void Update()
    {
        enemyAnim.Play("enemyAnims");
        RaycastHit hit;
        active = Physics.Raycast(enemyCam.position, enemyCam.TransformDirection(Vector3.forward), out hit, enemyActivateDistence);
        if (_audioSource.isPlaying || StunEnemy.audioSource.isPlaying) ;
        else _audioSource.PlayOneShot(babyBreath);
        
        float distance = Vector3.Distance(target.position, transform.position);
        Vector3 targetDir = target.position - transform.position;
        float _angle = Vector3.Angle(targetDir,transform.forward);

        if (distance <= lookRadius || (_angle <= 70 && _angle >= -70 && distance <= 55f) || TaskManager.lastKeyFound)
        {
            if (TaskManager.lastKeyFound && oneTimeProcess)
            {
                agent.speed += 2f;
                enemyMaxSpeed += 2f;
                oneTimeProcess = false;
            }
            agent.SetDestination(target.position);

            if(distance <= 6.0f && GetComponent<EnemyRespawn>().enemyCanMove && _angle <= 50 && _angle >= -50)
            {
                if (active)
                {
                    if (hit.transform.tag == "Door" || hit.transform.tag == "Wall")
                    {
                        print("Enemy önünde engel var:  " + hit.transform.tag);
                    }
                    else 
                    {
                        FaceTarget();
                    }
                }
            }
        }
        else
        {
            Patroling();
        }
        if (!EnemyMovingOrNot())
        {
            enemyAnim.SetBool("isWalking", false);
            SearchWalkPoint();
        }
        else
        {
            enemyAnim.SetBool("isWalking", true);
        }

        enemyMoveCheckZ = transform.position.z;
        enemyMoveCheckX = transform.position.x;

    }
    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    public void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    void FaceTarget()
    {
        horrorDoll.SetActive(false);
        jumpscareCam.SetActive(true);
        jsAnim.Play("DirectionalLight");
        Time.timeScale = 0f;
        jsTimer += Time.unscaledDeltaTime;
        if (jsTimer > 2f)
        {
            SceneManager.LoadScene(2);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
