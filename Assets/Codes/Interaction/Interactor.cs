using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    public GameObject cam1;
    public GameObject cam2;
    public GameObject star;
    public bool cam1active;


    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    [SerializeField]
    MouseLook mouseLook;


    void Start()
    {
        star.active = false;
    }

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, (int)_interactableMask);

        if(_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();
            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
                PlayerMovement.speed = 0f;
                star.active = true;
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
                PlayerMovement.speed = 12f;
                star.active = false;
            }


        }

    }

}
