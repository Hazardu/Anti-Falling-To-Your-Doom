using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheForest.Utils;
using UnityEngine;

namespace AntiFallingToYourDoom
{
    public class MainMod : FirstPersonCharacter
    {
        const float LowestY = -750;
        protected void LateUpdate()
        {
            if(transform.position.y< LowestY)
            {
                if (LocalPlayer.IsInOutsideWorld)
                {
                    Vector3 newPosition = transform.position;
                    newPosition.y = Terrain.activeTerrain.SampleHeight(transform.position) +2;
                    transform.position = newPosition;
                    rb.velocity = Vector3.zero;
                }
                else
                {
                    LocalPlayer.Stats.InACave();
                    Vector3 newPosition = transform.position;
                    newPosition.y = Terrain.activeTerrain.SampleHeight(transform.position) + 2;
                    transform.position = newPosition;
                    rb.velocity = Vector3.zero;
                }
            }    
        }
    }
}
