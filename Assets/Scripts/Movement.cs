using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    Rigidbody rb;
    AudioSource audioSource;

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }
    private void FixedUpdate()
    {
        ProcessRotation();
        ProcessThrust();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            startThrusting();
        }
        else
        {
            StopTrusting();
        }
    }
    private void startThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSFX);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }
    private void StopTrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }
    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            RotateRight();
        }
        else if (rotationInput > 0)
        {
            RotateLeft();
        }
        else
        {
            StopRotating();
        }
    }
    private void RotateRight()
    {
        ApplyRotation(rotationStrength);
        if (!rightThrustParticles.isPlaying)
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Play();
        }
    }
    private void RotateLeft()
    {
        ApplyRotation(-rotationStrength);
        if (!leftThrustParticles.isPlaying)
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Play();
        }
    }
    private void StopRotating()
    {
        rightThrustParticles.Stop();
        leftThrustParticles.Stop();
    }
    private void ApplyRotation(float rotationThisFranme)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFranme * Time.fixedDeltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
