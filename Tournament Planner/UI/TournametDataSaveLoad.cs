using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Tournament_Planner.BL;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.UI
{
    public class TournametDataSaveLoad
    {
        private Tournament data;

        public TournametDataSaveLoad(Tournament data)
        {
            this.data = data;
        }

        public bool SavePlayersList(string fileName)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    new XmlSerializer(typeof(TournamentData)).Serialize(stream, this.data.GetXmlData());
                    File.WriteAllBytes(fileName, stream.ToArray());
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
                return false;
            }
        }

        public bool LoadPlayersList(string fileName)
        {
            try
            {
                TournamentData newData;
                using (var stream = new MemoryStream(File.ReadAllBytes(fileName)))
                {
                    newData = new XmlSerializer(typeof(TournamentData)).Deserialize(stream) as TournamentData;
                }

                this.data.SetXmlData(newData);

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message);
                return false;
            }
        }
    }
}
