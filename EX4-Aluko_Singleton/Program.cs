using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //for file class
using Newtonsoft.Json; //addition for JSON format



/*
 * Tyler Aluko
 * IGME.201 - Unit Test #4 (Final)
 * This console application defines and uses a singleton class.
 * The singleton includes methods to load and save players' settings.
 * Furthermore, it serializes and deserializes the structure with the Newtonsoft JSON package.
 */
namespace EX4_Aluko_Singleton
{
    
    
    //singleton class manages player settings
    public class PlayerSettingsManager
    {
        
        private static PlayerSettingsManager instance; //initialized instance

        //player settings structure
        public class PlayerSettings
        {
            public string PlayerName { get; set; }
            public int Level { get; set; }
            public int Hp { get; set; }
            public string[] Inventory { get; set; }
            public string LicenseKey { get; set; }
        }

        //path to settings file
        private readonly string settingsFilePath = "playerSettings.json";

        private PlayerSettingsManager() { }

        //singleton instance property
        public static PlayerSettingsManager Instance
        {
            get
            {
                
                if (instance == null)
                { //if no instances of PlaySettingsManager
                    instance = new PlayerSettingsManager(); //create new instance
                }

                return instance; //then return

            }
        }

        //load player settings from file
        public PlayerSettings LoadSettings()
        {
            
            if (File.Exists(settingsFilePath))
            { //if there is file in correct path
                string json = File.ReadAllText(settingsFilePath); //read text
                return JsonConvert.DeserializeObject<PlayerSettings>(json); //then deserialize
            }

            //return default settings if file doesn't exist
            return GetDefaultSettings();

        }

        //save player settings to file
        public void SaveSettings(PlayerSettings settings)
        {
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented); //serialize (format was a little weird-- this fixed it on my end)
            File.WriteAllText(settingsFilePath, json); //write text
        }

        //get default player settings
        private PlayerSettings GetDefaultSettings()
        {
            //JSON format
            return new PlayerSettings
            {
                PlayerName = "dschuh",
                Level = 4,
                Hp = 99,
                Inventory = new[] 
                {
                    "spear", 
                    "water bottle", 
                    "hammer", 
                    "sonic screwdriver", 
                    "cannonball", 
                    "wood", 
                    "Scooby snack", 
                    "Hydra", 
                    "poisonous potato", 
                    "dead bush", 
                    "repair powder"
                },
                LicenseKey = "DFGU99-1454"
            };
        }

    }

    class Program
    {
        static void Main()
        {
            
            try //hopefully prevents any crashes
            {
                //get the singleton instance of PlayerSettingsManager
                PlayerSettingsManager manager = PlayerSettingsManager.Instance;

                //load player settings
                PlayerSettingsManager.PlayerSettings settings = manager.LoadSettings();

                //display loaded settings
                Console.WriteLine("Loaded Player Settings");
                Console.WriteLine();
                Console.WriteLine($"Player Name: {settings.PlayerName}");
                Console.WriteLine($"Level: {settings.Level}");
                Console.WriteLine($"HP: {settings.Hp}");
                Console.WriteLine("Inventory: " + string.Join(", ", settings.Inventory));
                Console.WriteLine($"License Key: {settings.LicenseKey}");

                //modify settings
                settings.Level++;

                //save modified settings
                manager.SaveSettings(settings);

                Console.WriteLine("\nSettings modified and saved."); //confirmation message
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled Exception: {ex.Message}");
            }
            finally //keep program open
            {
                Console.ReadLine();
            }

        }
    }


}
