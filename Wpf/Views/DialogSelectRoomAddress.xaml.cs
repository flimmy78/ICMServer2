﻿using ICMServer.Models;
using ICMServer.WPF.Models;
using ICMServer.WPF.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace ICMServer.WPF.Views
{
    /// <summary>
    /// DialogSelectRoomAddressViewModel.xaml 的互動邏輯
    /// </summary>
    public partial class DialogSelectRoomAddress : Window
    {
        DialogSelectDevicesViewModel _viewModel;

        public DialogSelectRoomAddress()
        {
            InitializeComponent();
            this.DataContext = _viewModel = new DialogSelectDevicesViewModel(
                ServiceLocator.Current.GetInstance<ICollectionModel<Device>>(), 14);
        }

        // 單選
        // TODO: 複選要怎麼做?
        public string RoomAddress
        {
            get
            {
                if (_viewModel.SelectedItem != null)
                {
                    DeviceNodeViewModel node = _viewModel.SelectedItem as DeviceNodeViewModel;
                    if (node != null)
                        return node.DeviceAddress;
                }
                return "";
            }
            set { _viewModel.Address = value; }
        }
    }
}