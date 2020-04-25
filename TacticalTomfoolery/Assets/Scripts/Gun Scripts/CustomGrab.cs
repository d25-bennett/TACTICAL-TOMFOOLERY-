using System.Linq;
using UnityEngine;

public class CustomGrab : MonoBehaviour
{
    //Raycast origin
    public GameObject RayCastPosition;

    //The Other Hand
    public GameObject OtherHandObj;
    private CustomGrab OtherHand;

    //Controller
    public OVRInput.Controller Controller;

    //Snap positions
    public Transform[] SnapPosition;

    //private bool MaterialChanged = false;
    //private bool ColliderExited = false;
    private bool ItemInHand = false;

    //Item to interact with
    private GameObject ItemInFocus;
    public GameObject GrabbedItem;
    private Rigidbody GrabbedItemRigidbody;

    private Animator HandAnimator;
    private Animator WeaponAnimator;

    //Line Renderer
    public LineRenderer LineRenderer;
    private float LineWidth = 0.01f;
    private float LineMaxLength = 2f;
    private Vector3[] InitLaserPositions;

    void Start()
    {
        InitLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        LineRenderer = GetComponent<LineRenderer>();
        OtherHand = OtherHandObj.GetComponent<CustomGrab>();
        HandAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        RenderLine();

        GrabItem();

        DropItem();
    }

    private void DropItem()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, Controller) && ItemInHand == true)
        {
            ItemInHand = false;
            HandAnimator.SetBool("GrabGun", false);

            //if (GrabbedItem.name.Contains("Loaded") == false)
            //{
            //    GrabbedItem.transform.parent = null;
            //    GrabbedItemRigidbody.isKinematic = false;
            //    GrabbedItemRigidbody.useGravity = true;
            //}

            //if (GrabbedItem.CompareTag("MP5K"))
            //{
            //    GrabbedItem.GetComponent<SimpleShoot>().Shoot = false;    
            //}

            GrabbedItem = null;
        }
    }

    private void GrabItem()
    {
        if (ItemInHand == false && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, Controller) && ItemInFocus != null && OtherHand.GrabbedItem != ItemInFocus)
        {
            GrabbedItem = ItemInFocus;
            ItemInHand = true;
            WeaponAnimator = GrabbedItem.GetComponent<Animator>();
            if (GrabbedItem.CompareTag("Gun") == true)
            {
                HandAnimator.SetBool("GrabGun", true);
            }
            else if (GrabbedItem.CompareTag("Book"))
            {
                HandAnimator.SetBool("Pose", true);
            }

            //Get Snap Position And Place
            var snapp = SnapPosition.Where(x => x.CompareTag(GrabbedItem.tag)).FirstOrDefault();
            if (snapp != null)
            {
                GrabbedItem.transform.parent = snapp.transform;
                GrabbedItem.transform.position = snapp.position;
                GrabbedItem.transform.rotation = snapp.rotation;
                GrabbedItemRigidbody = GrabbedItem.GetComponent<Rigidbody>();
                GrabbedItemRigidbody.useGravity = false;
                GrabbedItemRigidbody.isKinematic = true;
                LineRenderer.enabled = false;
            }
        }
    }

    private void RenderLine()
    {
        if(GrabbedItem == null)
        {
            int layerMask = 1 << 8;

            RaycastHit hit;
            //Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2, layerMask))
            {
                LineRenderer.enabled = true;
                LineRenderer.SetPositions(InitLaserPositions);
                LineRenderer.startWidth = LineWidth;
                LineRenderer.endWidth = LineWidth;
                RenderLine(RayCastPosition.transform.position, transform.TransformDirection(Vector3.forward), LineMaxLength);

                if (ItemInFocus == null)
                {
                    ItemInFocus = hit.collider.gameObject;
                }
            }
            else
            {
                LineRenderer.enabled = false;
                ItemInFocus = null;
            }
        }
    }

    void RenderLine(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if(Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        LineRenderer.SetPosition(0, targetPosition);
        LineRenderer.SetPosition(1, endPosition);
    }
}