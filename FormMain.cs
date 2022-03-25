using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using MySql.Data.MySqlClient;

namespace Map
{
    public partial class FormMain : Form
    {
        double corX, corY;
        string nameTech;
        int quantity, x, y;
        List<Points> point = new List<Points>();

        DBPoint dbPoint = new DBPoint();
        DataTable dt = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command;

        GMapMarker selectMarker;

        GMapOverlay layVic = new GMapOverlay("Vicings");
        GMapOverlay layHel = new GMapOverlay("Hellion");
        GMapOverlay layBatCr = new GMapOverlay("Battlecruiser");
        GMapOverlay layMed = new GMapOverlay("Medivak");
        GMapOverlay layMinWid = new GMapOverlay("Mina Widow");
        GMapOverlay laySiTan = new GMapOverlay("Siege Tank");
        GMapOverlay layThor = new GMapOverlay("Thor");
        GMapOverlay layHellbat = new GMapOverlay("Hellbat");
        GMapOverlay layCyclon = new GMapOverlay("Cyclon");

        public FormMain()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //выбор подгрузки карты – онлайн или из ресурсов
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; //какой провайдер карт используется (в нашем случае гугл)
            gMap.MinZoom = 2; //минимальный зум
            gMap.MaxZoom = 16; //максимальный зум
            gMap.Zoom = 4; // какой используется зум при открытии
            gMap.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);// точка в центре карты при открытии (центр России)
            gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            gMap.CanDragMap = true; // перетаскивание карты мышью
            gMap.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание
            gMap.ShowCenter = false; //показывать или скрывать красный крестик в центре
            gMap.ShowTileGridLines = false; //показывать или скрывать тайлы

            LoadData();

