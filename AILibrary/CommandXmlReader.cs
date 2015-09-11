using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AILibrary
{
    /// <summary>
    /// 콘솔에 관련된 메시지가 들어있는 Xml 파일을 읽어들이는 클래스입니다.
    /// </summary>
    public class CommandXmlReader
    {
        private XDocument targetXmlFile;

        /// <summary>
        /// 주어진 정보를 이용하여 CommandXmlReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public CommandXmlReader(string filePathOrContent, bool isPath)
        {
            if (isPath)
            {
                this.targetXmlFile = XDocument.Load(filePathOrContent);
            }
            else
            {
                this.targetXmlFile = XDocument.Parse(filePathOrContent);
            }
        }
   
        /// <summary>
        /// 주어진 매개변수를 통해 상황에 맞는 메시지를 불러옵니다. 이 메서드는 Help 명령어가 아니라면 사용하지 마십시오.
        /// </summary>
        /// <param name="command">현재 사용하고자 하는 명령어입니다.</param>
        /// <param name="info">명령어의 입력 상태를 가리킵니다.</param>
        /// <returns>주어진 값에 대한 정보 메시지입니다.</returns>
        public string Message(CommandList command, CommandList info)
        {
            IEnumerable<XElement> foundCommand = from consoleCommand in this.targetXmlFile.Root.Elements("Command")
                                                 where consoleCommand.Attribute("type").Value == command.ToString()
                                                 select consoleCommand;

            IEnumerable<string> interpretedTag = from resultElem in foundCommand.ToArray()[0].Element("Messages").Elements("message")
                                                 where resultElem.Attribute("cause").Value == info.ToString()
                                                 select resultElem.Value;

            return interpretedTag.ToArray<string>()[0];
        }

        /// <summary>
        /// 주어진 매개변수를 통해 상황에 맞는 메시지를 불러옵니다.
        /// </summary>
        /// <param name="command">현재 사용하고자 하는 명령어입니다.</param>
        /// <param name="info">명령어의 입력 상태를 가리킵니다.</param>
        /// <returns>주어진 값에 대한 정보 메시지입니다.</returns>
        public string Message(CommandList command, CommandInfoList info)
        {
            IEnumerable<XElement> foundCommand = from consoleCommand in this.targetXmlFile.Root.Elements("Command")
                                                 where consoleCommand.Attribute("type").Value == command.ToString()
                                                 select consoleCommand;

            IEnumerable<string> interpretedTag = from resultElem in foundCommand.ToArray()[0].Element("Messages").Elements("message")
                                                 where resultElem.Attribute("cause").Value == info.ToString()
                                                 select resultElem.Value;

            return interpretedTag.ToArray<string>()[0];
        }

        /// <summary>
        /// 명령어의 최소 요구 매개변수 개수를 가져옵니다.
        /// </summary>
        /// <param name="command">해당 명령어를 가리킵니다.</param>
        /// <returns>이 명령어의 최소 요구 매개변수 개수입니다.</returns>
        public int MinArgumentNumber(CommandList command)
        {
            IEnumerable<XElement> foundCommand = from consoleCommand in this.targetXmlFile.Root.Elements("Command")
                                                 where consoleCommand.Attribute("type").Value == command.ToString()
                                                 select consoleCommand;

            IEnumerable<string> interpretTag = from foundElem in foundCommand.Elements("Arguments")
                                               select foundElem.Element("min").Value;

            return int.Parse(interpretTag.ToArray<string>()[0]);
        }

        /// <summary>
        /// 명령어의 최대 요구 매개변수 개수를 가져옵니다.
        /// </summary>
        /// <param name="command">해당 명령어를 가리킵니다.</param>
        /// <returns>이 명령어의 최대 요구 매개변수 개수입니다.</returns>
        public int MaxArgumentNumber(CommandList command)
        {
            IEnumerable<XElement> foundCommand = from consoleCommand in this.targetXmlFile.Root.Elements("Command")
                                                 where consoleCommand.Attribute("type").Value == command.ToString()
                                                 select consoleCommand;

            IEnumerable<string> interpretTag = from foundElem in foundCommand.Elements("Arguments")
                                               select foundElem.Element("max").Value;

            return int.Parse(interpretTag.ToArray<string>()[0]);
        }
    }
}
