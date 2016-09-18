using System;
//using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using NLog;

namespace FX12U
{
    class Storage
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        Logger logger = LogManager.GetCurrentClassLogger();

		int sizearr;
		//ItemStorage []arrstor;
		string strFileName;
		string strval;

        void ParseString(string str, ItemStorage item)
        { 
        	string []arrayres;
            arrayres = str.Split('=');
            //dic.Add(arrayres[0], arrayres[1]);
            item.key = arrayres[0];
            item.val = arrayres[1];
        }

   
        public Storage()
        {
            sizearr = 32;
            //arrstor = new ItemStorage[sizearr+1];



        }

        public void set(string key, string val)
        {
           // dic.Add(key, val);

            dic[key] = val;

            /*
            //Сначала ищем запись с заданным ключем. Если находим, то присваиваем значение и выходим.
            for (int ind = 0; ind < sizearr; ind++)
            {
                if (arrstor[ind].key.Length > 0)
                {
                    int result = arrstor[ind].key.CompareTo(key);
                    if (result == 0)
                    {
                        arrstor[ind].val = val;
                        return;
                    }
                }
            }
            //Если сюда пришли, значит ключ не нашли. Ищем запись с нулевым ключем и записываем пару "ключ-значение"
            for (int ind = 0; ind < sizearr; ind++)
            {
                if (arrstor[ind].key.Length > 0)
                {

                }
                else
                {
                    arrstor[ind].key = key;
                    arrstor[ind].val = val;
                    return;
                }
            }
            */
        }
        public string get(string key)
        {
            if(dic.Count == 0) 
                return "";
            if( dic.ContainsKey(key) )
                return dic[key];
            else
                return "";

            /*
            for (int ind = 0; ind < sizearr; ind++)
            {
                if (arrstor[ind].key.Length > 0)
                {
                    int result = arrstor[ind].key.CompareTo(key);
                    if (result == 0)
                    {
                        return arrstor[ind].val;
                    }
                }
                else
                {
                    return "";
                }
            }
            return "";
             * */
        }
        public void save(string filename)
        {
            strFileName = filename;

            string strpatch = Path.GetDirectoryName(filename);

            string strpatch1 = Path.GetPathRoot(filename);
            string strpatch2 = Path.GetExtension(filename);
            string strpatch3 = Path.GetDirectoryName(filename);

            if (!Directory.Exists(strpatch))
            {

                return;
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
            //Стираем файлы
            //???FileDelete(filename);
            //Открываем	
            //int handle = FileOpen(strFileName, FILE_READ | FILE_WRITE | FILE_CSV);
            //Пишем
            foreach (KeyValuePair<string, string> itemdic in dic) {

                if (itemdic.Key.Length > 0)
                {

                    string strOut = itemdic.Key + "=" + itemdic.Value + "\r\n";
                    file.Write(strOut);
                }
            
            }
            //Закрываем
            file.Flush();
            file.Close();
        
        }
        public void read(string filename)
        {
            string readstr;
            strFileName = filename;
            if (!File.Exists(strFileName)) {
                logger.Info(" Storage: file " + strFileName + " not exists");
                return;
            
            }
            //int handle = FileOpen(strFileName, FILE_READ | FILE_CSV);
            //System.IO.StreamWriter handle = new System.IO.StreamWriter(strFileName);
            string[] lines = System.IO.File.ReadAllLines(strFileName);

            ItemStorage item = new ItemStorage();

            foreach (string line in lines)
            {
                ParseString(line, item);
                set(item.key, item.val);
            }

        }
		
		public void setDouble(string key, double val)
        {
            set(key, val.ToString());
        }

		public double getDouble(string key)
        {
            strval = get(key);
            if (strval.Length > 0)
            {
                return (double.Parse(strval));
            }
            return 0;
        }

		public void setInt(string key, int val)
        {
            set(key, val.ToString());
        }

		public int getInt(string key)
        {
            strval = get(key);
            if (strval.Length > 0)
            {
                return ( int.Parse(strval));
            }
            return 0;
        }

		public void setBool(string key, bool val)
        {
            if (val)
                set(key, "1");
            else
                set(key, "0");
        }

		public bool getBool(string key)
        {
            strval = get(key);
            if (strval.Length > 0)
            {
                int result = strval.CompareTo("1");
                if (result == 0)
                    return (true);
                else
                    return (false);
            }
            return (false);
        }

		
		public string checkBool(bool val1, bool val2, string name)
        {
            string strres = "";
            if (val1 != val2)
            {
                strres = name + " ( " + val1 + " / " + val2 + " )  ";
            }
            return strres;
        }


		public string checkInt(int val1, int val2, string name)
        {
            string strres = "";
            if (val1 != val2)
            {
                strres = name + " ( " + val1.ToString() + " / " + val2.ToString() + " )  ";
            }
            return strres;
        }

		public string checkDouble(double val1, double val2, string name)
        {
            string strres = "";
            double vd1 = val1 * 10000;
            double vd2 = val2 * 10000;
            int vi1 = (int)vd1;
            int vi2 = (int)vd2;

            if (vi1 != vi2)
            {
                strres = name + " ( " + val1.ToString() + " / " + val2.ToString() + " )  ";
            }
            return strres;
        }	


    }
}
