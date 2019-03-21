﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigUtils
{
    class ConfigParser
    {
        public Dictionary<string, Wilaya> wilayas { get; set; }

        public ConfigParser()
        {
            wilayas = new Dictionary<string, Wilaya>();
        }

        public ConfigParser(Dictionary<string, Wilaya> wilayas)
        {
            this.wilayas = wilayas;
        }

        public void export(string config)
        {
            string json = JsonConvert.SerializeObject(wilayas);

            using(var f = new StreamWriter(new FileStream(config, FileMode.Create), Encoding.UTF8))
            {
                f.Write(json);
            }
        }

        public void import(string config)
        {
            string json;
            using(var f = new StreamReader(File.OpenRead(config), Encoding.UTF8))
            {
                json = f.ReadToEnd();
            }
            wilayas = JsonConvert.DeserializeObject<Dictionary<string, Wilaya>>(json);
        }
    }
}