using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AILibrary
{
    /// <summary>
    /// 스크립트의 Xml 파일을 읽어 Parsing 해주는 클래스입니다.
    /// </summary>
    public abstract class XmlScriptReader : XmlReader
    {
        private static Dictionary<int, string> scriptKeyElementDictionary;

        static XmlScriptReader()
        {
            scriptKeyElementDictionary = new Dictionary<int, string>();
            scriptKeyElementDictionary.Add(0, "ButtonNumber");
            scriptKeyElementDictionary.Add(1, "Message");
            scriptKeyElementDictionary.Add(2, "InputNumber");
            scriptKeyElementDictionary.Add(3, "SleepTime");
            scriptKeyElementDictionary.Add(4, "JumpScript");
            scriptKeyElementDictionary.Add(5, "Sound");
            scriptKeyElementDictionary.Add(6, "VibeDirection");
            scriptKeyElementDictionary.Add(7, "MovePosX");
            scriptKeyElementDictionary.Add(8, "Background");
        }

        /// <summary>
        /// 주어진 정보를 이용하여 XmlScriptReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlScriptReader(string filePathOrContent, bool isPath) : base(filePathOrContent, isPath)
        {
        }

        /// <summary>
        /// 해당 XmlReader 인스턴스를 통해 그에 맞는 스크립트 인스턴스를 읽어들여 반환합니다.
        /// </summary>
        /// <param name="scriptID">읽어들일 스크립트 ID입니다.</param>
        /// <returns>스크립트 인스턴스입니다. Interface로 형바꿈되어 반환됩니다.</returns>
        public abstract Script GetScript(int scriptID);

        /// <summary>
        /// 현재 참조하려고 하는 Xml 파일이 유효한 Xml 파일인지 검사합니다. 유효하지 않을 시 예외가 throw 됩니다.
        /// </summary>
        public override void CheckValidXmlContent()
        {
            if (this.targetXmlFile.Root.Name != "Scripts")
            {
                throw new NotSupportedException("잘못된 Xml 파일에 접근하려고 합니다. (Script)");
            }
        }

        /// <summary>
        /// 현재 대상 스크립트의 총 스크립트 개수를 가져옵니다.
        /// </summary>
        public int TotalScriptNum
        {
            get
            {
                IEnumerable<string> totalScripNum = from rootElems in this.targetXmlFile.Root.Elements()
                                                    where rootElems.Name == "Total"
                                                    select rootElems.Value;

                return int.Parse(totalScripNum.ToArray<string>()[0]);
            }
        }

        /// <summary>
        /// 이 인스턴스를 XmlScriptReader 파생 클래스들로 변환합니다.
        /// </summary>
        /// <param name="toConvert">바꾸려고 하는 인스턴스입니다.</param>
        /// <param name="scriptTypeCode">바꾸고자 하는 XmlScriptReader 파생 클래스의 TypeCode입니다.</param>
        public static XmlScriptReader ConvertReader(XmlScriptReader toConvert, int scriptTypeCode)
        {
            switch (scriptTypeCode)
            {
                case 0:
                    {
                        return new XmlButtonReader(toConvert.targetXmlFile.ToString(), false);
                    }
                case 1:
                    {
                        return new XmlMessageReader(toConvert.targetXmlFile.ToString(), false);
                    }
                case 2:
                    {
                        return new XmlInputReader(toConvert.targetXmlFile.ToString(), false);
                    }
                case 3:
                    {
                        return new XmlSleepReader(toConvert.targetXmlFile.ToString(), false);
                    }
                case 4:
                    {
                        return new XmlJumpReader(toConvert.targetXmlFile.ToString(), false);
                    }
                case 5:
                    {
                        return new XmlSoundReader(toConvert.targetXmlFile.ToString(), false);
                    }
                case 6:
                    {
                        return new XmlVibrationReader(toConvert.targetXmlFile.ToString(), false);
                    }
                case 7:
                    {
                        return new XmlMoveReader(toConvert.targetXmlFile.ToString(), false);
                    }
                case 8:
                    {
                        return new XmlBackgroundScript(toConvert.targetXmlFile.ToString(), false);
                    }
            }

            throw new NotSupportedException("지원하지 않는 스크립트 코드입니다.");
        }

        /// <summary>
        /// 스크립트 코드와 스크립트 ID를 통해 해당 ID 스크립트에서 주어진 코드에 해당하는 스크립트를 필요로 하는 지를 반환합니다.
        /// </summary>
        /// <param name="scriptTypeCode">판단하고자 하는 스크립트 코드입니다.</param>
        /// <param name="scriptID">판단하고자 하는 스크립트의 ID입니다.</param>
        /// <returns>필요 유무입니다.</returns>
        public bool IsNeedThisScript(int scriptTypeCode, int scriptID)
        {
            return this.CheckNeedScript(scriptKeyElementDictionary[scriptTypeCode], scriptID);
        }

        /// <summary>
        /// 어떤 스크립트 종류가 필요한지 검사합니다.
        /// </summary>
        /// <param name="targetScriptKeyElementName">검사하고자 하는 스크립트에서 핵심적으로 필요한 Xml 엘리먼트의 이름을 나타냅니다.</param>
        /// <param name="scriptID">검사할 Script ID입니다.</param>
        /// <returns></returns>
        private bool CheckNeedScript(string targetScriptKeyElementName, int scriptID)
        {
            try
            {
                string invokeException = this.GetLevelTwoElementValueFromXml(targetScriptKeyElementName, scriptID);
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// 레벨 2인 Xml Element의 값을 가져옵니다.
        /// </summary>
        /// <param name="targetElementName">가져올 Xml Element의 이름입니다.</param>
        /// <param name="scriptID">목표 스크립트가 가지고 있는 Script ID입니다.</param>
        /// <returns>가져온 값을 반환합니다.</returns>
        protected string GetLevelTwoElementValueFromXml(string targetElementName, int scriptID)
        {
            IEnumerable<string> scriptMessage = from scriptElem in this.targetXmlFile.Root.Elements("Script")
                                                where scriptElem.Attribute("ID").Value == scriptID.ToString()
                                                select scriptElem.Element(targetElementName).Value;
            return scriptMessage.ToArray<string>()[0];
        }

    }
}
