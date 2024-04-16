using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameManager GM;
    void Start() {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player")
        {
            GM.gameOver.SetActive(true);
            GM.inGamePanel.SetActive(false);
            GM.player.GetComponent<ShowScore>().StopAllCoroutines();
            GM.scoreText.text = "Final Score : " + GM.player.GetComponent<ShowScore>().score;
        }
    }
    
}
