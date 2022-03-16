using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_and_Damage : MonoBehaviour
{
    public int vida = 100;
    public bool invencible = false;
    public float tiempo_invencible = 1f;
    public float tiempo_frenado = 0.25f;

    public void RestarVida(int cantidad)
    {
        if (!invencible && vida > 0)
        {
            vida -= cantidad;
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());
            if (vida == 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0; //para el juego
    }

    IEnumerator Invulnerabilidad()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempo_invencible);
        invencible = false;
    }

    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<playerController>().playerSpeed;
        GetComponent<playerController>().playerSpeed = 0;
        yield return new WaitForSeconds(tiempo_frenado);
        GetComponent<playerController>().playerSpeed = velocidadActual;
    }
}
