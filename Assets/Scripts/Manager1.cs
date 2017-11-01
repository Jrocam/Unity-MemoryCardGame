using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager1 : MonoBehaviour {

    public Text Puntos1;
    public Text Puntos2;

    public int count = 0;
    public bool PlayerChange = false;
    public bool _player1 = true;
    public bool _player2 = false;
    public GameObject[] cartas;
    public Sprite ogSprite;
    public string primera;
    public string segunda;
    public int puntos1=0;
    public int puntos2=0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Puntos1.text = "Puntos1= " + puntos1;
        Puntos2.text = "Puntos2= " + puntos2;
    }
    public void voltearCartas()
    {
        for (int i = 0; i < cartas.Length; i++)
        {
            cartas[i].gameObject.GetComponent<SpriteRenderer>().sprite = ogSprite;
        }
    }
}
