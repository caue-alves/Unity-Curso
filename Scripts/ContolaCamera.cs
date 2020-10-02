using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContolaCamera : MonoBehaviour
{
    public GameObject Player;
    Vector3 distanceToCompense;
    //Instancia as variáveis para serem preenchidas

    // Update is called once per frame
    void Start()
    {
        distanceToCompense = transform.position - Player.transform.position;
        // Calcula a distância a ser compensada 
    }

    void Update()
    {
        transform.position = Player.transform.position + distanceToCompense;
        // Move a câmera para um local com certa margem
    }
}
