using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control 
{
    public class Facade : MonoBehaviour
    {
        // List of actors indexed by instance ID
        public static Dictionary<int, Actor> actors = new Dictionary<int, Actor>();

        [SerializeField]
        private float findActorTimer = 0; // Interval between actor searches

        private void Awake()
        {
            // Refresh list of actors at set intervals
            FindActors();
            InvokeRepeating(nameof(FindActors), 0, findActorTimer);
        }

        private void FindActors()
        {
            // Find actors by tag
            GameObject[] _actors = GameObject.FindGameObjectsWithTag("Actor");

            // Itterate through list
            foreach (GameObject a in _actors)
            {
                int instanceID = a.GetInstanceID();
                Debug.Log($"{a.name}, {instanceID}");

                // Skip to next loop if list already has the instance ID
                if (actors.ContainsKey(instanceID))
                    continue;

                // If it didn't, add the actor and instance ID
                actors.Add(instanceID, a.GetComponent<Actor>());
            }
        }

        // Move specified actor
        public static void MoveActor(int actorID, Vector3 direction)
        {
            Actor actor = actors[actorID];

            actor.Move(direction);
        }
    }
}
