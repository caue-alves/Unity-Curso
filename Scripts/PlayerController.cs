using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 30;
    Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public bool vivo = true;

    // Instancia as variáveis a serem preenchidas

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        // Captura os impulsos dos eixos

        this.direcao = new Vector3(eixoX, 0, eixoZ);
        // Modifica a direção

        if (direcao != Vector3.zero) // Se o Player estiver se movendo
        {
            GetComponent<Animator>().SetBool("Moving", true);
            //Faz a boolean Moving true e faz a animação correndo
        } else
            GetComponent<Animator>().SetBool("Moving", false);
        //Faz a boolean Moving false e faz a animação idle

        if(vivo == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //Recomeça a cena com tempo 1
                SceneManager.LoadScene("Fase1");
                Time.timeScale = 1;
            }
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position + 
                (this.direcao * (Time.deltaTime * this.velocidade)));
        // Move o player de acordo com o Rigidbody

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Cria um raio da câmera até o mouse

        Debug.DrawRay(raio.origin/*origem do raio*/, raio.direction * 100/*Direçaõ do raio*/, Color.red/*Cor vermelha*/);

        RaycastHit impact/*Pega a posição do hit do raio*/;

        if(Physics.Raycast(raio, out impact, 100, MascaraChao)/*Junta o raio com o impacto*/)
        {
            Vector3 posicaoMiraJogador = impact.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
     }
}
