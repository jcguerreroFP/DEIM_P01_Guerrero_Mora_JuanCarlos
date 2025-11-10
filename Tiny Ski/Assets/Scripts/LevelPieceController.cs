using UnityEngine;

public class LevelPieceController : MonoBehaviour
{
    public float speed = 5f;

    public float size;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Respawn"))
        {
            //GameObject.Find("Generator").GetComponent<LevelGenerator>().AddNewPiece();
            LevelGenerator.AddNewPiece(transform.position - new Vector3(0, size, 0));
            
        }
        
    }
}
