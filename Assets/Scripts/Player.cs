using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
    
    //UI and health
    public float health = 100;
    public float maxHealth = 100;
    public HealthBar healthBar;

    //States bools
    bool vulnerable = true;
    bool immune = false;
    bool can_move = true;

    //Click_Move
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
    
    // Animation
    public float speed;

    private void Start() {
        //Click and Move
        _navMeshAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main; //tag lookup
    }
    private void Update() {

        // Animation state transition
        speed = Mathf.Max(Mathf.Abs(_navMeshAgent.velocity.x), Mathf.Abs(_navMeshAgent.velocity.y));
        transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", speed);

        // Check for death
        if (health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //Click and Move
        if(Input.GetMouseButtonDown(0) && can_move){
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 500)){
                _navMeshAgent.destination = hit.point;
            }
        }
    }


    void OnTriggerEnter(Collider other){
        //print(other.gameObject.name);
        if (other.gameObject.CompareTag("Key")){
            //print("touched");
            int keynum = (int)char.GetNumericValue(other.gameObject.name[3]); //suppose the name is "KeyX", where X is the number
            Destroy(other.gameObject);
            //print(keynum);
            PublicVars.Keys[keynum] = true;
        }
        else if (other.gameObject.CompareTag("Fixed_Trap")){
            ChangeHealth(-25);
            StartCoroutine("BeInvulnerable");
            healthBar.UpdateHealthBar();
        }
        else if (other.CompareTag("Poison")){
            StartCoroutine("Poisoned");
        }
        else if (other.CompareTag("Sleep")){
            StartCoroutine("Sleeping");
        }
    }
    public void ChangeHealth(int value) {
        if (vulnerable) {
            health += value;
        }
    }

    
    IEnumerator BeInvulnerable(){
        vulnerable = false;
        yield return new WaitForSeconds(2f);
        vulnerable = true;
    }

    IEnumerator BeImmune(){
        immune = true;
        yield return new WaitForSeconds(3f);
        immune = false;
    }

    IEnumerator Sleeping(){
        if (!immune){
            StartCoroutine("BeImmune");
            _navMeshAgent.isStopped = true;
            can_move = false;
            yield return new WaitForSeconds(2f);
            _navMeshAgent.isStopped = false;
            can_move = true;
        }
    }

    IEnumerator Poisoned(){
        if (!immune){
            StartCoroutine("BeImmune");
            _navMeshAgent.speed *= 0.2f;
            yield return new WaitForSeconds(2f);
            _navMeshAgent.speed *= 5f;
        }
    }

}
