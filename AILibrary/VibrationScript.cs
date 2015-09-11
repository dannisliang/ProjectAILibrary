using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 하나의 흔들림 관련 Script 정보를 가지고 있는 클래스입니다.
    /// </summary>
    public class VibrationScript : Script
    {
        /// <summary>
        /// 주어진 정보를 이용하여 VibrationScript 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="direction">흔들리는 방향을 설정합니다.</param>
        /// <param name="speed">흔들리는 속도를 설정합니다.</param>
        /// <param name="moveDistance">움직일 거리를 설정합니다.</param>
        /// <param name="waveQuantity">흔들리는 횟수를 설정합니다.</param>
        public VibrationScript(VibrationState direction, float speed, float moveDistance, int waveQuantity)
        {
            base.ScriptCode = (int)ScriptTypeCode.VibrationScript;
            base.IsStepScript = true;
            this.Direction = direction;
            this.Speed = speed;
            this.WaveQuantity = waveQuantity;
        }

        /// <summary>
        /// 흔들림 방향을 가져옵니다.
        /// </summary>
        public VibrationState Direction
        {
            get; private set;
        }

        /// <summary>
        /// 흔들리는 속도를 가져옵니다.
        /// </summary>
        public float Speed
        {
            get; private set;
        }

        /// <summary>
        /// 움직일 거리를 가져옵니다.
        /// </summary>
        public float MoveDistance
        {
            get; private set;
        }

        /// <summary>
        /// 흔들리는 양을 가져옵니다.
        /// </summary>
        public int WaveQuantity
        {
            get; private set;
        }
    }

    /// <summary>
    /// 흔들리는 방향을 열거하는 열거자입니다.
    /// </summary>
    public enum VibrationState
    {
        /// <summary>
        /// 세로 방향입니다.
        /// </summary>
        Vertical,

        /// <summary>
        /// 가로 방향입니다.
        /// </summary>
        Horizontal
    }
}
