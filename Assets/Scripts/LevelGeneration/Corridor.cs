using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour, IConnectable {

    public string IsExtensionOf { get; set; }
    public string[] ConnectionNames { get; set; }

    public GameObject entrance;

    public List<GameObject> Connections;
    private List<GameObject> _doors;

    public void Start()
    {
        entrance = null;
        //look for entrance
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag.Equals("BackDoorEntry"))
            {
                entrance = transform.GetChild(i).transform.Find("Doorway/PortalTeleporter").gameObject;
            }
        }
        //If this then we're in corridor extension
        if(entrance == null)
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if(transform.parent.GetChild(i).tag.Equals("BackDoorEntry"))
                {
                    entrance = transform.parent.GetChild(i).transform.Find("Doorway/PortalTeleporter").gameObject;
                }
            }
        }
    }

    public void SetupConnections()
    {
        Connections = new List<GameObject>();
        InitializeDoors();
        foreach (var item in ConnectionNames)
        {
            Connect(GetNextEmptyDoor(), item);
        }
    }

    private void InitializeDoors()
    {
        _doors = new List<GameObject>();
        var portals = transform.GetComponentsInChildren<Portal>();
        foreach (var item in portals)
        {
            if(item.receiver == null)
            {
                GameObject gate = item.transform.parent.gameObject;
                _doors.Add(gate);
            }
        }
    }

    private GameObject GetNextEmptyDoor()
    {
        var door = _doors.Find(x => _doors.IndexOf(x) == _doors.Count - 1);
        _doors.Remove(door);
        return door;
    }

    private void Connect(GameObject door, string name)
    {
        var target = GameObject.Find(name);
        if (target != null)
        {
            Transform destination = target.transform;
            door.GetComponentInChildren<Portal>().receiver = destination.GetComponent<RoomBehaviour>().BackTeleporter.transform;
            door.GetComponentInChildren<Portal>().destination = name;
            var textMesh = door.transform.parent.GetComponentInChildren<TextMesh>();
            if (textMesh != null) {
                textMesh.text = name;
            }
            destination.Find("PortalCamera").GetComponent<PortalCamera>().OtherPortal = door.transform.Find("Portal").GetComponent<MeshRenderer>().transform;
            Connections.Add(target);
        }
    }
}