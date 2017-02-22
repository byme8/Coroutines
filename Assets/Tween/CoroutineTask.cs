
using System;
using UnityEngine;

namespace Tweens
{
    public class CoroutineTask : CustomYieldInstruction
    {
        private bool _keepWaiting = true;

        public override bool keepWaiting 
        {
            get
            {
                return this._keepWaiting;
            }
        }

        public void Done()
        {
            this._keepWaiting = false;
        }
    }
}
