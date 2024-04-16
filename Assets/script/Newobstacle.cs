using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newobstacle : MonoBehaviour
{
    public int offSet = 32;
    private float offSetY = 1.25f;
    obstacle spawnerManager;

    private void Start()
    {
        spawnerManager = GameObject.Find("plateformManager").GetComponent<obstacle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(spawnerManager.plateform, new Vector3(0, 0, gameObject.transform.position.z + offSet), Quaternion.identity);
            for (int i = 0; i < offSet / 3; i++)
            {
                int randomInt = Random.Range(0,2);
                GameObject door = Instantiate(spawnerManager.obstacles[randomInt],
                    new Vector3(spawnerManager.positions[Random.Range(0,spawnerManager.positions.Length)].position.x,transform.position.y 
                    + offSetY, transform.position.z 
                    + offSet/2 + (i * 5)),
                    spawnerManager.obstacles[randomInt].transform.rotation);
            }
        }
    }
}