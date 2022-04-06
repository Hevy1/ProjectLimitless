using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEverything : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] objectList;
    void Start()
    {
        //Récupération des objets de la scène
        objectList = Resources.FindObjectsOfTypeAll<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //on itère sur tout les objets, et on les fait tous tourner à vitesse aléatoire autour de l'axe y, à l'exception du joueur
        foreach (GameObject go in objectList)
        {
            if (go == gameObject) continue;
            else
            {
                float r = Random.Range(1, 80);
                go.transform.Rotate(0f, r/100, 0f);
            }
        }
        
    }
}
