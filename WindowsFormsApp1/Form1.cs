using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Repository;
using WindowsFormsApp1.Repository.Impl;
using WindowsFormsApp1.Services;
using WindowsFormsApp1.Services.Impl;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private IMarkerService markerService;
        private List<US> us;
        private RepositoryImpl repository;
        private GMapMarker _selectedMarker;

        public Form1()
        {
            markerService = new MarkerService();
            repository = new RepositoryImpl();

            us = repository.GetAllCoordsAsync();

            InitializeComponent();

            gMapControl1.MouseUp += _gMapControl_MouseUp;
            gMapControl1.MouseDown += _gMapControl_MouseDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //выбор подгрузки карты – онлайн или из ресурсов
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; //какой провайдер карт используется (в нашем случае гугл) 
            gMapControl1.MinZoom = 2; //минимальный зум
            gMapControl1.MaxZoom = 16; //максимальный зум
            gMapControl1.Zoom = 4; // какой используется зум при открытии
            gMapControl1.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);// точка в центре карты при открытии (центр России)
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            gMapControl1.CanDragMap = true; // перетаскивание карты мышью
            gMapControl1.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание
            gMapControl1.ShowCenter = false; //показывать или скрывать красный крестик в центре
            gMapControl1.ShowTileGridLines = false; //показывать или скрывать тайлы

            gMapControl1.Overlays.Add(markerService.GetOverlayMarkers(us, "GroupsMarkers"));
        }

        private void _gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            //находим тот маркер над которым нажали клавишу мыши
            _selectedMarker = gMapControl1.Overlays
                .SelectMany(o => o.Markers)
                .FirstOrDefault(m => m.IsMouseOver == true);
        }

        private void _gMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_selectedMarker is null)
                return;

            //переводим координаты курсора мыши в долготу и широту на карте
            var latlng = gMapControl1.FromLocalToLatLng(e.X, e.Y);
            //присваиваем новую позицию для маркера
            _selectedMarker.Position = latlng;

            repository.updateMarker(_selectedMarker.ToolTipText, _selectedMarker.Position.Lat, _selectedMarker.Position.Lng);

            _selectedMarker = null;
        }
    }

}
