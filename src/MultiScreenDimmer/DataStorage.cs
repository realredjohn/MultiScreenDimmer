using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DimScreen
{
    public class DataStorage
    {
        private readonly string _filePath;
        private List<MonitorInfo> _monitorInfoList;
        private List<Profile> _profileList;
        private bool _hideOnCloseCheckboxState;

        public DataStorage(string filePath)
        {
            this._filePath = filePath;
            _monitorInfoList = new List<MonitorInfo>();
            _profileList = new List<Profile>();
        }


        // MonitorInfo methods
        public void SaveMonitorInfo(MonitorInfo monitorInfo)
        {
            _monitorInfoList.Add(monitorInfo);
            SaveData();
        }

        public void EditMonitorInfo(string monitorIdentifier, string newDisplayName)
        {
            var existingInfo = _monitorInfoList.FirstOrDefault(info => info.MonitorIdentifier == monitorIdentifier);
            existingInfo?.UpdateDisplayName(newDisplayName);
            SaveData();
        }

        public List<MonitorInfo> LoadMonitorInfo()
        {
            LoadData();
            return _monitorInfoList;
        }

        public bool IsMonitorInfoSaved(string monitorIdentifier)
        {
            return _monitorInfoList.Any(savedInfo => savedInfo.MonitorIdentifier == monitorIdentifier);
        }

        public string GetMonitorName(string monitorIdentifier)
        {
            var monitor = _monitorInfoList.FirstOrDefault(info => info.MonitorIdentifier == monitorIdentifier);
            return monitor?.DisplayName ?? "Unknown";
        }

        public MonitorInfo GetMonitorInfo(string monitorIdentifier)
        {
            return _monitorInfoList.FirstOrDefault(info => info.MonitorIdentifier == monitorIdentifier);
        }



        // Profile methods
        public void SaveProfile(Profile profile)
        {
            _profileList.Add(profile);
            SaveData();
        }

        public List<Profile> LoadProfiles()
        {
            LoadData();
            return _profileList;
        }

        public void DeleteProfile(string profileName)
        {
            var existingProfile = _profileList.FirstOrDefault(profile => profile.ProfileName == profileName);
            _profileList.Remove(existingProfile);
            SaveData();
        }

        public int GetNextAvailableSlotIndex()
        {
            var existingProfileNames = _profileList.Select(profile => profile.ProfileName).ToList();

            for (int i = 1; i <= existingProfileNames.Count + 1; i++)
            {
                if (!existingProfileNames.Contains($"Profile {i}"))
                {
                    return i;
                }
            }

            return existingProfileNames.Count + 1;
        }


        public void EditProfileShortcut(string profileName, Keys[] newShortcut)
        {
            var existingProfile = _profileList.FirstOrDefault(profile => profile.ProfileName == profileName);
            existingProfile?.UpdateShortcut(newShortcut);
            SaveData();
        }


        // HideOnCloseCheckbox 
        public void SaveMinimizeCheckBoxState(bool state)
        {
            _hideOnCloseCheckboxState = state;
            SaveData();
        }

        public bool LoadMinimizeCheckBoxState()
        {
            LoadData();
            return _hideOnCloseCheckboxState;
        }


        // Data operations
        private void SaveData()
        {
            DataContainer dataContainer = new DataContainer
            {
                MonitorInfoList = _monitorInfoList,
                ProfileList = _profileList,
                HideOnCloseCheckboxState = _hideOnCloseCheckboxState
            };

            string jsonData = JsonSerializer.Serialize(dataContainer);
            File.WriteAllText(_filePath, jsonData);
        }

        private void LoadData()
        {
            if (File.Exists(_filePath))
            {
                string jsonData = File.ReadAllText(_filePath);
                var dataContainer = JsonSerializer.Deserialize<DataContainer>(jsonData);
                _monitorInfoList = dataContainer?.MonitorInfoList ?? new List<MonitorInfo>();
                _profileList = dataContainer?.ProfileList ?? new List<Profile>();
                _hideOnCloseCheckboxState = dataContainer?.HideOnCloseCheckboxState ?? true;
            }
        }
    }

    public class MonitorInfo
    {
        public string? DisplayName { get; set; }
        public string? MonitorIdentifier { get; set; }

        public void UpdateDisplayName(string newDisplayName)
        {
            DisplayName = newDisplayName;
        }
    }

    public class Profile
    {
        public string? ProfileName { get; set; }
        public List<MonitorInfo>? MonitorInfoList { get; set; }
        public int Opacity { get; set; }
        public Keys[]? Shortcut { get; set; }

        public void UpdateShortcut(Keys[] newShortcut)
        {
            Shortcut = newShortcut;
        }
    }

    public class DataContainer
    {
        public List<MonitorInfo>? MonitorInfoList { get; set; }
        public List<Profile>? ProfileList { get; set; }
        public bool HideOnCloseCheckboxState { get; set; }
    }
}
