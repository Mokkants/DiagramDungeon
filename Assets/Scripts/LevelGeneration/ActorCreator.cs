﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project{
	public class ActorCreator : ScriptableObject {

		System.Random rnd = new System.Random();
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void CreateAttributes(Room room, GameObject newRoom)
        {
            int i = 0;
            if (room.Info.attributes.Length > 0)
            {
                foreach (NPCObject npc in room.Info.attributes)
                {
                    Vector3 position;
                    GameObject obj;
                    switch (npc.type)
                    {
                        case ("int"):
                            obj = Resources.Load("Prefabs/Actors/attributeInt") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z) , Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            position.y = 0;
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("double"):
                            obj = Resources.Load("Prefabs/Actors/attributeDouble") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z) , Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("float"):
                            obj = Resources.Load("Prefabs/Actors/attributeFloat") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            position.y = 8;
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("boolean"):
                            obj = Resources.Load("Prefabs/Actors/attributeBoolean") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("char"):
                            obj = Resources.Load("Prefabs/Actors/attributeChar") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("short"):
                            obj = Resources.Load("Prefabs/Actors/attributeShort") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        case ("long"):
                            obj = Resources.Load("Prefabs/Actors/attributeLong") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<NPC>().Populate(npc);
                            break;

                        default:
                            obj = Resources.Load("Prefabs/Actors/attributeCustom") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            position.y = 0;
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<NPC>().Populate(npc);
                            break;
                    }
                }
            }
        }

        public void CreateMethods(Room room, GameObject newRoom)
        {
            int i = 0;
            if (room.Info.methods.Length > 0)
            {
                foreach (MethodObject method in room.Info.methods)
                {
                    Vector3 position;
                    GameObject obj;
                    switch (method.returnType)
                    {
                        case ("int"):
                            obj = Resources.Load("Prefabs/Actors/methodInt") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z) , Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            position.y = 0;
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("double"):
                            obj = Resources.Load("Prefabs/Actors/methodDouble") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z) , Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("float"):
                            obj = Resources.Load("Prefabs/Actors/methodFloat") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("boolean"):
                            obj = Resources.Load("Prefabs/Actors/methodBoolean") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("char"):
                            obj = Resources.Load("Prefabs/Actors/methodChar") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("short"):
                            obj = Resources.Load("Prefabs/Actors/methodShort") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("long"):
                            obj = Resources.Load("Prefabs/Actors/methodLong") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("void"):
                            obj = Resources.Load("Prefabs/Actors/methodVoid") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            position = new Vector3(position.x, position.y+2.65f, position.z);  
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        case ("String"):
                            obj = Resources.Load("Prefabs/Actors/methodString") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;

                        default:
                            obj = Resources.Load("Prefabs/Actors/methodCustom") as GameObject;
                            //Instantiate(obj, new Vector3(newRoom.transform.position.x, newRoom.transform.position.y, newRoom.transform.position.z), Quaternion.identity, newRoom.transform);
                            Instantiate(obj, newRoom.transform, false);
                            position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            while (!checkIfPosEmpty(position))
                            {
                                position = new Vector3(rnd.Next(-90, -10), newRoom.transform.position.y, rnd.Next(-40, 40));
                            }
                            obj.transform.localPosition = position;
                            obj.transform.rotation = Quaternion.Euler(0, rnd.Next(0, 360), 0);
                            obj.GetComponent<Method>().Populate(method);
                            break;
                    }
                }
            }
        }

		private bool checkIfPosEmpty(Vector3 pos)
        {
           /*  GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
            foreach (GameObject current in interactables)
            {
                if (current.transform.position == pos)
                    return false;
            }*/
            Collider[] colliders = Physics.OverlapSphere(pos, 4);
            if(colliders.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
	}
}
