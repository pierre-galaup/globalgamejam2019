using Newtonsoft.Json;
using Save;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public PlayerManager PlayerManager { get; private set; }
        public StatsManager StatsManager { get; private set; }

        public int daysPassed = 0;
        public bool soldierSaved = false;

        private string _savePath;

        public void NewGame()
        {
            Debug.Log("New game requested");

            daysPassed = 0;
            PlayerManager.CurrentMoney = Constants.InitialMoney;
            soldierSaved = false;
            PlayerManager.maxHealthPoints = Constants.InitialPlayerHealthPoint;
            PlayerManager.maxAmmoNumber = Constants.InitialAmmoNumber;
            PlayerManager.damagesPerFire = Constants.InitialDamagesPerFire;
            PlayerManager.fireRate = Constants.InitialFireRate;

            SaveGame();
            LoadScene();
        }

        public void SaveGame()
        {
            SaveObject saveObject = new SaveObject
            {
                daysPassed = daysPassed,
                currentMoney = PlayerManager.CurrentMoney,
                maxHp = PlayerManager.maxHealthPoints,
                maxAmmo = PlayerManager.maxAmmoNumber,
                dmgPerFire = PlayerManager.damagesPerFire,
                fireRate = PlayerManager.fireRate,
                totalZombiesKilled = StatsManager.totalZombiesKilled,
                damagesDealt = StatsManager.damagesDealt,
                deaths = StatsManager.deaths,
                damagesTaken = StatsManager.damagesTaken,
                totalAmmoFired = StatsManager.totalAmmoFired,
                moneyEarned = StatsManager.moneyEarned,
                soldierSaved = soldierSaved
            };

            if (!Directory.Exists(Application.persistentDataPath))
            {
                Directory.CreateDirectory(Application.persistentDataPath);
            }

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(_savePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, saveObject);
                Debug.Log($"Saved game to {_savePath}");
                Debug.Log($"Data saved:{Environment.NewLine}{JsonConvert.SerializeObject(saveObject, Formatting.Indented)}");
            }
        }

        public void LoadGame()
        {
            SaveObject saveObject = null;

            Debug.Log($"Loading save from {_savePath}");

            IFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(_savePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                saveObject = formatter.Deserialize(stream) as SaveObject;
            }

            if (saveObject == null)
            {
                Debug.Log("No data loaded from save");
                return;
            }
            Debug.Log($"Loaded data: {Environment.NewLine}{JsonConvert.SerializeObject(saveObject, Formatting.Indented)}");

            daysPassed = saveObject.daysPassed;
            PlayerManager.CurrentMoney = saveObject.currentMoney;
            PlayerManager.maxHealthPoints = saveObject.maxHp;
            PlayerManager.maxAmmoNumber = saveObject.maxAmmo;
            PlayerManager.damagesPerFire = saveObject.dmgPerFire;
            PlayerManager.fireRate = saveObject.fireRate;
            soldierSaved = saveObject.soldierSaved;

            StatsManager.damagesDealt = saveObject.damagesDealt;
            StatsManager.damagesTaken = saveObject.damagesTaken;
            StatsManager.deaths = saveObject.deaths;
            StatsManager.moneyEarned = saveObject.moneyEarned;
            StatsManager.totalAmmoFired = saveObject.totalAmmoFired;
            StatsManager.totalZombiesKilled = saveObject.totalZombiesKilled;

            LoadScene();
        }

        public bool CanLoadGame()
        {
            return File.Exists(_savePath);
        }

        private void Awake()
        {
            Instance = this;
            _savePath = Path.Combine(Application.persistentDataPath, "save.dat");
            PlayerManager = GetComponent<PlayerManager>();
            StatsManager = GetComponent<StatsManager>();
        }

        private void LoadScene()
        {
            Debug.Log("Loading scene 'Camp'...");
            SceneManager.LoadScene("Camp");
        }
    }
}