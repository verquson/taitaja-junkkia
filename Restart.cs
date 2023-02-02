using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    //kun painaa nappia, k‰ytt‰j‰ menee pelin ensimm‰iseen kentt‰‰n eli yhdeks‰n scene‰ taaksep‰in
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);

    }
}
