﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class RoomCreator : ScriptableObject
    {
        private ActorCreator _actorCreator;
        private Vector3 NextItemPosition
        {
            get
            {
                var pos = _nextItemPosition;
                _nextItemPosition += _offset;
                return pos;
            }
        }

        private string _room;
        private Vector3 _nextItemPosition = new Vector3(0, 0, 0);
        private Vector3 _offset = new Vector3(0, 150, 150);

        //Game objects for building corridors
        private GameObject _corridor;
        private GameObject _2doorCorridor;
        private GameObject _2doorCorridorEx;
        private GameObject _doorwayWall;
        private GameObject _wallEnding;
        private GameObject _stairs;

        public void OnEnable()
        {
            _corridor = Resources.Load<GameObject>("Prefabs/Environment/Corridor");
            _2doorCorridor = Resources.Load<GameObject>("Prefabs/Environment/2DoorCorridorBase");
            _2doorCorridorEx = Resources.Load<GameObject>("Prefabs/Environment/2DoorCorridorExtension");
            _doorwayWall = Resources.Load<GameObject>("Prefabs/Environment/DoorwayWall");
            _wallEnding = Resources.Load<GameObject>("Prefabs/Environment/WallEnding");
            _actorCreator = ScriptableObject.CreateInstance("ActorCreator") as ActorCreator;
            _stairs = Resources.Load<GameObject>("Prefabs/Environment/Stairs");
            items = new List<GameObject>();
        }


        private List<GameObject> items;

        public List<GameObject> CreateRoomAndExtensions(ClassObject classObject)
        {
            var room = GetRoom(classObject);
            var newRoom = InstantiateEnvironmentItem(room.RoomGO);

            _actorCreator.CreateAttributes(room, newRoom);
            _actorCreator.CreateMethods(room, newRoom);

            newRoom.gameObject.name = room.Info.name;
            newRoom.AddComponent<RoomBehaviour>();

            CreateExtensions(room, newRoom);
            return items;
        }

        //Determine room prefab
        private Room GetRoom(ClassObject classObject)
        {
            //Path to prefab file
            string _room = "Prefabs/Environment/4DoorRoom";
            return new Room(classObject, Resources.Load<GameObject>(_room));
        }

        private void CreateExtensions(Room room, GameObject newRoom)
        {
            var classObject = room.Info;
            if (classObject.associations.Length > 0) { CreateAssociationsCorridor(room, newRoom); }
            if (classObject.components.Length > 0) { CreateComponentsCorridor(room, newRoom); }
            if (classObject.subclasses.Length > 0 || !String.IsNullOrEmpty(classObject.superclass)) { CreateInheritenceStairs(room, newRoom); }
        }

        private void CreateAssociationsCorridor(Room room, GameObject newRoom)
        {
            var corridor = BuildCorridor(room.Info.associations);
            for (int i = 0; i < corridor.transform.childCount; i++)
            {
                if (corridor.transform.GetChild(i).tag == "BackDoorEntry")
                {
                    var portal = corridor.transform.GetChild(i).Find("Doorway/PortalTeleporter");
                    newRoom.GetComponent<RoomBehaviour>().AssociationsRoomTeleporter = portal;
                    portal.GetComponent<Portal>().receiver = newRoom.GetComponent<RoomBehaviour>().LeftTeleporter;
                }

            }
            for (int i = 0; i < corridor.transform.childCount; i++)
            {
                if (corridor.transform.GetChild(i).CompareTag("PortalCam"))
                {
                    corridor.transform.GetChild(i).GetComponent<PortalCamera>().OtherPortal = newRoom.GetComponent<RoomBehaviour>().LeftTeleporter.transform.parent.Find("Portal");
                }
            }
        }

        private void CreateComponentsCorridor(Room room, GameObject newRoom)
        {
            var corridor = BuildCorridor(room.Info.components);
            var roomBH = newRoom.GetComponent<RoomBehaviour>();

            for (int i = 0; i < corridor.transform.childCount; i++)
            {
                if (corridor.transform.GetChild(i).tag == "BackDoorEntry")
                {
                    var portal = corridor.transform.GetChild(i).Find("Doorway/PortalTeleporter");
                    roomBH.ComponentsRoomTeleporter = portal;
                    portal.GetComponent<Portal>().receiver = roomBH.RightTeleporter;
                }

            }
            for (int i = 0; i < corridor.transform.childCount; i++)
            {
                if (corridor.transform.GetChild(i).CompareTag("PortalCam"))
                {
                    corridor.transform.GetChild(i).GetComponent<PortalCamera>().OtherPortal = roomBH.RightTeleporter.transform.parent.Find("Portal").transform;
                }
            }
        }

        private void CreateInheritenceStairs(Room room, GameObject newRoom)
        {

            //Setup Staircase
            var stairs = InstantiateEnvironmentItem(_stairs);

            Transform subClassTeleporter = null;
            Transform superClassTeleporter = null;

            for (int i = 0; i < stairs.transform.childCount; i++)
            {
                if(stairs.transform.GetChild(i).tag == "BackDoorEntry")
                {
                    var portal = stairs.transform.GetChild(i).Find("Doorway/PortalTeleporter");
                    newRoom.GetComponent<RoomBehaviour>().InheritenceRoomTeleporter = portal;
                    portal.GetComponent<Portal>().receiver = newRoom.GetComponent<RoomBehaviour>().FrontTeleporter;
                }
                else if(stairs.transform.GetChild(i).tag == "LeftDoorEntry")
                {
                    subClassTeleporter = stairs.transform.GetChild(i).Find("PortalTeleporter");
                }
                else if (stairs.transform.GetChild(i).tag == "RightDoorEntry")
                {
                    superClassTeleporter = stairs.transform.GetChild(i).Find("PortalTeleporter");
                }
            }

            for (int i = 0; i < stairs.transform.childCount; i++)
            {
                if (stairs.transform.GetChild(i).CompareTag("PortalCam"))
                {
                    stairs.transform.GetChild(i).GetComponent<PortalCamera>().OtherPortal = newRoom.GetComponent<RoomBehaviour>().FrontTeleporter.transform.parent.Find("Portal");
                }
            }

            //Setup subclasses corridor
            var corridor = BuildCorridor(room.Info.subclasses);
            for (int i = 0; i < corridor.transform.childCount; i++)
            {
                if (corridor.transform.GetChild(i).tag == "BackDoorEntry")
                {
                    var portal = corridor.transform.GetChild(i).Find("Doorway/PortalTeleporter");
                    portal.GetComponent<Portal>().receiver = subClassTeleporter;
                }
            }
            
        }

        //Centralize logic required for each addition
        private GameObject InstantiateEnvironmentItem(GameObject go)
        {
            var newGameObject = Instantiate(go);
            newGameObject.transform.position = NextItemPosition;
            items.Add(newGameObject);
            return newGameObject;
        }


        private GameObject BuildCorridor(string[] connectionsList)
        {
            GameObject corr = null;
            Transform currentEndPoint;

            int connections = connectionsList.Length;

            if (connections == 1)
            {
                corr = InstantiateEnvironmentItem(_corridor);
            }
            else if (connections >= 2)
            {
                corr = InstantiateEnvironmentItem(_2doorCorridor);
                currentEndPoint = corr.transform.Find("Endpoint");
                connections -= 2;
                while (connections >= 2)
                {
                    Debug.Log(connections);
                    var extension = Instantiate(_2doorCorridorEx);
                    extension.transform.position = currentEndPoint.position + (extension.transform.position - extension.transform.Find("Startpoint").position);
                    currentEndPoint = extension.transform.Find("Endpoint");
                    extension.transform.parent = corr.transform;
                    connections -= 2;
                }
                var ending = connections == 1 ? Instantiate(_doorwayWall) : Instantiate(_wallEnding);
                ending.transform.position = currentEndPoint.position;
                ending.transform.parent = corr.transform;
            }
            //Attach connection names to Corridor
            var corrBehaviour = corr.GetComponent<Corridor>();
            corrBehaviour.ConnectionNames = connectionsList;
            
            return corr;
        }
    }
}