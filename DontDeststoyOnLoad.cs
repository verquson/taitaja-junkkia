using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//t�m� koodi varmistaa ett� taustamusiikki ei lopetu tai starttaa alusta scenen vaihdossa

public class DontDeststoyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
