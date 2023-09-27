using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections.Generic;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services.Impl
{
    public class MarkerService: IMarkerService
    {
        public GMarkerGoogle GetMarker(US us, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
        {
            GMarkerGoogle mapMarker = new GMarkerGoogle(new GMap.NET.PointLatLng(us.Coordinates.Latitude, us.Coordinates.Longitude), gMarkerGoogleType);//широта, долгота, тип маркера
            mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);//всплывающее окно с инфой к маркеру
            mapMarker.ToolTipText = us.Id; // текст внутри всплывающего окна
            mapMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver; //отображение всплывающего окна (при наведении)
            return mapMarker;
        }

        public GMapOverlay GetOverlayMarkers(List<US> uss, string name, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
        {
            GMapOverlay gMapMarkers = new GMapOverlay(name);// создание именованного слоя 
            foreach (US us in uss)
            {
                gMapMarkers.Markers.Add(GetMarker(us, gMarkerGoogleType));// добавление маркеров на слой
            }
            return gMapMarkers;
        }
    }
}
