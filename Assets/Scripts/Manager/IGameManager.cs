using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager 
{
   ManagersStatus status { get;}

   void Startup();
}
