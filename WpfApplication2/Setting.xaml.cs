﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Page
    {
        List<string>  languages = new List<string>() {"Английский", "Русский" };
        List<string>  themes= new List<string>() {"Темная", "Светлая", "Розовая" };
        List<string>  outLine= new List<string>() {"Да", "Нет" };
        List<int> size = new List<int>();

        public Setting()
        {
            InitializeComponent();
            for (int i = 2; i <= 72; i += 2)
            {
                size.Add(i);
            }

            langListBox.ItemsSource = languages;    
            microphoneListBox.ItemsSource = GetAvailableMicrophones();
            themesList.ItemsSource = themes;
            outlineList.ItemsSource= outLine;
            SizeList.ItemsSource= size;
        }
        public ObservableCollection<string> GetAvailableMicrophones()
        {
            ObservableCollection<string> microphones = new ObservableCollection<string>();
            var waveInDevices = WaveInEvent.DeviceCount;

            for (int deviceId = 0; deviceId < waveInDevices; deviceId++)
            {
                var waveInCapabilities = WaveInEvent.GetCapabilities(deviceId);
                microphones.Add(waveInCapabilities.ProductName);
            }

            return microphones;
        }

    }
}