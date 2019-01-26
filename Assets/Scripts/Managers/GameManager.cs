using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Save;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public PlayerManager PlayerManager { get; private set; }

        public int daysPassed = 0;

        public float EnemyHealthMultiplier => 1f + daysPassed * 1.1f;
        public float EnemyDamagesMultiplier => 1f + daysPassed * 1.1f;

        private string _savePath;

        public void NewGame()
        {
            Debug.Log("New game requested");

            daysPassed = 0;
            PlayerManager.CurrentMoney = 500;
            PlayerManager.maxHealthPoints = 200;
            PlayerManager.maxAmmoNumber = 60;
            PlayerManager.damagesPerFire = 30;
            PlayerManager.fireRate = 2;

            SaveGame();
            LoadScene();
        }

        public void SaveGame()
        {
            var saveObject = new SaveObject
            {
                daysPassed = daysPassed,
                currentMoney = PlayerManager.CurrentMoney,
                maxHp = PlayerManager.maxHealthPoints,
                maxAmmo = PlayerManager.maxAmmoNumber,
                dmgPerFire = PlayerManager.damagesPerFire,
                fireRate = PlayerManager.damagesPerFire
            };

            if (!Directory.Exists(Application.persistentDataPath))
                Directory.CreateDirectory(Application.persistentDataPath);

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
            using (var stream = new FileStream(_savePath, FileMode.Open, FileAccess.Read, FileShare.None))
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
        }

        private void LoadScene()
        {
            Debug.Log("Loading scene 'Camp'...");
            SceneManager.LoadScene("Camp");
        }
    }
}
