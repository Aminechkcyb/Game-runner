using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float middleX = 2f; // Position du milieu sur l'axe X
    public float leftX = -3f; // Position de gauche sur l'axe X
    public float rightX = 2f; // Position de droite sur l'axe X
    public float jumpForce = 10f; // Force du saut

    // Variable pour suivre la position actuelle du joueur
    private float targetX;

    // Variable pour suivre la direction de déplacement du joueur
    private int direction = 0; // 0 pour immobile, -1 pour gauche, 1 pour droite

    // Référence au Rigidbody du joueur
    private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        // Déplacement avant
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Met à jour la position cible en fonction de la direction
        targetX = (direction == 1) ? rightX : ((direction == -1) ? leftX : middleX);

        // Déplacement vers la gauche, le milieu ou la droite
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x != rightX)
        {
            direction = -1; // Déplacer vers la gauche
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x != leftX)
        {
            direction = 1; // Déplacer vers la droite
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.x != middleX)
        {
            direction = 0; // Déplacer vers le milieu
        }

        // Déplacer le joueur vers la position cible
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);

        // Sauter lorsque la touche Espace est enfoncée
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    // Assure que le joueur commence à la position gauche
    void Start()
    {
        transform.position = new Vector3(middleX, transform.position.y, transform.position.z);
        rb = GetComponent<Rigidbody>(); // Récupère le Rigidbody du joueur
    }

    // Fonction pour effectuer un saut
    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f) // Vérifie que le joueur n'est pas déjà en train de sauter
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Ajoute une force vers le haut pour simuler le saut
        }
    }
}
