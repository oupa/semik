using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SEMIK1
{
    class Serializer
    {
        public Serializer()
        { }

        public bool SaveFDR(string filename, FDR fdr)
        {
            try{
                Stream stream = File.Open(filename, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, fdr);
                stream.Close();
                return true;
            } catch (Exception){
                return false;
            }
        }

        public FDR LoadFDR(string filename)
        {
            try
            {
                FDR fdr;
                Stream stream = File.Open(filename, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                fdr = (FDR)bFormatter.Deserialize(stream);
                stream.Close();
                return fdr;
            }
            catch (Exception e) {
                Logger.Log(e.ToString());
                MessageBox.Show("FDR format incompatible");
                return null;
            }
        }
    }
}
