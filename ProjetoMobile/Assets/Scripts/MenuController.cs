using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameManager _gameManager;

    public void Play()
    {
        _gameManager.Enable();
        Destroy(gameObject);
    }




}
