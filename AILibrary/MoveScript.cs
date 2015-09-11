using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 하나의 이동 관련 Script 정보를 가지고 있는 클래스입니다.
    /// </summary>
    public class MoveScript : Script
    {
        /// <summary>
        /// X축으로 이동할 양을 가져옵니다.
        /// </summary>
        public int DirectionXQuantity
        {
            get; private set;
        }

        /// <summary>
        /// Y축으로 이동할 양을 가져옵니다.
        /// </summary>
        public int DirectionYQuantity
        {
            get; private set;
        }

        /// <summary>
        /// 주어진 정보를 이용하여 MoveScript 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="xQuantity">X축으로 이동할 양을 가리킵니다.</param>
        /// <param name="yQuantity">Y축으로 이동할 양을 가리킵니다.</param>
        public MoveScript(int xQuantity, int yQuantity)
        {
            base.ScriptCode = (int)ScriptTypeCode.MoveScript;
            base.IsStepScript = true;
            this.DirectionXQuantity = xQuantity;
            this.DirectionYQuantity = yQuantity;
        }
    }
}
