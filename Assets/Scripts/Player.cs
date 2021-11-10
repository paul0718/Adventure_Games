using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
    
    //UI and health
    bool canChangeHealth = true;
    public float health = 100;
    public float maxHealth = 100;
    public HealthBar healthBar;
    
    // Animation
    bool actionState;

    public float speed;
    private void Start() {
       
    }
    private void Update() {

        speed = Mathf.Max(Mathf.Abs(GetComponent<NavMeshAgent>().velocity.x), Mathf.Abs(GetComponent<NavMeshAgent>().velocity.y));
        transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", speed);

        // Check for death
        if (health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        else if (other.gameObject.CompareTag("Trap")){
            ChangeHealth(-25);
            StartCoroutine("BeInvulnerable");
            healthBar.UpdateHealthBar();
        }
        else if (other.gameObject.CompareTag("Guard")){
            //Restart() or TakeDamage()
            //Guards.Stun(2f)
        }
    }
    public void ChangeHealth(int value) {
        if (canChangeHealth) {
            health += value;
        }
    }

    
    IEnumerator BeInvulnerable(){
        canChangeHealth = false;
        yield return new WaitForSeconds(1f);
        canChangeHealth = true;
    }
}
