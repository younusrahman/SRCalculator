using Newtonsoft.Json;
using SRCalculator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace SRCalculator.Services
{
    class DataStore : IDataStore<Item>
    {
        //public static string FileName => fname("UserName" + ".xml");



        public static string filename = "DemoUser.json";
        static string localpath;

        public static List<Item> items;

        //static string fname(string name)
        //{
        //    var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //    documentPath = Path.Combine(documentPath, "S4R", "Calculator");
        //    if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
        //    return Path.Combine(documentPath, name);
        //}


        public static void Serialize()
        {



            var _locker = new object();
            lock (_locker)
            {
                string json = JsonConvert.SerializeObject(items, Formatting.Indented);


                File.WriteAllText(localpath, json);
                //using (StreamWriter file = File.CreateText(FileName))
                //{


                //    JsonSerializer serializer = new JsonSerializer();
                //    serializer.Serialize(file, items);
                //}
            }

        }

        public async static void Deserialize()
        {

            if (File.Exists(localpath))
            {

                using (var stream = await FileSystem.OpenAppPackageFileAsync(filename))
                {
                    using (StreamReader streamread = new StreamReader(stream))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        items = (List<Item>)serializer.Deserialize(streamread, typeof(List<Item>)); ;
                    }

                }
            }
            else
            {
                items = new List<Item>();
            }

            //{
            //    using (StreamReader file = File.OpenText(FileName))
            //    {
            //        JsonSerializer serializer = new JsonSerializer();
            //        items = (List<Item>)serializer.Deserialize(file, typeof(List<Item>));;
            //    }
            //}
            //catch (Exception)
            //{

            //    items = new List<Item>();
            //}            
        }




        public DataStore()
        {
            items = new List<Item>();
            localpath = Path.Combine(FileSystem.AppDataDirectory, filename);
            Deserialize();

        }



        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
