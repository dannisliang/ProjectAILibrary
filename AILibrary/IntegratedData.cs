using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace AILibrary
{
    /// <summary>
    /// 게임의 통합된 데이터를 관리하는 정적 클래스입니다.
    /// </summary>
    public static class IntegratedData
    {
        private static InnerIntegratedData realizedData;

        /// <summary>
        /// 초기 데이터들을 초기화합니다.
        /// </summary>
        static IntegratedData()
        {
            try
            {
                LoadData();
                throw new InvalidCastException();
            }
            catch (Exception)
            {
                realizedData = new InnerIntegratedData();
                // TODO : if LoadFailed..
                LoadAllFolderToHashMap();
                LoadAllItemToHashMap();

                GetFolderData(0).IsAccessible = true;
                GetFolderData(2).IsAccessible = true;
                GetFolderData(4).IsAccessible = true;
                GetFolderData(5).IsAccessible = true;
                GetFolderData(13).IsAccessible = true;
                
                for (int i = 3001; i <= 3008; i++)
                {
                    GetItemData(i).IsGet = true;
                    GetItemData(i).IsImported = true;
                }

                for (int i = 2030; i <= 2037; i++)
                {
                    GetItemData(i).IsGet = true;
                    GetItemData(i).IsImported = true;
                }
                
                GetItemData(3077).IsGet = true;
                GetItemData(3077).IsImported = true;
            }
        }

        /// <summary>
        /// 게임의 GUI가 세팅되어 있는지에 대한 여부입니다.
        /// </summary>
        public static bool IsGUISet
        {
            get { return realizedData.isGUISet; }
            set { realizedData.isGUISet = value; }
        }

        /// <summary>
        /// 현재 호감도를 가져오거나 설정합니다.
        /// </summary>
        public static int Favor
        {
            get { return realizedData.favor; }
            set
            {
                if (value < 0)
                {
                    throw new NotSupportedException("호감도를 0 미만으로 설정하지 마세요!");
                }

                realizedData.favor = value;
            }
        }

        /// <summary>
        /// 현재 데이터를 파일에 저장합니다.
        /// </summary>
        public static void SaveData()
        {
            //FileStream fileStream = null;

            //try
            //{
            //    fileStream = new FileStream(Application.persistentDataPath + "save.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(fileStream, realizedData);
            //}
            //finally
            //{
            //    fileStream.Close();
            //}
        }

        /// <summary>
        /// 게임 데이터를 파일에서 불러옵니다.
        /// </summary>
        public static void LoadData()
        {
            //FileStream fileStream = null;

            //try
            //{
            //    fileStream = new FileStream(Application.dataPath + "save.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    realizedData = (InnerIntegratedData) formatter.Deserialize(fileStream);
            //}
            //finally
            //{
            //    fileStream.Close();
            //}
        }

        /// <summary>
        /// 폴더의 ID를 이용하여 그에 해당하는 폴더 데이터를 가져옵니다.
        /// </summary>
        /// <param name="folderID">얻고자 하는 폴더의 ID 값입니다.</param>
        /// <returns>해당하는 폴더입니다.</returns>
        public static Folder GetFolderData(int folderID)
        {
            return realizedData.folderHashMap[folderID];
        }

        /// <summary>
        /// 아이템 ID를 이용하여 그에 해당하는 아이템 데이터를 가져옵니다.
        /// </summary>
        /// <param name="itemID">얻고자 하는 아이템의 ID 값입니다.</param>
        /// <returns>해당하는 아이템입니다.</returns>
        public static Item GetItemData(int itemID)
        {
            return realizedData.itemHashMap[itemID];
        }

        /// <summary>
        /// 가장 최근에 참조하고 있는 폴더의 경로를 가져옵니다.
        /// </summary>
        public static string RecentFolderPath
        {
            get { return realizedData.recentConsoleFolderPath; }
        }

        /// <summary>
        /// 가장 최근에 참조하고 있는 폴더의 경로를 반영시킵니다.
        /// </summary>
        /// <param name="folderToChange">경로를 참조시킬 폴더를 가리킵니다.</param>
        /// <param name="isShrink">참조 폴더 경로를 줄이는 것인지, 늘리는 것인지에 대한 여부입니다.</param>
        public static void ChangeRecentFolderPath(Folder folderToChange, bool isShrink)
        {
            if (isShrink)
            {
                realizedData.recentConsoleFolderPath = realizedData.recentConsoleFolderPath.Replace("/" + folderToChange.Name, string.Empty);
            }
            else
            {
                realizedData.recentConsoleFolderPath = realizedData.recentConsoleFolderPath.Replace(folderToChange.UpperFolderInfo.FolderName, folderToChange.UpperFolderInfo.FolderName + "/" + folderToChange.Name);
            }
        }

        /// <summary>
        /// 최근 참조 폴더 경로를 root 폴더로 초기화합니다.
        /// </summary>
        public static void ResetRecentFolderPath()
        {
            realizedData.recentConsoleFolderPath = "<color=lime>/root</color><color=yellow> $ </color>";
        }

        /// <summary>
        /// 폴더 정보가 담겨있는 Xml 파일의 경로를 통해 해쉬맵에 해당 폴더를 추가합니다.
        /// </summary>
        /// <param name="folderXmlPath">폴더 정보가 담겨있는 Xml 파일의 경로입니다.</param>
        private static void AddFolderToHashMap(string folderXmlPath)
        {
            XmlFolderReader folderReader = new XmlFolderReader(Resources.Load<TextAsset>(folderXmlPath).text, false);
            realizedData.folderHashMap.Add(folderReader.GetFolderID(), folderReader.GetFolder());
        }

        /// <summary>
        /// 아이템 정보가 담겨있는 Xml 파일의 경로를 통해 해쉬맵에 해당 아이템을 추가합니다.
        /// </summary>
        /// <param name="itemXmlPath">아이템 정보가 담겨있는 Xml 파일의 경로입니다.</param>
        private static void AddItemToHashMap(string itemXmlPath)
        {
            XmlItemReader itemReader = new XmlItemReader(Resources.Load<TextAsset>(itemXmlPath).text, false);

            switch (itemReader.GetID() / 1000)
            {
                case 0:
                    {
                        realizedData.itemHashMap.Add(itemReader.GetID(), itemReader.GetItemAsWorkBook());
                        break;
                    }
                case 1:
                    {
                        realizedData.itemHashMap.Add(itemReader.GetID(), itemReader.GetItemAsDataAddress());
                        break;
                    }
                case 2:
                    {
                        realizedData.itemHashMap.Add(itemReader.GetID(), itemReader.GetItemAsPartialData());
                        break;
                    }
                case 3:
                    {
                        realizedData.itemHashMap.Add(itemReader.GetID(), itemReader.GetItemAsUnknownData());
                        break;
                    }
            }
        }

        /// <summary>
        /// 모든 폴더 정보를 읽어들여 Dictionary에 추가합니다.
        /// </summary>
        private static void LoadAllFolderToHashMap()
        {
            for (int i = 0; i <= 6; i++)
            {
                AddFolderToHashMap("Folders/" + i);
            }

            for (int i = 11; i <= 19; i++)
            {
                AddFolderToHashMap("Folders/" + i);
            }
        }

        /// <summary>
        /// 모든 아이템 정보를 읽어들여 Dictionary에 추가합니다.
        /// </summary>
        private static void LoadAllItemToHashMap()
        {
            for (int i = 3001; i <= 3008; i++)
            {
                AddItemToHashMap("Items/" + i);
            }

            for (int i = 2030; i <= 2040; i++)
            {
                AddItemToHashMap("Items/" + i);
            }

            AddItemToHashMap("Items/" + 3077);
        }

        /// <summary>
        /// 메인에서 발생하는 Event의 정보를 가지고 있는 인스턴스를 가져옵니다.
        /// </summary>
        public static EventScript Event
        {
            get { return realizedData.mainEventScript; }
        }

        /// <summary>
        /// 게임의 통합적인 데이터를 실질적으로 가지고 있는 클래스입니다. 절대로 외부에서 인스턴스화 하지 마세요.
        /// </summary>
        private class InnerIntegratedData
        {
            public Dictionary<int, Folder> folderHashMap;
            public Dictionary<int, Item> itemHashMap;
            public EventScript mainEventScript;
            public string recentConsoleFolderPath;
            public bool isGUISet;
            public int favor;

            /// <summary>
            /// 새로운 InnerIntegratedData 인스턴스를 만듭니다.
            /// </summary>
            public InnerIntegratedData()
            {
                this.folderHashMap = new Dictionary<int, Folder>();
                this.itemHashMap = new Dictionary<int, Item>();
                this.mainEventScript = new EventScript();
                this.favor = 0;
                this.recentConsoleFolderPath = "<color=lime>/root</color><color=yellow> $ </color>";

            }
        }

        private class GameData
        {

        }
    }
}
