using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardChange : MonoBehaviour {
	public SpriteRenderer sprite1, sprite3;
	public Sprite[] sprite2;
    public Camera camaraprincipal;


    // Use this for initialization
    void Start () {
		sprite1 = GetComponent<SpriteRenderer> ();
        StartCoroutine(TimeOut());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (camaraprincipal.GetComponent<Manager1>().PlayerChange)
        {
            camaraprincipal.GetComponent<Manager1>().PlayerChange = false;
            StartCoroutine(unSec());
            StartCoroutine(TimeOut());
        }
    
	}
	void OnMouseDown() {

        if (camaraprincipal.GetComponent<Manager1>().count < 2)
        {
            sprite1.sprite = sprite2[0];
            camaraprincipal.GetComponent<Manager1>().count++;
            //PRIMERA VEZ QUE PRESIONA
            if (camaraprincipal.GetComponent<Manager1>().count == 1)
            {
                camaraprincipal.GetComponent<Manager1>().primera = gameObject.tag;
            }
            Debug.Log(camaraprincipal.GetComponent<Manager1>().count);
            //SEGUNDA VEZ QUE PRESIONA
            if (camaraprincipal.GetComponent<Manager1>().count == 2)
            {
                //VERIFICAR CARTAS SON IGUALES
                if (camaraprincipal.GetComponent<Manager1>().primera.Equals(gameObject.tag))
                {
                    if (camaraprincipal.GetComponent<Manager1>()._player1)
                    {
                        camaraprincipal.GetComponent<Manager1>().puntos1++;
                    }
                    else if (camaraprincipal.GetComponent<Manager1>()._player2)
                    {
                        camaraprincipal.GetComponent<Manager1>().puntos2++;
                    }
                }
                camaraprincipal.GetComponent<Manager1>().PlayerChange = true;
                camaraprincipal.GetComponent<Manager1>().count = 0;

                if (camaraprincipal.GetComponent<Manager1>()._player1)
                {
                    Debug.Log("Jugador 2 es tu turno");
                    camaraprincipal.GetComponent<Manager1>()._player1 = false;
                    camaraprincipal.GetComponent<Manager1>()._player2 = true;
                }
                else if (camaraprincipal.GetComponent<Manager1>()._player2)
                {
                    Debug.Log("Jugador 1 es tu turno");
                    camaraprincipal.GetComponent<Manager1>()._player1 = true;
                    camaraprincipal.GetComponent<Manager1>()._player2 = false;
                }
            }
        }


    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(15f);
        camaraprincipal.GetComponent<Manager1>().count = 0;
        camaraprincipal.GetComponent<Manager1>().PlayerChange = true;
        if (camaraprincipal.GetComponent<Manager1>()._player1)
        {
            Debug.Log("Jugador 2 es tu turno");
            camaraprincipal.GetComponent<Manager1>()._player1 = false;
            camaraprincipal.GetComponent<Manager1>()._player2 = true;
        }
        else if (camaraprincipal.GetComponent<Manager1>()._player2)
        {
            Debug.Log("Jugador 1 es tu turno");
            camaraprincipal.GetComponent<Manager1>()._player1 = true;
            camaraprincipal.GetComponent<Manager1>()._player2 = false;
        }
    }

    IEnumerator unSec()
    {
        yield return new WaitForSeconds(1f);
        camaraprincipal.GetComponent<Manager1>().voltearCartas();
    }
}
