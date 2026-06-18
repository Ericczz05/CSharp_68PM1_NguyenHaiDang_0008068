using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLSINHVIEN
{
    public partial class UCQLLH : UserControl
    {
        databaseDataContext db = new databaseDataContext();
        private const int SoDongMoiTrang = 10;
        private int trangHienTai = 1;
        private int tongSoDong = 0;
        private int tongSoTrang = 1;
        private int lopHocDangChonId = 0;

        public UCQLLH()
        {
            InitializeComponent();
            CauHinhDataGridView();
            CauHinhPhanTrang();
            txt_id_lop.ReadOnly = true;
            btn_add.Click += btn_add_Click;
            btn_edit.Click += btn_edit_Click;
            btn_delete.Click += btn_delete_Click;
            btn_refresh.Click += btn_refresh_Click;
            LoadLopHoc();
        }

        private void CauHinhDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void CauHinhPhanTrang()
        {
            button6.Click += button6_Click;
            button7.Click += button7_Click;
            button9.Click += button9_Click;
            button8.Click += button8_Click;
        }

        private void CapNhatThongTinPhanTrang()
        {
            label7.Text = $"Trang {trangHienTai}/{tongSoTrang} | {tongSoDong} bản ghi";
            button6.Enabled = trangHienTai > 1;
            button7.Enabled = trangHienTai > 1;
            button9.Enabled = trangHienTai < tongSoTrang;
            button8.Enabled = trangHienTai < tongSoTrang;
        }

        private void ChuyenTrang(int trangMoi)
        {
            trangMoi = Math.Max(1, Math.Min(trangMoi, tongSoTrang));
            if (trangMoi == trangHienTai)
            {
                return;
            }

            trangHienTai = trangMoi;
            LoadLopHoc();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            DoThongTinLopHoc(dataGridView1.Rows[e.RowIndex]);
        }

        private void DoThongTinLopHoc(DataGridViewRow row)
        {
            int.TryParse(LayGiaTriCell(row, "id"), out lopHocDangChonId);
            txt_id_lop.Text = LayGiaTriCell(row, "id");
            txt_ma_lop.Text = LayGiaTriCell(row, "malop");
            txt_ten_lop.Text = LayGiaTriCell(row, "tenlop");
            txt_ghichu_lop.Text = LayGiaTriCell(row, "ghichu");
        }

        private string LayGiaTriCell(DataGridViewRow row, string columnName)
        {
            if (!dataGridView1.Columns.Contains(columnName))
            {
                return string.Empty;
            }

            object value = row.Cells[columnName].Value;
            return value == null || value == DBNull.Value ? string.Empty : value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChuyenTrang(tongSoTrang);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChuyenTrang(trangHienTai + 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChuyenTrang(trangHienTai - 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChuyenTrang(1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void UCQLLH_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_2(object sender, EventArgs e)
        {

        }

        private void label4_Click_2(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void label5_Click_2(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
        private void loadUC(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
            uc.BringToFront();
        }
        public void button10_Click(object sender, EventArgs e)
        {
            string maLop = txt_ma_lop.Text.Trim();
            if (lopHocDangChonId <= 0 || string.IsNullOrWhiteSpace(maLop))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xem danh sách sinh viên");
                return;
            }

            lophoc lop = db.lophocs.FirstOrDefault(l => l.id == lopHocDangChonId && l.malop == maLop);
            if (lop == null)
            {
                MessageBox.Show("Không tìm thấy lớp học cần xem danh sách sinh viên");
                LoadLopHoc();
                lamMoiThongTinNhap();
                return;
            }

            UCQLSV ucSinhVien = new UCQLSV();
            ucSinhVien.HienThiSinhVienTheoLop(maLop);
            loadUC(ucSinhVien);
        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void txt_class_id_TextChanged(object sender, EventArgs e)
        {

        }
        public void loadlop()
        {
            LoadLopHoc();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            update();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void add()
        {
            try
            {
                if (!kiemTraDuLieuNhap())
                {
                    return;
                }

                string maLop = txt_ma_lop.Text.Trim();
                if (db.lophocs.Any(l => l.malop == maLop))
                {
                    MessageBox.Show("Mã lớp đã tồn tại");
                    txt_ma_lop.Focus();
                    return;
                }

                lophoc lop = new lophoc();
                lop.malop = maLop;
                lop.tenlop = txt_ten_lop.Text.Trim();
                lop.ghichu = txt_ghichu_lop.Text.Trim();

                db.lophocs.InsertOnSubmit(lop);
                db.SubmitChanges();

                MessageBox.Show("Thêm thành công");
                trangHienTai = int.MaxValue;
                LoadLopHoc();
                lamMoiThongTinNhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update()
        {
            try
            {
                if (lopHocDangChonId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn lớp học cần sửa");
                    return;
                }

                if (!kiemTraDuLieuNhap())
                {
                    return;
                }

                string maLop = txt_ma_lop.Text.Trim();
                if (db.lophocs.Any(l => l.malop == maLop && l.id != lopHocDangChonId))
                {
                    MessageBox.Show("Mã lớp đã tồn tại");
                    txt_ma_lop.Focus();
                    return;
                }

                lophoc lop = db.lophocs.FirstOrDefault(l => l.id == lopHocDangChonId);
                if (lop == null)
                {
                    MessageBox.Show("Không tìm thấy lớp học cần sửa");
                    LoadLopHoc();
                    lamMoiThongTinNhap();
                    return;
                }

                lop.malop = maLop;
                lop.tenlop = txt_ten_lop.Text.Trim();
                lop.ghichu = txt_ghichu_lop.Text.Trim();

                db.SubmitChanges();

                MessageBox.Show("Sửa thành công");
                LoadLopHoc();
                lamMoiThongTinNhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete()
        {
            try
            {
                if (lopHocDangChonId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn lớp học cần xóa");
                    return;
                }

                lophoc lop = db.lophocs.FirstOrDefault(l => l.id == lopHocDangChonId);
                if (lop == null)
                {
                    MessageBox.Show("Không tìm thấy lớp học cần xóa");
                    LoadLopHoc();
                    lamMoiThongTinNhap();
                    return;
                }

                if (db.sinhviens.Any(sv => sv.malop == lop.malop))
                {
                    MessageBox.Show("Không thể xóa lớp đang có sinh viên");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa lớp {lop.tenlop}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }

                db.lophocs.DeleteOnSubmit(lop);
                db.SubmitChanges();

                MessageBox.Show("Xóa thành công");
                LoadLopHoc();
                lamMoiThongTinNhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh()
        {
            txt_search.Clear();
            trangHienTai = 1;
            LoadLopHoc();
            lamMoiThongTinNhap();
        }

        private bool kiemTraDuLieuNhap()
        {
            if (string.IsNullOrWhiteSpace(txt_ma_lop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp");
                txt_ma_lop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_ten_lop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp");
                txt_ten_lop.Focus();
                return false;
            }

            return true;
        }

        private void lamMoiThongTinNhap()
        {
            lopHocDangChonId = 0;
            txt_id_lop.Clear();
            txt_ma_lop.Clear();
            txt_ten_lop.Clear();
            txt_ghichu_lop.Clear();
            dataGridView1.ClearSelection();
        }

        private void LoadLopHoc()
        {
            var ds = from l in db.lophocs
                     orderby l.id
                     select new
                     {
                         l.id,
                         l.malop,
                         l.tenlop,
                         l.ghichu
                     };

            tongSoDong = db.lophocs.Count();
            tongSoTrang = Math.Max(1, (int)Math.Ceiling((double)tongSoDong / SoDongMoiTrang));
            trangHienTai = Math.Max(1, Math.Min(trangHienTai, tongSoTrang));

            dataGridView1.DataSource = ds.Skip((trangHienTai - 1) * SoDongMoiTrang)
                                         .Take(SoDongMoiTrang)
                                         .ToList();
            lopHocDangChonId = 0;
            dataGridView1.ClearSelection();
            CapNhatThongTinPhanTrang();
        }
    }

}
