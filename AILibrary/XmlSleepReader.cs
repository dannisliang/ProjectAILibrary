using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 스크립트의 Xml 파일을 읽어 Sleep 스크립트와 관련된 항목을 Parsing 해주는 클래스입니다.
    /// </summary>
    public class XmlSleepReader : XmlScriptReader
    {
        /// <summary>
        /// 주어진 정보를 이용하여 XmlSleepReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlSleepReader(string filePathOrContent, bool isPath) : base(filePathOrContent, isPath)
        {
        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트에서 얼마나 행동을 멈출 지를 읽어옵니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>Sleep 양을 가져옵니다.</returns>
        public float GetSleepTime(int scriptID)
        {
            if (this.IsNeedThisScript(3, scriptID))
            {
                return float.Parse(base.GetLevelTwoElementValueFromXml("SleepTime", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 Sleep 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 정보를 수집하여 SleepScript 인스턴스를 만듭니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>완성된 SleepScript 인스턴스입니다.</returns>
        public override Script GetScript(int scriptID)
        {
            if (this.IsNeedThisScript(3, scriptID))
            {
                return new SleepScript(this.GetSleepTime(scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 Sleep 스크립트에 해당하지 않는 스크립트입니다.");
        }
    }
}
