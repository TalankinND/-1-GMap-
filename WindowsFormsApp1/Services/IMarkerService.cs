using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections.Generic;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services
{
    public interface IMarkerService
    {
        GMarkerGoogle GetMarker(US us, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red);
        GMapOverlay GetOverlayMarkers(List<US> uss, string name, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red);
    }
}
