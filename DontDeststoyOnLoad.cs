using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tämä koodi varmistaa että taustamusiikki ei lopetu tai starttaa alusta scenen vaihdossa

public class DontDeststoyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
