using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{

    public int score = 0;
    public TextMeshProUGUI textScore;
    void Start()
    {
        StartCoroutine(UpgradeScore());
    }
    void Update()
    {
        textScore.text = "Score : " + score;
    }

    public IEnumerator UpgradeScore(){
        score += 1;
        yield return new WaitForSeconds(1);
        StartCoroutine(UpgradeScore());
    }
}
