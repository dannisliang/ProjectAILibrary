using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 스크립트의 Xml 파일을 읽어 Vibration 스크립트와 관련된 항목을 Parsing 해주는 클래스입니다.
    /// </summary>
    public class XmlVibrationReader : XmlScriptReader
    {
        /// <summary>
        /// 주어진 정보를 이용하여 XmlVibrationReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlVibrationReader(string filePathOrContent, bool isPath) : base(filePathOrContent, isPath)
        {
        }

        /// <summary>
        /// 대상 스크립트에서 흔들리는 횟수를 가져옵니다. VibrationScript에 해당하는 스크립트가 아닐 시 예외가 throw됩니다.
        /// </summary>
        /// <param name="scriptID">흔들리는 횟수 정보가 담겨있는 스크립트 ID입니다.</param>
        /// <returns>흔들리는 횟수입니다.</returns>
        public int GetWaveQuantity(int scriptID)
        {
            if (this.IsNeedThisScript(6, scriptID))
            {
                return int.Parse(base.GetLevelTwoElementValueFromXml("VibeTimes", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 흔들림 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 흔들리는 속도를 가져옵니다. VibrationScript에 해당하는 스크립트가 아닐 시 예외가 throw됩니다.
        /// </summary>
        /// <param name="scriptID">흔들리는 속도 정보가 담겨있는 스크립트 ID입니다.</param>
        /// <returns>흔들리는 속도입니다.</returns>
        public float GetSpeed(int scriptID)
        {
            if (this.IsNeedThisScript(6, scriptID))
            {
                return float.Parse(base.GetLevelTwoElementValueFromXml("VibeSpeed", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 흔들림 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 흔들리는 방향을 가져옵니다. VibrationScript에 해당하는 스크립트가 아닐 시 예외가 throw됩니다.
        /// </summary>
        /// <param name="scriptID">흔들리는 방향 정보가 담겨있는 스크립트 ID입니다.</param>
        /// <returns>흔들리는 방향입니다.</returns>
        public VibrationState GetDirection(int scriptID)
        {
            if (this.IsNeedThisScript(6, scriptID))
            {
                return (VibrationState) Enum.Parse(typeof(VibrationState), base.GetLevelTwoElementValueFromXml("VibeDirection", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 흔들림 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 정보를 수집하여 VibrationScript 인스턴스를 만듭니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>완성된 VibrationScript 인스턴스입니다.</returns>
        public override Script GetScript(int scriptID)
        {
            if (this.IsNeedThisScript(6, scriptID))
            {
                return new VibrationScript(this.GetDirection(scriptID), this.GetSpeed(scriptID), this.GetWaveQuantity(scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 흔들림 스크립트에 해당하지 않는 스크립트입니다.");
        }
    }
}
