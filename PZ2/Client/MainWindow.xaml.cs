using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GMapOverlay markersSubstationEntity = new GMapOverlay("markersSubstationEntity");
        GMapOverlay markersNodeEntity = new GMapOverlay("markersNodeEntity");
        GMapOverlay markersSwitchEntity = new GMapOverlay("markersSwitchEntity");
        GMapOverlay markersLinesEntity = new GMapOverlay("markersLinesEntity");
        GMapOverlay routes = new GMapOverlay("routes");
        GMapOverlay polygons = new GMapOverlay("polygons");
        List<PointLatLng> points = new List<PointLatLng>();
        List<PointLatLng> points2 = new List<PointLatLng>();
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;

            // Initialize map:
            gmap.MapProvider = GMapProviders.GoogleMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            Lists lists = new Lists();
            gmap.Position = new PointLatLng(45.25116, 19.823758);
            gmap.Zoom = 12;

            
            gmap.Overlays.Add(markersSubstationEntity);
            gmap.Overlays.Add(markersNodeEntity);
            gmap.Overlays.Add(markersSwitchEntity);
            gmap.Overlays.Add(routes);
            gmap.Overlays.Add(polygons);
        }

        private void ToLatLon(double utmX, double utmY, int zoneUTM, out double latitude, out double longitude)
        {
            bool isNorthHemisphere = true;

            var diflat = -0.00066286966871111111111111111111111111;
            var diflon = -0.0003868060578;

            var zone = zoneUTM;
            var c_sa = 6378137.000000;
            var c_sb = 6356752.314245;
            var e2 = Math.Pow((Math.Pow(c_sa, 2) - Math.Pow(c_sb, 2)), 0.5) / c_sb;
            var e2cuadrada = Math.Pow(e2, 2);
            var c = Math.Pow(c_sa, 2) / c_sb;
            var x = utmX - 500000;
            var y = isNorthHemisphere ? utmY : utmY - 10000000;

            var s = ((zone * 6.0) - 183.0);
            var lat = y / (c_sa * 0.9996);
            var v = (c / Math.Pow(1 + (e2cuadrada * Math.Pow(Math.Cos(lat), 2)), 0.5)) * 0.9996;
            var a = x / v;
            var a1 = Math.Sin(2 * lat);
            var a2 = a1 * Math.Pow((Math.Cos(lat)), 2);
            var j2 = lat + (a1 / 2.0);
            var j4 = ((3 * j2) + a2) / 4.0;
            var j6 = ((5 * j4) + Math.Pow(a2 * (Math.Cos(lat)), 2)) / 3.0;
            var alfa = (3.0 / 4.0) * e2cuadrada;
            var beta = (5.0 / 3.0) * Math.Pow(alfa, 2);
            var gama = (35.0 / 27.0) * Math.Pow(alfa, 3);
            var bm = 0.9996 * c * (lat - alfa * j2 + beta * j4 - gama * j6);
            var b = (y - bm) / v;
            var epsi = ((e2cuadrada * Math.Pow(a, 2)) / 2.0) * Math.Pow((Math.Cos(lat)), 2);
            var eps = a * (1 - (epsi / 3.0));
            var nab = (b * (1 - epsi)) + lat;
            var senoheps = (Math.Exp(eps) - Math.Exp(-eps)) / 2.0;
            var delt = Math.Atan(senoheps / (Math.Cos(nab)));
            var tao = Math.Atan(Math.Cos(delt) * Math.Tan(nab));

            longitude = ((delt * (180.0 / Math.PI)) + s) + diflon;
            latitude = ((lat + (1 + e2cuadrada * Math.Pow(Math.Cos(lat), 2) - (3.0 / 2.0) * e2cuadrada * Math.Sin(lat) * Math.Cos(lat) * (tao - lat)) * (tao - lat)) * (180.0 / Math.PI)) + diflat;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GMapMarker marker;

            double latitude;
            double longitude;

            foreach (SubstationEntity se in Lists.Substations)
            {
                ToLatLon(Double.Parse(se.X), Double.Parse(se.Y), 34, out latitude, out longitude);
                marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red);
                markersSubstationEntity.Markers.Add(marker);
                points2.Add(new PointLatLng(latitude, longitude));
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            GMapMarker marker;

            double latitude;
            double longitude;
            
            foreach (NodeEntity se in Lists.Nodes)
            {
                ToLatLon(Double.Parse(se.X), Double.Parse(se.Y), 34, out latitude, out longitude);
                marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.yellow);
                markersNodeEntity.Markers.Add(marker);
                points2.Add(new PointLatLng(latitude, longitude));
            }
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            GMapMarker marker;

            double latitude;
            double longitude;

            foreach (SwitchEntity se in Lists.Swtitches)
            {
                ToLatLon(Double.Parse(se.X), Double.Parse(se.Y), 34, out latitude, out longitude);
                marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.blue);
                markersSwitchEntity.Markers.Add(marker);
                points2.Add(new PointLatLng(latitude, longitude));
            }
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            double latitude;
            double longitude;
            List<PointLatLng> points = new List<PointLatLng>();
            Lists.Lines.ForEach(x =>
            {
                x.Vertice.Points.ForEach(y =>
                {
                    ToLatLon(Double.Parse(y.X), Double.Parse(y.Y), 34, out latitude, out longitude);
                    points.Add(new PointLatLng(latitude, longitude));
                    GMapPolygon polygon = new GMapPolygon(points, "");
                    polygon.Fill = new SolidBrush(System.Drawing.Color.Transparent);
                    polygon.Stroke = new System.Drawing.Pen(System.Drawing.Color.Blue, 1);
                    polygons.Polygons.Add(polygon);
                });
                points.Clear();
            });
            //var route = GoogleMapProvider.Instance.GetRoute(points[0], points[10], false, false, 12);
            //var r = new GMapRoute(points, "routes");
            //r.Stroke = new Pen(Color.Blue, 1);

            //routes.Routes.Add(r);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            markersSwitchEntity.Clear();
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            routes.Clear();
            points.Clear();
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            markersNodeEntity.Clear();
        }

        private void CheckBox_Unchecked_3(object sender, RoutedEventArgs e)
        {
            markersSubstationEntity.Clear();
        }

    }
}
