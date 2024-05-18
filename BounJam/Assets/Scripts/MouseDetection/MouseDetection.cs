using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    public static MouseDetection Instance {  get; private set; }

    private Camera _cam;
    private void Awake()
    {
        Instance = this;
        _cam = Camera.main;
    }

    public Node IsNodeUnderMouse()
    {
        Vector3 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        LayerMask layerMask = LayerMask.GetMask("Node");
        
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit;

 
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Hit object on layer: " + hit.collider.gameObject.name); 
                                                                               
            return hit.collider.GetComponentInParent<Node>();                                                          
                                                                                                              
        }
 
        return null;
    }

    public RopeCutable IsRopeUnderMouse()
    {
        Vector3 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        LayerMask layerMask = LayerMask.GetMask("RopeCutable");


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Hit object on layer: " + hit.collider.gameObject.name);

            return hit.collider.GetComponentInParent<RopeCutable>();

        }

        return null;
    }
}


