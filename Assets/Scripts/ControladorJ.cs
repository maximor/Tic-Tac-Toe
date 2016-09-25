﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorJ : MonoBehaviour {

    public Text[] listaBotones;
    private string JugadorT;//variable mantendra una X u O dependiendo el turno del jugador
    public GameObject mensaje;
    public Text TextoMensaje;
    private int movNum;

    void Awake()
    {
        mensaje.SetActive(false);
        ReferenciaBotones();
        JugadorT = "X";
        movNum = 0;
    }

    void ReferenciaBotones()
    {
        for(int i = 0; i < listaBotones.Length; i++)
        {
            listaBotones[i].GetComponentInParent<Botones>().SetGameControllerReference(this);
        }
    }

    //retorna en el boton el valor actual que tenga el JugadorT
    public string GetTurnoString()
    {
        return JugadorT;
    }

    //verifica si uno de los jugadores ha gana para finalizar el juego
    public void FinalizarTurno()
    {
        movNum++;
        if(listaBotones[0].text == JugadorT && listaBotones[1].text == JugadorT
            && listaBotones[2].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[3].text == JugadorT && listaBotones[4].text == JugadorT
            && listaBotones[5].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[6].text == JugadorT && listaBotones[7].text == JugadorT
            && listaBotones[8].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[0].text == JugadorT && listaBotones[3].text == JugadorT
            && listaBotones[6].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[1].text == JugadorT && listaBotones[4].text == JugadorT
            && listaBotones[7].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[2].text == JugadorT && listaBotones[5].text == JugadorT
            && listaBotones[8].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[0].text == JugadorT && listaBotones[4].text == JugadorT
            && listaBotones[8].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[2].text == JugadorT && listaBotones[4].text == JugadorT
            && listaBotones[6].text == JugadorT)
        {
            GameOver();
        }

        //lanza el mensaje cuando los jugadores quedan empate.
        if(movNum >= 9)
        {
            mensaje.SetActive(true);
            TextoMensaje.text = "Empate!";
        }

        Cambiardeturno();
    }

    
    void Cambiardeturno()
    {
        JugadorT = (JugadorT == "X") ? "O" : "X";
    }

    //desactiva todos los botones del juego para finalizarlo
    void GameOver()
    {
        for(int i = 0; i < listaBotones.Length; i++)
        {
            listaBotones[i].GetComponentInParent<Button>().interactable = false;
        }

        mensaje.SetActive(true);
        TextoMensaje.text = "Ganó " + JugadorT;
    }
}
