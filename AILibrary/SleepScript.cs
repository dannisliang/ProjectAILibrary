using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 잠시 멈추는 행동을 하는 스크립트 정보를 가지고 있는 클래스입니다.
    /// </summary>
    public class SleepScript : Script
    {
        /// <summary>
        /// 주어진 정보를 이용하여 SleepScript 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="TimeToSleep">멈추게 할 시간을 가리킵니다.</param>
        public SleepScript(float TimeToSleep)
        {
            base.ScriptCode = (int)ScriptTypeCode.SleepScript;
            base.IsStepScript = true;
            this.SleepTime = TimeToSleep;
        }

        /// <summary>
        /// 멈추는 시간을 가져옵니다.
        /// </summary>
        public float SleepTime
        {
            get; private set;
        }
    }
}
