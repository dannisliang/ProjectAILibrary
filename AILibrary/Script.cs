using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 각종 Script들이 공유하는 추상 클래스입니다.
    /// </summary>
    public abstract class Script
    {
        /// <summary>
        /// 이 스크립트의 스크립트 코드를 가져옵니다.
        /// </summary>
        public int ScriptCode
        {
            get;
            protected set;
        }

        /// <summary>
        /// 이 스크립트가 하나의 단계를 차지하는 스크립트인지 여부를 가져옵니다.
        /// </summary>
        public bool IsStepScript
        {
            get;
            protected set;
        }
    }
}
