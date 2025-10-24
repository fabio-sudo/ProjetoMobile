using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private Vector3 rotation;

    private void Start()
    {
        var xRotation = Random.Range(0.5f, 1f);
        rotation = new Vector3(xRotation, 0f, 0f);
    }

    private void Update()
    {
        transform.Rotate(rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstaculo")){
            Destroy(gameObject);
        }
    }
}