            //Заполнение листа точками
            for (int i = 0; i < dgTech.Rows.Count - 1; i++)
                point.Add(new Points(Convert.ToString(dt.Rows[i][0]), Convert.ToInt32(dt.Rows[i][1]), Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])));
            
            //Контекстное меню
            gMap.ContextMenuStrip = contextMenuMap; //Ассоциация контекстного меню
        }

        //Получение основных данных
        private void LoadData()
        {
            //Очистка таблицы
            //dgTech.Rows.Clear();
            while (dgTech.Rows.Count > 1)
                for (int i = 0; i < dgTech.Rows.Count - 1; i++)
                    dgTech.Rows.Remove(dgTech.Rows[i]);

            //Команда для получения основынх данных из БД
            command = new MySqlCommand("SELECT tech.nameTech AS nameTech, coordinates_of_points.quantity AS quantity, coordinates_of_points.coordinateX AS coordinateX, coordinates_of_points.coordinateY AS coordinateY FROM coordinates_of_points INNER JOIN tech ON coordinates_of_points.idTech = tech.idTech", dbPoint.getConnection());

            //Выполнение запроса и заполнение данных
            adapter.SelectCommand = command;
            adapter.Fill(dt);

            //Вывод данных по единицам техники
            dgTech.DataSource = dt;
            dgTech.Columns[0].HeaderText = "Техника";
            dgTech.Columns[1].HeaderText = "Количество";
            dgTech.Columns[2].HeaderText = "Координата X";
            dgTech.Columns[3].HeaderText = "Координата Y";
        }

        //КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ
        //Добавление метки
        private void bAddPoint_Click(object sender, EventArgs e)
        {
            addPoint();
        }

        private void bUpdPoint_Click(object sender, EventArgs e)
        {

        }

        //Удаление метки
        private void bDeletePoint_Click(object sender, EventArgs e)
        {

        }

        //Добавление метки через контекстное меню
        private void создатьНовуюМеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var latlng = gMap.FromLocalToLatLng(x, y);
            addPoint(latlng.Lng, latlng.Lat);
        }

        //КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ КНОПКИ



        //Открытие формы с созданием новой метки
        private void addPoint(double _x = 0, double _y = 0)
        {
            FormAddPoint addPoint = new FormAddPoint(_x, _y);
            addPoint.ShowDialog();

            LoadData();
        }



        //СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ 
        //Создание слоя с Геллионами
        private void cbHel_CheckedChanged(object sender, EventArgs e)
        {
            gMap.Overlays.Add(layHel);
            if (cbHel.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToString(dt.Rows[i][0]) == "Геллион")
                    {
                        Bitmap b = new Bitmap(@"Icons/hellion.png");
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])), new Bitmap(b, new Size(80, 80)));
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = Convert.ToString(dt.Rows[i][0]) + " " + Convert.ToString(dt.Rows[i][1]);
                        layHel.Markers.Add(marker);
                    }

                gMap.Overlays.Add(layHel);
            }
            else
                layHel.Clear();
        }

        //Создание слоя с Линейными Крейсерами
        private void cbBatCr_CheckedChanged(object sender, EventArgs e)
        {
            gMap.Overlays.Add(layBatCr);
            if (cbBatCr.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToString(dt.Rows[i][0]) == "Линейный Крейсер")
                    {
                        Bitmap b = new Bitmap(@"Icons/battlecruiser.png");
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])), new Bitmap(b, new Size(80, 80)));
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = Convert.ToString(dt.Rows[i][0]) + " " + Convert.ToString(dt.Rows[i][1]);
                        layBatCr.Markers.Add(marker);
                    }

                gMap.Overlays.Add(layBatCr);
            }
            else
                layBatCr.Clear();
        }

        //Создание слоя с Медиваками
        private void cbMed_CheckedChanged(object sender, EventArgs e)
        {
            gMap.Overlays.Add(layMed);
            if (cbMed.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToString(dt.Rows[i][0]) == "Медивак")
                    {
                        Bitmap b = new Bitmap(@"Icons/medivac.png");
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])), new Bitmap(b, new Size(80, 80)));
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = Convert.ToString(dt.Rows[i][0]) + " " + Convert.ToString(dt.Rows[i][1]);
                        layMed.Markers.Add(marker);
                    }

                gMap.Overlays.Add(layMed);
            }
            else
                layMed.Clear();
        }

        //Создание слоя с минами вдовами
        private void cbMinWid_CheckedChanged(object sender, EventArgs e)
        {
            gMap.Overlays.Add(layMinWid);
            if (cbMinWid.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToString(dt.Rows[i][0]) == "Мина Вдова")
                    {
                        Bitmap b = new Bitmap(@"Icons/mina.png");
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])), new Bitmap(b, new Size(80, 80)));
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = Convert.ToString(dt.Rows[i][0]) + " " + Convert.ToString(dt.Rows[i][1]);
                        layMinWid.Markers.Add(marker);
                    }

                gMap.Overlays.Add(layMinWid);
            }
            else
                layMinWid.Clear();
        }

        //Создание слоя с Осадными Танками
        private void cbSiTan_CheckedChanged(object sender, EventArgs e)
        {
            gMap.Overlays.Add(laySiTan);
            if (cbSiTan.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToString(dt.Rows[i][0]) == "Осадный Танк")
                    {
                        Bitmap b = new Bitmap(@"Icons/siege tank.png");
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])), new Bitmap(b, new Size(80,80)));
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = Convert.ToString(dt.Rows[i][0]) + " " + Convert.ToString(dt.Rows[i][1]);
                        laySiTan.Markers.Add(marker);
                    }

                gMap.Overlays.Add(laySiTan);
            }
            else
                laySiTan.Clear();
        }

        //Создание слоя с Торами
        private void cbThor_CheckedChanged(object sender, EventArgs e)
        {
            gMap.Overlays.Add(layThor);
            if (cbThor.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToString(dt.Rows[i][0]) == "Тор")
                    {
                        Bitmap b = new Bitmap(@"Icons/thor.png");
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])), new Bitmap(b, new Size(80, 80)));
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = Convert.ToString(dt.Rows[i][0]) + " " + Convert.ToString(dt.Rows[i][1]);
                        layThor.Markers.Add(marker);
                    }

                gMap.Overlays.Add(layThor);
            }
            else
                layThor.Clear();
        }

        //Создание слоя с Хеллбатами
        private void cbHellbat_CheckedChanged(object sender, EventArgs e)
        {
            gMap.Overlays.Add(layHellbat);
            if (cbHellbat.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToString(dt.Rows[i][0]) == "Хеллбат")
                    {
                        Bitmap b = new Bitmap(@"Icons/hellbat.png");
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])), new Bitmap(b, new Size(80, 80)));
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = Convert.ToString(dt.Rows[i][0]) + " " + Convert.ToString(dt.Rows[i][1]);
                        layHellbat.Markers.Add(marker);
                    }

                gMap.Overlays.Add(layHellbat);
            }
            else
                layHellbat.Clear();
        }

        //Создание слоя с Циклонами
        private void cbCyclon_CheckedChanged(object sender, EventArgs e)
        {
            gMap.Overlays.Add(layCyclon);
            if (cbCyclon.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToString(dt.Rows[i][0]) == "Циклон")
                    {
                        Bitmap b = new Bitmap(@"Icons/cyclon.png");
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])), new Bitmap(b, new Size(80, 80)));
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = Convert.ToString(dt.Rows[i][0]) + " " + Convert.ToString(dt.Rows[i][1]);
                        layCyclon.Markers.Add(marker);
                    }

                gMap.Overlays.Add(layCyclon);
            }
            else
                layCyclon.Clear();
        }

        //Создание слоя с Викингами
        private void cbVic_CheckedChanged(object sender, EventArgs e)
        {
            gMap.Overlays.Add(layVic);
            if (cbVic.Checked)
            {
                for (int i = 0; i < dgTech.Rows.Count; i++)
                    if (Convert.ToString(dgTech[0,i]) == "Викинг")
                    {
                        Bitmap b = new Bitmap(@"Icons/viking.png");
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][3])), new Bitmap(b, new Size(80, 80)));
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = Convert.ToString(dt.Rows[i][0]) + " " + Convert.ToString(dt.Rows[i][1]);
                        layVic.Markers.Add(marker);
                    }

                gMap.Overlays.Add(layVic);
            }
            else
                layVic.Clear();
        }
        //СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ СЛОИ 



        //Перенос маркеров
        private void gMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectMarker is null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                var latlng = gMap.FromLocalToLatLng(e.X, e.Y);
                selectMarker.Position = latlng;

                selectMarker = null;
            }
        }
        private void gMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectMarker = gMap.Overlays.SelectMany(o => o.Markers).FirstOrDefault(m => m.IsMouseOver == true);
            if (e.Button == MouseButtons.Right)
            {
                x = e.X;
                y = e.Y;
            }
        }
    }
}
