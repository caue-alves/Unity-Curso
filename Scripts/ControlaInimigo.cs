using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 5; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        // Move o zumbi para perto do Player
        Vector3 direcao = Jogador.transform.position - transform.position;
        Quaternion NovaRotacao = Quaternion.LookRotation(direcao);

        //Faz ele olhar para o personagem
        GetComponent<Rigidbody>().MoveRotation(NovaRotacao);

        if (distancia > 2.5)
        {
            // Cria uma margem

            GetComponent<Rigidbody>().MovePosition
                (GetComponent<Rigidbody>().position +
                direcao.normalized/*Direção normalizada*/ * Velocidade * Time.deltaTime);
            GetComponent<Animator>().SetBool("Atacando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", true);
        }
    }

    void AtacaJogador ()
    {
        Jogador.GetComponent<PlayerController>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<Animator>().SetBool("Dead", true);
        Jogador.GetComponent<PlayerController>().vivo = false;
        Time.timeScale = 0;
    }
}
