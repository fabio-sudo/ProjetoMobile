using Unity.Cinemachine;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private Vector3 rotation;
    public ParticleSystem deadParticula;
    private CinemachineImpulseSource _impulseSource;
    private PlayerController _playerController;

    private void Start()
    {
        var xRotation = Random.Range(90f, 180f);
        rotation = new Vector3(xRotation, 0);

        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _playerController = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstaculo")){

            Instantiate(deadParticula, transform.position,Quaternion.identity);


            //Este trecho muda a força de impacto de acordo com a proximidade com o player
            if (_playerController != null)
            {
                var distancia =
                    Vector3.Distance(transform.position, _playerController.transform.position);
                var force = 1 / distancia;

                //Gera o impulso fazendo a tela tremer
                _impulseSource.GenerateImpulse(force);
            }

            Destroy(gameObject);
        }
    }
}
