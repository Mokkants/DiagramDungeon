using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour, IConnectable {

    public List<GameObject> Connections;

    public string superClass;
    public GameObject subClassesCorridor;

    public Transform superClassPortal;
    public Transform subClassesPortal;

    public void Start()
    {
        Connections = new List<GameObject>();
    }


    public void SetupConnections()
    {
        if(superClassPortal != null) { ConnectSuperclass(); }
        if (subClassesPortal != null) { ConnectSubclassesCorridor(); }
    }

    private void ConnectSubclassesCorridor()
    {
        subClassesPortal.GetComponentInChildren<Portal>().receiver = subClassesCorridor.GetComponent<Corridor>().entrance.transform;
        subClassesCorridor.transform.Find("PortalCamera").GetComponent<PortalCamera>().OtherPortal = subClassesPortal.transform.Find("Portal").GetComponent<MeshRenderer>().transform;
        Connections.Add(this.subClassesCorridor);
    }

    private void ConnectSuperclass()
    {
        var target = GameObject.Find(superClass);
        if (target != null)
        {
            Transform destination = target.transform;
            superClassPortal.GetComponent<Portal>().receiver = destination.GetComponent<RoomBehaviour>().BackTeleporter.transform;
            superClassPortal.GetComponent<Portal>().destination = superClass;
            var textMesh = superClassPortal.transform.parent.GetComponentInChildren<TextMesh>();
            if (textMesh != null)
            {
                textMesh.text = superClass;
            }
            destination.Find("PortalCamera").GetComponent<PortalCamera>().OtherPortal = superClassPortal.transform.Find("Portal").GetComponent<MeshRenderer>().transform;
            Connections.Add(target);
        }
    }
}
