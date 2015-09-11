using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 스크립트의 Xml 파일을 읽어 Move 스크립트와 관련된 항목을 Parsing 해주는 클래스입니다.
    /// </summary>
    public class XmlMoveReader : XmlScriptReader
    {
        /// <summary>
        /// 주어진 정보를 이용하여 XmlSoundReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlMoveReader(string filePathOrContent, bool isPath) : base(filePathOrContent, isPath)
        {
        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트에서 X축으로 이동할 양을 읽어옵니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>X축으로 이동할 양을 가리킵니다.</returns>
        public int GetXQuantity(int scriptID)
        {
            if (this.IsNeedThisScript(7, scriptID))
            {
                return int.Parse(base.GetLevelTwoElementValueFromXml("MovePosX", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 이동 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트에서 Y축으로 이동할 양을 읽어옵니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>Y축으로 이동할 양을 가리킵니다.</returns>
        public int GetYQuantity(int scriptID)
        {
            if (this.IsNeedThisScript(7, scriptID))
            {
                return int.Parse(base.GetLevelTwoElementValueFromXml("MovePosY", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 이동 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 정보를 수집하여 MoveScript 인스턴스를 만듭니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>완성된 MoveScript 인스턴스입니다.</returns>
        public override Script GetScript(int scriptID)
        {
            if (this.IsNeedThisScript(7, scriptID))
            {
                return new MoveScript(this.GetXQuantity(scriptID), this.GetYQuantity(scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 이동 스크립트에 해당하지 않는 스크립트입니다.");
        }
    }
}
