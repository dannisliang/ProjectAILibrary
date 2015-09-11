using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 폴더 정보가 들어있는 Xml 파일을 읽어 Parsing 해주는 클래스입니다.
    /// </summary>
    public class XmlFolderReader : XmlReader
    {
        /// <summary>
        /// 주어진 정보를 이용하여 XmlFolderReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlFolderReader(string filePathOrContent, bool isPath)
            : base(filePathOrContent, isPath)
        {
        }

        /// <summary>
        /// 현재 참조하려고 하는 Xml 파일이 유효한 Xml 파일인지 검사합니다. 유효하지 않을 시 예외가 throw 됩니다.
        /// </summary>
        public override void CheckValidXmlContent()
        {
            if (this.targetXmlFile.Root.Name != "Folder")
            {
                throw new NotSupportedException("잘못된 Xml 파일에 접근하려고 합니다. (Folder)");
            }
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 폴더의 정보를 가져옵니다.
        /// </summary>
        /// <returns>폴더의 정보입니다.</returns>
        public Folder GetFolder()
        {
            return new Folder(this.GetFolderID(), this.GetFolderName(), this.GetFolderSprite(), this.GetUpperFolder(), false, this.GetLowerFolder(), this.GetItems());
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 폴더의 ID를 가져옵니다.
        /// </summary>
        /// <returns>폴더의 ID입니다.</returns>
        public int GetFolderID()
        {
            IEnumerable<string> idValue = from folderElem in this.targetXmlFile.Root.Elements()
                                          where folderElem.Name == "ID"
                                          select folderElem.Value;

            return int.Parse(idValue.ToArray<string>()[0]);
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 폴더 이미지(Sprite)를 가져옵니다. 가져올 때는 Resources 폴더 하위에 있는 Images 폴더에서 참조하게 됩니다.
        /// </summary>
        /// <returns>폴더 이미지 (Sprite)입니다.</returns>
        public Sprite GetFolderSprite()
        {
            IEnumerable<string> spriteValue = from folderElem in this.targetXmlFile.Root.Elements("Sprite")
                                              select folderElem.Value;

            return Resources.Load<Sprite>("Images/" + spriteValue.ToArray<string>()[0]);
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 상위 폴더의 정보를 가져옵니다. 상위 폴더가 존재하지 않으면 null을 반환합니다.
        /// </summary>
        /// <returns>상위 폴더의 정보입니다.</returns>
        public FolderShortcut GetUpperFolder()
        {
            try
            {
                IEnumerable<string> upperFolderIDEnumerator = from folderElem in this.targetXmlFile.Root.Elements("UpperFolder")
                                                              select folderElem.Element("ID").Value;

                IEnumerable<string> upperFolderNameEnumerator = from folderElem in this.targetXmlFile.Root.Elements("UpperFolder")
                                                                select folderElem.Element("Name").Value;

                IEnumerable<string> upperFolderSpriteEnumerator = from folderElem in this.targetXmlFile.Root.Elements("UpperFolder")
                                                                  select folderElem.Element("Sprite").Value;

                int folderID = int.Parse(upperFolderIDEnumerator.ToArray<string>()[0]);
                string folderName = upperFolderNameEnumerator.ToArray<string>()[0];
                Sprite folderSprite = Resources.Load<Sprite>("Images/" + upperFolderSpriteEnumerator.ToArray<string>()[0]);
                return new FolderShortcut(folderID, folderName, folderSprite);
            }
            catch (IndexOutOfRangeException)
            {
                if (this.targetXmlFile.Root.Element("UpperFolder") == null)
                {
                    return null;
                }

                throw new NullReferenceException("상위 폴더를 가져올 수 없습니다.");
            }
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 하위 폴더들의 정보를 가져옵니다.
        /// </summary>
        /// <returns>하위 폴더의 정보입니다.</returns>
        public FolderShortcut[] GetLowerFolder()
        {
            try
            {
                IEnumerable<string> lowerFolderIDEnumerator = from folderElem in this.targetXmlFile.Root.Elements("LowerFolder")
                                                              select folderElem.Element("ID").Value;
                IEnumerable<string> lowerFolderNameEnumerator = from folderElem in this.targetXmlFile.Root.Elements("LowerFolder")
                                                                select folderElem.Element("Name").Value;
                IEnumerable<string> lowerFolderSpriteEnumerator = from folderElem in this.targetXmlFile.Root.Elements("LowerFolder")
                                                                  select folderElem.Element("Sprite").Value;

                int[] splitedLowerFolderID = Array.ConvertAll(lowerFolderIDEnumerator.ToArray<string>()[0].Split('/'), int.Parse);
                string[] splitedLowerFolderName = lowerFolderNameEnumerator.ToArray<string>()[0].Split('/');
                string[] splitedLowerFolderSprite = lowerFolderSpriteEnumerator.ToArray<string>()[0].Split('/');
                List<FolderShortcut> lowerFolderList = new List<FolderShortcut>();



                if (splitedLowerFolderID.Length != this.GetLowerFolderNumber() || splitedLowerFolderName.Length != this.GetLowerFolderNumber()
                    || splitedLowerFolderSprite.Length != this.GetLowerFolderNumber())
                {
                    throw new ArgumentException("Xml 파일에 명시된 하위 폴더 개수와 실제 하위 폴더 개수가 다릅니다.");
                }

                for (int i = 0; i < splitedLowerFolderID.Length; i++)
                {
                    lowerFolderList.Add(new FolderShortcut(splitedLowerFolderID[i], splitedLowerFolderName[i], Resources.Load<Sprite>("Images/" + splitedLowerFolderSprite[i])));
                }

                return lowerFolderList.ToArray();
            }
            catch (FormatException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                if (this.GetLowerFolderNumber() == 0)
                {
                    return null;
                }

                throw new ArgumentException("Xml 파일에 명시된 하위 폴더 개수와 실제 하위 폴더 개수가 다릅니다.");
            }
        }


        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 폴더의 이름을 가져옵니다.
        /// </summary>
        /// <returns>폴더의 이름입니다.</returns>
        public string GetFolderName()
        {
            IEnumerable<string> nameValue = from folderElem in this.targetXmlFile.Root.Elements()
                                            where folderElem.Name == "Name"
                                            select folderElem.Value;

            return nameValue.ToArray<string>()[0];
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 하위 폴더의 개수를 가져옵니다.
        /// </summary>
        /// <returns>하위 폴더의 개수입니다.</returns>
        public int GetLowerFolderNumber()
        {
            IEnumerable<string> lowerFolderEnumerator = from folderElem in this.targetXmlFile.Root.Elements("LowerFolder")
                                                        select folderElem.Element("Number").Value;

            return int.Parse(lowerFolderEnumerator.ToArray<string>()[0]);
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 폴더에 포함된 아이템들의 개수를 가져옵니다.
        /// </summary>
        /// <returns>포함된 아이템의 개수입니다.</returns>
        public int GetItemNumber()
        {
            IEnumerable<string> itemEnumerator = from folderElem in this.targetXmlFile.Root.Elements("Items")
                                                 select folderElem.Element("Number").Value;

            return int.Parse(itemEnumerator.ToArray<string>()[0]);
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 폴더에 포함된 아이템들을 가져옵니다.
        /// </summary>
        /// <returns>아이템의 배열입니다.</returns>
        public Item[] GetItems()
        {
            List<Item> itemList = new List<Item>();
            IEnumerable<string> itemEnumerator = from folderElem in this.targetXmlFile.Root.Elements("Items")
                                                 select folderElem.Element("LinkTo").Value;
            string[] itemLinks = itemEnumerator.ToArray<string>()[0].Split('/');

            if (itemLinks[0] == string.Empty)
            {
                return null;
            }

            if (this.GetItemNumber() != itemLinks.Length)
            {
                throw new ArgumentException("Xml 파일에 명시된 아이템 개수와 실제 아이템 개수가 다릅니다.");
            }

            foreach (string itemLink in itemLinks)
            {
                XmlItemReader itemReader = new XmlItemReader(Resources.Load<TextAsset>("Items/" + itemLink).text, false);

                switch (itemReader.GetID() / 1000)
                {
                    case 0:
                        {
                            itemList.Add(itemReader.GetItemAsWorkBook());
                            break;
                        }
                    case 1:
                        {
                            itemList.Add(itemReader.GetItemAsDataAddress());
                            break;
                        }
                    case 2:
                        {
                            itemList.Add(itemReader.GetItemAsPartialData());
                            break;
                        }
                    case 3:
                        {
                            itemList.Add(itemReader.GetItemAsUnknownData());
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("아이템 ID가 잘못된 듯 싶습니다.");
                        }
                }
            }

            return itemList.ToArray();
        }
    }
}
