using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, Iinteractable
{
    public UnityEvent InteractEvt;
    public SoundEffect InteractSE;

    public void OnInteract()
    {
        InteractEvt.Invoke();
        AudioManager.Instance.PlayClipOnce(InteractSE, this.gameObject);
    }

}
