using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image healthBarImage;
    public Player player;
    public void UpdateHealthBar(){
        healthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
    }

    IEnumerator Poisoned()
    {   
        Debug.Log("starting");
        Color old = GetComponent<Image>().color;
        GetComponent<Image>().color = new Color(1,0,1,1);
        yield return new WaitForSeconds(4f);
        GetComponent<Image>().color = old;
    }
}
