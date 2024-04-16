using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject platformPrefab; // Le prefab de la plateforme à créer
    public Transform spawnPoint; // L'endroit où la nouvelle plateforme sera créée
    public string playerTag = "Player"; // Le tag du joueur
    public int spawnOffset = 0; // L'offset pour la position de la plateforme
    public object prefabobstacle ;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag)) // Vérifie si le joueur entre dans le trigger
        {
            SpawnPlatform(); // Crée une nouvelle plateforme
        }
    }

    private void SpawnPlatform()
    {
        Vector3 spawnPosition = new Vector3(0.1f,0,gameObject.transform.position.z + spawnOffset); // Calcule la position de spawn en ajoutant l'offset
        GameObject insobject = Instantiate(platformPrefab, spawnPosition, Quaternion.identity); // Crée une nouvelle plateforme au spawnPoint
    }
}
