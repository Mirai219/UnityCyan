using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField] float restTime = 3f;
    new Collider collider;
    MeshRenderer meshRenderer;
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] ParticleSystem pickUpVFX;

    AudioSource audioSource;
     
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerController>(out PlayerController controller))
        {
            controller.CanAirJump = true;
            collider.enabled = false;
            meshRenderer.enabled = false;
            audioSource.PlayOneShot(pickUpSFX);
            Instantiate(pickUpVFX,transform.position,transform.rotation);

            StartCoroutine(ResrCoroutine());
        }
    }

    private void Reset()
    {
        meshRenderer.enabled = true;
        collider.enabled = true;
    }

    IEnumerator ResrCoroutine()
    {
        yield return new WaitForSeconds(restTime);

        Reset();
    }
}
