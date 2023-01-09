using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;

namespace Commands
{
    public class MoveActorCommand : Command
    {
        public Vector3 direction;

        public MoveActorCommand(int _actorID, Vector3 _direction) 
        {
            actorID = _actorID;
            direction = _direction;
        }

        public override void Excecute()
        {
            Facade.MoveActor(actorID, direction);
        }
    }
}