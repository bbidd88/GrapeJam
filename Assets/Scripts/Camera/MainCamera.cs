using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Vector3 Distance = Vector3.zero;

    // Update is called once per frame
    private void Update()
    {
        if  (Player != null)
        {
            transform.position = Player.transform.position;
            transform.Translate(Distance);
        }        
    }
}
